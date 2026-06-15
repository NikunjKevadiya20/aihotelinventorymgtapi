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
    public class SeoTagsDomain : ISeoTagsDomain
    {
        ISeoTagsRepository repository;
        public SeoTagsDomain(ISeoTagsRepository _repository)
        {
            repository = _repository;
        }

        public async Task<ResultModel> InsertSeoTags(SeoTagsDataEntity entity)
        {
            return await repository.InsertSeoTags(entity);
        }
        public async Task<ResultModel> UpdateSeoTags(SeoTagsDataEntity entity)
        {
            return await repository.UpdateSeoTags(entity);
        }
        public async Task<ResultModel> DeleteSeoTags(SeoTagsIDEntity entity)
        {
            return await repository.DeleteSeoTags(entity);
        }
        public async Task<SeoTagsViewEntity> FindByIDSeoTags(SeoTagsIDEntity entity)
        {
            return await repository.FindByIDSeoTags(entity);
        }
        public async Task<List<SeoTagsViewEntity>> FindAllSeoTags(SeoTagsIDEntity entity)
        {
            return await repository.FindAllSeoTags(entity);
        }
        public async Task<List<SeoTagsViewEntity>> FindAllActiveSeoTags()
        {
            return await repository.FindAllActiveSeoTags();
        }
        public async Task<ResultModel> ActiveInActiveSeoTags(SeoTagsIDEntity entity)
        {
            return await repository.ActiveInActiveSeoTags(entity);
        }

    }
}
