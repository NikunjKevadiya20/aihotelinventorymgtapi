using HotelBooking.Entity.Common.Entities;
using HotelBooking.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBooking.DataAccess.Interfaces
{
    public interface ISuitableforRepository
    {
        Task<ResultModel> InsertSuitablefor(SuitableforEntity entity);

        Task<ResultModel> UpdateSuitablefor(SuitableforEntity entity);
        Task<ResultModel> DeleteSuitablefor(SuitableforIDEntity entity);

        Task<SuitableforViewEntity> FindByIDSuitablefor(SuitableforIDEntity entity);
        Task<List<SuitableforViewEntity>> FindAllSuitablefor(SuitableforIDEntity entity);
        Task<List<SuitableforViewEntity>> FindAllActiveSuitablefor();

        Task<ResultModel> ActiveInActiveSuitablefor(SuitableforIDEntity entity);

    }
}
