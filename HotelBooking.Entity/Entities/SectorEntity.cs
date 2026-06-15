using Microsoft.AspNetCore.Http;

/// <summary>
/// Added by NikunjK on 01-08-2023
/// </summary>
namespace HotelBooking.Entity.Entities
{
    public class SectorDataEntity
    {
        public int? ID { get; set; }
        public int? RegionID { get; set; }
        public int? CountryID { get; set; }
        public string? SectorType { get; set; }
        public string? SectorName { get; set; }
        public string? SectorURL { get; set; }
        public string? Prefix { get; set; }
        public string? CityID { get; set; }
        public string? Description { get; set; }
        public string? LongDescription { get; set; }
        public string? MetaTitle { get; set; }
        public string? MetaKeyWord { get; set; }
        public string? MetaDiscription { get; set; }
        public string? TermsNCondition { get; set; }
        public int? SequenceNo { get; set; }
        public string? Season { get; set; }
        public bool? IsShowOnMenu { get; set; }
        public bool? IsShowOnHome { get; set; }
        public Boolean? IsActive { get; set; }
        public Int32? CreatedBy { set; get; }
        public Int32? UpdatedBy { set; get; }
        public string? Inclusions { get; set; }
        public string? Exclusions { get; set; }
        public string? CancellationPolicy { get; set; }

        public string? Details { get; set; }
        public string? Message { get; set; }

    }

    public class SectorIDEntity : MessageBaseEntity
    {
        public int? ID { get; set; }
        public string? SectorName { get; set; }
        public string? SectorType { get; set; }
        public Int32? UpdatedBy { set; get; }
        public Boolean? IsActive { get; set; }
    }

    public class SectorViewEntity
    {
        public Int32 ID { set; get; }
        public int? RegionID { get; set; }
        public int? CountryID { get; set; }
        public string? CountryName { get; set; }
        public string? SectorType { get; set; }
        public string? SectorName { get; set; }
        public string? Prefix { get; set; }
        public string? CityID { get; set; }
        public bool? IsShowOnMenu { get; set; }
        public bool? IsShowOnHome { get; set; }
        public string? SectorURL { get; set; }
        public string? SectorImage { get; set; }
        public string? BannerImage { get; set; }
        public string? HomeImage { get; set; }
        public string? Description { get; set; }
        public string? LongDescription { get; set; }
        public string? MetaTitle { get; set; }
        public string? MetaKeyWord { get; set; }
        public string? MetaDiscription { get; set; }
        public string? TermsNCondition { get; set; }
        public int? SequenceNo { get; set; }
        public string? Season { get; set; }
        public string? Inclusions { get; set; }
        public string? Exclusions { get; set; }
        public string? CancellationPolicy { get; set; }
        public Boolean? IsActive { get; set; }
        public string? Details { get; set; }
        public string? Message { get; set; }
        public int? Status { get; set; }
        public string? ErrorMessage { get; set; }

    }
    public class CityListBySectorID : MessageBaseEntity
    {
        public int? ID { get; set; }
        public string? CityName { get; set; }
        public int? Status { get; set; }
        public string? ErrorMessage { get; set; }
    }

    public class SectorImageDataEntity
    {
        public int? ID { get; set; }
        public IFormFile? SectorImage { get; set; }
        public IFormFile? BannerImage { get; set; }
        public IFormFile? HomeImage { get; set; }

    }
}
