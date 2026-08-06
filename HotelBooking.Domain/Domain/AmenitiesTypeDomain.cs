using HotelBooking.DataAccess.Interfaces;
using HotelBooking.Domain.Interfaces;
using HotelBooking.Entity.Common.Entities;
using HotelBooking.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBooking.Domain.Domain
{
    public class AmenitiesTypeDomain : IAmenitiesTypeDomain
    {
        private readonly IAmenitiesTypeRepository repository;

        public AmenitiesTypeDomain(IAmenitiesTypeRepository _repository)
        {
            repository = _repository;
        }

        public async Task<AmenitiesTypeIDViewEntity> InsertAmenitiesType(AmenitiesTypeEntity entity)
        {
            return await repository.InsertAmenitiesType(entity);
        }

        public async Task<ResultModel> UpdateAmenitiesType(AmenitiesTypeEntity entity)
        {
            return await repository.UpdateAmenitiesType(entity);
        }

        public async Task<ResultModel> DeleteAmenitiesType(AmenitiesTypeIDEntity entity)
        {
            return await repository.DeleteAmenitiesType(entity);
        }

        public async Task<AmenitiesTypeDataViewEntity> FindByIDAmenitiesType(AmenitiesTypeIDEntity entity)
        {
            return await repository.FindByIDAmenitiesType(entity);
        }

        public async Task<List<AmenitiesTypeDataViewEntity>> FindAllAmenitiesType(AmenitiesTypeIDEntity entity)
        {
            return await repository.FindAllAmenitiesType(entity);
        }

        public async Task<List<AmenitiesTypeDataViewEntity>> FindAllActiveAmenitiesType()
        {
            return await repository.FindAllActiveAmenitiesType();
        }

        public async Task<ResultModel> ActiveInActiveAmenitiesType(AmenitiesTypeIDEntity entity)
        {
            return await repository.ActiveInActiveAmenitiesType(entity);
        }
    }
}
