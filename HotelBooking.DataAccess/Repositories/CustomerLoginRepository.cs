using HotelBooking.DataAccess.Base;
using HotelBooking.DataAccess.Interfaces;
using HotelBooking.Entity.Common.Entities;
using HotelBooking.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBooking.DataAccess.Repositories
{
  
    public class CustomerLoginRepository : ICustomerLoginRepository
    {
        ICustomerLoginLookupRepositoryInterface repository;
        public CustomerLoginRepository(ICustomerLoginLookupRepositoryInterface _repository)
        {
            repository = _repository;
        }

        public async Task<LogInResponseEntity> UserLogin(LoginRequestsEntity entity)
        {
            return await repository.UserLogin(entity, "sp_ManageLoginCustomer");
        }
        public async Task<SignUPResponseEntity> UserSignup(LoginRequestsEntity entity)
        {
            return await repository.UserSignup(entity, "sp_ManageLoginCustomer");
        }
        public async Task<OtpResponseEntity> OtpGenerate(LoginRequestsEntity entity)
        {
            return await repository.OtpGenerate(entity, "sp_ManageLoginCustomer");
        }
        public async Task<OtpResponseEntity> VerifyOtpGenerate(LoginRequestsEntity entity)
        {
            return await repository.VerifyOtpGenerate(entity, "sp_ManageLoginCustomer");
        }
        public async Task<EmailVerificationViewEntity> EmailVerification(EmailVerificationEntity entity)
        {
            return await repository.EmailVerification(entity, "sp_ManageLoginCustomer");
        }
        public async Task<ResultModel> MobileVerification(EmailVerificationEntity entity)
        {
            return await repository.MobileVerification(entity, "sp_ManageLoginCustomer");
        }
        public async Task<EmailOtpApproveViewEntity> EmailOtpApprove(EmailVerificationEntity entity)
        {
            return await repository.EmailOtpApprove(entity, "sp_ManageLoginCustomer");
        }
        public async Task<ResultModel> UpdateCustomer(CustomerEntity entity)
        {
            return await repository.UpdateCustomer(entity, "sp_ManageLoginCustomer");
        }
        public async Task<CustomerViewEntity> FindByIDCustomer(ColorIDEntity entity)
        {
            return await repository.FindByIDCustomer(entity, "sp_ManageLoginCustomer");
        }
        public async Task<CustomerListFinalResponse> FindAllCustomer(CustomerListRequestEntity entity)
        {
            return await repository.FindAllCustomer(entity, "sp_ManageCustomer");
        }
        public async Task<CustomerDetailsFinalResponse> CustomerDetailsByID(ColorIDEntity entity)
        {
            return await repository.CustomerDetailsByID(entity,"sp_ManageCustomer");
        }
        public async Task<OrderPaymentFinalResponse> FindAllPayment(OrderPaymentRequestEntity entity)
        {
            return await repository.FindAllPayment(entity, "sp_ManageOrderPayment");
        }
        public async Task<OrderPaymentDetailsFinalResponse> PaymentDetailsByID(OrderPaymentDetailsRequestEntity entity)
        {
            return await repository.PaymentDetailsByID(entity,"sp_ManageOrderPayment");
        }
    }
}
