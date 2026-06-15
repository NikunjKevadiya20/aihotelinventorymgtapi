using HotelBooking.DataAccess.Interfaces;
using HotelBooking.Domain.Interfaces;
using HotelBooking.Entity.Common.Entities;
using HotelBooking.Entity.Entities;

namespace HotelBooking.Domain.Domains
{
    public class ItineraryFacilitiesDomain : IItineraryFacilitiesDomain
    {
        IItineraryFacilitiesRepository repository;
        public ItineraryFacilitiesDomain(IItineraryFacilitiesRepository _repository)
        {
            repository = _repository;
        }


        public async Task<ItineraryIDViewEntity> InsertItineraryFacilities(ItineraryFacilitiesEntity entity)
        {

            return await repository.InsertItineraryFacilities(entity);

        }

        #region // Update Added by AI009 on 07-04-23
        public async Task<ResultModel> UpdateItineraryFacilities(ItineraryFacilitiesEntity entity)
        {

            return await repository.UpdateItineraryFacilities(entity);


        }
        #endregion

        #region // FindAll Added by AI009 on 07-04-23
        public async Task<List<ItineraryFacilitiesEntity>> FindAllItineraryFacilities()
        {
            return await repository.FindAllItineraryFacilities();
        }
        #endregion

        #region // FindAllActive Added by AI009 on 07-04-23
        public async Task<List<ItineraryFacilitiesEntity>> FindAllActiveItineraryFacilities()
        {
            return await repository.FindAllActiveItineraryFacilities();
        }
        #endregion

        #region // FindByID Added by AI009 on 07-04-23
        public async Task<ItineraryFacilitiesEntity> FindByIDItineraryFacilities(ItineraryFacilitiesViewEntity entity)
        {
            return await repository.FindByIDItineraryFacilities(entity);
        }
        #endregion

        #region // Delete Added by AI009 on 07-04-23
        public async Task<ResultModel> DeleteItineraryFacilities(ItineraryFacilitiesViewEntity entity)
        {
            return await repository.DeleteItineraryFacilities(entity);
        }
        #endregion

        #region // Active-InActive Added by AI009 on 07-04-23
        public async Task<ResultModel> ActiveInActiveItineraryFacilities(ItineraryFacilitiesViewEntity entity)
        {
            return await repository.ActiveInActiveItineraryFacilities(entity);
        }
        #endregion

        public async Task<ResultModel> FacilityImageUpdate(string? physicalFileName, int? ID, int? UpdatedBy)
        {
            return await repository.FacilityImageUpdate(physicalFileName, ID, UpdatedBy);
        }

    }
}
