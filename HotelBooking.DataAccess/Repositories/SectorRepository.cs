using HotelBooking.DataAccess.Base;
using HotelBooking.DataAccess.Interfaces;
using HotelBooking.Entity.Common.Entities;
using HotelBooking.Entity.Entities;

namespace HotelBooking.DataAccess.Repositories
{
    /// <summary>
    /// Added by NikunjK on 01-08-2023
    /// </summary>
    public class SectorRepository : ISectorRepository
    {
        ISectorLookupRepositoryInterface repository;
        public SectorRepository(ISectorLookupRepositoryInterface _repository)
        {
            repository = _repository;
        }

        public async Task<SectorResultModel> InsertSector(SectorDataEntity entity)
        {
            return await repository.InsertSector(entity, "sp_ManageSector");
        }
        public async Task<ResultModel> UpdateSector(SectorDataEntity entity)
        {
            return await repository.UpdateSector(entity, "sp_ManageSector");
        }
        public async Task<ResultModel> DeleteSector(SectorIDEntity entity)
        {
            return await repository.DeleteSector(entity, "sp_ManageSector");
        }
        public async Task<SectorViewEntity> FindByIDSector(SectorIDEntity entity)
        {
            return await repository.FindByIDSector(entity, "sp_ManageSector");
        }
        public async Task<List<SectorViewEntity>> FindAllSector(SectorIDEntity entity)
        {
            return await repository.FindAllSector(entity, "sp_ManageSector");
        }
        public async Task<List<SectorViewEntity>> FindAllActiveSector()
        {
            return await repository.FindAllActiveSector("sp_ManageSector");
        }
        public async Task<ResultModel> ActiveInActiveSector(SectorIDEntity entity)
        {
            return await repository.ActiveInActiveSector(entity, "sp_ManageSector");
        }
        public async Task<List<CityListBySectorID>> FindCityBySectorID(SectorIDEntity entity)
        {
            return await repository.FindCityBySectorID(entity, "sp_ManageSector");
        }
        public async Task<List<SectorViewEntity>> SectorShowOnMenu()
        {
            return await repository.SectorShowOnMenu("sp_ManageSector");
        }
        public async Task<List<SectorViewEntity>> SectorShowOnHome()
        {
            return await repository.SectorShowOnHome("sp_ManageSector");
        }
        public async Task<ResultModel> SectorImageUpdate(string? MainImage, string? BannerImage, string? HomeImage, int? ID, int? UpdatedBy)
        {
            return await repository.SectorImageUpdate(MainImage, BannerImage, HomeImage, ID, UpdatedBy, "sp_ManageSector");
        }
        public async Task<List<SectorViewEntity>> FindAllSectorIncrementalSearch(SectorIDEntity entity)
        {
            return await repository.FindAllSectorIncrementalSearch(entity, "sp_ManageSectorIncrementalSearch");
        }
        public async Task<List<SectorViewEntity>> FindAllSectorTypeWiseSector(SectorIDEntity entity)
        {
            return await repository.FindAllSectorTypeWiseSector(entity, "Sp_ManageSectorTypeWiseSectorData");
        }
    }

}
