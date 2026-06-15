
using HotelBooking.Entity.Common.Entities;
using HotelBooking.Entity.Entities;

namespace HotelBooking.Domain.Interfaces
{
    public interface IHotelSpecialRateDomain
    {
        Task<HotelRateResViewEntity> InsertHotelSpecialRate(HotelSpecialRateDataEntity city);

        Task<HotelRateResViewEntity> UpdateHotelSpecialRate(HotelSpecialRateDataEntity city);

        Task<ResultModel> DeleteHotelSpecialRate(HotelSpecialRateIDEntity city);

        Task<HotelSpecialRateViewEntity> FindByIDHotelSpecialRate(HotelSpecialRateIDEntity entity);
        Task<List<HotelSpecialRateViewEntity>> FindHotelIDByHotelSpecialRate(HotelSpecialRateIDEntity entity);
        //Task<List<HotelSpecialRateViewEntity>> FindAllActiveHotelSpecialRate();
        Task<ResultModel> ActiveInActiveHotelSpecialRate(HotelSpecialRateIDEntity entity);
        Task<HotelRateViewEntity> GetHotelSpecialRate(HotelRateDataEntity entity);

    }
}
