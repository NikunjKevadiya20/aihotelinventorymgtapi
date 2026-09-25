using HotelBooking.DataAccess.Interfaces;
using HotelBooking.Domain.Interfaces;
using HotelBooking.Entity.Common.Entities;
using HotelBooking.Entity.Entities;

namespace HotelBooking.Domain.Domain
{
    public class RoomStyleDomain : IRoomStyleDomain
    {
        IRoomStyleRepository repository;
        public RoomStyleDomain(IRoomStyleRepository _repository)
        {
            repository = _repository;
        }

        public async Task<ResultModel> InsertRoomStyle(RoomStyleEntity entity)
        {
            return await repository.InsertRoomStyle(entity);
        }

        public async Task<ResultModel> UpdateRoomStyle(RoomStyleEntity entity)
        {
            return await repository.UpdateRoomStyle(entity);
        }

        public async Task<ResultModel> DeleteRoomStyle(RoomStyleIDEntity entity)
        {
            return await repository.DeleteRoomStyle(entity);
        }
        public async Task<RoomStyleViewEntity> FindByIDRoomStyle(RoomStyleIDEntity entity)
        {
            return await repository.FindByIDRoomStyle(entity);
        }
        public async Task<List<RoomStyleViewEntity>> FindAllRoomStyle(RoomStyleIDEntity entity)
        {
            return await repository.FindAllRoomStyle(entity);
        }
        public async Task<List<RoomStyleViewEntity>> FindAllActiveRoomStyle()
        {
            return await repository.FindAllActiveRoomStyle();
        }

        public async Task<ResultModel> ActiveInActiveRoomStyle(RoomStyleIDEntity entity)
        {
            return await repository.ActiveInActiveRoomStyle(entity);
        }

    }
}
