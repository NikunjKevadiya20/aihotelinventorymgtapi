using HotelBooking.DataAccess.Base;
using HotelBooking.DataAccess.Interfaces;
using HotelBooking.Entity.Common.Entities;
using HotelBooking.Entity.Entities;

namespace HotelBooking.DataAccess.Repositories
{
    public class BedTypeRepository : IBedTypeRepository
    {
        IBedTypeLookupRepositoryInterface repository;

        public BedTypeRepository(IBedTypeLookupRepositoryInterface _repository)
        {
            repository = _repository;
        }

        public async Task<ResultModel> InsertBedType(BedTypeEntity entity)
        {
            return await repository.InsertBedType(entity, "sp_ManageBedTypeInsert");
        }
        public async Task<ResultModel> UpdateBedType(BedTypeEntity entity)
        {
            return await repository.UpdateBedType(entity, "sp_ManageBedTypeInsert");
        }
        public async Task<ResultModel> DeleteBedType(BedTypeIDEntity entity)
        {
            return await repository.DeleteBedType(entity, "sp_ManageBedTypeFindByID");
        }
        public async Task<BedTypeViewEntity> FindByIDBedType(BedTypeIDEntity entity)
        {
            return await repository.FindByIDBedType(entity, "sp_ManageBedTypeFindByID");
        }
        public async Task<List<BedTypeViewEntity>> FindAllBedType(BedTypeIDEntity entity)
        {
            return await repository.FindAllBedType(entity, "sp_ManageBedTypeFindAll");
        }
        public async Task<List<BedTypeViewEntity>> FindAllActiveBedType()
        {
            return await repository.FindAllActiveBedType("sp_ManageBedTypeFindAll");
        }
        public async Task<ResultModel> ActiveInActiveBedType(BedTypeIDEntity entity)
        {
            return await repository.ActiveInActiveBedType(entity, "sp_ManageBedTypeFindByID");
        }


    }
}
