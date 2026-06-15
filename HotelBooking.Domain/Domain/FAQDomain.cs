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
    public class FAQDomain : IFAQDomain
    {
        IFAQRepository repository;
        public FAQDomain(IFAQRepository _repository)
        {
            repository = _repository;
        }

        public async Task<ResultModel> InsertFAQ(FAQEntity entity)
        {
            return await repository.InsertFAQ(entity);
        }
        public async Task<ResultModel> UpdateFAQ(FAQEntity entity)
        {
            return await repository.UpdateFAQ(entity);
        }
        public async Task<ResultModel> DeleteFAQ(FAQIDEntity entity)
        {
            return await repository.DeleteFAQ(entity);
        }
        public async Task<FAQDataViewEntity> FindByIDFAQ(FAQIDEntity entity)
        {
            return await repository.FindByIDFAQ(entity);
        }
        public async Task<List<FAQDataViewEntity>> FindAllFAQ(FAQIDEntity entity)
        {
            return await repository.FindAllFAQ(entity);
        }
        public async Task<List<FAQDataViewEntity>> FindAllActiveFAQ()
        {
            return await repository.FindAllActiveFAQ();
        }
        public async Task<ResultModel> ActiveInActiveFAQ(FAQIDEntity entity)
        {
            return await repository.ActiveInActiveFAQ(entity);
        }
    }
}
