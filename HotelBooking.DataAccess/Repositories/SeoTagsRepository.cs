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
    public class SeoTagsRepository : ISeoTagsRepository
    {
        ISeoTagsLookupRepositoryInterface repository;
        public SeoTagsRepository(ISeoTagsLookupRepositoryInterface _repository)
        {
            repository = _repository;
        }

        public async Task<ResultModel> InsertSeoTags(SeoTagsDataEntity entity)
        {
            return await repository.InsertSeoTags(entity, "sp_ManageSeoTagsInsert");
        }
        public async Task<ResultModel> UpdateSeoTags(SeoTagsDataEntity entity)
        {
            return await repository.UpdateSeoTags(entity, "sp_ManageSeoTagsInsert");
        }
        public async Task<ResultModel> DeleteSeoTags(SeoTagsIDEntity entity)
        {
            return await repository.DeleteSeoTags(entity, "sp_ManageSeoTagsFindDelete");
        }
        public async Task<SeoTagsViewEntity> FindByIDSeoTags(SeoTagsIDEntity entity)
        {
            return await repository.FindByIDSeoTags(entity, "sp_ManageSeoTagsFindDelete");
        }
        public async Task<List<SeoTagsViewEntity>> FindAllSeoTags(SeoTagsIDEntity entity)
        {
            return await repository.FindAllSeoTags(entity, "sp_ManageSeoTagsFindDelete");
        }
        public async Task<List<SeoTagsViewEntity>> FindAllActiveSeoTags()
        {
            return await repository.FindAllActiveSeoTags("sp_ManageSeoTagsFindDelete");
        }
        public async Task<ResultModel> ActiveInActiveSeoTags(SeoTagsIDEntity entity)
        {
            return await repository.ActiveInActiveSeoTags(entity, "sp_ManageSeoTagsFindDelete");
        }

    }
}
