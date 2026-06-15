using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// Added by NikunjK on 01-08-2023
/// </summary>
namespace HotelBooking.Entity.Entities
{
    public class UserTypeDataEntity
    {
        public int? ID { get; set; }
        public string? UserType { get; set; }
        public Boolean? IsActive { get; set; }
        public Int32? CreatedBy { set; get; }
        public Int32? UpdatedBy { set; get; }
        public string? Details { get; set; }
        public string? Message { get; set; }
        public IEnumerable<UserRightsAssignEntity>? UserTypeRightsAssign { get; set; }
    }

    public class UserRightsAssignEntity
    {
        public int? MenuID { set; get; }  
        public string? RightsID { set; get; }
    }
    public class UserTypeIDEntity : MessageBaseEntity
    {
        public int? ID { get; set; }
        public string? UserType { get; set; }
        public Int32? UpdatedBy { set; get; }
        public Boolean? IsActive { get; set; }
    }

    public class UserTypeListEntity 
    {
        public int? ID { get; set; }
        public string? UserType { get; set; }
        public Boolean? IsActive { get; set; }
        public string Message { get; set; }
        public string? Details { get; set; }
        public int Status { get; set; }
        public string ErrorMessage { get; set; }
        public IEnumerable<UserRightsAssign>? UserTypeRightsAssign { get; set; }
    }

}
