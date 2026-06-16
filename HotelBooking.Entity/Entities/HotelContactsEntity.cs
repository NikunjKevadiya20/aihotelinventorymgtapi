/// <summary>
/// Added by NikunjK on 01-08-2023
/// </summary>
namespace HotelBooking.Entity.Entities
{
    public class HotelContactDataEntity : MessageBaseEntity
    {
        public int? ID { get; set; }
        public int? HotelID { get; set; }
        public string? ContactPersonName { get; set; }
        public string? ContactPersonMobileNo { get; set; }
        public string? ContactPersonEmailID { get; set; }
        public string? ContactPersonDesignation { get; set; }
        public bool? IsActive { get; set; }
        public int? CreatedBy { get; set; }
        public int? UpdatedBy { get; set; }
        public int? DeletedBy { get; set; }
        public int? IsUser { get; set; }
        public int? IsDeletedUser { get; set; }
        public int? IsUpdatedUser { get; set; }

    }

    public class HotelContactIDEntity : MessageBaseEntity
    {
        public int? ID { get; set; }
        public int? HotelID { get; set; }

        public string? HotelContactName { get; set; }
        public Int32? UpdatedBy { set; get; }
        public Boolean? IsActive { get; set; }
    }

    public class HotelContactViewEntity : MessageBaseEntity
    {
        public int? ID { get; set; }
        public int? HotelID { get; set; }
        public string? ContactPersonName { get; set; }
        public string? ContactPersonMobileNo { get; set; }
        public string? ContactPersonEmailID { get; set; }
        public string? ContactPersonDesignation { get; set; }
        public bool? IsActive { get; set; }

    }

    public class HotelContactsViewEntity : MessageBaseEntity
    {
        public int? ID { get; set; }
        public IEnumerable<HotelContactEnityReq>? HotelContactList { get; set; }
    }

}
