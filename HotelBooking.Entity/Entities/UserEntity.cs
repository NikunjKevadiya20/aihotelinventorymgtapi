using HotelBooking.Entity.Common.Entities;
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
    public class UsersDataEntity
    {
        public int? ID { get; set; }
        public Guid? UserGUID { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? MobileNo { get; set; }
        public string? AlternateMobileNo { get; set; }
        public string? EmailID { get; set; }
        public string? AlternateEmailID { get; set; }
        public string? Password { get; set; }
        public Boolean? IsActive { get; set; }
        public int? UserTypeID { get; set; }
        public int? CreatedBy { get; set; }
        public int? UpdatedBy { get; set; }  
        public string? Details { get; set; }
        public string? Message { get; set; }
        public IEnumerable<UserRightsAssignData>? UserRightsAssign { get; set; }


    }
    public class UserRightsAssignData
    {
        public int? MenuID { set; get; }
        public string? RightsID { set; get; }
    }
    public class UserIDEntity : MessageBaseEntity
    {
        public int? ID { get; set; }
        public Guid? UserGUID { get; set; }
        public string? FirstName { get; set; }
        public Int32? UpdatedBy { set; get; }
        public Boolean? IsActive { get; set; }
    }
    public class UsersListEntity
    {
        public int? ID { get; set; }
        public Guid? UserGUID { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? MobileNo { get; set; }
        public string? AlternateMobileNo { get; set; }
        public string? EmailID { get; set; }
        public string? AlternateEmailID { get; set; }
        public string? Password { get; set; }
        public Boolean? IsActive { get; set; }
        public int? UserTypeID { get; set; }
        public int? CreatedBy { get; set; }
        public int? UpdatedBy { get; set; }

        public string Message { get; set; }
        public string? Details { get; set; }
        public int Status { get; set; }
        public string ErrorMessage { get; set; }
        public IEnumerable<UserRightsAssignList>? UserRightsAssign { get; set; }


    }

    public class EmployeeUsersListEntity
    {
        public int? ID { get; set; }
        public Guid? UserGUID { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public int? UserTypeID { get; set; }
        public string? UserType {  get; set; }
        public string? Message { get; set; }
        public string? Details { get; set; }
        public int? Status { get; set; }
        public string? ErrorMessage { get; set; }
        public IEnumerable<UserRightsAssignList>? UserRightsAssign { get; set; }
    }
    public class UserRightsAssignList
    {
        public int? ID { set; get; }
        public int? UserID { set; get; }
        public int? MenuID { set; get; }
        public string? MenuName { set; get; }
        public string? RightsID { set; get; }
    }
    public class UserIDView : MessageBaseEntity
    {
        public int? ID { set; get; }
    }
    public class UserImageDataEntity
    {
        public int? ID { get; set; }
        public IFormFile? UserImage { get; set; }

    }
    public class UserImageListEntity : ResultModel
    {
        public string? UserImage { get; set; }

    }


}