using HotelBooking.Entity.Common.Entities;
using HotelBooking.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBooking.DataAccess.Base
{
    public interface IWebsiteLookupRepositoryInterface
    {

        Task<HomePageData> HomePageList(string storedProcedure);
        Task<List<HomePageHotelBookingTicket>> FindAllSAOUTicketList(string storedProcedure);
        Task<TourUrlEntity> TourDetailsByURL(TourByURLEntity entity, string storedProcedure);
        Task<AnalyticsCountViewEntity> FindAnalyticsCount(AnalyticsCountEntity entity, string storedProcedure);
        Task<ResultModel> InsertBookingReference(BookingReferenceEntity entity, string storedProcedure);
        Task<List<BookingReferenceViewEntity>> FindAllBookingReference(BookingReferenceEntity entity, string storedProcedure);

    }
}
