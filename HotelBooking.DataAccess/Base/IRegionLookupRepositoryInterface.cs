using HotelBooking.Entity.Common.Entities;
using HotelBooking.Entity.Entities;

namespace HotelBooking.DataAccess.Base
{
    public interface IRegionLookupRepositoryInterface
    {
        Task<ResultModel> InsertRegion(RegionDataEntity entity, string storedProcedure);
        Task<ResultModel> UpdateRegion(RegionDataEntity entity, string storedProcedure);
        Task<ResultModel> DeleteRegion(RegionIDEntity entity, string storedProcedure);
        Task<RegionViewEntity> FindByIDRegion(RegionIDEntity entity, string storedProcedure);
        Task<List<RegionViewEntity>> FindAllRegion(RegionIDEntity entity, string storedProcedure);
        Task<List<RegionViewEntity>> FindAllActiveRegion(string storedProcedure);
        Task<ResultModel> ActiveInActiveRegion(RegionIDEntity entity, string storedProcedure);

    }
}
