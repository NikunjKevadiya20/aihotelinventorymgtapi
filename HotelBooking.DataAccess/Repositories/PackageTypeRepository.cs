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
    public class PackageTypeRepository : IPackageTypeRepository
    {
        IPackageTypeLookupRepositoryInterface repository;

        public PackageTypeRepository(IPackageTypeLookupRepositoryInterface _repository)
        {
            repository = _repository;
        }

        public async Task<ResultModel> InsertPackageType(PackageTypeEntity entity)
        {
            return await repository.InsertPackageType(entity, "sp_ManagePackageTypeInsert");
        }
        public async Task<ResultModel> UpdatePackageType(PackageTypeEntity entity)
        {
            return await repository.UpdatePackageType(entity, "sp_ManagePackageTypeInsert");
        }
        public async Task<ResultModel> DeletePackageType(PackageTypeIDEntity entity)
        {
            return await repository.DeletePackageType(entity, "sp_ManagePackageTypeFindByID");
        }
        public async Task<PackageTypeViewEntity> FindByIDPackageType(PackageTypeIDEntity entity)
        {
            return await repository.FindByIDPackageType(entity, "sp_ManagePackageTypeFindByID");
        }

        public async Task<List<PackageTypeViewEntity>> FindAllPackageType(PackageTypeIDEntity entity)
        {
            return await repository.FindAllPackageType(entity, "sp_ManagePackageTypeFindAll");
        }
        public async Task<List<PackageTypeViewEntity>> FindAllActivePackageType()
        {
            return await repository.FindAllActivePackageType("sp_ManagePackageTypeFindAll");
        }
        public async Task<ResultModel> ActiveInActivePackageType(PackageTypeIDEntity entity)
        {
            return await repository.ActiveInActivePackageType(entity, "sp_ManagePackageTypeFindByID");
        }

        public async Task<ResultModel> SingleImageUpload(string? ImageUpload, int? ID, int? UpdatedBy)
        {
            return await repository.SingleImageUpload(ImageUpload, ID, UpdatedBy);
        }
    }
}
