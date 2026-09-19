using HotelBooking.DataAccess.Interfaces;
using HotelBooking.Domain.Interfaces;
using HotelBooking.Entity.Common.Entities;
using HotelBooking.Entity.Entities;

namespace HotelBooking.Domain.Domain
{
    public class RoomCategoryDomain : IRoomCategoryDomain
    {
        IRoomCategoryRepository repository;
        public RoomCategoryDomain(IRoomCategoryRepository _repository)
        {
            repository = _repository;
        }

        public async Task<ResultModel> InsertRoomCategory(RoomCategoryEntity entity)
        {
            return await repository.InsertRoomCategory(entity);
        }

        public async Task<ResultModel> UpdateRoomCategory(RoomCategoryEntity entity)
        {
            return await repository.UpdateRoomCategory(entity);
        }

        public async Task<ResultModel> DeleteRoomCategory(RoomCategoryIDEntity entity)
        {
            return await repository.DeleteRoomCategory(entity);
        }
        public async Task<RoomCategoryViewEntity> FindByIDRoomCategory(RoomCategoryIDEntity entity)
        {
            return await repository.FindByIDRoomCategory(entity);
        }
        public async Task<List<RoomCategoryViewEntity>> FindAllRoomCategory(RoomCategoryIDEntity entity)
        {
            return await repository.FindAllRoomCategory(entity);
        }
        public async Task<List<RoomCategoryViewEntity>> FindAllActiveRoomCategory()
        {
            return await repository.FindAllActiveRoomCategory();
        }

        public async Task<ResultModel> ActiveInActiveRoomCategory(RoomCategoryIDEntity entity)
        {
            return await repository.ActiveInActiveRoomCategory(entity);
        }

    }
}
