using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBooking.Entity.Entities
{
    public class HomePageData : MessageBaseEntity
    {
        public List<HomePageBannerData>? Banner { get; set; }
        public List<HomePageHotel>? Hotel { get; set; }
        public List<HomePageHotelBookingTicket>? HotelBookingTicket { get; set; }
        public List<HomePageAtrraction>? Atrraction { get; set; }
        public List<HomePageTour>? Tour { get; set; }
        public List<HomePageTestimonials>? Testimonials { get; set; }
        public List<HomePageCMSData>? CMSList { get; set; }
        public List<HomePageSeotag>? Seotag { get; set; }
        public List<HomePageBlog>? Blog { get; set; }
        public List<HomeHotelBookingPackage>? HotelBookingPackage { get; set; }
        

    }
    public class HomeHotelBookingPackage
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
        public List<HomeHotelBookingPackagePrice>? HotelBookingPackagePrice { get; set; }
    }
    public class HomeHotelBookingPackagePrice
    {
        public int? ID { get; set; }
        public int? HotelBookingPackageID { get; set; }
        public string? Days { get; set; }
        public decimal? CoupleCost { get; set; }
        public decimal? ExtraPersonCost { get; set; }
        public decimal? ExtraChildCost { get; set; }
        public decimal? ChildThreeYrRate { get; set; }
        public decimal? ChildSevenYrRate { get; set; }
        public int? Discount { get; set; }
        public DateTime? Date { get; set; }
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
    }
    public class HomePageBlog
    {
        public int? ID { get; set; }
        public string? BlogImage { get; set; }
        public string? BlogTitle { get; set; }
        public string? BlogDate { get; set; }
        public string? ShortDescription { get; set; }
        public string? LongDescription { get; set; }
        public string? BlogBannerImage { get; set; }
        public string? BlogURL { get; set; }
        public string? MetaTitle { get; set; }
        public string? MetaDescription { get; set; }
        public string? Keyword { get; set; }
        public Boolean? IsActive { get; set; }
        public string Details { get; set; }
        public string Message { get; set; }
        public int Status { get; set; }
        public string ErrorMessage { get; set; }
    }
    public class SAOUTicketListEntity : MessageBaseEntity
    {
        public HomePageHotelBookingTicket? HotelBookingTicket { get; set; }

    }


    public class HomePageBannerData
    {
        public Int32 ID { set; get; }
        public string? BannerType { get; set; }
        public string? BannerTitle { get; set; }
        public string? SubTitle { get; set; }
        public string? Description { get; set; }
        public string? BannerImage { get; set; }
        public string? AltTitle { get; set; }
        public Boolean? IsActive { get; set; }
        public string? Details { get; set; }
        public string? Message { get; set; }
        public int? Status { get; set; }
        public string? ErrorMessage { get; set; }
    }

    public class HomePageHotel
    {
        public int? ID { get; set; }
        public string? ShortDescription { get; set; }
        public string? HotelFacilityID { get; set; }
        public string? HotelName { get; set; }
        public string? Address { get; set; }
        public int? CityID { get; set; }
        public string? CityName { get; set; }
        public int? StateID { get; set; }
        public string? StateName { get; set; }
        public int? CountryID { get; set; }
        public string? CountryName { get; set; }
        public string? HotelCategory { get; set; }
        public string? WeekDays { get; set; }
        public string? WeekEnds { get; set; }
        public bool? IsActive { get; set; }
        public string? HotelDescription { get; set; }
        public string? BookingURL { get; set; }
        public string? Notes { get; set; }
        public string? CancellationPolicy { get; set; }
        public string? URL { get; set; }
        public string? BathroomFacilities { get; set; }
        public string? RoomAminities { get; set; }
        public string? LivingArea { get; set; }
        public string? Bedroom { get; set; }
        public int? SectorID { get; set; }
        public int? TotalRoom { get; set; }
        public Boolean? IsDisplay { get; set; }
        public Decimal? PurchaseRate { get; set; }
        public string? MainImage { get; set; }
        public string? BannerImage { get; set; }
        public int? TotalRecord { get; set; }
        public int? TotalPages { get; set; }
        public int? SequenceNo { get; set; }
        public string? CheckInTime { get; set; }
        public string? CheckOutTime { get; set; }
        public decimal? FarFrom { get; set; }
        public List<HotelFacility> Facilities { get; set; }


    }

    public class HotelFacility
    {
        public int ID { get; set; }
        public string? Name { get; set; }
        public string? FacilityImage { get; set; }

    }
    public class HomePageHotelBookingTicket :MessageBaseEntity
    {
        public int? ID { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public int? SequenceNo { get; set; }
        public string? BookingURL { get; set; }
        public string? ImageUpload { get; set; }
        public Boolean? IsPopular { get; set; }
        public string? CancellationPolicy { get; set; }
        public string? TicketURL { get; set; }
        public string? InstructionsForVisitors { get; set; }
        public string? LastEntry { get; set; }
        public string? Notice { get; set; }
        public Boolean? IsActive { get; set; }
        public string? Details { get; set; }
        public string? Message { get; set; }
        public int? Status { get; set; }
        public string? ErrorMessage { get; set; }
        public decimal? PerPersonRate { get; set; }
        public decimal? ChildSevenYrRate { get; set; }
        public decimal? ChildThreeYrRate { get; set; }
        public List<HotelBookingTicketDetailsdataEntity>? HotelBookingTicketDetails { get; set; }
        public List<HotelBookingTicketImagedataEntity>? HotelBookingTicketImage { get; set; }
        public List<HotelBookingTicketSoldOutDatedataEntity>? HotelBookingTicketSoldOutDate { get; set; }
    }
    public class HotelBookingTicketSoldOutDatedataEntity
        {
        public int? ID { get; set; }
        public int? HotelBookingTicketID { get; set; }
        public string? SoldOutDate { get; set; }
    }

    public class HotelBookingTicketImagedataEntity
    {
        public int? ID { get; set; }
        public int? HotelBookingTicketID { get; set; }
       
        public string? Image { get; set; }
        
    }
    public class HomePageAtrraction
    {
        public int? ID { get; set; }
        public int? PropertyID { get; set; }
        public string? PropertyName { get; set; }
        public string? PropertyURL { get; set; }
        public string? Title { get; set; }
        public string? AttractionURL { get; set; }
        public string? AttractionCategory { get; set; }
        public string? TagLine { get; set; }
        public string? Distance { get; set; }
        public string? TravelTime { get; set; }
        public string? BestTime { get; set; }
        public string? Duration { get; set; }
        public string? Description { get; set; }
        public string? Dos { get; set; }
        public string? Donts { get; set; }
        public string? MainImage { get; set; }
        public string? BannerImage { get; set; }
        public string? MetaTitle { get; set; }
        public string? MetaDescription { get; set; }
        public string? MetaKeywords { get; set; }
        public Boolean? IsActive { get; set; }
        public Boolean? IsMustVisit { get; set; }
        public Boolean? IsDeleted { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public string? UpdatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
    }
    public class HomePageTour
    {
        public int ID { get; set; }
        public string? TourName { get; set; }
        public string? TourURL { get; set; }
        public string? ShortDescription { get; set; }
        public string? LongDescription { get; set; }
        public string? PackageType { get; set; }

        public int? NoOfNights { get; set; }
        public int? NoOfDays { get; set; }
        public decimal? TwoSharing { get; set; }
        public string? MainImage { get; set; }
        public string? MetaTitle { get; set; }
        public string? MetaKeywords { get; set; }
        public string? MetaDescription { get; set; }
        public string? Inclusion { get; set; }
        public string? Exclusion { get; set; }
        public string? KeyPoints { get; set; }
        public string? Highlights { get; set; }
        public Boolean? IsPopular { get; set; }
        public string? BookingURL { get; set; }
        public int? SequenceNo { get; set; }
        public bool? IsActive { get; set; }
        public string? Details { get; set; }
        public string? Message { get; set; }
        public int? Status { get; set; }
        public string? ErrorMessage { get; set; }
    }
    public class HomePageTestimonials
    {
        public Int32? ID { set; get; }
        public string? CustomerName { get; set; }
        public string? Description { get; set; }
        public string? UniversityName { get; set; }
        public string? TestimonialImage { get; set; }
        public string? TestimonialURL { get; set; }
        public Boolean? IsActive { get; set; }
        public string? Details { get; set; }
        public string? Message { get; set; }
        public int? Status { get; set; }
        public string? ErrorMessage { get; set; }
    }
    public class HomePageCMSData
    {
        public int ID { get; set; }
        public string? Name { get; set; }
        public string? Template { get; set; }
        public string? CMSURL { get; set; }
        public string? MetaTitle { get; set; }
        public string? MetaDescription { get; set; }
        public string? MetaKeyword { get; set; }
        public string? CMSImage { get; set; }
        public string? CMSImageAlterTag { get; set; }
        public bool? IsActive { get; set; }
        public string? Details { get; set; }
        public string? Message { get; set; }
        public int? Status { get; set; }
        public string? ErrorMessage { get; set; }
    }
    public class HomePageSeotag
    {
        public Int32 ID { set; get; }
        public string? PageName { get; set; }
        public string? PageUrl { get; set; }
        public string? MetaTitle { get; set; }
        public string? MetaKeywords { get; set; }
        public string? MetaDescription { get; set; }
        public Boolean? IsActive { get; set; }
        public string? Details { get; set; }
        public string? Message { get; set; }
        public int? Status { get; set; }
        public string? ErrorMessage { get; set; }
    }

    public class TourUrlEntity : MessageBaseEntity
    {
        public int ID { get; set; }
        public string? TourName { get; set; }
        public string? TourURL { get; set; }
        public string? ShortDescription { get; set; }
        public string? LongDescription { get; set; }
        public string? PackageType { get; set; }

        public int? NoOfNights { get; set; }
        public int? NoOfDays { get; set; }

        public string? MetaTitle { get; set; }
        public string? MetaKeywords { get; set; }
        public string? MetaDescription { get; set; }
        public string? Inclusion { get; set; }
        public string? Exclusion { get; set; }
        public string? KeyPoints { get; set; }
        public string? Highlights { get; set; }
        public string? MainImage { get; set; }
        public string? BannerImage { get; set; }
        public decimal? TwoSharing { get; set; }
        public Boolean? IsPopular { get; set; }
        public string? BookingURL { get; set; }
        public int? SequenceNo { get; set; }
        public bool? IsActive { get; set; }
        public string? Details { get; set; }
        public string? Message { get; set; }
        public int? Status { get; set; }
        public string? ErrorMessage { get; set; }
        public List<WeddingInnserimageEntity> Innerimage { get; set; }
        public List<TourItineraryEntity> TourItinerary { get; set; }
        public List<TourCostEntity> TourCost { get; set; }
        public List<VideoGalleryViewEntity> VideoGallery { get; set; }
        public List<FAQDataViewEntity> FAQ { get; set; }
        
    }
    public class TourItineraryEntity
    {
        public int? ID { get; set; }
        public int? TourID { get; set; }
        public string? TourName { get; set; }
        public int? DayNo { get; set; }
        public int? CreatedBy { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
    }
    public class TourCostEntity
    {
        public int? ID { get; set; }
        public int? TourID { get; set; }
        public string? StartDate { get; set; }
        public string? EndDate { get; set; }

        public decimal? TwoSharing { get; set; }
        public decimal? ExtraAdults { get; set; }
        public decimal? CWB { get; set; }
        public decimal? CNB { get; set; }

        public int? RoomTypeID { get; set; }
        public string? RoomTypeName { get; set; }
        public string? RateTitle { get; set; }

        public decimal? TwoPax { get; set; }
        public decimal? FourPax { get; set; }
        public decimal? SixPax { get; set; }
        public decimal? EightPax { get; set; }
        public decimal? TenPax { get; set; }

        public string? PickupLocation { get; set; }
        public int? VehicleTypeID { get; set; }
        public string? VehicleTypeName { get; set; }

        public bool? IsActive { get; set; }
        public bool? IsDeleted { get; set; }

        public int? CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
    }
    public class TourByURLEntity
    {
        public string? TourURL  { get; set; }
    }

    public class AnalyticsCountEntity
    {
        public string? URL { get; set; }
    }

    public class AnalyticsCountViewEntity : MessageBaseEntity
    {
        public int? ID { get; set; }
 
        public int? Count { get; set; }
    }

    public class BookingReferenceEntity : MessageBaseEntity
    {

        public int? ID { get; set; }
        public int? RoomID { get; set; }
        public string? URL { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public string? Country { get; set; }
        public string? IP { get; set; }
        public string? Pincode { get; set; }
        public decimal? Latitude { get; set; }
        public decimal? Longitude { get; set; }
        public string? CreatedOn { get; set; }
        public int? Skip { get; set; }
        public int? Limit { get; set; }
    }

    public class BookingReferenceViewEntity
    {

        public int? ID { get; set; }
        public int? RoomID { get; set; }
        public string? URL { get; set; }
        public string? City { get; set; }
        public string? CreatedOn { get; set; }
        public int? ItemCount { get; set; }
        public int? TotalPages { get; set; }
        public string? RoomName { get; set; }
        public string? Details { get; set; }
        public string? Message { get; set; }
        public int? Status { get; set; }
        public string? ErrorMessage { get; set; }
    }

}
