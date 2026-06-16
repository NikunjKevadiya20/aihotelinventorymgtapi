using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBooking.Entity.Entities
{
    public class PackageTypeEntity
    {
        public int? ID { get; set; }
        public string? PackageTypeName { get; set; }
        public string? PackageTitle { get; set; }
        public string? URL { get; set; }
        public string? ShortDescription { get; set; }
        public Boolean? IsActive { get; set; }
        public Int32? CreatedBy { set; get; }
        public Int32? UpdatedBy { set; get; }
        public string? Details { get; set; }
        public string? Message { get; set; }

    }

    public class PackageTypeImage
    {
        public int? ID { get; set; }
        public IFormFile? ImageUpload { get; set; }
        public Int32? UpdatedBy { set; get; }
        public string? Details { get; set; }
        public string? Message { get; set; }

    }

    public class PackageTypeIDEntity : MessageBaseEntity
    {
        public int? ID { get; set; }
        public string? PackageTypeName { get; set; }
        public Int32? UpdatedBy { set; get; }
        public Boolean? IsActive { get; set; }
    }

    public class PackageTypeViewEntity
    {
        public int? ID { get; set; }
        public string? PackageTypeName { get; set; }
        public string? PackageTitle { get; set; }
        public string? URL { get; set; }
        public string? ShortDescription { get; set; }
        public string? ImageUpload { get; set; }
        public Boolean? IsActive { get; set; }
        public string? Details { get; set; }
        public string? Message { get; set; }
        public int? Status { get; set; }
        public string? ErrorMessage { get; set; }

    }
}
