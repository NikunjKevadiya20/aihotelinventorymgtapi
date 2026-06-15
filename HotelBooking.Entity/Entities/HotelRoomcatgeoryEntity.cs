using Microsoft.AspNetCore.Http;

namespace HotelBooking.Entity.Entities
{
    public class HotelRoomcatgeoryDataEntity
    {
        public int? ID { get; set; }
        public int? HotelID { get; set; }
        public string? RoomCategoryName { get; set; }
        public int? MinAdultCount { get; set; }
        public int? MaxAdultCount { get; set; }
        public int? CWBCount { get; set; }
        public int? CNBCount { get; set; }
        public Boolean? IsActive { get; set; }
        public Int32? CreatedBy { set; get; }
        public Int32? UpdatedBy { set; get; }
        public string? Details { get; set; }
        public string? Message { get; set; }
        public int? RoomCategoryID { get; set; }
        public List<IFormFile>? OtherImage { get; set; }

    }
    public class HotelRoomcatgeoryIDEntity : MessageBaseEntity
    {
        public int? ID { get; set; }
        public int? HotelID { get; set; }
        public Int32? UpdatedBy { set; get; }
        public Boolean? IsActive { get; set; }
    }

    public class HotelRoomcatgeoryViewEntity
    {
        public Int32? ID { set; get; }
        public int? HotelID { get; set; }
        public string? HotelName { get; set; }
        public string? RoomCategoryName { get; set; }
        public int? MinAdultCount { get; set; }
        public int? MaxAdultCount { get; set; }
        public int? CWBCount { get; set; }
        public int? CNBCount { get; set; }
        public Boolean? IsActive { get; set; }
        public string? Details { get; set; }
        public string? Message { get; set; }
        public int? Status { get; set; }
        public string? ErrorMessage { get; set; }
        public int? RoomCategoryID { get; set; }
        public List<HotelCategoryImage> Images { get; set; } = new();

    }
    public class RoomCategoryImageEntity
    {
        public int? ID { get; set; }
        public int? RoomCategoryID { get; set; }

        public List<IFormFile>? OtherImage { get; set; }
    }

}

