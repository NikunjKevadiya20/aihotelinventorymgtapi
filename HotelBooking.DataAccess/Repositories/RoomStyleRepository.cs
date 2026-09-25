using HotelBooking.DataAccess.Base;
using HotelBooking.DataAccess.Interfaces;
using HotelBooking.Entity.Common.Entities;
using HotelBooking.Entity.Entities;

namespace HotelBooking.DataAccess.Repositories
{
    public class RoomStyleRepository : IRoomStyleRepository
    {
        IRoomStyleLookupRepositoryInterface repository;

        public RoomStyleRepository(IRoomStyleLookupRepositoryInterface _repository)
        {
            repository = _repository;
        }

        public async Task<ResultModel> InsertRoomStyle(RoomStyleEntity entity)
        {
            return await repository.InsertRoomStyle(entity, "sp_ManageRoomStyleInsert");
        }
        public async Task<ResultModel> UpdateRoomStyle(RoomStyleEntity entity)
        {
            return await repository.UpdateRoomStyle(entity, "sp_ManageRoomStyleInsert");
        }
        public async Task<ResultModel> DeleteRoomStyle(RoomStyleIDEntity entity)
        {
            return await repository.DeleteRoomStyle(entity, "sp_ManageRoomStyleDetails");
        }
        public async Task<RoomStyleViewEntity> FindByIDRoomStyle(RoomStyleIDEntity entity)
        {
            return await repository.FindByIDRoomStyle(entity, "sp_ManageRoomStyleDetails");
        }
        public async Task<List<RoomStyleViewEntity>> FindAllRoomStyle(RoomStyleIDEntity entity)
        {
            return await repository.FindAllRoomStyle(entity, "sp_ManageRoomStyleFindAllActive");
        }
        public async Task<List<RoomStyleViewEntity>> FindAllActiveRoomStyle()
        {
            return await repository.FindAllActiveRoomStyle("sp_ManageRoomStyleFindAllActive");
        }
        public async Task<ResultModel> ActiveInActiveRoomStyle(RoomStyleIDEntity entity)
        {
            return await repository.ActiveInActiveRoomStyle(entity, "sp_ManageRoomStyleDetails");
        }


    }
}
