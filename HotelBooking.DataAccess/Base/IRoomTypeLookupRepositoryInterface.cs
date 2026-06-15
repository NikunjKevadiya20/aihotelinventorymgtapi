using HotelBooking.Entity.Common.Entities;
using HotelBooking.Entity.Entities;

namespace HotelBooking.DataAccess.Base
{
    public interface IRoomTypeLookupRepositoryInterface
    {

        Task<ResultModel> InsertRoomType(RoomTypeDataEntity entity, string storedProcedure);
        Task<ResultModel> UpdateRoomType(RoomTypeDataEntity entity, string storedProcedure);
        Task<ResultModel> DeleteRoomType(RoomTypeIDEntity entity, string storedProcedure);
        Task<RoomTypeViewEntity> FindByIDRoomType(RoomTypeIDEntity entity, string storedProcedure);
        Task<List<RoomTypeViewEntity>> FindAllRoomType(RoomTypeIDEntity entity, string storedProcedure);
        Task<List<RoomTypeViewEntity>> FindAllActiveRoomType(string storedProcedure);
        Task<ResultModel> ActiveInActiveRoomType(RoomTypeIDEntity entity, string storedProcedure);

    }
}
