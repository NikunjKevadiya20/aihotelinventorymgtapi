using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBooking.Entity.Entities
{
    public class CompanyProfile : MessageBaseEntity
    {
        public int? Id { get; set; }
        public string? Manager { get; set; }
        public string? AmenitiesIDs { get; set; }
        public string? AmenitiesNames { get; set; }
        public string? HotelEmail { get; set; }
        public string? ReservationsManager { get; set; }
        public string? ReservationsEmail { get; set; }
        public string? ReservationsTelephone { get; set; }
        public bool? IsDisableBookingEmails { get; set; }
        public string? SalesManager { get; set; }
        public string? AccountsManager { get; set; }
        public string? CancellationPolicyName { get; set; }
        public string? CancellationTerm { get; set; }
        public string? CutOffType { get; set; }
        public int? CutOffDays { get; set; }
        public DateTime? CutOffTime { get; set; }
        public string? PenaltyType { get; set; }
        public decimal? PenaltyValue { get; set; }
        public string? StayType { get; set; }
        public string? CancellationDescription { get; set; }
        public int? ChildPolicyFromAge { get; set; }
        public int? ChildPolicyToAge { get; set; }
        public string? ChildPolicyDescription { get; set; }
        public string? MetaKeywords { get; set; }
        public string? PrivacyStatement { get; set; }
        public string? ExtraBedPolicy { get; set; }
        public string? TermsAndConditionsType { get; set; }
        public string? TermsAndConditionsUrl { get; set; }
        public string? TermsAndConditionsText { get; set; }
        public string? CreditCardTerms { get; set; }
        public bool? IsCloseOutTime { get; set; }
        public string? CheckInTime { get; set; }
        public string? CheckOutTime { get; set; }
        public string? EstimatedArrivalFrom { get; set; }
        public string? EstimatedArrivalTo { get; set; }
        public string? CheckInDescription { get; set; }
        public string? PaymentTermsType { get; set; }
        public string? PaymentTermsHeading { get; set; }
        public string? PaymentTermsDescription { get; set; }
        public string? PrivacyPolicyType { get; set; }
        public string? PrivacyPolicyUrl { get; set; }
        public string? PrivacyPolicyText { get; set; }
        public string? StreetAddress { get; set; }
        public string? MapLink { get; set; }
        public string? LocationSuburb { get; set; }
        public string? Country { get; set; }
        public string? State { get; set; }
        public string? City { get; set; }
        public string? PostalCode { get; set; }
        public decimal? Latitude { get; set; }
        public decimal? Longitude { get; set; }
        public string? Telephone { get; set; }
        public string? Fax { get; set; }
        public string? PropertyName { get; set; }
        public string? MaxId { get; set; }
        public string? PropertyDescription { get; set; }
        public string? AdministratorEmail { get; set; }
        public string? WhatsAppCountryCode { get; set; }
        public string? WhatsAppMobileNumber { get; set; }
        public string? PropertyType { get; set; }
        public string? Website { get; set; }
        public string? Image { get; set; }
        public string? SecondaryDomains { get; set; }
        public string? Currency { get; set; }
        public decimal? StarRating { get; set; }
        public string? WeekEndNights { get; set; }
        public bool? IsActive { get; set; }
        public Int32? CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public Int32? UpdatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public bool? IsDeleted { get; set; }

        // Amenities types and associated amenities will be nested here for responses
        public List<AmenitiesTypeDataViewEntity> AmenitiesType { get; set; } = new();
    }
    public class ExperienceImageDataEntity
    { 
        public IFormFile? Image { get; set; }
    }
    public class CompanyProfileIDEntity : MessageBaseEntity
    {
        public int? Id { get; set; }
    }
}
