using HotelBooking.Entity.Common.Entities;
using HotelBooking.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBooking.Domain.Interfaces
{
    public interface IInquiryDomain
    {
        Task<ResultModel> InsertInquiry(InquiryEntity entity);
        Task<List<InquiryViewEntity>> FindAllInquiry(InquiryPagination entity);
    }
}
