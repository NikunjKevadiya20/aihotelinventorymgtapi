using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelBooking.Entity.Common.Entities;
using HotelBooking.Entity.Entities;

namespace HotelBooking.Domain.Interfaces
{
    public interface IHotelProfileDomain
    {
        Task<PhilosophyIDViewEntity> InsertHotelProfile(HotelProfileEntity entity);
        Task<ResultModel> UpdateHotelProfile(HotelProfileEntity entity);
        Task<ResultModel> DeleteHotelProfile(HotelProfileIDEntity entity);
        Task<HotelProfileViewEntity> FindByIDHotelProfile(HotelProfileIDEntity entity);
        Task<List<HotelProfileViewEntity>> FindAllHotelProfile(HotelProfileIDEntity entity);
        Task<List<HotelProfileViewEntity>> FindAllActiveHotelProfile();
        Task<ResultModel> ActiveInActiveHotelProfile(HotelProfileIDEntity entity);
        Task<ResultModel> UploadLogoHotelProfile(int? ID, string? LogoFile, int? UpdatedBy);
    }
}
