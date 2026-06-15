using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBooking.Entity.Common
{
    [Serializable]
    public class ResultList<T> where T : new()
    {
        public ResultList()
        {
            List = new List<T>();
        }
        public List<T> List { get; set; }
        public string Details { get; set; }
        public int Status { get; set; }
        public string Message { get; set; }
        public string CachingStatus { set;  get; }
        public int ItemCount { set; get; }
        public int TotalPages { set; get; }

    }
}
