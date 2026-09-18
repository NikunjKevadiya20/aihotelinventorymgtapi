using HotelBooking.DataAccess.Base;
using HotelBooking.DataAccess.Interfaces;
using HotelBooking.Entity.Common.Entities;
using HotelBooking.Entity.Entities;

namespace HotelBooking.DataAccess.Repositories
{
    public class BadTypeRepository : IBadTypeRepository
    {
        IBadTypeLookupRepositoryInterface repository;

        public BadTypeRepository(IBadTypeLookupRepositoryInterface _repository)
        {
            repository = _repository;
        }

        public async Task<ResultModel> InsertBadType(BadTypeEntity entity)
        {
            return await repository.InsertBadType(entity, "sp_ManageBadTypeInsert");
        }
        public async Task<ResultModel> UpdateBadType(BadTypeEntity entity)
        {
            return await repository.UpdateBadType(entity, "sp_ManageBadTypeInsert");
        }
        public async Task<ResultModel> DeleteBadType(BadTypeIDEntity entity)
        {
            return await repository.DeleteBadType(entity, "sp_ManageBadTypeFindByID");
        }
        public async Task<BadTypeViewEntity> FindByIDBadType(BadTypeIDEntity entity)
        {
            return await repository.FindByIDBadType(entity, "sp_ManageBadTypeFindByID");
        }
        public async Task<List<BadTypeViewEntity>> FindAllBadType(BadTypeIDEntity entity)
        {
            return await repository.FindAllBadType(entity, "sp_ManageBadTypeFindAll");
        }
        public async Task<List<BadTypeViewEntity>> FindAllActiveBadType()
        {
            return await repository.FindAllActiveBadType("sp_ManageBadTypeFindAll");
        }
        public async Task<ResultModel> ActiveInActiveBadType(BadTypeIDEntity entity)
        {
            return await repository.ActiveInActiveBadType(entity, "sp_ManageBadTypeFindByID");
        }


    }
}
