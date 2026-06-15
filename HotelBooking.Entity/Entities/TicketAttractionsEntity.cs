using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBooking.Entity.Entities
{
    public class   TicketAttractionsEntity
    {   
        public int? ID { get; set; }
        public string? Title { get; set; }
        public string? TicketType { get; set; }
        public Boolean? IsActive { get; set; }
        public Int32? CreatedBy { set; get; }
        public Int32? UpdatedBy { set; get; }
        public string? Details { get; set; }
        public string? Message { get; set; }
        public List<AttractionSlotEntity>? Slot { get; set; }

    }

    public class AttractionSlotEntity
    {
        public string? TimeSlot { get; set; }
    }

    public class TicketAttractionsIDEntity : MessageBaseEntity
    {
        public int? ID { get; set; }
        public string? Title { get; set; }
        public Int32? UpdatedBy { set; get; }
        public Boolean? IsActive { get; set; }
    }

    public class TicketAttractionsViewEntity
    {
        public int? ID { get; set; }
        public string? Title { get; set; }
        public string? TicketType { get; set; }
        public Boolean? IsActive { get; set; }
        public string? Details { get; set; }
        public string? Message { get; set; }
        public int? Status { get; set; }
        public string? ErrorMessage { get; set; }
        public List<AttractionSlotViewEntity>? Slot { get; set; }

    }
    public class AttractionSlotViewEntity 
    {
        public int? ID { get; set; }
        public int? AttractionID { get; set; }
        public string? TimeSlot { get; set; }
    }

}
