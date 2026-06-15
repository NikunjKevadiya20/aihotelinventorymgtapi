using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBooking.Entity.Entities
{
    public class TourEntity
    {
        public int? ID { get; set; }
        public int? PackageTypeID { get; set; }
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


        public string? BookingURL { get; set; }

        public int? SequenceNo { get; set; }
        public bool? IsPopular { get; set; }
        public bool? IsActive { get; set; }
        public int? CreatedBy { get; set; }
        public int? UpdatedBy { get; set; }
        public string? Details { get; set; }
        public string? Message { get; set; }
    }

    public class TourIDEntity : MessageBaseEntity
    {
        public int? ID { get; set; }
        public int? PackageTypeID { get; set; }
       
        public string? TourName { get; set; }
        public int? UpdatedBy { get; set; }
        public bool? IsActive { get; set; }
    }

    public class TourDataViewEntity : MessageBaseEntity
    {
        public int ID { get; set; }
        public int? PackageTypeID { get; set; }
        public string? PackageTypeName { get; set; }
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
        public bool? IsPopular { get; set; }
        public string? BookingURL { get; set; }
        public int? SequenceNo { get; set; }
        public bool? IsActive { get; set; }
        public string? Details { get; set; }
        public string? Message { get; set; }
        public int? Status { get; set; }
        public string? ErrorMessage { get; set; }
        public List<WeddingInnserimageEntity> Innerimage { get; set; }
        public List<TourVideodataEntity>? TourVideo { get; set; }
        public List<TourFAQdataEntity>? TourFAQ { get; set; }
    }

    public class WeddingInnserimageEntity
    {
        public int? ID { get; set; }
        public string? Images { get; set; }
    }

    public class TourImageDataEntity
    {
        public int? ID { get; set; }

        public IFormFile? MainImage { get; set; }
        public IFormFile? BannerImage { get; set; }
        public List<IFormFile>? Images { get; set; }
    }

    public class TourIDViewEntity : MessageBaseEntity
    {
        public int? ID { get; set; }
    }
    public class TourDocumentsImage
    {
        public string? Images { get; set; }
    }
    public class TourItineraryDetailsEntity
    {
        public int? ID { get; set; }
        public int? TourID { get; set; }
        public int? DayNo { get; set; }
        public int? SequenceNo { get; set; }
        public int? CreatedBy { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }

    }
    public class TourItinerariesEntity
    {
        public int? ID { get; set; }
        public Boolean? IsActive { get; set; }
        public int? CreatedBy { set; get; }
        public int? UpdatedBy { set; get; }

        public List<Itineraries>? ItinerariesData { get; set; }
    }

    public class Itineraries
    {
        public int? HotelBookingPackageID { get; set; }
        public int? DayNo { get; set; }
        public int? SequenceNo { get; set; }
       
        public string? Title { get; set; }
         
        public string? Description { get; set; }
    }
    public class TourItineraryDetailsViewEntity :MessageBaseEntity
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

    public class TourRateViewEntity : MessageBaseEntity 
    {
        public int? TourID { get; set; }
    }

    public class TourCostDetailsEntity
    {
        public int? ID { get; set; }
        public int? TourID { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }

        public decimal? TwoSharing { get; set; }
        public decimal? ExtraAdults { get; set; }
        public decimal? CWB { get; set; }
        public decimal? CNB { get; set; }

        public int? RoomTypeID { get; set; }
        public string? RateTitle { get; set; }

        public decimal? TwoPax { get; set; }
        public decimal? FourPax { get; set; }
        public decimal? SixPax { get; set; }
        public decimal? EightPax { get; set; }
        public decimal? TenPax { get; set; }

        public string? PickupLocation { get; set; }
        public int? TwoPaxVehicleType { get; set; }
        public int? FourPaxVehicleType { get; set; }
        public int? EightPaxVehicleType { get; set; }

        public bool? IsActive { get; set; }
        public bool? IsDeleted { get; set; }

        public int? CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
    }
    public class TourCostDetailsViewEntity : MessageBaseEntity
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
        public int? TwoPaxVehicleType { get; set; }
        public string? TwoPaxVehicleTypeName { get; set; }
        public int? FourPaxVehicleType { get; set; }
        public string? FourPaxVehicleTypeName { get; set; }
        public int? EightPaxVehicleType { get; set; }
        public string? EightPaxVehicleTypeName { get; set; }

        public bool? IsActive { get; set; }
        public bool? IsDeleted { get; set; }

        public int? CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }

        public List<TourVideodataEntity>? TourVideo { get; set; }
        public List<TourFAQdataEntity>? TourFAQ { get; set; } 

    }
    public class TourFAQdataEntity
    {
        public int? ID { get; set; }
        public int? TourID { get; set; }
        public int? SequenceNo { get; set; }
        public string? Question { get; set; }
        public string? Answer { get; set; }

    }

    public class TourFAQEntity
    {
        public int? TourID { get; set; }
        public List<TourFAQ>? TourFAQ { get; set; }
    }

    public class TourFAQ
    {
        public string? Question { get; set; }
        public string? Answer { get; set; }
        public int? SequenceNo { get; set; }
    }
    public class TourVideodataEntity
    {
        public int? ID { get; set; }
        public int? TourID { get; set; }
        public string? URL { get; set; }
    }
    public class TourVideoEntity
    {
        public int? TourID { get; set; }
        public List<TourVideo>? TourVideo { get; set; }
    }
    public class TourVideo
    {
        public string? URL { get; set; }
    }
}
