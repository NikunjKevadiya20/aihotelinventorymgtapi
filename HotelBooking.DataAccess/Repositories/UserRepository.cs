using HotelBooking.DataAccess.Base;
using HotelBooking.DataAccess.Interfaces;
using HotelBooking.Entity.Common.Entities;
using HotelBooking.Entity.Entities;
using static Dapper.SqlMapper;

namespace HotelBooking.DataAccess.Repositories
{
    /// <summary>
    /// Added by NikunjK on 01-08-2023
    /// </summary>
    public class UserRepository : IUserRepository
    {
        IUserLookupRepositoryInterface repository;
        public UserRepository(IUserLookupRepositoryInterface _repository)
        {
            repository = _repository;
        }

        public async Task<UserIDView> InsertUser(UsersDataEntity entity)
        {
            return await repository.InsertUser(entity, "sp_ManageUserInsert");
        }
        public async Task<ResultModel> UpdateUser(UsersDataEntity entity)
        {
            return await repository.UpdateUser(entity, "sp_ManageUserInsert");
        }
        public async Task<ResultModel> DeleteUser(UserIDEntity entity)
        {
            return await repository.DeleteUser(entity, "sp_ManageUserFindDelete");
        }
        public async Task<UsersListEntity> FindByIDUser(UserIDEntity entity)
        {
            return await repository.FindByIDUser(entity, "sp_ManageUserFindDelete");
        }
        public async Task<List<UsersListEntity>> FindAllUser(UserIDEntity entity)
        {
            return await repository.FindAllUser(entity, "sp_ManageUserFindDelete");
        }
        public async Task<List<UsersListEntity>> FindAllActiveUser()
        {
            return await repository.FindAllActiveUser("sp_ManageUserFindALL");
        }
        public async Task<ResultModel> ActiveInActiveUser(UserIDEntity entity)
        {
            return await repository.ActiveInActiveUser(entity, "sp_ManageUserFindDelete");
        }
        public async Task<UserImageListEntity> UserImageUpdate(string? physicalFileName, int? ID, int? UpdatedBy)
        {
            return await repository.UserImageUpdate(physicalFileName, ID, UpdatedBy, "sp_ManageUserInsert");
        }
    }

}
