using HotelBooking.Entity.Common.Entities;
using HotelBooking.Entity.Entities;

namespace HotelBooking.DataAccess.Base
{
    /// <summary>
    /// Added by NikunjK on 01-08-2023
    /// </summary>
    public interface IUserLookupRepositoryInterface
    {
        Task<UserIDView> InsertUser(UsersDataEntity entity, string storedProcedure);
        Task<ResultModel> UpdateUser(UsersDataEntity entity, string storedProcedure);
        Task<ResultModel> DeleteUser(UserIDEntity entity, string storedProcedure);
        Task<UsersListEntity> FindByIDUser(UserIDEntity entity, string storedProcedure);
        Task<List<UsersListEntity>> FindAllUser(UserIDEntity entity, string storedProcedure);
        Task<List<UsersListEntity>> FindAllActiveUser(string storedProcedure);
        Task<ResultModel> ActiveInActiveUser(UserIDEntity entity, string storedProcedure);
        Task<UserImageListEntity> UserImageUpdate(string? physicalFileName, int? ID, int? UpdatedBy, string storedProcedure);
    }
}

