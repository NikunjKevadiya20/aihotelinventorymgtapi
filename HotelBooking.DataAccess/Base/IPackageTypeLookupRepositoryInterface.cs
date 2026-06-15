using HotelBooking.Entity.Common.Entities;
using HotelBooking.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBooking.DataAccess.Base
{
    public interface IPackageTypeLookupRepositoryInterface
    {
        Task<ResultModel> InsertPackageType(PackageTypeEntity entity, string storedProcedure);
        Task<ResultModel> UpdatePackageType(PackageTypeEntity entity, string storedProcedure);
        Task<ResultModel> DeletePackageType(PackageTypeIDEntity entity, string storedProcedure);
        Task<PackageTypeViewEntity> FindByIDPackageType(PackageTypeIDEntity entity, string storedProcedure);
        Task<List<PackageTypeViewEntity>> FindAllPackageType(PackageTypeIDEntity entity, string storedProcedure);
        Task<List<PackageTypeViewEntity>> FindAllActivePackageType(string storedProcedure);

        Task<ResultModel> ActiveInActivePackageType(PackageTypeIDEntity entity, string storedProcedure);
        Task<ResultModel> SingleImageUpload(string? ImageUpload, int? ID, int? UpdatedBy);


    }
}
