using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBooking.Entity.Entities
{
    public class LoginRequestsEntity : MessageBaseEntity
    {

        public string? first_name { get; set; }
        public string? last_name { get; set; }
        public string? mobile_no { get; set; }
        public string? email_id { get; set; }
        public string? otp { get; set; }
        public string? browser_version { get; set; }
        public string? device_id { get; set; }
        public string? device_type { get; set; }
        public string? session_id { get; set; }


    }
    public class EmailVerificationEntity : MessageBaseEntity
    {

        public Guid? user_guid { get; set; }
        public string? email_code { get; set; }
        public string? otp { get; set; }

    }

    public class CustomerEntity
    {
        public int? ID { get; set; }
        public string? first_name { get; set; }
        public string? last_name { get; set; }
        public string? email_id { get; set; }
        public bool? isactive { get; set; }
    }
    public class CustomerViewEntity : MessageBaseEntity
    {
        public int? ID { get; set; }
        public string? first_name { get; set; }
        public string? last_name { get; set; }
        public string? email_id { get; set; }
        public bool? isactive { get; set; }
    }
    public class OtpResponseEntity : MessageBaseEntity
    {
        public int? otp { get; set; }

    }
    public class LogInResponseEntity : MessageBaseEntity
    {
        public int? ID { get; set; }
        public Boolean? isexisting_user { get; set; }
        public Boolean? is_email_verified { get; set; }
        public Boolean? is_mobile_verified { get; set; }
        public Guid? user_guid { get; set; }
        public string? first_name { get; set; }
        public string? last_name { get; set; }
        public string? mobile_no { get; set; }
        public string? email_id { get; set; }
        public string? is_first_login { get; set; }
        public string? token { get; set; }
        public string? refresh_token { get; set; }
        public string? otp { get; set; }
        public string? login_with { get; set; }
        public string? Errors { get; set; }
        public IEnumerable<UserRightsAssignViewLogin>? UserRightsAssign { get; set; }
    }

    public class SignUPResponseEntity : MessageBaseEntity
    {
   
        public string? Errors { get; set; }
        //public IEnumerable<UserRightsAssignViewLogin>? UserRightsAssign { get; set; }
    }
    public class UserRightsAssignViewLogin
    {
        public int? MenuID { set; get; }
        public string? MenuKey { set; get; }
        public string? MenuName { set; get; }
        public string? RightsID { set; get; }
    }
    public class EmailOtpApproveViewEntity
    {

        public string? is_email_verified { get; set; }
        public string? is_mobile_verified { get; set; }
        public string? Details { get; set; }
        public string? Message { get; set; }
        public int? Status { get; set; }
        public string? ErrorMessage { get; set; }
    }

    public class EmailVerificationViewEntity
    {

        public string? email_verification_link { get; set; }
        public string? email_id { get; set; }
        public string? full_name { get; set; }

        public string? Details { get; set; }
        public string? Message { get; set; }
        public int? Status { get; set; }
        public string? ErrorMessage { get; set; }
    }


    public class CustomerListRequestEntity
    {
        public int? ID { get; set; } = 0;

        public string? CustomerName { get; set; } = string.Empty;

        public string? MobileNo { get; set; } = string.Empty;

        public string? EmailID { get; set; } = string.Empty;

      
        public string? FilterType { get; set; } = string.Empty;

        public int? Limit { get; set; } 

        public int? Skip { get; set; } 

    }

    public class CustomerListFinalResponse : MessageBaseEntity
    {
        public List<CustomerListResponse> CustomerList { get; set; } = new();
        public CustomerSummaryResponse Summary { get; set; } = new();
    }

    public class CustomerSummaryResponse
    {
        public int TotalCustomer { get; set; }
        public int ActiveThisMonth { get; set; }
    }

    public class CustomerListResponse
    {
        public string Message { get; set; } = string.Empty;
        public string Details { get; set; } = string.Empty;

        public int ID { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string CustomerName { get; set; } = string.Empty;

        public string MobileNo { get; set; } = string.Empty;
        public string EmailID { get; set; } = string.Empty;

        public bool IsActive { get; set; }

        public DateTime? CreatedOn { get; set; }

        public DateTime? LastLoginDate { get; set; }
        public int? LastLoginDays { get; set; }

        public int TotalCount { get; set; }
        public decimal TotalSpent { get; set; }

        public int ItemCount { get; set; }
        public int TotalPages { get; set; }
    }
    public class CustomerDetailsFinalResponse : MessageBaseEntity
    {
        public CustomerDetailsResponse CustomerDetails { get; set; } = new();

        public List<CustomerAddressResponse> AddressList { get; set; } = new();

      
    }
    public class CustomerAddressResponse
    {
        public string Message { get; set; } = string.Empty;
        public string Details { get; set; } = string.Empty;

        public int ID { get; set; }
        public int CustomerId { get; set; }

        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string CompanyName { get; set; } = string.Empty;

        public string MobileNo { get; set; } = string.Empty;

        public string Address1 { get; set; } = string.Empty;
        public string Address2 { get; set; } = string.Empty;

        public string City { get; set; } = string.Empty;
        public string State { get; set; } = string.Empty;
        public string Country { get; set; } = string.Empty;
        public string ZipCode { get; set; } = string.Empty;

        public bool IsDefaultAddress { get; set; }
        public bool IsActive { get; set; }
    }
    public class CustomerDetailsResponse
    {
        public string Message { get; set; } = string.Empty;
        public string Details { get; set; } = string.Empty;

        public int ID { get; set; }

        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string CustomerName { get; set; } = string.Empty;

        public string MobileNo { get; set; } = string.Empty;
        public string EmailID { get; set; } = string.Empty;

        public bool IsActive { get; set; }

        public DateTime? CreatedOn { get; set; }

        public int TotalCount { get; set; }
        public decimal TotalSpent { get; set; }

        public DateTime? LastLoginDate { get; set; }
        public int? LastLoginDays { get; set; }
    }

    public class OrderPaymentRequestEntity
    {
        public string? SearchText { get; set; } = string.Empty;

        public string? PaymentStatus { get; set; } = string.Empty;   

        public string? Gateway { get; set; } = string.Empty;       
        public int? Limit { get; set; } 

        public int? Skip { get; set; } 

    }

    public class OrderPaymentListResponse
    {
        public string Message { get; set; } = string.Empty;

        public string Details { get; set; } = string.Empty;

        public int ID { get; set; }

        public string TransactionID { get; set; } = string.Empty;

        public string PaymentID { get; set; } = string.Empty;

        public string OrderNo { get; set; } = string.Empty;

        public int CustomerID { get; set; }

        public string CustomerName { get; set; } = string.Empty;

        public string MobileNo { get; set; } = string.Empty;

        public string EmailID { get; set; } = string.Empty;

        public decimal Amount { get; set; }

        public string Gateway { get; set; } = string.Empty;

        public string PaymentStatus { get; set; } = string.Empty;

        public string OrderStatus { get; set; } = string.Empty;

        public decimal FinalPrice { get; set; }

        public string? TransactionDate { get; set; }

        public int TotalRecord { get; set; }

        public int TotalPages { get; set; }
    }

    public class OrderPaymentFinalResponse : MessageBaseEntity
    {
        public List<OrderPaymentListResponse> PaymentList { get; set; } = new();

        public OrderPaymentSummaryResponse Summary { get; set; } = new();

   
    }
    public class OrderPaymentSummaryResponse
    {
        public int TotalTransactions { get; set; }

        public int Successful { get; set; }

        public int Pending { get; set; }

        public int Failed { get; set; }
    }

    public class OrderPaymentDetailsRequestEntity
    {
        public int? ID { get; set; }

    }
    public class OrderPaymentDetailsResponse
    {
        public string Message { get; set; } = string.Empty;

        public string Details { get; set; } = string.Empty;

        // Payment
        public int ID { get; set; }

        public string PaymentID { get; set; } = string.Empty;

        public string Entity { get; set; } = string.Empty;

        public decimal Amount { get; set; }

        public string Currency { get; set; } = string.Empty;

        public string PaymentStatus { get; set; } = string.Empty;

        public string Order_ID { get; set; } = string.Empty;

        public string Invoice_ID { get; set; } = string.Empty;

        public string Method { get; set; } = string.Empty;

        public decimal Amount_Refunded { get; set; }

        public string Refund_Status { get; set; } = string.Empty;

        public bool Captured { get; set; }

        public string Bank { get; set; } = string.Empty;

        public string Wallet { get; set; } = string.Empty;

        public string VPA { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public string Contact { get; set; } = string.Empty;

        public decimal Fee { get; set; }

        public decimal Tax { get; set; }

        public string OrderNo { get; set; } = string.Empty;

        public string TransactionID { get; set; } = string.Empty;

        public string Error_Code { get; set; } = string.Empty;

        public string Error_Description { get; set; } = string.Empty;

        // Customer
        public string CustomerName { get; set; } = string.Empty;

        public string CustomerEmail { get; set; } = string.Empty;

        public string CustomerContact { get; set; } = string.Empty;

        // Order
        public int OrderID { get; set; }

        public int CustomerID { get; set; }

        public decimal OrderValue { get; set; }

        public decimal DiscountValue { get; set; }

        public decimal GSTValue { get; set; }

        public decimal FinalPrice { get; set; }

        public string OrderPaymentStatus { get; set; } = string.Empty;

        public string OrderStatus { get; set; } = string.Empty;

        public string CouponCode { get; set; } = string.Empty;

        public decimal CouponCodeValue { get; set; }

        public int CustomerAddressID { get; set; }

        public string TransactionDate { get; set; } = string.Empty;
    }
    public class OrderPaymentItemResponse
    {
        public int ID { get; set; }

        public int OrderID { get; set; }

        public int TempID { get; set; }

        public int ProductID { get; set; }

        public string ProductName { get; set; } = string.Empty;

        public string BrandName { get; set; } = string.Empty;

        public string ColorName { get; set; } = string.Empty;

        public string SizeName { get; set; } = string.Empty;

        public string StyleName { get; set; } = string.Empty;

        public string MainImage { get; set; } = string.Empty;

        public int Quantity { get; set; }

        public decimal Price { get; set; }

        public decimal GSTValue { get; set; }

        public decimal TotalPrice { get; set; }

        public int SizeID { get; set; }

        public int ColorID { get; set; }

        public int StyleID { get; set; }
    }
    public class OrderPaymentDetailsFinalResponse : MessageBaseEntity   
    {
        public OrderPaymentDetailsResponse PaymentDetails { get; set; } = new();

        public List<OrderPaymentItemResponse> ItemList { get; set; } = new();

    
    }
}
