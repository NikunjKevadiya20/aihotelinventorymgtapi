using HotelBooking.Entity.Common.Entities;
using HotelBooking.Entity.Entities;


namespace HotelBooking.DataAccess.Base
{
    public interface IRoomStyleLookupRepositoryInterface
    {
        Task<ResultModel> InsertRoomStyle(RoomStyleEntity entity, string storedProcedure);
        Task<ResultModel> UpdateRoomStyle(RoomStyleEntity entity, string storedProcedure);
        Task<ResultModel> DeleteRoomStyle(RoomStyleIDEntity entity, string storedProcedure);
        Task<RoomStyleViewEntity> FindByIDRoomStyle(RoomStyleIDEntity entity, string storedProcedure);
        Task<List<RoomStyleViewEntity>> FindAllRoomStyle(RoomStyleIDEntity entity, string storedProcedure);
        Task<List<RoomStyleViewEntity>> FindAllActiveRoomStyle(string storedProcedure);

        Task<ResultModel> ActiveInActiveRoomStyle(RoomStyleIDEntity entity, string storedProcedure);


    }
}
