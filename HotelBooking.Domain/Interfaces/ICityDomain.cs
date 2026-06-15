
using HotelBooking.Entity.Common.Entities;
using HotelBooking.Entity.Entities;

namespace HotelBooking.Domain.Interfaces
{
    public interface ICityDomain
    {
        Task<ResultModel> InsertCity(CityDataEntity city);

        Task<ResultModel> UpdateCity(CityDataEntity city);

        Task<ResultModel> DeleteCity(CityIDEntity city);

        Task<CityViewEntity> FindByIDCity(CityIDEntity entity);
        Task<List<CityViewEntity>> FindAllCity(CityIDEntity entity);
        Task<List<CityViewEntity>> FindAllCityForDropdown(CityIDEntity entity);
        Task<List<CityViewEntity>> FindAllActiveCity();

        Task<ResultModel> ActiveInActiveCity(CityIDEntity entity);



    }
}
