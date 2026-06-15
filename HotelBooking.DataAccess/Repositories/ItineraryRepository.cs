using HotelBooking.DataAccess.Base;
using HotelBooking.DataAccess.Interfaces;
using HotelBooking.Entity.Common.Entities;
using HotelBooking.Entity.Entities;

namespace HotelBooking.DataAccess.Repositories
{
    /// <summary>
    /// Added by NikunjK on 01-08-2023
    /// </summary>
    public class ItineraryRepository : IItineraryRepository
    {
        IItineraryLookupRepositoryInterface repository;
        public ItineraryRepository(IItineraryLookupRepositoryInterface _repository)
        {
            repository = _repository;
        }

        public async Task<ResultModel> InsertItinerary(ItineraryDataEntity entity)
        {
            return await repository.InsertItinerary(entity, "sp_ManageItineraryInsert");
        }
        public async Task<ResultModel> UpdateItinerary(ItineraryDataEntity entity)
        {
            return await repository.UpdateItinerary(entity, "sp_ManageItineraryInsert");
        }
        public async Task<ResultModel> DeleteItinerary(ItineraryIDEntity entity)
        {
            return await repository.DeleteItinerary(entity, "sp_ManageItineraryDetails");
        }
        public async Task<ItineraryViewEntity> FindByIDItinerary(ItineraryIDEntity entity)
        {
            return await repository.FindByIDItinerary(entity, "sp_ManageItineraryDetails");
        }
        public async Task<List<ItineraryViewEntity>> FindAllItinerary(ItineraryIDEntity entity)
        {
            return await repository.FindAllItinerary(entity, "sp_ManageItineraryDetails");
        }
        public async Task<List<ItineraryViewEntity>> FindAllActiveItinerary()
        {
            return await repository.FindAllActiveItinerary("sp_ManageItineraryFindAllActive");
        }
        public async Task<ResultModel> ActiveInActiveItinerary(ItineraryIDEntity entity)
        {
            return await repository.ActiveInActiveItinerary(entity, "sp_ManageItineraryDetails");
        }
        public async Task<List<ItineraryViewEntity>> FindByIDItineraryList(ItineraryIDEntity entity)
        {
            return await repository.FindByIDItineraryList(entity, "sp_ManageItineraryDetails");
        }

    }

}
