using HotelBooking.Entity.Common.Entities;
using HotelBooking.Entity.Entities;


namespace HotelBooking.DataAccess.Base
{
    public interface IRoomViewLookupRepositoryInterface
    {
        Task<ResultModel> InsertRoomView(RoomViewEntity entity, string storedProcedure);
        Task<ResultModel> UpdateRoomView(RoomViewEntity entity, string storedProcedure);
        Task<ResultModel> DeleteRoomView(RoomViewIDEntity entity, string storedProcedure);
        Task<RoomViewViewEntity> FindByIDRoomView(RoomViewIDEntity entity, string storedProcedure);
        Task<List<RoomViewViewEntity>> FindAllRoomView(RoomViewIDEntity entity, string storedProcedure);
        Task<List<RoomViewViewEntity>> FindAllActiveRoomView(string storedProcedure);

        Task<ResultModel> ActiveInActiveRoomView(RoomViewIDEntity entity, string storedProcedure);


    }
}
