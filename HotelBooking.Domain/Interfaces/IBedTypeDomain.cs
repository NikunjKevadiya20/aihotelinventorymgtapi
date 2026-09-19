using HotelBooking.Entity.Common.Entities;
using HotelBooking.Entity.Entities;

namespace HotelBooking.Domain.Interfaces
{
    public interface IBedTypeDomain
    {
        Task<ResultModel> InsertBedType(BedTypeEntity entity);

        Task<ResultModel> UpdateBedType(BedTypeEntity entity);
        Task<ResultModel> DeleteBedType(BedTypeIDEntity entity);

        Task<BedTypeViewEntity> FindByIDBedType(BedTypeIDEntity entity);

        Task<List<BedTypeViewEntity>> FindAllBedType(BedTypeIDEntity entity);
        Task<List<BedTypeViewEntity>> FindAllActiveBedType();

        Task<ResultModel> ActiveInActiveBedType(BedTypeIDEntity entity);

    }
}
