using HotelBooking.Entity.Common.Entities;
using HotelBooking.Entity.Entities;

namespace HotelBooking.DataAccess.Base
{
    public interface IHotelSpecialRateLookupRepositoryInterface
    {

        Task<HotelRateResViewEntity> InsertHotelSpecialRate(HotelSpecialRateDataEntity entity, string storedProcedure);
        Task<HotelRateResViewEntity> UpdateHotelSpecialRate(HotelSpecialRateDataEntity entity, string storedProcedure);
        Task<ResultModel> DeleteHotelSpecialRate(HotelSpecialRateIDEntity entity, string storedProcedure);
        Task<HotelSpecialRateViewEntity> FindByIDHotelSpecialRate(HotelSpecialRateIDEntity entity, string storedProcedure);
        Task<List<HotelSpecialRateViewEntity>> FindHotelIDByHotelSpecialRate(HotelSpecialRateIDEntity entity, string storedProcedure);
        //Task<List<HotelSpecialRateViewEntity>> FindAllActiveHotelSpecialRate( string storedProcedure);
        Task<ResultModel> ActiveInActiveHotelSpecialRate(HotelSpecialRateIDEntity entity, string storedProcedure);
        Task<HotelRateViewEntity> GetHotelSpecialRate(HotelRateDataEntity entity, string storedProcedure);
    }
}
