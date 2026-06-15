using HotelBooking.DataAccess.Interfaces;
using HotelBooking.Domain.Interfaces;
using HotelBooking.Entity.Common.Entities;
using HotelBooking.Entity.Entities;

namespace HotelBooking.Domain.Domains
{
    /// <summary>
    /// Added by NikunjK on 01-08-2023
    /// </summary>
    public class CountryDomain : ICountryDomain
    {
        ICountryRepository repository;
        public CountryDomain(ICountryRepository _repository)
        {
            repository = _repository;
        }

        public async Task<ResultModel> InsertCountry(CountryDataEntity entity)
        {
            return await repository.InsertCountry(entity);
        }
        public async Task<ResultModel> UpdateCountry(CountryDataEntity entity)
        {
            return await repository.UpdateCountry(entity);
        }
        public async Task<ResultModel> DeleteCountry(CountryIDEntity entity)
        {
            return await repository.DeleteCountry(entity);
        }
        public async Task<CountryViewEntity> FindByIDCountry(CountryIDEntity entity)
        {
            return await repository.FindByIDCountry(entity);
        }
        public async Task<List<CountryViewEntity>> FindAllCountry(CountryIDEntity entity)
        {
            return await repository.FindAllCountry(entity);
        }
        public async Task<List<CountryViewEntity>> FindAllActiveCountry()
        {
            return await repository.FindAllActiveCountry();
        }
        public async Task<ResultModel> ActiveInActiveCountry(CountryIDEntity entity)
        {
            return await repository.ActiveInActiveCountry(entity);
        }
    }
}
