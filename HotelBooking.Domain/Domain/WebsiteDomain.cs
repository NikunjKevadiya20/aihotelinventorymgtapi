using HotelBooking.DataAccess.Interfaces;
using HotelBooking.Domain.Interfaces;
using HotelBooking.Entity.Common.Entities;
using HotelBooking.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBooking.Domain.Domain
{
    public class WebsiteDomain : IWebsiteDomain
    {
        IWebsiteRepository repository;
        public WebsiteDomain(IWebsiteRepository _repository)
        {
            repository = _repository;
        }


        public async Task<HomePageData> HomePageList()
        {
            return await repository.HomePageList();
        }
       
        public async Task<List<HomePageHotelBookingTicket>> FindAllSAOUTicketList()
        {
            return await repository.FindAllSAOUTicketList();
        }
        public async Task<TourUrlEntity> TourDetailsByURL(TourByURLEntity entity)
        {
            return await repository.TourDetailsByURL(entity);
        }
        public async Task<AnalyticsCountViewEntity> FindAnalyticsCount(AnalyticsCountEntity entity)
        {
            return await repository.FindAnalyticsCount(entity);
        }

        public async Task<ResultModel> InsertBookingReference(BookingReferenceEntity entity)
        {
            return await repository.InsertBookingReference(entity);
        }
        public async Task<List<BookingReferenceViewEntity>> FindAllBookingReference(BookingReferenceEntity entity)
        {
            return await repository.FindAllBookingReference(entity);
        }

    }
}
