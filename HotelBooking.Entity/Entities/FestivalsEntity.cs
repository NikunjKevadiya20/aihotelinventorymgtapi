namespace HotelBooking.Entity.Entities
{
    // Added by AI009 on 25-03-23

    public class FestivalsEntity : MessageBaseEntity
    {
        public int? ID { get; set; }

        public string? Title { get; set; }
        public string? Description { get; set; }
        public Int32 CreatedBy { set; get; }
        public Boolean? IsActive { get; set; }

    }

    public class FestivalEntity : MessageBaseEntity
    {
        public int? ID { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public Int32 CreatedBy { set; get; }
        public Int32 UpdatedBy { set; get; }
        public int? IsUser { set; get; }
        public Boolean? IsActive { get; set; }


    }
    public class FestivalsViewEntity : MessageBaseEntity
    {
        public int? ID { get; set; }
        public Int32 UpdatedBy { set; get; }
        public Boolean? IsActive { get; set; }

    }

}
