using FluentValidation.Results;
using HotelBooking.DataAccess.Interfaces;
using HotelBooking.Domain.Interfaces;
using HotelBooking.Domain.Validations;
using HotelBooking.Entity.Common.Entities;
using HotelBooking.Entity.Entities;

namespace HotelBooking.Domain.Domains
{
    /// <summary>
    /// Added by NikunjK on 01-08-2023
    /// </summary>
    public class UserLoginDomain : IUserLoginDomain
    {
        IUserLoginRepository repository;
        public UserLoginDomain(IUserLoginRepository _repository)
        {
            repository = _repository;
        }

        public async Task<LoginResponseEntity> UserLogin(LoginRequestEntity entity)
        {
            LoginResponseEntity result = new LoginResponseEntity();
            LoginInValidation validator = new LoginInValidation();
            ValidationResult validationResult = validator.Validate(entity);
            if (validationResult.IsValid)
            {
                result = await repository.UserLogin(entity);
            }
            else
            {
                foreach (var item in validationResult.Errors)
                {
                    result.Message += item.ErrorMessage + Environment.NewLine;
                }
            }

            return result;
        }
        public async Task<LoginResponseEntity> CheckRefreshToken(UserToken entity)
        {
            return await repository.CheckRefreshToken(entity);

        }
        public async Task<ResultModel> ManageUserChangePassword(ChangePasswordRequestEntity entity)
        {
            return await repository.ManageUserChangePassword(entity);

        }
        public async Task<ResultModel> ManageUserResetPassword(ChangePasswordRequestEntity entity)
        {
            return await repository.ManageUserResetPassword(entity);

        }
    }
}
