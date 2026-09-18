using HotelBooking.Entity.Common.Entities;
using HotelBooking.Entity.Entities;

namespace HotelBooking.Domain.Interfaces
{
    public interface IOTADomain
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
