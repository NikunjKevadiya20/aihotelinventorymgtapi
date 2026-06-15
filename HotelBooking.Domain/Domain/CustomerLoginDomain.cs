using HotelBooking.DataAccess.Interfaces;
using HotelBooking.Domain.Interfaces;
using HotelBooking.Domain.Validations;
using HotelBooking.Entity.Common.Entities;
using HotelBooking.Entity.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBooking.Domain.Domain
{
  

    public class CustomerLoginDomain : ICustomerLoginDomain
    {
        ICustomerLoginRepository repository;
        public CustomerLoginDomain(ICustomerLoginRepository _repository)
        {
            repository = _repository;
        }

        public async Task<LogInResponseEntity> UserLogin(LoginRequestsEntity entity)
        {
            //LogInResponseEntity result = new LogInResponseEntity();
            //LoginValidation validator = new LoginValidation();
            //ValidationResult validationResult = validator.Validate(entity);
            //if (validationResult.IsValid)
            //{
            //    result = await repository.UserLogin(entity);
            //}
            //else
            //{
            //    foreach (var item in validationResult.Errors)
            //    {
            //        result.Message += item.ErrorMessage + Environment.NewLine;
            //    }
            //}

            //return result;
            return await repository.UserLogin(entity);
        }
        public async Task<SignUPResponseEntity> UserSignup(LoginRequestsEntity entity)
        {
            //LogInResponseEntity result = new LogInResponseEntity();
            //LoginValidation validator = new LoginValidation();
            //ValidationResult validationResult = validator.Validate(entity);
            //if (validationResult.IsValid)
            //{
            //    result = await repository.UserSignup(entity);
            //}
            //else
            //{
            //    foreach (var item in validationResult.Errors)
            //    {
            //        result.Message += item.ErrorMessage + Environment.NewLine;
            //    }
            //}

            //return result;

            return await repository.UserSignup(entity);


        }

        public async Task<OtpResponseEntity> OtpGenerate(LoginRequestsEntity entity)
        {
            return await repository.OtpGenerate(entity);
        }
        public async Task<OtpResponseEntity> VerifyOtpGenerate(LoginRequestsEntity entity)
        {
            return await repository.VerifyOtpGenerate(entity);
        }
        public async Task<EmailVerificationViewEntity> EmailVerification(EmailVerificationEntity entity)
        {
            return await repository.EmailVerification(entity);
        }
        public async Task<ResultModel> MobileVerification(EmailVerificationEntity entity)
        {
            return await repository.MobileVerification(entity);
        }

        public async Task<EmailOtpApproveViewEntity> EmailOtpApprove(EmailVerificationEntity entity)
        {
            return await repository.EmailOtpApprove(entity);
        }
        public async Task<ResultModel> UpdateCustomer(CustomerEntity entity)
        {
            return await repository.UpdateCustomer(entity);
        }
        public async Task<CustomerViewEntity> FindByIDCustomer(ColorIDEntity entity)
        {
            return await repository.FindByIDCustomer(entity);
        }
        public async Task<CustomerListFinalResponse> FindAllCustomer(CustomerListRequestEntity entity)
        {
            return await repository.FindAllCustomer(entity);
        }
        public async Task<CustomerDetailsFinalResponse> CustomerDetailsByID(ColorIDEntity entity)
        {
            return await repository.CustomerDetailsByID(entity);
        }
        public async Task<OrderPaymentFinalResponse> FindAllPayment(OrderPaymentRequestEntity entity)
        {
            return await repository.FindAllPayment(entity);
        }
        public async Task<OrderPaymentDetailsFinalResponse> PaymentDetailsByID(OrderPaymentDetailsRequestEntity entity)
        {
            return await repository.PaymentDetailsByID(entity);
        }
    }
}
