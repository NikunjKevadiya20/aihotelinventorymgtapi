using HotelBooking.DataAccess.Base;
using HotelBooking.DataAccess.Interfaces;
using HotelBooking.Entity.Common.Entities;
using HotelBooking.Entity.Entities;

namespace HotelBooking.DataAccess.Repositories
{
    public class RoomViewRepository : IRoomViewRepository
    {
        IRoomViewLookupRepositoryInterface repository;

        public RoomViewRepository(IRoomViewLookupRepositoryInterface _repository)
        {
            repository = _repository;
        }

        public async Task<ResultModel> InsertRoomView(RoomViewEntity entity)
        {
            return await repository.InsertRoomView(entity, "sp_ManageRoomViewInsert");
        }
        public async Task<ResultModel> UpdateRoomView(RoomViewEntity entity)
        {
            return await repository.UpdateRoomView(entity, "sp_ManageRoomViewInsert");
        }
        public async Task<ResultModel> DeleteRoomView(RoomViewIDEntity entity)
        {
            return await repository.DeleteRoomView(entity, "sp_ManageRoomViewDetails");
        }
        public async Task<RoomViewViewEntity> FindByIDRoomView(RoomViewIDEntity entity)
        {
            return await repository.FindByIDRoomView(entity, "sp_ManageRoomViewDetails");
        }
        public async Task<List<RoomViewViewEntity>> FindAllRoomView(RoomViewIDEntity entity)
        {
            return await repository.FindAllRoomView(entity, "sp_ManageRoomViewFindAllActive");
        }
        public async Task<List<RoomViewViewEntity>> FindAllActiveRoomView()
        {
            return await repository.FindAllActiveRoomView("sp_ManageRoomViewFindAllActive");
        }
        public async Task<ResultModel> ActiveInActiveRoomView(RoomViewIDEntity entity)
        {
            return await repository.ActiveInActiveRoomView(entity, "sp_ManageRoomViewDetails");
        }


    }
}
