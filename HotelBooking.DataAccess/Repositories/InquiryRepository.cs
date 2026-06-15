using HotelBooking.DataAccess.Base;
using HotelBooking.DataAccess.Interfaces;
using HotelBooking.Entity.Common.Entities;
using HotelBooking.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBooking.DataAccess.Repositories
{
    public class InquiryRepository : IInquiryRepository
    {
        IInquiryLookupRepositoryInterface repository;
        public InquiryRepository(IInquiryLookupRepositoryInterface _repository)
        {
            repository = _repository;
        }

        public async Task<ResultModel> InsertInquiry(InquiryEntity entity)
        {
            return await repository.InsertInquiry(entity, "sp_ManageInquiryInsert");
        }
      
        public async Task<List<InquiryViewEntity>> FindAllInquiry(InquiryPagination entity)
        {
            return await repository.FindAllInquiry(entity, "sp_ManageInquiryFindAll");
        }
    }
}

