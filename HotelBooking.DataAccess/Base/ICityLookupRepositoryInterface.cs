using HotelBooking.Entity.Common.Entities;
using HotelBooking.Entity.Entities;

namespace HotelBooking.DataAccess.Base
{
    public interface ICityLookupRepositoryInterface
    {

        Task<ResultModel> InsertCity(CityDataEntity entity, string storedProcedure);
        Task<ResultModel> UpdateCity(CityDataEntity entity, string storedProcedure);
        Task<ResultModel> DeleteCity(CityIDEntity entity, string storedProcedure);
        Task<CityViewEntity> FindByIDCity(CityIDEntity entity, string storedProcedure);
        Task<List<CityViewEntity>> FindAllCity(CityIDEntity entity, string storedProcedure);
        Task<List<CityViewEntity>> FindAllCityForDropdown(CityIDEntity entity, string storedProcedure);
        Task<List<CityViewEntity>> FindAllActiveCity(string storedProcedure);
        Task<ResultModel> ActiveInActiveCity(CityIDEntity entity, string storedProcedure);
    }
}
