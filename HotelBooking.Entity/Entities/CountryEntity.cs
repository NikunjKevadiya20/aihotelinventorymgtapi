using HotelBooking.Entity;

/// <summary>
/// Added by NikunjK on 01-08-2023
/// </summary>
namespace HotelBooking.Entity.Entities
{
    public class CountryDataEntity
    {
        public int? ID { get; set; }
        public string? CountryName { get; set; }
        public string? CountryCode { get; set; }
        public Boolean? IsActive { get; set; }
        public Int32? CreatedBy { set; get; }
        public Int32? UpdatedBy { set; get; }
        public string? Details { get; set; }
        public string? Message { get; set; }

    }

    public class CountryIDEntity : MessageBaseEntity
    {
        public int? ID { get; set; }
        public string? CountryName { get; set; }
        public Int32? UpdatedBy { set; get; }
        public Boolean? IsActive { get; set; }
    }

    public class CountryViewEntity
    {
        public Int32 ID { set; get; }
        public string? CountryName { get; set; }
        public string? CountryCode { get; set; }
        public Boolean? IsActive { get; set; }
        public string? Details { get; set; }
        public string? Message { get; set; }
        public int? Status { get; set; }
        public string? ErrorMessage { get; set; }

    }

}
