namespace HotelBooking.Entity.Entities
{

    public class MealTypeDataEntity
    {
        public int? ID { get; set; }
        public string? MealType { get; set; }
        public string? Description { get; set; }

        public Boolean? IsActive { get; set; }
        public Int32? CreatedBy { set; get; }
        public Int32? UpdatedBy { set; get; }
        public string? Details { get; set; }
        public string? Message { get; set; }

    }
    public class MealTypeIDEntity : MessageBaseEntity
    {
        public int? ID { get; set; }
        public string? MealType { get; set; }
        public string? Description { get; set; }
        public Int32? UpdatedBy { set; get; }
        public Boolean? IsActive { get; set; }
    }
    public class MealTypeViewEntity
    {
        public Int32 ID { set; get; }
        public string? MealType { get; set; }
        public string? Description { get; set; }
        public Boolean? IsActive { get; set; }
        public string? Details { get; set; }
        public string? Message { get; set; }
        public int? Status { get; set; }
        public string? ErrorMessage { get; set; }

    }


}
