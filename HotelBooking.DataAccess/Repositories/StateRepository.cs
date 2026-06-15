using HotelBooking.DataAccess.Base;
using HotelBooking.DataAccess.Interfaces;
using HotelBooking.Entity.Common.Entities;
using HotelBooking.Entity.Entities;

namespace HotelBooking.DataAccess.Repositories
{
    public class StateRepository : IStateRepository
    {
        IStateLookupRepositoryInterface repository;

        public StateRepository(IStateLookupRepositoryInterface _repository)
        {
            repository = _repository;
        }

        public async Task<ResultModel> InsertState(StateEntity entity)
        {
            return await repository.InsertState(entity, "sp_ManageState");
        }
        public async Task<ResultModel> UpdateState(StateEntity entity)
        {
            return await repository.UpdateState(entity, "sp_ManageState");
        }
        public async Task<ResultModel> DeleteState(StateIDEntity entity)
        {
            return await repository.DeleteState(entity, "sp_ManageState");
        }
        public async Task<StateViewEntity> FindByIDState(StateIDEntity entity)
        {
            return await repository.FindByIDState(entity, "sp_ManageState");
        }

        public async Task<List<StateViewEntity>> FindAllState(StateIDEntity entity)
        {
            return await repository.FindAllState(entity, "sp_ManageState");
        }
        public async Task<List<StateViewEntity>> FindAllActiveState()
        {
            return await repository.FindAllActiveState("sp_ManageState");
        }
        public async Task<ResultModel> ActiveInActiveState(StateIDEntity entity)
        {
            return await repository.ActiveInActiveState(entity, "sp_ManageState");
        }


    }
}
