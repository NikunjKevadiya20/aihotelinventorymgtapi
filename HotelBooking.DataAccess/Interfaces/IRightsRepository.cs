using HotelBooking.Entity.Common.Entities;
using HotelBooking.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBooking.DataAccess.Interfaces
{
    public interface IRightsRepository
    {
        Task<ResultModel> InsertRights(RightsEntity entity);

        Task <ResultModel> UpdateRights (RightsEntity entity);
        Task <ResultModel > DeleteRights(RightsIDEntity entity);

        Task<RightsViewEntity> FindByIDRights(RightsIDEntity entity);
        Task<List<RightsViewEntity>> FindAllRights(RightsIDEntity entity);
        Task<List<RightsViewEntity>> FindAllActiveRights();

        Task<ResultModel> ActiveInActiveRights(RightsIDEntity entity);

    }
}
