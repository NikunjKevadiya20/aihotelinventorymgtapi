using HotelBooking.Entity.Common.Entities;
using HotelBooking.Entity.Entities;

namespace HotelBooking.DataAccess.Base
{
    public interface IHotelRoomcatgeoryLookupRepositoryInterface
    {

        Task<ResultModel> InsertHotelRoomcatgeory(HotelRoomcatgeoryDataEntity entity, List<string>? otherImages, string storedProcedure);
        Task<ResultModel> UpdateHotelRoomcatgeory(HotelRoomcatgeoryDataEntity entity, List<string>? otherImages, string storedProcedure);
        Task<ResultModel> DeleteHotelRoomcatgeory(HotelRoomcatgeoryIDEntity entity, string storedProcedure);
        Task<HotelRoomcatgeoryViewEntity> FindByIDHotelRoomcatgeory(HotelRoomcatgeoryIDEntity entity, string storedProcedure);
        Task<List<HotelRoomcatgeoryViewEntity>> FindByHotelIDHotelRoomcatgeory(HotelRoomcatgeoryIDEntity entity, string storedProcedure);
        Task<List<HotelRoomcatgeoryViewEntity>> FindAllActiveHotelRoomcatgeory(HotelRoomcatgeoryIDEntity entity, string storedProcedure);
        Task<ResultModel> ActiveInActiveHotelRoomcatgeory(HotelRoomcatgeoryIDEntity entity, string storedProcedure);
        Task<ResultModel> RoomCategoryImageUpload(List<string> otherImages, int? RoomCategoryID);
        Task<ResultModel> DeleteRoomCategoryImage(HotelRoomcatgeoryIDEntity entity, string storedProcedure);

    }
}
