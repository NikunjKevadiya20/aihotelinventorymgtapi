using Dapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using HotelBooking.DataAccess.Base;
using HotelBooking.Entity.Common;
using HotelBooking.Entity.Entities;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;

namespace HotelBooking.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentsController : ControllerBase
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;
        private readonly string _merchantKey;
        private readonly string _salt;
        private readonly string _env;
        private readonly string _easebuzzApiUrl;


        private readonly BookingLookupRepository _webBookingLookupRepository;
        private readonly IDbConnection _dbConnection;

        private readonly string _easebuzzDashboardApiUrl;

        public PaymentsController(HttpClient httpClient, IConfiguration configuration, BookingLookupRepository webBookingLookupRepository, IDbConnection dbConnection)
        {
            _httpClient = httpClient;
            _configuration = configuration;

            _merchantKey = CommonRepositoryConstants.EasebuzzMerchantKey;
            _salt = CommonRepositoryConstants.EasebuzzSalt;
            _env = CommonRepositoryConstants.EasebuzzEnv;


            _webBookingLookupRepository = webBookingLookupRepository;
            _dbConnection = dbConnection;

            _easebuzzApiUrl = _env == "prod"
                ? "https://pay.easebuzz.in"
                : "https://testpay.easebuzz.in";

            _easebuzzDashboardApiUrl = _env == "prod"
        ? "https://dashboard.easebuzz.in"
        : "https://testdashboard.easebuzz.in";
        }


        #region INITIATE PAYMENT

        [HttpPost("Initiate")]
        public async Task<ActionResult<InitiatePaymentResponse>> InitiatePayment(
            [FromBody] InitiatePaymentRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new InitiatePaymentResponse
                {
                    Success = false,
                    Error = "Validation failed."
                });
            }

            try
            {
                // Generate Unique Transaction ID
                string txnid =
                    "TXN" +
                    DateTime.Now.ToString("yyyyMMddHHmmssfff");

                // Format Amount
                string formattedAmount =
                    request.Amount.ToString("0.00");


                // HASH GENERATION
                string hashString =
                            $"{_merchantKey}|{txnid}|{formattedAmount}|{request.ProductInfo}|{request.Firstname}|{request.Email}|{request.TempBookingId}||||||||||{_salt}";

                string hash =
                GenerateHash512(hashString);

                // SUCCESS / FAILURE URL

                string surl =
                    $"{Request.Scheme}://{Request.Host}/api/Payments/Webhook";

                string furl =
                    $"{Request.Scheme}://{Request.Host}/api/Payments/Webhook";


                // REQUEST DATA

                var formData = new Dictionary<string, string>
                {
                    { "key", _merchantKey },
                    { "txnid", txnid },
                    { "amount", formattedAmount },
                    { "productinfo", request.ProductInfo },
                    { "firstname", request.Firstname },
                    { "email", request.Email },
                    { "phone", request.Phone },
                    { "surl", "https://google.com" },
                    { "furl", "https://google.com" },
                    { "hash", hash },
                    { "udf1", request.TempBookingId.ToString()  }
                };
                
                var content =
                    new FormUrlEncodedContent(formData);

                // CALL EASEBUZZ API
               
                var response =
                    await _httpClient.PostAsync(
                        $"{_easebuzzApiUrl}/payment/initiateLink",
                        content);

                var responseString =
                    await response.Content.ReadAsStringAsync();

                // DESERIALIZE RESPONSE

                var easebuzzResponse =
                    JsonSerializer.Deserialize<EasebuzzInitiateRawResponse>(
                        responseString);

                if (easebuzzResponse == null)
                {
                    return BadRequest(new InitiatePaymentResponse
                    {
                        Success = false,
                        Error = "Invalid gateway response."
                    });
                }

                // FAILED RESPONSE

                if (easebuzzResponse.Status != 1)
                {
                    return BadRequest(new InitiatePaymentResponse
                    {
                        Success = false,
                        Error = easebuzzResponse.Data
                    });
                }

                // SUCCESS RESPONSE

                string query = @"
                    UPDATE tblTempBooking
                    SET 
                        TxnID = @TxnID
                    WHERE ID = @TempBookingID";

                await _dbConnection.ExecuteAsync(query, new
                {
                    TxnID = txnid,
                    TempBookingID = request.TempBookingId
                });

                return Ok(new InitiatePaymentResponse
                {
                    Success = true,
                    AccessKey = easebuzzResponse.Data,
                    TxnId = txnid,
                    MerchantKey = _merchantKey,
                    Env = _env,
                    Hash = hash
                });


            }
            catch (Exception ex)
            {
                return StatusCode(500,
                    new InitiatePaymentResponse
                    {
                        Success = false,
                        Error = ex.Message
                    });
            }
        }
        #endregion

        #region VERIFY PAYMENT
        [HttpPost("Verify")]
        public async Task<ActionResult<VerifyPaymentResponse>> VerifyPayment([FromBody] VerifyPaymentRequest request)
        {
            try
            {

                // VALIDATION

                if (string.IsNullOrWhiteSpace(request.TxnId))
                {
                    return BadRequest(new VerifyPaymentResponse
                    {
                        Success = false,
                        Error = "Transaction ID is required."
                    });
                }


                // HASH (Must generate lowercase SHA-512 hex)

                string hashString = $"{_merchantKey}|{request.TxnId}|{_salt}";
                string hash = GenerateHash512(hashString);


                // FORM DATA

                var formData = new Dictionary<string, string>
                {
                    { "key", _merchantKey },
                    { "txnid", request.TxnId },
                    { "hash", hash }
                };

                var content = new FormUrlEncodedContent(formData);


                // CALL VERIFY API (Using _easebuzzDashboardApiUrl!)

                var response = await _httpClient.PostAsync(
                    $"{_easebuzzDashboardApiUrl}/transaction/v2/retrieve",
                    content);

                var responseString = await response.Content.ReadAsStringAsync();


                // CHECK EMPTY RESPONSE

                if (string.IsNullOrWhiteSpace(responseString))
                {
                    return BadRequest(new VerifyPaymentResponse
                    {
                        Success = false,
                        Error = "Empty response from payment gateway."
                    });
                }


                // CHECK HTML RESPONSE

                if (responseString.TrimStart().StartsWith("<"))
                {
                    return BadRequest(new VerifyPaymentResponse
                    {
                        Success = false,
                        Error = "Invalid response received from Easebuzz."
                    });
                }


                // PARSE JSON

                using JsonDocument doc = JsonDocument.Parse(responseString);
                var root = doc.RootElement;


                // CHECK STATUS EXISTS

                if (!root.TryGetProperty("status", out JsonElement statusElement))
                {
                    return BadRequest(new VerifyPaymentResponse
                    {
                        Success = false,
                        Error = "Invalid payment response."
                    });
                }

                bool apiSuccess = false;

                // Handle both bool and int status securely
                if (statusElement.ValueKind == JsonValueKind.True ||
                    statusElement.ValueKind == JsonValueKind.False)
                {
                    apiSuccess = statusElement.GetBoolean();
                }
                else if (statusElement.ValueKind == JsonValueKind.Number)
                {
                    apiSuccess = statusElement.GetInt32() == 1;
                }

                if (!apiSuccess)
                {
                    string errorMessage = "";
                    if (root.TryGetProperty("msg", out JsonElement msgError))
                    {
                        errorMessage = msgError.ToString();
                    }

                    return BadRequest(new VerifyPaymentResponse
                    {
                        Success = false,
                        Error = string.IsNullOrWhiteSpace(errorMessage)
                            ? "Payment verification failed."
                            : errorMessage
                    });
                }


                // CHECK MSG NODE

                if (!root.TryGetProperty("msg", out JsonElement msg))
                {
                    return BadRequest(new VerifyPaymentResponse
                    {
                        Success = false,
                        Error = "Transaction details not found."
                    });
                }


                // READ VALUES SAFELY

                string paymentStatus = msg.TryGetProperty("status", out JsonElement paymentStatusElement)
                    ? paymentStatusElement.ToString()
                    : "";

                string amountString = msg.TryGetProperty("amount", out JsonElement amountElement)
                    ? amountElement.ToString()
                    : "0";

                string bookingId = msg.TryGetProperty("udf1", out JsonElement bookingElement)
                    ? bookingElement.ToString()
                    : "";

                decimal amount = 0;
                decimal.TryParse(amountString, out amount);


                // FINAL RESPONSE
                bool isSuccess = paymentStatus.Equals("success", StringComparison.OrdinalIgnoreCase);

                
                var paymentEntity = new EasebuzzPaymentEntity
                    {
                        Key = _merchantKey,
                        Txnid = msg.TryGetProperty("txnid", out JsonElement txnElement)
                                   ? txnElement.ToString() : null,

                        Amount = msg.TryGetProperty("amount", out JsonElement amtElement)
                                 && decimal.TryParse(amtElement.ToString(), out decimal amt) ? amt : 0,

                        Status = paymentStatus,
                        Error = msg.TryGetProperty("error", out JsonElement errElement)
                                ? errElement.ToString() : null,
                        ErrorMessage = msg.TryGetProperty("error_Message", out JsonElement errMsgElement)
                                       ? errMsgElement.ToString() : null,

                        Addedon = msg.TryGetProperty("addedon", out JsonElement addedonElement)
                                  && DateTime.TryParse(addedonElement.ToString(), out DateTime addedonDate)
                                  ? addedonDate : null,

                        Easepayid = msg.TryGetProperty("easepayid", out JsonElement easepayElement)
                                    ? easepayElement.ToString() : null,
                        BankRefNum = msg.TryGetProperty("bank_ref_num", out JsonElement bankRefElement)
                                     ? bankRefElement.ToString() : null,
                        AuthCode = msg.TryGetProperty("auth_code", out JsonElement authCodeElement)
                                   ? authCodeElement.ToString() : null,
                        AuthRefNum = msg.TryGetProperty("auth_ref_num", out JsonElement authRefElement)
                                     ? authRefElement.ToString() : null,

                        Firstname = msg.TryGetProperty("firstname", out JsonElement firstNameElement)
                                    ? firstNameElement.ToString() : null,
                        Email = msg.TryGetProperty("email", out JsonElement emailElement)
                                ? emailElement.ToString() : null,
                        Phone = msg.TryGetProperty("phone", out JsonElement phoneElement)
                                ? phoneElement.ToString() : null,
                        Productinfo = msg.TryGetProperty("productinfo", out JsonElement productElement)
                                      ? productElement.ToString() : null,

                        BankName = msg.TryGetProperty("bank_name", out JsonElement bankNameElement)
                                   ? bankNameElement.ToString() : null,
                        Bankcode = msg.TryGetProperty("bankcode", out JsonElement bankcodeElement)
                                   ? bankcodeElement.ToString() : null,
                        Cardnum = msg.TryGetProperty("cardnum", out JsonElement cardnumElement)
                                  ? cardnumElement.ToString() : null,
                        CardType = msg.TryGetProperty("card_type", out JsonElement cardTypeElement)
                                   ? cardTypeElement.ToString() : null,
                        CardCategory = msg.TryGetProperty("cardCategory", out JsonElement cardCatElement)
                                       ? cardCatElement.ToString() : null,
                        NameOnCard = msg.TryGetProperty("name_on_card", out JsonElement nameOnCardElement)
                                     ? nameOnCardElement.ToString() : null,
                        IssuingBank = msg.TryGetProperty("issuing_bank", out JsonElement issuingBankElement)
                                      ? issuingBankElement.ToString() : null,

                        PaymentHotelBookingrce = msg.TryGetProperty("payment_HotelBookingrce", out JsonElement psElement)
                                        ? psElement.ToString() : null,
                        PaymentCategory = msg.TryGetProperty("payment_category", out JsonElement pcElement)
                                          ? pcElement.ToString() : null,
                        Mode = msg.TryGetProperty("mode", out JsonElement modeElement)
                               ? modeElement.ToString() : null,
                        PgType = msg.TryGetProperty("PG_TYPE", out JsonElement pgElement)
                                 ? pgElement.ToString() : null,
                        UpiVa = msg.TryGetProperty("upi_va", out JsonElement upiVaElement)
                                ? upiVaElement.ToString() : null,

                        ServiceTax = msg.TryGetProperty("service_tax", out JsonElement stElement)
                                     && decimal.TryParse(stElement.ToString(), out decimal st) ? st : null,
                        ServiceCharge = msg.TryGetProperty("service_charge", out JsonElement scElement)
                                        && decimal.TryParse(scElement.ToString(), out decimal sc) ? sc : null,
                        NetAmountDebit = msg.TryGetProperty("net_amount_debit", out JsonElement nadElement)
                                         && decimal.TryParse(nadElement.ToString(), out decimal nad) ? nad : null,
                        SettlementAmount = msg.TryGetProperty("settlement_amount", out JsonElement saElement)
                                           && decimal.TryParse(saElement.ToString(), out decimal sa) ? sa : null,
                        DiscountAmount = msg.TryGetProperty("discount_amount", out JsonElement daElement)
                                         && decimal.TryParse(daElement.ToString(), out decimal da) ? da : null,
                        DiscountCode = msg.TryGetProperty("discount_code", out JsonElement dcElement)
                                       ? dcElement.ToString() : null,

                        CashBackPercentage = msg.TryGetProperty("cash_back_percentage", out JsonElement cbElement)
                                             && decimal.TryParse(cbElement.ToString(), out decimal cb) ? cb : null,
                        DeductionPercentage = msg.TryGetProperty("deduction_percentage", out JsonElement dpElement)
                                              && decimal.TryParse(dpElement.ToString(), out decimal dp) ? dp : null,

                        Furl = msg.TryGetProperty("furl", out JsonElement furlElement)
                               ? furlElement.ToString() : null,
                        Surl = msg.TryGetProperty("surl", out JsonElement surlElement)
                               ? surlElement.ToString() : null,
                        Hash = msg.TryGetProperty("hash", out JsonElement hashElement)
                               ? hashElement.ToString() : null,

                        // UDF Fields
                        Udf1 = msg.TryGetProperty("udf1", out JsonElement udf1Element) ? udf1Element.ToString() : null,
                        Udf2 = msg.TryGetProperty("udf2", out JsonElement udf2Element) ? udf2Element.ToString() : null,
                        Udf3 = msg.TryGetProperty("udf3", out JsonElement udf3Element) ? udf3Element.ToString() : null,
                        Udf4 = msg.TryGetProperty("udf4", out JsonElement udf4Element) ? udf4Element.ToString() : null,
                        Udf5 = msg.TryGetProperty("udf5", out JsonElement udf5Element) ? udf5Element.ToString() : null,
                        Udf6 = msg.TryGetProperty("udf6", out JsonElement udf6Element) ? udf6Element.ToString() : null,
                        Udf7 = msg.TryGetProperty("udf7", out JsonElement udf7Element) ? udf7Element.ToString() : null,
                        Udf8 = msg.TryGetProperty("udf8", out JsonElement udf8Element) ? udf8Element.ToString() : null,
                        Udf9 = msg.TryGetProperty("udf9", out JsonElement udf9Element) ? udf9Element.ToString() : null,
                        Udf10 = msg.TryGetProperty("udf10", out JsonElement udf10Element) ? udf10Element.ToString() : null,

                        CancellationReason = msg.TryGetProperty("cancellation_reason", out JsonElement cancelElement)
                                             ? cancelElement.ToString() : null,
                    };

                    paymentEntity.IsWebhook = false;
                    var data = await _webBookingLookupRepository.InsertEasebuzzPaymentData(
                        paymentEntity,
                        "sp_ManageInsertEasebuzzPayment");   
                
                

                return Ok(new VerifyPaymentResponse
                {
                    Success = isSuccess,
                    BookingId = bookingId,
                    Amount = amount,
                    Status = paymentStatus,
                    Error = isSuccess ? null : "Payment not successful."
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new VerifyPaymentResponse
                {
                    Success = false,
                    Error = ex.Message
                });
            }
        }

        #endregion

        #region WEBHOOK
        [HttpPost("Webhook")]
        [Consumes("application/x-www-form-urlencoded")]
        public async Task<IActionResult> Webhook([FromForm] IFormCollection form)
        {
            try
            {

                // CREATE LOG DIRECTORY

                string logFolder = CommonRepositoryConstants.ImageFilePath;

                Directory.CreateDirectory(logFolder);


                // DYNAMIC REQUEST LOG

                var logBuilder = new StringBuilder();

                logBuilder.AppendLine("========== EASEBUZZ WEBHOOK ==========");
                logBuilder.AppendLine($"DateTime : {DateTime.Now}");
                logBuilder.AppendLine("--------------------------------------");

                foreach (var key in form.Keys)
                {
                    logBuilder.AppendLine($"{key} : {form[key]}");
                }

                logBuilder.AppendLine("======================================");
                logBuilder.AppendLine();

                string logFileName = $"Webhook_{DateTime.Now:yyyyMMdd}.txt";

                string logFilePath = Path.Combine(logFolder, logFileName);

                await System.IO.File.AppendAllTextAsync(
                    logFilePath,
                    logBuilder.ToString());


                // GET VALUES

                var receivedHash = form["hash"].ToString();
                var status = form["status"].ToString();
                var txnid = form["txnid"].ToString();
                var tempBookingId = form["udf1"].ToString();
                var amount = form["amount"].ToString();
                var productInfo = form["productinfo"].ToString();
                var firstname = form["firstname"].ToString();
                var email = form["email"].ToString();


                // HASH VALIDATION

                string hashSequence =
                    $"{_salt}|{status}|||||||||{tempBookingId}|{email}|{firstname}|{productInfo}|{amount}|{txnid}|{_merchantKey}";

                string calculatedHash = GenerateHash512(hashSequence);


                    bool isSuccess = status.Equals("success", StringComparison.OrdinalIgnoreCase);


                    var paymentEntity = new EasebuzzPaymentEntity
                    {
                        Key = _merchantKey,
                        Txnid = txnid,
                        Amount = decimal.TryParse(amount, out decimal amt) ? amt : 0,
                        Status = status,
                        Error = form["error"].ToString(),
                        ErrorMessage = form["error_Message"].ToString(),
                        Addedon = DateTime.TryParse(form["addedon"].ToString(), out DateTime addedonDate)
                                  ? addedonDate : DateTime.Now,

                        Easepayid = form["easepayid"].ToString(),
                        BankRefNum = form["bank_ref_num"].ToString(),
                        AuthCode = form["auth_code"].ToString(),
                        AuthRefNum = form["auth_ref_num"].ToString(),

                        Firstname = firstname,
                        Email = email,
                        Phone = form["phone"].ToString(),
                        Productinfo = productInfo,

                        BankName = form["bank_name"].ToString(),
                        Bankcode = form["bankcode"].ToString(),
                        Cardnum = form["cardnum"].ToString(),
                        CardType = form["card_type"].ToString(),
                        CardCategory = form["cardCategory"].ToString(),
                        NameOnCard = form["name_on_card"].ToString(),
                        IssuingBank = form["issuing_bank"].ToString(),

                        PaymentHotelBookingrce = form["payment_HotelBookingrce"].ToString(),
                        PaymentCategory = form["payment_category"].ToString(),
                        Mode = form["mode"].ToString(),
                        PgType = form["PG_TYPE"].ToString(),
                        UpiVa = form["upi_va"].ToString(),

                        ServiceTax = decimal.TryParse(form["service_tax"].ToString(), out decimal st) ? st : null,
                        ServiceCharge = decimal.TryParse(form["service_charge"].ToString(), out decimal sc) ? sc : null,
                        NetAmountDebit = decimal.TryParse(form["net_amount_debit"].ToString(), out decimal nad) ? nad : null,
                        SettlementAmount = decimal.TryParse(form["settlement_amount"].ToString(), out decimal sa) ? sa : null,
                        DiscountAmount = decimal.TryParse(form["discount_amount"].ToString(), out decimal da) ? da : null,
                        DiscountCode = form["discount_code"].ToString(),

                        CashBackPercentage = decimal.TryParse(form["cash_back_percentage"].ToString(), out decimal cb) ? cb : null,
                        DeductionPercentage = decimal.TryParse(form["deduction_percentage"].ToString(), out decimal dp) ? dp : null,

                        Furl = form["furl"].ToString(),
                        Surl = form["surl"].ToString(),
                        Hash = receivedHash,

                        // UDF Fields
                        Udf1 = tempBookingId,
                        Udf2 = form["udf2"].ToString(),
                        Udf3 = form["udf3"].ToString(),
                        Udf4 = form["udf4"].ToString(),
                        Udf5 = form["udf5"].ToString(),
                        Udf6 = form["udf6"].ToString(),
                        Udf7 = form["udf7"].ToString(),
                        Udf8 = form["udf8"].ToString(),
                        Udf9 = form["udf9"].ToString(),
                        Udf10 = form["udf10"].ToString(),

                        CancellationReason = form["cancellation_reason"].ToString(),

                    };

                    paymentEntity.IsWebhook = true;

                    await Task.Delay(1000 * 60);

                    var data = await _webBookingLookupRepository.InsertEasebuzzPaymentData(
                        paymentEntity,
                        "sp_ManageInsertEasebuzzPayment");

                    await LogWebhookMessage(
                        "PAYMENT SUCCESS",
                        $"Transaction ID : {txnid}\nTempBookingId : {tempBookingId}");

                
                
                return Ok("Webhook received successfully.");
                
            }
            catch (Exception ex)
            {
                await LogWebhookMessage(
                    "WEBHOOK ERROR",
                    ex.ToString());

                return StatusCode(500, "Error receiving webhook parameters.");
            }
        }

        #endregion

        private async Task LogWebhookMessage(string title, string message)
        {
            string logFolder = CommonRepositoryConstants.ImageFilePath;

            Directory.CreateDirectory(logFolder);

            string filePath = Path.Combine(
                logFolder,
                $"Webhook_{DateTime.Now:yyyyMMdd}.txt");

            StringBuilder sb = new StringBuilder();

            sb.AppendLine("======================================");
            sb.AppendLine(title);
            sb.AppendLine($"DateTime : {DateTime.Now}");
            sb.AppendLine(message);
            sb.AppendLine("======================================");
            sb.AppendLine();

            await System.IO.File.AppendAllTextAsync(
                filePath,
                sb.ToString());
        }

        private static string GenerateHash512(string text)
        {
            byte[] bytes =
                Encoding.UTF8.GetBytes(text);

            using SHA512 sha =
                SHA512.Create();

            byte[] hash =
                sha.ComputeHash(bytes);

            return Convert
                .ToHexString(hash)
                .ToLower();
        }
    }
}