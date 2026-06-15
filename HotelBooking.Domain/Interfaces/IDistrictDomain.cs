using HotelBooking.Entity.Common.Entities;
using HotelBooking.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBooking.Domain.Interfaces
{
    public interface IDistrictDomain
    {
        Task<ResultModel> InsertDistrict(DistrictEntity entity);
        Task<ResultModel> UpdateDistrict(DistrictEntity entity);
        Task<ResultModel> DeleteDistrict(DistrictIDEntity entity);
        Task<DistrictViewEntity> FindByIDDistrict(DistrictIDEntity entity);
        Task<List<DistrictViewEntity>> FindAllDistrict(DistrictIDEntity entity);
        Task<List<DistrictViewEntity>> FindAllActiveDistrict();
        Task<ResultModel> ActiveInActiveDistrict(DistrictIDEntity entity);
        Task<List<DistrictViewEntity>> FindDisatrictByStateID(DistrictIDEntity entity);
    }
}
