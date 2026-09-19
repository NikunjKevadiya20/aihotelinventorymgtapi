using HotelBooking.Entity.Common.Entities;
using HotelBooking.Entity.Entities;


namespace HotelBooking.DataAccess.Base
{
    public interface IRoomCategoryLookupRepositoryInterface
    {
        Task<ResultModel> InsertRoomCategory(RoomCategoryEntity entity, string storedProcedure);
        Task<ResultModel> UpdateRoomCategory(RoomCategoryEntity entity, string storedProcedure);
        Task<ResultModel> DeleteRoomCategory(RoomCategoryIDEntity entity, string storedProcedure);
        Task<RoomCategoryViewEntity> FindByIDRoomCategory(RoomCategoryIDEntity entity, string storedProcedure);
        Task<List<RoomCategoryViewEntity>> FindAllRoomCategory(RoomCategoryIDEntity entity, string storedProcedure);
        Task<List<RoomCategoryViewEntity>> FindAllActiveRoomCategory(string storedProcedure);

        Task<ResultModel> ActiveInActiveRoomCategory(RoomCategoryIDEntity entity, string storedProcedure);


    }
}
