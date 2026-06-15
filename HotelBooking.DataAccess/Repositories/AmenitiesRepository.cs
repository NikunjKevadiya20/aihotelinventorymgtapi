using HotelBooking.DataAccess.Base;
using HotelBooking.DataAccess.Interfaces;
using HotelBooking.Entity.Entities;
using HotelBooking.Entity.Common.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBooking.DataAccess.Repositories
{
    public class AmenitiesRepository : IAmenitiesRepository
    {
        IAmenitiesLookupRepositoryInterface repository;

        public AmenitiesRepository(IAmenitiesLookupRepositoryInterface _repository)
        {
            repository = _repository;
        }

        public async Task<AmenitiesIDViewEntity> InsertAmenities(AmenitiesEntity entity)
        {
            return await repository.InsertAmenities(entity, "sp_ManageAmenitiesInsert");
        }

        public async Task<ResultModel> UpdateAmenities(AmenitiesEntity entity)
        {
            return await repository.UpdateAmenities(entity, "sp_ManageAmenitiesInsert");
        }

        public async Task<ResultModel> DeleteAmenities(AmenitiesIDEntity entity)
        {
            return await repository.DeleteAmenities(entity, "sp_ManageAmenitiesFindDelete");
        }

        public async Task<AmenitiesDataViewEntity> FindByIDAmenities(AmenitiesIDEntity entity)
        {
            return await repository.FindByIDAmenities(entity, "sp_ManageAmenitiesFindDelete");
        }

        public async Task<List<AmenitiesDataViewEntity>> FindAllAmenities(AmenitiesIDEntity entity)
        {
            return await repository.FindAllAmenities(entity, "sp_ManageAmenitiesFindDelete");
        }

        public async Task<List<AmenitiesDataViewEntity>> FindAllActiveAmenities()
        {
            return await repository.FindAllActiveAmenities("sp_ManageAmenitiesFindDelete");
        }

        public async Task<ResultModel> ActiveInActiveAmenities(AmenitiesIDEntity entity)
        {
            return await repository.ActiveInActiveAmenities(entity, "sp_ManageAmenitiesFindDelete");
        }

        
    }
}
