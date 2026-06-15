using HotelBooking.Entity.Common.Entities;
using HotelBooking.Entity.Entities;

namespace HotelBooking.Domain.Interfaces
{
    /// <summary>
    /// Added by NikunjK on 01-08-2023
    /// </summary>
    public interface IUserLoginDomain
    {
        Task<LoginResponseEntity> UserLogin(LoginRequestEntity entity);
        Task<LoginResponseEntity> CheckRefreshToken(UserToken entity);
        Task<ResultModel> ManageUserChangePassword(ChangePasswordRequestEntity entity);
        Task<ResultModel> ManageUserResetPassword(ChangePasswordRequestEntity entity);
    }
}
