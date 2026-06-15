using HotelBooking.DataAccess.Base;
using HotelBooking.DataAccess.Interfaces;
using HotelBooking.Entity.Common.Entities;
using HotelBooking.Entity.Entities;

namespace HotelBooking.DataAccess.Repositories
{
    public class HotelSpecialRateRepository : IHotelSpecialRateRepository
    {
        IHotelSpecialRateLookupRepositoryInterface repository;

        public HotelSpecialRateRepository(IHotelSpecialRateLookupRepositoryInterface _repository)
        {
            repository = _repository;
        }
        public async Task<HotelRateResViewEntity> InsertHotelSpecialRate(HotelSpecialRateDataEntity entity)
        {
            return await repository.InsertHotelSpecialRate(entity, "sp_ManageHotelSpecialRatesInsert");
        }

        public async Task<HotelRateResViewEntity> UpdateHotelSpecialRate(HotelSpecialRateDataEntity entity)
        {
            return await repository.UpdateHotelSpecialRate(entity, "sp_ManageHotelSpecialRatesInsert");
        }
        public async Task<ResultModel> DeleteHotelSpecialRate(HotelSpecialRateIDEntity entity)
        {
            return await repository.DeleteHotelSpecialRate(entity, "sp_ManageHotelSpecialRateFindByID");
        }
        public async Task<HotelSpecialRateViewEntity> FindByIDHotelSpecialRate(HotelSpecialRateIDEntity entity)
        {
            return await repository.FindByIDHotelSpecialRate(entity, "sp_ManageHotelSpecialRateFindByID");
        }
        public async Task<List<HotelSpecialRateViewEntity>> FindHotelIDByHotelSpecialRate(HotelSpecialRateIDEntity entity)
        {
            return await repository.FindHotelIDByHotelSpecialRate(entity, "sp_ManageHotelSpecialRateFindByID");
        }
        //public async Task<List<HotelSpecialRateViewEntity>> FindAllActiveHotelSpecialRate()
        //{
        //    return await repository.FindAllActiveHotelSpecialRate( "sp_ManageHotelSpecialRate");
        //}
        public async Task<ResultModel> ActiveInActiveHotelSpecialRate(HotelSpecialRateIDEntity entity)
        {
            return await repository.ActiveInActiveHotelSpecialRate(entity, "sp_ManageHotelSpecialRateFindByID");
        }
        public async Task<HotelRateViewEntity> GetHotelSpecialRate(HotelRateDataEntity entity)
        {
            return await repository.GetHotelSpecialRate(entity, "sp_ManageHotelSpecialRateFindByID");
        }
    }
}
