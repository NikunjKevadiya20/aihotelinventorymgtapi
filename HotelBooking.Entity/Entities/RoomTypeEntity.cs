namespace HotelBooking.Entity.Entities
{
    public class RoomTypeDataEntity
    {
        public int? ID { get; set; }
        public string? RoomType { get; set; }
        public string? Prefix { get; set; }
        public Boolean? IsActive { get; set; }
        public Int32? CreatedBy { set; get; }
        public Int32? UpdatedBy { set; get; }
        public string? Details { get; set; }
        public string? Message { get; set; }
    }

    public class RoomTypeIDEntity : MessageBaseEntity
    {
        public int? ID { get; set; }
        public string? RoomType { get; set; }
        public string? Prefix { get; set; }

        public Int32? UpdatedBy { set; get; }
        public Boolean? IsActive { get; set; }
    }

    public class RoomTypeViewEntity
    {
        public Int32 ID { set; get; }
        public string? RoomType { get; set; }
        public string? Prefix { get; set; }
        public Boolean? IsActive { get; set; }
        public string? Details { get; set; }
        public string? Message { get; set; }
        public int? Status { get; set; }
        public string? ErrorMessage { get; set; }

    }
}
