using HotelBooking.DataAccess.Interfaces;
using HotelBooking.Domain.Interfaces;
using HotelBooking.Entity.Common.Entities;
using HotelBooking.Entity.Entities;

namespace HotelBooking.Domain.Domain
{
    public class SuitableforDomain : ISuitableforDomain
    {
        ISuitableforRepository repository;
        public SuitableforDomain(ISuitableforRepository _repository)
        {
            repository = _repository;
        }

        public async Task<ResultModel> InsertSuitablefor(SuitableforEntity entity)
        {
            return await repository.InsertSuitablefor(entity);
        }

        public async Task<ResultModel> UpdateSuitablefor(SuitableforEntity entity)
        {
            return await repository.UpdateSuitablefor(entity);
        }

        public async Task<ResultModel> DeleteSuitablefor(SuitableforIDEntity entity)
        {
            return await repository.DeleteSuitablefor(entity);
        }
        public async Task<SuitableforViewEntity> FindByIDSuitablefor(SuitableforIDEntity entity)
        {
            return await repository.FindByIDSuitablefor(entity);
        }
        public async Task<List<SuitableforViewEntity>> FindAllSuitablefor(SuitableforIDEntity entity)
        {
            return await repository.FindAllSuitablefor(entity);
        }
        public async Task<List<SuitableforViewEntity>> FindAllActiveSuitablefor()
        {
            return await repository.FindAllActiveSuitablefor();
        }

        public async Task<ResultModel> ActiveInActiveSuitablefor(SuitableforIDEntity entity)
        {
            return await repository.ActiveInActiveSuitablefor(entity);
        }

    }
}
