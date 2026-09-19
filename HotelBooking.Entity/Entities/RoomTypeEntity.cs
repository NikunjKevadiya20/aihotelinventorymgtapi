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
        public string? OTARoomCode { get; set; }
        public int? BoAdults { get; set; }
        public int? BoChildren { get; set; }
        public int? MoAdults { get; set; }
        public int? MoChildren { get; set; }
        public int? MoInfant { get; set; }
        public int? Floor { get; set; }
        public int? RoomCategoryID { get; set; }
        public int? AccessibilityID { get; set; }
        public string? RoomViewID { get; set; }
        public string? Smoking { get; set; }
        public string? SizeType { get; set; }
        public Boolean? IsActive { get; set; }
        public Int32? CreatedBy { set; get; }
        public Int32? UpdatedBy { set; get; }
        public string? Details { get; set; }
        public string? Message { get; set; }
        public List<RoomTypeBed>? RoomTypeBeds { get; set; }
    }

    public class RoomTypeBed
    {
        public int? BedTypeID { get; set; }
        public int? Count { get; set; }
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
        public string? OTARoomCode { get; set; }
        public int? BoAdults { get; set; }
        public int? BoChildren { get; set; }
        public int? MoAdults { get; set; }
        public int? MoChildren { get; set; }
        public int? MoInfant { get; set; }
        public int? Floor { get; set; }
        public int? RoomCategoryID { get; set; }
        public string? RoomCategoryName { get; set; }
        public int? AccessibilityID { get; set; }
        public string? AccessibilityName { get; set; }
        public string? RoomViewID { get; set; }
        public string? RoomViewName { get; set; }
        public string? Smoking { get; set; }
        public string? SizeType { get; set; }
        public Boolean? IsActive { get; set; }
        public string? Details { get; set; }
        public string? Message { get; set; }
        public int? Status { get; set; }
        public string? ErrorMessage { get; set; }
        public List<RoomTypeImageViewEntity> ImageList { get; set; } = new();
        public List<RoomTypeBedViewEntity>? RoomTypeBeds { get; set; }

    }

    public class RoomTypeImageViewEntity
    {
        public int ID { get; set; }
        public int RoomTypeID { get; set; }
        public string ImageList { get; set; } = string.Empty;
    }

    public class RoomTypeBedViewEntity
    {
        public int? BedTypeID { get; set; }
        public int? Count { get; set; }
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
