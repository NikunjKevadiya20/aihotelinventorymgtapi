using HotelBooking.DataAccess.Base;
using HotelBooking.DataAccess.Interfaces;
using HotelBooking.Entity.Common.Entities;
using HotelBooking.Entity.Entities;

namespace HotelBooking.DataAccess.Repositories
{
    /// <summary>
    /// Added by NikunjK on 01-08-2023
    /// </summary>
    public class UserLoginRepository : IUserLoginRepository
    {
        IUserLoginLookupRepositoryInterface repository;
        public UserLoginRepository(IUserLoginLookupRepositoryInterface _repository)
        {
            repository = _repository;
        }

        public async Task<LoginResponseEntity> UserLogin(LoginRequestEntity entity)
        {
            return await repository.UserLogin(entity, "sp_ManageLogin");
        }
        public async Task<LoginResponseEntity> CheckRefreshToken(UserToken entity)
        {
            return await repository.CheckRefreshToken(entity, "sp_ManageToken");
        }
        public async Task<ResultModel> ManageUserChangePassword(ChangePasswordRequestEntity entity)
        {
            return await repository.ManageUserChangePassword(entity, "sp_ManageLogin");
        }
        public async Task<ResultModel> ManageUserResetPassword(ChangePasswordRequestEntity entity)
        {
            return await repository.ManageUserResetPassword(entity, "sp_ManageLogin");
        }
        public async Task<EmailOtpVerificationEntity> OtpGenerateByEmail(EmailOtpVerificationEntity entity)
        {
            return await repository.OtpGenerateByEmail(entity, "sp_ManageOtpVerify");
        }
        public async Task<EmailOtpVerificationEntity> OtpVerifyByEmail(EmailOtpVerificationEntity entity)
        {
            return await repository.OtpVerifyByEmail(entity, "sp_ManageOtpVerifyByEmail");
        }
        public async Task<ResultModel> UpdateCancellation(EmailOtpCancellationEntity entity)
        {
            return await repository.UpdateCancellation(entity, "sp_ManageOtpVerify");
        }
    }

}
