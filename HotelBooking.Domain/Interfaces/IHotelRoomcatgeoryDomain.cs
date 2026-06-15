
using HotelBooking.Entity.Common.Entities;
using HotelBooking.Entity.Entities;

namespace HotelBooking.Domain.Interfaces
{
    public interface IHotelRoomcatgeoryDomain
    {
        Task<ResultModel> InsertHotelRoomcatgeory(HotelRoomcatgeoryDataEntity city, List<string>? otherImages);

        Task<ResultModel> UpdateHotelRoomcatgeory(HotelRoomcatgeoryDataEntity city, List<string>? otherImages);

        Task<ResultModel> DeleteHotelRoomcatgeory(HotelRoomcatgeoryIDEntity city);

        Task<HotelRoomcatgeoryViewEntity> FindByIDHotelRoomcatgeory(HotelRoomcatgeoryIDEntity entity);
        Task<List<HotelRoomcatgeoryViewEntity>> FindByHotelIDHotelRoomcatgeory(HotelRoomcatgeoryIDEntity entity);
        Task<List<HotelRoomcatgeoryViewEntity>> FindAllActiveHotelRoomcatgeory(HotelRoomcatgeoryIDEntity entity);

        Task<ResultModel> ActiveInActiveHotelRoomcatgeory(HotelRoomcatgeoryIDEntity entity);

        Task<ResultModel> RoomCategoryImageUpload(List<string> otherImages, int? RoomCategoryID);
        Task<ResultModel> DeleteRoomCategoryImage(HotelRoomcatgeoryIDEntity city);


    }
}
