using HotelBooking.Entity.Common.Entities;
using HotelBooking.Entity.Entities;

namespace HotelBooking.DataAccess.Base
{
    public interface IRoomTypeLookupRepositoryInterface
    {

        Task<ResultModel> InsertRoomType(RoomTypeDataEntity entity, string storedProcedure);
        Task<ResultModel> UpdateRoomType(RoomTypeDataEntity entity, string storedProcedure);
        Task<ResultModel> UpdateRoomTypeOccupancy(RoomTypeDataEntity entity, string storedProcedure);
        Task<ResultModel> UpdateRoomTypeAmenities(RoomTypeDataEntity entity, string storedProcedure);
        Task<ResultModel> DeleteRoomType(RoomTypeIDEntity entity, string storedProcedure);
        Task<RoomTypeViewEntity> FindByIDRoomType(RoomTypeIDEntity entity, string storedProcedure);
        Task<List<RoomTypeViewEntity>> FindAllRoomType(RoomTypeIDEntity entity, string storedProcedure);
        Task<List<RoomTypeViewEntity>> FindAllActiveRoomType(string storedProcedure);
        Task<ResultModel> ActiveInActiveRoomType(RoomTypeIDEntity entity, string storedProcedure);
        Task<ResultModel> RoomTypeImageUpload(string? image, List<string> imageList,int? roomTypeID, int? updatedBy);
        Task<ResultModel> CommonImageUpload(string? image, string? altTag, string? title, int? updatedBy);
        Task<ResultModel> DeleteImage(DeleteImageEntity entity, string storedProcedure);
        Task<List<RoomTypeImageViewEntity>> FindAllRoomTypeImage(RoomTypeIDEntity entity, string storedProcedure);
        Task<ResultModel> InsertRoomTypeBed(RoomTypeBed entity, string storedProcedure);
        Task<ResultModel> UpdateRoomTypeBed(RoomTypeBed entity, string storedProcedure);
        Task<ResultModel> DeleteRoomTypeBed(RoomTypeBed entity, string storedProcedure);
        Task<List<RoomTypeBedViewEntity>> FindAllRoomTypeBed(string storedProcedure);

    }
}
