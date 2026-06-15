using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBooking.Entity.Entities
{
    public class MenuEntity
    {
        public int? ID { get; set; }
        public string? MenuName { get; set; }
        public string? MenuKey { get; set; }
        public Boolean? IsMenu { get; set; }
        public int? UnderMenuID { get; set; }
        public Boolean? IsActive { get; set; } 
        public Int32? CreatedBy { set; get; }
        public Int32? UpdatedBy { set; get; }
        public string? Details { get; set; }
        public string? Message { get; set; }

    }

    public class MenuIDEntity : MessageBaseEntity
    {
        public int? ID { get; set; }
        public string? MenuName { get; set; }
        public Int32? UpdatedBy { set; get; }
        public Boolean? IsActive { get; set; }
    }

    public class MenuViewEntity
    {
        public Int32 ID { set; get; }
     public string? MenuName { get; set; }
        public string? MenuKey { get; set; }
        public Boolean? IsMenu { get; set; }
        public int? UnderMenuID { get; set; }
        public Boolean? IsActive { get; set; }
        public string? Details { get; set; }
        public string? Message { get; set; }
        public int? Status { get; set; }
        public string? ErrorMessage { get; set; }

    }
    public class MenuFindByIDData
    {
        public int? ID { get; set; }
        public string? MenuName { get; set; }
        public string? MenuKey { get; set; }
        public Boolean? IsMenu { get; set; }
        public int? UnderMenuID { get; set; }
        public Boolean? IsActive { get; set; }

        public string? Details { get; set; }
        public string? Message { get; set; }
        public int Status { get; set; }
        public string ErrorMessage { get; set; }
        public List<MenuSubList> MenuSubList { get; set; }

    }
    public class MenuSubList
    {
        public int? ID { get; set; }
        public string? MenuName { get; set; }
        public string? MenuKey { get; set; }
        public Boolean? IsMenu { get; set; }
        public int? UnderMenuID { get; set; }
        public Boolean? IsActive { get; set; }
    }

}
