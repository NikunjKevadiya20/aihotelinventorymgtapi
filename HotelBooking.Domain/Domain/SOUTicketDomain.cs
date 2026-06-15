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
    public class HotelBookingTicketDomain : IHotelBookingTicketDomain
    {
        IHotelBookingTicketRepository repository;
        public HotelBookingTicketDomain(IHotelBookingTicketRepository _repository)
        {
            repository = _repository;
        }

        public async Task<ResultModel> InsertHotelBookingTicket(HotelBookingTicketEntity entity)
        {
            return await repository.InsertHotelBookingTicket(entity);
        }

        public async Task<ResultModel> UpdateHotelBookingTicket(HotelBookingTicketEntity entity)
        {
            return await repository.UpdateHotelBookingTicket(entity);
        }

        public async Task<ResultModel> DeleteHotelBookingTicket(HotelBookingTicketIDEntity entity)
        {
            return await repository.DeleteHotelBookingTicket(entity);
        }
        public async Task<HotelBookingTicketViewEntity> FindByIDHotelBookingTicket(HotelBookingTicketIDEntity entity)
        {
            return await repository.FindByIDHotelBookingTicket(entity);
        }
        public async Task<List<HotelBookingTicketViewEntity>> FindAllHotelBookingTicket(HotelBookingTicketIDEntity entity)
        {
            return await repository.FindAllHotelBookingTicket(entity);
        }
        public async Task<List<HotelBookingTicketViewEntity>> FindAllActiveHotelBookingTicket()
        {
            return await repository.FindAllActiveHotelBookingTicket();
        }

        public async Task<ResultModel> ActiveInActiveHotelBookingTicket(HotelBookingTicketIDEntity entity)
        {
            return await repository.ActiveInActiveHotelBookingTicket(entity);
        }
        public async Task<ResultModel> HotelBookingTicketImageUpdate(string? BannerImage, string? ImageUpload, List<HotelBookingTicketDocumentsImage> Image, int? ID, int? UpdatedBy)
        {
            return await repository.HotelBookingTicketImageUpdate(BannerImage, ImageUpload, Image, ID, UpdatedBy);
        }
        public async Task<ResultModel> DeleteHotelBookingImages(AttractionIDEntity entity)
        {
            return await repository.DeleteHotelBookingImages(entity);
        }
        public async Task<HotelBookingTicketViewEntity> FindByURLHotelBookingTicket(HotelBookingTicketIDEntity entity)
        {
            return await repository.FindByURLHotelBookingTicket(entity);
        }
        public async Task<ResultModel> InsertHotelBookingTicketVideo(HotelBookingTicketVideoEntity entity)
        {
            return await repository.InsertHotelBookingTicketVideo(entity);
        }

        public async Task<ResultModel> UpdateHotelBookingTicketVideo(HotelBookingTicketVideoEntity entity)
        {
            return await repository.UpdateHotelBookingTicketVideo(entity);
        }

        public async Task<ResultModel> DeleteHotelBookingTicketVideo(HotelBookingTicketIDEntity entity)
        {
            return await repository.DeleteHotelBookingTicketVideo(entity);
        }
        public async Task<ResultModel> InsertHotelBookingTicketFAQ(HotelBookingTicketFAQEntity entity)
        {
            return await repository.InsertHotelBookingTicketFAQ(entity);
        }

        public async Task<ResultModel> UpdateHotelBookingTicketFAQ(HotelBookingTicketFAQEntity entity)
        {
            return await repository.UpdateHotelBookingTicketFAQ(entity);
        }

        public async Task<ResultModel> DeleteHotelBookingTicketFAQ(HotelBookingTicketIDEntity entity)
        {
            return await repository.DeleteHotelBookingTicketFAQ(entity);
        }
        public async Task<ResultModel> InsertHotelBookingTicketSoldOutDate(HotelBookingTicketSoldOutDateEntity entity)
        {
            return await repository.InsertHotelBookingTicketSoldOutDate(entity);
        }
        public async Task<ResultModel> DeleteHotelBookingTicketSoldOutDate(FAQIDEntity entity)
        {
            return await repository.DeleteHotelBookingTicketSoldOutDate(entity);
        }
        public async Task<List<HotelBookingTicketSoldOutDateViewEntity>> FindBYHotelBookingTicketSoldOutDate(HotelBookingTicketSoldOutDateEntity entity)
        {
            return await repository.FindBYHotelBookingTicketSoldOutDate(entity);
        }
        public async Task<ResultModel> InsertTicketAvailability(TicketAvailabilityEntity entity)
        {
            return await repository.InsertTicketAvailability(entity);
        }
        public async Task<List<TicketAvailabilityDataViewEntity>> FindTicketAvailability(TicketAvailabilityEntity entity)
        {
            return await repository.FindTicketAvailability(entity);
        }
        public async Task<TicketAvailabilityDataViewEntity> FindAvailableTicket(TicketAvailabilityEntity entity)
        {
            return await repository.FindAvailableTicket(entity);
        }
        public async Task<ResultModel> InsertSoldOutDateDay(HotelPriceRangeEntity entity)
        {
            return await repository.InsertSoldOutDateDay(entity);
        }

    }
}
