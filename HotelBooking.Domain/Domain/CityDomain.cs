using HotelBooking.DataAccess.Interfaces;
using HotelBooking.Domain.Interfaces;
using HotelBooking.Entity.Common.Entities;
using HotelBooking.Entity.Entities;

namespace HotelBooking.Domain.Domain
{
    public class CityDomain : ICityDomain
    {

        ICityRepository repository;
        public CityDomain(ICityRepository _repository)
        {
            repository = _repository;
        }

        public async Task<ResultModel> InsertCity(CityDataEntity entity)
        {
            return await repository.InsertCity(entity);
        }

        public async Task<ResultModel> UpdateCity(CityDataEntity entity)
        {
            return await repository.UpdateCity(entity);
        }

        public async Task<ResultModel> DeleteCity(CityIDEntity entity)
        {
            return await repository.DeleteCity(entity);
        }

        public async Task<CityViewEntity> FindByIDCity(CityIDEntity entity)
        {
            return await repository.FindByIDCity(entity);
        }

        public async Task<List<CityViewEntity>> FindAllCity(CityIDEntity entity)
        {
            return await repository.FindAllCity(entity);
        }
        public async Task<List<CityViewEntity>> FindAllCityForDropdown(CityIDEntity entity)
        {
            return await repository.FindAllCityForDropdown(entity);
        }
        public async Task<List<CityViewEntity>> FindAllActiveCity()
        {
            return await repository.FindAllActiveCity();
        }
        public async Task<ResultModel> ActiveInActiveCity(CityIDEntity entity)
        {
            return await repository.ActiveInActiveCity(entity);
        }

    }
}
