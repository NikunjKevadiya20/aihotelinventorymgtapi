using Dapper;
using DapperParameters;
using Microsoft.Extensions.Logging;
using Org.BouncyCastle.Asn1.Pkcs;
using PuppeteerSharp;
using PuppeteerSharp.Media;
using Razorpay.Api;
using HotelBooking.Entity.Common;
using HotelBooking.Entity.Common.Entities;
using HotelBooking.Entity.Common.Enums;
using HotelBooking.Entity.Entities;
using System;
using System.Data;
using System.Data.SqlClient;
using static Dapper.SqlMapper;

namespace HotelBooking.DataAccess.Base
{
    public class BookingLookupRepository : IBookingLookupRepositoryInterface
    {
        private readonly IDbConnection _dbConnection;
        private readonly ILogger<BookingLookupRepository> logger;

        public BookingLookupRepository(ILogger<BookingLookupRepository> _logger, IDbConnection dbConnection)
        {
            logger = _logger;
            _dbConnection = dbConnection;
        }

        #region Insert TempBooking
        public async Task<TempBookingIDViewEntity> InsertTempBooking(
      TempBookingEntity entity,
      string storedProcedure)
        {
            TempBookingIDViewEntity result = new TempBookingIDViewEntity();

            try
            {
                Dapper.DefaultTypeMap.MatchNamesWithUnderscores = true;

                DynamicParameters dynamicParameters = new DynamicParameters();

                dynamicParameters.Add("@FirstName", entity.FirstName);
                dynamicParameters.Add("@LastName", entity.LastName);
                dynamicParameters.Add("@MobileNo", entity.MobileNo);
                dynamicParameters.Add("@EmailID", entity.EmailID);
                dynamicParameters.Add("@IsPayAtHotel", entity.IsPayAtHotel);
                dynamicParameters.Add("@PromoCode", entity.PromoCode);
                dynamicParameters.Add("@FromDate", entity.FromDate);
                dynamicParameters.Add("@ToDate", entity.ToDate);
                dynamicParameters.Add("@NoOfNight", entity.NoOfNight);
          
                dynamicParameters.Add("@IsActive", entity.IsActive);
                dynamicParameters.Add("@CreatedBy", entity.CreatedBy);
                dynamicParameters.Add("@OperationType", CommonRepositoryConstants.Insert);

                // Child Table
                if (entity.TempBookingDetails != null &&
                    entity.TempBookingDetails.Any())
                {
                    dynamicParameters.AddTable<TempBookingDetailEntity>(
                        "@UDTTTempBookingDetails",
                        "dbo.UDTTTempBookingDetails",
                        entity.TempBookingDetails);
                }

                var data = await _dbConnection.QueryAsync(
                    storedProcedure,
                    dynamicParameters,
                    commandType: CommandType.StoredProcedure);

                var first = data.FirstOrDefault();

                if (first != null)
                {
                    result.ID = first.ID;
                    result.BookingNo = first.BookingNo;
                    result.Message = first.Message;
                    result.Details = first.Details;
                }

                return result;
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
        }
        #endregion
        //public async Task<BookingViewInsertEntity> InsertBooking(BookingRequestEntity entity, string storedProcedure)
        public async Task<BookingViewInsertEntity> InsertBooking(BookingRequestEntity entity, string storedProcedure)
        {
            BookingViewInsertEntity result = new BookingViewInsertEntity();

            try
            {
                Dapper.DefaultTypeMap.MatchNamesWithUnderscores = true;

                DynamicParameters dynamicParameters = new DynamicParameters();

                dynamicParameters.Add("@TempID", entity.TempID);
                
                dynamicParameters.Add("@OperationType", CommonRepositoryConstants.Insert);

                using var multi = await _dbConnection.QueryMultipleAsync(
                    storedProcedure,
                    dynamicParameters,
                    commandType: CommandType.StoredProcedure);

                var booking = multi.Read<BookingViewInsertEntity>().FirstOrDefault();

                if (booking != null)
                {
                    booking.BookingDetails = multi
                        .Read<InsertBookingDetailEntity>()
                        .ToList();

                    result = booking;
                }

                return result;
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
                logger.LogError(ex, ex.Message);

                result.Status = (int)ResponseStatusCode.InternaServerError;
                result.Message = CommonRepositoryMessages.ExceptionMessage;
                result.ErrorMessage = ex.Message;

                throw;
            }
        }
        private string GetMimeType(string filePath)
        {
            string extension = Path.GetExtension(filePath)?.ToLowerInvariant();
            return extension switch
            {
                ".png" => "image/png",
                ".jpg" => "image/jpeg",
                ".jpeg" => "image/jpeg",
                ".gif" => "image/gif",
                ".bmp" => "image/bmp",
                _ => "image/png" // Default to PNG if unknown
            };
        }
        public async Task<List<BookingListEntity>> FindAllBooking(BookingSearchEntity entity, string storedProcedure)
        {
            try
            {
                Dapper.DefaultTypeMap.MatchNamesWithUnderscores = true;
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@CustomerName", entity.CustomerName);
                dynamicParameters.Add("@MobileNo", entity.MobileNo);
                dynamicParameters.Add("@EmailID", entity.EmailID);
                dynamicParameters.Add("@BookingNo", entity.BookingNo);
                dynamicParameters.Add("@BookingStatus", entity.BookingStatus);
                dynamicParameters.Add("@PaymentStatus", entity.PaymentStatus);
                dynamicParameters.Add("@FromDate", entity.FromDate);
                dynamicParameters.Add("@ToDate", entity.ToDate);
                dynamicParameters.Add("@skip", entity.Skip);
                dynamicParameters.Add("@limit", entity.Limit);
                
                dynamicParameters.Add("@OperationType", 1);

                var data = await _dbConnection.QueryAsync<BookingListEntity>(storedProcedure, dynamicParameters, commandType: CommandType.StoredProcedure);
                return data.ToList();
            }
            catch (SqlException sqlException)
            {
                logger.LogError(sqlException, sqlException.Message);
                throw;
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.Message);
                throw;
            }
        }

        #region InsertPaymentData
        public async Task<ResultModel> InsertPaymentData(PaymentDataEntity entity, string storedProcedure)
        {
            ResultModel result = new ResultModel();

            try
            {
                Dapper.DefaultTypeMap.MatchNamesWithUnderscores = true;
                DynamicParameters dynamicParameters = new DynamicParameters();

                dynamicParameters.Add("@payment_id", entity.payment_id);
                dynamicParameters.Add("@booking_no", entity.booking_no);
                dynamicParameters.Add("@customer_id", entity.customer_id);
                dynamicParameters.Add("@entity", entity.Entity);
                dynamicParameters.Add("@amount", entity.Amount);
                dynamicParameters.Add("@currency", entity.Currency);
                dynamicParameters.Add("@status", entity.Status);
                dynamicParameters.Add("@order_id", entity.OrderId);
                dynamicParameters.Add("@invoice_id", entity.InvoiceId);
                dynamicParameters.Add("@international", entity.International);
                dynamicParameters.Add("@method", entity.Method);
                dynamicParameters.Add("@amount_refunded", entity.AmountRefunded);
                dynamicParameters.Add("@refund_status", entity.RefundStatus);
                dynamicParameters.Add("@captured", entity.Captured);
                dynamicParameters.Add("@description", entity.Description);
                dynamicParameters.Add("@card_id", entity.CardId);
                dynamicParameters.Add("@bank", entity.Bank);
                dynamicParameters.Add("@wallet", entity.Wallet);
                dynamicParameters.Add("@vpa", entity.Vpa);
                dynamicParameters.Add("@email", entity.Email);
                dynamicParameters.Add("@contact", entity.Contact);
                dynamicParameters.Add("@fee", entity.Fee);
                dynamicParameters.Add("@tax", entity.Tax);
                dynamicParameters.Add("@error_code", entity.ErrorCode);
                dynamicParameters.Add("@error_description", entity.ErrorDescription);
                dynamicParameters.Add("@error_HotelBookingrce", entity.ErrorHotelBookingrce);
                dynamicParameters.Add("@error_step", entity.ErrorStep);
                dynamicParameters.Add("@error_reason", entity.ErrorReason);
                dynamicParameters.Add("@created_at", entity.CreatedAt);

                if (entity.acquirer != null)
                {
                    dynamicParameters.Add("@auth_code", entity.acquirer.auth_code);
                    dynamicParameters.Add("@arn", entity.acquirer.arn);
                    dynamicParameters.Add("@rrn", entity.acquirer.rrn);
                    dynamicParameters.Add("@transaction_id", entity.acquirer.transaction_id);
                    dynamicParameters.Add("@bank_transaction_id", entity.acquirer.bank_transaction_id);
                }
                if (entity.carddetails != null)
                {
                    dynamicParameters.Add("@last4", entity.carddetails.last4);
                    dynamicParameters.Add("@network", entity.carddetails.network);
                    dynamicParameters.Add("@card_type", entity.carddetails.card_type);
                    dynamicParameters.Add("@issuer", entity.carddetails.issuer);
                    dynamicParameters.Add("@card_international", entity.carddetails.card_international);
                    dynamicParameters.Add("@card_emi", entity.carddetails.card_emi);
                    dynamicParameters.Add("@card_sub_type", entity.carddetails.card_sub_type);
                }
                // UPI details
                if (entity.upidetails != null)
                {
                    dynamicParameters.Add("@upi_payer_account_type", entity.upidetails.payer_account_type);
                    dynamicParameters.Add("@upi_vpa", entity.upidetails.vpa);
                    dynamicParameters.Add("@upi_flow", entity.upidetails.flow);
                }

                dynamicParameters.Add("@operationtype", CommonRepositoryConstants.Insert);
                var data = await _dbConnection.QueryAsync(storedProcedure, dynamicParameters, commandType: CommandType.StoredProcedure);
                result.Message = data.FirstOrDefault()?.Message;
                result.Details = data.FirstOrDefault()?.Details;
            }
            catch (SqlException sqlException)
            {
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

            return result;
        }
        #endregion

        #region FindByIDBooking
        public async Task<BookingViewInsertEntity> FindByIDBooking(BookingRequestEntity entity, string storedProcedure)
        {
            BookingViewInsertEntity result = new BookingViewInsertEntity();

            try
            {
                Dapper.DefaultTypeMap.MatchNamesWithUnderscores = true;

                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@ID", entity.ID);
                dynamicParameters.Add("@OperationType", 2);

                using var data = await _dbConnection.QueryMultipleAsync(
                    storedProcedure,
                    dynamicParameters,
                    commandType: CommandType.StoredProcedure);

                // First Result Set (Booking Header)
                var booking = await data.ReadFirstOrDefaultAsync<BookingViewInsertEntity>();

                if (booking != null)
                {
                    // Second Result Set (Booking Details)
                    booking.BookingDetails = (await data.ReadAsync<InsertBookingDetailEntity>()).ToList();
                }

                return booking;
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
        }
        #endregion

        #region Dashboard Count
        public async Task<DashboardResponse> DashboardCount(DashboardCustomerRequestEntity entity, string storedProcedure)
        {
            DashboardResponse result = new DashboardResponse();

            try
            {
                DynamicParameters parameters = new DynamicParameters();

                parameters.Add("@FromDate", entity.FromDate);
                parameters.Add("@ToDate", entity.ToDate);

                using var multi = await _dbConnection.QueryMultipleAsync(
                    storedProcedure,
                    parameters,
                    commandType: CommandType.StoredProcedure);

                
                result.Summary = await multi.ReadFirstOrDefaultAsync<DashboardCountData>();

                
                result.HotelSellingCount = (await multi.ReadAsync<HotelSellingCountData>()).ToList();

              
                result.TicketSellingCount = (await multi.ReadAsync<TicketSellingCountData>()).ToList();

                 
                result.MonthWiseRevanue = (await multi.ReadAsync<MonthWiseRevanueData>()).ToList();

                result.RecentBooking = (await multi.ReadAsync<RecentBookingData>()).ToList();

                result.Status = (int)ResponseStatusCode.Success;
                result.Message = "success";
                result.Details = "Dashboard data found successfully.";

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

        #region Dashboard Booking Details
        public async Task<List<BookingViewEntity>> GetDashboardBookingDetails(DashboardCustomerRequestEntity entity, string storedProcedure)
        {
            List<BookingViewEntity> result = new List<BookingViewEntity>();

            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@FromDate", entity.FromDate);
                parameters.Add("@ToDate", entity.ToDate);
                parameters.Add("@OperationType", 1);

                var data = await _dbConnection.QueryMultipleAsync(storedProcedure, parameters, commandType: CommandType.StoredProcedure);

                // 1. BOOKING LIST
                var orders = (await data.ReadAsync<BookingViewEntity>())
                    .ToList();

                // 2. TICKETS
                var tickets = (await data.ReadAsync<BookingTicketViewEntity>())
                    .ToList();

                // 3. PAX
                var pax = (await data.ReadAsync<BookingTicketPaxViewEntity>())
                    .ToList();

                // 4. HOTELS
                var hotels = (await data.ReadAsync<BookingHotelDetailsViewEntity>())
                    .ToList();

                // MAP PAX -> TICKET
                foreach (var ticket in tickets)
                {
                    ticket.PaxList = pax
                        .Where(p => p.BookingTicketID == ticket.ID)
                        .ToList();
                }

                // MAP TICKETS & HOTELS -> BOOKING
                foreach (var order in orders)
                {
                    order.TicketView = tickets
                        .Where(t => t.BookingID == order.ID)
                        .ToList();

                    order.HotelDetails = hotels
                        .Where(h => h.BookingID == order.ID)
                        .ToList();
                }

                return orders;
            }
            catch (SqlException ex)
            {
                logger.LogError(ex, ex.Message);
                result[0].Status = (int)ResponseStatusCode.InternaServerError;
                result[0].ErrorMessage = ex.Message;
                throw;
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.Message);
                result[0].Status = (int)ResponseStatusCode.InternaServerError;
                result[0].ErrorMessage = ex.Message;
                throw;
            }
        }
        #endregion

        #region Dashboard Inquiry
        public async Task<List<DashboardInquiryData>> GetDashboardInquiry(
            DashboardCustomerRequestEntity entity,
            string storedProcedure)
        {
            DashboardInquiryData result = new DashboardInquiryData();

            try
            {
                Dapper.DefaultTypeMap.MatchNamesWithUnderscores = true;

                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@FromDate", entity.FromDate);
                dynamicParameters.Add("@ToDate", entity.ToDate);
                dynamicParameters.Add("@OperationType", 2);

                var data = await _dbConnection.QueryAsync<DashboardInquiryData>(
                    storedProcedure,
                    dynamicParameters,
                    commandType: CommandType.StoredProcedure);

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

        #region Dashboard Tomorrow CheckIn
        public async Task<List<DashboardTomorrowCheckInData>> GetDashboardTomorrowCheckIn(
           
            string storedProcedure)
        {
            DashboardTomorrowCheckInData result = new DashboardTomorrowCheckInData();

            try
            {
                Dapper.DefaultTypeMap.MatchNamesWithUnderscores = true;

                DynamicParameters dynamicParameters = new DynamicParameters();
 
                dynamicParameters.Add("@OperationType", 3);

                var data = await _dbConnection.QueryAsync<DashboardTomorrowCheckInData>(
                    storedProcedure,
                    dynamicParameters,
                    commandType: CommandType.StoredProcedure);

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

        #region PDF Download
        //        public async Task<PDFDownloadResponse> PDFDownload(BookingRequestEntity entity, string storedProcedure)
        //        {
        //            try
        //            {
        //                DynamicParameters parameters = new DynamicParameters();
        //                parameters.Add("@ID", entity.ID);
        //                parameters.Add("@OperationType", 1);

        //                var multi = await _dbConnection.QueryMultipleAsync(
        //                    storedProcedure,
        //                    parameters,
        //                    commandType: CommandType.StoredProcedure
        //                );

        //                var booking = await multi.ReadFirstOrDefaultAsync<BookingViewInsertEntity>();
        //                var TicketView = (await multi.ReadAsync<BookingTicketViewEntity>()).ToList();
        //                var PaxList = (await multi.ReadAsync<BookingTicketPaxViewEntity>()).ToList();
        //                var HotelDetails = (await multi.ReadAsync<BookingHotelDetailsViewEntity>()).ToList();

        //                foreach (var ticket in TicketView)
        //                {
        //                    ticket.PaxList = PaxList
        //                        .Where(p => p.BookingTicketID == ticket.ID)
        //                        .ToList();
        //                }

        //                booking.TicketView = TicketView;
        //                booking.HotelDetails = HotelDetails;

        //                try
        //                {
        //                    //string companyName = "HotelBooking";
        //                    //string fullName = $"{booking.FirstName} {booking.LastName}".Trim();
        //                    //string bookingNo = booking.BookingNo ?? "N/A";
        //                    //string pnr = booking.PNR ?? "N/A";
        //                    //string customerEmail = booking.EmailID;
        //                    //string adminEmail = booking.AdminMail;
        //                    //decimal finalPrice = booking.FinalPrice ?? 0;

        //                    string companyName = "HotelBooking";
        //                    string fullName = $"{booking.FirstName} {booking.LastName}".Trim();
        //                    string bookingNo = booking.BookingNo ?? "N/A";
        //                    string pnr = booking.PNR ?? "N/A";
        //                    string customerEmail = booking.EmailID;
        //                    string adminEmail = booking.AdminMail;
        //                    decimal finalPrice = booking.FinalPrice ?? 0;
        //                    bool hasTickets = TicketView?.Any() == true;
        //                    bool hasHotel = HotelDetails?.Any() == true;

        //                    // ==================== Logo as Base64 ====================
        //                    string logoImgHtml =
        //                        "<span style='color:white; font-size:28px; font-weight:bold;'>HotelBooking</span>";

        //                    try
        //                    {
        //                        string logoPath = "https://aalpine.in/images/aalpine%20logo%20header.png";

        //                        byte[] imageBytes;

        //                        using (var httpClient = new HttpClient
        //                        {
        //                            Timeout = TimeSpan.FromSeconds(8)
        //                        })
        //                        {
        //                            imageBytes = await httpClient.GetByteArrayAsync(logoPath);
        //                        }

        //                        string base64 = Convert.ToBase64String(imageBytes);
        //                        string mime = GetMimeType(logoPath);

        //                        logoImgHtml =
        //                            $"<img src='data:{mime};base64,{base64}' alt='Chasmawale Logo' style='max-width:180px; height:auto; display:block; margin:auto;' />";
        //                    }
        //                    catch
        //                    {
        //                    }



        //                    // ==================== Hotel Logo ====================
        //                    string hotelLogoHtml = "";

        //                    try
        //                    {
        //                        string hotelLogoPath = HotelDetails?.FirstOrDefault()?.HotelLogo;

        //                        if (!string.IsNullOrWhiteSpace(hotelLogoPath))
        //                        {
        //                            byte[] hotelLogoBytes;

        //                            using (var httpClient = new HttpClient { Timeout = TimeSpan.FromSeconds(8) })
        //                            {
        //                                hotelLogoBytes = await httpClient.GetByteArrayAsync(hotelLogoPath);
        //                            }

        //                            string hotelLogoBase64 = Convert.ToBase64String(hotelLogoBytes);
        //                            string hotelMime = GetMimeType(hotelLogoPath);

        //                            hotelLogoHtml = $@"
        //<img src='data:{hotelMime};base64,{hotelLogoBase64}' 
        //     alt='Hotel Logo' 
        //     style='max-width:90px; max-height:90px; object-fit:contain;' />";
        //                        }
        //                    }
        //                    catch
        //                    {
        //                        hotelLogoHtml = "";
        //                    }

        //                    // ==================== HTML ====================

        //                    //string pdfHtml = $@"
        //                    //<!DOCTYPE html>
        //                    //<html>
        //                    //<head>
        //                    //    <meta charset='UTF-8'>
        //                    //    <title>Booking Voucher - {bookingNo}</title>
        //                    //    <style>
        //                    //        body {{ 
        //                    //            font-family: Arial, sans-serif; 
        //                    //            font-size: 13px; 
        //                    //            margin: 0; 
        //                    //            padding: 20px; 
        //                    //            background: #fff; 
        //                    //        }}
        //                    //        .voucher {{ 
        //                    //            max-width: 820px; 
        //                    //            margin: 0 auto; 
        //                    //            border: 2px solid #c8a951; 
        //                    //            border-radius: 6px; 
        //                    //            overflow: hidden;
        //                    //        }}

        //                    //    .header {{display: table;
        //                    //    width: 100%;
        //                    //    padding: 12px 20px;
        //                    //    border-bottom: 2px solid #c8a951;
        //                    //    box-sizing: border-box;
        //                    //}}

        //                    //.header-left,
        //                    //.header-center,
        //                    //.header-right {{display: table-cell;
        //                    //    vertical-align: middle;
        //                    //}}

        //                    ///* LEFT SECTION */
        //                    //.header-left {{width: 32%;
        //                    //    text-align: left;
        //                    //    padding-left: 10px;
        //                    //    vertical-align: top;
        //                    //}}

        //                    //.hotel-logo img {{max - width: 100px;
        //                    //    max-height: 100px;
        //                    //    object-fit: contain;
        //                    //}}

        //                    //.property-label {{margin - top: 6px;
        //                    //    margin-left: -15px;
        //                    //    font-size: 14px;
        //                    //    font-weight: bold;
        //                    //    color: #333;
        //                    //    white-space: nowrap;
        //                    //}}

        //                    ///* CENTER SECTION */
        //                    //.header-center {{width: 38%;
        //                    //    text-align: center;
        //                    //}}

        //                    //.center-logo img {{max - width: 220px;
        //                    //    max-height: 90px;
        //                    //    object-fit: contain;
        //                    //}}

        //                    ///* RIGHT SECTION */
        //                    //.header-right {{width: 30%;
        //                    //    text-align: right;
        //                    //    font-size: 12px;
        //                    //    color: #333;
        //                    //    line-height: 1.8;
        //                    //    padding-right: 10px;
        //                    //}}
        //                    // .pnr-bar {{
        //                    //            background: #c8a951;
        //                    //            color: white;
        //                    //            display: flex;
        //                    //            justify-content: space-between;
        //                    //            align-items: center;
        //                    //            padding: 8px 20px;
        //                    //            font-weight: bold;
        //                    //            font-size: 15px;
        //                    //        }}


        //                    //        /* GUEST NAME */
        //                    //        .guest-name {{
        //                    //            background: #f5f0e8;
        //                    //            padding: 14px 20px;
        //                    //            border-bottom: 1px solid #e0c97a;
        //                    //        }}
        //                    //        .guest-name h2 {{
        //                    //            margin: 0 0 4px 0;
        //                    //            font-size: 20px;
        //                    //            color: #333;
        //                    //        }}
        //                    //        .guest-name p {{
        //                    //            margin: 0;
        //                    //            font-size: 12px;
        //                    //            color: #555;
        //                    //        }}

        //                    //        /* SECTIONS */
        //                    //        .section-title {{
        //                    //            background: #f5f0e8;
        //                    //            padding: 10px 20px;
        //                    //            font-size: 16px;
        //                    //            font-weight: bold;
        //                    //            color: #333;
        //                    //            border-bottom: 1px solid #e0c97a;
        //                    //            border-top: 1px solid #e0c97a;
        //                    //        }}

        //                    //        /* TABLE */
        //                    //        table {{
        //                    //            width: 100%;
        //                    //            border-collapse: collapse;
        //                    //        }}
        //                    //        .detail-table td {{
        //                    //            padding: 9px 20px;
        //                    //            border-bottom: 1px solid #f0e8d0;
        //                    //            font-size: 13px;
        //                    //            color: #333;
        //                    //        }}
        //                    //        .detail-table td:first-child {{
        //                    //            font-weight: bold;
        //                    //            width: 200px;
        //                    //            color: #555;
        //                    //        }}

        //                    //        /* GRID for guest details */
        //                    //        .two-col-table {{
        //                    //            width: 100%;
        //                    //            border-collapse: collapse;
        //                    //        }}
        //                    //        .two-col-table td {{
        //                    //            padding: 9px 20px;
        //                    //            border-bottom: 1px solid #f0e8d0;
        //                    //            font-size: 13px;
        //                    //            color: #333;
        //                    //            width: 25%;
        //                    //        }}
        //                    //        .two-col-table td.label {{
        //                    //            font-weight: bold;
        //                    //            color: #555;
        //                    //        }}

        //                    //        /* ROOM STATS */
        //                    //        .room-grid {{
        //                    //            display: grid;
        //                    //            grid-template-columns: 1fr 1fr 1fr 1fr;
        //                    //            border-bottom: 1px solid #f0e8d0;
        //                    //        }}
        //                    //        .room-cell {{
        //                    //            padding: 12px 20px;
        //                    //            border-right: 1px solid #f0e8d0;
        //                    //            text-align: center;
        //                    //        }}
        //                    //        .room-cell:last-child {{ border-right: none; }}
        //                    //        .room-cell .val {{
        //                    //            font-size: 28px;
        //                    //            font-weight: bold;
        //                    //            color: #c8a951;
        //                    //        }}
        //                    //        .room-cell .lbl {{
        //                    //            font-size: 11px;
        //                    //            color: #777;
        //                    //            margin-top: 2px;
        //                    //        }}

        //                    //        /* TOTAL ROW */
        //                    //        .total-row {{
        //                    //            background: #c8a951;
        //                    //            color: white;
        //                    //            font-size: 17px;
        //                    //            font-weight: bold;
        //                    //            padding: 12px 20px;
        //                    //            display: flex;
        //                    //            justify-content: space-between;
        //                    //        }}

        //                    //        /* POLICY */
        //                    //        .policy-body {{
        //                    //            padding: 14px 20px;
        //                    //            border-bottom: 1px solid #e0c97a;
        //                    //        }}
        //                    //        .policy-body ol {{
        //                    //            margin: 0;
        //                    //            padding-left: 18px;
        //                    //            line-height: 2;
        //                    //            font-size: 13px;
        //                    //            color: #444;
        //                    //        }}
        //                    //        .policy-note {{
        //                    //            font-style: italic;
        //                    //            font-size: 12px;
        //                    //            color: #555;
        //                    //            padding: 10px 20px;
        //                    //            border-bottom: 1px solid #e0c97a;
        //                    //        }}

        //                    //        /* FOOTER */
        //                    //        .footer {{
        //                    //            background: #f9f6f0;
        //                    //            display: flex;
        //                    //            justify-content: space-between;
        //                    //            padding: 14px 20px;
        //                    //            font-size: 12px;
        //                    //            color: #444;
        //                    //            line-height: 1.7;
        //                    //            border-top: 1px solid #e0c97a;
        //                    //        }}
        //                    //        .footer strong {{ display: block; color: #222; font-size: 13px; }}
        //                    //        .footer-thanks {{
        //                    //            text-align: center;
        //                    //            padding: 10px;
        //                    //            font-size: 12px;
        //                    //            color: #888;
        //                    //            background: #fff;
        //                    //        }}
        //                    //    </style>
        //                    //</head>
        //                    //<body>
        //                    //<div class='voucher'>

        //                    //  <!-- HEADER -->
        //                    //<div class='header'>

        //                    //    <!-- LEFT : HOTEL LOGO -->
        //                    //    <div class='header-left'>
        //                    //        <div class='hotel-logo'>
        //                    //            {hotelLogoHtml}
        //                    //        </div>
        //                    // <div class='property-label'>
        //                    //        {HotelDetails.FirstOrDefault()?.HotelName ?? "N/A"}
        //                    //    </div>
        //                    //    </div>

        //                    //    <!-- CENTER : AALPINE LOGO -->
        //                    //    <div class='header-center'>
        //                    //        <div class='center-logo'>
        //                    //            {logoImgHtml}
        //                    //        </div>
        //                    //    </div>

        //                    //    <!-- RIGHT : CONTACT -->
        //                    //    <div class='header-right'>
        //                    //        <strong>+91 9898 034 096</strong><br>
        //                    //        booking@aalpine.in<br>
        //                    //        www.aalpine.in
        //                    //    </div>

        //                    //</div>


        //                    //        <!-- PNR BAR -->
        //                    //    <div class='pnr-bar'>
        //                    //        <span>PNR: {pnr}</span>
        //                    //        <span>Booking Voucher</span>
        //                    //    </div>

        //                    //    <!-- GUEST NAME -->
        //                    //    <div class='guest-name'>
        //                    //        <h3>Dear : {fullName}</h3>
        //                    //        <p>It is mandatory to produce this voucher along with a valid photo ID at the time of check-in</p>
        //                    //    </div>

        //                    //    <!-- GUEST DETAILS -->
        //                    //    <div class='section-title'>Guest Details</div>
        //                    //    <table class='two-col-table'>
        //                    // <tr>
        //                    //            <td class='label'>Name :</td>
        //                    //            <td>{fullName}</td>
        //                    //            <td class='label'>Mobile No :</td>
        //                    //            <td>{booking.MobileNo ?? "N/A"}</td>
        //                    //        </tr>
        //                    //        <tr>
        //                    //            <td class='label'>Check In Date :</td>
        //                    //            <td>{HotelDetails.FirstOrDefault()?.CheckIn}</td>
        //                    //            <td class='label'>Check Out Date :</td>
        //                    //            <td>{HotelDetails.FirstOrDefault()?.CheckOut}</td>
        //                    //        </tr>

        //                    //         <tr>
        //                    //            <td class='label'>Booking Date :</td>
        //                    //            <td>{DateTime.Now:dd MMM yyyy HH:mm}</td>
        //                    //            <td class='label'>WhatsApp MobileNo :</td>
        //                    //            <td>{booking.WhatsAppMobileNo ?? "N/A"}</td>
        //                    //        </tr>



        //                    //        <tr>
        //                    //            <td class='label'>Room Category :</td>
        //                    //            <td>{HotelDetails.FirstOrDefault()?.RoomCategoryName}</td>
        //                    //            <td class='label'>Meal Plan :</td>
        //                    //            <td>[{HotelDetails.FirstOrDefault()?.MealPlanName}] - {HotelDetails.FirstOrDefault()?.MealPlanDescription}</td>
        //                    //        </tr>
        //                    //        <tr>
        //                    //            <td class='label'>Email :</td>
        //                    //            <td colspan='3'>{booking.EmailID}</td>
        //                    //        </tr>
        //                    //    </table>

        //                    //    <!-- ROOM DETAILS -->
        //                    //    <div class='section-title'>Room Details</div>
        //                    //    <div class='room-grid'>
        //                    //        <div class='room-cell'>
        //                    //            <div class='val'>{HotelDetails.FirstOrDefault()?.Rooms}</div>
        //                    //            <div class='lbl'>Total Room</div>
        //                    //        </div>
        //                    //        <div class='room-cell'>
        //                    //            <div class='val'>{HotelDetails.FirstOrDefault()?.Adults}</div>
        //                    //            <div class='lbl'>Adult</div>
        //                    //        </div>
        //                    //        <div class='room-cell'>
        //                    //            <div class='val'>{HotelDetails.FirstOrDefault()?.Child}</div>
        //                    //            <div class='lbl'>Child</div>
        //                    //        </div>
        //                    //        <div class='room-cell'>
        //                    //            <div class='val'>{(HotelDetails.FirstOrDefault()?.Adults ?? 0) + (HotelDetails.FirstOrDefault()?.Child ?? 0)}</div>
        //                    //            <div class='lbl'>Total Person</div>
        //                    //        </div>
        //                    //    </div>

        //                    //    <!-- PRICE -->

        //                    // {(booking.HotelBookingPackageID == null || booking.HotelBookingPackageID == 0 ? $@"
        //                    //    <div class='total-row'>
        //                    //        <span>Total Amount :</span>
        //                    //        <span>&#8377; {HotelDetails.FirstOrDefault()?.TotalAmount:N0}/-</span>
        //                    //    </div>" : "")}

        //                    //    <!-- CANCELLATION POLICY -->
        //                    //    <div class='section-title'>Cancellation Policy</div>
        //                    //    <div class='policy-body'>
        //                    //        <ol>
        //                    //            <li>100% refund if cancelled before 20 days of scheduled arrival date.</li>
        //                    //            <li>50% refund if cancelled more than or equal to 10 days prior to scheduled arrival date but less than 20 days prior to scheduled arrival date.</li>
        //                    //            <li>No refund if cancelled less than 10 days prior to scheduled arrival date.</li>
        //                    //            <li>Change in guest/guests names would be treated as Cancellation.</li>
        //                    //            <li>In case of any date change Rs.1500/Per Tent + 18% GST will be charged. (Rate difference shall be levied)</li>
        //                    //            <li>Rates are exclusive of applicable taxes.</li>
        //                    //            <li>GST shall be charged as per applicable.</li>
        //                    //            <li>In case of triple occupancy, any person above 6 yrs. of age will be charged as an extra person (with mattress).</li>
        //                    //        </ol>
        //                    //    </div>
        //                    //    <div class='policy-note'>** Note: Organiser reserves all rights to make any changes without prior notice.</div>

        //                    //    <!-- FOOTER -->
        //                    //    <div class='footer'>
        //                    //        <div>
        //                    //            <strong>Aalpine Holiday Nagari India Pvt. Ltd.</strong>
        //                    //            Reservation Office<br>
        //                    //            B-701/702, PNTC, Radio Mirchi Road,<br>
        //                    //            Satellite, Ahmedabad.
        //                    //        </div>
        //                    //        <div style='text-align:right;'>
        //                    //            <strong>{HotelDetails.FirstOrDefault()?.HotelName ?? "N/A"}</strong>
        //                    //            Site Address<br>
        //                    //            {HotelDetails.FirstOrDefault()?.HotelAddress ?? "N/A"}
        //                    //        </div>
        //                    //    </div>
        //                    //    <div class='footer-thanks'>Thank you for choosing {HotelDetails.FirstOrDefault()?.HotelName ?? "N/A"}</div>

        //                    //</div>
        //                    //</body>
        //                    //</html>";



        //                    // ====================== REPLACE your existing pdfHtml string with this ======================
        //                    // Place this after: string hotelLogoHtml = ""; (and after hotel logo loading logic)

        //                    string pdfHtml = $@"
        //<!DOCTYPE html>
        //<html>
        //<head>
        //    <meta charset='UTF-8'>
        //    <title>Booking Voucher - {bookingNo}</title>
        //    <style>
        //        * {{ box-sizing: border-box; margin: 0; padding: 0; }}
        //        body {{
        //            font-family: 'Segoe UI', Arial, sans-serif;
        //            font-size: 13px;
        //            background: #f4f4f4;
        //            color: #222;
        //            padding: 30px 20px;
        //        }}
        //        .page {{
        //            max-width: 780px;
        //            margin: 0 auto;
        //            background: #fff;
        //            border-radius: 8px;
        //            overflow: hidden;
        //            box-shadow: 0 2px 16px rgba(0,0,0,0.10);
        //        }}

        //        /* ---- TOP NAV BAR ---- */
        //        .top-bar {{
        //            background: #fff;
        //            border-bottom: 1px solid #e8e8e8;
        //            padding: 14px 28px;
        //            display: flex;
        //            align-items: center;
        //            justify-content: space-between;
        //        }}
        //        .top-bar .brand {{
        //            font-size: 18px;
        //            font-weight: 700;
        //            color: #1a1a2e;
        //            letter-spacing: -0.3px;
        //        }}
        //        .top-bar .brand span {{ color: #2563eb; }}

        //        /* ---- HERO SECTION ---- */
        //        .hero {{
        //            padding: 28px 28px 22px 28px;
        //            border-bottom: 1px solid #ebebeb;
        //            display: table;
        //            width: 100%;
        //        }}
        //        .hero-left {{
        //            display: table-cell;
        //            vertical-align: top;
        //            width: 55%;
        //        }}
        //        .hero-right {{
        //            display: table-cell;
        //            vertical-align: top;
        //            width: 45%;
        //            text-align: right;
        //        }}
        //        .confirmed-badge {{
        //            display: inline-block;
        //            background: #1a1a2e;
        //            color: #fff;
        //            font-size: 10px;
        //            font-weight: 700;
        //            letter-spacing: 1.2px;
        //            padding: 4px 10px;
        //            border-radius: 3px;
        //            margin-bottom: 10px;
        //            text-transform: uppercase;
        //        }}
        //        .ref-number {{
        //            font-size: 28px;
        //            font-weight: 800;
        //            color: #1a1a2e;
        //            margin-bottom: 6px;
        //            letter-spacing: -0.5px;
        //        }}
        //        .ref-subtitle {{
        //            font-size: 12px;
        //            color: #777;
        //            font-style: italic;
        //        }}
        //        .hotel-name-block {{
        //            margin-bottom: 6px;
        //        }}
        //        .hotel-name-block .hotel-icon {{
        //            color: #c8a951;
        //            font-size: 16px;
        //            margin-right: 4px;
        //        }}
        //        .hotel-name-block strong {{
        //            font-size: 15px;
        //            font-weight: 700;
        //            color: #1a1a2e;
        //        }}
        //        .hotel-address {{
        //            font-size: 12px;
        //            color: #555;
        //            line-height: 1.6;
        //            margin-top: 5px;
        //        }}
        //        .hotel-contact {{
        //            font-size: 12px;
        //            color: #333;
        //            margin-top: 4px;
        //        }}
        //        .hero-divider {{
        //            border: none;
        //            border-top: 1px solid #ddd;
        //            margin: 20px 0 0 0;
        //        }}

        //        /* ---- GREETING ---- */
        //        .greeting {{
        //            padding: 20px 28px 10px 28px;
        //        }}
        //        .greeting p {{
        //            font-size: 13.5px;
        //            line-height: 1.7;
        //            color: #333;
        //        }}
        //        .greeting strong {{ color: #1a1a2e; }}

        //        /* ---- CARDS ROW (Stay + Guest) ---- */
        //        .cards-row {{
        //            padding: 14px 28px 18px 28px;
        //            display: table;
        //            width: 100%;
        //        }}
        //        .card-left {{
        //            display: table-cell;
        //            vertical-align: top;
        //            width: 48%;
        //            padding-right: 10px;
        //        }}
        //        .card-right {{
        //            display: table-cell;
        //            vertical-align: top;
        //            width: 52%;
        //        }}
        //        .info-card {{
        //            border: 1px solid #e8e8e8;
        //            border-radius: 8px;
        //            overflow: hidden;
        //            height: 100%;
        //        }}
        //        .info-card-header {{
        //            padding: 10px 16px;
        //            font-size: 10px;
        //            font-weight: 700;
        //            letter-spacing: 1px;
        //            text-transform: uppercase;
        //            color: #888;
        //            border-bottom: 1px solid #f0f0f0;
        //            display: flex;
        //            align-items: center;
        //            gap: 6px;
        //        }}
        //        .info-card-body {{
        //            padding: 14px 16px;
        //        }}
        //        /* Stay Details Card */
        //        .stay-dates {{
        //            display: table;
        //            width: 100%;
        //            margin-bottom: 12px;
        //        }}
        //        .stay-date-col {{
        //            display: table-cell;
        //            width: 50%;
        //        }}
        //        .stay-date-col .date-label {{
        //            font-size: 11px;
        //            color: #999;
        //            margin-bottom: 3px;
        //        }}
        //        .stay-date-col .date-val {{
        //            font-size: 15px;
        //            font-weight: 700;
        //            color: #1a1a2e;
        //        }}
        //        .stay-date-col .date-time {{
        //            font-size: 11px;
        //            color: #888;
        //            font-style: italic;
        //        }}
        //        .stay-duration {{
        //            display: flex;
        //            justify-content: space-between;
        //            align-items: center;
        //            border-top: 1px solid #f0f0f0;
        //            padding-top: 10px;
        //            font-size: 13px;
        //            color: #555;
        //        }}
        //        .stay-duration strong {{
        //            color: #1a1a2e;
        //            font-size: 13.5px;
        //        }}
        //        /* Guest Card */
        //        .guest-name-big {{
        //            font-size: 18px;
        //            font-weight: 700;
        //            color: #1a1a2e;
        //            margin-bottom: 4px;
        //        }}
        //        .guest-email {{
        //            font-size: 12px;
        //            color: #2563eb;
        //            margin-bottom: 8px;
        //        }}
        //        .guest-booking-date {{
        //            font-size: 11.5px;
        //            color: #888;
        //            display: flex;
        //            align-items: center;
        //            gap: 5px;
        //        }}

        //        /* ---- ROOM IMAGE + LABEL (right side of cards) ---- */
        //        .room-image-card {{
        //            border: 1px solid #e8e8e8;
        //            border-radius: 8px;
        //            overflow: hidden;
        //            position: relative;
        //        }}
        //        .room-image-card img {{
        //            width: 100%;
        //            height: 220px;
        //            object-fit: cover;
        //            display: block;
        //        }}
        //        .room-image-placeholder {{
        //            width: 100%;
        //            height: 220px;
        //            background: linear-gradient(135deg, #1a1a2e 60%, #2563eb 100%);
        //            display: flex;
        //            align-items: flex-end;
        //        }}
        //        .room-image-overlay {{
        //            position: absolute;
        //            bottom: 0;
        //            left: 0;
        //            right: 0;
        //            background: linear-gradient(transparent, rgba(15,23,42,0.92));
        //            padding: 14px 16px 12px 16px;
        //        }}
        //        .most-selected-badge {{
        //            display: inline-block;
        //            background: #c8a951;
        //            color: #fff;
        //            font-size: 9px;
        //            font-weight: 700;
        //            letter-spacing: 1px;
        //            text-transform: uppercase;
        //            padding: 3px 8px;
        //            border-radius: 3px;
        //            margin-bottom: 6px;
        //        }}
        //        .room-type-name {{
        //            font-size: 16px;
        //            font-weight: 700;
        //            color: #fff;
        //            margin-bottom: 4px;
        //        }}
        //        .room-stats {{
        //            font-size: 12px;
        //            color: rgba(255,255,255,0.8);
        //        }}

        //        /* ---- FINANCIAL SUMMARY ---- */
        //        .section-label {{
        //            padding: 14px 28px 8px 28px;
        //            font-size: 10px;
        //            font-weight: 700;
        //            letter-spacing: 1.5px;
        //            text-transform: uppercase;
        //            color: #888;
        //        }}
        //        .financial-table {{
        //            margin: 0 28px 4px 28px;
        //            border: 1px solid #e8e8e8;
        //            border-radius: 8px;
        //            overflow: hidden;
        //        }}
        //        .financial-table table {{
        //            width: 100%;
        //            border-collapse: collapse;
        //        }}
        //        .financial-table table thead tr {{
        //            background: #f8f8f8;
        //            border-bottom: 1px solid #eee;
        //        }}
        //        .financial-table table thead th {{
        //            padding: 10px 16px;
        //            font-size: 12px;
        //            font-weight: 600;
        //            color: #444;
        //            text-align: left;
        //        }}
        //        .financial-table table thead th:last-child {{
        //            text-align: right;
        //        }}
        //        .financial-table table tbody tr {{
        //            border-bottom: 1px solid #f0f0f0;
        //        }}
        //        .financial-table table tbody tr:last-child {{
        //            border-bottom: none;
        //        }}
        //        .financial-table table tbody td {{
        //            padding: 11px 16px;
        //            font-size: 13px;
        //            color: #444;
        //        }}
        //        .financial-table table tbody td:last-child {{
        //            text-align: right;
        //            color: #333;
        //        }}
        //        .grand-total-row {{
        //            background: #1a1a2e;
        //            color: #fff;
        //            display: flex;
        //            justify-content: space-between;
        //            align-items: center;
        //            padding: 13px 16px;
        //            font-size: 15px;
        //            font-weight: 700;
        //            margin: 0 28px;
        //            border-radius: 0 0 8px 8px;
        //            border: 1px solid #1a1a2e;
        //            border-top: none;
        //        }}
        //        .grand-total-row .amount {{
        //            font-size: 20px;
        //            letter-spacing: -0.5px;
        //        }}

        //        /* ---- PAYMENT STATUS ---- */
        //        .payment-status-bar {{
        //            margin: 12px 28px;
        //            background: #fef9ec;
        //            border: 1px solid #f0e0a0;
        //            border-radius: 8px;
        //            padding: 12px 16px;
        //            display: flex;
        //            justify-content: space-between;
        //            align-items: center;
        //        }}
        //        .payment-status-left {{
        //            display: flex;
        //            align-items: center;
        //            gap: 10px;
        //        }}
        //        .payment-icon {{
        //            width: 32px;
        //            height: 32px;
        //            background: #c8a951;
        //            border-radius: 50%;
        //            display: flex;
        //            align-items: center;
        //            justify-content: center;
        //            color: #fff;
        //            font-size: 14px;
        //            font-weight: bold;
        //        }}
        //        .payment-status-text .ps-title {{
        //            font-size: 11px;
        //            font-weight: 700;
        //            letter-spacing: 1px;
        //            text-transform: uppercase;
        //            color: #8a6d00;
        //        }}
        //        .payment-status-text .ps-sub {{
        //            font-size: 12px;
        //            color: #6b5500;
        //            margin-top: 2px;
        //        }}
        //        .payment-status-right {{
        //            text-align: right;
        //        }}
        //        .payment-status-right .booked-by-label {{
        //            font-size: 11px;
        //            color: #888;
        //        }}
        //        .payment-status-right .booked-by-name {{
        //            font-size: 15px;
        //            font-weight: 700;
        //            color: #1a1a2e;
        //        }}

        //        /* ---- POLICIES ---- */
        //        .policies-row {{
        //            display: table;
        //            width: 100%;
        //            padding: 16px 28px 10px 28px;
        //            border-top: 1px solid #ebebeb;
        //            margin-top: 10px;
        //        }}
        //        .policy-col {{
        //            display: table-cell;
        //            width: 50%;
        //            vertical-align: top;
        //            padding-right: 20px;
        //        }}
        //        .policy-col:last-child {{ padding-right: 0; }}
        //        .policy-title {{
        //            font-size: 13px;
        //            font-weight: 700;
        //            color: #1a1a2e;
        //            margin-bottom: 6px;
        //            display: flex;
        //            align-items: center;
        //            gap: 6px;
        //        }}
        //        .policy-text {{
        //            font-size: 12px;
        //            color: #666;
        //            line-height: 1.65;
        //        }}

        //        /* ---- TICKETS SECTION ---- */
        //        .ticket-section {{
        //            margin: 0 28px 4px 28px;
        //            border: 1px solid #e8e8e8;
        //            border-radius: 8px;
        //            overflow: hidden;
        //        }}
        //        .ticket-section table {{
        //            width: 100%;
        //            border-collapse: collapse;
        //        }}
        //        .ticket-section table tr {{
        //            border-bottom: 1px solid #f0f0f0;
        //        }}
        //        .ticket-section table tr:last-child {{
        //            border-bottom: none;
        //        }}
        //        .ticket-section table td {{
        //            padding: 10px 16px;
        //            font-size: 13px;
        //            color: #444;
        //        }}
        //        .ticket-section table td.lbl {{
        //            font-weight: 600;
        //            color: #888;
        //            width: 40%;
        //        }}

        //        /* ---- LEGAL NOTE ---- */
        //        .legal-note {{
        //            margin: 12px 28px;
        //            background: #f8f8f8;
        //            border-radius: 6px;
        //            padding: 12px 16px;
        //            font-size: 11.5px;
        //            color: #888;
        //            font-style: italic;
        //            text-align: center;
        //            border: 1px solid #ebebeb;
        //        }}

        //        /* ---- FOOTER ---- */
        //        .footer-bar {{
        //            background: #1a1a2e;
        //            padding: 18px 28px;
        //            display: table;
        //            width: 100%;
        //            margin-top: 14px;
        //        }}
        //        .footer-bar-left {{
        //            display: table-cell;
        //            vertical-align: middle;
        //        }}
        //        .footer-bar-left .brand-footer {{
        //            font-size: 14px;
        //            font-weight: 700;
        //            color: #fff;
        //            letter-spacing: 0.5px;
        //        }}
        //        .footer-bar-left .brand-sub {{
        //            font-size: 11px;
        //            color: rgba(255,255,255,0.5);
        //            margin-top: 2px;
        //        }}
        //        .footer-bar-right {{
        //            display: table-cell;
        //            vertical-align: middle;
        //            text-align: right;
        //        }}
        //        .footer-links {{
        //            font-size: 11px;
        //            color: rgba(255,255,255,0.6);
        //        }}
        //        .footer-links span {{
        //            margin-left: 14px;
        //        }}
        //        .footer-help {{
        //            font-size: 11px;
        //            color: rgba(255,255,255,0.5);
        //            margin-top: 3px;
        //        }}

        //        /* ---- AALPINE LOGO AT BOTTOM ---- */
        //        .aalpine-logo-section {{
        //            text-align: center;
        //            padding: 18px 28px 12px 28px;
        //            border-top: 1px solid #ebebeb;
        //        }}
        //        .aalpine-logo-section .powered-by {{
        //            font-size: 11px;
        //            color: #aaa;
        //            margin-bottom: 6px;
        //            text-transform: uppercase;
        //            letter-spacing: 1px;
        //        }}
        //    </style>
        //</head>
        //<body>
        //<div class='page'>



        //    <!-- HERO -->
        //    <div class='hero'>
        //        <div class='hero-left'>
        //            <div class='confirmed-badge'>Confirmed Booking</div>
        //            <div class='ref-number'>PNR: {pnr}</div>
        //            <div class='ref-subtitle'>Kindly present this voucher upon check-in at the hotel.</div>
        //        </div>
        //       <div class='hero-right'>
        //    <div class='hotel-name-block'>
        //        <strong>{HotelDetails.FirstOrDefault()?.HotelName ?? "N/A"}</strong>
        //    </div>
        //    <div class='hotel-address'>
        //        {HotelDetails.FirstOrDefault()?.HotelAddress ?? "N/A"}
        //    </div>
        //    <div class='hotel-contact'>
        //        <strong>Contact:</strong> {HotelDetails.FirstOrDefault()?.HotelContactPersonMobileNo} | {HotelDetails.FirstOrDefault()?.HotelContactPersonName}
        //    </div>
        //</div>
        //    </div>
        //    <hr class='hero-divider' style='border:none;border-top:1px solid #ddd;margin:0 28px;'/>

        //    <!-- GREETING -->
        //    <div class='greeting'>
        //        <p>Dear <strong>{fullName}</strong>,</p>
        //        <p style='margin-top:8px;'>Thank you for choosing <strong>{HotelDetails.FirstOrDefault()?.HotelName ?? "N/A"}</strong> for your upcoming stay. Your reservation request has been successfully confirmed. Below are your personalized travel details for your holiday.</p>
        //    </div>

        //    <!-- CARDS ROW -->
        //    <div class='cards-row'>
        //        <!-- LEFT: Stay + Guest stacked -->
        //        <div class='card-left'>
        //            <!-- Stay Details -->
        //            <div class='info-card' style='margin-bottom:12px;'>
        //                <div class='info-card-header'>&#128197; Stay Details</div>
        //                <div class='info-card-body'>
        //                    <div class='stay-dates'>
        //                        <div class='stay-date-col'>
        //                            <div class='date-label'>Check-In</div>
        //                            <div class='date-val'>{HotelDetails.FirstOrDefault()?.CheckIn}</div>
        //                            <div class='date-time'>From 12:00 PM</div>
        //                        </div>
        //                        <div class='stay-date-col'>
        //                            <div class='date-label'>Check-Out</div>
        //                            <div class='date-val'>{HotelDetails.FirstOrDefault()?.CheckOut}</div>
        //                            <div class='date-time'>Until 10:00 AM</div>
        //                        </div>
        //                    </div>
        //                    <div class='stay-duration'>
        //                        <span>Duration:</span>
        //                        <strong>{HotelDetails.FirstOrDefault()?.Night ?? 1} Night{((HotelDetails.FirstOrDefault()?.Night ?? 1) > 1 ? "s" : "")}</strong>
        //                    </div>
        //                </div>
        //            </div>
        //            <!-- Guest Info -->
        //            <div class='info-card'>
        //                <div class='info-card-header'>&#128100; Guest Information</div>
        //                <div class='info-card-body'>
        //                    <div class='guest-name-big'>{fullName}</div>
        //                    <div class='guest-email'>{booking.EmailID}</div>
        //                    <div class='guest-booking-date'>&#9432; Booking Date: {booking.CreatedOn?.ToString("dd/MM/yyyy") ?? DateTime.Now.ToString("dd/MM/yyyy")}</div>
        //                    {(!string.IsNullOrWhiteSpace(booking.MobileNo) ? $"<div style='font-size:12px;color:#555;margin-top:5px;'>&#128222; {booking.MobileNo}</div>" : "")}
        //                </div>
        //            </div>
        //        </div>

        //        <!-- RIGHT: Room Image -->
        //        <div class='card-right'>
        //            <div class='room-image-card' style='height:100%;min-height:220px;'>
        //                {(!string.IsNullOrWhiteSpace(HotelDetails.FirstOrDefault()?.MainImage)
        //                                        ? $"<img src='{HotelDetails.FirstOrDefault()?.MainImage}' alt='Room' style='width:100%;height:260px;object-fit:cover;display:block;' />"
        //                                        : "<div class='room-image-placeholder' style='height:260px;background:linear-gradient(135deg,#1a1a2e 60%,#2563eb 100%);display:flex;align-items:flex-end;'></div>")}
        //                <div class='room-image-overlay'>
        //                    <div class='most-selected-badge'>Most Selected</div>
        //                    <div class='room-type-name'>{HotelDetails.FirstOrDefault()?.RoomCategoryName ?? "Room"} [{HotelDetails.FirstOrDefault()?.MealPlanName ?? ""}]</div>
        //                    <div class='room-stats'>{HotelDetails.FirstOrDefault()?.Rooms ?? 1} Room &bull; {HotelDetails.FirstOrDefault()?.Adults ?? 0} Adult{((HotelDetails.FirstOrDefault()?.Adults ?? 0) != 1 ? "s" : "")} &bull; {HotelDetails.FirstOrDefault()?.Child ?? 0} Children</div>
        //                </div>
        //            </div>
        //        </div>
        //    </div>



        //    <!-- FINANCIAL SUMMARY -->
        //    <div class='section-label'>Financial Summary</div>
        //    <div class='financial-table'>
        //        <table>
        //            <thead>
        //                <tr>
        //                    <th>Description</th>
        //                    <th style='text-align:right;'>Amount (INR)</th>
        //                </tr>
        //            </thead>
        //            <tbody>
        //                {(hasHotel && HotelDetails.FirstOrDefault()?.TotalAmount != null ? $@"
        //                <tr>
        //                    <td>Total Room Charges</td>
        //                    <td style='text-align:right;'>{(HotelDetails.FirstOrDefault()?.TotalAmount ?? 0) - (HotelDetails.FirstOrDefault()?.GSTPrice ?? 0):N2}</td>
        //                </tr>
        //                <tr>
        //                    <td>Room Charges Tax (GST)</td>
        //                    <td style='text-align:right;'>{( HotelDetails.FirstOrDefault()?.GSTPrice ?? 0):N2}</td>
        //                </tr>
        //                <tr>
        //                    <td>Inclusions Including Tax</td>
        //                    <td style='text-align:right;'>0.00</td>
        //                </tr>" : $@"
        //                <tr>
        //                    <td>Booking Amount</td>
        //                    <td style='text-align:right;'>{(HotelDetails.FirstOrDefault()?.TotalAmount ?? 0):N2}</td>
        //                </tr>")}
        //            </tbody>
        //        </table>
        //    </div>
        //    <div class='grand-total-row'>
        //        <span>Grand Total</span>
        //        <span class='amount'>&#8377; {(HotelDetails.FirstOrDefault()?.TotalAmount ?? 0):N2}</span>
        //    </div>



        //    <!-- POLICIES -->
        //    <div style='height:12px;'></div>
        //    <hr style='border:none;border-top:1px solid #ebebeb;margin:0 28px;'/>
        //    <div class='policies-row'>
        //        <div class='policy-col'>
        //            <div class='policy-title'>&#127774; Cancellation Policy</div>
        //            <div class='policy-text'>
        //                100% refund if cancelled before 20 days of arrival. 50% refund if cancelled 10–20 days prior. No refund if cancelled less than 10 days prior. Peak season bookings may have non-refundable terms.
        //            </div>
        //        </div>
        //        <div class='policy-col'>
        //            <div class='policy-title'>&#127970; Hotel Policy</div>
        //            <div class='policy-text'>
        //                A valid government-issued photo ID is required for all guests at check-in. The primary guest must be 18 years or older. Early check-in or late check-out is subject to availability.
        //            </div>
        //        </div>
        //    </div>



        //    <!-- AALPINE LOGO AT BOTTOM -->
        //    <div class='aalpine-logo-section'>
        //        <div class='powered-by'>Powered by</div>
        //        {logoImgHtml}
        //    </div>

        //    <!-- FOOTER BAR -->
        //    <div class='footer-bar'>
        //        <div class='footer-bar-left'>
        //            <div class='brand-footer'>AALPINE HOLIDAYS</div>
        //            <div class='brand-sub'>&copy; {DateTime.Now.Year} Aalpine Holidays. All rights reserved. Professional Travel Services.</div>
        //        </div>
        //        <div class='footer-bar-right'>
        //            <div class='footer-links'>
        //                <span>Contact Support</span>
        //            </div>
        //            <div class='footer-help'>Need Help? +91 9898 034 096</div>
        //        </div>
        //    </div>

        //</div>
        //</body>
        //</html>";
        //                    // ==================== PDF ====================

        //                    try
        //                    {
        //                        var browserFetcher = new BrowserFetcher();

        //                        await browserFetcher.DownloadAsync();

        //                        var launchOptions = new LaunchOptions
        //                        {
        //                            Headless = true,
        //                            Args = new[]
        //                            {
        //                        "--no-sandbox",
        //                        "--disable-setuid-sandbox"
        //                    }
        //                        };

        //                        await using var browser =
        //                            await Puppeteer.LaunchAsync(launchOptions);

        //                        await using var page =
        //                            await browser.NewPageAsync();

        //                        await page.SetContentAsync(pdfHtml);

        //                        byte[] pdfBytes =
        //                            await page.PdfDataAsync(new PdfOptions
        //                            {
        //                                Format = PaperFormat.A4,
        //                                PrintBackground = true,
        //                                MarginOptions = new MarginOptions
        //                                {
        //                                    Top = "30px",
        //                                    Bottom = "30px",
        //                                    Left = "25px",
        //                                    Right = "25px"
        //                                }
        //                            });

        //                        return new PDFDownloadResponse
        //                        {
        //                            PDFBytes = pdfBytes,
        //                            BookingNo = bookingNo
        //                        };
        //                    }
        //                    catch (Exception pdfEx)
        //                    {
        //                        logger.LogError(
        //                            pdfEx,
        //                            "PDF generation failed for BookingNo {BookingNo}",
        //                            bookingNo
        //                        );

        //                        return null;
        //                    }
        //                }
        //                catch (Exception ex)
        //                {
        //                    logger.LogError(ex, ex.Message);
        //                    return null;
        //                }
        //            }
        //            catch (Exception ex)
        //            {
        //                logger.LogError(ex, ex.Message);
        //                throw;
        //            }
        //        }
        #endregion

        #region InsertEasebuzzPaymentData
        /// <summary>
        /// Inserts Easebuzz payment response data into database (used after payment verification)
        /// </summary>
//        public async Task<ResultModel> InsertEasebuzzPaymentData(EasebuzzPaymentEntity entity, string storedProcedure)
//        {
//            ResultModel result = new ResultModel();
//            try
//            {
//                Dapper.DefaultTypeMap.MatchNamesWithUnderscores = true;
//                DynamicParameters dynamicParameters = new DynamicParameters();

//                // Basic transaction details
//                dynamicParameters.Add("@key", entity.Key);
//                dynamicParameters.Add("@txnid", entity.Txnid);
//                dynamicParameters.Add("@amount", entity.Amount);
//                dynamicParameters.Add("@status", entity.Status);
//                dynamicParameters.Add("@error", entity.Error);
//                dynamicParameters.Add("@error_message", entity.ErrorMessage);
//                dynamicParameters.Add("@addedon", entity.Addedon);
//                dynamicParameters.Add("@easepayid", entity.Easepayid);
//                dynamicParameters.Add("@bank_ref_num", entity.BankRefNum);
//                dynamicParameters.Add("@auth_code", entity.AuthCode);
//                dynamicParameters.Add("@auth_ref_num", entity.AuthRefNum);

//                // Customer & Product Info
//                dynamicParameters.Add("@firstname", entity.Firstname);
//                dynamicParameters.Add("@email", entity.Email);
//                dynamicParameters.Add("@phone", entity.Phone);
//                dynamicParameters.Add("@productinfo", entity.Productinfo);

//                // Bank & Payment Method Details
//                dynamicParameters.Add("@bank_name", entity.BankName);
//                dynamicParameters.Add("@bankcode", entity.Bankcode);
//                dynamicParameters.Add("@cardnum", entity.Cardnum);
//                dynamicParameters.Add("@card_type", entity.CardType);
//                dynamicParameters.Add("@card_category", entity.CardCategory);
//                dynamicParameters.Add("@name_on_card", entity.NameOnCard);
//                dynamicParameters.Add("@issuing_bank", entity.IssuingBank);
//                dynamicParameters.Add("@payment_HotelBookingrce", entity.PaymentHotelBookingrce);
//                dynamicParameters.Add("@payment_category", entity.PaymentCategory);
//                dynamicParameters.Add("@mode", entity.Mode);
//                dynamicParameters.Add("@pg_type", entity.PgType);
//                dynamicParameters.Add("@upi_va", entity.UpiVa);

//                // Charges & Settlement
//                dynamicParameters.Add("@service_tax", entity.ServiceTax);
//                dynamicParameters.Add("@service_charge", entity.ServiceCharge);
//                dynamicParameters.Add("@net_amount_debit", entity.NetAmountDebit);
//                dynamicParameters.Add("@settlement_amount", entity.SettlementAmount);
//                dynamicParameters.Add("@discount_amount", entity.DiscountAmount);
//                dynamicParameters.Add("@discount_code", entity.DiscountCode);

//                // Cashback & Deduction
//                dynamicParameters.Add("@cash_back_percentage", entity.CashBackPercentage);
//                dynamicParameters.Add("@deduction_percentage", entity.DeductionPercentage);

//                // Redirect & Additional Info
//                dynamicParameters.Add("@furl", entity.Furl);
//                dynamicParameters.Add("@surl", entity.Surl);
//                dynamicParameters.Add("@hash", entity.Hash);
//                dynamicParameters.Add("@merchant_logo", entity.MerchantLogo);

//                // UDF Fields
//                dynamicParameters.Add("@udf1", entity.Udf1);
//                dynamicParameters.Add("@udf2", entity.Udf2);
//                dynamicParameters.Add("@udf3", entity.Udf3);
//                dynamicParameters.Add("@udf4", entity.Udf4);
//                dynamicParameters.Add("@udf5", entity.Udf5);
//                dynamicParameters.Add("@udf6", entity.Udf6);
//                dynamicParameters.Add("@udf7", entity.Udf7);
//                dynamicParameters.Add("@udf8", entity.Udf8);
//                dynamicParameters.Add("@udf9", entity.Udf9);
//                dynamicParameters.Add("@udf10", entity.Udf10);
//                dynamicParameters.Add("@IsWebhook", entity.IsWebhook);

//                // Cancellation
//                dynamicParameters.Add("@cancellation_reason", entity.CancellationReason);

//                dynamicParameters.Add("@operationtype", CommonRepositoryConstants.Insert);

//                var data = await _dbConnection.QueryAsync(storedProcedure, dynamicParameters, commandType: CommandType.StoredProcedure);
                
//                var firstResult = data.FirstOrDefault();

//                result.Message = firstResult?.Message;
//                result.Details = firstResult?.Details;

//                // ====================== EMAIL CONDITION ======================
//                int isBookingCreated = firstResult?.IsBookingCreated ?? 0;

//                if (entity.IsWebhook && isBookingCreated == 1)
//                {
//                    // ====================== EMAIL + PDF LOGIC ======================
//                    _ = Task.Run(async () =>
//                    {
//                        try
//                        {
//                            // GET FULL BOOKING DATA AGAIN
//                            DynamicParameters bookingParams = new DynamicParameters();
//                            bookingParams.Add("@TempID", entity.Udf1);
//                            bookingParams.Add("@OperationType", 1);

//                            var multi = await _dbConnection.QueryMultipleAsync(
//                                "sp_InsertBooking",
//                                bookingParams,
//                                commandType: CommandType.StoredProcedure);

//                            var booking = await multi.ReadFirstOrDefaultAsync<BookingViewInsertEntity>();
//                            var TicketView = (await multi.ReadAsync<BookingTicketViewEntity>()).ToList();
//                            var PaxList = (await multi.ReadAsync<BookingTicketPaxViewEntity>()).ToList();
//                            var HotelDetails = (await multi.ReadAsync<BookingHotelDetailsViewEntity>()).ToList();

//                            foreach (var ticket in TicketView)
//                            {
//                                ticket.PaxList = PaxList
//                                    .Where(p => p.BookingTicketID == ticket.ID)
//                                    .ToList();
//                            }

//                            booking.TicketView = TicketView;
//                            booking.HotelDetails = HotelDetails;

//                            if (booking.Message?.Trim().ToLower() == "success"
//                                && !string.IsNullOrWhiteSpace(booking.EmailID))
//                            {
//                                string companyName = "HotelBooking";
//                                string fullName = $"{booking.FirstName} {booking.LastName}".Trim();
//                                string bookingNo = booking.BookingNo ?? "N/A";
//                                string pnr = booking.PNR ?? "N/A";
//                                string customerEmail = booking.EmailID;
//                                string adminEmail = booking.AdminMail;
//                                decimal finalPrice = booking.FinalPrice ?? 0;

//                                // ==================== YOUR EXISTING PDF + EMAIL CODE ====================

//                                string logoImgHtml = "<span style='color:white; font-size:28px; font-weight:bold;'>HotelBooking</span>";
//                                try
//                                {
//                                    string logoPath = "https://aalpine.in/images/aalpine%20logo%20header.png";
//                                    byte[] imageBytes;
//                                    using (var httpClient = new HttpClient { Timeout = TimeSpan.FromSeconds(8) })
//                                    {
//                                        imageBytes = await httpClient.GetByteArrayAsync(logoPath);
//                                    }
//                                    string base64 = Convert.ToBase64String(imageBytes);
//                                    string mime = GetMimeType(logoPath);
//                                    logoImgHtml = $"<img src='data:{mime};base64,{base64}' alt='Chasmawale Logo' style='max-width:180px; height:auto; display:block; margin:auto;' />";
//                                }
//                                catch { }


//                                // ====================== Determine Booking Type ======================
//                                bool hasTickets = TicketView?.Any() == true;
//                                bool hasHotel = HotelDetails?.Any() == true;

//                                string ticketName = TicketView?.FirstOrDefault()?.HotelBookingTicketName ?? "";
//                                string hotelName = HotelDetails?.FirstOrDefault()?.HotelName ?? "Statue of Unity - Unity Village Resort";

//                                // Dynamic Subject
//                                string customerSubject = "";

//                                if (hasTickets && !hasHotel)
//                                {
//                                    customerSubject = $"{pnr} || CONFIRM BOOKING || {ticketName} || {fullName}";
//                                }
//                                else if (hasHotel && !hasTickets)
//                                {
//                                    customerSubject = $"{pnr} || CONFIRM BOOKING || {hotelName} || {fullName}";
//                                }
//                                else // Both
//                                {
//                                    customerSubject = $"{pnr} || CONFIRM BOOKING || {fullName}";
//                                }

//                                string customerHtml = $@"
//<!DOCTYPE html>
//<html lang='en'>
//<head>
//    <meta charset='UTF-8'>
//    <meta name='viewport' content='width=device-width, initial-scale=1.0'>
//    <title>Booking Confirmed - PNR: {pnr}</title>
//    <style>
//        body {{ margin:0; padding:0; background:#f3f4f6; font-family: 'Segoe UI', Arial, sans-serif; color:#1f2937; }}
//        .wrapper {{ max-width:680px; margin:30px auto; background:#ffffff; border-radius:12px; overflow:hidden; box-shadow:0 6px 25px rgba(0,0,0,0.1); }}
//        .header {{ background:#0f172a; padding:32px 25px; text-align:center; color:#ffffff; }}
//        .content {{ padding:32px 28px; font-size:15.2px; line-height:1.7; }}
//        .section-title {{ font-size:17px; font-weight:600; margin:26px 0 12px; color:#0f172a; border-left:5px solid #2563eb; padding-left:14px; }}
//        table {{ width:100%; border-collapse:collapse; background:#f9fafb; border-radius:8px; overflow:hidden; }}
//        td, th {{ padding:13px 16px; border-bottom:1px solid #e5e7eb; text-align:left; }}
//        .label {{ color:#6b7280; font-weight:500; width:38%; }}
//        .value {{ font-weight:600; }}
//        .amount {{ color:#2563eb; font-weight:700; text-align:right; }}
//        .highlight {{ background:#fefce8; padding:18px; border-radius:8px; margin:18px 0; line-height:1.85; }}
//        .guest-table th {{ background:#e0f2fe; }}
//        .guest-table td, .guest-table th {{ padding:11px 14px; }}
//        .footer {{ background:#f1f5f9; text-align:center; padding:22px; font-size:13px; color:#6b7280; }}
//    </style>
//</head>
//<body>
//    <div class='wrapper'>
//        <div class='header'>
//            <h1>{(hasTickets ? "Activity Booking Confirmed" : "Hotel Booking Confirmed")}</h1>
//            <p>Greetings from Statue of Unity</p>
//        </div>
      
//        <div class='content'>
//            <p>Dear <strong>{fullName}</strong>,</p>
//            <p>Thank you for your booking with us.</p>

//            <!-- Booking Details (Common) -->
//            <div class='section-title'>Booking Details</div>
//            <table>
//                <tr><td class='label'>PNR No</td><td class='value'><strong>{pnr}</strong></td></tr>
//                <tr><td class='label'>Booking No</td><td class='value'>{booking.BookingNo}</td></tr>
//                <tr><td class='label'>Transaction ID</td><td>{booking.TransactionID ?? booking.PaymentID}</td></tr>
//                <tr><td class='label'>Booking Date</td><td>{booking.CreatedOn?.ToString("dd MMM yyyy") ?? DateTime.Now.ToString("dd MMM yyyy")}</td></tr>
//                {(hasTickets ? $"<tr><td class='label'>Travel Date</td><td>{booking.TicketDate?.ToString("dd MMM yyyy")}</td></tr>" : "")}
//                <tr>
//    <td class='label'>Total Amount Paid</td>
//    <td class='value' style='color:#2563eb; font-weight:700;'>&#8377; {finalPrice:N0}</td>
//</tr>

//            </table>";

//                                // ==================== TICKET SECTION (Multiple Tickets) ====================
//                                if (hasTickets)
//                                {
//                                    customerHtml += @"
//            <!-- Package Details - Multiple Tickets -->";

//                                    foreach (var ticket in TicketView)
//                                    {
//                                        customerHtml += $@"
//            <div class='section-title'>Ticket Details : {ticket.HotelBookingTicketName}</div>
//            <table style='margin-bottom: 20px;'>
//                <tr><td class='label'>Ticket Name</td><td><strong>{ticket.HotelBookingTicketName}</strong></td></tr>";

//                                        // Only show Viewing Gallery if it has value
//                                        if (!string.IsNullOrWhiteSpace(ticket.TimeSlotName))
//                                        {
//                                            customerHtml += $@"
//                <tr><td class='label'>Viewing Gallery</td><td>{ticket.TimeSlotName}</td></tr>";
//                                        }

//                                        // Only show Projection Mapping if it has value
//                                        if (!string.IsNullOrWhiteSpace(ticket.ProjectionMappingTitle))
//                                        {
//                                            customerHtml += $@"
//                <tr><td class='label'>Projection Mapping</td><td>{ticket.ProjectionMappingTitle}</td></tr>";
//                                        }

//                                        customerHtml += $@"
//                <tr><td class='label'>No. of Tickets</td><td>{ticket.NoOfTicket ?? 1}</td></tr>
//                <tr><td class='label'>Total Price</td><td>&#8377; {ticket.TotalPrice:N0}</td></tr>
//            </table>";
//                                    }
//                                }

//                                // ==================== HOTEL SECTION ====================
//                                if (hasHotel)
//                                {
//                                    var hotel = HotelDetails.FirstOrDefault();
//                                    customerHtml += $@"
//            <!-- Hotel Details -->
//            <div class='section-title'>Hotel Booking Details</div>
//            <table>
//                <tr><td class='label'>Hotel Name</td><td><strong>{hotel.HotelName}</strong></td></tr>
//                <tr><td class='label'>Room Category</td><td>{hotel.RoomCategoryName}</td></tr>
//                <tr><td class='label'>Meal Plan</td><td>[{HotelDetails.FirstOrDefault()?.MealPlanName}] - {HotelDetails.FirstOrDefault()?.MealPlanDescription}</td></tr>
//                <tr><td class='label'>Check-In</td><td>{(DateTime.TryParse(hotel.CheckIn, out var cin) ? cin.ToString("dd MMM yyyy") : hotel.CheckIn)} (12:00 PM)</td></tr>
//                <tr><td class='label'>Check-Out</td><td>{(DateTime.TryParse(hotel.CheckOut, out var cout) ? cout.ToString("dd MMM yyyy") : hotel.CheckOut)} (10:00 AM)</td></tr>
//                <tr><td class='label'>No. of Nights</td><td>{hotel.Night}</td></tr>
//                <tr><td class='label'>No. of Rooms</td><td>{hotel.Rooms}</td></tr>
//                <tr><td class='label'>Adults</td><td>{hotel.Adults}</td></tr>
//                <tr><td class='label'>Children</td><td>{hotel.Child}</td></tr>
//                <tr><td class='label'>Extra Adult</td><td>{hotel.ExtraAdult}</td></tr>
//<tr><td class='label'>Total Amount</td><td>{hotel.TotalAmount}</td></tr>
//            </table>";
//                                }

//                                customerHtml += $@"
//            <p>We look forward to welcoming you at the Statue of Unity.</p>
//            <p>Warm regards,<br>
//            <strong>Aalpine Holiday</strong><br>
//            </p>
//        </div>
//        <div class='footer'>
//            © {DateTime.Now.Year} Statue of Unity | Aalpine Holiday Nagari India Pvt. Ltd.<br>
//            For assistance: booking@aalpine.in | +91 98980 34096
//        </div>
//    </div>
//</body>
//</html>";

//                                // ==================== Hotel Logo ====================
//                                string hotelLogoHtml = "";

//                                try
//                                {
//                                    string hotelLogoPath = HotelDetails?.FirstOrDefault()?.HotelLogo;

//                                    if (!string.IsNullOrWhiteSpace(hotelLogoPath))
//                                    {
//                                        byte[] hotelLogoBytes;

//                                        using (var httpClient = new HttpClient { Timeout = TimeSpan.FromSeconds(8) })
//                                        {
//                                            hotelLogoBytes = await httpClient.GetByteArrayAsync(hotelLogoPath);
//                                        }

//                                        string hotelLogoBase64 = Convert.ToBase64String(hotelLogoBytes);
//                                        string hotelMime = GetMimeType(hotelLogoPath);

//                                        hotelLogoHtml = $@"
//<img src='data:{hotelMime};base64,{hotelLogoBase64}' 
//     alt='Hotel Logo' 
//     style='max-width:90px; max-height:90px; object-fit:contain;' />";
//                                    }
//                                }
//                                catch
//                                {
//                                    hotelLogoHtml = "";
//                                }

//                                string pdfHtml = $@"
//<!DOCTYPE html>
//<html>
//<head>
//    <meta charset='UTF-8'>
//    <title>Booking Voucher - {bookingNo}</title>
//    <style>
//        body {{ 
//            font-family: Arial, sans-serif; 
//            font-size: 13px; 
//            margin: 0; 
//            padding: 20px; 
//            background: #fff; 
//        }}
//        .voucher {{ 
//            max-width: 820px; 
//            margin: 0 auto; 
//            border: 2px solid #c8a951; 
//            border-radius: 6px; 
//            overflow: hidden;
//        }}

//       /* HEADER */
//    .header {{display: table;
//    width: 100%;
//    padding: 12px 20px;
//    border-bottom: 2px solid #c8a951;
//    box-sizing: border-box;
//}}

//.header-left,
//.header-center,
//.header-right {{display: table-cell;
//    vertical-align: middle;
//}}

///* LEFT SECTION */
//.header-left {{width: 32%;
//    text-align: left;
//    padding-left: 10px;
//    vertical-align: top;
//}}

//.hotel-logo img {{max - width: 100px;
//    max-height: 100px;
//    object-fit: contain;
//}}

//.property-label {{margin - top: 6px;
//    margin-left: -15px;
//    font-size: 14px;
//    font-weight: bold;
//    color: #333;
//    white-space: nowrap;
//}}

///* CENTER SECTION */
//.header-center {{width: 38%;
//    text-align: center;
//}}

//.center-logo img {{max - width: 220px;
//    max-height: 90px;
//    object-fit: contain;
//}}

///* RIGHT SECTION */
//.header-right {{width: 30%;
//    text-align: right;
//    font-size: 12px;
//    color: #333;
//    line-height: 1.8;
//    padding-right: 10px;
//}}
// .pnr-bar {{
//            background: #c8a951;
//            color: white;
//            display: flex;
//            justify-content: space-between;
//            align-items: center;
//            padding: 8px 20px;
//            font-weight: bold;
//            font-size: 15px;
//        }}
         

//        /* GUEST NAME */
//        .guest-name {{
//            background: #f5f0e8;
//            padding: 14px 20px;
//            border-bottom: 1px solid #e0c97a;
//        }}
//        .guest-name h2 {{
//            margin: 0 0 4px 0;
//            font-size: 20px;
//            color: #333;
//        }}
//        .guest-name p {{
//            margin: 0;
//            font-size: 12px;
//            color: #555;
//        }}

//        /* SECTIONS */
//        .section-title {{
//            background: #f5f0e8;
//            padding: 10px 20px;
//            font-size: 16px;
//            font-weight: bold;
//            color: #333;
//            border-bottom: 1px solid #e0c97a;
//            border-top: 1px solid #e0c97a;
//        }}

//        /* TABLE */
//        table {{
//            width: 100%;
//            border-collapse: collapse;
//        }}
//        .detail-table td {{
//            padding: 9px 20px;
//            border-bottom: 1px solid #f0e8d0;
//            font-size: 13px;
//            color: #333;
//        }}
//        .detail-table td:first-child {{
//            font-weight: bold;
//            width: 200px;
//            color: #555;
//        }}

//        /* GRID for guest details */
//        .two-col-table {{
//            width: 100%;
//            border-collapse: collapse;
//        }}
//        .two-col-table td {{
//            padding: 9px 20px;
//            border-bottom: 1px solid #f0e8d0;
//            font-size: 13px;
//            color: #333;
//            width: 25%;
//        }}
//        .two-col-table td.label {{
//            font-weight: bold;
//            color: #555;
//        }}

//        /* ROOM STATS */
//        .room-grid {{
//            display: grid;
//            grid-template-columns: 1fr 1fr 1fr 1fr;
//            border-bottom: 1px solid #f0e8d0;
//        }}
//        .room-cell {{
//            padding: 12px 20px;
//            border-right: 1px solid #f0e8d0;
//            text-align: center;
//        }}
//        .room-cell:last-child {{ border-right: none; }}
//        .room-cell .val {{
//            font-size: 28px;
//            font-weight: bold;
//            color: #c8a951;
//        }}
//        .room-cell .lbl {{
//            font-size: 11px;
//            color: #777;
//            margin-top: 2px;
//        }}

//        /* TOTAL ROW */
//        .total-row {{
//            background: #c8a951;
//            color: white;
//            font-size: 17px;
//            font-weight: bold;
//            padding: 12px 20px;
//            display: flex;
//            justify-content: space-between;
//        }}

//        /* POLICY */
//        .policy-body {{
//            padding: 14px 20px;
//            border-bottom: 1px solid #e0c97a;
//        }}
//        .policy-body ol {{
//            margin: 0;
//            padding-left: 18px;
//            line-height: 2;
//            font-size: 13px;
//            color: #444;
//        }}
//        .policy-note {{
//            font-style: italic;
//            font-size: 12px;
//            color: #555;
//            padding: 10px 20px;
//            border-bottom: 1px solid #e0c97a;
//        }}

//        /* FOOTER */
//        .footer {{
//            background: #f9f6f0;
//            display: flex;
//            justify-content: space-between;
//            padding: 14px 20px;
//            font-size: 12px;
//            color: #444;
//            line-height: 1.7;
//            border-top: 1px solid #e0c97a;
//        }}
//        .footer strong {{ display: block; color: #222; font-size: 13px; }}
//        .footer-thanks {{
//            text-align: center;
//            padding: 10px;
//            font-size: 12px;
//            color: #888;
//            background: #fff;
//        }}
//    </style>
//</head>
//<body>
//<div class='voucher'>

//  <!-- HEADER -->
//<div class='header'>

//    <!-- LEFT : HOTEL LOGO -->
//    <div class='header-left'>
//        <div class='hotel-logo'>
//            {hotelLogoHtml}
//        </div>
// <div class='property-label'>
//        {HotelDetails.FirstOrDefault()?.HotelName ?? "N/A"}
//    </div>
//    </div>

//    <!-- CENTER : AALPINE LOGO -->
//    <div class='header-center'>
//        <div class='center-logo'>
//            {logoImgHtml}
//        </div>
//    </div>

//    <!-- RIGHT : CONTACT -->
//    <div class='header-right'>
//        <strong>+91 9898 034 096</strong><br>
//        booking@aalpine.in<br>
//        www.aalpine.in
//    </div>
 
//</div>
 
   

//        <!-- PNR BAR -->
//    <div class='pnr-bar'>
//        <span>PNR: {pnr}</span>
//        <span>Booking Voucher</span>
//    </div>


//    <!-- GUEST NAME -->
//    <div class='guest-name'>
//        <h3>Dear : {fullName}</h3>
//        <p>It is mandatory to produce this voucher along with a valid photo ID at the time of check-in</p>
//    </div>

//    <!-- GUEST DETAILS -->
//    <div class='section-title'>Guest Details</div>
//    <table class='two-col-table'>
// <tr>
//            <td class='label'>Name :</td>
//            <td>{fullName}</td>
//            <td class='label'>Mobile No :</td>
//            <td>{booking.MobileNo ?? "N/A"}</td>
//        </tr>
//        <tr>
//            <td class='label'>Check In Date :</td>
//            <td>{HotelDetails.FirstOrDefault()?.CheckIn}</td>
//            <td class='label'>Check Out Date :</td>
//            <td>{HotelDetails.FirstOrDefault()?.CheckOut}</td>
//        </tr>
     
//        <tr>
//            <td class='label'>Booking Date :</td>
//            <td>{DateTime.Now:dd MMM yyyy HH:mm}</td>
//            <td class='label'>WhatsApp MobileNo :</td>
//            <td>{booking.WhatsAppMobileNo ?? "N/A"}</td>
//        </tr>
 


//        <tr>
//            <td class='label'>Room Category :</td>
//            <td>{HotelDetails.FirstOrDefault()?.RoomCategoryName}</td>
//            <td class='label'>Meal Plan :</td>
//            <td>[{HotelDetails.FirstOrDefault()?.MealPlanName}] - {HotelDetails.FirstOrDefault()?.MealPlanDescription}</td>
//        </tr>
//        <tr>
//            <td class='label'>Email :</td>
//            <td colspan='3'>{booking.EmailID}</td>
//        </tr>
//    </table>

//    <!-- ROOM DETAILS -->
//    <div class='section-title'>Room Details</div>
//    <div class='room-grid'>
//        <div class='room-cell'>
//            <div class='val'>{HotelDetails.FirstOrDefault()?.Rooms}</div>
//            <div class='lbl'>Total Room</div>
//        </div>
//        <div class='room-cell'>
//            <div class='val'>{HotelDetails.FirstOrDefault()?.Adults}</div>
//            <div class='lbl'>Adult</div>
//        </div>


//            <div class='lbl'>Child</div>
//        </div>
//        <div class='room-cell'>
//            <div class='val'>{(HotelDetails.FirstOrDefault()?.Adults ?? 0) + (HotelDetails.FirstOrDefault()?.Child ?? 0)}</div>
//            <div class='lbl'>Total Person</div>
//        </div>
//    </div>

//    <!-- PRICE -->
    
//   {(booking.HotelBookingPackageID == null || booking.HotelBookingPackageID == 0 ? $@"
//    <div class='total-row'>
//        <span>Total Amount :</span>
//        <span>&#8377; {HotelDetails.FirstOrDefault()?.TotalAmount:N0}/-</span>
//    </div>" : "")}

//    <!-- CANCELLATION POLICY -->
//    <div class='section-title'>Cancellation Policy</div>
//    <div class='policy-body'>
//        <ol>
//            <li>100% refund if cancelled before 20 days of scheduled arrival date.</li>
//            <li>50% refund if cancelled more than or equal to 10 days prior to scheduled arrival date but less than 20 days prior to scheduled arrival date.</li>
//            <li>No refund if cancelled less than 10 days prior to scheduled arrival date.</li>
//            <li>Change in guest/guests names would be treated as Cancellation.</li>
//            <li>In case of any date change Rs.1500/Per Tent + 18% GST will be charged. (Rate difference shall be levied)</li>
//            <li>Rates are exclusive of applicable taxes.</li>
//            <li>GST shall be charged as per applicable.</li>
//            <li>In case of triple occupancy, any person above 6 yrs. of age will be charged as an extra person (with mattress).</li>
//        </ol>
//    </div>
//    <div class='policy-note'>** Note: Organiser reserves all rights to make any changes without prior notice.</div>

//    <!-- FOOTER -->
//    <div class='footer'>
//        <div>
//            <strong>Aalpine Holiday Nagari India Pvt. Ltd.</strong>
//            Reservation Office<br>
//            B-701/702, PNTC, Radio Mirchi Road,<br>
//            Satellite, Ahmedabad.
//        </div>
//        <div style='text-align:right;'>
//            <strong>{HotelDetails.FirstOrDefault()?.HotelName ?? "N/A"}</strong>
//            Site Address<br>
//            {HotelDetails.FirstOrDefault()?.HotelAddress ?? "N/A"}
//        </div>
//    </div>
//    <div class='footer-thanks'>Thank you for choosing {HotelDetails.FirstOrDefault()?.HotelName ?? "N/A"}</div>

//</div>
//</body>
//</html>";

//                                // Generate PDF
//                                var browserFetcher = new BrowserFetcher();
//                                await browserFetcher.DownloadAsync();
//                                await using var browser = await Puppeteer.LaunchAsync(new LaunchOptions { Headless = true });
//                                await using var page = await browser.NewPageAsync();
//                                await page.SetContentAsync(pdfHtml, new NavigationOptions { WaitUntil = new[] { WaitUntilNavigation.Networkidle0 } });

//                                byte[] pdfBytes = await page.PdfDataAsync(new PdfOptions
//                                {
//                                    Format = PuppeteerSharp.Media.PaperFormat.A4,
//                                    PrintBackground = true,
//                                    MarginOptions = new PuppeteerSharp.Media.MarginOptions { Top = "20px", Bottom = "30px", Left = "20px", Right = "20px" }
//                                });

//                                string filename = $"Booking_{bookingNo}_{DateTime.Now.Ticks}.pdf";
//                                string pdfFilePath = CommonRepositoryConstants.ImageFilePath;
//                                if (!Directory.Exists(pdfFilePath)) Directory.CreateDirectory(pdfFilePath);

//                                string physicalFileFullPath = Path.Combine(pdfFilePath, filename);
//                                await File.WriteAllBytesAsync(physicalFileFullPath, pdfBytes);

//                                var sendEmail = new HotelBooking.Entity.Common.Methods.SendEmail();

//                                sendEmail.MailSendSMTP(
//                                    customerEmail,
//                                    "",
//                                    customerSubject,
//                                    customerHtml,
//                                    HotelDetails?.Any() == true ? physicalFileFullPath : ""
//                                );

//                                if (!string.IsNullOrWhiteSpace(adminEmail))
//                                {
//                                    string adminHtml = customerHtml.Replace(
//                                        "Booking Confirmed",
//                                        "New Booking Received"
//                                    );

//                                    sendEmail.MailSendSMTP(
//                                        adminEmail,
//                                        "",
//                                        customerSubject,
//                                        adminHtml,
//                                        HotelDetails?.Any() == true ? physicalFileFullPath : ""
//                                    );
//                                }
//                            }
//                        }
//                        catch (Exception emailEx)
//                        {
//                            // LOG ERROR
//                        }
//                    });
//                }
//                result.Message = data.FirstOrDefault()?.Message;
//                result.Details = data.FirstOrDefault()?.Details;
//            }
//            catch (SqlException sqlException)
//            {
//                result.ErrorMessage = sqlException.Message;
//                result.Status = (int)ResponseStatusCode.InternaServerError;
//                result.Message = CommonRepositoryMessages.CannotFindAllMessage;
//                result.Details = CommonRepositoryMessages.CannotFindAllDetails;
//            }
//            catch (Exception ex)
//            {
//                result.Status = (int)ResponseStatusCode.InternaServerError;
//                result.Message = CommonRepositoryMessages.ExceptionMessage;
//                result.ErrorMessage = ex.Message;
//            }

//            return result;
//        }
        #endregion

    }
}
