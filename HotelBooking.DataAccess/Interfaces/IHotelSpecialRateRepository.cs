using HotelBooking.Entity.Common.Entities;
using HotelBooking.Entity.Entities;

namespace HotelBooking.DataAccess.Interfaces
{
    public interface IHotelSpecialRateRepository
    {
        Task<HotelRateResViewEntity> InsertHotelSpecialRate(HotelSpecialRateDataEntity entity);
        Task<HotelRateResViewEntity> UpdateHotelSpecialRate(HotelSpecialRateDataEntity entity);
        Task<ResultModel> DeleteHotelSpecialRate(HotelSpecialRateIDEntity entity);
        Task<HotelSpecialRateViewEntity> FindByIDHotelSpecialRate(HotelSpecialRateIDEntity entity);
        Task<List<HotelSpecialRateViewEntity>> FindHotelIDByHotelSpecialRate(HotelSpecialRateIDEntity entity);
        //Task<List<HotelSpecialRateViewEntity>> FindAllActiveHotelSpecialRate();
        Task<ResultModel> ActiveInActiveHotelSpecialRate(HotelSpecialRateIDEntity entity);
        Task<HotelRateViewEntity> GetHotelSpecialRate(HotelRateDataEntity entity);


    }
}
