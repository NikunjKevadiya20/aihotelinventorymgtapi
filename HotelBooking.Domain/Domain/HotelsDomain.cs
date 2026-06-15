using HotelBooking.DataAccess.Interfaces;
using HotelBooking.Domain.Interfaces;
using HotelBooking.Entity.Common.Entities;
using HotelBooking.Entity.Entities;

namespace HotelBooking.Domain.Domains
{
    /// <summary>
    /// Added by NikunjK on 01-08-2023
    /// </summary>
    public class HotelsDomain : IHotelsDomain
    {
        IHotelsRepository repository;
        public HotelsDomain(IHotelsRepository _repository)
        {
            repository = _repository;
        }

        public async Task<HotelResEntity> InsertHotels(HotelsDataEntity entity)
        {
            return await repository.InsertHotels(entity);
        }
        public async Task<HotelResEntity> UpdateHotels(HotelsDataEntity entity)
        {
            return await repository.UpdateHotels(entity);
        }
        public async Task<ResultModel> DeleteHotels(HotelsIDEntity entity)
        {
            return await repository.DeleteHotels(entity);
        }
        public async Task<ResultModel> DeleteHotelImage(HotelsIDEntity entity)
        {
            return await repository.DeleteHotelImage(entity);
        }
        public async Task<HotelsFindByViewEntity> FindByIDHotels(HotelsIDEntity entity)
        {
            return await repository.FindByIDHotels(entity);
        }
        public async Task<List<HotelsViewEntity>> FindAllHotels(HotelsIDEntity entity)
        {
            return await repository.FindAllHotels(entity);
        }
        public async Task<List<HotelsViewEntity>> FindAllActiveHotels(HotelsAvailabilityEntity entity)
        {
            return await repository.FindAllActiveHotels(entity);
        }
        public async Task<ResultModel> ActiveInActiveHotels(HotelsIDEntity entity)
        {
            return await repository.ActiveInActiveHotels(entity);
        }
        public async Task<ResultModel> BulkUploadHotelData(List<Hotel> Hotel, List<HotelRateSpecialDate> rate)
        {
            return await repository.BulkUploadHotelData(Hotel, rate);
        }
        public async Task<ResultModel> BulkUploadHotelDataNew(List<HotelExcelExport> Hotel, List<HotelRateSpecialDateNew> rate)
        {
            return await repository.BulkUploadHotelDataNew(Hotel, rate);
        }
        public async Task<ResultModel> HotelImageUpdate(HotelImageEntity entity)
        {
            return await repository.HotelImageUpdate(entity);
        }

        public async Task<HotelsFindByViewEntity> FindByURLHotels(HotelsIDEntity entity)
        {
            return await repository.FindByURLHotels(entity);
        }
        public async Task<List<HotelsViewEntity>> HotelsListForWebsite(HotelsIDEntity entity)
        {
            return await repository.HotelsListForWebsite(entity);
        }
        public async Task<List<HotelsViewEntity>> FindAllHotelsForDropdown(HotelsIDEntity entity)
        {
            return await repository.FindAllHotelsForDropdown(entity);
        }
        public async Task<List<HotelSearchForWebsite>> HotelSearchForWebsite(HotelsIDEntity entity)
        {
            return await repository.HotelSearchForWebsite(entity);
        }
        public async Task<List<HotelsCity>> CityListForWebsite()
        {
            return await repository.CityListForWebsite();
        }

        public async Task<ResultModel> InsertHotelRoomAvalability(HotelRoomEntity entity)
        {
            return await repository.InsertHotelRoomAvalability(entity);
        }
        public async Task<List<HotelRoomViewEntity>> FindAllHotelRoomAvalability(HotelsIDEntity entity)
        {
            return await repository.FindAllHotelRoomAvalability(entity);
        }

        public async Task<ResultModel> InsertHotelPriceRange(HotelPriceRangeEntity entity)
        {
            return await repository.InsertHotelPriceRange(entity);
        }
        public async Task<List<HotelPriceRangeViewEntity>> FindAllHotelPriceRange(HotelPriceEntity entity)
        {
            return await repository.FindAllHotelPriceRange(entity);
        }
        public async Task<HotelRoomPriceViewEntity> FindAllAvailableHotelRoomPrice(HotelsIDEntity entity)
        {
            return await repository.FindAllAvailableHotelRoomPrice(entity);
        }
        public async Task<List<HotelPriceRangeViewEntity>> FindAllHotelPriceTicketAvaibility(HotelPriceEntity entity)
        {
            return await repository.FindAllHotelPriceTicketAvaibility(entity);
        }
        public async Task<List<HotelPriceRangeViewEntity>> HotelPriceByHotelRoom(HotelPriceEntity entity)
        {
            return await repository.HotelPriceByHotelRoom(entity);
        }
        public async Task<ResultModel> InsertHotelBookingPackagePrice(HotelBookingPackagePriceEntity entity)
        {
            return await repository.InsertHotelBookingPackagePrice(entity);
        }
        public async Task<List<HotelBookingPackagePriceViewEntity>> FindAllHotelBookingPackagePrice(HotelBookingPackagePriceEntity entity)
        {
            return await repository.FindAllHotelBookingPackagePrice(entity);
        }
    }
}
