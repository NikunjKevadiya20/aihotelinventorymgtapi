using HotelBooking.Entity.Common.Entities;
using HotelBooking.Entity.Entities;

namespace HotelBooking.DataAccess.Base
{
    public interface IItineraryFacilitiesViewRepositoryInterface
    {
        //Insert Added by AI009 on 07-04-23
        Task<ItineraryIDViewEntity> InsertItineraryFacilities(ItineraryFacilitiesEntity entity, string storedProcedure);
        //Update Added by AI009 on 07-04-23
        Task<ResultModel> UpdateItineraryFacilities(ItineraryFacilitiesEntity entity, string storedProcedure);
        //FindAll Added by AI009 on 07-04-23
        Task<List<ItineraryFacilitiesEntity>> FindAllItineraryFacilities(string storedProcedure);
        //FindAllActive Added by AI009 on 07-04-23
        Task<List<ItineraryFacilitiesEntity>> FindAllActiveItineraryFacilities(string storedProcedure);
        //FindByID Added by AI009 on 07-04-23
        Task<ItineraryFacilitiesEntity> FindByIDItineraryFacilities(ItineraryFacilitiesViewEntity entity, string storedProcedure);
        //Delete Added by AI009 on 07-04-23
        Task<ResultModel> DeleteItineraryFacilities(ItineraryFacilitiesViewEntity entity, string storedProcedure);
        //ActiveInActive Added by AI009 on 07-04-23
        Task<ResultModel> ActiveInActiveItineraryFacilities(ItineraryFacilitiesViewEntity entity, string storedProcedure);
        Task<ResultModel> FacilityImageUpdate(string? physicalFileName, int? ID, int? UpdatedBy, string storedProcedure);
    }
}