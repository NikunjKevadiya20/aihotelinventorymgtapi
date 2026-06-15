using HotelBooking.DataAccess.Base;
using HotelBooking.DataAccess.Interfaces;
using HotelBooking.Entity.Common.Entities;
using HotelBooking.Entity.Entities;

namespace HotelBooking.DataAccess.Repositories
{
    public class ItineraryFacilitiesRepository : IItineraryFacilitiesRepository
    {
        IItineraryFacilitiesViewRepositoryInterface viewrepository;
        public ItineraryFacilitiesRepository(IItineraryFacilitiesViewRepositoryInterface _viewrepository)
        {
            viewrepository = _viewrepository;
        }

        // Insert Added by AI009 on 07-04-23

        public async Task<ItineraryIDViewEntity> InsertItineraryFacilities(ItineraryFacilitiesEntity entity)
        {
            return await viewrepository.InsertItineraryFacilities(entity, "sp_ManageItineraryFacilities");
        }

        // Update Added by AI009 on 07-04-23
        public async Task<ResultModel> UpdateItineraryFacilities(ItineraryFacilitiesEntity entity)
        {
            return await viewrepository.UpdateItineraryFacilities(entity, "sp_ManageItineraryFacilities");
        }

        // FindAll Added by AI009 on 07-04-23
        public async Task<List<ItineraryFacilitiesEntity>> FindAllItineraryFacilities()
        {
            return await viewrepository.FindAllItineraryFacilities("sp_ManageItineraryFacilities");
        }

        // FindAllActive Added by AI009 on 07-04-23
        public async Task<List<ItineraryFacilitiesEntity>> FindAllActiveItineraryFacilities()
        {
            return await viewrepository.FindAllActiveItineraryFacilities("sp_ManageItineraryFacilities");
        }

        // FindByID Added by AI009 on 07-04-23
        public async Task<ItineraryFacilitiesEntity> FindByIDItineraryFacilities(ItineraryFacilitiesViewEntity entity)
        {
            return await viewrepository.FindByIDItineraryFacilities(entity, "sp_ManageItineraryFacilities"); ;
        }

        // Delete Added by AI009 on 07-04-23
        public async Task<ResultModel> DeleteItineraryFacilities(ItineraryFacilitiesViewEntity entity)
        {
            return await viewrepository.DeleteItineraryFacilities(entity, "sp_ManageItineraryFacilities");
        }

        // ActiveInActive Added by AI009 on 07-04-23
        public async Task<ResultModel> ActiveInActiveItineraryFacilities(ItineraryFacilitiesViewEntity entity)
        {
            return await viewrepository.ActiveInActiveItineraryFacilities(entity, "sp_ManageItineraryFacilities");
        }
        public async Task<ResultModel> FacilityImageUpdate(string? physicalFileName, int? ID, int? UpdatedBy)
        {
            return await viewrepository.FacilityImageUpdate(physicalFileName, ID, UpdatedBy, "sp_ManageItineraryFacilities");
        }

    }
}
