using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBooking.Entity.Entities
{
    public class CMSDataEntity
    {
        public int? ID { get; set; }
        public string? Name { get; set; }
        public string? Template { get; set; }
        public string? CMSURL { get; set; }
        public string? MetaTitle { get; set; }
        public string? MetaDescription { get; set; }
        public string? MetaKeyword { get; set; }
        public bool? IsActive { get; set; }
        public int? CreatedBy { get; set; }
        public int? UpdatedBy { get; set; }
        public string? Details { get; set; }
        public string? Message { get; set; }
    }

    public class CMSIDEntity : MessageBaseEntity
    {
        public int? ID { get; set; }
        public string? Name { get; set; }
        public string? CMSURL { get; set; }
        public int? UpdatedBy { get; set; }
        public bool? IsActive { get; set; }
    }

    public class CMSViewDataEntity : MessageBaseEntity
    {
        public int ID { get; set; }
        public string? Name { get; set; }
        public string? Template { get; set; }
        public string? CMSURL { get; set; }
        public string? MetaTitle { get; set; }
        public string? MetaDescription { get; set; }
        public string? MetaKeyword { get; set; }
        public string? CMSImage { get; set; }
        public string? CMSImageAlterTag { get; set; }
        public bool? IsActive { get; set; }
        public string? Details { get; set; }
        public string? Message { get; set; }
        public int? Status { get; set; }
        public string? ErrorMessage { get; set; }
    }

    public class CMSImageDataViewEntity
    {
        public int? ID { get; set; }
        public string? CMSImageAlterTag { get; set; }
        public IFormFile? CMSImage { get; set; }
    }

    public class CMSIDViewEntity : MessageBaseEntity
    {
        public int? ID { get; set; }
    }
}
