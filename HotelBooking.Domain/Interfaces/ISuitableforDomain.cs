using HotelBooking.Entity.Common.Entities;
using HotelBooking.Entity.Entities;

namespace HotelBooking.Domain.Interfaces
{
    public interface ISuitableforDomain
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
