using HotelBooking.Entity;

namespace HotelBooking.Entity.Entities
{
    public class CityDataEntity
    {
        public int? ID { get; set; }
        public int? CountryID { get; set; }
        public int? StateID { get; set; }
        public string? CityName { get; set; }
        public Boolean? IsActive { get; set; }
        public Int32? CreatedBy { set; get; }
        public Int32? UpdatedBy { set; get; }
        public string? Details { get; set; }
        public string? Message { get; set; }

    }
    public class CityIDEntity : MessageBaseEntity
    {
        public int? ID { get; set; }
        public int? CountryID { get; set; }
        public string? CountryName { get; set; }
        public int? StateID { get; set; }
        public string? StateName { get; set; }
        public string? CityName { get; set; }
        public Int32? UpdatedBy { set; get; }
        public Boolean? IsActive { get; set; }
    }

    public class CityViewEntity
    {
        public Int32 ID { set; get; }
        public int? CountryID { get; set; }
        public string? CountryName { get; set; }
        public int? StateID { get; set; }
        public string? StateName { get; set; }
        public string? CityName { get; set; }
        public Boolean? IsActive { get; set; }
        public string? Details { get; set; }
        public string? Message { get; set; }
        public int? Status { get; set; }
        public string? ErrorMessage { get; set; }

    }

}

