using HotelBooking.DataAccess.Interfaces;
using HotelBooking.Domain.Interfaces;
using HotelBooking.Entity.Common.Entities;
using HotelBooking.Entity.Entities;

namespace HotelBooking.Domain.Domains
{
    /// <summary>
    /// Added by NikunjK on 01-08-2023
    /// </summary>
    public class UserTypeDomain : IUserTypeDomain
    {
        IUserTypeRepository repository;
        public UserTypeDomain(IUserTypeRepository _repository)
        {
            repository = _repository;
        }
        public async Task<UserIDView> InsertUserType(UserTypeDataEntity entity)
        {
            return await repository.InsertUserType(entity);
        }
        public async Task<ResultModel> UpdateUserType(UserTypeDataEntity entity)
        {
            return await repository.UpdateUserType(entity);
        }
        public async Task<ResultModel> DeleteUserType(UserTypeIDEntity entity)
        {
            return await repository.DeleteUserType(entity);
        }
        public async Task<UserTypeListEntity> FindByIDUserType(UserTypeIDEntity entity)
        {
            return await repository.FindByIDUserType(entity);
        }
        public async Task<List<UserTypeListEntity>> FindAllUserType(UserTypeIDEntity entity)
        {
            return await repository.FindAllUserType(entity);
        }
        public async Task<List<UserTypeListEntity>> FindAllActiveUserType()
        {
            return await repository.FindAllActiveUserType();
        }
        public async Task<ResultModel> ActiveInActiveUserType(UserTypeIDEntity entity)
        {
            return await repository.ActiveInActiveUserType(entity);
        }
    }
}
