using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBooking.Entity.Entities
{
    public class TestimonialEntity
    {
        public int? ID { get; set; }
        public string? CustomerName { get; set; }
        public string? Description { get; set; }
        public string? UniversityName { get; set; }
        public string? TestimonialURL { get; set; }
        public Boolean? IsActive { get; set; }
        public Int32? CreatedBy { set; get; }
        public Int32? UpdatedBy { set; get; }
        public string? Details { get; set; }
        public string? Message { get; set; }

    }

    public class TestimonialIDEntity : MessageBaseEntity
    {
        public int? ID { get; set; }
        public string? CustomerName { get; set; }
        public string? TestimonialURL { get; set; }
        public Int32? UpdatedBy { set; get; }
        public Boolean? IsActive { get; set; }
    }

    public class TestimonialDataViewEntity
    {
        public Int32? ID { set; get; }
        public string? CustomerName { get; set; }
        public string? Description { get; set; }
        public string? UniversityName { get; set; }
        public string? TestimonialImage { get; set; }
        public string? TestimonialURL { get; set; }
        public Boolean? IsActive { get; set; }
        public string? Details { get; set; }
        public string? Message { get; set; }
        public int? Status { get; set; }
        public string? ErrorMessage { get; set; }

    }
    public class TestimonialImageDataEntity
    {
        public int? ID { get; set; }
        public IFormFile? TestimonialImage { get; set; }

    }

    public class TestimonialIDViewEntity : MessageBaseEntity
    {
        public int? ID { get; set; }
    }

}
