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
    public class BannerRepository: IBannerRepository
    {
        IBannerLookupRepositoryInterface repository;
        public BannerRepository(IBannerLookupRepositoryInterface _repository)
        {
            repository = _repository;
        }

        public async Task<BannerIDViewEntity> InsertBanner(BannerEntity entity)
        {
            return await repository.InsertBanner(entity, "sp_ManageBannersInsert");
        }
        public async Task<ResultModel> UpdateBanner(BannerEntity entity)
        {
            return await repository.UpdateBanner(entity, "sp_ManageBannersInsert");
        }
        public async Task<ResultModel> DeleteBanner(BannerIDEntity entity)
        {
            return await repository.DeleteBanner(entity, "sp_ManageBannersFindDelete");
        }
        public async Task<BannerDataViewEntity> FindByIDBanner(BannerIDEntity entity)
        {
            return await repository.FindByIDBanner(entity, "sp_ManageBannersFindDelete");
        }
        public async Task<List<BannerDataViewEntity>> FindAllBanner(BannerIDEntity entity)
        {
            return await repository.FindAllBanner(entity, "sp_ManageBannersFindDelete");
        }
        public async Task<List<BannerDataViewEntity>> FindAllActiveBanner()
        {
            return await repository.FindAllActiveBanner("sp_ManageBannersFindDelete");
        }
        public async Task<ResultModel> ActiveInActiveBanner(BannerIDEntity entity)
        {
            return await repository.ActiveInActiveBanner(entity, "sp_ManageBannersFindDelete");
        }
        public async Task<ResultModel> BannerImageUpdate(string? physicalFileName, string? AltTitle, int? ID, int? UpdatedBy)
        {
            return await repository.BannerImageUpdate(physicalFileName, AltTitle, ID, UpdatedBy, "sp_ManageBannersInsert");
        }
    }
  
}
