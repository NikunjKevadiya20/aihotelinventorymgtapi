using System;


namespace HotelBooking.Entity.Entities
{
    public class CartEntity
    {
        public string? SessionID { get; set; }

        public List<CartPaxDataEntity>? TicketPax { get; set; }

        public string? Message { get; set; }
        public string? Details { get; set; }
    }

    public class CartPaxDataEntity
    {
        public int? ID { get; set; }          // Existing = ID, New = 0

        public string? Name { get; set; }

        public int? Age { get; set; }

        public string? Gender { get; set; }

        public int? CountryID { get; set; }

        public int? StateID { get; set; }

        
    }
    // Cart entity for add/delete operations
    public class CartDataEntity
    {
        public int? ID { get; set; }
        public string? SessionID { get; set; }
        public string? CartType { get; set; }

        // Hotel Fields
        public int? HotelID { get; set; }
        public int? MealPlanID { get; set; }
        public int? TotalChildSevenYr { get; set; }
        public int? TotalChildThreeYr { get; set; }
        public int? TotalAdults { get; set; }
        public int? RoomCategoryID { get; set; }
        public int? ProjectionMappingID { get; set; }
        public int? TimeSlotID { get; set; }
        public DateTime? CheckIn { get; set; }
        public DateTime? CheckOut { get; set; }
        public int? Night { get; set; }
        public int? Rooms { get; set; }
        public int? Adults { get; set; }
        public int? Child { get; set; }
        public int? ExtraAdult { get; set; }
        public int? ExtraChild { get; set; }


        // Ticket Fields
        public int? TicketID { get; set; }
        public DateTime? VisitDate { get; set; }


        public int? CreatedBy { get; set; }
        public int? UpdatedBy { get; set; }

        public List<CartPaxEntity>? TicketPax { get; set; }

        public string? Message { get; set; }
        public string? Details { get; set; }
    }

    public class CartPaxEntity
    {
        public string? Name { get; set; }
        public int? Age { get; set; }
        public string? Gender { get; set; }
        public int? CountryID { get; set; }
        public int? StateID { get; set; }
    }

    // Request for GetCartDetails
    public class CartDetailsRequestEntity
    {
        public string? SessionID { get; set; }
    }

    // Response entities for GetCartDetails
    public class CartDetailsResponseEntity
    {
        public List<CartHotelEntity>? HotelCart { get; set; }
        public List<CartTicketEntity>? TicketCart { get; set; }
        public List<CartPaxDetailsEntity>? CartPaxDetails { get; set; }
        public List<HotelBookingTicketPaxSoldOutDateViewEntity>? HotelBookingTicketSoldOutDateforpax { get; set; }
        public List<VisitDateEntity>? VisitDate { get; set; }

        public string? Message { get; set; }
        public string? Details { get; set; }
    }

    public class VisitDateEntity
    {
        public string? SessionID { get; set; }
        public DateTime? VisitDate { get; set; }
    }
    public class CartPaxDetailsEntity
    {
        public string? SessionID { get; set; }
        public string? Name { get; set; }
        public int? Age { get; set; }
        public string? Gender { get; set; }
        public int? CountryID { get; set; }
        public string? CountryName { get; set; }
        public int? StateID     { get; set; }
        public string? StateName { get; set; }


    }
    public class ViewingGalleryEntity 
    {
        public int? ID { get; set; }
        public int? AttractionID { get; set; }
        public int? TicketID { get; set; }
        public string? TimeSlot { get; set; }


    }
    public class CartHotelEntity
    {
        public int? CartID { get; set; }
        public int? CustomerID { get; set; }
        public int? HotelID { get; set; }
        public int? MealPlanID { get; set; }
        public int? TotalPaxAllowed { get; set; }
        public string? HotelName { get; set; }
        public string? MealPlanName { get; set; }
        public string? MealPlanDescription { get; set; }
        public string? RoomCategoryName { get; set; }
        public string? HotelMainImage { get; set; }
        public int? RoomCategoryID { get; set; }
        public string? CheckIn { get; set; }
        public string? CheckOut { get; set; }
        public int? Night { get; set; }
        public int? Rooms { get; set; }
        public int? Adults { get; set; }
        public int? Child { get; set; }
        public int? TillChildAge { get; set; }
        public int? ExtraAdult { get; set; }
        public int? ExtraChild { get; set; }
        public decimal? TotalAmount { get; set; }
        public int? TotalChildSevenYr { get; set; }
        public int? TotalChildThreeYr { get; set; }
        public int? TotalAdults { get; set; }
        public DateTime? CreatedOn { get; set; }
        // ==================== Price & GST Details ====================
        public DateTime? Date { get; set; }                    // hp.[Date]
        public decimal? CoupleCost { get; set; }
        public decimal? ExtraPersonCost { get; set; }
        public decimal? ExtraChildCost { get; set; }
        public decimal? Discount { get; set; }
        public decimal? GSTPercentage { get; set; }            // gst.GSTPersantage AS GSTPercentage

        // ==================== Availability ====================
        public int? Total { get; set; }                        // AV.Total
        public int Booked { get; set; }                        // AS Booked
        public int Available { get; set; }                     // AS Available

        // ==================== Hotel Master Details ====================
        public string? Address { get; set; }
        public string? HotelCategory { get; set; }
        public string? HotelDescription { get; set; }
        public string? ShortDescription { get; set; }
        public string? GoogleMapURL { get; set; }
        public string? PropertyRules { get; set; }
        public string? CancellationPolicy { get; set; }
        public string? Notes { get; set; }
        public string? BathroomFacilities { get; set; }
        public string? RoomAminities { get; set; }
        public string? LivingArea { get; set; }
        public string? Bedroom { get; set; }
        public decimal? FarFrom { get; set; }
        public int? TotalRoom { get; set; }
        public List<RoomCategoryImageViewEntity>? RoomCategory { get; set; }
    }

public class RoomCategoryImageViewEntity
{
    public int? ID { get; set; }
    public int? RoomCategoryID { get; set; }
    public int? HotelID { get; set; }
    public string? OtherImage { get; set; }
}

public class CartTicketEntity
    {
        public int CartID { get; set; }
        public int CustomerID { get; set; }
        public int TicketID { get; set; }
        public string? TicketName { get; set; }
        public string? TicketImage { get; set; }
        public string? HotelBookingCampus { get; set; }
        public string? HelipadGround { get; set; }
        public string? ShortDescription { get; set; }
        public string? Description { get; set; }
        public string? LastEntry { get; set; }
        public string? Notice { get; set; }
        public decimal? PerPersonRate { get; set; }
        public decimal? ChildSevenYrRate { get; set; }
        public decimal? ChildThreeYrRate { get; set; }
        public decimal? ServiceCharge { get; set; }
        public int? ServiceChargeType { get; set; }
        public int? MinPaxCount { get; set; }
        public int? ProjectionMappingID { get; set; }
        public string? ProjectionMappingTitle   { get; set; }
         public int? TimeSlotID { get; set; }
        public decimal Total { get; set; }
        public DateTime? CreatedOn { get; set; }
        public int? TotalChildSevenYr { get; set; }
        public int? TotalChildThreeYr { get; set; }
        public int? TotalAdults { get; set; }
        public DateTime? VisitDate { get; set; }

        public List<CartTicketPaxEntity>? TicketPaxDetails { get; set; }
        public List<ViewingGalleryEntity>? ViewingGallery { get; set; }
        public List<ViewingGalleryEntity>? ProjectionMapping { get; set; }
        public List<AttractionTicket>? AttractionTicket { get; set; }
    }
    public class AttractionTicket
    {
        public int? ID { get; set; }
        public int? AttractionID { get; set; }
        public int? PackageID { get; set; }
        public int? TicketID { get; set; }
        public string? Title { get; set; }
        public DateTime? CreatedOn { get; set; }
        public List<AttractionTicketChild>? AttractionTicketChild { get; set; }

    }
    public class AttractionTicketChild
    {
        public int? ID { get; set; }
        public int? AttractionID { get; set; }
        public int? TicketID { get; set; }
        public string? TimeSlot { get; set; }
    }
    public class HotelBookingTicketPaxSoldOutDateViewEntity
    {
        public int? ID { get; set; }
        public int? HotelBookingTicketID { get; set; }
        public string? SoldOutDate { get; set; }
    }

    public class CartTicketPaxEntity
    {
        public int ID { get; set; }
        public int TicketCartID { get; set; }
        public string? Name { get; set; }
        public int Age { get; set; }
        public string? Gender { get; set; }
    }

    public class CartPaxView
    {
        public int? ID { get; set; }
        public int? CustomerID { get; set; }
        public string? Name { get; set; }
        public int? Age { get; set; }
        public string? Gender { get; set; }
        public int? CountryID { get; set; }
        public string? CountryName { get; set; }
        public int? StateID { get; set; }
        public string? StateName { get; set; }
        public string? Message { get; set; }
        public string? Details { get; set; }
    }
    public class CartIDEntity : MessageBaseEntity
    {
        public int? ID { get; set; }
        public string? SessionID { get; set; }
        public Int32? UpdatedBy { get; set; }
    }
}
