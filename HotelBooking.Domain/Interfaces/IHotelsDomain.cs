using HotelBooking.Entity.Common.Entities;
using HotelBooking.Entity.Entities;

namespace HotelBooking.Domain.Interfaces
{
    /// <summary>
    /// Added by NikunjK on 01-08-2023
    /// </summary>
    public interface IHotelsDomain
    {
        Task<HotelResEntity> InsertHotels(HotelsDataEntity entity);
        Task<HotelResEntity> UpdateHotels(HotelsDataEntity entity);
        Task<ResultModel> DeleteHotels(HotelsIDEntity entity);
        Task<ResultModel> DeleteHotelImage(HotelsIDEntity entity);
        Task<HotelsFindByViewEntity> FindByIDHotels(HotelsIDEntity entity);
        Task<List<HotelsViewEntity>> FindAllHotels(HotelsIDEntity entity);
        Task<List<HotelsViewEntity>> FindAllActiveHotels(HotelsAvailabilityEntity entity);
        Task<ResultModel> ActiveInActiveHotels(HotelsIDEntity entity);
        Task<ResultModel> BulkUploadHotelData(List<Hotel> Hotel, List<HotelRateSpecialDate> rate);
        Task<ResultModel> BulkUploadHotelDataNew(List<HotelExcelExport> Hotel, List<HotelRateSpecialDateNew> rate);

        Task<ResultModel> HotelImageUpdate(HotelImageEntity entity);
        Task<HotelsFindByViewEntity> FindByURLHotels(HotelsIDEntity entity);
        Task<List<HotelsViewEntity>> HotelsListForWebsite(HotelsIDEntity entity);
        Task<List<HotelsViewEntity>> FindAllHotelsForDropdown(HotelsIDEntity entity);
        Task<List<HotelSearchForWebsite>> HotelSearchForWebsite(HotelsIDEntity entity);
        Task<List<HotelsCity>> CityListForWebsite();
        Task<ResultModel> InsertHotelRoomAvalability(HotelRoomEntity entity);
        Task<List<HotelRoomViewEntity>> FindAllHotelRoomAvalability(HotelsIDEntity entity);

        Task<ResultModel> InsertHotelPriceRange(HotelPriceRangeEntity entity);
        Task<List<HotelPriceRangeViewEntity>> FindAllHotelPriceRange(HotelPriceEntity entity);
        Task<HotelRoomPriceViewEntity> FindAllAvailableHotelRoomPrice(HotelsIDEntity entity);
        Task<List<HotelPriceRangeViewEntity>> FindAllHotelPriceTicketAvaibility(HotelPriceEntity entity);
        Task<List<HotelPriceRangeViewEntity>> HotelPriceByHotelRoom(HotelPriceEntity entity);
        Task<ResultModel> InsertHotelBookingPackagePrice(HotelBookingPackagePriceEntity entity);
        Task<List<HotelBookingPackagePriceViewEntity>> FindAllHotelBookingPackagePrice(HotelBookingPackagePriceEntity entity);

    }
}
