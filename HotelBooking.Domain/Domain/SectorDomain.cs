using HotelBooking.DataAccess.Interfaces;
using HotelBooking.Domain.Interfaces;
using HotelBooking.Entity.Common.Entities;
using HotelBooking.Entity.Entities;

namespace HotelBooking.Domain.Domains
{
    /// <summary>
    /// Added by NikunjK on 01-08-2023
    /// </summary>
    public class SectorDomain : ISectorDomain
    {
        ISectorRepository repository;
        public SectorDomain(ISectorRepository _repository)
        {
            repository = _repository;
        }

        public async Task<SectorResultModel> InsertSector(SectorDataEntity entity)
        {
            return await repository.InsertSector(entity);
        }
        public async Task<ResultModel> UpdateSector(SectorDataEntity entity)
        {
            return await repository.UpdateSector(entity);
        }
        public async Task<ResultModel> DeleteSector(SectorIDEntity entity)
        {
            return await repository.DeleteSector(entity);
        }
        public async Task<SectorViewEntity> FindByIDSector(SectorIDEntity entity)
        {
            return await repository.FindByIDSector(entity);
        }
        public async Task<List<SectorViewEntity>> FindAllSector(SectorIDEntity entity)
        {
            return await repository.FindAllSector(entity);
        }
        public async Task<List<SectorViewEntity>> FindAllActiveSector()
        {
            return await repository.FindAllActiveSector();
        }
        public async Task<ResultModel> ActiveInActiveSector(SectorIDEntity entity)
        {
            return await repository.ActiveInActiveSector(entity);
        }
        public async Task<List<CityListBySectorID>> FindCityBySectorID(SectorIDEntity entity)
        {
            return await repository.FindCityBySectorID(entity);
        }
        public async Task<List<SectorViewEntity>> SectorShowOnMenu()
        {
            return await repository.SectorShowOnMenu();
        }
        public async Task<List<SectorViewEntity>> SectorShowOnHome()
        {
            return await repository.SectorShowOnHome();
        }
        public async Task<ResultModel> SectorImageUpdate(string? MainImage, string? BannerImage, string? HomeImage, int? ID, int? UpdatedBy)
        {
            return await repository.SectorImageUpdate(MainImage, BannerImage, HomeImage, ID, UpdatedBy);
        }
        public async Task<List<SectorViewEntity>> FindAllSectorIncrementalSearch(SectorIDEntity entity)
        {
            return await repository.FindAllSectorIncrementalSearch(entity);
        }
        public async Task<List<SectorViewEntity>> FindAllSectorTypeWiseSector(SectorIDEntity entity)
        {
            return await repository.FindAllSectorTypeWiseSector(entity);
        }
    }
}
