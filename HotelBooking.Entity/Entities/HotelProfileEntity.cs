using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBooking.Entity.Entities
{
    public class HotelProfileEntity
    {
        public int? ID { get; set; }
        public string? HotelName { get; set; }
        public string? Address { get; set; }
        public string? MobileNo { get; set; }
        public string? EmailID { get; set; }
        public string? MapURL { get; set; }
        public int? StarCategory { get; set; }
        public string? CheckInTime { get; set; }
        public string? CheckOutTime { get; set; }
        public string? ContactDetails { get; set; }
        public string? GSTDetails { get; set; }
        public string? BankDetails { get; set; }
        public string? ChildPolicy { get; set; }
        public string? CommonPolicy { get; set; }
        public string? CancellationPolicy { get; set; }
        public string? TermsAndCondition { get; set; }
        public string? LogoFile { get; set; }
        public Boolean? IsActive { get; set; }
        public Int32? CreatedBy { set; get; }
        public Int32? UpdatedBy { set; get; }
    }
    public class PhilosophyIDViewEntity : MessageBaseEntity
    {
        public int? ID { get; set; }
    }
    public class HotelProfileIDEntity : MessageBaseEntity
    {
        public int? ID { get; set; }
        public string? HotelName { get; set; }
        public Boolean? IsActive { get; set; }
        public Int32? UpdatedBy { set; get; }
    }
 
    public class HotelProfileViewEntity
    {
        public int? ID { get; set; }
        public string? HotelName { get; set; }
        public string? Address { get; set; }
        public string? MobileNo { get; set; }
        public string? EmailID { get; set; }
        public string? MapURL { get; set; }
        public int? StarCategory { get; set; }
        public string? CheckInTime { get; set; }
        public string? CheckOutTime { get; set; }
        public string? ContactDetails { get; set; }
        public string? GSTDetails { get; set; }
        public string? BankDetails { get; set; }
        public string? ChildPolicy { get; set; }
        public string? CommonPolicy { get; set; }
        public string? CancellationPolicy { get; set; }
        public string? TermsAndCondition { get; set; }
        public string? LogoFile { get; set; }
        public Boolean? IsActive { get; set; }
        public string? Message { get; set; }
        public string? Details { get; set; }
        public int? Status { get; set; }
        public string? ErrorMessage { get; set; }
    }

    public class HotelProfileLogoEntity
    {
        public int? ID { get; set; }
        public IFormFile? LogoFile { get; set; }
    }
}
