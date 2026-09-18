using HotelBooking.DataAccess.Interfaces;
using HotelBooking.Domain.Interfaces;
using HotelBooking.Entity.Common.Entities;
using HotelBooking.Entity.Entities;

namespace HotelBooking.Domain.Domain
{
    public class OTADomain : IOTADomain
    {
        IOTARepository repository;
        public OTADomain(IOTARepository _repository)
        {
            repository = _repository;
        }

        public async Task<ResultModel> InsertOTA(OTAEntity entity)
        {
            return await repository.InsertOTA(entity);
        }

        public async Task<ResultModel> UpdateOTA(OTAEntity entity)
        {
            return await repository.UpdateOTA(entity);
        }

        public async Task<ResultModel> DeleteOTA(OTAIDEntity entity)
        {
            return await repository.DeleteOTA(entity);
        }
        public async Task<OTAViewEntity> FindByIDOTA(OTAIDEntity entity)
        {
            return await repository.FindByIDOTA(entity);
        }
        public async Task<List<OTAViewEntity>> FindAllOTA(OTAIDEntity entity)
        {
            return await repository.FindAllOTA(entity);
        }
        public async Task<List<OTAViewEntity>> FindAllActiveOTA()
        {
            return await repository.FindAllActiveOTA();
        }

        public async Task<ResultModel> ActiveInActiveOTA(OTAIDEntity entity)
        {
            return await repository.ActiveInActiveOTA(entity);
        }

    }
}
