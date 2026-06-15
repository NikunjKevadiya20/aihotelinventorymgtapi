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
    public class BannerDomain : IBannerDomain
    {
        IBannerRepository repository;
        public BannerDomain(IBannerRepository _repository)
        {
            repository = _repository;
        }

        public async Task<BannerIDViewEntity> InsertBanner(BannerEntity entity)
        {
            return await repository.InsertBanner(entity);
        }
        public async Task<ResultModel> UpdateBanner(BannerEntity entity)
        {
            return await repository.UpdateBanner(entity);
        }
        public async Task<ResultModel> DeleteBanner(BannerIDEntity entity)
        {
            return await repository.DeleteBanner(entity);
        }
        public async Task<BannerDataViewEntity> FindByIDBanner(BannerIDEntity entity)
        {
            return await repository.FindByIDBanner(entity);
        }
        public async Task<List<BannerDataViewEntity>> FindAllBanner(BannerIDEntity entity)
        {
            return await repository.FindAllBanner(entity);
        }
        public async Task<List<BannerDataViewEntity>> FindAllActiveBanner()
        {
            return await repository.FindAllActiveBanner();
        }
        public async Task<ResultModel> ActiveInActiveBanner(BannerIDEntity entity)
        {
            return await repository.ActiveInActiveBanner(entity);
        }
        public async Task<ResultModel> BannerImageUpdate(string? physicalFileName, string? AltTitle, int? ID, int? UpdatedBy)
        {
            return await repository.BannerImageUpdate(physicalFileName, AltTitle, ID, UpdatedBy);
        }
    }
}
