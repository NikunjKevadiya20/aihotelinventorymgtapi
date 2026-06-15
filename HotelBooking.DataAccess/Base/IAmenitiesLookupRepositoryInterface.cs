using HotelBooking.Entity.Entities;
using HotelBooking.Entity.Common.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBooking.DataAccess.Base
{
    public interface IAmenitiesLookupRepositoryInterface
    {
        Task<AmenitiesIDViewEntity> InsertAmenities(AmenitiesEntity entity, string storedProcedure);
        Task<ResultModel> UpdateAmenities(AmenitiesEntity entity, string storedProcedure);
        Task<ResultModel> DeleteAmenities(AmenitiesIDEntity entity, string storedProcedure);
        Task<AmenitiesDataViewEntity> FindByIDAmenities(AmenitiesIDEntity entity, string storedProcedure);
        Task<List<AmenitiesDataViewEntity>> FindAllAmenities(AmenitiesIDEntity entity, string storedProcedure);
        Task<List<AmenitiesDataViewEntity>> FindAllActiveAmenities(string storedProcedure);
        Task<ResultModel> ActiveInActiveAmenities(AmenitiesIDEntity entity, string storedProcedure);
       
    }
}
