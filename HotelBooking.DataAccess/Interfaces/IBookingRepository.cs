using HotelBooking.Entity.Entities;
using HotelBooking.Entity.Common.Entities;
using HotelBooking.Entity.Entities;

namespace HotelBooking.DataAccess.Interfaces
{
    public interface IBookingRepository
    {
        // Repository methods for Booking will be defined later.
        Task<TempBookingIDViewEntity> InsertTempBooking(TempBookingEntity entity);
        Task<BookingViewInsertEntity> InsertBooking(BookingRequestEntity entity);
        Task<List<BookingListEntity>> FindAllBooking(BookingSearchEntity entity);
        Task<BookingViewEntity> FindByIDBooking(BookingEntity entity);
        Task<DashboardResponse> DashboardCount(DashboardCustomerRequestEntity entity);
        Task<List<BookingViewEntity>> GetDashboardBookingDetails(DashboardCustomerRequestEntity entity);
        Task<List<DashboardInquiryData>> GetDashboardInquiry(DashboardCustomerRequestEntity entity);

        Task<List<DashboardTomorrowCheckInData>> GetDashboardTomorrowCheckIn();


        Task<PDFDownloadResponse> PDFDownload(BookingRequestEntity entity);

    }
}
