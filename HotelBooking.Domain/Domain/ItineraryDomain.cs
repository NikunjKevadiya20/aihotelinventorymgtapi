using HotelBooking.DataAccess.Interfaces;
using HotelBooking.Domain.Interfaces;
using HotelBooking.Entity.Common.Entities;
using HotelBooking.Entity.Entities;

namespace HotelBooking.Domain.Domains
{
    /// <summary>
    /// Added by NikunjK on 01-08-2023
    /// </summary>
    public class ItineraryDomain : IItineraryDomain
    {
        IItineraryRepository repository;
        public ItineraryDomain(IItineraryRepository _repository)
        {
            repository = _repository;
        }

        public async Task<ResultModel> InsertItinerary(ItineraryDataEntity entity)
        {
            return await repository.InsertItinerary(entity);
        }
        public async Task<ResultModel> UpdateItinerary(ItineraryDataEntity entity)
        {
            return await repository.UpdateItinerary(entity);
        }
        public async Task<ResultModel> DeleteItinerary(ItineraryIDEntity entity)
        {
            return await repository.DeleteItinerary(entity);
        }
        public async Task<ItineraryViewEntity> FindByIDItinerary(ItineraryIDEntity entity)
        {
            return await repository.FindByIDItinerary(entity);
        }
        public async Task<List<ItineraryViewEntity>> FindAllItinerary(ItineraryIDEntity entity)
        {
            return await repository.FindAllItinerary(entity);
        }
        public async Task<List<ItineraryViewEntity>> FindAllActiveItinerary()
        {
            return await repository.FindAllActiveItinerary();
        }
        public async Task<ResultModel> ActiveInActiveItinerary(ItineraryIDEntity entity)
        {
            return await repository.ActiveInActiveItinerary(entity);
        }
        public async Task<List<ItineraryViewEntity>> FindByIDItineraryList(ItineraryIDEntity entity)
        {
            return await repository.FindByIDItineraryList(entity);
        }
    }
}
