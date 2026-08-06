using HotelBooking.DataAccess.Base;
using HotelBooking.DataAccess.Interfaces;
using HotelBooking.Entity.Common.Entities;
using HotelBooking.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBooking.DataAccess.Repositories
{
    public class AmenitiesTypeRepository : IAmenitiesTypeRepository
    {
        IAmenitiesTypeLookupRepositoryInterface repository;

        public AmenitiesTypeRepository(IAmenitiesTypeLookupRepositoryInterface _repository)
        {
            repository = _repository;
        }

        public async Task<AmenitiesTypeIDViewEntity> InsertAmenitiesType(AmenitiesTypeEntity entity)
        {
            return await repository.InsertAmenitiesType(entity, "sp_ManageAmenitiesTypeInsert");
        }

        public async Task<ResultModel> UpdateAmenitiesType(AmenitiesTypeEntity entity)
        {
            return await repository.UpdateAmenitiesType(entity, "sp_ManageAmenitiesTypeInsert");
        }

        public async Task<ResultModel> DeleteAmenitiesType(AmenitiesTypeIDEntity entity)
        {
            return await repository.DeleteAmenitiesType(entity, "sp_ManageAmenitiesTypeFindDelete");
        }

        public async Task<AmenitiesTypeDataViewEntity> FindByIDAmenitiesType(AmenitiesTypeIDEntity entity)
        {
            return await repository.FindByIDAmenitiesType(entity, "sp_ManageAmenitiesTypeFindDelete");
        }

        public async Task<List<AmenitiesTypeDataViewEntity>> FindAllAmenitiesType(AmenitiesTypeIDEntity entity)
        {
            return await repository.FindAllAmenitiesType(entity, "sp_ManageAmenitiesTypeFindDelete");
        }

        public async Task<List<AmenitiesTypeDataViewEntity>> FindAllActiveAmenitiesType()
        {
            return await repository.FindAllActiveAmenitiesType("sp_ManageAmenitiesTypeFindDelete");
        }

        public async Task<ResultModel> ActiveInActiveAmenitiesType(AmenitiesTypeIDEntity entity)
        {
            return await repository.ActiveInActiveAmenitiesType(entity, "sp_ManageAmenitiesTypeFindDelete");
        }
    }
}
