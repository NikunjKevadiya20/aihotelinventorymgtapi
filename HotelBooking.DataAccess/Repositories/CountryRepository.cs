using HotelBooking.DataAccess.Base;
using HotelBooking.DataAccess.Interfaces;
using HotelBooking.Entity.Common.Entities;
using HotelBooking.Entity.Entities;

namespace HotelBooking.DataAccess.Repositories
{
    /// <summary>
    /// Added by NikunjK on 01-08-2023
    /// </summary>
    public class CountryRepository : ICountryRepository
    {
        ICountryLookupRepositoryInterface repository;
        public CountryRepository(ICountryLookupRepositoryInterface _repository)
        {
            repository = _repository;
        }

        public async Task<ResultModel> InsertCountry(CountryDataEntity entity)
        {
            return await repository.InsertCountry(entity, "sp_ManageCountry");
        }
        public async Task<ResultModel> UpdateCountry(CountryDataEntity entity)
        {
            return await repository.UpdateCountry(entity, "sp_ManageCountry");
        }
        public async Task<ResultModel> DeleteCountry(CountryIDEntity entity)
        {
            return await repository.DeleteCountry(entity, "sp_ManageCountry");
        }
        public async Task<CountryViewEntity> FindByIDCountry(CountryIDEntity entity)
        {
            return await repository.FindByIDCountry(entity, "sp_ManageCountry");
        }
        public async Task<List<CountryViewEntity>> FindAllCountry(CountryIDEntity entity)
        {
            return await repository.FindAllCountry(entity, "sp_ManageCountry");
        }
        public async Task<List<CountryViewEntity>> FindAllActiveCountry()
        {
            return await repository.FindAllActiveCountry("sp_ManageCountry");
        }
        public async Task<ResultModel> ActiveInActiveCountry(CountryIDEntity entity)
        {
            return await repository.ActiveInActiveCountry(entity, "sp_ManageCountry");
        }
    }

}
