using HotelBooking.Entity.Common.Entities;
using HotelBooking.Entity.Entities;

namespace HotelBooking.DataAccess.Base
{
    /// <summary>
    /// Added by NikunjK on 01-08-2023
    /// </summary>
    public interface ISectorLookupRepositoryInterface
    {
        Task<SectorResultModel> InsertSector(SectorDataEntity entity, string storedProcedure);
        Task<ResultModel> UpdateSector(SectorDataEntity entity, string storedProcedure);
        Task<ResultModel> DeleteSector(SectorIDEntity entity, string storedProcedure);
        Task<SectorViewEntity> FindByIDSector(SectorIDEntity entity, string storedProcedure);
        Task<List<SectorViewEntity>> FindAllSector(SectorIDEntity entity, string storedProcedure);
        Task<List<SectorViewEntity>> FindAllActiveSector(string storedProcedure);
        Task<ResultModel> ActiveInActiveSector(SectorIDEntity entity, string storedProcedure);
        Task<List<CityListBySectorID>> FindCityBySectorID(SectorIDEntity entity, string storedProcedure);
        Task<List<SectorViewEntity>> SectorShowOnMenu(string storedProcedure);
        Task<List<SectorViewEntity>> SectorShowOnHome(string storedProcedure);
        Task<ResultModel> SectorImageUpdate(string? MainImage, string? BannerImage, string? HomeImage, int? ID, int? UpdatedBy, string storedProcedure);
        Task<List<SectorViewEntity>> FindAllSectorIncrementalSearch(SectorIDEntity entity, string storedProcedure);
        Task<List<SectorViewEntity>> FindAllSectorTypeWiseSector(SectorIDEntity entity, string storedProcedure);

    }
}

