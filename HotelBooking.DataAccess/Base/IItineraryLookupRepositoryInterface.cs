using HotelBooking.Entity.Common.Entities;
using HotelBooking.Entity.Entities;

namespace HotelBooking.DataAccess.Base
{
    /// <summary>
    /// Added by NikunjK on 01-08-2023
    /// </summary>
    public interface IItineraryLookupRepositoryInterface
    {
        Task<ResultModel> InsertItinerary(ItineraryDataEntity entity, string storedProcedure);
        Task<ResultModel> UpdateItinerary(ItineraryDataEntity entity, string storedProcedure);
        Task<ResultModel> DeleteItinerary(ItineraryIDEntity entity, string storedProcedure);
        Task<ItineraryViewEntity> FindByIDItinerary(ItineraryIDEntity entity, string storedProcedure);
        Task<List<ItineraryViewEntity>> FindAllItinerary(ItineraryIDEntity entity, string storedProcedure);
        Task<List<ItineraryViewEntity>> FindAllActiveItinerary( string storedProcedure);
        Task<ResultModel> ActiveInActiveItinerary(ItineraryIDEntity entity, string storedProcedure);
        Task<List<ItineraryViewEntity>> FindByIDItineraryList(ItineraryIDEntity entity, string storedProcedure);

    }
}

