using HotelBooking.DataAccess.Interfaces;
using HotelBooking.Domain.Interfaces;
using HotelBooking.Entity.Common.Entities;
using HotelBooking.Entity.Entities;

namespace HotelBooking.Domain.Domain
{
    public class BedTypeDomain : IBedTypeDomain
    {
        IBedTypeRepository repository;
        public BedTypeDomain(IBedTypeRepository _repository)
        {
            repository = _repository;
        }

        public async Task<ResultModel> InsertBedType(BedTypeEntity entity)
        {
            return await repository.InsertBedType(entity);
        }

        public async Task<ResultModel> UpdateBedType(BedTypeEntity entity)
        {
            return await repository.UpdateBedType(entity);
        }

        public async Task<ResultModel> DeleteBedType(BedTypeIDEntity entity)
        {
            return await repository.DeleteBedType(entity);
        }
        public async Task<BedTypeViewEntity> FindByIDBedType(BedTypeIDEntity entity)
        {
            return await repository.FindByIDBedType(entity);
        }
        public async Task<List<BedTypeViewEntity>> FindAllBedType(BedTypeIDEntity entity)
        {
            return await repository.FindAllBedType(entity);
        }
        public async Task<List<BedTypeViewEntity>> FindAllActiveBedType()
        {
            return await repository.FindAllActiveBedType();
        }

        public async Task<ResultModel> ActiveInActiveBedType(BedTypeIDEntity entity)
        {
            return await repository.ActiveInActiveBedType(entity);
        }

    }
}
