using HotelBooking.Entity.Common.Entities;
using HotelBooking.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBooking.DataAccess.Interfaces
{
    public interface IPackageTypeRepository
    {
        Task<ResultModel> InsertPackageType(PackageTypeEntity entity);

        Task<ResultModel> UpdatePackageType(PackageTypeEntity entity);
        Task<ResultModel> DeletePackageType(PackageTypeIDEntity entity);

        Task<PackageTypeViewEntity> FindByIDPackageType(PackageTypeIDEntity entity);
        Task<List<PackageTypeViewEntity>> FindAllPackageType(PackageTypeIDEntity entity);
        Task<List<PackageTypeViewEntity>> FindAllActivePackageType();

        Task<ResultModel> ActiveInActivePackageType(PackageTypeIDEntity entity);
        Task<ResultModel> SingleImageUpload(string? ImageUpload, int? ID, int? UpdatedBy);


    }
}
