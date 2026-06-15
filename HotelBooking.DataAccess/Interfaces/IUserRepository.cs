using HotelBooking.Entity.Common.Entities;
using HotelBooking.Entity.Entities;

namespace HotelBooking.DataAccess.Interfaces
{
    /// <summary>
    /// Added by NikunjK on 01-08-2023
    /// </summary>
    public interface IUserRepository
    {
        Task<UserIDView> InsertUser(UsersDataEntity entity);
        Task<ResultModel> UpdateUser(UsersDataEntity entity);
        Task<ResultModel> DeleteUser(UserIDEntity entity);
        Task<UsersListEntity> FindByIDUser(UserIDEntity entity);
        Task<List<UsersListEntity>> FindAllUser(UserIDEntity entity);
        Task<List<UsersListEntity>> FindAllActiveUser();
        Task<ResultModel> ActiveInActiveUser(UserIDEntity entity);
        Task<UserImageListEntity> UserImageUpdate(string? physicalFileName, int? ID, int? UpdatedBy);

    }
}
