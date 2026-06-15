using HotelBooking.Entity.Common.Entities;
using HotelBooking.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBooking.Domain.Interfaces
{
  
    public interface ICustomerLoginDomain
    {
        Task<LogInResponseEntity> UserLogin(LoginRequestsEntity entity);
        Task<SignUPResponseEntity> UserSignup(LoginRequestsEntity entity);
        Task<OtpResponseEntity> OtpGenerate(LoginRequestsEntity entity);
        Task<OtpResponseEntity> VerifyOtpGenerate(LoginRequestsEntity entity);
        Task<EmailVerificationViewEntity> EmailVerification(EmailVerificationEntity entity);
        Task<ResultModel> MobileVerification(EmailVerificationEntity entity);
        Task<EmailOtpApproveViewEntity> EmailOtpApprove(EmailVerificationEntity entity);
        Task<ResultModel> UpdateCustomer(CustomerEntity entity);
        Task<CustomerViewEntity> FindByIDCustomer(ColorIDEntity entity);
        Task<CustomerListFinalResponse> FindAllCustomer(CustomerListRequestEntity entity);
        Task<CustomerDetailsFinalResponse> CustomerDetailsByID(ColorIDEntity entity);
        Task<OrderPaymentFinalResponse> FindAllPayment(OrderPaymentRequestEntity entity);
        Task<OrderPaymentDetailsFinalResponse> PaymentDetailsByID(OrderPaymentDetailsRequestEntity entity);
    }
}
