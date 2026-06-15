using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBooking.Entity.Common.Entities
{
    public class ResponseModel
    {
        public dynamic Result { get; set; }
        public string Details { get; set; }

        public object List { get; set; }

        public string Message { get; set; }

        public int Status { get; set; }
        public string CachingStatus { set; get; }
    }
}
