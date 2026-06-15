using HotelBooking.Entity.Common.Entities;
using HotelBooking.Entity.Entities;

namespace HotelBooking.DataAccess.Base
{
    /// <summary>
    /// Added by NikunjK on 01-08-2023
    /// </summary>
    public interface IUserTypeLookupRepositoryInterface
    {
        Task<UserIDView> InsertUserType(UserTypeDataEntity entity, string storedProcedure);
        Task<ResultModel> UpdateUserType(UserTypeDataEntity entity, string storedProcedure);
        Task<ResultModel> DeleteUserType(UserTypeIDEntity entity, string storedProcedure);
        Task<UserTypeListEntity> FindByIDUserType(UserTypeIDEntity entity, string storedProcedure);
        Task<List<UserTypeListEntity>> FindAllUserType(UserTypeIDEntity entity, string storedProcedure);
        Task<List<UserTypeListEntity>> FindAllActiveUserType(string storedProcedure);
        Task<ResultModel> ActiveInActiveUserType(UserTypeIDEntity entity, string storedProcedure);
    }
}

