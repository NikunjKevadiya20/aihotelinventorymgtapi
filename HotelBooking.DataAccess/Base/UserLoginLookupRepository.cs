using Dapper;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using HotelBooking.Entity.Common;
using HotelBooking.Entity.Common.Entities;
using HotelBooking.Entity.Common.Enums;
using HotelBooking.Entity.Common.Helpers;
using HotelBooking.Entity.Entities;
using System.Data;
using System.Data.SqlClient;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace HotelBooking.DataAccess.Base
{
    public class UserLoginLookupRepository : IUserLoginLookupRepositoryInterface
    {
        #region Global Variables
        private readonly IDbConnection _dbConnection;
        private readonly ILogger<UserLoginLookupRepository> logger;
        #endregion

        public UserLoginLookupRepository(ILogger<UserLoginLookupRepository> _logger, IDbConnection dbConnection)
        {
            logger = _logger;
            _dbConnection = dbConnection;
        }


        #region Login
        public async Task<LoginResponseEntity> UserLogin(LoginRequestEntity entity, string storedProcedure)
        {
            LoginResponseEntity result = new LoginResponseEntity();

            try
            {
                Dapper.DefaultTypeMap.MatchNamesWithUnderscores = true;
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@UserName", entity.UserName);
                dynamicParameters.Add("@Password", HashPassword.EncryptPlainTextToCipherText(entity.Password));
                dynamicParameters.Add("@OperationType", 1);
                var Userdata = await _dbConnection.QueryMultipleAsync(storedProcedure, dynamicParameters, commandType: System.Data.CommandType.StoredProcedure);

                LoginResponseEntity data = await Userdata.ReadFirstOrDefaultAsync<LoginResponseEntity>();

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
    }

}
