using HotelBooking.Entity.Common.Entities;
using HotelBooking.Entity.Entities;

namespace HotelBooking.Domain.Interfaces
{
    public interface IRightsDomain
    {
        Task<ResultModel> InsertRights(RightsEntity entity);

        Task<ResultModel> UpdateRights(RightsEntity entity);
        Task <ResultModel> DeleteRights(RightsIDEntity entity);

        Task <RightsViewEntity> FindByIDRights (RightsIDEntity entity);

        Task<List<RightsViewEntity>> FindAllRights(RightsIDEntity entity);
        Task<List<RightsViewEntity>> FindAllActiveRights();

        Task <ResultModel> ActiveInActiveRights (RightsIDEntity entity);
        
    }
}
