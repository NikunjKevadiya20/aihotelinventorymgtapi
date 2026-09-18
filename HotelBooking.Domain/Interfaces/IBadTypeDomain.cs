using HotelBooking.Entity.Common.Entities;
using HotelBooking.Entity.Entities;

namespace HotelBooking.Domain.Interfaces
{
    public interface IBadTypeDomain
    {
        Task<ResultModel> InsertBadType(BadTypeEntity entity);

        Task<ResultModel> UpdateBadType(BadTypeEntity entity);
        Task<ResultModel> DeleteBadType(BadTypeIDEntity entity);

        Task<BadTypeViewEntity> FindByIDBadType(BadTypeIDEntity entity);

        Task<List<BadTypeViewEntity>> FindAllBadType(BadTypeIDEntity entity);
        Task<List<BadTypeViewEntity>> FindAllActiveBadType();

        Task<ResultModel> ActiveInActiveBadType(BadTypeIDEntity entity);

    }
}
