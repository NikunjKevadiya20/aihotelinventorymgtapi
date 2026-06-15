using HotelBooking.Entity.Common.Entities;
using HotelBooking.Entity.Entities;

namespace HotelBooking.DataAccess.Interfaces
{
    public interface ICityRepository
    {
        Task<ResultModel> InsertCity(CityDataEntity entity);
        Task<ResultModel> UpdateCity(CityDataEntity entity);
        Task<ResultModel> DeleteCity(CityIDEntity entity);
        Task<CityViewEntity> FindByIDCity(CityIDEntity entity);
        Task<List<CityViewEntity>> FindAllCity(CityIDEntity entity);
        Task<List<CityViewEntity>> FindAllCityForDropdown(CityIDEntity entity);
        Task<List<CityViewEntity>> FindAllActiveCity();
        Task<ResultModel> ActiveInActiveCity(CityIDEntity entity);

    }
}
