using HotelBooking.Entity.Common.Entities;
using HotelBooking.Entity.Entities;

namespace HotelBooking.Domain.Interfaces
{
    /// <summary>
    /// Added by NikunjK on 01-08-2023
    /// </summary>
    public interface IUserTypeDomain
    {
        Task<UserIDView> InsertUserType(UserTypeDataEntity entity);
        Task<ResultModel> UpdateUserType(UserTypeDataEntity entity);
        Task<ResultModel> DeleteUserType(UserTypeIDEntity entity);
        Task<UserTypeListEntity> FindByIDUserType(UserTypeIDEntity entity);
        Task<List<UserTypeListEntity>> FindAllUserType(UserTypeIDEntity entity);
        Task<List<UserTypeListEntity>> FindAllActiveUserType();
        Task<ResultModel> ActiveInActiveUserType(UserTypeIDEntity entity);
    }
}
