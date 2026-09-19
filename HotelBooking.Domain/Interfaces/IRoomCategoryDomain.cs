using HotelBooking.Entity.Common.Entities;
using HotelBooking.Entity.Entities;

namespace HotelBooking.Domain.Interfaces
{
    public interface IRoomCategoryDomain
    {
        Task<ResultModel> InsertRoomCategory(RoomCategoryEntity entity);

        Task<ResultModel> UpdateRoomCategory(RoomCategoryEntity entity);
        Task<ResultModel> DeleteRoomCategory(RoomCategoryIDEntity entity);

        Task<RoomCategoryViewEntity> FindByIDRoomCategory(RoomCategoryIDEntity entity);

        Task<List<RoomCategoryViewEntity>> FindAllRoomCategory(RoomCategoryIDEntity entity);
        Task<List<RoomCategoryViewEntity>> FindAllActiveRoomCategory();

        Task<ResultModel> ActiveInActiveRoomCategory(RoomCategoryIDEntity entity);

    }
}
