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
    public class PackageTypeDomain : IPackageTypeDomain
    {
        IPackageTypeRepository repository;
        public PackageTypeDomain(IPackageTypeRepository _repository)
        {
            repository = _repository;
        }

        public async Task<ResultModel> InsertPackageType(PackageTypeEntity entity)
        {
            return await repository.InsertPackageType(entity);
        }

        public async Task<ResultModel> UpdatePackageType(PackageTypeEntity entity)
        {
            return await repository.UpdatePackageType(entity);
        }

        public async Task<ResultModel> DeletePackageType(PackageTypeIDEntity entity)
        {
            return await repository.DeletePackageType(entity);
        }
        public async Task<PackageTypeViewEntity> FindByIDPackageType(PackageTypeIDEntity entity)
        {
            return await repository.FindByIDPackageType(entity);
        }
        public async Task<List<PackageTypeViewEntity>> FindAllPackageType(PackageTypeIDEntity entity)
        {
            return await repository.FindAllPackageType(entity);
        }
        public async Task<List<PackageTypeViewEntity>> FindAllActivePackageType()
        {
            return await repository.FindAllActivePackageType();
        }

        public async Task<ResultModel> ActiveInActivePackageType(PackageTypeIDEntity entity)
        {
            return await repository.ActiveInActivePackageType(entity);
        }
        public async Task<ResultModel> SingleImageUpload(string? ImageUpload, int? ID, int? UpdatedBy)
        {
            return await repository.SingleImageUpload(ImageUpload, ID, UpdatedBy);
        }



    }
}
