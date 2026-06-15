using HotelBooking.Entity.Common.Entities;
using HotelBooking.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBooking.Domain.Interfaces
{
    public interface IBannerDomain
    {
        Task<BannerIDViewEntity> InsertBanner(BannerEntity entity);
        Task<ResultModel> UpdateBanner(BannerEntity entity);
        Task<ResultModel> DeleteBanner(BannerIDEntity entity);
        Task<BannerDataViewEntity> FindByIDBanner(BannerIDEntity entity);
        Task<List<BannerDataViewEntity>> FindAllBanner(BannerIDEntity entity);
        Task<List<BannerDataViewEntity>> FindAllActiveBanner();
        Task<ResultModel> ActiveInActiveBanner(BannerIDEntity entity);
        Task<ResultModel> BannerImageUpdate(string? physicalFileName, string? AltTitle, int? ID, int? UpdatedBy);

    }
}
