using HotelBooking.Entity.Common.Entities;
using HotelBooking.Entity.Entities;

namespace HotelBooking.DataAccess.Interfaces
{
    /// <summary>
    /// Added by NikunjK on 01-08-2023
    /// </summary>
  
    public interface IItineraryRepository
    {
        Task<ResultModel> InsertItinerary(ItineraryDataEntity entity);
        Task<ResultModel> UpdateItinerary(ItineraryDataEntity entity);
        Task<ResultModel> DeleteItinerary(ItineraryIDEntity entity);
        Task<ItineraryViewEntity> FindByIDItinerary(ItineraryIDEntity entity);
        Task<List<ItineraryViewEntity>> FindAllItinerary(ItineraryIDEntity entity);
        Task<List<ItineraryViewEntity>> FindAllActiveItinerary();
        Task<ResultModel> ActiveInActiveItinerary(ItineraryIDEntity entity);
        Task<List<ItineraryViewEntity>> FindByIDItineraryList(ItineraryIDEntity entity);

    }
}
