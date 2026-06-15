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
    public class FAQRepository : IFAQRepository
    {
        IFAQLookupRepositoryInterface repository;
        public FAQRepository(IFAQLookupRepositoryInterface _repository)
        {
            repository = _repository;
        }

        public async Task<ResultModel> InsertFAQ(FAQEntity entity)
        {
            return await repository.InsertFAQ(entity, "sp_ManageFAQInsert");
        }
        public async Task<ResultModel> UpdateFAQ(FAQEntity entity)
        {
            return await repository.UpdateFAQ(entity, "sp_ManageFAQInsert");
        }
        public async Task<ResultModel> DeleteFAQ(FAQIDEntity entity)
        {
            return await repository.DeleteFAQ(entity, "sp_ManageFAQFindDelete");
        }
        public async Task<FAQDataViewEntity> FindByIDFAQ(FAQIDEntity entity)
        {
            return await repository.FindByIDFAQ(entity, "sp_ManageFAQFindDelete");
        }
        public async Task<List<FAQDataViewEntity>> FindAllFAQ(FAQIDEntity entity)
        {
            return await repository.FindAllFAQ(entity, "sp_ManageFAQFindDelete");
        }
        public async Task<List<FAQDataViewEntity>> FindAllActiveFAQ()
        {
            return await repository.FindAllActiveFAQ("sp_ManageFAQFindDelete");
        }
        public async Task<ResultModel> ActiveInActiveFAQ(FAQIDEntity entity)
        {
            return await repository.ActiveInActiveFAQ(entity, "sp_ManageFAQFindDelete");
        }

    }

}

