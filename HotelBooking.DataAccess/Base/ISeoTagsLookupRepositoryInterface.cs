using HotelBooking.Entity.Common.Entities;
using HotelBooking.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBooking.DataAccess.Base
{
    public interface ISeoTagsLookupRepositoryInterface
    {
        Task<ResultModel> InsertSeoTags(SeoTagsDataEntity entity, string storedProcedure);
        Task<ResultModel> UpdateSeoTags(SeoTagsDataEntity entity, string storedProcedure);
        Task<ResultModel> DeleteSeoTags(SeoTagsIDEntity entity, string storedProcedure);
        Task<SeoTagsViewEntity> FindByIDSeoTags(SeoTagsIDEntity entity, string storedProcedure);
        Task<List<SeoTagsViewEntity>> FindAllSeoTags(SeoTagsIDEntity entity, string storedProcedure);
        Task<List<SeoTagsViewEntity>> FindAllActiveSeoTags(string storedProcedure);
        Task<ResultModel> ActiveInActiveSeoTags(SeoTagsIDEntity entity, string storedProcedure);
    }
}
