using Dapper;
using Microsoft.Extensions.Logging;
using Org.BouncyCastle.Asn1.Ocsp;
using HotelBooking.Entity.Common;
using HotelBooking.Entity.Common.Entities;
using HotelBooking.Entity.Common.Enums;
using HotelBooking.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBooking.DataAccess.Base
{
    public class InquiryLookupRepository : IInquiryLookupRepositoryInterface
    {
        #region Global Variables
        private readonly IDbConnection _dbConnection;
        #endregion


        private readonly ILogger<InquiryLookupRepository> logger;

        public InquiryLookupRepository(ILogger<InquiryLookupRepository> _logger, IDbConnection dbConnection)
        {
            logger = _logger;
            _dbConnection = dbConnection;
        }

        
        #region Insert Inquiry
        public async Task<ResultModel> InsertInquiry(InquiryEntity entity, string storedProcedure)
        {
            ResultModel result = new ResultModel();

            try
            {
                Dapper.DefaultTypeMap.MatchNamesWithUnderscores = true;
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@FirstName", entity.FirstName);
                dynamicParameters.Add("@LastName", entity.LastName);
                dynamicParameters.Add("@Address", entity.Address);
                dynamicParameters.Add("@CompanyName", entity.CompanyName);
                dynamicParameters.Add("@AreYou", entity.AreYou);
                dynamicParameters.Add("@AreYouOther", entity.AreYouOther);
                dynamicParameters.Add("@LookingFor", entity.LookingFor);
                dynamicParameters.Add("@LookingForOther", entity.LookingForOther);
                dynamicParameters.Add("@Remarks", entity.Remarks);
                dynamicParameters.Add("@Email",entity.Email);
                dynamicParameters.Add("@MobileNo", entity.MobileNo);
                dynamicParameters.Add("@CityID", entity.CityID);
                dynamicParameters.Add("@Adults", entity.Adults);
                dynamicParameters.Add("@Child", entity.Child);
                dynamicParameters.Add("@Nights", entity.Nights);
                dynamicParameters.Add("@CheckInDate", entity.CheckInDate);
                dynamicParameters.Add("@CheckOut", entity.CheckOut);
                dynamicParameters.Add("@WebSiteURL", entity.WebSiteURL);
                dynamicParameters.Add("@InquiryType", entity.InquiryType);
                dynamicParameters.Add("@PackageName", entity.PackageName);
                dynamicParameters.Add("@HotelID", entity.HotelID);
                dynamicParameters.Add("@OperationType", CommonRepositoryConstants.Insert);    
                var data = await _dbConnection.QueryAsync(storedProcedure, dynamicParameters, commandType: CommandType.StoredProcedure);
                var spResult = data.FirstOrDefault();

                result.Message = spResult?.Message;
                result.Details = spResult?.Details;

                /* ================= EMAIL FUNCTIONALITY ================= */

                SendEmail sendEmail = new SendEmail();

                string companyName = "HotelBooking";
                string firstName = entity.FirstName;
                string lastName = entity.LastName;
                string InquiryType = entity.InquiryType;
                string PackageName = entity.PackageName;
                string email = entity.Email;
                string mobile = entity.MobileNo;
                int? cityID = entity.CityID;
                int? adults = entity.Adults;
                int? child = entity.Child;
                int? nights = entity.Nights;
                DateTime? checkInDate = entity.CheckInDate;
                DateTime? CheckOut = entity.CheckOut;
              
                string remarks = entity.Remarks;
                string inquiryDateTime = DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss");
                string HotelName = spResult?.HotelName;
                /* ================= SUBJECT COMMON TEXT ================= */

                string subjectDetails = "";

                if (!string.IsNullOrWhiteSpace(PackageName) && !string.IsNullOrWhiteSpace(HotelName))
                {
                    subjectDetails = $"{PackageName} | {HotelName}";
                }
                else if (!string.IsNullOrWhiteSpace(PackageName))
                {
                    subjectDetails = PackageName;
                }
                else if (!string.IsNullOrWhiteSpace(HotelName))
                {
                    subjectDetails = HotelName;
                }
                /* ================= 1️ EMAIL TO VISITOR ================= */
                //string visitorSubject = $"Thank You for Your Inquiry – {companyName}";
                string visitorSubject = string.IsNullOrWhiteSpace(subjectDetails)
                           ? $"Thank You for Your Inquiry – {companyName}"
                           : $"Thank You for Your Inquiry – {subjectDetails} | {companyName}";

                string visitorBody = $@"
<!DOCTYPE html>
<html>
<head>
<meta charset='UTF-8'>
<meta name='viewport' content='width=device-width, initial-scale=1.0'>
<title>Thank You for Your Inquiry</title>
</head>
<body style='margin:0; padding:0; background-color:#f8f9fa; font-family:Arial, Helvetica, sans-serif;'>
<table width='100%' cellpadding='0' cellspacing='0' bgcolor='#f8f9fa' style='padding:30px 0;'>
<tr>
<td align='center'>
<!-- Main Container -->
<table width='650' cellpadding='0' cellspacing='0' bgcolor='#ffffff' style='background-color:#ffffff; border-radius:8px; overflow:hidden; box-shadow:0 4px 15px rgba(0,0,0,0.08);'>
    
    <!-- Top Orange Accent -->
    <tr>
        <td height='6' bgcolor='#FF6B00'></td>
    </tr>

    <!-- Header -->
    <tr>
        <td bgcolor='#FF8C00' style='background: linear-gradient(135deg, #FF6B00, #FF8C00); padding:35px 20px; text-align:center;'>
            <h2 style='margin:0; font-size:26px; font-weight:bold; color:#ffffff;'>
                {companyName}
            </h2>
            <p style='margin:10px 0 0 0; font-size:16px; color:#fff; opacity:0.95;'>
                Thank You for Your Inquiry
            </p>
        </td>
    </tr>

    <!-- Body -->
    <tr>
        <td style='padding:40px 35px;'>
            <p style='font-size:16px; color:#333; margin:0 0 18px;'>
                Dear <strong>{firstName}</strong>,
            </p>
            <p style='font-size:15px; color:#555; line-height:1.65; margin:0 0 30px;'>
                Thank you for contacting <strong>{companyName}</strong>.<br>
                We have received your inquiry successfully.
            </p>

            <!-- Details Box -->
            <table width='100%' cellpadding='10' cellspacing='0' 
                   style='border:1px solid #ffe0cc; background-color:#fffaf0; border-radius:6px;'>
                <tr>
                   <td colspan='2' style='font-size:17px; font-weight:bold; color:#FF6B00; padding:16px 12px; border-bottom:1px solid #ffe0cc;'>
                        📌 Your Submitted Details
                    </td>
                </tr>
                
                {(string.IsNullOrWhiteSpace(firstName) && string.IsNullOrWhiteSpace(lastName) ? "" : $@"
                <tr>
                    <td width='40%' style='font-weight:bold; color:#444; padding:10px 12px;'>Name:</td>
                    <td style='padding:10px 12px; color:#333;'>{firstName} {lastName}</td>
                </tr>")}

                {(string.IsNullOrWhiteSpace(email) ? "" : $@"
                <tr>
                    <td style='font-weight:bold; color:#444; padding:10px 12px;'>Email:</td>
                    <td style='padding:10px 12px; color:#333;'>{email}</td>
                </tr>")}

                {(string.IsNullOrWhiteSpace(mobile) ? "" : $@"
                <tr>
                    <td style='font-weight:bold; color:#444; padding:10px 12px;'>Mobile No:</td>
                    <td style='padding:10px 12px; color:#333;'>{mobile}</td>
                </tr>")}

                {(string.IsNullOrWhiteSpace(cityID?.ToString()) ? "" : $@"
                <tr>
                    <td style='font-weight:bold; color:#444; padding:10px 12px;'>City ID:</td>
                    <td style='padding:10px 12px; color:#333;'>{cityID}</td>
                </tr>")}

                {(string.IsNullOrWhiteSpace(adults?.ToString()) ? "" : $@"
                <tr>
                    <td style='font-weight:bold; color:#444; padding:10px 12px;'>Adults:</td>
                    <td style='padding:10px 12px; color:#333;'>{adults}</td>
                </tr>")}

                {(string.IsNullOrWhiteSpace(child?.ToString()) ? "" : $@"
                <tr>
                    <td style='font-weight:bold; color:#444; padding:10px 12px;'>Child:</td>
                    <td style='padding:10px 12px; color:#333;'>{child}</td>
                </tr>")}

                {(string.IsNullOrWhiteSpace(nights?.ToString()) ? "" : $@"
                <tr>
                    <td style='font-weight:bold; color:#444; padding:10px 12px;'>Nights:</td>
                    <td style='padding:10px 12px; color:#333;'>{nights}</td>
                </tr>")}

                {(string.IsNullOrWhiteSpace(HotelName?.ToString()) ? "" : $@"
                <tr>
                    <td style='font-weight:bold; color:#444; padding:10px 12px;'>HotelName:</td>
                    <td style='padding:10px 12px; color:#333;'>{HotelName}</td>
                </tr>")}


                {(string.IsNullOrWhiteSpace(checkInDate?.ToString()) ? "" : $@"
                <tr>
                    <td style='font-weight:bold; color:#444; padding:10px 12px;'>Check-In Date:</td>
                    <td style='padding:10px 12px; color:#333;'>{checkInDate:dd-MM-yyyy}</td>
                </tr>")}

                {(string.IsNullOrWhiteSpace(CheckOut?.ToString()) ? "" : $@"
                <tr>
                    <td style='font-weight:bold; color:#444; padding:10px 12px;'>CheckOut:</td>
                    <td style='padding:10px 12px; color:#333;'>{CheckOut:dd-MM-yyyy}</td>
                </tr>")}


                {(string.IsNullOrWhiteSpace(remarks) ? "" : $@"
                <tr>
                    <td style='font-weight:bold; color:#444; padding:10px 12px;'>Message:</td>
                    <td style='padding:10px 12px; color:#333;'>{remarks}</td>
                </tr>")}

                {(string.IsNullOrWhiteSpace(inquiryDateTime) ? "" : $@"
                <tr>
                    <td style='font-weight:bold; color:#444; padding:10px 12px;'>Submitted On:</td>
                    <td style='padding:10px 12px; color:#333;'>{inquiryDateTime}</td>
                </tr>")}

            {(string.IsNullOrWhiteSpace(entity.WebSiteURL) ? "" : $@"
                <tr>
                    <td style='font-weight:bold; color:#444; padding:10px 12px;'>WebSiteURL:</td>
                    <td style='padding:10px 12px; color:#333;'>{entity.WebSiteURL}</td>
                </tr>")}

         {(string.IsNullOrWhiteSpace(entity.InquiryType) ? "" : $@"
                <tr>
                    <td style='font-weight:bold; color:#444; padding:10px 12px;'>InquiryType:</td>
                    <td style='padding:10px 12px; color:#333;'>{entity.InquiryType}</td>
                </tr>")}
            {(string.IsNullOrWhiteSpace(entity.PackageName) ? "" : $@"
                <tr>
                    <td style='font-weight:bold; color:#444; padding:10px 12px;'>PackageName:</td>
                    <td style='padding:10px 12px; color:#333;'>{entity.PackageName}</td>
                </tr>")}
            </table>

            <p style='margin-top:28px; font-size:15px; color:#555; line-height:1.6;'>
                Our team will get back to you shortly.
            </p>

            <p style='margin-top:32px; font-size:15px; color:#555;'>
                Regards,<br/>
                <strong>{companyName}</strong>
            </p>
        </td>
    </tr>

    <!-- Footer -->
    <tr>
        <td bgcolor='#f8f9fa' style='padding:22px; text-align:center; font-size:12.5px; color:#777; border-top:1px solid #eee;'>
            © {DateTime.Now.Year} {companyName}. All Rights Reserved.
        </td>
    </tr>
</table>
</td>
</tr>
</table>
</body>
</html>
";

                Task.Run(() =>
                {
                    try
                    {
                        sendEmail.MailSendSMTP(email, "", visitorSubject, visitorBody, "");
                    }
                    catch (Exception ex)
                    {
                        // Optional Log Error
                    }
                });

                /* ================= 2️ EMAIL TO ADMIN ================= */

                string adminEmail = spResult?.AdminInquiryEmail; // from SP

                if (!string.IsNullOrEmpty(adminEmail))
                {
                    //string adminSubject = $"New Inquiry Received – {firstName} {lastName}";
                    /* ================= 2️ EMAIL TO ADMIN ================= */

                    string adminSubject = string.IsNullOrWhiteSpace(subjectDetails)
                                ? $"New Inquiry Received – {firstName} {lastName}"
                                : $"New Inquiry Received – {subjectDetails} | {firstName} {lastName}";


                    string adminBody = $@"
<!DOCTYPE html>
<html>
<head>
<meta charset='UTF-8'>
<meta name='viewport' content='width=device-width, initial-scale=1.0'>
<title>New Inquiry Received</title>
</head>
<body style='margin:0; padding:0; background-color:#f8f9fa; font-family:Arial, Helvetica, sans-serif;'>
<table width='100%' cellpadding='0' cellspacing='0' bgcolor='#f8f9fa' style='padding:30px 0;'>
<tr>
<td align='center'>
<table width='650' cellpadding='0' cellspacing='0' bgcolor='#ffffff' style='background-color:#ffffff; border-radius:8px; overflow:hidden; box-shadow:0 4px 15px rgba(0,0,0,0.08);'>
    
    <!-- Top Orange Accent -->
    <tr>
        <td height='6' bgcolor='#FF6B00'></td>
    </tr>

    <!-- Header -->
    <tr>
        <td bgcolor='#FF8C00' style='background: linear-gradient(135deg, #FF6B00, #FF8C00); padding:35px 20px; text-align:center;'>
            <h2 style='margin:0; font-size:26px; font-weight:bold; color:#ffffff;'>
                {companyName}
            </h2>
            <p style='margin:10px 0 0 0; font-size:16px; color:#fff; opacity:0.95;'>
                New Website Inquiry
            </p>
        </td>
    </tr>

    <!-- Body -->
    <tr>
        <td style='padding:40px 35px;'>
            <p style='font-size:16px; color:#333; margin:0 0 18px;'>
                Dear Team,
            </p>
            <p style='font-size:15px; color:#555; line-height:1.65; margin:0 0 30px;'>
                A new inquiry has been received with the following details:
            </p>

            <!-- Details Box -->
            <table width='100%' cellpadding='10' cellspacing='0' 
                   style='border:1px solid #ffe0cc; background-color:#fffaf0; border-radius:6px;'>
                <tr>
                   <td colspan='2' style='font-size:17px; font-weight:bold; color:#FF6B00; padding:16px 12px; border-bottom:1px solid #ffe0cc;'>
                        📌 Inquiry Details
                    </td>
                </tr>
                
                              
                {(string.IsNullOrWhiteSpace(firstName) && string.IsNullOrWhiteSpace(lastName) ? "" : $@"
                <tr><td width='40%' style='font-weight:bold; color:#444; padding:10px 12px;'>Name:</td><td style='padding:10px 12px; color:#333;'>{firstName} {lastName}</td></tr>")}

                {(string.IsNullOrWhiteSpace(email) ? "" : $@"
                <tr><td style='font-weight:bold; color:#444; padding:10px 12px;'>Email:</td><td style='padding:10px 12px; color:#333;'>{email}</td></tr>")}

                {(string.IsNullOrWhiteSpace(mobile) ? "" : $@"
                <tr><td style='font-weight:bold; color:#444; padding:10px 12px;'>Mobile No:</td><td style='padding:10px 12px; color:#333;'>{mobile}</td></tr>")}

                {(string.IsNullOrWhiteSpace(cityID?.ToString()) ? "" : $@"
                <tr><td style='font-weight:bold; color:#444; padding:10px 12px;'>City ID:</td><td style='padding:10px 12px; color:#333;'>{cityID}</td></tr>")}

                {(string.IsNullOrWhiteSpace(adults?.ToString()) ? "" : $@"
                <tr><td style='font-weight:bold; color:#444; padding:10px 12px;'>Adults:</td><td style='padding:10px 12px; color:#333;'>{adults}</td></tr>")}

                {(string.IsNullOrWhiteSpace(child?.ToString()) ? "" : $@"
                <tr><td style='font-weight:bold; color:#444; padding:10px 12px;'>Child:</td><td style='padding:10px 12px; color:#333;'>{child}</td></tr>")}

                {(string.IsNullOrWhiteSpace(nights?.ToString()) ? "" : $@"
                <tr><td style='font-weight:bold; color:#444; padding:10px 12px;'>Nights:</td><td style='padding:10px 12px; color:#333;'>{nights}</td></tr>")}

               {(string.IsNullOrWhiteSpace(HotelName?.ToString()) ? "" : $@"
               <tr>
                   <td style='font-weight:bold; color:#444; padding:10px 12px;'>HotelName:</td>
                   <td style='padding:10px 12px; color:#333;'>{HotelName}</td>
               </tr>")}

                {(string.IsNullOrWhiteSpace(checkInDate?.ToString()) ? "" : $@"
                <tr><td style='font-weight:bold; color:#444; padding:10px 12px;'>Check-In Date:</td><td style='padding:10px 12px; color:#333;'>{checkInDate:dd-MM-yyyy}</td></tr>")}

                {(string.IsNullOrWhiteSpace(CheckOut?.ToString()) ? "" : $@"
                <tr>
                    <td style='font-weight:bold; color:#444; padding:10px 12px;'>CheckOut:</td>
                    <td style='padding:10px 12px; color:#333;'>{CheckOut:dd-MM-yyyy}</td>
                </tr>")}

              
                {(string.IsNullOrWhiteSpace(remarks) ? "" : $@"
                <tr><td style='font-weight:bold; color:#444; padding:10px 12px;'>Remarks:</td><td style='padding:10px 12px; color:#333;'>{remarks}</td></tr>")}

                {(string.IsNullOrWhiteSpace(inquiryDateTime) ? "" : $@"
                <tr><td style='font-weight:bold; color:#444; padding:10px 12px;'>Submitted On:</td><td style='padding:10px 12px; color:#333;'>{inquiryDateTime}</td></tr>")}

                {(string.IsNullOrWhiteSpace(entity.WebSiteURL) ? "" : $@"
                <tr>
                    <td style='font-weight:bold; color:#444; padding:10px 12px;'>WebSiteURL:</td>
                    <td style='padding:10px 12px; color:#333;'>{entity.WebSiteURL}</td>
                </tr>")}

  {(string.IsNullOrWhiteSpace(entity.InquiryType) ? "" : $@"
                <tr>
                    <td style='font-weight:bold; color:#444; padding:10px 12px;'>InquiryType:</td>
                    <td style='padding:10px 12px; color:#333;'>{entity.InquiryType}</td>
                </tr>")}
                {(string.IsNullOrWhiteSpace(entity.PackageName) ? "" : $@"
                <tr>
                    <td style='font-weight:bold; color:#444; padding:10px 12px;'>PackageName:</td>
                    <td style='padding:10px 12px; color:#333;'>{entity.PackageName}</td>
                </tr>")}

            </table>

            <p style='margin-top:32px; font-size:15px; color:#555;'>
                Regards,<br/>
                <strong>System Notification</strong><br/>
                <strong>{companyName}</strong>
            </p>
        </td>
    </tr>

    <!-- Footer -->
    <tr>
        <td bgcolor='#f8f9fa' style='padding:22px; text-align:center; font-size:12.5px; color:#777; border-top:1px solid #eee;'>
            © {DateTime.Now.Year} {companyName}. All Rights Reserved.<br/>
            Internal Website Inquiry Notification.
        </td>
    </tr>
</table>
</td>
</tr>
</table>
</body>
</html>
";

                    Task.Run(() =>
                    {
                        try
                        {
                            sendEmail.MailSendSMTP(adminEmail, "", adminSubject, adminBody, "");
                        }
                        catch (Exception ex)
                        {
                            // Optional Log Error
                        }
                    });
                }
            


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

        #region Find All Inquiry
        public async Task<List<InquiryViewEntity>> FindAllInquiry(InquiryPagination entity, string storedProcedure)
        {
            InquiryViewEntity result = new InquiryViewEntity();

            try
            {
                Dapper.DefaultTypeMap.MatchNamesWithUnderscores = true;
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@limit", entity.Limit);
                dynamicParameters.Add("@skip", entity.Skip);
                dynamicParameters.Add("@FirstName", entity.FirstName);
                //dynamicParameters.Add("@Email", entity.Email);
                //dynamicParameters.Add("@MobileNo", entity.MobileNo);
                dynamicParameters.Add("@OperationType",1);
                var data = await _dbConnection.QueryAsync<InquiryViewEntity>(storedProcedure, dynamicParameters, commandType: CommandType.StoredProcedure);
                return data.ToList();

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

    }
}
