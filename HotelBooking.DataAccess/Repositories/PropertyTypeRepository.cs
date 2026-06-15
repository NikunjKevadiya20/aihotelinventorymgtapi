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
    public class PropertyTypeRepository : IPropertyTypeRepository
    {
        IPropertyTypeLookupRepositoryInterface repository;

        public PropertyTypeRepository(IPropertyTypeLookupRepositoryInterface _repository)
        {
            repository = _repository;
        }

        public async Task<ResultModel> InsertPropertyType(PropertyTypeEntity entity)
        {
            return await repository.InsertPropertyType(entity, "sp_ManagePropertyTypeInsert");
        }
        public async Task<ResultModel> UpdatePropertyType(PropertyTypeEntity entity)
        {
            return await repository.UpdatePropertyType(entity, "sp_ManagePropertyTypeInsert");
        }
        public async Task<ResultModel> DeletePropertyType(PropertyTypeIDEntity entity)
        {
            return await repository.DeletePropertyType(entity, "sp_ManagePropertyTypeFindByID");
        }
        public async Task<PropertyTypeViewEntity> FindByIDPropertyType(PropertyTypeIDEntity entity)
        {
            return await repository.FindByIDPropertyType(entity, "sp_ManagePropertyTypeFindByID");
        }

        public async Task<List<PropertyTypeViewEntity>> FindAllPropertyType(PropertyTypeIDEntity entity)
        {
            return await repository.FindAllPropertyType(entity, "sp_ManagePropertyTypeFindAll");
        }
        public async Task<List<PropertyTypeViewEntity>> FindAllActivePropertyType()
        {
            return await repository.FindAllActivePropertyType("sp_ManagePropertyTypeFindAll");
        }
        public async Task<ResultModel> ActiveInActivePropertyType(PropertyTypeIDEntity entity)
        {
            return await repository.ActiveInActivePropertyType(entity, "sp_ManagePropertyTypeFindByID");
        }

    }
}
