using HotelBooking.Entity.Common.Entities;
using HotelBooking.Entity.Entities;


namespace HotelBooking.DataAccess.Base
{
    public interface IOTALookupRepositoryInterface
    {
        Task<ResultModel> InsertOTA(OTAEntity entity, string storedProcedure);
        Task<ResultModel> UpdateOTA(OTAEntity entity, string storedProcedure);
        Task<ResultModel> DeleteOTA(OTAIDEntity entity, string storedProcedure);
        Task<OTAViewEntity> FindByIDOTA(OTAIDEntity entity, string storedProcedure);
        Task<List<OTAViewEntity>> FindAllOTA(OTAIDEntity entity, string storedProcedure);
        Task<List<OTAViewEntity>> FindAllActiveOTA(string storedProcedure);

        Task<ResultModel> ActiveInActiveOTA(OTAIDEntity entity, string storedProcedure);


    }
}
