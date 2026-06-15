using HotelBooking.Entity;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBooking.Entity.Entities
{
    public class AmenitiesEntity
    {
        public int? ID { get; set; }
        public string? PropertyID { get; set; }
        public string? AmenitiesName { get; set; }
        public bool? IsActive { get; set; }
        public int? CreatedBy { get; set; }
        public int? UpdatedBy { get; set; }
        public string? Details { get; set; }
        public string? Message { get; set; }
    }

    public class AmenitiesIDEntity : MessageBaseEntity
    {
        public int? ID { get; set; }
        public string? AmenitiesName { get; set; }
        public int? UpdatedBy { get; set; }
        public bool? IsActive { get; set; }
    }

    public class AmenitiesDataViewEntity : MessageBaseEntity
    {
        public int ID { get; set; }
        public string? PropertyID { get; set; }
        public string? PropertyName { get; set; }
        public string? AmenitiesName { get; set; }
        public bool? IsActive { get; set; }
        public string? Details { get; set; }
        public string? Message { get; set; }
        public int? Status { get; set; }
        public string? ErrorMessage { get; set; }
    }

    public class AmenitiesImageDataEntity
    {
        public int? ID { get; set; }
        public IFormFile? Icon { get; set; }
    }

    public class AmenitiesIDViewEntity : MessageBaseEntity
    {
        public int? ID { get; set; }
    }
}
