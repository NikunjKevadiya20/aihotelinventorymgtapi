using HotelBooking.Entity.Common.Entities;
using HotelBooking.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBooking.DataAccess.Base
{
    public interface IBannerLookupRepositoryInterface
    {
        Task<BannerIDViewEntity> InsertBanner(BannerEntity entity, string storedProcedure);
        Task<ResultModel> UpdateBanner(BannerEntity entity, string storedProcedure);
        Task<ResultModel> DeleteBanner(BannerIDEntity entity, string storedProcedure);
        Task<BannerDataViewEntity> FindByIDBanner(BannerIDEntity entity, string storedProcedure);
        Task<List<BannerDataViewEntity>> FindAllBanner(BannerIDEntity entity, string storedProcedure);
        Task<List<BannerDataViewEntity>> FindAllActiveBanner(string storedProcedure);
        Task<ResultModel> ActiveInActiveBanner(BannerIDEntity entity, string storedProcedure);
        Task<ResultModel> BannerImageUpdate(string? physicalFileName, string? AltTitle, int? ID, int? UpdatedBy, string storedProcedure);
    }
}
