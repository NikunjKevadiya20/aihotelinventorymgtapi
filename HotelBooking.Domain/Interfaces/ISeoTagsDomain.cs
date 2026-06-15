using HotelBooking.Entity.Common.Entities;
using HotelBooking.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBooking.Domain.Interfaces
{
    public interface ISeoTagsDomain
    {
        Task<ResultModel> InsertSeoTags(SeoTagsDataEntity entity);
        Task<ResultModel> UpdateSeoTags(SeoTagsDataEntity entity);
        Task<ResultModel> DeleteSeoTags(SeoTagsIDEntity entity);
        Task<SeoTagsViewEntity> FindByIDSeoTags(SeoTagsIDEntity entity);
        Task<List<SeoTagsViewEntity>> FindAllSeoTags(SeoTagsIDEntity entity);
        Task<List<SeoTagsViewEntity>> FindAllActiveSeoTags();
        Task<ResultModel> ActiveInActiveSeoTags(SeoTagsIDEntity entity);

    }
}
