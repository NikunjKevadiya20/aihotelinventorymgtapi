using HotelBooking.Entity.Common.Entities;
using HotelBooking.Entity.Entities;

namespace HotelBooking.DataAccess.Interfaces
{
    /// <summary>
    /// Added by NikunjK on 01-08-2023
    /// </summary>

    public interface ISectorRepository
    {
        Task<SectorResultModel> InsertSector(SectorDataEntity entity);
        Task<ResultModel> UpdateSector(SectorDataEntity entity);
        Task<ResultModel> DeleteSector(SectorIDEntity entity);
        Task<SectorViewEntity> FindByIDSector(SectorIDEntity entity);
        Task<List<SectorViewEntity>> FindAllSector(SectorIDEntity entity);
        Task<List<SectorViewEntity>> FindAllActiveSector();
        Task<ResultModel> ActiveInActiveSector(SectorIDEntity entity);
        Task<List<CityListBySectorID>> FindCityBySectorID(SectorIDEntity entity);
        Task<List<SectorViewEntity>> SectorShowOnMenu();
        Task<List<SectorViewEntity>> SectorShowOnHome();
        Task<ResultModel> SectorImageUpdate(string? MainImage, string? BannerImage, string? HomeImage, int? ID, int? UpdatedBy);
        Task<List<SectorViewEntity>> FindAllSectorIncrementalSearch(SectorIDEntity entity);
        Task<List<SectorViewEntity>> FindAllSectorTypeWiseSector(SectorIDEntity entity);
    }
}
