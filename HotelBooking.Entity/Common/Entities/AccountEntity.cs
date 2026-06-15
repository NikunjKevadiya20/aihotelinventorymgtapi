using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBooking.Entity.Common.Entities
{
    public class AccountEntity
    {
        public int? id { get; set; }
        public Guid? account_guid { get; set; }
        public int? under_group_id { get; set; }
        public string? account_name { get; set; }
        public string? short_alias_name { get; set; }
        public string? contact_person_name { get; set; }
        public string? email { get; set; }
        public string? mobile_number { get; set; }
        public string? address1 { get; set; }
        public string? address2 { get; set; }
        public int? pincode { get; set; }
        public int? country_id { get; set; }
        public int? state_id { get; set; }
        public int? city_id { get; set; }
        public Boolean? provide_bank_details { get; set; }
        public string? bank_account_name { get; set; }
        public string? account_no { get; set; }
        public string? ifsc_code { get; set; }
        public string? bank_name { get; set; }
        public Boolean? enable_credit_limit { get; set; }
        public int? limit_set_based_on_no_of_invoice { get; set; }
        public decimal? limit_set_based_on_outstanding_amount { get; set; }
        public decimal? opening_balance { get; set; }
        public string? openingbalance_credit_debit { get; set; }
        public string? pan_no { get; set; }
        public string? gst_no { get; set; }
        public int? user_type_id { get; set; }
        public string? password { get; set; }
        public string? user_name { get; set; }
        public int? payment_due_days { get; set; }
        public int? district_id {  get; set; }
        public int? route_id {  get; set; }
        public string? alternet_mobile_no {  get; set; }
        public Boolean? isactive { get; set; }
        public Int32? createdby { set; get; }
        public Int32? updatedby { set; get; }
        public string? Details { get; set; }
        public string? Message { get; set; }
    }
    public class AccountID : MessageBaseEntity
    {
        public int? id { get; set; }
        public Guid? account_guid { get; set; }
        public int? under_group_id { get; set; }
        public string? account_name { get; set; }
        public string? short_alias_name { get; set; }
        public string? contact_person_name { get; set; }
        public string? email { get; set; }
        public string? mobile_number { get; set; }
        public string? address1 { get; set; }
        public string? address2 { get; set; }
        public int? pincode { get; set; }
        public int? country_id { get; set; }
        public int? state_id { get; set; }
        public string? state_name { get; set; }
        public int? city_id { get; set; }
        public string? city_name { get; set; }
        public Boolean? provide_bank_details { get; set; }
        public string? bank_account_name { get; set; }
        public string? account_no { get; set; }
        public string? ifsc_code { get; set; }
        public string? bank_name { get; set; }
        public Boolean? enable_credit_limit { get; set; }
        public int? limit_set_based_on_no_of_invoice { get; set; }
        public decimal? limit_set_based_on_outstanding_amount { get; set; }
        public decimal? opening_balance { get; set; }
        public string? openingbalance_credit_debit { get; set; }
        public string? pan_no { get; set; }
        public string? gst_no { get; set; }
        public int? user_type_id { get; set; }
        public string? user_name { get; set; }
        public int? district_id { get; set; }
        public int? route_id { get; set; }
        public string? alternet_mobile_no { get; set; }
        public Boolean? isactive { get; set; }
        public Int32? createdby { set; get; }
        public Int32? updatedby { set; get; }
        public string? Details { get; set; }
        public string? Message { get; set; }
        public int? Status { get; set; }
        public string? ErrorMessage { get; set; }
    }
    public class AccountViewEntity
    {
        public int? id { get; set; }
        public Guid? account_guid { get; set; }
        public int? under_group_id { get; set; }
        public string? under_group_name { get; set; }
        public string? account_name { get; set; }
        public string? short_alias_name { get; set; }
        public string? contact_person_name { get; set; }
        public string? email { get; set; }
        public string? mobile_number { get; set; }
        public string? address1 { get; set; }
        public string? address2 { get; set; }
        public int? pincode { get; set; }
        public int? country_id { get; set; }
        public int? state_id { get; set; }
        public string? state_name { get; set; }
        public int? city_id { get; set; }
        public string? city_name { get; set; }
        public Boolean? provide_bank_details { get; set; }
        public string? bank_account_name { get; set; }
        public string? account_no { get; set; }
        public string? ifsc_code { get; set; }
        public string? bank_name { get; set; }
        public Boolean? enable_credit_limit { get; set; }
        public int? limit_set_based_on_no_of_invoice { get; set; }
        public decimal? limit_set_based_on_outstanding_amount { get; set; }
        public decimal? opening_balance { get; set; }
        public string? openingbalance_credit_debit { get; set; }
        public string? pan_no { get; set; }
        public string? gst_no { get; set; }
        public int? user_type_id { get; set; }
        public string? user_name { get; set; }
        public int? payment_due_days { get; set; }
        public int? district_id { get; set; }
        public string? district_name {  get; set; }
        public int? route_id { get; set; }
        public string? route_name { get; set; }
        public string? alternet_mobile_no { get; set; }
        public Boolean? isactive { get; set; }
        public Int32? createdby { set; get; }
        public Int32? updatedby { set; get; }
        public string? Details { get; set; }
        public string? Message { get; set; }
        public int? Status { get; set; }
        public string? ErrorMessage { get; set; }
    }

    public class UnderGroup
    {
        public int id { get; set; }  
        public string? under_group_name { get; set; }
        public Boolean? isactive { get; set; }
        public Int32? createdby { set; get; }
        public Int32? updatedby { set; get; }
        public string? Details { get; set; }
        public string? Message { get; set; }
        public int? Status { get; set; }
        public string? ErrorMessage { get; set; }
    }

    public class IncremnetalAccountSearch
    {
        public int? id { get; set; }
        public Guid? account_guid { get; set; }
        public string? account_name { get; set; }
        public string? short_alias_name { get; set; }
        public string? Details { get; set; }
        public string? Message { get; set; }
        public int? Status { get; set; }
        public string? ErrorMessage { get; set; }
    }
    
}
