using HotelBooking.DataAccess.Interfaces;
using HotelBooking.Domain.Interfaces;
using HotelBooking.Entity.Common.Entities;
using HotelBooking.Entity.Entities;

namespace HotelBooking.Domain.Domain
{
    public class BookingDomain : IBookingDomain
    {
        private readonly IBookingRepository repository;

        public BookingDomain(IBookingRepository _repository)
        {
            repository = _repository;
        }

        // Domain methods will be implemented later.
        public async Task<TempBookingIDViewEntity> InsertTempBooking(TempBookingEntity entity)
        {
            return await repository.InsertTempBooking(entity);
        }

        public async Task<BookingViewInsertEntity> InsertBooking(BookingRequestEntity entity)
        {
            return await repository.InsertBooking(entity);
        }

        public async Task<List<BookingListEntity>> FindAllBooking(BookingSearchEntity entity)
        {
            return await repository.FindAllBooking(entity);
        }
        public async Task<BookingViewEntity> FindByIDBooking(BookingEntity entity)
        {
            return await repository.FindByIDBooking(entity);
        }
        public async Task<DashboardResponse> DashboardCount(DashboardCustomerRequestEntity entity)
        {
            return await repository.DashboardCount(entity);
        }
        public async Task<List<BookingViewEntity>> GetDashboardBookingDetails(DashboardCustomerRequestEntity entity)
        {
            return await repository.GetDashboardBookingDetails(entity);
        }
        public async Task<List<DashboardInquiryData>> GetDashboardInquiry(DashboardCustomerRequestEntity entity)
        {
            return await repository.GetDashboardInquiry(entity);
        }
        public async Task<List<DashboardTomorrowCheckInData>> GetDashboardTomorrowCheckIn()
        {
            return await repository.GetDashboardTomorrowCheckIn();
        }
        public async Task<PDFDownloadResponse> PDFDownload(BookingRequestEntity entity)
        {
            return await repository.PDFDownload(entity);
        }
    }
}
