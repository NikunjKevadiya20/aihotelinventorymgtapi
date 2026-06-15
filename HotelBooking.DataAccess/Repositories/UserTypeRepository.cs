using HotelBooking.DataAccess.Base;
using HotelBooking.DataAccess.Interfaces;
using HotelBooking.Entity.Common.Entities;
using HotelBooking.Entity.Entities;

namespace HotelBooking.DataAccess.Repositories
{
    /// <summary>
    /// Added by NikunjK on 01-08-2023
    /// </summary>
    public class UserTypeRepository : IUserTypeRepository
    {
        IUserTypeLookupRepositoryInterface repository;
        public UserTypeRepository(IUserTypeLookupRepositoryInterface _repository)
        {
            repository = _repository;
        }

        public async Task<UserIDView> InsertUserType(UserTypeDataEntity entity)
        {
            return await repository.InsertUserType(entity, "sp_ManageUserTypeInsert");
        }
        public async Task<ResultModel> UpdateUserType(UserTypeDataEntity entity)
        {
            return await repository.UpdateUserType(entity, "sp_ManageUserTypeInsert");
        }
        public async Task<ResultModel> DeleteUserType(UserTypeIDEntity entity)
        {
            return await repository.DeleteUserType(entity, "sp_ManageUserTypeFindDelete");
        }
        public async Task<UserTypeListEntity> FindByIDUserType(UserTypeIDEntity entity)
        {
            return await repository.FindByIDUserType(entity, "sp_ManageUserTypeFindDelete");
        }
        public async Task<List<UserTypeListEntity>> FindAllUserType(UserTypeIDEntity entity)
        {
            return await repository.FindAllUserType(entity, "sp_ManageUserTypeFindAll");
        }
        public async Task<List<UserTypeListEntity>> FindAllActiveUserType()
        {
            return await repository.FindAllActiveUserType("sp_ManageUserTypeFindAll");
        }
        public async Task<ResultModel> ActiveInActiveUserType(UserTypeIDEntity entity)
        {
            return await repository.ActiveInActiveUserType(entity, "sp_ManageUserTypeFindDelete");
        }
    }

}
