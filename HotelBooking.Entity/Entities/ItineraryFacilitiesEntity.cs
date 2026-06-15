using Microsoft.AspNetCore.Http;

namespace HotelBooking.Entity.Entities
{
    // Added by AI009 on 07-04-23
    public class ItineraryFacilitiesEntity : MessageBaseEntity
    {
        public int? ID { get; set; }
        public string? Name { get; set; }
        public string? FacilityImage { get; set; }
        public Boolean? IsActive { set; get; }
        public int? CreatedBy { set; get; }
        public int? UpdatedBy { set; get; }

    }
    public class ItineraryFacilitiesViewEntity : MessageBaseEntity
    {
        public int? ID { get; set; }
        public Boolean? IsActive { set; get; }
        public int? UpdatedBy { set; get; }

    }

    public class ItineraryFacility : MessageBaseEntity
    {
        public int? ID { get; set; }
        public string? Name { get; set; }
        public IFormFile? FacilityImage { get; set; }
        public int? IsUser { set; get; }
    }
    public class ItineraryIDViewEntity : MessageBaseEntity
    {
        public int? ID { get; set; }
        public int? UpdatedBy { set; get; }

    }
}
