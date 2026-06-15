using HotelBooking.Entity.Common.Entities;
using HotelBooking.Entity.Entities;

namespace HotelBooking.Domain.Interfaces
{
    public interface IItineraryFacilitiesDomain
    {
        //Insert Added by AI009 on 07-04-23
        Task<ItineraryIDViewEntity> InsertItineraryFacilities(ItineraryFacilitiesEntity entity);
        //Update Added by AI009 on 07-04-23
        Task<ResultModel> UpdateItineraryFacilities(ItineraryFacilitiesEntity entity);
        //FindAll Added by AI009 on 07-04-23
        Task<List<ItineraryFacilitiesEntity>> FindAllItineraryFacilities();
        //FindAllActive Added by AI009 on 07-04-23
        Task<List<ItineraryFacilitiesEntity>> FindAllActiveItineraryFacilities();
        //FindByID Added by AI009 on 07-04-23
        Task<ItineraryFacilitiesEntity> FindByIDItineraryFacilities(ItineraryFacilitiesViewEntity entity);
        //Delete Added by AI009 on 07-04-23
        Task<ResultModel> DeleteItineraryFacilities(ItineraryFacilitiesViewEntity entity);
        //ActiveInActive Added by AI009 on 07-04-23
        Task<ResultModel> ActiveInActiveItineraryFacilities(ItineraryFacilitiesViewEntity entity);
        Task<ResultModel> FacilityImageUpdate(string? physicalFileName, int? ID, int? UpdatedBy);
    }
}

