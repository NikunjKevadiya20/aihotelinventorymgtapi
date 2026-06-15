using HotelBooking.Entity.Common.Entities;
using HotelBooking.Entity.Entities;

namespace HotelBooking.DataAccess.Base
{
    /// <summary>
    /// Added by NikunjK on 01-08-2023
    /// </summary>
    public interface IHotelsLookupRepositoryInterface
    {
        Task<HotelResEntity> InsertHotels(HotelsDataEntity entity, string storedProcedure);
        Task<HotelResEntity> UpdateHotels(HotelsDataEntity entity, string storedProcedure);
        Task<ResultModel> DeleteHotels(HotelsIDEntity entity, string storedProcedure);
        Task<ResultModel> DeleteHotelImage(HotelsIDEntity entity, string storedProcedure);
        Task<HotelsFindByViewEntity> FindByIDHotels(HotelsIDEntity entity, string storedProcedure);
        Task<List<HotelsViewEntity>> FindAllHotels(HotelsIDEntity entity, string storedProcedure);
        Task<List<HotelsViewEntity>> FindAllActiveHotels(HotelsAvailabilityEntity entity,string storedProcedure);
        Task<ResultModel> ActiveInActiveHotels(HotelsIDEntity entity, string storedProcedure);
        Task<ResultModel> BulkUploadHotelData(List<Hotel> Hotel, List<HotelRateSpecialDate> rate, string storedProcedure);
        Task<ResultModel> BulkUploadHotelDataNew(List<HotelExcelExport> Hotel, List<HotelRateSpecialDateNew> rate, string storedProcedure);

        Task<ResultModel> HotelImageUpdate(HotelImageEntity entity, string storedProcedure);
        Task<HotelsFindByViewEntity> FindByURLHotels(HotelsIDEntity entity, string storedProcedure);
        Task<List<HotelsViewEntity>> HotelsListForWebsite(HotelsIDEntity entity, string storedProcedure);
        Task<List<HotelsViewEntity>> FindAllHotelsForDropdown(HotelsIDEntity entity, string storedProcedure);
        Task<List<HotelSearchForWebsite>> HotelSearchForWebsite(HotelsIDEntity entity, string storedProcedure);
        Task<List<HotelsCity>> CityListForWebsite(string storedProcedure);

        Task<ResultModel> InsertHotelRoomAvalability(HotelRoomEntity entity, string storedProcedure);
        Task<List<HotelRoomViewEntity>> FindAllHotelRoomAvalability(HotelsIDEntity entity, string storedProcedure);

        Task<ResultModel> InsertHotelPriceRange(HotelPriceRangeEntity entity, string storedProcedure);
        Task<List<HotelPriceRangeViewEntity>> FindAllHotelPriceRange(HotelPriceEntity entity, string storedProcedure);
        Task<HotelRoomPriceViewEntity> FindAllAvailableHotelRoomPrice(HotelsIDEntity entity, string storedProcedure);

        Task<List<HotelPriceRangeViewEntity>> FindAllHotelPriceTicketAvaibility(HotelPriceEntity entity, string storedProcedure);
        Task<List<HotelPriceRangeViewEntity>> HotelPriceByHotelRoom(HotelPriceEntity entity, string storedProcedure);
        Task<ResultModel> InsertHotelBookingPackagePrice(HotelBookingPackagePriceEntity entity, string storedProcedure);
        Task<List<HotelBookingPackagePriceViewEntity>> FindAllHotelBookingPackagePrice(HotelBookingPackagePriceEntity entity, string storedProcedure);

    }
}

