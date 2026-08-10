using HotelBooking.Entity;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBooking.Entity.Entities
{
    public class GalleryEntity
    {
        public int? ID { get; set; }
        public string? Image { get; set; }
        public string? ImgAlt { get; set; }
        public bool? IsshowHome { get; set; }
        public string? GroupName { get; set; }
        public int? GalleryTypeID   { get; set; }
        public bool? IsCuision { get; set; }
        public bool? IsActive { get; set; }
        public int? CreatedBy { get; set; }
        public int? UpdatedBy { get; set; }
        public string? Message { get; set; }
        public string? Details { get; set; }
    }

    //  For Insert with File Upload  
    public class GalleryImageDataEntity
    {
        public int? ID { get; set; }
        public string? ImgAlt { get; set; }
        public string? GroupName { get; set; }
        public int? GalleryTypeID { get; set; }
        public Boolean? IsshowHome { get; set; }
        public Boolean? IsCuision { get; set; }
        public IFormFile? ImageFile { get; set; } // for upload via API
    }

    public class GalleryIDEntity : MessageBaseEntity
    {
        public int? ID { get; set; }
        public string? ImgAlt { get; set; }
        public bool? IsActive { get; set; }
        public int? UpdatedBy { get; set; }
    }

    //  For List / GetAll 
    public class GalleryDataViewEntity : MessageBaseEntity
    {
        public int ID { get; set; }
        public string? GalleryImage { get; set; }
        public string? ImgAlt { get; set; }
        public bool? IsshowHome { get; set; }
        public bool? IsCuision { get; set; }
        public string? GroupName { get; set; }
        public int? GalleryTypeID { get; set; }
        public string? GalleryType { get; set; }
        public bool? IsActive { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public string? Message { get; set; }
        public string? Details { get; set; }
        public int? Status { get; set; }
        public string? ErrorMessage { get; set; }
    }

    public class GalleryGroupViewEntity : MessageBaseEntity
    {
        public string? GroupName { get; set; }
        public int? GalleryTypeID { get; set; }
        public string? GalleryTypeName { get; set; }
        public List<GalleryDataViewEntity>? Images { get; set; }
    }

    // For FindByID    
    public class GalleryIDViewEntity : MessageBaseEntity
    {
        public int? ID { get; set; }
    }

    public class GalleryVideoGalleryData : MessageBaseEntity
    {
        public List<GalleryData>? Gallery { get; set; }
        public List<VideoGalleryData>? VideoGallery { get; set; }
    }
    

    public class GalleryData : MessageBaseEntity
    {
        public int ID { get; set; }
        public string? GalleryImage { get; set; }
        public string? ImgAlt { get; set; }
        public bool? IsshowHome { get; set; }
        public bool? IsCuision { get; set; }
        public string? GroupName { get; set; }
        public int? GalleryTypeID { get; set; }
        public string? GalleryType { get; set; }
        public bool? IsActive { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public string? Message { get; set; }
        public string? Details { get; set; }
        public int? Status { get; set; }
        public string? ErrorMessage { get; set; }
    }

    public class VideoGalleryData
    {
        public int? ID { get; set; }
        public string? Title { get; set; }

        public string? VideoURL { get; set; }
        public Boolean? IsActive { get; set; }
        public string? Details { get; set; }
        public string? Message { get; set; }
        public int? Status { get; set; }
        public string? ErrorMessage { get; set; }
    }
}
