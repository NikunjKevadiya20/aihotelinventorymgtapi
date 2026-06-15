namespace HotelBooking.Entity.Entities
{
    public class HotelSpecialRateDataEntity : MessageBaseEntity
    {
        public int? ID { get; set; }
        public int? DateType { get; set; }
        public int? HotelID { get; set; }
        public int? RoomCategoryID { get; set; }
        public int? FestivalID { get; set; }
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
        public decimal? SOEPAI { get; set; }
        public decimal? SOCPAI { get; set; }
        public decimal? SOMAPAI { get; set; }
        public decimal? SOAPAI { get; set; }
        public decimal? KitchenCharges { get; set; }
        public bool? IsActive { get; set; }
        public int? CreatedBy { get; set; }
        public int? UpdatedBy { get; set; }
        public int? DeletedBy { get; set; }
        public int? IsUser { get; set; }
        public int? IsUpdatedUser { get; set; }
        public int? IsDeletedUser { get; set; }
        public int? MealID { get; set; }
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
        public string? Details { get; set; }
        public string? Message { get; set; }

    }
    public class HotelSpecialRateIDEntity : MessageBaseEntity
    {
        public int? ID { get; set; }
        public int? CountryID { get; set; }
        public string? CountryName { get; set; }
        public int? HotelID { get; set; }

        public int? StateID { get; set; }
        public string? StateName { get; set; }
        public string? HotelSpecialRateName { get; set; }
        public Int32? UpdatedBy { set; get; }
        public Boolean? IsActive { get; set; }
    }

    public class HotelSpecialRateViewEntity : MessageBaseEntity
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
        public decimal? KitchenCharges { get; set; }
        public bool? IsActive { get; set; }
        public int? MealID { get; set; }
        public string? Meal { get; set; }
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


    public class HotelRateResViewEntity : MessageBaseEntity
    {
        public int? ID { get; set; }
        public IEnumerable<HotelRatesViewEntity>? WeekDaysRateList { get; set; }
        public IEnumerable<HotelRatesViewEntity>? WeekEndRateList { get; set; }
        public IEnumerable<HotelSpecialRateResEntity>? SpecialDateRateList { get; set; }
    }

    public class HotelRateViewEntity : MessageBaseEntity
    {
        public string? RoomCategoryName { get; set; }
        public string? MealTypeName { get; set; }
        public string? MealTypeDescription { get; set; }
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
        public int? MinAdultCount { get; set; }
        public int? MaxAdultCount { get; set; }
        public int? CWBCount { get; set; }
        public int? CNBCount { get; set; }
    }
    public class HotelRateDataEntity
    {
        public int? HotelID { get; set; }
        public string? Place { get; set; }
        public string? CheckInDate { get; set; }
        public int? MealTypeID { get; set; }
        public int? RoomCategoryID { get; set; }
    }
}

