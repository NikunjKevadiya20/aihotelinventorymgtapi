using HotelBooking.Entity.Common.Entities;
using HotelBooking.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBooking.DataAccess.Base
{
    public interface IDistrictLookupRepositoryInterface
    {
        Task<ResultModel> InsertDistrict(DistrictEntity entity, string storedProcedure);
        Task<ResultModel> UpdateDistrict(DistrictEntity entity, string storedProcedure);
        Task<ResultModel> DeleteDistrict(DistrictIDEntity entity, string storedProcedure);
        Task<DistrictViewEntity> FindByIDDistrict(DistrictIDEntity entity, string storedProcedure);
        Task<List<DistrictViewEntity>> FindAllDistrict(DistrictIDEntity entity, string storedProcedure);
        Task<List<DistrictViewEntity>> FindAllActiveDistrict(string storedProcedure);
        Task<ResultModel> ActiveInActiveDistrict(DistrictIDEntity entity, string storedProcedure);
        Task<List<DistrictViewEntity>> FindDisatrictByStateID(DistrictIDEntity entity, string storedProcedure);
    }
}
