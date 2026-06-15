using HotelBooking.Entity.Common.Entities;
using HotelBooking.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBooking.Domain.Interfaces
{
    public interface IPropertyTypeDomain
    {
        Task<ResultModel> InsertPropertyType(PropertyTypeEntity entity);

        Task<ResultModel> UpdatePropertyType(PropertyTypeEntity entity);
        Task<ResultModel> DeletePropertyType(PropertyTypeIDEntity entity);

        Task<PropertyTypeViewEntity> FindByIDPropertyType(PropertyTypeIDEntity entity);

        Task<List<PropertyTypeViewEntity>> FindAllPropertyType(PropertyTypeIDEntity entity);
        Task<List<PropertyTypeViewEntity>> FindAllActivePropertyType();

        Task<ResultModel> ActiveInActivePropertyType(PropertyTypeIDEntity entity);


    }
}
