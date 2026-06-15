using HotelBooking.DataAccess.Base;
using HotelBooking.DataAccess.Interfaces;
using HotelBooking.Entity.Common.Entities;
using HotelBooking.Entity.Entities;

namespace HotelBooking.DataAccess.Repositories
{
    public class HotelRoomcatgeoryRepository : IHotelRoomcatgeoryRepository
    {
        IHotelRoomcatgeoryLookupRepositoryInterface repository;

        public HotelRoomcatgeoryRepository(IHotelRoomcatgeoryLookupRepositoryInterface _repository)
        {
            repository = _repository;
        }
        public async Task<ResultModel> InsertHotelRoomcatgeory(HotelRoomcatgeoryDataEntity entity, List<string>? otherImages)
        {
            return await repository.InsertHotelRoomcatgeory(entity, otherImages, "sp_ManageHotelRoomCategoriesInsert");
        }

        public async Task<ResultModel> UpdateHotelRoomcatgeory(HotelRoomcatgeoryDataEntity entity, List<string>? otherImages)
        {
            return await repository.UpdateHotelRoomcatgeory(entity, otherImages, "sp_ManageHotelRoomCategoriesInsert");
        }
        public async Task<ResultModel> DeleteHotelRoomcatgeory(HotelRoomcatgeoryIDEntity entity)
        {
            return await repository.DeleteHotelRoomcatgeory(entity, "sp_ManageHotelRoomCategoriesFindByID");
        }
        public async Task<HotelRoomcatgeoryViewEntity> FindByIDHotelRoomcatgeory(HotelRoomcatgeoryIDEntity entity)
        {
            return await repository.FindByIDHotelRoomcatgeory(entity, "sp_ManageHotelRoomCategoriesFindByID");
        }
        public async Task<List<HotelRoomcatgeoryViewEntity>> FindByHotelIDHotelRoomcatgeory(HotelRoomcatgeoryIDEntity entity)
        {
            return await repository.FindByHotelIDHotelRoomcatgeory(entity, "sp_ManageHotelRoomCategoriesFindByID");
        }
        public async Task<List<HotelRoomcatgeoryViewEntity>> FindAllActiveHotelRoomcatgeory(HotelRoomcatgeoryIDEntity entity)
        {
            return await repository.FindAllActiveHotelRoomcatgeory(entity, "sp_ManageHotelRoomCategoriesFindAllActive");
        }
        public async Task<ResultModel> ActiveInActiveHotelRoomcatgeory(HotelRoomcatgeoryIDEntity entity)
        {
            return await repository.ActiveInActiveHotelRoomcatgeory(entity, "sp_ManageHotelRoomCategoriesFindByID");
        }
        public async Task<ResultModel> RoomCategoryImageUpload(List<string> otherImages, int? RoomCategoryID)
        {
            return await repository.RoomCategoryImageUpload(otherImages, RoomCategoryID);
        }

        public async Task<ResultModel> DeleteRoomCategoryImage(HotelRoomcatgeoryIDEntity entity)
        {
            return await repository.DeleteRoomCategoryImage(entity, "sp_ManageHotelRoomCategoriesInsert");
        }

    }
}
