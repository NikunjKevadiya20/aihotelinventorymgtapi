using HotelBooking.Entity.Common.Entities;
using HotelBooking.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBooking.DataAccess.Interfaces
{
    public interface IAmenitiesTypeRepository
    {
        Task<AmenitiesTypeIDViewEntity> InsertAmenitiesType(AmenitiesTypeEntity entity);
        Task<ResultModel> UpdateAmenitiesType(AmenitiesTypeEntity entity);
        Task<ResultModel> DeleteAmenitiesType(AmenitiesTypeIDEntity entity);
        Task<AmenitiesTypeDataViewEntity> FindByIDAmenitiesType(AmenitiesTypeIDEntity entity);
        Task<List<AmenitiesTypeDataViewEntity>> FindAllAmenitiesType(AmenitiesTypeIDEntity entity);
        Task<List<AmenitiesTypeDataViewEntity>> FindAllActiveAmenitiesType();
        Task<ResultModel> ActiveInActiveAmenitiesType(AmenitiesTypeIDEntity entity);
    }
}
