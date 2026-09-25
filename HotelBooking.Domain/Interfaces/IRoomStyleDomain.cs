using HotelBooking.Entity.Common.Entities;
using HotelBooking.Entity.Entities;

namespace HotelBooking.Domain.Interfaces
{
    public interface IRoomStyleDomain
    {
        Task<ResultModel> InsertRoomStyle(RoomStyleEntity entity);

        Task<ResultModel> UpdateRoomStyle(RoomStyleEntity entity);
        Task<ResultModel> DeleteRoomStyle(RoomStyleIDEntity entity);

        Task<RoomStyleViewEntity> FindByIDRoomStyle(RoomStyleIDEntity entity);

        Task<List<RoomStyleViewEntity>> FindAllRoomStyle(RoomStyleIDEntity entity);
        Task<List<RoomStyleViewEntity>> FindAllActiveRoomStyle();

        Task<ResultModel> ActiveInActiveRoomStyle(RoomStyleIDEntity entity);

    }
}
