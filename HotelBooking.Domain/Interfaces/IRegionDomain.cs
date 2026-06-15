using HotelBooking.Entity.Common.Entities;
using HotelBooking.Entity.Entities;

namespace HotelBooking.Domain.Interfaces
{
    public interface IRegionDomain
    {
        Task<ResultModel> InsertRegion(RegionDataEntity entity);
        Task<ResultModel> UpdateRegion(RegionDataEntity entity);
        Task<ResultModel> DeleteRegion(RegionIDEntity entity);
        Task<RegionViewEntity> FindByIDRegion(RegionIDEntity entity);
        Task<List<RegionViewEntity>> FindAllRegion(RegionIDEntity entity);
        Task<List<RegionViewEntity>> FindAllActiveRegion();
        Task<ResultModel> ActiveInActiveRegion(RegionIDEntity entity);

    }
}
