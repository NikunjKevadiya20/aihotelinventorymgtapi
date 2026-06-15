using HotelBooking.DataAccess.Interfaces;
using HotelBooking.Domain.Interfaces;
using HotelBooking.Entity.Entities;
using HotelBooking.Entity.Common.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBooking.Domain.Domain
{
    public class AmenitiesDomain : IAmenitiesDomain
    {
        private readonly IAmenitiesRepository repository;

        public AmenitiesDomain(IAmenitiesRepository _repository)
        {
            repository = _repository;
        }

        public async Task<AmenitiesIDViewEntity> InsertAmenities(AmenitiesEntity entity)
        {
            return await repository.InsertAmenities(entity);
        }

        public async Task<ResultModel> UpdateAmenities(AmenitiesEntity entity)
        {
            return await repository.UpdateAmenities(entity);
        }

        public async Task<ResultModel> DeleteAmenities(AmenitiesIDEntity entity)
        {
            return await repository.DeleteAmenities(entity);
        }

        public async Task<AmenitiesDataViewEntity> FindByIDAmenities(AmenitiesIDEntity entity)
        {
            return await repository.FindByIDAmenities(entity);
        }

        public async Task<List<AmenitiesDataViewEntity>> FindAllAmenities(AmenitiesIDEntity entity)
        {
            return await repository.FindAllAmenities(entity);
        }

        public async Task<List<AmenitiesDataViewEntity>> FindAllActiveAmenities()
        {
            return await repository.FindAllActiveAmenities();
        }

        public async Task<ResultModel> ActiveInActiveAmenities(AmenitiesIDEntity entity)
        {
            return await repository.ActiveInActiveAmenities(entity);
        }

        
    }
}
