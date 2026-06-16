using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBooking.Entity.Entities
{
    public class ColorEntity
    {
        public int? ID { get; set; }
        public string? Title { get; set; }
        public bool? IsActive { get; set; }
        public int? CreatedBy { get; set; }
        public int? UpdatedBy { get; set; }
        public string? Details { get; set; }
        public string? Message { get; set; }
    }

    public class ColorIDEntity : MessageBaseEntity
    {
        public int? ID { get; set; }
        public string? Title { get; set; }
        public int? UpdatedBy { get; set; }
        public bool? IsActive { get; set; }
    }

    public class ColorDataViewEntity : MessageBaseEntity
    {
        public int ID { get; set; }
        public string? Title { get; set; }
        public bool? IsActive { get; set; }
        public string? Details { get; set; }
        public string? Message { get; set; }
        public int? Status { get; set; }
        public string? ErrorMessage { get; set; }
    }

    public class ColorIDViewEntity : MessageBaseEntity
    {
        public int? ID { get; set; }
    }
}
