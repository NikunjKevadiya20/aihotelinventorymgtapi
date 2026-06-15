using HotelBooking.Entity.Entities;
using HotelBooking.Entity.Common.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBooking.Domain.Interfaces
{
    public interface IAmenitiesDomain
    {
        Task<AmenitiesIDViewEntity> InsertAmenities(AmenitiesEntity entity);
        Task<ResultModel> UpdateAmenities(AmenitiesEntity entity);
        Task<ResultModel> DeleteAmenities(AmenitiesIDEntity entity);
        Task<AmenitiesDataViewEntity> FindByIDAmenities(AmenitiesIDEntity entity);
        Task<List<AmenitiesDataViewEntity>> FindAllAmenities(AmenitiesIDEntity entity);
        Task<List<AmenitiesDataViewEntity>> FindAllActiveAmenities();
        Task<ResultModel> ActiveInActiveAmenities(AmenitiesIDEntity entity);
        
    }
}
