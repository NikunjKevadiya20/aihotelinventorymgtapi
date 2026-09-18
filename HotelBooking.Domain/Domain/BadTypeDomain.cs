using HotelBooking.DataAccess.Interfaces;
using HotelBooking.Domain.Interfaces;
using HotelBooking.Entity.Common.Entities;
using HotelBooking.Entity.Entities;

namespace HotelBooking.Domain.Domain
{
    public class BadTypeDomain : IBadTypeDomain
    {
        IBadTypeRepository repository;
        public BadTypeDomain(IBadTypeRepository _repository)
        {
            repository = _repository;
        }

        public async Task<ResultModel> InsertBadType(BadTypeEntity entity)
        {
            return await repository.InsertBadType(entity);
        }

        public async Task<ResultModel> UpdateBadType(BadTypeEntity entity)
        {
            return await repository.UpdateBadType(entity);
        }

        public async Task<ResultModel> DeleteBadType(BadTypeIDEntity entity)
        {
            return await repository.DeleteBadType(entity);
        }
        public async Task<BadTypeViewEntity> FindByIDBadType(BadTypeIDEntity entity)
        {
            return await repository.FindByIDBadType(entity);
        }
        public async Task<List<BadTypeViewEntity>> FindAllBadType(BadTypeIDEntity entity)
        {
            return await repository.FindAllBadType(entity);
        }
        public async Task<List<BadTypeViewEntity>> FindAllActiveBadType()
        {
            return await repository.FindAllActiveBadType();
        }

        public async Task<ResultModel> ActiveInActiveBadType(BadTypeIDEntity entity)
        {
            return await repository.ActiveInActiveBadType(entity);
        }

    }
}
