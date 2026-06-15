
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBooking.Entity.Entities
{
    public class BannerEntity
    {
        public int? ID { get; set; }
        public string? BannerType { get; set; }
        public string? BannerTitle { get; set; }
        public string? SubTitle { get; set; }
        public string? Description { get; set; }
        public Boolean? IsActive { get; set; }
        public Int32? CreatedBy { set; get; }
        public Int32? UpdatedBy { set; get; }
        public string? Details { get; set; }
        public string? Message { get; set; }

    }

    public class BannerIDEntity : MessageBaseEntity
    {
        public int? ID { get; set; }
        public string? BannerTitle { get; set; }
        public Int32? UpdatedBy { set; get; }
        public Boolean? IsActive { get; set; }
    }

    public class BannerDataViewEntity : MessageBaseEntity
    {
        public Int32 ID { set; get; }
        public string? BannerType { get; set; }
        public string? BannerTitle { get; set; }
        public string? SubTitle { get; set; }
        public string? Description { get; set; }
        public string? BannerImage { get; set; }
        public string? AltTitle { get; set; }
        public Boolean? IsActive { get; set; }
        public string? Details { get; set; }
        public string? Message { get; set; }
        public int? Status { get; set; }
        public string? ErrorMessage { get; set; }

    }
    public class BannerImageDataEntity
    {
        public int? ID { get; set; }
        public string? AltTitle { get; set; }
        public IFormFile? BannerImage { get; set; }

    }

    public class BannerIDViewEntity : MessageBaseEntity
    {
        public int? ID { get; set; }
    }
}
