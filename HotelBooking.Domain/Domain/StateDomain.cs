using HotelBooking.DataAccess.Interfaces;
using HotelBooking.Domain.Interfaces;
using HotelBooking.Entity.Common.Entities;
using HotelBooking.Entity.Entities;

namespace HotelBooking.Domain.Domain
{
    public class StateDomain : IStateDomain
    {
        IStateRepository repository;
        public StateDomain(IStateRepository _repository)
        {
            repository = _repository;
        }

        public async Task<ResultModel> InsertState(StateEntity entity)
        {
            return await repository.InsertState(entity);
        }

        public async Task<ResultModel> UpdateState(StateEntity entity)
        {
            return await repository.UpdateState(entity);
        }

        public async Task<ResultModel> DeleteState(StateIDEntity entity)
        {
            return await repository.DeleteState(entity);
        }
        public async Task<StateViewEntity> FindByIDState(StateIDEntity entity)
        {
            return await repository.FindByIDState(entity);
        }
        public async Task<List<StateViewEntity>> FindAllState(StateIDEntity entity)
        {
            return await repository.FindAllState(entity);
        }
        public async Task<List<StateViewEntity>> FindAllActiveState()
        {
            return await repository.FindAllActiveState();
        }

        public async Task<ResultModel> ActiveInActiveState(StateIDEntity entity)
        {
            return await repository.ActiveInActiveState(entity);
        }

    }
}
