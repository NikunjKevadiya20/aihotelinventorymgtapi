using HotelBooking.Entity.Common.Entities;
using HotelBooking.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBooking.DataAccess.Base
{
    public interface IInquiryLookupRepositoryInterface
    {
        Task<ResultModel> InsertInquiry(InquiryEntity entity, string storedProcedure);
        Task<List<InquiryViewEntity>> FindAllInquiry(InquiryPagination entity, string storedProcedure);
    }
}
