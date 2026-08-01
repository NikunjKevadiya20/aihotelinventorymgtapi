using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBooking.Entity.Entities
{
    public class OfferEntity
    {
        public int? ID { get; set; }
        public string? CouponCode { get; set; }
        public DateTime? ValidityFrom { get; set; }
        public DateTime? ValidityTo { get; set; }
        public string? ShortDescription { get; set; }
        public int? UsageCount { get; set; }
        public string? AmountType { get; set; }
        public decimal? Percentage { get; set; }
        public decimal? Amount { get; set; }
        public decimal? MaxAmount { get; set; }
        public string? ImageUpload { get; set; }
        public bool? IsActive { get; set; }
        public int? CreatedBy { get; set; }
        public int? UpdatedBy { get; set; }
    }

    public class OfferIDEntity : MessageBaseEntity
    {
        public int? ID { get; set; }
        public string? CouponCode { get; set; }
        public int? UpdatedBy { get; set; }
        public bool? IsActive { get; set; }
        public string? ImageUpload { get; set; }

        public class OfferDataViewEntity : MessageBaseEntity
        {
            public int ID { get; set; }
            public string? CouponCode { get; set; }
            public DateTime? ValidityFrom { get; set; }
            public DateTime? ValidityTo { get; set; }
            public string? ShortDescription { get; set; }
            public int? UsageCount { get; set; }
            public string? AmountType { get; set; }
            public decimal? Percentage { get; set; }
            public decimal? Amount { get; set; }
            public decimal? MaxAmount { get; set; }
            public string? ImageUpload { get; set; }
            public bool? IsActive { get; set; }
            public string? Message { get; set; }
            public int? Status { get; set; }
            public string? ErrorMessage { get; set; }
        }

        public class OfferViewEntity : MessageBaseEntity
        {
            public int ID { get; set; }
            public string? CouponCode { get; set; }
            public string? ValidityFrom { get; set; }
            public string? ValidityTo { get; set; }
            public string? ShortDescription { get; set; }
            public int? UsageCount { get; set; }
            public string? AmountType { get; set; }
            public decimal? Percentage { get; set; }
            public decimal? Amount { get; set; }
            public decimal? MaxAmount { get; set; }
            public string? ImageUpload { get; set; }
            public bool? IsActive { get; set; }
            public string? Message { get; set; }
            public int? Status { get; set; }
            public string? ErrorMessage { get; set; }
        }

        public class OfferIDViewEntity : MessageBaseEntity
        {
            public int? ID { get; set; }
        }

        public class OfferImageDataEntity
        {
            public int? ID { get; set; }
            public IFormFile? ImageUpload { get; set; }
        }
    }
}
