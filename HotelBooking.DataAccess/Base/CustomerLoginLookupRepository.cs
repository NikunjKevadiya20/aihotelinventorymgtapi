using HotelBooking.Entity.Common;
using HotelBooking.Entity.Common.Entities;
using HotelBooking.Entity.Common.Enums;
using HotelBooking.Entity.Entities;
using Dapper;
using System.Net.Http;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Clients.ActiveDirectory;

namespace HotelBooking.DataAccess.Base
{
    public class CustomerLoginLookupRepository : ICustomerLoginLookupRepositoryInterface
    {
        #region Global Variables
        private readonly IDbConnection _dbConnection;
        private readonly IHttpClientFactory _httpClientFactory;
        #endregion

        private readonly ILogger<CustomerLoginLookupRepository> logger;

        public CustomerLoginLookupRepository(IHttpClientFactory httpClientFactory, ILogger<CustomerLoginLookupRepository> _logger, IDbConnection dbConnection)
        {
            _httpClientFactory = httpClientFactory;
            logger = _logger;
            _dbConnection = dbConnection;
        }
        #region UserLogin
        public async Task<LogInResponseEntity> UserLogin(LoginRequestsEntity entity, string storedProcedure)
        {
            LogInResponseEntity result = new LogInResponseEntity();

            try
            {
                Dapper.DefaultTypeMap.MatchNamesWithUnderscores = true;
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@mobile_no", entity.mobile_no);
                dynamicParameters.Add("@otp", entity.otp);
                dynamicParameters.Add("@browser_version", entity.browser_version);
                dynamicParameters.Add("@device_id", entity.device_id);
                dynamicParameters.Add("@device_type", entity.device_type);
                dynamicParameters.Add("@session_id", entity.session_id);
                dynamicParameters.Add("@OperationType", 2);
                var data = await _dbConnection.QueryFirstOrDefaultAsync<LogInResponseEntity>(storedProcedure, dynamicParameters, commandType: System.Data.CommandType.StoredProcedure);

                if (data.Message == "success")
                {

                    if (data.is_first_login == "True")
                    {
                        HotelBooking.Entity.Common.Methods.SendEmail sendEmail = new HotelBooking.Entity.Common.Methods.SendEmail();
                        string EmailSubject = "Welcome to Sky Runer – Your Journey Begins Here!";
                        string body = $@"<p>Dear {data.first_name} {data.last_name},</p>
                                        <p>Welcome to Sky Runer! Thank you for registering with us.</p>
                                        <p>Now you can easily search, compare, and book flights at the best prices—all in just a few clicks.</p>
                                        <p>We’re excited to be part of your travel journey and look forward to helping you reach new destinations.</p>
                                        <p>Safe travels,<br>Team Sky Runer</p>";

                        //sendEmail.MailSendSMTP(data.email_id, "", EmailSubject, body, "");
                        //----------------------------------------------------------------------------
                        // WhatsApp Integration For Ticket
                        if (!string.IsNullOrEmpty(data.mobile_no))
                        {
                            var whatsappRequest = new Dictionary<string, string>
                                {
                                    { "apiToken", "12460|qFlEc2L2xUp9LyOxAgahx765MUB7ggI0rGEn3OHQe7049a6d" },
                                    { "phone_number_id", "790125650843323" },
                                    { "template_id", "246329" },
                                    { "templateVariable-customername-1", (data.first_name + ' ' + data.last_name) },
                                    { "phone_number", "+91" + (data.mobile_no ?? "") }
                                };

                            var client = _httpClientFactory.GetHttpClient();
                            // Send WhatsApp message
                            var whatsappApiUrl = "https://chatbotmarketing.in/api/v1/whatsapp/send/template";
                            var whatsappJsonRequest = JsonConvert.SerializeObject(whatsappRequest);
                            var whatsappHttpContent = new StringContent(whatsappJsonRequest, Encoding.UTF8, "application/json");
                            var whatsappResponse = await client.PostAsync(whatsappApiUrl, whatsappHttpContent);
                            var whatsappResponseContent = await whatsappResponse.Content.ReadAsStringAsync();

                            object whatsappContentObject;
                            try
                            {
                                whatsappContentObject = JsonConvert.DeserializeObject(whatsappResponseContent);
                            }
                            catch (JsonException ex)
                            {
                                whatsappContentObject = whatsappResponseContent;
                            }

                            var whatsappJsonResponse = JsonConvert.SerializeObject(
                                new
                                {
                                    StatusCode = whatsappResponse.StatusCode,
                                    Content = whatsappContentObject
                                },
                                Formatting.Indented
                            );

                        }
                    }
                }
                return data;
            }
            catch (SqlException sqlException)
            {
                result.Message = sqlException.Message;
                result.Details = String.Empty;
                throw;
            }
            catch (Exception ex)
            {
                result.Message = CommonRepositoryMessages.ExceptionMessage;
                throw;
            }
            finally
            {
            }


        }
        #region UserSignup
        public async Task<SignUPResponseEntity> UserSignup(LoginRequestsEntity entity, string storedProcedure)
        {
            SignUPResponseEntity result = new SignUPResponseEntity();

            try
            {
                Dapper.DefaultTypeMap.MatchNamesWithUnderscores = true;
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@first_name", entity.first_name);
                dynamicParameters.Add("@last_name", entity.last_name);
                dynamicParameters.Add("@mobile_no", entity.mobile_no);
                dynamicParameters.Add("@email_id", entity.email_id);
                dynamicParameters.Add("@browser_version", entity.browser_version);
                dynamicParameters.Add("@device_id", entity.device_id);
                dynamicParameters.Add("@device_type", entity.device_type);
                dynamicParameters.Add("@session_id", entity.session_id);
                dynamicParameters.Add("@OperationType", 7);
                var data = await _dbConnection.QueryFirstOrDefaultAsync<SignUPResponseEntity>(storedProcedure, dynamicParameters, commandType: System.Data.CommandType.StoredProcedure);

                if (data.Message == "success")
                {

                    HotelBooking.Entity.Common.Methods.SendSMS sendSMS = new HotelBooking.Entity.Common.Methods.SendSMS();

                    //sendSMS.SendOTP(entity.mobile_no, "Your OTP for login to Big Smile Holidays is " + data.otp + ". Do not share it with anyone. It is valid for 15 minutes.");
                    
                    //*---------------------------------------------------------------------------
                    //EmailVerificationEntity emailEntity = new EmailVerificationEntity
                    //{
                    //    user_guid = data.user_guid
                    //};

                    //string emailStoredProcedure = "sp_ManageLoginCustomer"; // Replace with actual stored procedure name
                    //var emailResult = await EmailVerification(emailEntity, emailStoredProcedure);
                }
                //data.otp = null; // Hiding OTP in response

                return data;
            }
            catch (SqlException sqlException)
            {
                result.Message = sqlException.Message;
                result.Details = String.Empty;
                throw;
            }
            catch (Exception ex)
            {
                result.Message = CommonRepositoryMessages.ExceptionMessage;
                throw;
            }
            finally
            {
            }


        }
        #endregion
        private string GenerateJwtToken(string userId, string userGUID, Boolean IsUser)
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

                Expires = DateTime.UtcNow.AddDays(30),    //Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        public async Task UpdateRefreshToken(Guid? userGUID, string refreshToken, string storedProcedure)
        {
            try
            {
                Dapper.DefaultTypeMap.MatchNamesWithUnderscores = true;
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@UserGUID", userGUID);
                dynamicParameters.Add("@Token", refreshToken);
                dynamicParameters.Add("@OperationType", 8);
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


        private string GenerateRefereshJwtToken(string userId, string userGUID, Boolean IsUser)
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

                Expires = DateTime.UtcNow.AddDays(3),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }


        #endregion

        #region Otp Generate
        public async Task<OtpResponseEntity> OtpGenerate(LoginRequestsEntity entity, string storedProcedure)
        {
            OtpResponseEntity result = new OtpResponseEntity();

            try
            {
                Dapper.DefaultTypeMap.MatchNamesWithUnderscores = true;
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@mobile_no", entity.mobile_no);
                dynamicParameters.Add("@OperationType", 1);
                var data = await _dbConnection.QueryFirstOrDefaultAsync<OtpResponseEntity>(storedProcedure, dynamicParameters, commandType: System.Data.CommandType.StoredProcedure);

                if (data.Message == "success")
                {
                    HotelBooking.Entity.Common.Methods.SendSMS sendSMS = new HotelBooking.Entity.Common.Methods.SendSMS();

                    sendSMS.SendOTP(entity.mobile_no, "Your OTP for login to Big Smile Holidays is " + data.otp + ". Do not share it with anyone. It is valid for 15 minutes.");
                    data.otp = null; // Hiding OTP in response

                }
                else
                {
                    // result.List = data.AsList();
                    result.Message = Convert.ToString(data.Message);
                    result.Details = Convert.ToString(data.Details);
                }
                return data;

            }
            catch (SqlException sqlException)
            {
                result.Message = sqlException.Message;
                result.Details = String.Empty;
                throw;
            }
            catch (Exception ex)
            {
                result.Message = CommonRepositoryMessages.ExceptionMessage;
                throw;
            }
            finally
            {
            }

        }
        #endregion
        #region Otp Generate
        public async Task<OtpResponseEntity> VerifyOtpGenerate(LoginRequestsEntity entity, string storedProcedure)
        {
            OtpResponseEntity result = new OtpResponseEntity();

            try
            {
                Dapper.DefaultTypeMap.MatchNamesWithUnderscores = true;
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@mobile_no", entity.mobile_no);
                dynamicParameters.Add("@OperationType", 8);
                var data = await _dbConnection.QueryFirstOrDefaultAsync<OtpResponseEntity>(storedProcedure, dynamicParameters, commandType: System.Data.CommandType.StoredProcedure);

                if (data.Message == "success")
                {
                    HotelBooking.Entity.Common.Methods.SendSMS sendSMS = new HotelBooking.Entity.Common.Methods.SendSMS();

                    sendSMS.SendOTP(entity.mobile_no, "Use " + data.otp + " as your one-time password (OTP) to verify your mobile number on Bigsmile Holidays. Never share this code with anyone.");

                }
                else
                {
                    // result.List = data.AsList();
                    result.Message = Convert.ToString(data.Message);
                    result.Details = Convert.ToString(data.Details);
                }
                data.otp = null; // Hiding OTP in response

                return data;

            }
            catch (SqlException sqlException)
            {
                result.Message = sqlException.Message;
                result.Details = String.Empty;
                throw;
            }
            catch (Exception ex)
            {
                result.Message = CommonRepositoryMessages.ExceptionMessage;
                throw;
            }
            finally
            {
            }

        }

        #endregion

        #region Email Verification
        public async Task<EmailVerificationViewEntity> EmailVerification(EmailVerificationEntity entity, string storedProcedure)
        {
            EmailVerificationViewEntity result = new EmailVerificationViewEntity();

            try
            {
                Dapper.DefaultTypeMap.MatchNamesWithUnderscores = true;
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@user_guid", entity.user_guid);
                dynamicParameters.Add("@OperationType", 3);
                var data = await _dbConnection.QueryFirstOrDefaultAsync<EmailVerificationViewEntity>(storedProcedure, dynamicParameters, commandType: System.Data.CommandType.StoredProcedure);

                if (data.Message == "success")
                {


                    HotelBooking.Entity.Common.Methods.SendEmail sendEmail = new HotelBooking.Entity.Common.Methods.SendEmail();
                    string EmailSubject = "Verify Your Email Address - Big Smile Holidays";

                    string body = "<!DOCTYPE html><html><head><style>";
                    body += "body { font-family: 'Arial', sans-serif; background-color: #f4f4f4; color: #333; margin: 0; padding: 0; }";
                    body += ".container { max-width: 600px; margin: 20px auto; background-color: #ffffff; border-radius: 8px; box-shadow: 0 2px 4px rgba(0, 0, 0, 0.1); padding: 30px; }";
                    body += ".header { text-align: center; border-bottom: 1px solid #e0e0e0; padding-bottom: 20px; margin-bottom: 20px; }";
                    body += ".header img { max-width: 150px; }";
                    body += ".content { line-height: 1.6; }";
                    body += ".button { display: inline-block; background-color: #E9F5BE; color: #ffffff; padding: 12px 24px; text-decoration: none; border-radius: 4px; font-weight: bold; text-align: center; margin: 20px 0; }";
                    body += ".button:hover { background-color: #003087; }";
                    body += ".footer { text-align: center; color: #777; font-size: 12px; margin-top: 20px; border-top: 1px solid #e0e0e0; padding-top: 20px; }";
                    body += "a { color: #004aad; text-decoration: none; }";
                    body += "a:hover { text-decoration: underline; }";
                    body += "</style></head><body>";
                    body += "<div class='container'>";
                    body += "<div class='header'>";
                    body += "<img src='https://bsdocs.novotrips.com/Uploads/Logo/logo.png' alt='Big Smile Holidays Logo'>";
                    body += "</div>";
                    body += "<div class='content'>";
                    body += "<p>Dear " + Convert.ToString(data.full_name) + ",</p>";
                    body += "<p>Welcome to Big Smile Holidays Pvt. Ltd. We’re thrilled to have you join us for your travel adventures. To complete your account setup and verify your email address, please click the button below:</p>";
                    body += "<a href='" + Convert.ToString(data.email_verification_link) + "' class='button'>Verify Your Email Address</a>";
                    body += "<p>If the button is not clickable, please copy and paste the following URL into your web browser:</p>";
                    body += "<p><a href='" + Convert.ToString(data.email_verification_link) + "'>" + Convert.ToString(data.email_verification_link) + "</a></p>";
                    body += "<p>For security purposes, this verification link will expire in 1 hour. We recommend verifying your email promptly.</p>";
                    body += "<p>If you did not create an account with Big Smile Holidays Pvt. Ltd., please disregard this email.</p>";
                    body += "<p>Thank you for choosing us for your travel needs. We look forward to helping you plan unforgettable journeys.</p>";
                    body += "<p>Warm regards,<br>The Big Smile Holidays Team</p>";
                    body += "</div>";
                    body += "<div class='footer'>";
                    body += "<p>© 2025 Big Smile Holidays Pvt. Ltd. All rights reserved.</p>";
                    body += "<p>2, Shreeji Complex, Ghodasar Highway, Ghodasar, Ahmedabad - 380050, Gujarat, India | <a href='mailto:bigsmileholiday@gmail.com'>bigsmileholiday@gmail.com</a></p>";
                    body += "</div>";
                    body += "</div></body></html>";




                    sendEmail.MailSendSMTP(data.email_id, "", EmailSubject, body, "");




                    //HotelBooking.Entity.Common.Methods.SendEmail sendEmail = new HotelBooking.Entity.Common.Methods.SendEmail();

                    //string EmailSubject= "Verify Your Email Now";

                    //sendEmail.MailSendSMTP(data.email_id, "",EmailSubject, data.email_verification_link, "");


                }

                return data;


            }
            catch (SqlException sqlException)
            {
                result.Message = sqlException.Message;
                result.Details = String.Empty;
                throw;
            }
            catch (Exception ex)
            {
                result.Message = CommonRepositoryMessages.ExceptionMessage;
                throw;
            }
            finally
            {
            }

        }
        #endregion
        #region Mobile Verification
        public async Task<ResultModel> MobileVerification(EmailVerificationEntity entity, string storedProcedure)
        {
            ResultModel result = new ResultModel();

            try
            {
                Dapper.DefaultTypeMap.MatchNamesWithUnderscores = true;
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@user_guid", entity.user_guid);
                dynamicParameters.Add("@otp", entity.otp);
                dynamicParameters.Add("@OperationType", 9);
                var data = await _dbConnection.QueryAsync(storedProcedure, dynamicParameters, commandType: System.Data.CommandType.StoredProcedure);
                result.Message = data.FirstOrDefault().Message;
                result.Details = data.FirstOrDefault().Details;
                return result;
            }
            catch (SqlException sqlException)
            {
                // Use ResultModel for error reporting
                var errorResult = new ResultModel
                {
                    Message = sqlException.Message,
                    Details = string.Empty,
                    Status = (int)ResponseStatusCode.InternaServerError,
                    ErrorMessage = sqlException.Message
                };
                return errorResult;
            }
            catch (Exception ex)
            {
                var errorResult = new ResultModel
                {
                    Message = CommonRepositoryMessages.ExceptionMessage,
                    Details = string.Empty,
                    Status = (int)ResponseStatusCode.InternaServerError,
                    ErrorMessage = ex.Message
                };
                return errorResult;
            }
            finally
            {
            }
        }
        #endregion
        #region FindBy ID FlightPlaces
        public async Task<EmailOtpApproveViewEntity> EmailOtpApprove(EmailVerificationEntity entity, string storedProcedure)
        {
            EmailOtpApproveViewEntity result = new EmailOtpApproveViewEntity();

            try
            {
                Dapper.DefaultTypeMap.MatchNamesWithUnderscores = true;
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@user_guid", entity.user_guid);
                dynamicParameters.Add("@email_code", entity.email_code);
                dynamicParameters.Add("@OperationType", 4);
                var data = await _dbConnection.QuerySingleOrDefaultAsync<EmailOtpApproveViewEntity>(storedProcedure, dynamicParameters, commandType: CommandType.StoredProcedure);
                return data;

            }
            catch (SqlException sqlException)
            {
                logger.LogError(sqlException, sqlException.Message);
                result.ErrorMessage = sqlException.Message;
                result.Status = (int)ResponseStatusCode.InternaServerError;
                result.Message = CommonRepositoryMessages.CannotFindAllMessage;
                result.Details = CommonRepositoryMessages.CannotFindAllDetails;
                throw;
            }
            catch (Exception ex)
            {
                result.Status = (int)ResponseStatusCode.InternaServerError;
                result.Message = CommonRepositoryMessages.ExceptionMessage;
                result.ErrorMessage = ex.Message;
                throw;
            }
            finally
            {

            }


        }
        #endregion

        #region Update Customer
        public async Task<ResultModel> UpdateCustomer(CustomerEntity entity, string storedProcedure)
        {
            ResultModel result = new ResultModel();
            try
            {
                Dapper.DefaultTypeMap.MatchNamesWithUnderscores = true;
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@ID", entity.ID);
                parameters.Add("@first_name", entity.first_name);
                parameters.Add("@email_id", entity.email_id);
                parameters.Add("@last_name", entity.last_name);
                parameters.Add("@OperationType", 11);

                var data = await _dbConnection.QueryAsync(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
                result.Message = data.FirstOrDefault()?.Message;
                result.Details = data.FirstOrDefault()?.Details;
            }
            catch (SqlException ex)
            {
                logger.LogError(ex, ex.Message);
                result.Status = (int)ResponseStatusCode.InternaServerError;
                result.ErrorMessage = ex.Message;
                result.Message = CommonRepositoryMessages.CannotFindAllMessage;
                result.Details = CommonRepositoryMessages.CannotFindAllDetails;
            }
            catch (Exception ex)
            {
                result.Status = (int)ResponseStatusCode.InternaServerError;
                result.ErrorMessage = ex.Message;
                result.Message = CommonRepositoryMessages.ExceptionMessage;
            }
            return result;
        }
        #endregion

        #region Find By ID Customer
        public async Task<CustomerViewEntity> FindByIDCustomer(ColorIDEntity entity, string storedProcedure)
        {
            CustomerViewEntity result = new CustomerViewEntity();
            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@ID", entity.ID);
                parameters.Add("@OperationType", 12);

                var data = await _dbConnection.QuerySingleOrDefaultAsync<CustomerViewEntity>(
                    storedProcedure, parameters, commandType: CommandType.StoredProcedure);
                return data;
            }
            catch (SqlException ex)
            {
                logger.LogError(ex, ex.Message);
                result.Status = (int)ResponseStatusCode.InternaServerError;
                result.ErrorMessage = ex.Message;
                throw;
            }
            catch (Exception ex)
            {
                result.Status = (int)ResponseStatusCode.InternaServerError;
                result.ErrorMessage = ex.Message;
                throw;
            }
        }
        #endregion

        #region Find All Customer
        public async Task<CustomerListFinalResponse> FindAllCustomer(CustomerListRequestEntity entity, string storedProcedure)
        {
            CustomerListFinalResponse result = new CustomerListFinalResponse();

            try
            {
                DynamicParameters parameters = new DynamicParameters();

                parameters.Add("@ID", entity.ID);
                parameters.Add("@CustomerName", entity.CustomerName);
                parameters.Add("@MobileNo", entity.MobileNo);
                parameters.Add("@EmailID", entity.EmailID);
                parameters.Add("@FilterType", entity.FilterType);
                parameters.Add("@limit", entity.Limit);
                parameters.Add("@skip", entity.Skip);
                parameters.Add("@OperationType", 1);

                using var multi = await _dbConnection.QueryMultipleAsync(
                    storedProcedure,
                    parameters,
                    commandType: CommandType.StoredProcedure);

                result.CustomerList = multi.Read<CustomerListResponse>().ToList();

                result.Summary = multi.Read<CustomerSummaryResponse>().FirstOrDefault()
                                 ?? new CustomerSummaryResponse();

                result.Status = (int)ResponseStatusCode.Success;
                result.Message = result.CustomerList[0].Message;
                result.Details = result.CustomerList[0].Details;

                return result;
            }
            catch (SqlException ex)
            {
                logger.LogError(ex, ex.Message);
                result.Status = (int)ResponseStatusCode.InternaServerError;
                result.ErrorMessage = ex.Message;
                throw;
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.Message);
                result.Status = (int)ResponseStatusCode.InternaServerError;
                result.ErrorMessage = ex.Message;
                throw;
            }
        }
        #endregion

        #region Customer Details By ID
        public async Task<CustomerDetailsFinalResponse> CustomerDetailsByID(ColorIDEntity entity, string storedProcedure)
        {
            CustomerDetailsFinalResponse result = new CustomerDetailsFinalResponse();

            try
            {
                DynamicParameters parameters = new DynamicParameters();

                parameters.Add("@ID", entity.ID);
                parameters.Add("@OperationType", 2);

                using var multi = await _dbConnection.QueryMultipleAsync(
                    storedProcedure,
                    parameters,
                    commandType: CommandType.StoredProcedure);

                // First Resultset = Customer Details
                result.CustomerDetails =
                    multi.Read<CustomerDetailsResponse>().FirstOrDefault()
                    ?? new CustomerDetailsResponse();

                // Second Resultset = Address List
                result.AddressList =
                    multi.Read<CustomerAddressResponse>().ToList();

                result.Status = (int)ResponseStatusCode.Success;

                result.Message = result.CustomerDetails.Message;
                result.Details = result.CustomerDetails.Details;

                return result;
            }
            catch (SqlException ex)
            {
                logger.LogError(ex, ex.Message);
                result.Status = (int)ResponseStatusCode.InternaServerError;
                result.ErrorMessage = ex.Message;
                throw;
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.Message);
                result.Status = (int)ResponseStatusCode.InternaServerError;
                result.ErrorMessage = ex.Message;
                throw;
            }
        }
        #endregion


        #region FindAllPayment
        public async Task<OrderPaymentFinalResponse> FindAllPayment(OrderPaymentRequestEntity entity, string storedProcedure)
        {
            OrderPaymentFinalResponse result = new OrderPaymentFinalResponse();

            try
            {
                DynamicParameters parameters = new DynamicParameters();

                parameters.Add("@SearchText", entity.SearchText);
                parameters.Add("@PaymentStatus", entity.PaymentStatus);
                parameters.Add("@Gateway", entity.Gateway);
                parameters.Add("@Limit", entity.Limit);
                parameters.Add("@Skip", entity.Skip);
                parameters.Add("@OperationType", 1);

                using var multi = await _dbConnection.QueryMultipleAsync(
                    storedProcedure,
                    parameters,
                    commandType: CommandType.StoredProcedure);

                // First Resultset = Payment List
                result.PaymentList =
                    multi.Read<OrderPaymentListResponse>().ToList();

                // Second Resultset = Summary
                result.Summary =
                    multi.Read<OrderPaymentSummaryResponse>().FirstOrDefault()
                    ?? new OrderPaymentSummaryResponse();

                result.Status = (int)ResponseStatusCode.Success;

                if (result.PaymentList.Count > 0)
                {
                    result.Message = result.PaymentList[0].Message;
                    result.Details = result.PaymentList[0].Details;
                }
                else
                {
                    result.Message = "success";
                    result.Details = "Payment list fetched successfully";
                }

                return result;
            }
            catch (SqlException ex)
            {
                logger.LogError(ex, ex.Message);
                result.Status = (int)ResponseStatusCode.InternaServerError;
                result.ErrorMessage = ex.Message;
                throw;
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.Message);
                result.Status = (int)ResponseStatusCode.InternaServerError;
                result.ErrorMessage = ex.Message;
                throw;
            }
        }
        #endregion

        #region PaymentDetailsByID
        public async Task<OrderPaymentDetailsFinalResponse> PaymentDetailsByID(
            OrderPaymentDetailsRequestEntity entity,
            string storedProcedure)
        {
            OrderPaymentDetailsFinalResponse result = new OrderPaymentDetailsFinalResponse();

            try
            {
                DynamicParameters parameters = new DynamicParameters();

                parameters.Add("@ID", entity.ID);
                parameters.Add("@OperationType", 2);

                using var multi = await _dbConnection.QueryMultipleAsync(
                    storedProcedure,
                    parameters,
                    commandType: CommandType.StoredProcedure);

                // First Resultset = Payment Details
                result.PaymentDetails =
                    multi.Read<OrderPaymentDetailsResponse>().FirstOrDefault()
                    ?? new OrderPaymentDetailsResponse();

                // Second Resultset = Item List
                result.ItemList =
                    multi.Read<OrderPaymentItemResponse>().ToList();

                result.Status = (int)ResponseStatusCode.Success;

                result.Message = result.PaymentDetails.Message;
                result.Details = result.PaymentDetails.Details;

                return result;
            }
            catch (SqlException ex)
            {
                logger.LogError(ex, ex.Message);
                result.Status = (int)ResponseStatusCode.InternaServerError;
                result.ErrorMessage = ex.Message;
                throw;
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.Message);
                result.Status = (int)ResponseStatusCode.InternaServerError;
                result.ErrorMessage = ex.Message;
                throw;
            }
        }
        #endregion
    }
}
