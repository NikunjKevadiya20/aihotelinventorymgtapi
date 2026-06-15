
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBooking.Entity.Entities
{
    public class SettingDataEntity
    {
        public int? ID { get; set; }
        public string? SettingKey { get; set; }
        public string? SettingType { get; set; }
        public string? SettingValue { get; set; }
        public Boolean? IsActive { get; set; }
        public Int32? CreatedBy { set; get; }
        public Int32? UpdatedBy { set; get; }
        public string? Details { get; set; }
        public string? Message { get; set; }

    }

    public class SettingIDEntity : MessageBaseEntity
    {
        public int? ID { get; set; }
        public string? SettingKey { get; set; }
        public Int32? UpdatedBy { set; get; }
        public Boolean? IsActive { get; set; }
    }

    public class SettingViewEntity
    {
        public Int32 ID { set; get; }
        public string? SettingKey { get; set; }
        public string? SettingType { get; set; }
        public string? SettingValue { get; set; }
        public Boolean? IsActive { get; set; }
        public string? Details { get; set; }
        public string? Message { get; set; }
        public int? Status { get; set; }
        public string? ErrorMessage { get; set; }

    }
}
