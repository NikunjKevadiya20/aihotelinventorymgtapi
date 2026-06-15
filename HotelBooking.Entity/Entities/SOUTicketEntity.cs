using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBooking.Entity.Entities
{
   public class HotelBookingTicketEntity
    {
        public int? ID { get; set; }
        public string? Title { get; set; } 
        public string? Timing { get; set; } 
        public string? ShortDescription { get; set; } 
        public string? Description { get; set; } 
        public int? SequenceNo { get; set; } 
        public string? BookingURL { get; set; }
        public string? CancellationPolicy { get; set; }
        public string? InstructionsForVisitors { get; set; }
        public string? MetaTitle { get; set; }
        public string? MetaKeywords { get; set; }
        public string? MetaDescription { get; set; }
        public string? TicketURL { get; set; }
        public decimal? ServiceCharge { get; set; }
        public int? ServiceChargeType { get; set; }
        public decimal? ServiceChargeValue { get; set; }
        public Boolean? IsActive { get; set; }
        public Int32? CreatedBy { set; get; }
        public Int32? UpdatedBy { set; get; }
        public string? Details { get; set; }
        public string? Message { get; set; }
        public bool? IsPopular  { get; set; }
        public string? AttractionID { get; set; }
        public bool? IsViewingGallery { get; set; }
        public bool? IsProjectMapping { get; set; } 
        public decimal? PerPersonRate { get; set; }
        public decimal? ChildSevenYrRate { get; set; }
        public decimal? ChildThreeYrRate { get; set; }
        public string? LastEntry { get; set; }
        public string? Notice { get; set; }
        public int? MinPaxCount { get; set; }
        public List<HotelBookingTicketDetailsEntity>? HotelBookingTicketDetails { get; set; }

    }
    public class HotelBookingTicketVideoEntity
    {
        public int? TicketID { get; set; }
        public List<HotelBookingTicketVideo>? HotelBookingTicketVideo { get; set; }
    }
    public class HotelBookingTicketVideo
    {
        public string? URL { get; set; }
    }
    public class HotelBookingTicketDocumentsImage
    {
        public string? Image { get; set; }
    }
    public class HotelBookingTicketImage
    {
        public int? ID { get; set; }
        public int? HotelBookingTicketID { get; set; }
        public IFormFile? MainImage { get; set; }
        public IFormFile? BannerImage { get; set; }
        public List<IFormFile>? Image { get; set; }
    }
    public class HotelBookingTicketDetailsEntity
    {
        public string? Title { get; set; }
        public decimal? Rate { get; set; }

    }
    public class HotelBookingTicketIDEntity : MessageBaseEntity
    {
        public int? ID { get; set; }

        public string? TicketURL { get; set; } 
        public string? Title { get; set; } 
        public Int32? UpdatedBy { set; get; }
        public Boolean? IsActive { get; set; }
    }

    public class HotelBookingTicketViewEntity : MessageBaseEntity
    {
        public int? ID { get; set; }
        public string? Title { get; set; }
        public string? Timing { get; set; }
        public string? ShortDescription { get; set; }
        public string? Description { get; set; }
        public int? SequenceNo { get; set; }
        public string? BookingURL { get; set; }
        public string? MetaTitle { get; set; }
        public string? MetaKeywords { get; set; }
        public string? MetaDescription { get; set; }
        public string? TicketURL { get; set; }
        public string? ImageUpload { get; set; }
        public string? BannerImage { get; set; }
        public Boolean? IsPopular { get; set; }
        public string? CancellationPolicy { get; set; }
        public string? InstructionsForVisitors { get; set; }
        public string? LastEntry { get; set; }
        public string? Notice { get; set; }
        public int? MinPaxCount { get; set; }
        public Boolean? IsActive { get; set; }
        public string? Details { get; set; }
        public string? Message { get; set; }
        public int? Status { get; set; }
        public string? ErrorMessage { get; set; }
        public string? AttractionID { get; set; }
        public bool? IsViewingGallery { get; set; }
        public bool? IsProjectMapping { get; set; }
        public decimal? ServiceCharge { get; set; }
        public int? ServiceChargeType { get; set; }
        public decimal? ServiceChargeValue { get; set; }
        public decimal? PerPersonRate { get; set; }
        public decimal? ChildSevenYrRate { get; set; }
        public decimal? ChildThreeYrRate { get; set; }
 
        public List<HotelBookingTicketDetailsdataEntity>? HotelBookingTicketDetails { get; set; }
        public List<HotelBookingTicketImagesdataEntity>? HotelBookingTicketImage { get; set; }
        public List<HotelBookingTicketVideodataEntity>? HotelBookingTicketVideo { get; set; }
        public List<HotelBookingTicketFAQdataEntity>? HotelBookingTicketFAQ { get; set; }
        public List<HotelBookingTicketAnotherTicketEntity>? AnotherTicket { get; set; }
        public List<HotelBookingTicketTimeSlotEntity>? TimeSlot { get; set; }
        public List<HotelBookingTicketSoldOutDateVeiwEntity>? HotelBookingTicketSoldOutDate { get; set; }
        public List<ViewingGalleryEntity>? ViewingGallery { get; set; }
        public List<ViewingGalleryEntity>? ProjectionMapping { get; set; }

    }
    public class HotelBookingTicketSoldOutDateVeiwEntity
    {
        public int? ID { get; set; }
        public int? HotelBookingTicketID { get; set; }
        public string? SoldOutDate { get; set; }
    }

    public class HotelBookingTicketTimeSlotEntity
    {
        public int? AttractionID { get; set; }
        public string? Title { get; set; }
        public string? TicketType { get; set; }
        public string? TimeSlot { get; set; }
    }

    public class HotelBookingTicketAnotherTicketEntity
    {
        public int? ID { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public int? SequenceNo { get; set; }
        public string? BookingURL { get; set; }
        public string? MetaTitle { get; set; }
        public string? MetaKeywords { get; set; }
        public string? MetaDescription { get; set; }
        public string? TicketURL { get; set; }
        public string? ImageUpload { get; set; }
        public string? BannerImage { get; set; }
        public Boolean? IsPopular { get; set; }
        public string? CancellationPolicy { get; set; }
        public string? InstructionsForVisitors { get; set; }
        public Boolean? IsActive { get; set; }
        public decimal? PerPersonRate { get; set; }
        public decimal? ChildSevenYrRate { get; set; }
        public decimal? ChildThreeYrRate { get; set; }
        public string? LastEntry { get; set; }
        public string? Notice { get; set; }
        public List<HotelBookingTicketDetailsdataEntity>? AnotherTicketDetails { get; set; }
    }

    public class HotelBookingTicketFAQdataEntity
    {
        public int? ID { get; set; }
        public int? TicketID { get; set; }
        public int? SequenceNo { get; set; }
        public string? Question { get; set; }
        public string? Answer { get; set; }
     
    }

    public class HotelBookingTicketFAQEntity
    {
        public int? TicketID { get; set; }
        public List<HotelBookingTicketFAQ>? HotelBookingTicketFAQ { get; set; }
    }

    public class HotelBookingTicketFAQ
    {
        public string? Question { get; set; }
        public string? Answer { get; set; }
        public int? SequenceNo { get; set; }
    }
    public class HotelBookingTicketVideodataEntity
    {
        public int? ID { get; set; }
        public int? TicketID { get; set; }
        public string? URL { get; set; }
    }
    public class HotelBookingTicketImagesdataEntity
    {
        public int? ID { get; set; }
        public int? HotelBookingTicketID { get; set; }
        public string? Image { get; set; }
    }
    public class HotelBookingTicketDetailsdataEntity
    {
        public int? ID { get; set; }
        public int? HotelBookingTicketID { get; set; }
        public string? Title { get; set; }
        public int? Rate { get; set; }

    }
    public class HotelBookingTicketImageDataEntity
    {
        public int? ID { get; set; }
 
        public IFormFile? ImageUpload { get; set; }
        public IFormFile? BannerImage { get; set; }
        public List<IFormFile>? Image { get; set; }


    }

    public class HotelBookingTicketSoldOutDateEntity
    {
        public int? HotelBookingTicketID { get; set; }
        public DateTime? SoldOutDate { get; set; }
    }

    public class HotelBookingTicketSoldOutDateViewEntity : MessageBaseEntity
    {
        public int? ID { get; set; }
        public int? HotelBookingTicketID { get; set; }
        public string? SoldOutDate { get; set; }
    }

    public class TicketAvailabilityEntity : MessageBaseEntity
    {
        public int? ID { get; set; }
        public int? AttractionID { get; set; }
        public int? TimeSlotID { get; set; }
        public int? Total { get; set; }
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
        public DateTime? Date { get; set; }


    }
    public class TicketAvailabilityDataViewEntity : MessageBaseEntity
    {
        public int? ID { get; set; }
        public int? AttractionID { get; set; }
        public int? TimeSlotID { get; set; }
        public int? Total { get; set; }
        public DateTime? Date { get; set; }
        public int? Booked { get; set; }
        public int? Available { get; set; }

    }

}
