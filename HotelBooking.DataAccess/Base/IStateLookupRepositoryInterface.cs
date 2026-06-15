using HotelBooking.Entity.Common.Entities;
using HotelBooking.Entity.Entities;


namespace HotelBooking.DataAccess.Base
{
    public interface IStateLookupRepositoryInterface
    {
        Task<ResultModel> InsertState(StateEntity entity, string storedProcedure);

        Task<ResultModel> UpdateState(StateEntity entity, string storedProcedure);
        Task<ResultModel> DeleteState(StateIDEntity entity, string storedProcedure);
        Task<StateViewEntity> FindByIDState(StateIDEntity entity, string storedProcedure);

        Task<List<StateViewEntity>> FindAllState(StateIDEntity entity, string storedProcedure);
        Task<List<StateViewEntity>> FindAllActiveState(string storedProcedure);

        Task<ResultModel> ActiveInActiveState(StateIDEntity entity, string storedProcedure);


    }
}
