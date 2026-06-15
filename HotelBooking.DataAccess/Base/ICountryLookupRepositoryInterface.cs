using HotelBooking.Entity.Common.Entities;
using HotelBooking.Entity.Entities;

namespace HotelBooking.DataAccess.Base
{
    /// <summary>
    /// Added by NikunjK on 01-08-2023
    /// </summary>
    public interface ICountryLookupRepositoryInterface
    {
        Task<ResultModel> InsertCountry(CountryDataEntity entity, string storedProcedure);
        Task<ResultModel> UpdateCountry(CountryDataEntity entity, string storedProcedure);
        Task<ResultModel> DeleteCountry(CountryIDEntity entity, string storedProcedure);
        Task<CountryViewEntity> FindByIDCountry(CountryIDEntity entity, string storedProcedure);
        Task<List<CountryViewEntity>> FindAllCountry(CountryIDEntity entity, string storedProcedure);
        Task<List<CountryViewEntity>> FindAllActiveCountry(string storedProcedure);
        Task<ResultModel> ActiveInActiveCountry(CountryIDEntity entity, string storedProcedure);
    }
}

