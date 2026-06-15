using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBooking.Entity.Common.Entities
{
    public class ResultModel
    {
        public int? ID { get; set; }
        public object Data { get; set; }
        public string Details { get; set; }
        public string Message { get; set; }
        public int Status { get; set; }
        public int ItemCount { set; get; }
        public string ErrorMessage { get; set; }
    }
    public class  ItemGroupResultModel
    {
        public int? id { get; set; }
        public Guid? item_group_guid { get; set; }
        public object Data { get; set; }
        public string Details { get; set; }
        public string Message { get; set; }
        public int Status { get; set; }
        public int ItemCount { set; get; }
        public string ErrorMessage { get; set; }
    }
    public class ItemResultModel
    {
        public int? id { get; set; }
        public Guid? item_guid { get; set; }
        public object Data { get; set; }
        public string Details { get; set; }
        public string Message { get; set; }
        public int Status { get; set; }
        public int ItemCount { set; get; }
        public string ErrorMessage { get; set; }
    }
    public class EmployeeResultModel
    {
        public int? id { get; set; }
        public Guid? user_guid { get; set; }
        public object Data { get; set; }
        public string Details { get; set; }
        public string Message { get; set; }
        public int Status { get; set; }
        public int ItemCount { set; get; }
        public string ErrorMessage { get; set; }
    }
    public class EmployeeEducationResultModel
    {
        public int? id { get; set; }
        public Guid? education_guid { get; set; }
        public object Data { get; set; }
        public string Details { get; set; }
        public string Message { get; set; }
        public int Status { get; set; }
        public int ItemCount { set; get; }
        public string ErrorMessage { get; set; }
    }
    public class EmployeeLeaveResultModel
    {
        public int? id { get; set; }
        public Guid? employee_leave_guid { get; set; }
        public object Data { get; set; }
        public string Details { get; set; }
        public string Message { get; set; }
        public int Status { get; set; }
        public int ItemCount { set; get; }
        public string ErrorMessage { get; set; }
    }

    public class SaleEmailResultModel
    {
        public string? url {  get; set; }
        public string? admin_email_id {  get; set; }
        public object Data { get; set; }
        public string Details { get; set; }
        public string Message { get; set; }
        public int Status { get; set; }
        public int ItemCount { set; get; }
        public string ErrorMessage { get; set; }
    }

    public class SectorResultModel
    {
        public object Data { get; set; }
        public string Details { get; set; }
        public string Message { get; set; }
        public int Status { get; set; }
        public int ItemCount { set; get; }
        public string ErrorMessage { get; set; }
        public string Result { get; set; }
        public int SectorID { get; set; }
    }
}
