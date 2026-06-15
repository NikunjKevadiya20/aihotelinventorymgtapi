using HotelBooking.DataAccess.Base;
using HotelBooking.DataAccess.Interfaces;
using HotelBooking.Entity.Common.Entities;
using HotelBooking.Entity.Entities;

namespace HotelBooking.DataAccess.Repositories
{
    public class RoomTypeRepository : IRoomTypeRepository
    {
        IRoomTypeLookupRepositoryInterface repository;
        public RoomTypeRepository(IRoomTypeLookupRepositoryInterface _repository)
        {
            repository = _repository;
        }
        public async Task<ResultModel> InsertRoomType(RoomTypeDataEntity entity)
        {
            return await repository.InsertRoomType(entity, "sp_ManageRoomType");
        }
        public async Task<ResultModel> UpdateRoomType(RoomTypeDataEntity entity)
        {
            return await repository.UpdateRoomType(entity, "sp_ManageRoomType");
        }
        public async Task<ResultModel> DeleteRoomType(RoomTypeIDEntity entity)
        {
            return await repository.DeleteRoomType(entity, "sp_ManageRoomType");
        }
        public async Task<RoomTypeViewEntity> FindByIDRoomType(RoomTypeIDEntity entity)
        {
            return await repository.FindByIDRoomType(entity, "sp_ManageRoomType");
        }
        public async Task<List<RoomTypeViewEntity>> FindAllRoomType(RoomTypeIDEntity entity)
        {
            return await repository.FindAllRoomType(entity, "sp_ManageRoomType");
        }
        public async Task<List<RoomTypeViewEntity>> FindAllActiveRoomType()
        {
            return await repository.FindAllActiveRoomType("sp_ManageRoomType");
        }
        public async Task<ResultModel> ActiveInActiveRoomType(RoomTypeIDEntity entity)
        {
            return await repository.ActiveInActiveRoomType(entity, "sp_ManageRoomType");
        }

    }
}
