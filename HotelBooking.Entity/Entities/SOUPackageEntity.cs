using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBooking.Entity.Entities
{
    public class HotelBookingPackageEntity
    {
        public int? ID { get; set; }
        public string? Title { get; set; }
        
        public string? ShortDescription { get; set; }
        public string? Description { get; set; }
        public int? SequenceNo { get; set; }
        public string? PackageURL { get; set; }
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
        public bool? IsPopular { get; set; }
        public string? AttractionID { get; set; }
        public bool? IsViewingGallery { get; set; }
        public bool? IsProjectMapping { get; set; }
       
        public decimal? ChildSevenYrRate { get; set; }
        public decimal? ChildThreeYrRate { get; set; }
       
        public string? Notice { get; set; }
        public string? ERickshaw { get; set; }
        public int? ResortID { get; set; }
        public int? NoOfNights { get; set; }
        public decimal? PerCoupleRate { get; set; }
        public decimal? ExtraPersonRate { get; set; }
        public string? Itinerary { get; set; }
        public string? Highlights { get; set; }
        public int? RoomCategoryID { get; set; }
        public int? MealTypeID { get; set; }
        public List<HotelBookingPackageDetailsEntity>? HotelBookingPackageDetails { get; set; }

    }
    public class HotelBookingPackageVideoEntity
    {
        public int? TicketID { get; set; }
        public List<HotelBookingPackageVideo>? HotelBookingPackageVideo { get; set; }
    }
    public class HotelBookingPackageVideo
    {
        public string? URL { get; set; }
    }
    public class HotelBookingPackageDocumentsImage
    {
        public string? Image { get; set; }
    }
    public class HotelBookingPackageImage
    {
        public int? ID { get; set; }
        public int? HotelBookingPackageID { get; set; }
        public IFormFile? MainImage { get; set; }
        public IFormFile? BannerImage { get; set; }
        public List<IFormFile>? Image { get; set; }
    }
    public class HotelBookingPackageDetailsEntity
    {
        public string? Title { get; set; }
        public decimal? Rate { get; set; }

    }
    public class HotelBookingPackageIDEntity : MessageBaseEntity
    {
        public int? ID { get; set; }

  
        public string? PackageURL { get; set; }
        public string? Title { get; set; }
        public Int32? UpdatedBy { set; get; }
        public Boolean? IsActive { get; set; }
    }

    public class HotelBookingPackageViewEntity : MessageBaseEntity
    {
        public int? ID { get; set; }
        public string? Title { get; set; }
     
        public string? ShortDescription { get; set; }
        public string? Description { get; set; }
        public int? SequenceNo { get; set; }
        public string? PackageURL { get; set; }
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
        public Boolean? IsActive { get; set; }
        public string? Details { get; set; }
        public string? Message { get; set; }
        public int? Status { get; set; }
        public string? ErrorMessage { get; set; }
        public string? AttractionID { get; set; }
        public string? AttractionName { get; set; }
        public bool? IsViewingGallery { get; set; }
        public bool? IsProjectMapping { get; set; }
        public decimal? ServiceCharge { get; set; }
        public int? ServiceChargeType { get; set; }
        public decimal? ServiceChargeValue { get; set; }
 
        public decimal? ChildSevenYrRate { get; set; }
        public decimal? ChildThreeYrRate { get; set; }
        public string? ERickshaw { get; set; }
        public int? ResortID { get; set; }
        public int? NoOfNights { get; set; }
        public decimal? PerCoupleRate { get; set; }
        public decimal? ExtraPersonRate { get; set; }
        public string? Itinerary { get; set; }

        public string? Highlights { get; set; }
        public string? HotelName { get; set; }
        public int? RoomCategoryID { get; set; }
        public string? RoomCategoryName { get; set; }
        public int? MealTypeID { get; set; }
        public string? MealTypeName { get; set; }
        public string? MealTypeDescription { get; set; }
        public string? HotelAddress { get; set; }

        public List<HotelBookingPackageDetailsdataEntity>? HotelBookingPackageDetails { get; set; }
        public List<HotelBookingPackageImagesdataEntity>? HotelBookingPackageImage { get; set; }
        public List<HotelBookingPackageItineraryEntity>? HotelBookingPackageItinerary { get; set; }
        public List<HotelBookingPackageHotelImages>? HotelBookingPackageHotelImages { get; set; }
        public List<HotelBookingPackageVideodataEntity>? HotelBookingPackageVideo { get; set; }
        public List<HotelBookingPackageFAQdataEntity>? HotelBookingPackageFAQ { get; set; }
        public List<HotelBookingPackageAnotherTicketEntity>? AnotherTicket { get; set; }
        public List<HotelBookingPackageTimeSlotEntity>? TimeSlot { get; set; }
        public List<HotelBookingPackageSoldOutDateVeiwEntity>? HotelBookingPackageSoldOutDate { get; set; }

        public List<ViewingGalleryEntity>? ViewingGallery { get; set; }
        public List<ViewingGalleryEntity>? ProjectionMapping { get; set; }
        public List<HotelBookingTicketPaxSoldOutDateViewEntity>? HotelBookingTicketSoldOutDateforpax { get; set; }
        public List<HotelBookingPackagePriceEntity>? PackagePrices { get; set; }
        public List<AttractionTicket>? AttractionTicket { get; set; }


    }

    public class HotelBookingPackageHotelImages
    {
        public int? ID { get; set; }
        public int? HotelID { get; set; }
        public int? SrNo { get; set; }
        public string? ImagePath { get; set; }
        public string? Remarks { get; set; }
    }
    public class HotelBookingPackageItineraryEntity
    {
        public int? ID { get; set; }
        public int? HotelBookingPackageID { get; set; }
        public string? TourName { get; set; }
        public int? DayNo { get; set; }
        public int? CreatedBy { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
    }
    public class HotelBookingPackageSoldOutDateVeiwEntity
    {
        public int? ID { get; set; }
        public int? HotelBookingPackageID { get; set; }
        public string? SoldOutDate { get; set; }
    }

    public class HotelBookingPackageTimeSlotEntity
    {
        public int? AttractionID { get; set; }
        public string? Title { get; set; }
        public string? TicketType { get; set; }
        public string? TimeSlot { get; set; }
    }

    public class HotelBookingPackageAnotherTicketEntity
    {
        public int? ID { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public int? SequenceNo { get; set; }
        public string? PackageURL { get; set; }
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
        public List<HotelBookingPackageDetailsdataEntity>? AnotherTicketDetails { get; set; }
    }

    public class HotelBookingPackageFAQdataEntity
    {
        public int? ID { get; set; }
        public int? TicketID { get; set; }
        public int? SequenceNo { get; set; }
        public string? Question { get; set; }
        public string? Answer { get; set; }

    }

    public class HotelBookingPackageFAQEntity
    {
        public int? TicketID { get; set; }
        public List<HotelBookingPackageFAQ>? HotelBookingPackageFAQ { get; set; }
    }

    public class HotelBookingPackageFAQ
    {
        public string? Question { get; set; }
        public string? Answer { get; set; }
        public int? SequenceNo { get; set; }
    }
    public class HotelBookingPackageVideodataEntity
    {
        public int? ID { get; set; }
        public int? TicketID { get; set; }
        public string? URL { get; set; }
    }
    public class HotelBookingPackageImagesdataEntity
    {
        public int? ID { get; set; }
        public int? HotelBookingPackageID { get; set; }
        public string? Image { get; set; }
    }
    public class HotelBookingPackageDetailsdataEntity
    {
        public int? ID { get; set; }
        public int? HotelBookingPackageID { get; set; }
        public string? Title { get; set; }
        public int? Rate { get; set; }

    }
    public class HotelBookingPackageImageDataEntity
    {
        public int? ID { get; set; }

        public IFormFile? ImageUpload { get; set; }
        public IFormFile? BannerImage { get; set; }
        public List<IFormFile>? Image { get; set; }


    }

    public class HotelBookingPackageSoldOutDateEntity
    {
        public int? HotelBookingPackageID { get; set; }
        public DateTime? SoldOutDate { get; set; }
    }

    public class HotelBookingPackageSoldOutDateViewEntity : MessageBaseEntity
    {
        public int? ID { get; set; }
        public int? HotelBookingPackageID { get; set; }
        public string? SoldOutDate { get; set; }
    }

    public class HotelBookingPackageItinerariesEntity
    {
        public int? ID { get; set; }
        public Boolean? IsActive { get; set; }
        public int? CreatedBy { set; get; }
        public int? UpdatedBy { set; get; }

        public List<Itineraries>? ItinerariesData { get; set; }
    }
    public class HotelBookingPackageItineraryDetailsEntity
    {
        public int? ID { get; set; }
        public int? HotelBookingPackageID { get; set; }
        public int? DayNo { get; set; }
        public int? SequenceNo { get; set; }
        public int? CreatedBy { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }

    }
    public class HotelBookingPackageRateViewEntity : MessageBaseEntity
    {
        public int? HotelBookingPackageID { get; set; }
    }
    public class HotelBookingPackageItineraryDetailsViewEntity : MessageBaseEntity
    {
        public int? ID { get; set; }
        public int? TourID { get; set; }
        public int? SequenceNo { get; set; }
        public string? TourName { get; set; }
        public int? DayNo { get; set; }
        public int? CreatedBy { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
    }
}
