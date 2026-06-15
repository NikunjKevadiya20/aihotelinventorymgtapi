using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBooking.Entity.Entities
{
    public class  AmountBaseGSTEntity
    {   
        public int? ID { get; set; }
        public int? GSTPersantage { get; set; }
        public int? FromAmount { get; set; }
        public int? ToAmount { get; set; }
        public Boolean? IsActive { get; set; }
        public Int32? CreatedBy { set; get; }
        public Int32? UpdatedBy { set; get; }
        public string? Details { get; set; }
        public string? Message { get; set; }

    }

    public class AmountBaseGSTIDEntity : MessageBaseEntity
    {
        public int? ID { get; set; }
        public Int32? UpdatedBy { set; get; }
        public Boolean? IsActive { get; set; }
    }

    public class AmountBaseGSTViewEntity
    {
        public int? ID { get; set; }
        public int? GSTPersantage { get; set; }
        public int? FromAmount { get; set; }
        public int? ToAmount { get; set; }
        public Boolean? IsActive { get; set; }
        public string? Details { get; set; }
        public string? Message { get; set; }
        public int? Status { get; set; }
        public string? ErrorMessage { get; set; }

    }
}
