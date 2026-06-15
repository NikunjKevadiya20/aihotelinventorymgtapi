using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// Added by NikunjK on 01-08-2023
/// </summary>
namespace HotelBooking.Entity.Entities
{
    public class ItineraryDataEntity
    {
        public int? ID { get; set; }
        public int? SectorID { get; set; }
        public string? ItineraryTitle { get; set; } 
        public string? Description { get; set; } 
        public Boolean? IsActive { get; set; }
        public Int32? CreatedBy { set; get; }
        public Int32? UpdatedBy { set; get; }
        public string? Details { get; set; }
        public string? Message { get; set; }

        
    }

    

    public class ItineraryIDEntity : MessageBaseEntity
    {
        public int? ID { get; set; }
        public int? SectorID { get; set; } 

        public string? ItineraryTitle { get; set; } 
        public Int32? UpdatedBy { set; get; }
        public Boolean? IsActive { get; set; }
    }

    public class ItineraryViewEntity
    {
        public Int32 ID { set; get; }
        public int? SectorID { get; set; }
        public string? SectorName { get; set; } 
        public string? ItineraryTitle { get; set; }
        public string? Description { get; set; }
        public Boolean? IsActive { get; set; }
        public string? Details { get; set; }
        public string? Message { get; set; }
        public int? Status { get; set; }
        public string? ErrorMessage { get; set; }
         
    }
    

    public class CityListByItineraryID : MessageBaseEntity
    {
        public int? ID { get; set; }
        public string? CityName { get; set; }
        public int? Status { get; set; }
        public string? ErrorMessage { get; set; }
    }

}
