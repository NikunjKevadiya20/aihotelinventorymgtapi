using HotelBooking.Entity.Common.Entities;
using HotelBooking.Entity.Entities;


namespace HotelBooking.DataAccess.Base
{
    public interface IBedTypeLookupRepositoryInterface
    {
        Task<ResultModel> InsertBedType(BedTypeEntity entity, string storedProcedure);
        Task<ResultModel> UpdateBedType(BedTypeEntity entity, string storedProcedure);
        Task<ResultModel> DeleteBedType(BedTypeIDEntity entity, string storedProcedure);
        Task<BedTypeViewEntity> FindByIDBedType(BedTypeIDEntity entity, string storedProcedure);
        Task<List<BedTypeViewEntity>> FindAllBedType(BedTypeIDEntity entity, string storedProcedure);
        Task<List<BedTypeViewEntity>> FindAllActiveBedType(string storedProcedure);

        Task<ResultModel> ActiveInActiveBedType(BedTypeIDEntity entity, string storedProcedure);


    }
}
