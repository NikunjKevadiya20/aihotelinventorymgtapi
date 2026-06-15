using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBooking.Entity.Common
{
    [Serializable]
    public class ResultEntity<T> where T : new()
    {
        public ResultEntity()
        {
            Entity = new T();
        }

        public T Entity { get; set; }

        public string Details { get; set; }

        public int Status { get; set; }

        public string Message { get; set; }
        public string CachingStatus { set; get; }

    }

    public class RegistrationStatusEntity
    {
        public byte RegistrationStatus { get; set; }
        public long RegistrationId { get; set; }
        public bool OTPVerified { get; set; }
    }
}
