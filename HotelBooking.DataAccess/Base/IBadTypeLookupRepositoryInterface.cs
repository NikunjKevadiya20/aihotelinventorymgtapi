using HotelBooking.Entity.Common.Entities;
using HotelBooking.Entity.Entities;


namespace HotelBooking.DataAccess.Base
{
    public interface IBadTypeLookupRepositoryInterface
    {
        Task<ResultModel> InsertBadType(BadTypeEntity entity, string storedProcedure);
        Task<ResultModel> UpdateBadType(BadTypeEntity entity, string storedProcedure);
        Task<ResultModel> DeleteBadType(BadTypeIDEntity entity, string storedProcedure);
        Task<BadTypeViewEntity> FindByIDBadType(BadTypeIDEntity entity, string storedProcedure);
        Task<List<BadTypeViewEntity>> FindAllBadType(BadTypeIDEntity entity, string storedProcedure);
        Task<List<BadTypeViewEntity>> FindAllActiveBadType(string storedProcedure);

        Task<ResultModel> ActiveInActiveBadType(BadTypeIDEntity entity, string storedProcedure);


    }
}
