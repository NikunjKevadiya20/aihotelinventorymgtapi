using System;

namespace HotelBooking.Entity.Common
{
    [Serializable]
    public class SearchEntity<T> where T : new()
    {
        public SearchEntity()
        {
            Entity = new T();
        }

        public T Entity { get; set; }

        public int PageIndex { get; set; }

        public int PageSize { get; set; }

        public string Query { get; set; }

        public string Details { get; set; }
        public int Status { get; set; }
        public string Message { get; set; }
        public string CachingStatus { set; get; }
    }
}
