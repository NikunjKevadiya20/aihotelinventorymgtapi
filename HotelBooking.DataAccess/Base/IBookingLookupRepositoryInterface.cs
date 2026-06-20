using HotelBooking.Entity.Entities;
using HotelBooking.Entity.Common.Entities;
using HotelBooking.Entity.Entities;

namespace HotelBooking.DataAccess.Base
{
    public interface IBookingLookupRepositoryInterface
    {
        Task<TempBookingIDViewEntity> InsertTempBooking(TempBookingEntity entity, string storedProcedure);
        Task<BookingViewInsertEntity> InsertBooking(BookingRequestEntity entity, string storedProcedure);
        Task<List<BookingListEntity>> FindAllBooking(BookingSearchEntity entity, string storedProcedure);
        Task<BookingViewInsertEntity> FindByIDBooking(BookingRequestEntity entity, string storedProcedure);
        Task<DashboardResponse> DashboardCount(DashboardCustomerRequestEntity entity, string storedProcedure);
        Task<List<BookingViewEntity>> GetDashboardBookingDetails(DashboardCustomerRequestEntity entity, string storedProcedure);
        Task<List<DashboardInquiryData>> GetDashboardInquiry(DashboardCustomerRequestEntity entity, string storedProcedure);

        Task<List<DashboardTomorrowCheckInData>> GetDashboardTomorrowCheckIn(string storedProcedure);
      
        //Task<PDFDownloadResponse> PDFDownload(BookingRequestEntity entity, string storedProcedure);

    }
}
