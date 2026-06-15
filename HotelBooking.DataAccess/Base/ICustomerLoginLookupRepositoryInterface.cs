using HotelBooking.Entity.Common.Entities;
using HotelBooking.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBooking.DataAccess.Base
{
     

    public interface ICustomerLoginLookupRepositoryInterface
    {
        Task<LogInResponseEntity> UserLogin(LoginRequestsEntity entity, string storedProcedure);
        Task<SignUPResponseEntity> UserSignup(LoginRequestsEntity entity, string storedProcedure);
        Task<OtpResponseEntity> OtpGenerate(LoginRequestsEntity entity, string storedProcedure);
        Task<OtpResponseEntity> VerifyOtpGenerate(LoginRequestsEntity entity, string storedProcedure);
        Task<EmailVerificationViewEntity> EmailVerification(EmailVerificationEntity entity, string storedProcedure);
        Task<ResultModel> MobileVerification(EmailVerificationEntity entity, string storedProcedure);
        Task<EmailOtpApproveViewEntity> EmailOtpApprove(EmailVerificationEntity entity, string storedProcedure);
        Task<ResultModel> UpdateCustomer(CustomerEntity entity, string storedProcedure);
        Task<CustomerViewEntity> FindByIDCustomer(ColorIDEntity entity, string storedProcedure);
        Task<CustomerListFinalResponse> FindAllCustomer(CustomerListRequestEntity entity,string storedProcedure);
        Task<CustomerDetailsFinalResponse> CustomerDetailsByID(ColorIDEntity entity, string storedProcedure);
        Task<OrderPaymentFinalResponse> FindAllPayment(OrderPaymentRequestEntity entity, string storedProcedure);
        Task<OrderPaymentDetailsFinalResponse> PaymentDetailsByID(OrderPaymentDetailsRequestEntity entity, string storedProcedure);
    }
}
