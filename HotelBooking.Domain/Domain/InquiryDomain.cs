using HotelBooking.DataAccess.Interfaces;
using HotelBooking.Domain.Interfaces;
using HotelBooking.Entity.Common.Entities;
using HotelBooking.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBooking.Domain.Domain
{
    public class InquiryDomain : IInquiryDomain
    {
        IInquiryRepository repository;
        public InquiryDomain(IInquiryRepository _repository)
        {
            repository = _repository;
        }

        public async Task<ResultModel> InsertInquiry(InquiryEntity entity)
        {
            return await repository.InsertInquiry(entity);
        }
        public async Task<List<InquiryViewEntity>> FindAllInquiry(InquiryPagination entity)
        {
            return await repository.FindAllInquiry(entity);
        }
    }
}
