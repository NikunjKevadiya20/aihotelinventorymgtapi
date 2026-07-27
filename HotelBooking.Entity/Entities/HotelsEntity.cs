using Microsoft.AspNetCore.Http;
using Org.BouncyCastle.Bcpg.OpenPgp;

/// <summary>
/// Added by NikunjK on 01-08-2023
/// </summary>
namespace HotelBooking.Entity.Entities
{
    public class HotelsDataEntity
    {
        public int? ID { get; set; }
        public int? PropertyTypeID { get; set; }
        public int? TillChildAge { get; set; }
        public string? PropertyRules { get; set; }
        public string? GoogleMapURL { get; set; }
        public string? ShortDescription { get; set; }
        public string? HotelFacilityID { get; set; }
        public string? HotelName { get; set; }
        public string? Address { get; set; }
        public int? CityID { get; set; }
        public int? StateID { get; set; }
        public int? CountryID { get; set; }
        public string? HotelCategory { get; set; }
        public string? WeekDays { get; set; }
        public string? WeekEnds { get; set; }
        public bool? IsActive { get; set; }
        public int? CreatedBy { get; set; }
        public int? UpdatedBy { get; set; }
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
        public int? IsUser { get; set; }
        public int? IsUpdatedUser { get; set; }
        public int? SequenceNo { get; set; }
        public string? CheckInTime { get; set; }
        public string? CheckOutTime { get; set; }
        public string? MetaTitle { get; set; }
        public string? MetaKeywords { get; set; }
        public string? MetaDescription { get; set; }
        public decimal? FarFrom { get; set; }

    }

    #region Hotel rates Response Entity by AI003 on 20-05-2023
    public class HotelResEntity : MessageBaseEntity
    {
        public int? ID { get; set; }
        public int? HotelID { get; set; }
    }
    #endregion
    public class HotelContacts
    {
        public int? HotelID { get; set; }
        public string? PersonName { get; set; }
        public string? MobileNo { get; set; }
        public string? EmailID { get; set; }
        public string? AlternateMobileNo { get; set; }
        public string? AlternateEmailID { get; set; }
        public Boolean? IsOwner { get; set; }
    }

    public class HotelsIDEntity : MessageBaseEntity
    {
        public int? ID { get; set; }
        public int? HotelID { get; set; }
        public int? CategoryID { get; set; }
        public int? MealPlanID { get; set; }
        public int? DeletedBy { get; set; }
        public int? IsDeletedUser { get; set; }
        public string? HotelName { get; set; }
        public int? PlaceID { get; set; }
        public string? HotelCategory { get; set; }
        public DateTime? Date { get; set; }
        public int? Limit { get; set; }
        public int? Skip { get; set; }
        public bool? IsActive { get; set; }
        public int? UpdatedBy { get; set; }
        public int? IsUpdatedUser { get; set; }
        public string? URL { get; set; }
        public string? SectorType { get; set; }

    }
    public class HotelsAvailabilityEntity  
    {
        public DateTime? VisitDate { get; set; }
    }
    public class HotelsViewEntity : MessageBaseEntity
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
        public int? AvailableRoomCount { get; set; }
        public Boolean? IsDisplay { get; set; }
        public Decimal? PurchaseRate { get; set; }
        public string? MainImage { get; set; }
        public string? BannerImage { get; set; }
        public int? TotalRecord { get; set; }
        public int? TotalPages { get; set; }
        public int? SequenceNo { get; set; }
        public string? CheckInTime { get; set; }
        public string? CheckOutTime { get; set; }
        public string? MetaTitle { get; set; }
        public string? MetaKeywords { get; set; }
        public string? MetaDescription { get; set; }
        public decimal? FarFrom { get; set; }
        public List<HotelFacility> Facilities { get; set; }
        public IEnumerable<HotelCategoryResponse>? RoomCategoryList { get; set; }

    }

    public class HotelsFindByViewEntity : MessageBaseEntity
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
        public Boolean? IsDisplay { get; set; }
        public Decimal? PurchaseRate { get; set; }
        public string? MainImage { get; set; }
        public string? BannerImage { get; set; }
        public string? HotelLogo { get; set; }
        public string? BathroomFacilities { get; set; }
        public string? RoomAminities { get; set; }
        public string? LivingArea { get; set; }
        public string? Bedroom { get; set; }
        public int? SectorID { get; set; }
        public int? TotalRoom { get; set; }
        public int? SequenceNo { get; set; }
        public string? CheckInTime { get; set; }
        public string? CheckOutTime { get; set; }
        public string? MetaTitle { get; set; }
        public string? MetaKeywords { get; set; }
        public string? MetaDescription { get; set; }
        public decimal? FarFrom { get; set; }


        public int? PropertyTypeID { get; set; }
        public int? TillChildAge { get; set; }
        public string? PropertyRules { get; set; }
        public string? GoogleMapURL { get; set; }
        public string? PropertyTypeName { get; set; }

        public IEnumerable<HotelContactEnityReq>? HotelContactList { get; set; }
        public IEnumerable<HotelCategoryResponse>? RoomCategoryList { get; set; }
        public IEnumerable<HotelRatesViewEntity>? WeekDaysRateList { get; set; }
        public IEnumerable<HotelRatesViewEntity>? WeekEndRateList { get; set; }
        public IEnumerable<HotelSpecialRateResEntity>? SpecialDateRateList { get; set; }
        public IEnumerable<HotelRatesViewEntity>? RegularDaysRateList { get; set; }
        public IEnumerable<HotelImages>? HotelImages { get; set; }
        public IEnumerable<FAQDataViewByHotelEntity>? FAQList { get; set; }

    }
    public class HotelImages
    {
        public int? ID { get; set; }
        public int? HotelID { get; set; }
        public int? SrNo { get; set; }
        public string? ImagePath { get; set; }
        public string? Remarks { get; set; }
    }

    #region Hotelcontacts View Entity
    public class HotelContactEnityReq
    {
        public int? ID { get; set; }
        public int? HotelID { get; set; }
        public string? ContactPersonName { get; set; }
        public string? ContactPersonMobileNo { get; set; }
        public string? ContactPersonEmailID { get; set; }
        public string? ContactPersonDesignation { get; set; }
        public bool? IsActive { get; set; }
    }
    #endregion


    #region Hotel Category Respoanse 
    public class HotelCategoryResponse
    {
        public int? ID { get; set; }
        public int? HotelID { get; set; }
        public string? RoomCategoryName { get; set; }
        public int? RoomCategoryID { get; set; }
        public bool? IsActive { get; set; }
        public List<HotelCategoryImage> Images { get; set; } = new();
        public List<HotelPriceRangeDataEntity> HotelPrice { get; set; } = new();
    }
    public class HotelPriceRangeDataEntity : MessageBaseEntity
    {
        public int? ID { get; set; }
        public int? HotelID { get; set; }
        public int? RoomCategoryID { get; set; }
        public int? MealPlanID { get; set; }
        public string? RoomCategoryName { get; set; }
        public string? MealPlanName { get; set; }
        public string? MealDescription { get; set; }
        public decimal? CoupleCost { get; set; }
        public decimal? ExtraPersonCost { get; set; }
        public decimal? ExtraChildCost { get; set; }
        public int? Discount { get; set; }
        public DateTime? Date { get; set; }

    }
    public class HotelCategoryImage
    {
        public int? ID { get; set; }
        public int? RoomCategoryID { get; set; }
        public string? OtherImage { get; set; }
    }
    #endregion


    #region Hotel weekdays/weekends Response Entity by AI003 on 20-05-2023
    public class HotelRatesViewEntity
    {
        public int? ID { get; set; }
        public int? DateType { get; set; }
        public int? HotelID { get; set; }
        public string? HotelName { get; set; }
        public int? RoomCategoryID { get; set; }
        public string? RoomCategoryName { get; set; }
        public decimal? SOEPAI { get; set; }
        public decimal? SOCPAI { get; set; }
        public decimal? SOMAPAI { get; set; }
        public decimal? SOAPAI { get; set; }
        public int? CNBAge { get; set; }
        public decimal? KitchenCharges { get; set; }
        public bool? IsActive { get; set; }
        public string? FromDate { get; set; }
        public string? ToDate { get; set; }
        public int? MealID { get; set; }
        public string? Meal { get; set; }
        public string? Description { get; set; }
        public decimal? MarkupAmount { get; set; }
        public string? MarkupType { get; set; }
        public decimal? SingleOccupancyRate { get; set; }
        public decimal? DoubleOccupancyRate { get; set; }
        public decimal? ExtraPersonRate { get; set; }
        public decimal? ChildWithBedRate { get; set; }
        public decimal? ChildWithoutBedRate { get; set; }
        public decimal? SingleOccPurRate { get; set; }
        public decimal? DoubleOccPurRate { get; set; }
        public decimal? ExtraPerPurRate { get; set; }
        public decimal? CWBPurRate { get; set; }
        public decimal? CNBPurRate { get; set; }

    }
    #endregion

    #region HotelSpecialRatesView Entity bby AI003 on 20-05-2023
    public class HotelSpecialRateResEntity
    {
        public int? ID { get; set; }
        public int? DateType { get; set; }
        public int? HotelID { get; set; }
        public string? HotelName { get; set; }
        public int? RoomCategoryID { get; set; }
        public string? RoomCategoryName { get; set; }
        public int? FestivalID { get; set; }
        public string? FestivalName { get; set; }
        public string? FromDate { get; set; }
        public string? ToDate { get; set; }
        public decimal? SOEPAI { get; set; }
        public decimal? SOCPAI { get; set; }
        public decimal? SOMAPAI { get; set; }
        public decimal? SOAPAI { get; set; }
        public int? CNBAge { get; set; }
        public decimal? KitchenCharges { get; set; }
        public bool? IsActive { get; set; }
        public int? MealID { get; set; }
        public string? Meal { get; set; }
        public string? Description { get; set; }
        public decimal? MarkupAmount { get; set; }
        public string? MarkupType { get; set; }
        public decimal? SingleOccupancyRate { get; set; }
        public decimal? DoubleOccupancyRate { get; set; }
        public decimal? ExtraPersonRate { get; set; }
        public decimal? ChildWithBedRate { get; set; }
        public decimal? ChildWithoutBedRate { get; set; }
        public decimal? SingleOccPurRate { get; set; }
        public decimal? DoubleOccPurRate { get; set; }
        public decimal? ExtraPerPurRate { get; set; }
        public decimal? CWBPurRate { get; set; }
        public decimal? CNBPurRate { get; set; }


    }
    #endregion




    public class Hotel
    {
        public string? HotelName { get; set; }
        public string? Address { get; set; }
        public string? StateName { get; set; }
        public string? CountryName { get; set; }
        public string? CityName { get; set; }
        public string? HotelCategory { get; set; }
        public string? WeekDays { get; set; }
        public string? WeekEnds { get; set; }
        public string? ContactPersonName { get; set; }
        public string? ContactPersonMobileNo { get; set; }
        public string? ContactPersonEmailID { get; set; }
        public string? ContactPersonDesignation { get; set; }
        public int? UserID { get; set; }

    }

    public class HotelExcelExport
    {
        public string? HotelName { get; set; }
        public string? CityName { get; set; }
        public string? HotelCategory { get; set; }
        public int? UserID { get; set; }

    }

    public class HotelRateSpecialDateNew
    {
        public string? HotelName { get; set; }
        public string? FromDate { get; set; }
        public string? ToDate { get; set; }
        public string? RoomCategoryName { get; set; }
        public decimal? DoubleOccupancyRate { get; set; }
        public decimal? ExtraPersonRate { get; set; }
        public decimal? ChildWithBedRate { get; set; }
        public decimal? ChildWithoutBedRate { get; set; }
        public string? MealType { get; set; }
        public string? DateType { get; set; }


    }
    public class HotelRateSpecialDate
    {
        public string? HotelName { get; set; }
        public string? FestivalName { get; set; }
        public string? FromDate { get; set; }
        public string? ToDate { get; set; }
        public string? RoomCategoryName { get; set; }
        public decimal? SingleOccupancyRate { get; set; }
        public decimal? DoubleOccupancyRate { get; set; }
        public decimal? ExtraPersonRate { get; set; }
        public decimal? ChildWithBedRate { get; set; }
        public decimal? ChildWithoutBedRate { get; set; }
        public decimal? SingleOccPurRate { get; set; }
        public decimal? DoubleOccPurRate { get; set; }
        public decimal? ExtraPerPurRate { get; set; }
        public decimal? CWBPurRate { get; set; }
        public decimal? CNBPurRate { get; set; }
        public decimal? KitchenCharges { get; set; }
        public string? MealType { get; set; }
        public string? DateType { get; set; }


    }
    public class HotelImageEntity : MessageBaseEntity
    {
        public int? ID { get; set; }
        public string? MainImage { get; set; }
        public string? BannerImage { get; set; }
        public string? HotelLogo { get; set; }
        public int? UpdatedBy { get; set; }

        public List<HotelImageListEntity>? InnerImages { get; set; }

    }
    public class HotelImageListEntity
    {
        public string? ImagePath { get; set; }
        public int? SrNo { get; set; }       // NEW
        public string? Remarks { get; set; } // NEW
    }

    public class HotelImageUploadEntity
    {
        public int? ID { get; set; }
        public IFormFile? MainImage { get; set; }
        public IFormFile? BannerImage { get; set; }
        public IFormFile? HotelLogo { get; set; }
        public List<IFormFile>? InnerImages { get; set; }
        public List<int?>? InnerImageSrNo { get; set; }      // NEW
        public List<string>? InnerImageRemarks { get; set; } // NEW
    }

    public class HotelSearchForWebsite : MessageBaseEntity
    {
        public int? ID { get; set; }
        public string? URL { get; set; }
        public string? HotelName { get; set; }
        public string? Address { get; set; }
        public string? CityName { get; set; }

    }
    public class HotelsCity : MessageBaseEntity
    {
        public int? CityID { get; set; }
        public string? CityName { get; set; }
    }

    public class FAQDataViewByHotelEntity
    {
        public int? HotelID { get; set; }
        public string? ServiceName { get; set; }
        public string? Question { get; set; }
        public string? Answer { get; set; }
        public int? SequenceNo { get; set; }
        public Boolean? IsActive { get; set; }
    }

    public class HotelRoomEntity
    {
        public int? ID { get; set; }
        public int? HotelID { get; set; }
        public int? CategoryID { get; set; }
        public int? Total { get; set; }
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
        public DateTime? CreatedOn { get; set; }

    }
    public class HotelRoomPriceViewEntity :MessageBaseEntity
    {
        public List<HotelRoomViewEntity>? HotelRoom { get; set; }
        public List<HotelPriceRangeViewEntity>? HotelPrice { get; set; }
    }
    public class HotelRoomViewEntity : MessageBaseEntity
    {
        public int? ID { get; set; }
        public int? HotelID { get; set; }
        public int? CategoryID { get; set; }
        public int? Total { get; set; }
        public int? Booked { get; set; }
        public int? Available { get; set; }
        public DateTime? Date { get; set; }

    }


    public class HotelPriceRangeEntity
    {
        public int? ID { get; set; }
        public int? HotelID { get; set; }
        public int? RoomCategoryID { get; set; }
        public int? HotelBookingTicketID { get; set; }
        public int? MealPlanID { get; set; }
        public string? Days { get; set; }
        public decimal? CoupleCost { get; set; }
        public decimal? ExtraPersonCost { get; set; }
        public decimal? ExtraChildCost { get; set; }
        public int? Discount { get; set; }
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
        public DateTime? CreatedOn { get; set; }
    }

    public class HotelPriceRangeViewEntity : MessageBaseEntity
    {
        public int? ID { get; set; }
        public int? HotelID { get; set; }
        public int? RoomCategoryID { get; set; }
        public int? MealPlanID { get; set; }
        public string? MealPlanName { get; set; }
        public string? MealDescription { get; set; }
        public int? Total { get; set; }
        public int? Booked { get; set; }
        public int? Available { get; set; }
        public int? GSTPercentage { get; set; }

        public string? Days { get; set; }
        public decimal? CoupleCost { get; set; }
        public decimal? ExtraPersonCost { get; set; }
        public decimal? ExtraChildCost { get; set; }
        public int? Discount { get; set; }
        public DateTime? Date { get; set; }

    }

    public class HotelPriceEntity
    {
        public int? HotelID { get; set; }
        public int? RoomCategoryID { get; set; }
        public int? MealPlanID { get; set; }
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
        public DateTime? Date { get; set; }

    }
    public class HotelBookingPackagePriceEntity
    {
        public int? HotelBookingPackageID { get; set; }
        public string? Days     { get; set; }
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
    public class HotelBookingPackagePriceViewEntity : MessageBaseEntity
    {
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
 }
