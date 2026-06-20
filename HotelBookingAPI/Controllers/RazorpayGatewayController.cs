using HotelBooking.Controllers;
using HotelBooking.DataAccess.Base;
using HotelBooking.Domain.Interfaces;
using HotelBooking.Entity.Common;
using HotelBooking.Entity.Common.Entities;
using HotelBooking.Entity.Common.Enums;
using HotelBooking.Entity.Entities;
using AutoMapper;
using Dapper;
using DocumentFormat.OpenXml.VariantTypes;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Org.BouncyCastle.Asn1.Ocsp;
using Razorpay.Api;
using System.Data;
using System.Data.SqlClient;
using System.Net;
using System.Net.Http;
using System.Numerics;
using System.Security.Cryptography;
using System.Text;

namespace HotelBooking.Controllers
{
    /// <summary>
    /// Added by NikunjK on 01-08-2023
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class RazorpayGatewayController : ControllerBase
    {
        private readonly IUserTypeDomain domain;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly BookingLookupRepository _webBookingLookupRepository;
        private readonly IHttpClientFactory _httpClientFactory;

        public RazorpayGatewayController(IHttpClientFactory httpClientFactory, ILogger<UserTypeController> _logger, IUserTypeDomain _UserTypeDomain, BookingLookupRepository webBookingLookupRepository)
        {
            _httpClientFactory = httpClientFactory;
            domain = _UserTypeDomain;
            _webBookingLookupRepository = webBookingLookupRepository;

        }

        #region Insert UserType

        [HttpPost("CreateOrder")]
        // [Authorize]
        public async Task<IActionResult> CreateOrder(PaymentRequest entity)
        {
            try
            {
                string razorpayID = CommonRepositoryConstants.RazorpayKeyId;
                string razorSecretKey = CommonRepositoryConstants.RazorpaySecretKey;

                RazorpayClient client = new RazorpayClient(razorpayID, razorSecretKey);

                Dictionary<string, object> options = new Dictionary<string, object>();
                options.Add("amount", entity.Amount); // Amount in paise
                options.Add("currency", entity.Currency);

                Order order = client.Order.Create(options);

                PaymentOrderResponse result = new PaymentOrderResponse();
                result.Orderid = order["id"];
                result.Amount = order["amount"];
                result.Currency = order["currency"];

                return StatusCode((int)HttpStatusCode.OK, new ResultModel()
                {
                    Status = (int)ResponseStatusCode.Success,
                    Message = Convert.ToString("Order Generated"),
                    Data = result,
                });


            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, new ResultModel()
                {
                    Message = CommonRepositoryMessages.NotFoundMessageEN,
                    Details = CommonRepositoryMessages.NotFoundMessageEN,
                    ErrorMessage = ex.Message,
                    Status = (int)ResponseStatusCode.InternaServerError,
                });
            }
        }
        #endregion

        [HttpPost("verify")]
        public async Task<IActionResult> VerifyPayment([FromBody] PaymentVerificationRequest request)
        {

            string razorSecretKey = CommonRepositoryConstants.RazorpaySecretKey;
            string razorpayID = CommonRepositoryConstants.RazorpayKeyId;
            // Signature validation
            string payload = $"{request.RazorpayOrderId}|{request.RazorpayPaymentId}";
            string generatedSignature = GenerateSignature(payload, razorSecretKey);

            if (generatedSignature == request.RazorpaySignature)
            {
                RazorpayClient client = new RazorpayClient(razorpayID, razorSecretKey);
                Payment payment = client.Payment.Fetch(request.RazorpayPaymentId);


                if (payment != null && payment.Attributes != null)
                {

                    var paymentDetail = ((Newtonsoft.Json.Linq.JObject)payment.Attributes)
                                             .ToObject<Dictionary<string, object>>();

                    PaymentDataEntity.acquirer_data? acquirer = null;
                    if (paymentDetail.ContainsKey("acquirer_data"))
                    {
                        var acquirerDetails = ((Newtonsoft.Json.Linq.JObject)paymentDetail["acquirer_data"])
                                              .ToObject<Dictionary<string, object>>();
                        acquirer = new PaymentDataEntity.acquirer_data
                        {
                            auth_code = acquirerDetails.GetValueOrDefault("auth_code")?.ToString(),
                            arn = acquirerDetails.GetValueOrDefault("arn")?.ToString(),
                            rrn = acquirerDetails.GetValueOrDefault("rrn")?.ToString(),
                            bank_transaction_id = acquirerDetails.GetValueOrDefault("bank_transaction_id")?.ToString(),
                            transaction_id = acquirerDetails.GetValueOrDefault("transaction_id")?.ToString()
                        };
                    }



                    // Extract card details
                    PaymentDataEntity.card_details? cardDetails = null;
                    if (paymentDetail.ContainsKey("card"))
                    {
                        var cardInfo = ((Newtonsoft.Json.Linq.JObject)paymentDetail["card"])
                                     .ToObject<Dictionary<string, object>>();
                        cardDetails = new PaymentDataEntity.card_details
                        {
                            card_id = cardInfo.GetValueOrDefault("id")?.ToString(),
                            card_name = cardInfo.GetValueOrDefault("name")?.ToString(),
                            last4 = cardInfo.GetValueOrDefault("last4")?.ToString(),
                            network = cardInfo.GetValueOrDefault("network")?.ToString(),
                            card_type = cardInfo.GetValueOrDefault("type")?.ToString(),        // Map 'type' to 'card_type'
                            issuer = cardInfo.GetValueOrDefault("issuer")?.ToString(),
                            card_international = cardInfo.GetValueOrDefault("international") != null
                                               ? Convert.ToBoolean(cardInfo["international"])
                                               : (bool?)null,                        // Map 'international' to 'card_international'
                            card_emi = cardInfo.GetValueOrDefault("emi") != null
                                     ? Convert.ToBoolean(cardInfo["emi"])
                                     : (bool?)null,                                  // Map 'emi' to 'card_emi'
                            card_sub_type = cardInfo.GetValueOrDefault("sub_type")?.ToString() // Map 'sub_type' to 'card_sub_type'
                        };
                    }

                    // Extract UPI details
                    PaymentDataEntity.upi_details? upiDetails = null;
                    if (paymentDetail.ContainsKey("upi"))
                    {
                        var upiInfo = ((Newtonsoft.Json.Linq.JObject)paymentDetail["upi"])
                                    .ToObject<Dictionary<string, object>>();
                        upiDetails = new PaymentDataEntity.upi_details
                        {
                            payer_account_type = upiInfo.GetValueOrDefault("payer_account_type")?.ToString(),
                            vpa = upiInfo.GetValueOrDefault("vpa")?.ToString(),
                            flow = upiInfo.GetValueOrDefault("flow")?.ToString()
                        };
                    }
                    var paymentEntity = new PaymentDataEntity
                    {
                        payment_id = paymentDetail.ContainsKey("id") ? paymentDetail["id"]?.ToString() : null,
                        Entity = paymentDetail.ContainsKey("entity") ? paymentDetail["entity"]?.ToString() : null,
                        Amount = paymentDetail.ContainsKey("amount") ? Convert.ToDecimal(paymentDetail["amount"]) / 100 : (decimal?)null,
                        Currency = paymentDetail.ContainsKey("currency") ? paymentDetail["currency"]?.ToString() : null,
                        Status = paymentDetail.ContainsKey("status") ? paymentDetail["status"]?.ToString() : null,
                        OrderId = paymentDetail.ContainsKey("order_id") ? paymentDetail["order_id"]?.ToString() : null,
                        InvoiceId = paymentDetail.ContainsKey("invoice_id") ? paymentDetail["invoice_id"]?.ToString() : null,
                        International = paymentDetail.ContainsKey("international") ? Convert.ToBoolean(paymentDetail["international"]) : (bool?)null,
                        Method = paymentDetail.ContainsKey("method") ? paymentDetail["method"]?.ToString() : null,
                        AmountRefunded = paymentDetail.ContainsKey("amount_refunded") ? Convert.ToDecimal(paymentDetail["amount_refunded"]) : (decimal?)null,
                        RefundStatus = paymentDetail.ContainsKey("refund_status") ? paymentDetail["refund_status"]?.ToString() : null,
                        Captured = paymentDetail.ContainsKey("captured") ? Convert.ToBoolean(paymentDetail["captured"]) : (bool?)null,
                        Description = paymentDetail.ContainsKey("description") ? paymentDetail["description"]?.ToString() : null,
                        CardId = paymentDetail.ContainsKey("card_id") ? paymentDetail["card_id"]?.ToString() : null,
                        Bank = paymentDetail.ContainsKey("bank") ? paymentDetail["bank"]?.ToString() : null,
                        Wallet = paymentDetail.ContainsKey("wallet") ? paymentDetail["wallet"]?.ToString() : null,
                        Vpa = paymentDetail.ContainsKey("vpa") ? paymentDetail["vpa"]?.ToString() : null,
                        Email = paymentDetail.ContainsKey("email") ? paymentDetail["email"]?.ToString() : null,
                        Contact = paymentDetail.ContainsKey("contact") ? paymentDetail["contact"]?.ToString() : null,
                        Fee = paymentDetail.ContainsKey("fee") ? paymentDetail["fee"]?.ToString() : null,
                        Tax = paymentDetail.ContainsKey("tax") ? paymentDetail["tax"]?.ToString() : null,
                        customer_id = paymentDetail.ContainsKey("customer_id") ? paymentDetail["customer_id"]?.ToString() : null,
                        booking_no = request.booking_no,
                        ErrorCode = paymentDetail.ContainsKey("error_code") ? paymentDetail["error_code"]?.ToString() : null,
                        ErrorDescription = paymentDetail.ContainsKey("error_description") ? paymentDetail["error_description"]?.ToString() : null,
                        ErrorHotelBookingrce = paymentDetail.ContainsKey("error_HotelBookingrce") ? paymentDetail["error_HotelBookingrce"]?.ToString() : null,
                        ErrorStep = paymentDetail.ContainsKey("error_step") ? paymentDetail["error_step"]?.ToString() : null,
                        ErrorReason = paymentDetail.ContainsKey("error_reason") ? paymentDetail["error_reason"]?.ToString() : null,
                        CreatedAt = paymentDetail.ContainsKey("created_at") ? Convert.ToInt32(paymentDetail["created_at"]) : (int?)null,
                        acquirer = acquirer,
                        carddetails = cardDetails,
                        upidetails = upiDetails,
                    };

                    var data = await _webBookingLookupRepository.InsertPaymentData(paymentEntity, "sp_ManageInsertPayment");

                    return StatusCode((int)HttpStatusCode.OK, new ResultModel
                    {
                        Status = (int)ResponseStatusCode.Success,
                        Message = "success",
                        Details = "Payment verified successfully",                      
                    });
                }
            }
            return StatusCode((int)HttpStatusCode.BadRequest, new ResultModel
            {
                Status = (int)ResponseStatusCode.BadRequestError,
                Message = "Payment verification failed",
                Details = "The payment details could not be retrieved.",
                Data = null
            });
        }

        private string GenerateSignature(string payload, string secret)
        {
            var encoding = new ASCIIEncoding();
            byte[] keyByte = encoding.GetBytes(secret);
            byte[] messageBytes = encoding.GetBytes(payload);
            using (var hmacsha256 = new HMACSHA256(keyByte))
            {
                byte[] hashMessage = hmacsha256.ComputeHash(messageBytes);
                return BitConverter.ToString(hashMessage).Replace("-", "").ToLower();
            }
        }



    }



}
