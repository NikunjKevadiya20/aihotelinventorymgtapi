using HotelBooking.Entity.Common.Entities;
using HotelBooking.Entity.Entities;


namespace HotelBooking.DataAccess.Base
{
    public interface ISuitableforLookupRepositoryInterface
    {
        Task<ResultModel> InsertSuitablefor(SuitableforEntity entity, string storedProcedure);
        Task<ResultModel> UpdateSuitablefor(SuitableforEntity entity, string storedProcedure);
        Task<ResultModel> DeleteSuitablefor(SuitableforIDEntity entity, string storedProcedure);
        Task<SuitableforViewEntity> FindByIDSuitablefor(SuitableforIDEntity entity, string storedProcedure);
        Task<List<SuitableforViewEntity>> FindAllSuitablefor(SuitableforIDEntity entity, string storedProcedure);
        Task<List<SuitableforViewEntity>> FindAllActiveSuitablefor(string storedProcedure);

        Task<ResultModel> ActiveInActiveSuitablefor(SuitableforIDEntity entity, string storedProcedure);


    }
}
