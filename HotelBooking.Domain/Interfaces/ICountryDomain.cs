using HotelBooking.Entity.Common.Entities;
using HotelBooking.Entity.Entities;

namespace HotelBooking.Domain.Interfaces
{
    /// <summary>
    /// Added by NikunjK on 01-08-2023
    /// </summary>
    public interface ICountryDomain
    {
        Task<ResultModel> InsertCountry(CountryDataEntity entity);
        Task<ResultModel> UpdateCountry(CountryDataEntity entity);
        Task<ResultModel> DeleteCountry(CountryIDEntity entity);
        Task<CountryViewEntity> FindByIDCountry(CountryIDEntity entity);
        Task<List<CountryViewEntity>> FindAllCountry(CountryIDEntity entity);
        Task<List<CountryViewEntity>> FindAllActiveCountry();
        Task<ResultModel> ActiveInActiveCountry(CountryIDEntity entity);

    }
}
