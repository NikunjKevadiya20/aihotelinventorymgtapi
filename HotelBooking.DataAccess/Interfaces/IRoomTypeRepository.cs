using HotelBooking.Entity.Common.Entities;
using HotelBooking.Entity.Entities;

namespace HotelBooking.DataAccess.Interfaces
{
    public interface IRoomTypeRepository
    {

        Task<ResultModel> InsertRoomType(RoomTypeDataEntity entity);
        Task<ResultModel> UpdateRoomType(RoomTypeDataEntity entity);
        Task<ResultModel> UpdateRoomTypeOccupancy(RoomTypeDataEntity entity);
        Task<ResultModel> UpdateRoomTypeAmenities(RoomTypeDataEntity entity);
        Task<ResultModel> DeleteRoomType(RoomTypeIDEntity entity);
        Task<RoomTypeViewEntity> FindByIDRoomType(RoomTypeIDEntity entity);
        Task<List<RoomTypeViewEntity>> FindAllRoomType(RoomTypeIDEntity entity);
        Task<List<RoomTypeViewEntity>> FindAllActiveRoomType();
        Task<ResultModel> ActiveInActiveRoomType(RoomTypeIDEntity entity);
        Task<ResultModel> RoomTypeImageUpload(string? image, List<string> imageList, int? roomTypeID, int? updatedBy);
        Task<ResultModel> DeleteImage(DeleteImageEntity entity);
        Task<List<RoomTypeImageViewEntity>> FindAllRoomTypeImage(RoomTypeIDEntity entity);
        Task<ResultModel> CommonImageUpload(string? image, string? altTag, string? title, int? updatedBy);
        Task<ResultModel> InsertRoomTypeBed(RoomTypeBed entity);
        Task<ResultModel> UpdateRoomTypeBed(RoomTypeBed entity);
        Task<ResultModel> DeleteRoomTypeBed(RoomTypeBed entity);
        Task<List<RoomTypeBedViewEntity>> FindAllRoomTypeBed();
    }
}
