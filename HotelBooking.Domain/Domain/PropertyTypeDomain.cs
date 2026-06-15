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
    public class PropertyTypeDomain : IPropertyTypeDomain
    {
        IPropertyTypeRepository repository;
        public PropertyTypeDomain(IPropertyTypeRepository _repository)
        {
            repository = _repository;
        }

        public async Task<ResultModel> InsertPropertyType(PropertyTypeEntity entity)
        {
            return await repository.InsertPropertyType(entity);
        }

        public async Task<ResultModel> UpdatePropertyType(PropertyTypeEntity entity)
        {
            return await repository.UpdatePropertyType(entity);
        }

        public async Task<ResultModel> DeletePropertyType(PropertyTypeIDEntity entity)
        {
            return await repository.DeletePropertyType(entity);
        }
        public async Task<PropertyTypeViewEntity> FindByIDPropertyType(PropertyTypeIDEntity entity)
        {
            return await repository.FindByIDPropertyType(entity);
        }
        public async Task<List<PropertyTypeViewEntity>> FindAllPropertyType(PropertyTypeIDEntity entity)
        {
            return await repository.FindAllPropertyType(entity);
        }
        public async Task<List<PropertyTypeViewEntity>> FindAllActivePropertyType()
        {
            return await repository.FindAllActivePropertyType();
        }

        public async Task<ResultModel> ActiveInActivePropertyType(PropertyTypeIDEntity entity)
        {
            return await repository.ActiveInActivePropertyType(entity);
        }
       

    }
}
