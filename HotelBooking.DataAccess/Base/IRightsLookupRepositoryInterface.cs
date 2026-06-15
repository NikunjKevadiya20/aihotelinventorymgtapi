using HotelBooking.Entity.Common.Entities;
using HotelBooking.Entity.Entities;


namespace HotelBooking.DataAccess.Base
{
    public interface IRightsLookupRepositoryInterface
    {
        Task<ResultModel> InsertRights(RightsEntity entity, string storedProcedure); 
        Task<ResultModel> UpdateRights(RightsEntity entity, string storedProcedure);
        Task<ResultModel> DeleteRights(RightsIDEntity entity,string storedProcedure);  
        Task<RightsViewEntity> FindByIDRights(RightsIDEntity entity,string storedProcedure); 
        Task<List<RightsViewEntity>> FindAllRights(RightsIDEntity entity, string storedProcedure);
        Task<List<RightsViewEntity>> FindAllActiveRights(string storedProcedure);

        Task<ResultModel> ActiveInActiveRights(RightsIDEntity entity, string storedProcedure);


    }
}
