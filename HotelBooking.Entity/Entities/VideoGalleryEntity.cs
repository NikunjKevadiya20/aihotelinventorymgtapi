using HotelBooking.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBooking.Entity.Entities
{
    public class VideoGalleryEntity
    {
        public int? ID { get; set; }
        public string? Title { get; set; }
        public int? ReferenceID { get; set; }
        public string? Type { get; set; }
        public string? VideoURL { get; set; }
        public Boolean? IsActive { get; set; }
        public Int32? CreatedBy { set; get; }
        public Int32? UpdatedBy { set; get; }
        public string? Details { get; set; }
        public string? Message { get; set; }

    }

    public class VideoGalleryIDEntity : MessageBaseEntity
    {
        public int? ID { get; set; }
        public string? Title { get; set; }
        public Int32? UpdatedBy { set; get; }
        public Boolean? IsActive { get; set; }
    }

    public class VideoGalleryViewEntity
    {
        public int? ID { get; set; }
        public string? Title { get; set; }
        public int? ReferenceID { get; set; }
    
        public string? ReferenceName { get; set; }
        public string? Type { get; set; }
        public string? VideoURL { get; set; }
 
        public Boolean? IsActive { get; set; }
        public string? Details { get; set; }
        public string? Message { get; set; }
        public int? Status { get; set; }
        public string? ErrorMessage { get; set; }

        

    }

    public class GalleryVideoViewEntity
    {
        public int? ID { get; set; }
        public int? ReferenceID { get; set; }
        public int? PropertyID { get; set; }
        public string? ReferenceName { get; set; }
        public string? Title { get; set; }
        public string? VideoURL { get; set; }


    }

    public class PropertyEntitys : MessageBaseEntity
    {
        public int ID { get; set; }
        public string? PropertyName { get; set; }
        public string? PropertyURL { get; set; }
        public string? TagLine { get; set; }
        public string? Address { get; set; }
        public string? ShortDescription { get; set; }
        public string? LongDescription { get; set; }
        public string? Tags { get; set; }
        public int? SequenceNo { get; set; }
        public bool? IsHightlightProperty { get; set; }
        public string? MetaTitle { get; set; }
        public string? MetaDescription { get; set; }
        public string? MetaKeywords { get; set; }
        public string? BannerImages { get; set; }
        public string? MobileNo { get; set; }
        public string? EmailID { get; set; }
        public string? DiningInfo { get; set; }
        public string? BookingURL { get; set; }
        public int? TotalRoom { get; set; }
        public bool? IsActive { get; set; }
        public string? Details { get; set; }
        public string? Message { get; set; }
        public int? Status { get; set; }
        public string? ErrorMessage { get; set; }

        public List<GalleryVideoViewEntity> GalleryVideoList { get; set; }
    }
}
