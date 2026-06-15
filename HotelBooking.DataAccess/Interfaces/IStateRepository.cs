using HotelBooking.Entity.Common.Entities;
using HotelBooking.Entity.Entities;

namespace HotelBooking.DataAccess.Interfaces
{
    public interface IStateRepository
    {
        Task<ResultModel> InsertState(StateEntity entity);

        Task<ResultModel> UpdateState(StateEntity entity);
        Task<ResultModel> DeleteState(StateIDEntity entity);

        Task<StateViewEntity> FindByIDState(StateIDEntity entity);
        Task<List<StateViewEntity>> FindAllState(StateIDEntity entity);
        Task<List<StateViewEntity>> FindAllActiveState();

        Task<ResultModel> ActiveInActiveState(StateIDEntity entity);

    }
}
