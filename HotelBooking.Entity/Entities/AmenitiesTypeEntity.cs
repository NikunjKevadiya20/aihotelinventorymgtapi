using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBooking.Entity.Entities
{
    public class AmenitiesTypeEntity
    {
        public int? ID { get; set; }
        public int? AmenitiesID { get; set; }
        public string? AmenityType { get; set; }
        public bool? IsActive { get; set; }
        public int? CreatedBy { get; set; }
        public int? UpdatedBy { get; set; }
        public string? Details { get; set; }
        public string? Message { get; set; }
    }

    public class AmenitiesTypeIDEntity : MessageBaseEntity
    {
        public int? ID { get; set; }
        public int? AmenitiesID { get; set; }
        public string? AmenityType { get; set; }
        public int? UpdatedBy { get; set; }
        public bool? IsActive { get; set; }
    }

    public class AmenitiesTypeDataViewEntity : MessageBaseEntity
    {
        public int ID { get; set; }
        public int? AmenitiesID { get; set; }
        public string? AmenitiesName { get; set; }
        public string? AmenityType { get; set; }
        public bool? IsActive { get; set; }
        public string? Details { get; set; }
        public string? Message { get; set; }
        public int? Status { get; set; }
        public string? ErrorMessage { get; set; }
    }

    public class AmenitiesTypeIDViewEntity : MessageBaseEntity
    {
        public int? ID { get; set; }
    }
}
