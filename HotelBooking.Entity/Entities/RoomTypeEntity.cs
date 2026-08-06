using Microsoft.AspNetCore.Http;

namespace HotelBooking.Entity.Entities
{
    public class RoomTypeDataEntity
    {
        public int? ID { get; set; }
        public string? AmenitiesIDs { get; set; }
        public string? RoomType { get; set; }
        public string? Prefix { get; set; }
        public int? MaxGuest { get; set; }
        public decimal? RoomArea { get; set; }
        public string? BedType { get; set; }
        public string? Description { get; set; }
        public string? Amenities { get; set; }
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
        public string? AmenitiesIDs { get; set; }
        public string? RoomType { get; set; }
        public string? Prefix { get; set; }
        public int? MaxGuest { get; set; }
        public decimal? RoomArea { get; set; }
        public string? BedType { get; set; }
        public string? Description { get; set; }
        public string? Amenities { get; set; }
        public string? Image { get; set; }
        public Boolean? IsActive { get; set; }
        public string? Details { get; set; }
        public string? Message { get; set; }
        public int? Status { get; set; }
        public string? ErrorMessage { get; set; }
        public List<RoomTypeImageViewEntity> ImageList { get; set; } = new();

    }
    public class RoomTypeImageViewEntity
    {
        public int ID { get; set; }
        public int RoomTypeID { get; set; }

        public string ImageList { get; set; } = string.Empty;
    }
    public class RoomTypeImageEntity
    {
        public IFormFile? Image { get; set; }           
        public List<IFormFile>? ImageList { get; set; } 

        public int? RoomTypeID { get; set; }            
    }

    public class DeleteImageEntity
    {
        public int? RoomTypeID { get; set; }

    }
}
