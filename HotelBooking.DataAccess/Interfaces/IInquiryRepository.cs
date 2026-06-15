using HotelBooking.Entity.Common.Entities;
using HotelBooking.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBooking.DataAccess.Interfaces
{
    public interface IInquiryRepository
    {
        Task<ResultModel> InsertInquiry(InquiryEntity entity);
        Task<List<InquiryViewEntity>> FindAllInquiry(InquiryPagination entity);
    }
}
