using HotelBooking.Entity.Common.Entities;
using HotelBooking.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBooking.DataAccess.Interfaces
{
    public interface IWebsiteRepository
    {

        Task<HomePageData> HomePageList();
        Task<List<HomePageHotelBookingTicket>> FindAllSAOUTicketList();
        Task<TourUrlEntity> TourDetailsByURL(TourByURLEntity entity);
        Task<AnalyticsCountViewEntity> FindAnalyticsCount(AnalyticsCountEntity entity);
        Task<ResultModel> InsertBookingReference(BookingReferenceEntity entity);
        Task<List<BookingReferenceViewEntity>> FindAllBookingReference(BookingReferenceEntity entity);
    }
}
