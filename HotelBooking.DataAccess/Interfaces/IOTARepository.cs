using HotelBooking.Entity.Common.Entities;
using HotelBooking.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBooking.DataAccess.Interfaces
{
    public interface IOTARepository
    {
        Task<ResultModel> InsertOTA(OTAEntity entity);

        Task<ResultModel> UpdateOTA(OTAEntity entity);
        Task<ResultModel> DeleteOTA(OTAIDEntity entity);

        Task<OTAViewEntity> FindByIDOTA(OTAIDEntity entity);
        Task<List<OTAViewEntity>> FindAllOTA(OTAIDEntity entity);
        Task<List<OTAViewEntity>> FindAllActiveOTA();

        Task<ResultModel> ActiveInActiveOTA(OTAIDEntity entity);

    }
}
