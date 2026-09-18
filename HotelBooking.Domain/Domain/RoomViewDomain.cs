using HotelBooking.DataAccess.Interfaces;
using HotelBooking.Domain.Interfaces;
using HotelBooking.Entity.Common.Entities;
using HotelBooking.Entity.Entities;

namespace HotelBooking.Domain.Domain
{
    public class RoomViewDomain : IRoomViewDomain
    {
        IRoomViewRepository repository;
        public RoomViewDomain(IRoomViewRepository _repository)
        {
            repository = _repository;
        }

        public async Task<ResultModel> InsertRoomView(RoomViewEntity entity)
        {
            return await repository.InsertRoomView(entity);
        }

        public async Task<ResultModel> UpdateRoomView(RoomViewEntity entity)
        {
            return await repository.UpdateRoomView(entity);
        }

        public async Task<ResultModel> DeleteRoomView(RoomViewIDEntity entity)
        {
            return await repository.DeleteRoomView(entity);
        }
        public async Task<RoomViewViewEntity> FindByIDRoomView(RoomViewIDEntity entity)
        {
            return await repository.FindByIDRoomView(entity);
        }
        public async Task<List<RoomViewViewEntity>> FindAllRoomView(RoomViewIDEntity entity)
        {
            return await repository.FindAllRoomView(entity);
        }
        public async Task<List<RoomViewViewEntity>> FindAllActiveRoomView()
        {
            return await repository.FindAllActiveRoomView();
        }

        public async Task<ResultModel> ActiveInActiveRoomView(RoomViewIDEntity entity)
        {
            return await repository.ActiveInActiveRoomView(entity);
        }

    }
}
