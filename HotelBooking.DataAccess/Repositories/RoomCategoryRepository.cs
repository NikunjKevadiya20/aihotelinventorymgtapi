using HotelBooking.DataAccess.Base;
using HotelBooking.DataAccess.Interfaces;
using HotelBooking.Entity.Common.Entities;
using HotelBooking.Entity.Entities;

namespace HotelBooking.DataAccess.Repositories
{
    public class RoomCategoryRepository : IRoomCategoryRepository
    {
        IRoomCategoryLookupRepositoryInterface repository;

        public RoomCategoryRepository(IRoomCategoryLookupRepositoryInterface _repository)
        {
            repository = _repository;
        }

        public async Task<ResultModel> InsertRoomCategory(RoomCategoryEntity entity)
        {
            return await repository.InsertRoomCategory(entity, "sp_ManageRoomCategoryInsert");
        }
        public async Task<ResultModel> UpdateRoomCategory(RoomCategoryEntity entity)
        {
            return await repository.UpdateRoomCategory(entity, "sp_ManageRoomCategoryInsert");
        }
        public async Task<ResultModel> DeleteRoomCategory(RoomCategoryIDEntity entity)
        {
            return await repository.DeleteRoomCategory(entity, "sp_ManageRoomCategoryFindByID");
        }
        public async Task<RoomCategoryViewEntity> FindByIDRoomCategory(RoomCategoryIDEntity entity)
        {
            return await repository.FindByIDRoomCategory(entity, "sp_ManageRoomCategoryFindByID");
        }
        public async Task<List<RoomCategoryViewEntity>> FindAllRoomCategory(RoomCategoryIDEntity entity)
        {
            return await repository.FindAllRoomCategory(entity, "sp_ManageRoomCategoryFindAllActive");
        }
        public async Task<List<RoomCategoryViewEntity>> FindAllActiveRoomCategory()
        {
            return await repository.FindAllActiveRoomCategory("sp_ManageRoomCategoryFindAllActive");
        }
        public async Task<ResultModel> ActiveInActiveRoomCategory(RoomCategoryIDEntity entity)
        {
            return await repository.ActiveInActiveRoomCategory(entity, "sp_ManageRoomCategoryFindByID");
        }


    }
}
