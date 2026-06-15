namespace HotelBooking.Entity.Entities
{
    public class RegionDataEntity
    {
        public int? ID { get; set; }
        public string? RegionName { get; set; }
        public Boolean? IsActive { get; set; }
        public Int32? CreatedBy { set; get; }
        public Int32? UpdatedBy { set; get; }
        public string? Details { get; set; }
        public string? Message { get; set; }
    }

    public class RegionIDEntity : MessageBaseEntity
    {
        public int? ID { get; set; }
        public string? RegionName { get; set; }
        public Int32? UpdatedBy { set; get; }
        public Boolean? IsActive { get; set; }
    }

    public class RegionViewEntity
    {
        public Int32 ID { set; get; }
        public string? RegionName { get; set; }
        public Boolean? IsActive { get; set; }
        public string? Details { get; set; }
        public string? Message { get; set; }
        public int? Status { get; set; }
        public string? ErrorMessage { get; set; }

    }
}
