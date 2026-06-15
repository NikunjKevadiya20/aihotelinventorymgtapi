using HotelBooking.Entity.Common.Entities;
using HotelBooking.Entity.Entities;

namespace HotelBooking.DataAccess.Interfaces
{
    public interface IRoomTypeRepository
    {

        Task<ResultModel> InsertRoomType(RoomTypeDataEntity entity);
        Task<ResultModel> UpdateRoomType(RoomTypeDataEntity entity);
        Task<ResultModel> DeleteRoomType(RoomTypeIDEntity entity);
        Task<RoomTypeViewEntity> FindByIDRoomType(RoomTypeIDEntity entity);
        Task<List<RoomTypeViewEntity>> FindAllRoomType(RoomTypeIDEntity entity);
        Task<List<RoomTypeViewEntity>> FindAllActiveRoomType();
        Task<ResultModel> ActiveInActiveRoomType(RoomTypeIDEntity entity);

    }
}
