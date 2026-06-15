using HotelBooking.Entity.Common.Entities;
using HotelBooking.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBooking.DataAccess.Base
{
    public interface IHotelBookingTicketLookupRepositoryInterface
    {
        Task<ResultModel> InsertHotelBookingTicket(HotelBookingTicketEntity entity, string storedProcedure);
        Task<ResultModel> UpdateHotelBookingTicket(HotelBookingTicketEntity entity, string storedProcedure);
        Task<ResultModel> DeleteHotelBookingTicket(HotelBookingTicketIDEntity entity, string storedProcedure);
        Task<HotelBookingTicketViewEntity> FindByIDHotelBookingTicket(HotelBookingTicketIDEntity entity, string storedProcedure);
        Task<List<HotelBookingTicketViewEntity>> FindAllHotelBookingTicket(HotelBookingTicketIDEntity entity, string storedProcedure);
        Task<List<HotelBookingTicketViewEntity>> FindAllActiveHotelBookingTicket(string storedProcedure);

        Task<ResultModel> ActiveInActiveHotelBookingTicket(HotelBookingTicketIDEntity entity, string storedProcedure);
        Task<ResultModel> HotelBookingTicketImageUpdate(string? BannerImage, string? ImageUpload, List<HotelBookingTicketDocumentsImage> Image, int? ID, int? UpdatedBy, string storedProcedure);
        Task<ResultModel> DeleteHotelBookingImages(AttractionIDEntity entity, string storedProcedure);
        Task<HotelBookingTicketViewEntity> FindByURLHotelBookingTicket(HotelBookingTicketIDEntity entity, string storedProcedure);
        Task<ResultModel> InsertHotelBookingTicketVideo(HotelBookingTicketVideoEntity entity, string storedProcedure);
        Task<ResultModel> UpdateHotelBookingTicketVideo(HotelBookingTicketVideoEntity entity, string storedProcedure);
        Task<ResultModel> DeleteHotelBookingTicketVideo(HotelBookingTicketIDEntity entity, string storedProcedure);
        Task<ResultModel> InsertHotelBookingTicketFAQ(HotelBookingTicketFAQEntity entity, string storedProcedure);
        Task<ResultModel> UpdateHotelBookingTicketFAQ(HotelBookingTicketFAQEntity entity, string storedProcedure);
        Task<ResultModel> DeleteHotelBookingTicketFAQ(HotelBookingTicketIDEntity entity, string storedProcedure);

        Task<ResultModel> InsertHotelBookingTicketSoldOutDate(HotelBookingTicketSoldOutDateEntity entity, string storedProcedure);
        Task<ResultModel> DeleteHotelBookingTicketSoldOutDate(FAQIDEntity entity, string storedProcedure);
        Task<List<HotelBookingTicketSoldOutDateViewEntity>> FindBYHotelBookingTicketSoldOutDate(HotelBookingTicketSoldOutDateEntity entity, string storedProcedure);
        Task<ResultModel> InsertTicketAvailability(TicketAvailabilityEntity entity, string storedProcedure);
        Task<List<TicketAvailabilityDataViewEntity>> FindTicketAvailability(TicketAvailabilityEntity entity, string storedProcedure);
        Task<TicketAvailabilityDataViewEntity> FindAvailableTicket(TicketAvailabilityEntity entity, string storedProcedure);

        Task<ResultModel> InsertSoldOutDateDay(HotelPriceRangeEntity entity, string storedProcedure);

    }
}
