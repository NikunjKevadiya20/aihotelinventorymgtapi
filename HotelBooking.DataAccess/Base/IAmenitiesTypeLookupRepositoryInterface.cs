using HotelBooking.Entity.Common.Entities;
using HotelBooking.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBooking.DataAccess.Base
{
    public interface IAmenitiesTypeLookupRepositoryInterface
    {
        Task<AmenitiesTypeIDViewEntity> InsertAmenitiesType(AmenitiesTypeEntity entity, string storedProcedure);
        Task<ResultModel> UpdateAmenitiesType(AmenitiesTypeEntity entity, string storedProcedure);
        Task<ResultModel> DeleteAmenitiesType(AmenitiesTypeIDEntity entity, string storedProcedure);
        Task<AmenitiesTypeDataViewEntity> FindByIDAmenitiesType(AmenitiesTypeIDEntity entity, string storedProcedure);
        Task<List<AmenitiesTypeDataViewEntity>> FindAllAmenitiesType(AmenitiesTypeIDEntity entity, string storedProcedure);
        Task<List<AmenitiesTypeDataViewEntity>> FindAllActiveAmenitiesType(string storedProcedure);
        Task<ResultModel> ActiveInActiveAmenitiesType(AmenitiesTypeIDEntity entity, string storedProcedure);
    }
}
