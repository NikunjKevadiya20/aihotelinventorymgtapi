using HotelBooking.Entity.Common.Entities;
using HotelBooking.Entity.Entities;

namespace HotelBooking.Domain.Interfaces
{
    public interface IRoomViewDomain
    {
        Task<ResultModel> InsertRoomView(RoomViewEntity entity);

        Task<ResultModel> UpdateRoomView(RoomViewEntity entity);
        Task<ResultModel> DeleteRoomView(RoomViewIDEntity entity);

        Task<RoomViewViewEntity> FindByIDRoomView(RoomViewIDEntity entity);

        Task<List<RoomViewViewEntity>> FindAllRoomView(RoomViewIDEntity entity);
        Task<List<RoomViewViewEntity>> FindAllActiveRoomView();

        Task<ResultModel> ActiveInActiveRoomView(RoomViewIDEntity entity);

    }
}
