/// <summary>
/// Added by NikunjK on 01-08-2023
/// </summary>
namespace HotelBooking.Entity.Entities
{
    public class VehicleSharingPaxDataEntity
    {
        public int? ID { get; set; }
        public string? Title { get; set; }
        public Boolean? IsActive { get; set; }
        public Int32? CreatedBy { set; get; }
        public Int32? UpdatedBy { set; get; }
        public string? Details { get; set; }
        public string? Message { get; set; }

    }

    public class VehicleSharingPaxIDEntity : MessageBaseEntity
    {
        public int? ID { get; set; }
        public string? Title { get; set; }
        public Int32? UpdatedBy { set; get; }
        public Boolean? IsActive { get; set; }
    }

    public class VehicleSharingPaxViewEntity
    {
        public Int32 ID { set; get; }
        public string? Title { get; set; }
        public Boolean? IsActive { get; set; }
        public string? Details { get; set; }
        public string? Message { get; set; }
        public int? Status { get; set; }
        public string? ErrorMessage { get; set; }

    }

}
