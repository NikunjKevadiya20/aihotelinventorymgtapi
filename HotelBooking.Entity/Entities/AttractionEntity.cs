using Microsoft.AspNetCore.Http;

namespace HotelBooking.Entity.Entities
{
    public class AttractionEntity
    {
        public int? ID { get; set; }
        public int? PropertyID { get; set; }
        public string? Title { get; set; }
        public string? AttractionURL { get; set; }
        public string? AttractionCategory { get; set; }
        public string? TagLine { get; set; }
        public string? Distance { get; set; }
        public string? TravelTime { get; set; }
        public string? BestTime { get; set; }
        public string? Duration { get; set; }
        public string? Description { get; set; }
        public string? Dos { get; set; }
        public string? Donts { get; set; }
        public string? MainImage { get; set; }
        public string? BannerImage { get; set; }
        public string? MetaTitle { get; set; }
        public string? MetaDescription { get; set; }
        public string? MetaKeywords { get; set; }
        public Boolean? IsActive { get; set; }
        public Boolean? IsMustVisit { get; set; }
        public string? CreatedBy { get; set; }
        public string? UpdatedBy { get; set; }
        public List<AttractionBestTimeEntity>? BestTimes { get; set; }
        public List<AttractionHowToReachEntity>? HowToReach { get; set; }
        public List<AttractionThingsToDoEntity>? ThingsToDo { get; set; }
        public List<AttractionWhyVisitEntity>? WhyVisit { get; set; }
        public List<AttractionNearbyEntity>? Nearby { get; set; }
    }

    public class AttractionBestTimeEntity
    {
        public string? Title { get; set; }
        public string? SeasonType { get; set; }
        public string? Description { get; set; }
    }
    public class AttractionHowToReachEntity
    {
        public string? Title { get; set; }
        public string? Description { get; set; }
    }
    public class AttractionThingsToDoEntity
    {
        public string? Description { get; set; }
    }
    public class AttractionWhyVisitEntity
    {
        public string? Title { get; set; }
        public string? Description { get; set; }
    }
    public class AttractionNearbyEntity
    {
        public int? SelectedAttractionID { get; set; }
        public Decimal? KmAwayFromMainAttraction { get; set; }
    }
    public class AttractionNearbyEntityFBI
    {
        public int? SelectedAttractionID { get; set; }
        public Decimal? KmAwayFromMainAttraction { get; set; }
        public string? Title { get; set; }
        public string? MainImage { get; set; }
        public string? AttractionURL { get; set; }
    }
    public class AttractionPhotoGalleryEntityFBI
    {
        public int? ID { get; set; }
        public string? Image { get; set; }
    }
    public class AttractionPhotoGalleryEntity
    {
        public string? Image { get; set; }        
    }
    public class AttractionIDEntity : MessageBaseEntity
    {
        public int? ID { get; set; }
        public string? AttractionURL { get; set; }
        public string? Title { get; set; }
        public Boolean? IsActive { get; set; }
        public string? UpdatedBy { get; set; }
    }
    public class AttractionListEntity : MessageBaseEntity
    {
        public int? ID { get; set; }
        public int? PropertyID { get; set; }
        public string? PropertyName { get; set; }
        public string? PropertyURL { get; set; }
        public string? Title { get; set; }
        public string? AttractionURL { get; set; }
        public string? AttractionCategory { get; set; }
        public string? TagLine { get; set; }
        public string? Distance { get; set; }
        public string? TravelTime { get; set; }
        public string? BestTime { get; set; }
        public string? Duration { get; set; }
        public string? Description { get; set; }
        public string? Dos { get; set; }
        public string? Donts { get; set; }
        public string? MainImage { get; set; }
        public string? BannerImage { get; set; }
        public string? MetaTitle { get; set; }
        public string? MetaDescription { get; set; }
        public string? MetaKeywords { get; set; }
        public Boolean? IsActive { get; set; }
        public Boolean? IsMustVisit { get; set; }
        public Boolean? IsDeleted { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public string? UpdatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public List<AttractionBestTimeEntity>? BestTimes { get; set; }
        public List<AttractionHowToReachEntity>? HowToReach { get; set; }
        public List<AttractionThingsToDoEntity>? ThingsToDo { get; set; }
        public List<AttractionWhyVisitEntity>? WhyVisit { get; set; }
        public List<AttractionNearbyEntityFBI>? Nearby { get; set; }
        public List<AttractionPhotoGalleryEntityFBI>? Images { get; set; }
    }
    public class AttractionDataViewEntity : MessageBaseEntity
    {
        public int ID { get; set; }
        public int PropertyID { get; set; }
        public string? PropertyName { get; set; }
        public string? Title { get; set; }
        public string? AttractionURL { get; set; }
        public string? AttractionCategory { get; set; }
        public string? TagLine { get; set; }
        public string? Distance { get; set; }
        public string? TravelTime { get; set; }
        public string? BestTime { get; set; }
        public string? Duration { get; set; }
        public string? Description { get; set; }
        public string? Dos { get; set; }
        public string? Donts { get; set; }
        public string? MainImage { get; set; }
        public string? BannerImage { get; set; }
        public string? MetaTitle { get; set; }
        public string? MetaDescription { get; set; }
        public string? MetaKeywords { get; set; }
        public Boolean? IsActive { get; set; }
        public Boolean? IsMustVisit { get; set; }
        public Boolean? IsDeleted { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public string? UpdatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
    }
    public class AttractionDocumentsImage
    {
        public Int64? ID { get; set; }
        public string? FileName { get; set; }
    }
    public class AttratcionsDocumentsImage
    {
       public string? FileName { get; set; }
    }
    public class AttractionImage
    {
        public int? AttractionID { get; set; }
        public IFormFile? MainImage { get; set; }
        public IFormFile? BannerImage { get; set; }
        public List<IFormFile>? attachment { get; set; }
    }
}
