using HotelBooking.Entity.Common.Entities;
using HotelBooking.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBooking.DataAccess.Base
{
    public interface IPropertyTypeLookupRepositoryInterface
    {
        Task<ResultModel> InsertPropertyType(PropertyTypeEntity entity, string storedProcedure);
        Task<ResultModel> UpdatePropertyType(PropertyTypeEntity entity, string storedProcedure);
        Task<ResultModel> DeletePropertyType(PropertyTypeIDEntity entity, string storedProcedure);
        Task<PropertyTypeViewEntity> FindByIDPropertyType(PropertyTypeIDEntity entity, string storedProcedure);
        Task<List<PropertyTypeViewEntity>> FindAllPropertyType(PropertyTypeIDEntity entity, string storedProcedure);
        Task<List<PropertyTypeViewEntity>> FindAllActivePropertyType(string storedProcedure);

        Task<ResultModel> ActiveInActivePropertyType(PropertyTypeIDEntity entity, string storedProcedure);
        
    }
}
