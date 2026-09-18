using AutoMapper.Configuration;
using Dapper;
using HotelBooking.Entity.Common;
using HotelBooking.Entity.Common.Entities;
using HotelBooking.Entity.Common.Enums;
using HotelBooking.Entity.Common.Helpers;
using HotelBooking.Entity.Entities;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Data;
using System.Data.SqlClient;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
 

namespace HotelBooking.DataAccess.Base
{
    public class UserLoginLookupRepository : IUserLoginLookupRepositoryInterface
    {
        #region Global Variables
        private readonly IDbConnection _dbConnection;
        private readonly ILogger<UserLoginLookupRepository> logger;
        private readonly Microsoft.Extensions.Configuration.IConfiguration _configuration;

        #endregion
            
        public UserLoginLookupRepository(ILogger<UserLoginLookupRepository> _logger, IDbConnection dbConnection, Microsoft.Extensions.Configuration.IConfiguration configuration)
        {
            logger = _logger;
            _dbConnection = dbConnection;
            _configuration = configuration;
        }


        #region Login
        public async Task<LoginResponseEntity> UserLogin(LoginRequestEntity entity, string storedProcedure)
        {
            LoginResponseEntity result = new LoginResponseEntity();

            try
            {
                Dapper.DefaultTypeMap.MatchNamesWithUnderscores = true;

                // STEP 1: Find tenant from master database
                using var masterConnection = new SqlConnection(
                    _configuration.GetConnectionString("TemplateConnection"));

                var tenant = await masterConnection.QueryFirstOrDefaultAsync<TenantInfo>(
                @"SELECT *
          FROM tblOrganization
          WHERE OrganizationCode = @OrganizationCode
          AND IsActive = 1
          AND IsDeleted = 0",
                new { entity.OrganizationCode });

                if (tenant == null)
                {
                    result.Message = "failure";
                    result.Details = "Invalid Organization Code.";
                    return result;
                }

                // STEP 2: Build tenant connection string
                var tenantConnectionString =
                    $"Server={tenant.ServerName};" +
                    $"Database={tenant.DatabaseName};" +
                    $"User Id={tenant.UserName};" +
                    $"Password={tenant.Password};" +
                    $"TrustServerCertificate=True;";

                using var tenantConnection =
                    new SqlConnection(tenantConnectionString);


                // --- Subscription check: verify RegistrationDate and RenewDate ---
                try
                {
                    // Get RegistrationDate from tblCompanyinfo (assume single active record)
                    var registrationDate = await tenantConnection.QueryFirstOrDefaultAsync<DateTime?>(
                        "SELECT TOP 1 RegistrationDate FROM tblCompanyinfo  ");

                    // Get the latest RenewDate from tblRenewCompany (if any)
                    var renewDate = await tenantConnection.QueryFirstOrDefaultAsync<DateTime?>(
                        "SELECT MAX(RenewDate) FROM tblRenewCompany ");

                    var now = DateTime.Now;

                    // If neither date exists, allow login to proceed. If at least one date exists and is in the future, allow login.
                    // If both dates exist and both are <= now (i.e. expired), return special expired message.
                    bool hasRegistration = registrationDate.HasValue;
                    bool hasRenew = renewDate.HasValue;

                    bool registrationValid = hasRegistration && registrationDate.Value > now;
                    bool renewValid = hasRenew && renewDate.Value > now;

                    if ((hasRegistration || hasRenew) && !(registrationValid || renewValid))
                    {
                        // Both dates are present (or at least one present) and none are in the future -> expired
                        result.Message = "company_expired";
                        result.Details = "Company subscription expired.";
                        return result;
                    }
                }
                catch (Exception ex)
                {
                    // Log and continue with login - do not block login on subscription-check DB errors
                    logger.LogWarning(ex, "Failed to validate company subscription dates.");
                }


                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@UserName", entity.UserName);
                dynamicParameters.Add("@Password", HashPassword.EncryptPlainTextToCipherText(entity.Password));
                dynamicParameters.Add("@OperationType", 1);

                // STEP 3: Login against tenant database
                var Userdata = await tenantConnection.QueryMultipleAsync(
                    storedProcedure,
                    dynamicParameters,
                    commandType: CommandType.StoredProcedure);

                LoginResponseEntity data =
                    await Userdata.ReadFirstOrDefaultAsync<LoginResponseEntity>();

                if (data == null)
                {
                    result.Message = "failure";
                    result.Details = "UserName or Password Not valid.";
                    return result;
                }
                if (data.Message == "success")
                {
                    result.Message = Convert.ToString(data.Message);
                    result.UserGUID = data.UserGUID;
                    result.ID = Convert.ToInt16(data.ID);
                    result.Name = Convert.ToString(data.Name);
                    result.MobileNo = Convert.ToString(data.MobileNo);
                    result.EmailID = Convert.ToString(data.EmailID);
                    result.Details = Convert.ToString(data.Details);
                    result.UserName = Convert.ToString(data.UserName);
                    result.IsUser = Convert.ToInt32(data.IsUser);            
                    result.Organizationlogo = Convert.ToString(data.Organizationlogo);            
                    result.OrganizationName = Convert.ToString(data.OrganizationName);            

                    if (data != null)
                    {
                        var User = await Userdata.ReadAsync<UserRightsAssign>();
                        result.UserRightsAssign = User.ToList();
                    }
                    var token = GenerateJwtToken(result.ID.ToString(), result.UserGUID.ToString(), (int)result.IsUser);
                    var refreshToken = GenerateRefereshJwtToken(result.ID.ToString(), result.UserGUID.ToString(), (int)result.IsUser);
                    result.Token = token;
                    result.RefreshToken = refreshToken;
                    result.UserTypeID = Convert.ToInt32(data.UserTypeID);
                    await UpdateRefreshToken(result.UserGUID, refreshToken, "sp_ManageToken");



                }
                else
                {
                    result.Message = Convert.ToString(data.Message);
                    result.Details = Convert.ToString(data.Details);
                }
            }
            catch (SqlException sqlException)
            {
                result.Message = sqlException.Message;
                result.Details = String.Empty;
            }
            catch (Exception ex)
            {
                result.Message = CommonRepositoryMessages.ExceptionMessage;
            }
            finally
            {
            }

            return result;
        }

        public static string GetTenantSecretKey(string organizationName)
        {
            using var sha = SHA256.Create();

            var bytes = sha.ComputeHash(
                Encoding.UTF8.GetBytes(
                    organizationName + "_HotelBooking_2026"));

            return Convert.ToBase64String(bytes);
        }

        public string Authenticate(string userId, string userGUID, int IsUser)
        {
            return GenerateJwtToken(userId, userGUID, IsUser);
        }

        private string GenerateJwtToken(string userId, string userGUID, int IsUser)
        {
            // generate token that is valid for 1 days
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(CommonRepositoryConstants.SecretKey);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim("userId", userId),
                     new Claim("userGUID", userGUID),
                    new Claim("isUser", IsUser.ToString())

                }),

                Expires = DateTime.UtcNow.AddDays(30),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        public async Task UpdateRefreshToken(Guid? userGUID, string refreshToken,  string storedProcedure)
        {
            try
            {
                Dapper.DefaultTypeMap.MatchNamesWithUnderscores = true;
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@UserGUID", userGUID);
                dynamicParameters.Add("@Token", refreshToken);
                dynamicParameters.Add("@OperationType", CommonRepositoryConstants.Insert);
                var data = await _dbConnection.QueryFirstOrDefaultAsync(storedProcedure, dynamicParameters, commandType: System.Data.CommandType.StoredProcedure);
            }

            catch (Exception)
            {

                throw;
            }
            finally
            {

            }
        }


        private string GenerateRefereshJwtToken(string userId, string userGUID, int IsUser)
        {
            // generate token that is valid for 1 days
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(CommonRepositoryConstants.SecretKey);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim("userId", userId),
                     new Claim("userGUID", userGUID),
                    new Claim("isUser", IsUser.ToString())

                }),

                Expires = DateTime.UtcNow.AddDays(30),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        #endregion

        public async Task<LoginResponseEntity> CheckRefreshToken(UserToken entity, string storedProcedure)
        {
            LoginResponseEntity result = new LoginResponseEntity();

            try
            {
                Dapper.DefaultTypeMap.MatchNamesWithUnderscores = true;
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@Token", entity.RefreshToken);
                dynamicParameters.Add("@OperationType", 2);
                var data = await _dbConnection.QueryFirstOrDefaultAsync<LoginResponseEntity>(storedProcedure, dynamicParameters, commandType: System.Data.CommandType.StoredProcedure);
                if (data.Message == "success")
                {
                    result.Message = Convert.ToString(data.Message);
                    result.UserGUID = data.UserGUID;
                    result.ID = Convert.ToInt16(data.ID);
                    result.Name = Convert.ToString(data.Name);
                    result.MobileNo = Convert.ToString(data.MobileNo);
                    result.EmailID = Convert.ToString(data.EmailID);
                    result.Details = Convert.ToString(data.Details);
                    result.UserName = Convert.ToString(data.UserName);
                    result.IsUser = Convert.ToInt32(data.IsUser);
                    var token = GenerateJwtToken(result.ID.ToString(), result.UserGUID.ToString(), (int)result.IsUser);
                    result.Token = token;
                }
                else
                {
                    result.Message = Convert.ToString(data.Message);
                    result.Details = Convert.ToString(data.Details);
                }
            }
            catch (SqlException sqlException)
            {
                result.Message = sqlException.Message;
                result.Details = String.Empty;
            }
            catch (Exception ex)
            {
                result.Message = CommonRepositoryMessages.ExceptionMessage;
            }
            finally
            {
            }

            return result;
        }

        #region Manage User Change Password
        public async Task<ResultModel> ManageUserChangePassword(ChangePasswordRequestEntity entity, string storedProcedure)
        {
            ResultModel result = new ResultModel();

            try
            {
                Dapper.DefaultTypeMap.MatchNamesWithUnderscores = true;
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@ID", entity.ID);
                dynamicParameters.Add("@OldPassword", HashPassword.EncryptPlainTextToCipherText(entity.OldPassword));
                dynamicParameters.Add("@Password", HashPassword.EncryptPlainTextToCipherText(entity.Password));
                dynamicParameters.Add("@OperationType", 2);
                var data = await _dbConnection.QueryAsync(storedProcedure, dynamicParameters, commandType: CommandType.StoredProcedure);
                result.Message = data.FirstOrDefault().Message;
                result.Details = data.FirstOrDefault().Details;

            }
            catch (SqlException sqlException)
            {
                logger.LogError(sqlException, sqlException.Message);
                result.ErrorMessage = sqlException.Message;
                result.Status = (int)ResponseStatusCode.InternaServerError;
                result.Message = CommonRepositoryMessages.CannotFindAllMessage;
                result.Details = CommonRepositoryMessages.CannotFindAllDetails;

            }
            catch (Exception ex)
            {
                result.Status = (int)ResponseStatusCode.InternaServerError;
                result.Message = CommonRepositoryMessages.ExceptionMessage;
                result.ErrorMessage = ex.Message;

            }
            finally
            {

            }

            return result;
        }
        #endregion

        #region Manage User Reset Password
        public async Task<ResultModel> ManageUserResetPassword(ChangePasswordRequestEntity entity, string storedProcedure)
        {
            ResultModel result = new ResultModel();

            try
            {
                Dapper.DefaultTypeMap.MatchNamesWithUnderscores = true;
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@ID", entity.ID);
                dynamicParameters.Add("@OperationType", 3);
                var data = await _dbConnection.QueryAsync(storedProcedure, dynamicParameters, commandType: CommandType.StoredProcedure);
                result.Message = data.FirstOrDefault().Message;
                result.Details = data.FirstOrDefault().Details;

            }
            catch (SqlException sqlException)
            {
                logger.LogError(sqlException, sqlException.Message);
                result.ErrorMessage = sqlException.Message;
                result.Status = (int)ResponseStatusCode.InternaServerError;
                result.Message = CommonRepositoryMessages.CannotFindAllMessage;
                result.Details = CommonRepositoryMessages.CannotFindAllDetails;

            }
            catch (Exception ex)
            {
                result.Status = (int)ResponseStatusCode.InternaServerError;
                result.Message = CommonRepositoryMessages.ExceptionMessage;
                result.ErrorMessage = ex.Message;

            }
            finally
            {

            }

            return result;
        }
        #endregion

        public async Task<EmailOtpVerificationEntity> OtpGenerateByEmail(
    EmailOtpVerificationEntity entity,
    string storedProcedure)
        {
            EmailOtpVerificationEntity result = new EmailOtpVerificationEntity();

            try
            {
                Dapper.DefaultTypeMap.MatchNamesWithUnderscores = true;

                DynamicParameters param = new DynamicParameters();
                param.Add("@EmailID", entity.EmailID);
                param.Add("@OperationType", 1);

                // SP returns multiple result sets
                using var multi = await _dbConnection.QueryMultipleAsync(
                    storedProcedure,
                    param,
                    commandType: CommandType.StoredProcedure);

                // Result Set 1: OTP details
                var data = multi.ReadFirstOrDefault<EmailOtpVerificationEntity>();

                // Result Set 2: Company Logo
                var logoData = multi.ReadFirstOrDefault<EmailOtpVerificationEntity>();

                if (data != null)
                {
                    // Assign Image returned from second result set
                    data.Image = logoData?.Image;
                }

                if (data != null && data.Message?.ToLower() == "success")
                {
                    string emailTo = entity.EmailID;

                    if (!string.IsNullOrWhiteSpace(emailTo))
                    {
                        HotelBooking.Entity.Common.Methods.SendEmail sendEmail =
                            new HotelBooking.Entity.Common.Methods.SendEmail();

                        string subject = "Your One-Time Password (OTP)";

                        // Logo returned from SP
                        string logoUrl = data.Image;

                        string body = $@"
                <!DOCTYPE html>
                <html>
                <head>
                    <meta charset='UTF-8'>
                    <meta name='viewport' content='width=device-width, initial-scale=1.0'>
                    <title>OTP Verification</title>
                </head>

                <body style='margin:0; padding:0; background-color:#f4f6f8; font-family:Arial, Helvetica, sans-serif;'>

                    <table width='100%' cellpadding='0' cellspacing='0' border='0'
                           style='background-color:#f4f6f8;'>
                        <tr>
                            <td align='center' style='padding:40px 15px;'>

                                <table width='480' cellpadding='0' cellspacing='0' border='0'
                                       style='width:100%; max-width:480px; background-color:#ffffff;'>

                                    <!-- Header with Logo + Title -->
                                    <tr>
                                        <td align='center'
                                            style='background-color:#667eea; padding:20px 30px;'>

                                            <table cellpadding='0' cellspacing='0' border='0' align='center'>
                                                <tr>

                                                    <!-- Logo -->
                                                    <td align='right' valign='middle'
                                                        style='padding-right:15px;'>

                                                        <img src='{logoUrl}'
                                                             alt='Company Logo'
                                                             width='80'
                                                             style='display:block;
                                                                    width:80px;
                                                                    max-width:80px;
                                                                    height:auto;
                                                                    border:0;
                                                                    outline:none;
                                                                    text-decoration:none;' />

                                                    </td>

                                                    <!-- Title -->
                                                    <td align='left' valign='middle'>
                                                        <p style='margin:0;
                                                                  padding:0;
                                                                  color:#ffffff;
                                                                  font-family:Arial, Helvetica, sans-serif;
                                                                  font-size:22px;
                                                                  line-height:30px;
                                                                  font-weight:bold;'>
                                                            Verification Code
                                                        </p>
                                                    </td>

                                                </tr>
                                            </table>

                                        </td>
                                    </tr>

                                    <!-- Body -->
                                    <tr>
                                        <td align='center'
                                            style='padding:40px 30px 30px 30px;
                                                   background-color:#ffffff;'>

                                            <p style='margin:0 0 12px 0;
                                                      color:#4a5568;
                                                      font-family:Arial, Helvetica, sans-serif;
                                                      font-size:16px;
                                                      line-height:24px;'>
                                                Use the following code to continue
                                            </p>

                                            <!-- OTP -->
                                            <table cellpadding='0' cellspacing='0' border='0'
                                                   align='center'
                                                   style='margin:28px auto;'>
                                                <tr>
                                                    <td align='center'
                                                        style='background-color:#f7fafc;
                                                               border:2px dashed #cbd5e0;
                                                               padding:18px 32px;'>

                                                        <p style='margin:0;
                                                                  padding:0;
                                                                  color:#2d3748;
                                                                  font-family:Arial, Helvetica, sans-serif;
                                                                  font-size:36px;
                                                                  line-height:42px;
                                                                  font-weight:bold;
                                                                  letter-spacing:8px;'>
                                                            {data.OTP}
                                                        </p>

                                                    </td>
                                                </tr>
                                            </table>

                                            <p style='margin:0 0 8px 0;
                                                      color:#718096;
                                                      font-family:Arial, Helvetica, sans-serif;
                                                      font-size:14px;
                                                      line-height:22px;'>
                                                This code is valid for <strong>10 minutes</strong>
                                            </p>

                                            <p style='margin:20px 0 0 0;
                                                      color:#a0aec0;
                                                      font-family:Arial, Helvetica, sans-serif;
                                                      font-size:13px;
                                                      line-height:20px;'>
                                                If you did not request this code,
                                                you can safely ignore this email.
                                            </p>

                                        </td>
                                    </tr>

                                    <!-- Footer -->
                                    <tr>
                                        <td align='center'
                                            style='background-color:#f7fafc;
                                                   padding:18px 30px;
                                                   border-top:1px solid #edf2f7;'>

                                            <p style='margin:0;
                                                      color:#a0aec0;
                                                      font-family:Arial, Helvetica, sans-serif;
                                                      font-size:12px;
                                                      line-height:18px;'>
                                                This is an automated message. Please do not reply.
                                            </p>

                                        </td>
                                    </tr>

                                </table>

                            </td>
                        </tr>
                    </table>

                </body>
                </html>";

                        sendEmail.MailSendSMTP(
                            emailTo,
                            "",
                            subject,
                            body,
                            "");
                    }

                    // Hide OTP from API response
                    data.OTP = null;
                }

                return data ?? result;
            }
            catch (SqlException ex)
            {
                result.Message = ex.Message;
                result.Details = string.Empty;
                throw;
            }
            catch (Exception)
            {
                result.Message = CommonRepositoryMessages.ExceptionMessage;
                throw;
            }
        }

        public async Task<EmailOtpVerificationEntity> OtpVerifyByEmail(EmailOtpVerificationEntity entity, string storedProcedure)
        {
            EmailOtpVerificationEntity result = new EmailOtpVerificationEntity();

            try
            {
                Dapper.DefaultTypeMap.MatchNamesWithUnderscores = true;

                DynamicParameters param = new DynamicParameters();
                param.Add("@EmailID", entity.EmailID);
                param.Add("@OTP", entity.OTP);
                param.Add("@OperationType", 2);   // Verify OTP

                var data = await _dbConnection.QueryFirstOrDefaultAsync<EmailOtpVerificationEntity>(
                    storedProcedure,
                    param,
                    commandType: CommandType.StoredProcedure);

                return data ?? result;
            }
            catch (SqlException ex)
            {
                result.Message = ex.Message;
                result.Details = string.Empty;
                throw;
            }
            catch (Exception)
            {
                result.Message = CommonRepositoryMessages.ExceptionMessage;
                throw;
            }
        }

  
        public async Task<ResultModel>  UpdateCancellation(EmailOtpCancellationEntity entity, string storedProcedure)
        {
            ResultModel result = new ResultModel();

            try
            {
                Dapper.DefaultTypeMap.MatchNamesWithUnderscores = true;
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@ID", entity.ID);
 
                dynamicParameters.Add("@OperationType", 3);
                var data = await _dbConnection.QueryAsync(storedProcedure, dynamicParameters, commandType: CommandType.StoredProcedure);
                result.Message = data.FirstOrDefault().Message;
                result.Details = data.FirstOrDefault().Details;

            }
            catch (SqlException sqlException)
            {
                logger.LogError(sqlException, sqlException.Message);
                result.ErrorMessage = sqlException.Message;
                result.Status = (int)ResponseStatusCode.InternaServerError;
                result.Message = CommonRepositoryMessages.CannotFindAllMessage;
                result.Details = CommonRepositoryMessages.CannotFindAllDetails;

            }
            catch (Exception ex)
            {
                result.Status = (int)ResponseStatusCode.InternaServerError;
                result.Message = CommonRepositoryMessages.ExceptionMessage;
                result.ErrorMessage = ex.Message;

            }
            finally
            {
            }

            return result;
        }
    }

}
 