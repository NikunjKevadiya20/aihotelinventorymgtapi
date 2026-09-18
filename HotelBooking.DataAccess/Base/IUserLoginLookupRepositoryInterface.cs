using HotelBooking.Entity.Common.Entities;
using HotelBooking.Entity.Entities;

namespace HotelBooking.DataAccess.Base
{
    /// <summary>
    /// Added by NikunjK on 01-08-2023
    /// </summary>
    public interface IUserLoginLookupRepositoryInterface
    {
        Task<LoginResponseEntity> UserLogin(LoginRequestEntity entity, string storedProcedure);
        Task<LoginResponseEntity> CheckRefreshToken(UserToken entity, string storedProcedure);
        Task<ResultModel> ManageUserChangePassword(ChangePasswordRequestEntity entity, string storedProcedure);
        Task<ResultModel> ManageUserResetPassword(ChangePasswordRequestEntity entity, string storedProcedure);
        Task<EmailOtpVerificationEntity> OtpGenerateByEmail(EmailOtpVerificationEntity entity, string storedProcedure);
        Task<EmailOtpVerificationEntity> OtpVerifyByEmail(EmailOtpVerificationEntity entity, string storedProcedure);
        Task<ResultModel> UpdateCancellation(EmailOtpCancellationEntity entity, string storedProcedure);
    }
}

