using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBooking.Entity.Entities
{
    public class DistrictEntity
    {
        public int? ID { get; set; }
        public int? StateID { get; set; }
        public string? Name { get; set; }
        public bool? IsActive { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public string? Message { get; set; }
        public string? Details { get; set; }
    }

    public class DistrictIDEntity : MessageBaseEntity
    {
        public string? Name { get; set; }
        public int? ID { get; set; }
        public int? StateID { get; set; }
        public int? UpdatedBy { get; set; }
        public bool? IsActive { get; set; }
    }

    public class DistrictViewEntity
    {
        public int? ID { get; set; }
        public int? StateID { get; set; }
        public string? StateName { get; set; }
        public string? Name { get; set; }
        public bool? IsActive { get; set; }
        public string? Message { get; set; }
        public string? Details { get; set; }
        public int? Status { get; set; }
        public string? ErrorMessage { get; set; }
    }
}
