using HotelBooking.DataAccess.Interfaces;
using HotelBooking.Domain.Interfaces;
using HotelBooking.Entity.Common.Entities;
using HotelBooking.Entity.Entities;

namespace HotelBooking.Domain.Domain
{
    public class RightsDomain : IRightsDomain
    {
        IRightsRepository repository;
        public RightsDomain(IRightsRepository _repository)
        {
            repository = _repository;
        }

        public async Task<ResultModel> InsertRights(RightsEntity entity)
        {
            return await repository.InsertRights(entity);
        }

        public async Task<ResultModel> UpdateRights(RightsEntity entity)
        {
            return await repository.UpdateRights(entity);
        }

        public async Task<ResultModel> DeleteRights(RightsIDEntity entity)
        {
            return await repository.DeleteRights(entity);
        }
        public async Task<RightsViewEntity> FindByIDRights(RightsIDEntity entity)
        {
            return await repository.FindByIDRights(entity);
        }
        public async Task<List<RightsViewEntity>> FindAllRights(RightsIDEntity entity)
        {
            return await repository.FindAllRights(entity);
        }
        public async Task<List<RightsViewEntity>> FindAllActiveRights()
        {
            return await repository.FindAllActiveRights();
        }

        public async Task<ResultModel> ActiveInActiveRights(RightsIDEntity entity)
        {
            return await repository.ActiveInActiveRights(entity);
        }

    }
}
