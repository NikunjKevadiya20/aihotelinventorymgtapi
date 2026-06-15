using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBooking.Entity.Entities
{
    public class InquiryEntity
    {
        public int? ID { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? CompanyName {  get; set; }
        public string? Address { get; set; }
        public string? AreYou { get; set; }
        public string? AreYouOther {  get; set; }
        public string? LookingFor {  get; set; }
        public string? LookingForOther {  get; set; }
        public string? Email { get; set; }
        public string? MobileNo { get; set; }
        public int? CityID { get; set; }
        public int? Adults { get; set; }
        public int? Child { get; set; }
        public int? Nights { get; set; }
        public int? HotelID { get; set; }
        public string? WebSiteURL { get; set; }
        public string? InquiryType { get; set; }
        public string? PackageName { get; set; }
        public DateTime? CheckInDate { get; set; }
        public DateTime? CheckOut { get; set; }
        public string? Remarks { get; set; }
        public Int32? CreatedBy { set; get; }
        public Int32? UpdatedBy { set; get; }
        public string? Details { get; set; }
        public string? Message { get; set; }

    }
    public class InquiryPagination
    {
        public int? Limit { get; set; }
        public int? Skip { get; set; }
        public string? FirstName { get; set; }
        //public string? MobileNo { get; set; }
        //public string? Email { get; set; }
    }
    public class InquiryViewEntity :MessageBaseEntity
    {
        public int? itemcount { get; set; }
        public int? totalpages {  get; set; }
        public int? id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? CompanyName { get; set; }
        public string? Address { get; set; }
        public string? AreYou { get; set; }
        public string? AreYouOther { get; set; }
        public string? LookingFor { get; set; }
        public string? LookingForOther { get; set; }
        public string? Email { get; set; }
        public string? MobileNo { get; set; }
        public string? WebSiteURL { get; set; }
        public string? CheckOut { get; set; }
        public string? HotelName { get; set; }
        public int? CityID { get; set; }
        public int? Adults { get; set; }
        public int? Child { get; set; }
        public int? Nights { get; set; }
        public string? CheckInDate { get; set; }
        public string? Remarks { get; set;}
        public string? Inquirydate { get; set; }
        public string? InquiryType { get; set; }
        public string? PackageName { get; set; }
    }
}
