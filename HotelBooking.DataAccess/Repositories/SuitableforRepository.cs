using HotelBooking.DataAccess.Base;
using HotelBooking.DataAccess.Interfaces;
using HotelBooking.Entity.Common.Entities;
using HotelBooking.Entity.Entities;

namespace HotelBooking.DataAccess.Repositories
{
    public class SuitableforRepository : ISuitableforRepository
    {
        ISuitableforLookupRepositoryInterface repository;

        public SuitableforRepository(ISuitableforLookupRepositoryInterface _repository)
        {
            repository = _repository;
        }

        public async Task<ResultModel> InsertSuitablefor(SuitableforEntity entity)
        {
            return await repository.InsertSuitablefor(entity, "sp_ManageSuitableforInsert");
        }
        public async Task<ResultModel> UpdateSuitablefor(SuitableforEntity entity)
        {
            return await repository.UpdateSuitablefor(entity, "sp_ManageSuitableforInsert");
        }
        public async Task<ResultModel> DeleteSuitablefor(SuitableforIDEntity entity)
        {
            return await repository.DeleteSuitablefor(entity, "sp_ManageSuitableforDetails");
        }
        public async Task<SuitableforViewEntity> FindByIDSuitablefor(SuitableforIDEntity entity)
        {
            return await repository.FindByIDSuitablefor(entity, "sp_ManageSuitableforDetails");
        }
        public async Task<List<SuitableforViewEntity>> FindAllSuitablefor(SuitableforIDEntity entity)
        {
            return await repository.FindAllSuitablefor(entity, "sp_ManageSuitableforFindAllActive");
        }
        public async Task<List<SuitableforViewEntity>> FindAllActiveSuitablefor()
        {
            return await repository.FindAllActiveSuitablefor("sp_ManageSuitableforFindAllActive");
        }
        public async Task<ResultModel> ActiveInActiveSuitablefor(SuitableforIDEntity entity)
        {
            return await repository.ActiveInActiveSuitablefor(entity, "sp_ManageSuitableforDetails");
        }


    }
}
