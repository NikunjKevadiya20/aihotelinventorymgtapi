using HotelBooking.DataAccess.Base;
using HotelBooking.DataAccess.Interfaces;
using HotelBooking.Entity.Common.Entities;
using HotelBooking.Entity.Entities;

namespace HotelBooking.DataAccess.Repositories
{
    public class BookingRepository : IBookingRepository
    {
        private readonly IBookingLookupRepositoryInterface repository;

        public BookingRepository(IBookingLookupRepositoryInterface _repository)
        {
            repository = _repository;
        }
        public async Task<TempBookingIDViewEntity> InsertTempBooking(TempBookingEntity entity)
        {
            return await repository.InsertTempBooking(entity, "SP_ManageTempBooking");
        }

        public async Task<BookingViewInsertEntity> InsertBooking(BookingRequestEntity entity)
        {
            return await repository.InsertBooking(entity, "sp_ManageBooking");
        }

        public async Task<List<BookingListEntity>> FindAllBooking(BookingSearchEntity entity)
        {
            return await repository.FindAllBooking(entity, "sp_ManageBookingFindAll");
        }
        public async Task<BookingViewEntity> FindByIDBooking(BookingEntity entity)
        {
            return await repository.FindByIDBooking(entity, "sp_ManageBookingFindByID");
        }
        public async Task<DashboardResponse> DashboardCount(DashboardCustomerRequestEntity entity)
        {
            return await repository.DashboardCount(entity, "sp_ManageGetBookingDashboardCount");
        }
        public async Task<List<BookingViewEntity>> GetDashboardBookingDetails(DashboardCustomerRequestEntity entity)
        {
            return await repository.GetDashboardBookingDetails(entity, "sp_ManageGetBookingDetails");
        }
        public async Task<List<DashboardInquiryData>> GetDashboardInquiry(DashboardCustomerRequestEntity entity)
        {
            return await repository.GetDashboardInquiry(entity, "sp_ManageGetBookingDetails");
        }
        public async Task<List<DashboardTomorrowCheckInData>> GetDashboardTomorrowCheckIn()
        {
            return await repository.GetDashboardTomorrowCheckIn( "sp_ManageGetBookingDetails");
        }
        public async Task<PDFDownloadResponse> PDFDownload(BookingRequestEntity entity)
        {
            return await repository.PDFDownload(entity, "sp_ManageBookingPDFGenerate");
        }
    }
}
