/// <summary>
/// Added by NikunjK on 01-08-2023
/// </summary>
namespace HotelBooking.Entity.Entities
{
    public class VehicleTypeDataEntity : MessageBaseEntity
    {
        public int? ID { get; set; }
        public string? VehicleType { get; set; }
        public Decimal? Rate { get; set; }
        public Boolean? IsActive { get; set; }
        public Int32? CreatedBy { set; get; }
        public Int32? UpdatedBy { set; get; }
        public string? Details { get; set; }
        public string? Message { get; set; }

    }

    public class VehicleTypeIDEntity : MessageBaseEntity
    {
        public int? ID { get; set; }
        public string? VehicleType { get; set; }
        public Int32? UpdatedBy { set; get; }
        public Boolean? IsActive { get; set; }
    }

    public class VehicleTypeViewEntity
    {
        public Int32 ID { set; get; }
        public string? VehicleType { get; set; }
        public Decimal? Rate { get; set; }
        public Boolean? IsActive { get; set; }
        public string? Details { get; set; }
        public string? Message { get; set; }
        public int? Status { get; set; }
        public string? ErrorMessage { get; set; }

    }

    // add 24-12-2024
    public class RatesEntity : MessageBaseEntity
    {
        public int? NoOfPax { get; set; }
        public int? CityID { get; set; }
    }

    public class RatesViewEntity : MessageBaseEntity
    {
        public string? VehicleType { get; set; }
        public string? KmPerDay { get; set; }
        public decimal? RatePerKm { get; set; }
        public decimal? DriverAllowancePerDay { get; set; }
        public decimal? PickUpWithinCity { get; set; }
        public decimal? DropWithinCity { get; set; }
        public decimal? EightHrEightyKmWithinCity { get; set; }
    }

    public class TourwiseCity : MessageBaseEntity
    {
        public int? NoOfPax { get; set; }
        public int? TourID { get; set; }
        public string? CityName { get; set; }
    }

}
