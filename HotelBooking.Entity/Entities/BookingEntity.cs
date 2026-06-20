using System;
using System.Collections.Generic;

namespace HotelBooking.Entity.Entities
{
    // ==========================================
    // RESPONSE ENTITY
    // ==========================================
    public class TempBookingIDViewEntity : MessageBaseEntity
    {
        public int? ID { get; set; }
        public int? TempID { get; set; }
        public string? BookingNo { get; set; }
    }

    // ==========================================
    // MAIN REQUEST ENTITY
    // ==========================================
    public class TempBookingEntity
    {
        public int? ID { get; set; }
        public string? BookingNo { get; set; }

        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? MobileNo { get; set; }
        public string? EmailID { get; set; }

        public bool? IsPayAtHotel { get; set; }
        public string? PromoCode { get; set; }

        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }

        public int? NoOfNight { get; set; }

        public decimal? SGst { get; set; }
        public decimal? CGst { get; set; }

        public decimal? TotalRoomCharges { get; set; }
        public decimal? FinalTotal { get; set; }

        public bool? IsActive { get; set; }

        public int? CreatedBy { get; set; }
        public int? UpdatedBy { get; set; }

        public List<TempBookingDetailEntity>? TempBookingDetails { get; set; }
    }
    public class TempBookingDetailEntity
    {
        public int? RoomCategoryID { get; set; }

        public int? Room { get; set; }

        public int? Adults { get; set; }

        public int? Child { get; set; }

        public decimal? SGst { get; set; }

        public decimal? CGst { get; set; }

        public decimal? TotalPrice { get; set; }
    }
    // ==========================================
    // TICKET LIST
    // ==========================================
    public class CartTicketList
    {
        public int? TicketID { get; set; }
        public int? TimeSlotID { get; set; }
        public int? ProjectionMappingID { get; set; }
        public decimal? Price { get; set; }
        public decimal? ServiceCharge { get; set; }
        public decimal? TotalPrice { get; set; }
        public int? NoOfTicket { get; set; }
        public int? TotalChildSevenYr { get; set; }
        public int? TotalChildThreeYr { get; set; }
        public int? TotalAdults { get; set; }
        public string? SlotIDs  { get; set; }

        public IEnumerable<CartTicketPaxList>? TicketPaxDetails { get; set; }
    }

    // ==========================================
    // TICKET PAX LIST
    // ==========================================
    public class CartTicketPaxList
    {
        public string? Name { get; set; }
        public int? Age { get; set; }
        public string? Gender { get; set; }

        public decimal? Price { get; set; }

        public int? CountryID { get; set; }
        public int? StateID { get; set; }
    }

    // ==========================================
    // HOTEL LIST
    // ==========================================
    public class CartHotelList
    {
        public int? HotelID { get; set; }
        public int? RoomCategoryID { get; set; }

        public DateTime? CheckIn { get; set; }
        public DateTime? CheckOut { get; set; }

        public int? Night { get; set; }
        public int? Rooms { get; set; }

        public int? Adults { get; set; }
        public int? Child { get; set; }

        public int? ExtraAdult { get; set; }
        public int? ExtraChild { get; set; }

        public decimal? TotalAmount { get; set; }
        public int? MealPlanID { get; set; }
        public decimal? GSTPrice { get; set; }
    }

    // ==========================================
    // SQL TABLE TYPE : TempTicketType
    // ==========================================
    public class TempTicketType
    {
        public int? SrNo { get; set; }

        public int? TicketID { get; set; }
        public int? TimeSlotID { get; set; }
 
        public int? ProjectionMappingID { get; set; }
 
        public decimal? Price { get; set; }
        public decimal? ServiceCharge { get; set; }
        public decimal? TotalPrice { get; set; }
        public int? NoOfTicket { get; set; }
        public int? TotalChildSevenYr { get; set; }
        public int? TotalChildThreeYr { get; set; }
        public int? TotalAdults { get; set; }
        public string? SlotIDs { get; set; }

    }

    // ==========================================
    // SQL TABLE TYPE : TempTicketPaxType
    // ==========================================
    public class TempTicketPaxType
    {
        public int? TicketSrNo { get; set; }

        public string? Name { get; set; }
        public int? Age { get; set; }
        public string? Gender { get; set; }

        public decimal? Price { get; set; }

        public int? CountryID { get; set; }
        public int? StateID { get; set; }
    }

    // ==========================================
    // SQL TABLE TYPE : TempHotelType
    // ==========================================
    public class TempHotelType
    {
        public int? RoomCategoryID { get; set; }

        public DateTime? CheckIn { get; set; }
        public DateTime? CheckOut { get; set; }

        public int? Night { get; set; }
        public int? Rooms { get; set; }

        public int? Adults { get; set; }
        public int? Child { get; set; }

        public int? ExtraAdult { get; set; }
        public int? ExtraChild { get; set; }

        public decimal? TotalAmount { get; set; }
    }

    // Request for final booking insertion
    public class BookingRequestEntity
    {
        public int TempID { get; set; }
        public int ID { get; set; }
    }

    public class BookingResponseEntity
    {
        public string? Message { get; set; }
        public string? Details { get; set; }
        public int BookingID { get; set; }
        public string? BookingNo { get; set; }
    }

    // Search request for bookings
    public class BookingSearchEntity
    {
        public string? CustomerName { get; set; }
        public string? MobileNo { get; set; }
        public string? EmailID { get; set; }
        public string? BookingNo { get; set; }
        public string? BookingStatus { get; set; }
        public string? PaymentStatus { get; set; }
        public string? FromDate { get; set; }
        public string? ToDate { get; set; }
        public int? Skip { get; set; }
        public int? Limit { get; set; }
    }

    public class BookingListEntity
    {
        public string? Message { get; set; }
        public string? Details { get; set; }

        public int ID { get; set; }
        public int TempID { get; set; }

        public string? BookingNo { get; set; }

        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? CustomerName { get; set; }

        public string? MobileNo { get; set; }
        public string? EmailID { get; set; }

        public bool? IsPayAtHotel { get; set; }
        public string? PromoCode { get; set; }

        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }

        public int? NoOfNight { get; set; }

        public decimal? SGst { get; set; }
        public decimal? CGst { get; set; }
        public decimal? TotalRoomCharges { get; set; }
        public decimal? FinalTotal { get; set; }

        public string? PaymentStatus { get; set; }
        public string? BookingStatus { get; set; }

        public int ItemCount { get; set; }
        public int TotalPages { get; set; }
    }

    public class BookingEntity
    {
        public int? ID  { get; set; }
        public string? BookingStatus { get; set; }
        public string? PNR { get; set; }
    }
    public class BookingViewInsertEntity : MessageBaseEntity
    {
        public int? ID { get; set; }

        public int? TempID { get; set; }

        public string? BookingNo { get; set; }

        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public string? MobileNo { get; set; }

        public string? EmailID { get; set; }

        public bool? IsPayAtHotel { get; set; }

        public string? PromoCode { get; set; }

        public DateTime? FromDate { get; set; }

        public DateTime? ToDate { get; set; }

        public int? NoOfNight { get; set; }

        public decimal? SGst { get; set; }

        public decimal? CGst { get; set; }

        public decimal? TotalRoomCharges { get; set; }

        public decimal? FinalTotal { get; set; }

        public string? PaymentStatus { get; set; }

        public string? BookingStatus { get; set; }

        public bool? IsActive { get; set; }

        public bool? IsDeleted { get; set; }

        public int? CreatedBy { get; set; }

        public string? CreatedOn { get; set; }

        public int? UpdatedBy { get; set; }

        public string? UpdatedOn { get; set; }

        public int? ItemCount { get; set; }

        public int? TotalPages { get; set; }

        public List<InsertBookingDetailEntity>? BookingDetails { get; set; }
    }
    public class InsertBookingDetailEntity
    {
        public int? ID { get; set; }

        public int? BookingID { get; set; }

        public int? RoomCategoryID { get; set; }

        public string? RoomCategoryName { get; set; }

        public int? Room { get; set; }

        public int? Adults { get; set; }

        public int? Child { get; set; }

        public decimal? SGst { get; set; }

        public decimal? CGst { get; set; }

        public decimal? TotalPrice { get; set; }

        public string? CreatedOn { get; set; }
    }
    public class BookingViewEntity : MessageBaseEntity
    {
        // Common
        public string? Message { get; set; }
        public string? Details { get; set; }

        // -------------------------------
        // ORDER DETAILS
        // -------------------------------
        public int? ID { get; set; }
        public string? BookingNo { get; set; }
        public string? TempID { get; set; }
        public int? CustomerID { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? MobileNo { get; set; }
        public string? EmailID { get; set; }
        public string? GSTNo { get; set; }
        public string? CompanyName { get; set; }
        public string? CompanyAddress { get; set; }
        public decimal? OrderValue { get; set; }
        public decimal? DiscountValue { get; set; }
        public decimal? ServiceCharge { get; set; }
        public decimal? FinalPrice { get; set; }
        public decimal? RoundOff { get; set; }
        public string? TicketDate { get; set; }
        public int? TotalRooms { get; set; }
        public int? TotalTickets { get; set; }
        public string? CreatedOn { get; set; }
        public string? PaymentStatus { get; set; }
        public string? BookingStatus { get; set; }
        public string? PNR { get; set; }

        // -------------------------------
        // PAYMENT DETAILS
        // -------------------------------
        public string? PaymentID { get; set; }
        public string? Entity { get; set; }
        public decimal? Amount { get; set; }
        public string? Currency { get; set; }
        public string? GatewayPaymentStatus { get; set; }
        public string? Order_ID { get; set; }
        public string? Invoice_ID { get; set; }
        public string? Method { get; set; }
        public decimal? Amount_Refunded { get; set; }
        public string? Refund_Status { get; set; }
        public bool? Captured { get; set; }
        public string? Bank { get; set; }
        public string? Wallet { get; set; }
        public string? VPA { get; set; }
        public string? Email { get; set; }
        public string? Contact { get; set; }
        public decimal? Fee { get; set; }
        public decimal? Tax { get; set; }
        public string? TransactionID { get; set; }
        public string? Error_Code { get; set; }
        public string? Error_Description { get; set; }
        public bool? IsHotelDetails { get; set; }       
        public string? TransactionDate { get; set; }
        public int? StateID { get; set; }
        public string? StateName { get; set; }
        public int? HotelBookingPackageID { get; set; }
        public string? HotelBookingPackageName { get; set; }
        public int? DistrictID { get; set; }
        public string? DistrictName { get; set; }
        public string? WhatsAppMobileNo { get; set; }
        public List<BookingTicketViewEntity>? TicketView { get; set; }
 

        public List<BookingHotelDetailsViewEntity>? HotelDetails { get; set; }
    }
    public class BookingTicketViewEntity
    {
        public int? ID { get; set; }
        public int? BookingID { get; set; }
        public int? TicketID { get; set; }
        public string? HotelBookingTicketName { get; set; }
        public string? TimeSlotName { get; set; }

        public int? TimeSlotID { get; set; }
        public string? TimeSlot { get; set; }
        public string? ProjectionMappingTitle { get; set; }
        
        public int? ProjectionMappingID { get; set; }

        public decimal? Price { get; set; }
        public decimal? ServiceCharge { get; set; }
        public decimal? TotalPrice { get; set; }

        public int? NoOfTicket { get; set; }
        public int? TotalChildSevenYr { get; set; }
        public int? TotalChildThreeYr { get; set; }
        public int? TotalAdults { get; set; }
        public string? SlotIDs { get; set; }
        public string? SlotTimeSlots { get; set; }
        
        public List<BookingTicketPaxViewEntity>? PaxList { get; set; }
        public List<AttractionTicket>? AttractionTicket { get; set; }

    }
    public class BookingTicketPaxViewEntity
    {
        public int? ID { get; set; }
        public int? BookingTicketID { get; set; }

        public string? Name { get; set; }
        public int? Age { get; set; }
        public string? Gender { get; set; }

        public decimal? Price { get; set; }

        public int? CountryID { get; set; }
        public string? CountryName { get; set; }
        public string? StateName { get; set; }
        public int? StateID { get; set; }
    }
    public class BookingHotelDetailsViewEntity
    {
        public int? ID { get; set; }
        public int? BookingID { get; set; }
        public int? HotelID { get; set; }

        public string? HotelName { get; set; }
        public int? RoomCategoryID { get; set; }
        public string? RoomCategoryName { get; set; }
        public string? HotelAddress { get; set; }
     
        public string? HotelContactPersonName { get; set; }
        public string? HotelContactPersonMobileNo { get; set; }
        public string? MainImage { get; set; }
        public string? HotelLogo { get; set; }

        public string? CheckIn { get; set; }
        public string? CheckOut { get; set; }

        public int? Night { get; set; }
        public int? Rooms { get; set; }

        public int? Adults { get; set; }
        public int? Child { get; set; }

        public int? ExtraAdult { get; set; }
        public int? ExtraChild { get; set; }

        public decimal? TotalAmount { get; set; }
        public decimal? GSTPrice { get; set; }
        public int? MealPlanID { get; set; }
        public string? MealPlanDescription { get; set; }
        public string? MealPlanName { get; set; }
    }


    public class DashboardCustomerRequestEntity
    {
        public int? ID { get; set; } = 0;
        public string? CustomerName { get; set; } = string.Empty;
        public string? MobileNo { get; set; } = string.Empty;
        public string? EmailID { get; set; } = string.Empty;
        public string? FilterType { get; set; } = string.Empty;
        public string? FromDate { get; set; } = string.Empty;
        public string? ToDate { get; set; } = string.Empty;
        public int? Skip { get; set; } = 0;
        public int? Limit { get; set; } = 0;
    }

    public class DashboardResponse
    {
        public DashboardCountData? Summary { get; set; }

        public List<HotelSellingCountData>? HotelSellingCount { get; set; }

        public List<TicketSellingCountData>? TicketSellingCount { get; set; }

        public List<MonthWiseRevanueData>? MonthWiseRevanue { get; set; }
        public List<RecentBookingData>? RecentBooking { get; set; }

        public string? Message { get; set; }
        public string? Details { get; set; }
        public int Status { get; set; }
        public string? ErrorMessage { get; set; }
    }


    public class DashboardCountData
    {
        public int? TotalBookings { get; set; }
        public int? TomorrowHotelCheckIn { get; set; }
        public decimal? TotalHotelRevenue { get; set; }
        public decimal? TotalTicketRevenue { get; set; }

        public int? TotalInquiries { get; set; }
    }

    public class HotelSellingCountData
    {
        public int? HotelID { get; set; }
        public string? HotelName { get; set; }
        public int? TotalBookings { get; set; }
        public decimal? TotalRevenue { get; set; }

    }

    public class TicketSellingCountData
    {
        public int? TicketID { get; set; }
        public string? Title { get; set; }
        public int? TotalTicketsSold { get; set; }
        public int? TotalBookings { get; set; }
        public decimal? TotalRevenue { get; set; }
    }

    public class MonthWiseRevanueData
    {
        public int? MonthNo { get; set; }
        public string? MonthName { get; set; }
        public decimal? TotalRevenue { get; set; }
    }

    public class RecentBookingData
    {
        public int? BookingID { get; set; }
        public string? BookingNo { get; set; }
        public string? CustomerName { get; set; }
        public string? MobileNo { get; set; }
        public int? TotalTickets { get; set; }
        public int? TotalRooms { get; set; }
        public decimal? FinalPrice { get; set; }
        public string? PaymentStatus { get; set; }
        public string? BookingStatus { get; set; }
        public bool? IsHotelDetails { get; set; }

    }

    public class DashboardBookingData :MessageBaseEntity
    {
       
        public List<DashboardBookingViewData>? Bookings { get; set; }
        public List<DashboardBookingTicketData>? Tickets { get; set; }
      
        public List<DashboardBookingHotelData>? HotelDetails { get; set; }
       
    }

    public class DashboardBookingViewData : MessageBaseEntity
    {
        public int? ID { get; set; }
        public string? BookingNo { get; set; }
        public int? CustomerID { get; set; }

        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? MobileNo { get; set; }
        public string? EmailID { get; set; }

        public decimal? OrderValue { get; set; }
        public decimal? DiscountValue { get; set; }
        public decimal? ServiceCharge { get; set; }
        public decimal? FinalPrice { get; set; }
        public decimal? RoundOff { get; set; }

        public DateTime? TicketDate { get; set; }
        public int? TotalRooms { get; set; }
        public int? TotalTickets { get; set; }

        public DateTime? CreatedOn { get; set; }

        public string? PaymentStatus { get; set; }
        public string? BookingStatus { get; set; }
    }

    public class DashboardBookingTicketData
    {
        public int? ID { get; set; }
        public int? BookingID { get; set; }

        public int? TicketID { get; set; }
        public int? TimeSlotID { get; set; }
        public int? ProjectionMappingID { get; set; }

        public decimal? Price { get; set; }
        public decimal? ServiceCharge { get; set; }
        public decimal? TotalPrice { get; set; }

        public int? NoOfTicket { get; set; }
        public List<DashboardBookingTicketPaxData>? PaxDetails { get; set; }
    }

    public class DashboardBookingTicketPaxData
    {
        public int? ID { get; set; }
        public int? BookingTicketID { get; set; }

        public string? Name { get; set; }
        public int? Age { get; set; }
        public string? Gender { get; set; }

        public decimal? Price { get; set; }

        public int? CountryID { get; set; }
        public int? StateID { get; set; }
    }

    public class DashboardBookingHotelData
    {
        public int? ID { get; set; }
        public int? BookingID { get; set; }

        public int? HotelID { get; set; }
        public int? RoomCategoryID { get; set; }

        public DateTime? CheckIn { get; set; }
        public DateTime? CheckOut { get; set; }

        public int? Night { get; set; }
        public int? Rooms { get; set; }

        public int? Adults { get; set; }
        public int? Child { get; set; }

        public int? ExtraAdult { get; set; }
        public int? ExtraChild { get; set; }

        public decimal? TotalAmount { get; set; }
    }


    public class DashboardInquiryData : MessageBaseEntity
    {
        public int? ID { get; set; }

        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? CompanyName { get; set; }

        public string? MobileNo { get; set; }
        public string? Email { get; set; }

        public int? CityID { get; set; }

        public int? Adults { get; set; }
        public int? Child { get; set; }
        public int? Nights { get; set; }

        public string? CheckInDate { get; set; }
        public string? CheckOut { get; set; }

        public int? HotelID { get; set; }

        public string? InquiryType { get; set; }
        public string? PackageName { get; set; }

        public string? Remarks { get; set; }

        public string? CreatedOn { get; set; }
    }

    public class DashboardTomorrowCheckInData : MessageBaseEntity
    {
        public int? ID { get; set; }
        public int? BookingID { get; set; }

        public string? BookingNo { get; set; }

        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? MobileNo { get; set; }
        public string? EmailID { get; set; }

        public int? RoomCategoryID { get; set; }

        public string? CheckIn { get; set; }
        public string? CheckOut { get; set; }

        public int? Night { get; set; }
        public int? Rooms { get; set; }

        public int? Adults { get; set; }
        public int? Child { get; set; }

        public int? ExtraAdult { get; set; }
        public int? ExtraChild { get; set; }

        public bool? IsHotelDetails { get; set; }
        public decimal? TotalAmount { get; set; }
    }

    public class PDFDownloadResponse
    {
        public byte[] PDFBytes { get; set; }
        public string BookingNo { get; set; }
    }
}