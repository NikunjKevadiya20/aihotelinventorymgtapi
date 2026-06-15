using HotelBooking.DataAccess.Base;
using HotelBooking.DataAccess.Interfaces;
using HotelBooking.Entity.Common.Entities;
using HotelBooking.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBooking.DataAccess.Repositories
{
    public class WebsiteRepository : IWebsiteRepository
    {
        IWebsiteLookupRepositoryInterface repository;
        public WebsiteRepository(IWebsiteLookupRepositoryInterface _repository)
        {
            repository = _repository;
        }


        public async Task<HomePageData> HomePageList()
        {
            return await repository.HomePageList("sp_ManageHome");
        }
        public async Task<List<HomePageHotelBookingTicket>> FindAllSAOUTicketList()
        {
            return await repository.FindAllSAOUTicketList("sp_ManageHome");
        }
        public async Task<TourUrlEntity> TourDetailsByURL(TourByURLEntity entity)
        {
            return await repository.TourDetailsByURL(entity, "sp_ManageTourFindDelete");
        }
        public async Task<AnalyticsCountViewEntity> FindAnalyticsCount(AnalyticsCountEntity entity)
        {
            return await repository.FindAnalyticsCount(entity, "sp_ManagePageAnalyticsInsert");
        }
        public async Task<ResultModel> InsertBookingReference(BookingReferenceEntity entity)
        {
            return await repository.InsertBookingReference(entity, "sp_ManageBookingReferenceInsert");
        }
        public async Task<List<BookingReferenceViewEntity>> FindAllBookingReference(BookingReferenceEntity entity)
        {
            return await repository.FindAllBookingReference(entity, "sp_ManageBookingReferenceInsert");
        }

    }
}
