using HotelBooking.DataAccess.Interfaces;
using HotelBooking.Domain.Interfaces;
using HotelBooking.Entity.Common.Entities;
using HotelBooking.Entity.Entities;

namespace HotelBooking.Domain.Domain
{
    public class HotelSpecialRateDomain : IHotelSpecialRateDomain
    {

        IHotelSpecialRateRepository repository;
        public HotelSpecialRateDomain(IHotelSpecialRateRepository _repository)
        {
            repository = _repository;
        }

        public async Task<HotelRateResViewEntity> InsertHotelSpecialRate(HotelSpecialRateDataEntity entity)
        {
            return await repository.InsertHotelSpecialRate(entity);
        }

        public async Task<HotelRateResViewEntity> UpdateHotelSpecialRate(HotelSpecialRateDataEntity entity)
        {
            return await repository.UpdateHotelSpecialRate(entity);
        }

        public async Task<ResultModel> DeleteHotelSpecialRate(HotelSpecialRateIDEntity entity)
        {
            return await repository.DeleteHotelSpecialRate(entity);
        }

        public async Task<HotelSpecialRateViewEntity> FindByIDHotelSpecialRate(HotelSpecialRateIDEntity entity)
        {
            return await repository.FindByIDHotelSpecialRate(entity);
        }

        public async Task<List<HotelSpecialRateViewEntity>> FindHotelIDByHotelSpecialRate(HotelSpecialRateIDEntity entity)
        {
            return await repository.FindHotelIDByHotelSpecialRate(entity);
        }
        //public async Task<List<HotelSpecialRateViewEntity>> FindAllActiveHotelSpecialRate()
        //{
        //    return await repository.FindAllActiveHotelSpecialRate();
        //}
        public async Task<ResultModel> ActiveInActiveHotelSpecialRate(HotelSpecialRateIDEntity entity)
        {
            return await repository.ActiveInActiveHotelSpecialRate(entity);
        }

        public async Task<HotelRateViewEntity> GetHotelSpecialRate(HotelRateDataEntity entity)
        {
            return await repository.GetHotelSpecialRate(entity);
        }
    }
}
