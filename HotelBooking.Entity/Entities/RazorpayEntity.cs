using HotelBooking.Entity.Common.Entities;
using Microsoft.AspNetCore.Http;
using Org.BouncyCastle.Math;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static HotelBooking.Entity.Entities.PaymentDataEntity;

/// <summary>
/// Added by NikunjK on 01-08-2023
/// </summary>
namespace HotelBooking.Entity.Entities
{
    public class PaymentVerificationRequest
    {
        public string RazorpayOrderId { get; set; }
        public string RazorpayPaymentId { get; set; }
        public string RazorpaySignature { get; set; }
        public string? booking_no { get; set; }
        public int? transaction_wallet_id { get; set; }
    }

    public class PaymentRequest
    {
        public int Amount { get; set; }
        public string Currency { get; set; }
    }

    public class PaymentOrderResponse
    {
        public int Amount { get; set; }
        public string Currency { get; set; }
        public string Orderid { get; set; }
    }
    public class PaymentDataEntity
    {
        public int? transaction_wallet_id { get; set; }
        public string? booking_no { get; set; }
        public string? payment_id { get; set; }
        public string? Entity { get; set; }
        public decimal? Amount { get; set; }
        public string? Currency { get; set; }
        public string? Status { get; set; }
        public string? OrderId { get; set; }
        public string? InvoiceId { get; set; }
        public bool? International { get; set; }
        public string? Method { get; set; }
        public decimal? AmountRefunded { get; set; }
        public string? RefundStatus { get; set; }
        public bool? Captured { get; set; }
        public string? Description { get; set; }
        public string? CardId { get; set; }
        public string? Bank { get; set; }
        public string? Wallet { get; set; }
        public string? Vpa { get; set; }
        public string? Email { get; set; }
        public string? Contact { get; set; }
        public string? Fee { get; set; }
        public string? Tax { get; set; }
        public string? customer_id { get; set; }
        public string? ErrorCode { get; set; }
        public string? ErrorDescription { get; set; }
        public string? ErrorHotelBookingrce { get; set; }
        public string? ErrorStep { get; set; }
        public string? ErrorReason { get; set; }
        public int? CreatedAt { get; set; }
        public acquirer_data? acquirer { get; set; }
        public card_details carddetails { get; set; } // Newly added property
        public upi_details upidetails { get; set; }

        public class acquirer_data
        {
            public string? auth_code { get; set; }
            public string? arn { get; set; }
            public string? rrn { get; set; }
            public string? bank_transaction_id { get; set; }
            public string? transaction_id { get; set; }
        }
        public class card_details
        {
            public string card_id { get; set; }
            public string card_name { get; set; }
            public string last4 { get; set; }
            public string network { get; set; }
            public string card_type { get; set; }       // Changed from 'type'
            public string issuer { get; set; }
            public bool? card_international { get; set; } // Changed from 'international'
            public bool? card_emi { get; set; }          // Changed from 'emi'
            public string card_sub_type { get; set; }    // Changed from 'sub_type'
        }

        public class upi_details
        {
            public string payer_account_type { get; set; }
            public string vpa { get; set; }
            public string flow { get; set; }
        }


    }



}
