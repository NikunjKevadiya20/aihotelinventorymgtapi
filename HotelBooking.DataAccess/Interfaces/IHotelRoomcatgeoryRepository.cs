using HotelBooking.Entity.Common.Entities;
using HotelBooking.Entity.Entities;

namespace HotelBooking.DataAccess.Interfaces
{
    public interface IHotelRoomcatgeoryRepository
    {
        Task<ResultModel> InsertHotelRoomcatgeory(HotelRoomcatgeoryDataEntity entity, List<string>? otherImages);
        Task<ResultModel> UpdateHotelRoomcatgeory(HotelRoomcatgeoryDataEntity entity, List<string>? otherImages);
        Task<ResultModel> DeleteHotelRoomcatgeory(HotelRoomcatgeoryIDEntity entity);
        Task<HotelRoomcatgeoryViewEntity> FindByIDHotelRoomcatgeory(HotelRoomcatgeoryIDEntity entity);
        Task<List<HotelRoomcatgeoryViewEntity>> FindByHotelIDHotelRoomcatgeory(HotelRoomcatgeoryIDEntity entity);
        Task<List<HotelRoomcatgeoryViewEntity>> FindAllActiveHotelRoomcatgeory(HotelRoomcatgeoryIDEntity entity);
        Task<ResultModel> ActiveInActiveHotelRoomcatgeory(HotelRoomcatgeoryIDEntity entity);
        Task<ResultModel> RoomCategoryImageUpload(List<string> otherImages, int? RoomCategoryID);
        Task<ResultModel> DeleteRoomCategoryImage(HotelRoomcatgeoryIDEntity entity);

    }
}
