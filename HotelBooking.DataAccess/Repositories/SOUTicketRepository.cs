using HotelBooking.DataAccess.Base;
using HotelBooking.DataAccess.Interfaces;
using HotelBooking.Entity.Common.Entities;
using HotelBooking.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace HotelBooking.DataAccess.Repositories
{
    public class SOUTicketRepository : ISOUTicketRepository
    {
        ISOUTicketLookupRepositoryInterface repository;

        public SOUTicketRepository(ISOUTicketLookupRepositoryInterface _repository)
        {
            repository = _repository;
        }

        public async Task<ResultModel> InsertHotelBookingTicket(HotelBookingTicketEntity entity)
        {
            return await repository.InsertHotelBookingTicket(entity, "sp_ManageSOUTicketInsert");
        }
        public async Task<ResultModel> UpdateHotelBookingTicket(HotelBookingTicketEntity entity)
        {
            return await repository.UpdateHotelBookingTicket(entity, "sp_ManageSOUTicketInsert");
        }
        public async Task<ResultModel> DeleteHotelBookingTicket(HotelBookingTicketIDEntity entity)
        {
            return await repository.DeleteHotelBookingTicket(entity, "sp_ManageSOUTicketFindDelete");
        }
        public async Task<HotelBookingTicketViewEntity> FindByIDHotelBookingTicket(HotelBookingTicketIDEntity entity)
        {
            return await repository.FindByIDHotelBookingTicket(entity, "sp_ManageSOUTicketFindDelete");
        }

        public async Task<List<HotelBookingTicketViewEntity>> FindAllHotelBookingTicket(HotelBookingTicketIDEntity entity)
        {
            return await repository.FindAllHotelBookingTicket(entity, "sp_ManageSOUTicketFindAll");
        }
        public async Task<List<HotelBookingTicketViewEntity>> FindAllActiveHotelBookingTicket()
        {
            return await repository.FindAllActiveHotelBookingTicket("sp_ManageSOUTicketFindAll");
        }
        public async Task<ResultModel> ActiveInActiveHotelBookingTicket(HotelBookingTicketIDEntity entity)
        {
            return await repository.ActiveInActiveHotelBookingTicket(entity, "sp_ManageSOUTicketFindDelete");
        }
        public async Task<ResultModel> HotelBookingTicketImageUpdate(string? BannerImage, string? ImageUpload, List<HotelBookingTicketDocumentsImage> Image, int? ID, int? UpdatedBy)
        {
            return await repository.HotelBookingTicketImageUpdate(BannerImage, ImageUpload, Image,ID, UpdatedBy, "sp_ManageSOUTicketInsert");
        }
        public async Task<ResultModel> DeleteHotelBookingImages(AttractionIDEntity entity)
        {
            return await repository.DeleteHotelBookingImages(entity, "sp_ManageSOUTicketInsert");
        }
        public async Task<HotelBookingTicketViewEntity> FindByURLHotelBookingTicket(HotelBookingTicketIDEntity entity)
        {
            return await repository.FindByURLHotelBookingTicket(entity, "sp_ManageSOUTicketFindDelete");
        }

        public async Task<ResultModel> InsertHotelBookingTicketVideo(HotelBookingTicketVideoEntity entity)
        {
            return await repository.InsertHotelBookingTicketVideo(entity, "sp_ManageSOUTicketInsertwithVideoURLandFAQ");
        }
        public async Task<ResultModel> UpdateHotelBookingTicketVideo(HotelBookingTicketVideoEntity entity)
        {
            return await repository.UpdateHotelBookingTicketVideo(entity, "sp_ManageSOUTicketInsertwithVideoURLandFAQ");
        }
        public async Task<ResultModel> DeleteHotelBookingTicketVideo(HotelBookingTicketIDEntity entity)
        {
            return await repository.DeleteHotelBookingTicketVideo(entity, "sp_ManageSOUTicketFindDelete");
        }
        public async Task<ResultModel> InsertHotelBookingTicketFAQ(HotelBookingTicketFAQEntity entity)
        {
            return await repository.InsertHotelBookingTicketFAQ(entity, "sp_ManageSOUTicketInsertwithVideoURLandFAQ");
        }
        public async Task<ResultModel> UpdateHotelBookingTicketFAQ(HotelBookingTicketFAQEntity entity)
        {
            return await repository.UpdateHotelBookingTicketFAQ(entity, "sp_ManageSOUTicketInsertwithVideoURLandFAQ");
        }
        public async Task<ResultModel> DeleteHotelBookingTicketFAQ(HotelBookingTicketIDEntity entity)
        {
            return await repository.DeleteHotelBookingTicketFAQ(entity, "sp_ManageSOUTicketFindDelete");
        }
        public async Task<ResultModel> InsertHotelBookingTicketSoldOutDate(HotelBookingTicketSoldOutDateEntity entity)
        {
            return await repository.InsertHotelBookingTicketSoldOutDate(entity, "sp_ManageSOUTicketSoldOutDateInsert");
        }
        public async Task<ResultModel> DeleteHotelBookingTicketSoldOutDate(FAQIDEntity entity)
        {
            return await repository.DeleteHotelBookingTicketSoldOutDate(entity, "sp_ManageSOUTicketSoldOutDateFindDelete");
        }
        public async Task<List<HotelBookingTicketSoldOutDateViewEntity>> FindBYHotelBookingTicketSoldOutDate(HotelBookingTicketSoldOutDateEntity entity)
        {
            return await repository.FindBYHotelBookingTicketSoldOutDate(entity, "sp_ManageSOUTicketSoldOutDateFindDelete");
        }
        public async Task<ResultModel> InsertTicketAvailability(TicketAvailabilityEntity entity)
        {
            return await repository.InsertTicketAvailability(entity, "sp_ManageTicketAvailability");
        }
        public async Task<List<TicketAvailabilityDataViewEntity>> FindTicketAvailability(TicketAvailabilityEntity entity)
        {
            return await repository.FindTicketAvailability(entity, "sp_ManageTicketAvailability");
        }
        public async Task<TicketAvailabilityDataViewEntity> FindAvailableTicket(TicketAvailabilityEntity entity)
        {
            return await repository.FindAvailableTicket(entity, "sp_ManageTicketAvailability");
        }
        public async Task<ResultModel> InsertSoldOutDateDay(HotelPriceRangeEntity entity)
        {
            return await repository.InsertSoldOutDateDay(entity, "sp_ManageSOUTicketSoldOutDateFindDelete");
        }
    }
}
