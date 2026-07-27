using HotelBooking.DataAccess.Base;
using HotelBooking.DataAccess.Interfaces;
using HotelBooking.Entity.Common.Entities;
using HotelBooking.Entity.Entities;

namespace HotelBooking.DataAccess.Repositories
{
    /// <summary>
    /// Added by NikunjK on 01-08-2023
    /// </summary>
    public class HotelsRepository : IHotelsRepository
    {
        IHotelsLookupRepositoryInterface repository;
        public HotelsRepository(IHotelsLookupRepositoryInterface _repository)
        {
            repository = _repository;
        }

        public async Task<HotelResEntity> InsertHotels(HotelsDataEntity entity)
        {
            return await repository.InsertHotels(entity, "sp_ManageHotelsInsert");
        }
        public async Task<HotelResEntity> UpdateHotels(HotelsDataEntity entity)
        {
            return await repository.UpdateHotels(entity, "sp_ManageHotelsInsert");
        }
        public async Task<ResultModel> DeleteHotels(HotelsIDEntity entity)
        {
            return await repository.DeleteHotels(entity, "sp_ManageHotelFindByID");
        }
        public async Task<ResultModel> DeleteHotelImage(HotelsIDEntity entity)
        {
            return await repository.DeleteHotelImage(entity, "sp_ManageHotelFindByID");
        }
        public async Task<HotelsFindByViewEntity> FindByIDHotels(HotelsIDEntity entity)
        {
            return await repository.FindByIDHotels(entity, "sp_ManageHotelFindByID");
        }
        public async Task<List<HotelsViewEntity>> FindAllHotels(HotelsIDEntity entity)
        {
            return await repository.FindAllHotels(entity, "sp_ManageHotelFindAll");
        }
        public async Task<List<HotelsViewEntity>> FindAllActiveHotels(HotelsAvailabilityEntity entity)
        {
            return await repository.FindAllActiveHotels(entity,"sp_ManageHotelFindAllActive");
        }
        public async Task<ResultModel> ActiveInActiveHotels(HotelsIDEntity entity)
        {
            return await repository.ActiveInActiveHotels(entity, "sp_ManageHotelFindByID");
        }
        public async Task<ResultModel> BulkUploadHotelData(List<Hotel> Hotel, List<HotelRateSpecialDate> rate)
        {
            return await repository.BulkUploadHotelData(Hotel, rate, "sp_ManageBulkUploadHotelData");
        }
        public async Task<ResultModel> BulkUploadHotelDataNew(List<HotelExcelExport> Hotel, List<HotelRateSpecialDateNew> rate)
        {
            return await repository.BulkUploadHotelDataNew(Hotel, rate, "sp_ManageBulkUploadHotelDataNew");
        }
        public async Task<ResultModel> HotelImageUpdate(HotelImageEntity entity)
        {
            return await repository.HotelImageUpdate(entity, "sp_ManageHotelsInsert");
        }
        public async Task<HotelsFindByViewEntity> FindByURLHotels(HotelsIDEntity entity)
        {
            return await repository.FindByURLHotels(entity, "sp_ManageHotelFindByID");
        }
        public async Task<List<HotelsViewEntity>> HotelsListForWebsite(HotelsIDEntity entity)
        {
            return await repository.HotelsListForWebsite(entity, "sp_ManageHotelFindByID");
        }
        public async Task<List<HotelsViewEntity>> FindAllHotelsForDropdown(HotelsIDEntity entity)
        {
            return await repository.FindAllHotelsForDropdown(entity, "sp_ManageHotelFindByID");
        }
        public async Task<List<HotelSearchForWebsite>> HotelSearchForWebsite(HotelsIDEntity entity)
        {
            return await repository.HotelSearchForWebsite(entity, "sp_ManageHotelFindByID");
        }
        public async Task<List<HotelsCity>> CityListForWebsite()
        {
            return await repository.CityListForWebsite("sp_ManageHotelFindByID");
        }

        public async Task<ResultModel> InsertHotelRoomAvalability(HotelRoomEntity entity)
        {
            return await repository.InsertHotelRoomAvalability(entity, "sp_ManageHotelsRoomAvalibilityInsert");
        }
        public async Task<List<HotelRoomViewEntity>> FindAllHotelRoomAvalability(HotelsIDEntity entity)
        {
            return await repository.FindAllHotelRoomAvalability(entity, "sp_ManageHotelsRoomAvalibilityInsert");
        }

        public async Task<ResultModel> InsertHotelPriceRange(HotelPriceRangeEntity entity)
        {
            return await repository.InsertHotelPriceRange(entity, "sp_ManageHotelsPriceRangeInsert");
        }
        public async Task<List<HotelPriceRangeViewEntity>> FindAllHotelPriceRange(HotelPriceEntity entity)
        {
            return await repository.FindAllHotelPriceRange(entity, "sp_ManageHotelsPriceRangeInsert");
        }
        public async Task<HotelRoomPriceViewEntity> FindAllAvailableHotelRoomPrice(HotelsIDEntity entity)
        {
            return await repository.FindAllAvailableHotelRoomPrice(entity, "sp_ManageHotelsRoomAvalibilityInsert");
        }
        public async Task<List<HotelPriceRangeViewEntity>> FindAllHotelPriceTicketAvaibility(HotelPriceEntity entity)
        {
            return await repository.FindAllHotelPriceTicketAvaibility(entity, "sp_ManageHotelsPriceRangeInsert");
        }
        public async Task<List<HotelPriceRangeViewEntity>> HotelPriceByHotelRoom(HotelPriceEntity entity)
        {
            return await repository.HotelPriceByHotelRoom(entity, "sp_ManageHotelPrice");
        }
        public async Task<ResultModel> InsertHotelBookingPackagePrice(HotelBookingPackagePriceEntity entity )
        {
            return await repository.InsertHotelBookingPackagePrice(entity, "sp_ManageHotelBookingPackagePriceInsert");
        }
        public async Task<List<HotelBookingPackagePriceViewEntity>> FindAllHotelBookingPackagePrice(HotelBookingPackagePriceEntity entity)
        {
            return await repository.FindAllHotelBookingPackagePrice(entity, "sp_ManageHotelBookingPackagePriceInsert");
        }

    }

}
