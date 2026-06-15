using HotelBooking.Entity.Common.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace HotelBooking.Entity.Entities
{
    // --- Frontend Request & Response DTOs ---

    public class InitiatePaymentRequest
    {
        [Required]
        public int TempBookingId { get; set; }

        [Required]
        [Range(0.01, double.MaxValue, ErrorMessage = "Amount must be greater than zero.")]
        public decimal Amount { get; set; }

        [Required]
        public string ProductInfo { get; set; } = string.Empty;

        [Required]
        public string Firstname { get; set; } = string.Empty;

        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        [Required]
        [RegularExpression(@"^\d{10}$", ErrorMessage = "A valid 10-digit phone number is required.")]
        public string Phone { get; set; } = string.Empty;
    }

    public class InitiatePaymentResponse
    {
        [JsonPropertyName("success")]
        public bool Success { get; set; }

        [JsonPropertyName("access_key")]
        public string AccessKey { get; set; } = string.Empty;

        [JsonPropertyName("txnid")]
        public string TxnId { get; set; } = string.Empty;

        [JsonPropertyName("merchantKey")]
        public string MerchantKey { get; set; } = string.Empty;

        [JsonPropertyName("env")]
        public string Env { get; set; } = string.Empty;

        [JsonPropertyName("hash")]
        public string Hash { get; set; } = string.Empty;

        [JsonPropertyName("error")]
        public string? Error { get; set; }
    }

    public class VerifyPaymentRequest
    {
        [Required]
        public string TxnId { get; set; } = string.Empty;

        [Required]
        public object FrontendResponse { get; set; } = null!;
    }

    public class VerifyPaymentResponse
    {
        [JsonPropertyName("success")]
        public bool Success { get; set; }

        [JsonPropertyName("bookingId")]
        public string BookingId { get; set; } = string.Empty;

        [JsonPropertyName("amount")]
        public decimal Amount { get; set; }

        [JsonPropertyName("status")]
        public string Status { get; set; } = string.Empty;

        [JsonPropertyName("error")]
        public string? Error { get; set; }
    }

    // --- Easebuzz Internal Service DTOs ---

    public class EasebuzzInitiateRawResponse
    {
        [JsonPropertyName("status")]
        public int Status { get; set; }

        [JsonPropertyName("data")]
        public string Data { get; set; } = string.Empty; // Holds access key on success or error message on failure
    }

    public class EasebuzzTransactionDetails
    {
        [JsonPropertyName("status")]
        public string Status { get; set; } = string.Empty;

        [JsonPropertyName("amount")]
        public string Amount { get; set; } = string.Empty;

        [JsonPropertyName("txnid")]
        public string Txnid { get; set; } = string.Empty;

        [JsonPropertyName("firstname")]
        public string Firstname { get; set; } = string.Empty;

        [JsonPropertyName("email")]
        public string Email { get; set; } = string.Empty;

        [JsonPropertyName("udf1")]
        public string Udf1 { get; set; } = string.Empty; // Map to TempBookingId
    }


    public class EasebuzzPaymentEntity
    {
        public string Key { get; set; }
        public string Txnid { get; set; }
        public decimal Amount { get; set; }
        public string Status { get; set; }
        public string Error { get; set; }
        public string ErrorMessage { get; set; }
        public DateTime? Addedon { get; set; }
        public string Easepayid { get; set; }
        public string BankRefNum { get; set; }
        public string AuthCode { get; set; }
        public string AuthRefNum { get; set; }

        public string Firstname { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Productinfo { get; set; }

        public string BankName { get; set; }
        public string Bankcode { get; set; }
        public string Cardnum { get; set; }
        public string CardType { get; set; }
        public string CardCategory { get; set; }
        public string NameOnCard { get; set; }
        public string IssuingBank { get; set; }
        public string PaymentHotelBookingrce { get; set; }
        public string PaymentCategory { get; set; }
        public string Mode { get; set; }
        public string PgType { get; set; }
        public string UpiVa { get; set; }

        public decimal? ServiceTax { get; set; }
        public decimal? ServiceCharge { get; set; }
        public decimal? NetAmountDebit { get; set; }
        public decimal? SettlementAmount { get; set; }
        public decimal? DiscountAmount { get; set; }
        public string DiscountCode { get; set; }

        public decimal? CashBackPercentage { get; set; }
        public decimal? DeductionPercentage { get; set; }

        public string Furl { get; set; }
        public string Surl { get; set; }
        public string Hash { get; set; }
        public string MerchantLogo { get; set; }

        public string Udf1 { get; set; }
        public string Udf2 { get; set; }
        public string Udf3 { get; set; }
        public string Udf4 { get; set; }
        public string Udf5 { get; set; }
        public string Udf6 { get; set; }
        public string Udf7 { get; set; }
        public string Udf8 { get; set; }
        public string Udf9 { get; set; }
        public string Udf10 { get; set; }

        public bool IsWebhook { get; set; }

        public string CancellationReason { get; set; }
    }
}
