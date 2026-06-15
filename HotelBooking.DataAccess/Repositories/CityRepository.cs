using HotelBooking.DataAccess.Base;
using HotelBooking.DataAccess.Interfaces;
using HotelBooking.Entity.Common.Entities;
using HotelBooking.Entity.Entities;

namespace HotelBooking.DataAccess.Repositories
{
    public class CityRepository : ICityRepository
    {
        ICityLookupRepositoryInterface repository;

        public CityRepository(ICityLookupRepositoryInterface _repository)
        {
            repository = _repository;
        }
        public async Task<ResultModel> InsertCity(CityDataEntity entity)
        {
            return await repository.InsertCity(entity, "sp_ManageCity");
        }

        public async Task<ResultModel> UpdateCity(CityDataEntity entity)
        {
            return await repository.UpdateCity(entity, "sp_ManageCity");
        }
        public async Task<ResultModel> DeleteCity(CityIDEntity entity)
        {
            return await repository.DeleteCity(entity, "sp_ManageCity");
        }
        public async Task<CityViewEntity> FindByIDCity(CityIDEntity entity)
        {
            return await repository.FindByIDCity(entity, "sp_ManageCity");
        }
        public async Task<List<CityViewEntity>> FindAllCity(CityIDEntity entity)
        {
            return await repository.FindAllCity(entity, "sp_ManageCity");
        }
        public async Task<List<CityViewEntity>> FindAllCityForDropdown(CityIDEntity entity)
        {
            return await repository.FindAllCityForDropdown(entity, "sp_ManageCity");
        }
        public async Task<List<CityViewEntity>> FindAllActiveCity()
        {
            return await repository.FindAllActiveCity("sp_ManageCity");
        }
        public async Task<ResultModel> ActiveInActiveCity(CityIDEntity entity)
        {
            return await repository.ActiveInActiveCity(entity, "sp_ManageCity");
        }

    }
}
