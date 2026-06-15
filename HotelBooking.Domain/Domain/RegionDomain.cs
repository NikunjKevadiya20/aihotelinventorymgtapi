using HotelBooking.DataAccess.Interfaces;
using HotelBooking.Domain.Interfaces;
using HotelBooking.Entity.Common.Entities;
using HotelBooking.Entity.Entities;

namespace HotelBooking.Domain.Domain
{
    public class RegionDomain : IRegionDomain
    {
        IRegionRepository repository;
        public RegionDomain(IRegionRepository _repository)
        {
            repository = _repository;
        }
        public async Task<ResultModel> InsertRegion(RegionDataEntity entity)
        {
            return await repository.InsertRegion(entity);
        }
        public async Task<ResultModel> UpdateRegion(RegionDataEntity entity)
        {
            return await repository.UpdateRegion(entity);
        }
        public async Task<ResultModel> DeleteRegion(RegionIDEntity entity)
        {
            return await repository.DeleteRegion(entity);
        }
        public async Task<RegionViewEntity> FindByIDRegion(RegionIDEntity entity)
        {
            return await repository.FindByIDRegion(entity);
        }
        public async Task<List<RegionViewEntity>> FindAllRegion(RegionIDEntity entity)
        {
            return await repository.FindAllRegion(entity);
        }
        public async Task<List<RegionViewEntity>> FindAllActiveRegion()
        {
            return await repository.FindAllActiveRegion();
        }
        public async Task<ResultModel> ActiveInActiveRegion(RegionIDEntity entity)
        {
            return await repository.ActiveInActiveRegion(entity);
        }
    }
}
