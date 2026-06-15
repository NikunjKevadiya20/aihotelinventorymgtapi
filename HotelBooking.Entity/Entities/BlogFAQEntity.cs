using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBooking.Entity.Entities
{
    public class BlogFAQEntity
    {
        public int? ID { get; set; }
        public int? BlogID { get; set; }
        public string? Question { get; set; }
        public string? Answer { get; set; }
        public int? SequenceNo { get; set; }
        public Boolean? IsActive { get; set; }
        public Int32? CreatedBy { set; get; }
        public Int32? UpdatedBy { set; get; }
        public string? Details { get; set; }
        public string? Message { get; set; }

    }

    public class BlogFAQIDEntity : MessageBaseEntity
    {
        public int? ID { get; set; }
        public int? BlogID { get; set; }
        public string? Question { get; set; }
        public Int32? UpdatedBy { set; get; }
        public Boolean? IsActive { get; set; }
    }

    public class BlogFAQDataViewEntity : MessageBaseEntity
    {
        public Int32 ID { set; get; }
        public int? BlogID { get; set; }
        public string? Question { get; set; }
        public string? Answer { get; set; }
        public int? SequenceNo { get; set; }
        public Boolean? IsActive { get; set; }
        public string? Details { get; set; }
        public string? Message { get; set; }
        public int? Status { get; set; }
        public string? ErrorMessage { get; set; }

    }

}
