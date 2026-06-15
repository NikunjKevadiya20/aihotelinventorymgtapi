using HotelBooking.DataAccess.Interfaces;
using HotelBooking.Domain.Interfaces;
using HotelBooking.Entity.Common.Entities;
using HotelBooking.Entity.Entities;

namespace HotelBooking.Domain.Domains
{
    /// <summary>
    /// Added by NikunjK on 01-08-2023
    /// </summary>
    public class UserDomain : IUserDomain
    {
        IUserRepository repository;
        public UserDomain(IUserRepository _repository)
        {
            repository = _repository;
        }
        public async Task<UserIDView> InsertUser(UsersDataEntity entity)
        {
            return await repository.InsertUser(entity);
        }
        public async Task<ResultModel> UpdateUser(UsersDataEntity entity)
        {
            return await repository.UpdateUser(entity);
        }
        public async Task<ResultModel> DeleteUser(UserIDEntity entity)
        {
            return await repository.DeleteUser(entity);
        }
        public async Task<UsersListEntity> FindByIDUser(UserIDEntity entity)
        {
            return await repository.FindByIDUser(entity);
        }
        public async Task<List<UsersListEntity>> FindAllUser(UserIDEntity entity)
        {
            return await repository.FindAllUser(entity);
        }
        public async Task<List<UsersListEntity>> FindAllActiveUser()
        {
            return await repository.FindAllActiveUser();
        }
        public async Task<ResultModel> ActiveInActiveUser(UserIDEntity entity)
        {
            return await repository.ActiveInActiveUser(entity);
        }
        public async Task<UserImageListEntity> UserImageUpdate(string? physicalFileName, int? ID, int? UpdatedBy)
        {
            return await repository.UserImageUpdate(physicalFileName, ID, UpdatedBy);
        }
    }
}
