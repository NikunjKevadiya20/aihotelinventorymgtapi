using HotelBooking.DataAccess.Interfaces;
using HotelBooking.Domain.Interfaces;
using HotelBooking.Entity.Common.Entities;
using HotelBooking.Entity.Entities;

namespace HotelBooking.Domain.Domain
{
    public class RoomTypeDomain : IRoomTypeDomain
    {
        IRoomTypeRepository repository;
        public RoomTypeDomain(IRoomTypeRepository _repository)
        {
            repository = _repository;
        }
        public async Task<ResultModel> InsertRoomType(RoomTypeDataEntity entity)
        {
            return await repository.InsertRoomType(entity);
        }
        public async Task<ResultModel> UpdateRoomType(RoomTypeDataEntity entity)
        {
            return await repository.UpdateRoomType(entity);
        }
        public async Task<ResultModel> DeleteRoomType(RoomTypeIDEntity entity)
        {
            return await repository.DeleteRoomType(entity);
        }
        public async Task<RoomTypeViewEntity> FindByIDRoomType(RoomTypeIDEntity entity)
        {
            return await repository.FindByIDRoomType(entity);
        }
        public async Task<List<RoomTypeViewEntity>> FindAllRoomType(RoomTypeIDEntity entity)
        {
            return await repository.FindAllRoomType(entity);
        }
        public async Task<List<RoomTypeViewEntity>> FindAllActiveRoomType()
        {
            return await repository.FindAllActiveRoomType();
        }
        public async Task<ResultModel> ActiveInActiveRoomType(RoomTypeIDEntity entity)
        {
            return await repository.ActiveInActiveRoomType(entity);
        }
    }
}
