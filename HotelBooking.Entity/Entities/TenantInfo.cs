using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBooking.Entity.Entities
{
    public class TenantInfo
    {
        public int ID { get; set; }
        public string Website { get; set; }
        public string DatabaseName { get; set; }
        public string ServerName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string OrganizationCode { get; set; }
        public string OrganizationName { get; set; }
    }
}
