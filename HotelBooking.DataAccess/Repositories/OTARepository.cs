using HotelBooking.DataAccess.Base;
using HotelBooking.DataAccess.Interfaces;
using HotelBooking.Entity.Common.Entities;
using HotelBooking.Entity.Entities;

namespace HotelBooking.DataAccess.Repositories
{
    public class OTARepository : IOTARepository
    {
        IOTALookupRepositoryInterface repository;

        public OTARepository(IOTALookupRepositoryInterface _repository)
        {
            repository = _repository;
        }

        public async Task<ResultModel> InsertOTA(OTAEntity entity)
        {
            return await repository.InsertOTA(entity, "sp_ManageOTAInsert");
        }
        public async Task<ResultModel> UpdateOTA(OTAEntity entity)
        {
            return await repository.UpdateOTA(entity, "sp_ManageOTAInsert");
        }
        public async Task<ResultModel> DeleteOTA(OTAIDEntity entity)
        {
            return await repository.DeleteOTA(entity, "sp_ManageOTADetails");
        }
        public async Task<OTAViewEntity> FindByIDOTA(OTAIDEntity entity)
        {
            return await repository.FindByIDOTA(entity, "sp_ManageOTADetails");
        }
        public async Task<List<OTAViewEntity>> FindAllOTA(OTAIDEntity entity)
        {
            return await repository.FindAllOTA(entity, "sp_ManageOTAFindAllActive");
        }
        public async Task<List<OTAViewEntity>> FindAllActiveOTA()
        {
            return await repository.FindAllActiveOTA("sp_ManageOTAFindAllActive");
        }
        public async Task<ResultModel> ActiveInActiveOTA(OTAIDEntity entity)
        {
            return await repository.ActiveInActiveOTA(entity, "sp_ManageOTADetails");
        }


    }
}
