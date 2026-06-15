
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
    public class LoginRequestEntity
    { 
        public string? UserName { get; set; }
        public string? Password { get; set; }
        public Boolean? isemployee { get; set; }

    }
    public class LoginResponseEntity
    {
        public int? ID { get; set; }
        public Guid UserGUID { get; set; }
        public string? Name { get; set; }
        public string? UserName { get; set; }
        public string? EmailID { get; set; }
        public string? MobileNo { get; set; }
        public string? Message { get; set; }
        public string? Details { get; set; }
        public string? ErrorMessage { get; set; }
        public string? Token { get; set; }
        public string? RefreshToken { get; set; }
        public Boolean? IsEmployee { get; set; }
        public int? IsUser { get; set; }
        public int? UserTypeID { get; set; }
        public string? UserType { get; set; }
        public int? state_id { get; set; }
        public string? state_name { get; set; }
        public int? account_id{get;set;}
        public Guid? account_guid { get; set;}
        public string? account_name { get; set; }
        public IEnumerable<UserRightsAssign>? UserRightsAssign { get; set; }

    }
    public class UserRightsAssign
    {
        public int? MenuID { set; get; }
        public string? MenuKey { set; get; }
        public string? MenuName { set; get; }

        public string? RightsID { set; get; }
    }

    public class UserToken
    {
        public int? UserID { get; set; }
        public Guid? UserGUID { get; set; }
        public string? RefreshToken { get; set; }
        public Boolean? IsEmployee { get; set; }

    }

    public class ChangePasswordRequestEntity
    {
        public int? ID { get; set; }
        public string? UserName { get; set; }
        public string? OldPassword { get; set; }
        public string? Password { get; set; }
        public string? DeviceToken { get; set; }


    }
}
