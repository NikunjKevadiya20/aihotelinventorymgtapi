using HotelBooking.Entity.Common.Entities;
using HotelBooking.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBooking.DataAccess.Interfaces
{
    public interface IHotelBookingTicketRepository
    {
        Task<ResultModel> InsertHotelBookingTicket(HotelBookingTicketEntity entity);
        Task<ResultModel> UpdateHotelBookingTicket(HotelBookingTicketEntity entity);
        Task<ResultModel> DeleteHotelBookingTicket(HotelBookingTicketIDEntity entity);

        Task<HotelBookingTicketViewEntity> FindByIDHotelBookingTicket(HotelBookingTicketIDEntity entity);
        Task<List<HotelBookingTicketViewEntity>> FindAllHotelBookingTicket(HotelBookingTicketIDEntity entity);
        Task<List<HotelBookingTicketViewEntity>> FindAllActiveHotelBookingTicket();

        Task<ResultModel> ActiveInActiveHotelBookingTicket(HotelBookingTicketIDEntity entity);
        Task<ResultModel> HotelBookingTicketImageUpdate(string? BannerImage, string? ImageUpload, List<HotelBookingTicketDocumentsImage> Image, int? ID, int? UpdatedBy);
        Task<ResultModel> DeleteHotelBookingImages(AttractionIDEntity entity);
        Task<HotelBookingTicketViewEntity> FindByURLHotelBookingTicket(HotelBookingTicketIDEntity entity);

        Task<ResultModel> InsertHotelBookingTicketVideo(HotelBookingTicketVideoEntity entity);
        Task<ResultModel> UpdateHotelBookingTicketVideo(HotelBookingTicketVideoEntity entity);
        Task<ResultModel> DeleteHotelBookingTicketVideo(HotelBookingTicketIDEntity entity);
        Task<ResultModel> InsertHotelBookingTicketFAQ(HotelBookingTicketFAQEntity entity);
        Task<ResultModel> UpdateHotelBookingTicketFAQ(HotelBookingTicketFAQEntity entity);
        Task<ResultModel> DeleteHotelBookingTicketFAQ(HotelBookingTicketIDEntity entity);

        Task<ResultModel> InsertHotelBookingTicketSoldOutDate(HotelBookingTicketSoldOutDateEntity entity);
        Task<ResultModel> DeleteHotelBookingTicketSoldOutDate(FAQIDEntity entity);
        Task<List<HotelBookingTicketSoldOutDateViewEntity>> FindBYHotelBookingTicketSoldOutDate(HotelBookingTicketSoldOutDateEntity entity);
        Task<ResultModel> InsertTicketAvailability(TicketAvailabilityEntity entity);
        Task<List<TicketAvailabilityDataViewEntity>> FindTicketAvailability(TicketAvailabilityEntity entity);

        Task<TicketAvailabilityDataViewEntity> FindAvailableTicket(TicketAvailabilityEntity entity);
        Task<ResultModel> InsertSoldOutDateDay(HotelPriceRangeEntity entity);


    }
}
