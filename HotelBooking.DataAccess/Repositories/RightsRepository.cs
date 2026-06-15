using HotelBooking.DataAccess.Base;
using HotelBooking.DataAccess.Interfaces;
using HotelBooking.Entity.Common.Entities;
using HotelBooking.Entity.Entities;

namespace HotelBooking.DataAccess.Repositories
{
    public class RightsRepository : IRightsRepository
    {
        IRightsLookupRepositoryInterface repository;

        public RightsRepository (IRightsLookupRepositoryInterface _repository)
        {
            repository = _repository;
        }

        public async Task<ResultModel> InsertRights (RightsEntity entity)
        {
            return await repository.InsertRights(entity, "sp_ManageRightsInsert");
        }
        public async Task<ResultModel> UpdateRights (RightsEntity entity)
        {
            return await repository.UpdateRights(entity, "sp_ManageRightsInsert");
        }
        public async Task<ResultModel> DeleteRights(RightsIDEntity entity)
        {
            return await repository.DeleteRights(entity, "sp_ManageRightsDetails");
        }
        public async Task<RightsViewEntity> FindByIDRights(RightsIDEntity entity)
        {
            return await repository.FindByIDRights(entity, "sp_ManageRightsDetails");
        }

        public async Task<List<RightsViewEntity>> FindAllRights(RightsIDEntity entity)
        {
            return await repository.FindAllRights(entity, "sp_ManageRightsDetails");
        }
        public async Task<List<RightsViewEntity>> FindAllActiveRights()
        {
            return await repository.FindAllActiveRights("sp_ManageRightsFindAllActive");
        }
        public async Task<ResultModel> ActiveInActiveRights(RightsIDEntity entity)
        {
            return await repository.ActiveInActiveRights(entity, "sp_ManageRightsDetails");
        }


    }
}
