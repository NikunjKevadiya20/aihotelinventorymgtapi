using HotelBooking.DataAccess.Base;
using HotelBooking.DataAccess.Interfaces;
using HotelBooking.Entity.Common.Entities;
using HotelBooking.Entity.Entities;

namespace HotelBooking.DataAccess.Repositories
{
    public class RegionRepository : IRegionRepository
    {
        IRegionLookupRepositoryInterface repository;
        public RegionRepository(IRegionLookupRepositoryInterface _repository)
        {
            repository = _repository;
        }

        public async Task<ResultModel> InsertRegion(RegionDataEntity entity)
        {
            return await repository.InsertRegion(entity, "sp_ManageRegion");
        }
        public async Task<ResultModel> UpdateRegion(RegionDataEntity entity)
        {
            return await repository.UpdateRegion(entity, "sp_ManageRegion");
        }
        public async Task<ResultModel> DeleteRegion(RegionIDEntity entity)
        {
            return await repository.DeleteRegion(entity, "sp_ManageRegion");
        }
        public async Task<RegionViewEntity> FindByIDRegion(RegionIDEntity entity)
        {
            return await repository.FindByIDRegion(entity, "sp_ManageRegion");
        }

        public async Task<List<RegionViewEntity>> FindAllRegion(RegionIDEntity entity)
        {
            return await repository.FindAllRegion(entity, "sp_ManageRegion");
        }
        public async Task<List<RegionViewEntity>> FindAllActiveRegion()
        {
            return await repository.FindAllActiveRegion("sp_ManageRegion");
        }
        public async Task<ResultModel> ActiveInActiveRegion(RegionIDEntity entity)
        {
            return await repository.ActiveInActiveRegion(entity, "sp_ManageRegion");
        }
    }
}
