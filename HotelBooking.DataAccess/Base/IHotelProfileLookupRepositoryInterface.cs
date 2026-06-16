using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelBooking.Entity.Common.Entities;
using HotelBooking.Entity.Entities;

namespace HotelBooking.DataAccess.Base
{
    public interface IHotelProfileLookupRepositoryInterface
    {
        Task<PhilosophyIDViewEntity> InsertHotelProfile(HotelProfileEntity entity, string storedProcedure);
        Task<ResultModel> UpdateHotelProfile(HotelProfileEntity entity, string storedProcedure);
        Task<ResultModel> DeleteHotelProfile(HotelProfileIDEntity entity, string storedProcedure);
        Task<HotelProfileViewEntity> FindByIDHotelProfile(HotelProfileIDEntity entity, string storedProcedure);
        Task<List<HotelProfileViewEntity>> FindAllHotelProfile(HotelProfileIDEntity entity, string storedProcedure);
        Task<List<HotelProfileViewEntity>> FindAllActiveHotelProfile(string storedProcedure);
        Task<ResultModel> ActiveInActiveHotelProfile(HotelProfileIDEntity entity, string storedProcedure);
        Task<ResultModel> UploadLogoHotelProfile(int? ID, string? LogoFile, int? UpdatedBy, string storedProcedure);
    }
}
