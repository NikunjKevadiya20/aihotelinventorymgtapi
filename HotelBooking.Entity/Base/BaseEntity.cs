using System;

namespace HotelBooking.Entity
{
    [Serializable]
    public abstract class BaseEntity
    {      
        public Int32 ID { set; get; } = 0;
        public Int32 CreatedBy { set; get; }
        public Int32 UpdatedBy { set; get; }
        public string? Message { set; get; } = String.Empty;
        public DateTime? CreatedOn { set; get; } = DateTime.Now;
        public DateTime? UpdatedOn { set; get; }
        public Boolean IsActive { get; set; } = true;
        //added by paresh sir for paging
        public int? TotalRecord { get; set; }
        public int? TotalPages { get; set; }
        public int Limit { get; set; }
        public int Skip { get; set; }
        //added by nik for getting detailed message
        public string? Details { get; set; }
    }
    public abstract class MessageBaseEntity
    {
        public string? Message { set; get; } = String.Empty;
        public string? Details { get; set; } = String.Empty;
        public int? Status { get; set; }
        public string? ErrorMessage { get; set; }

    }
}
