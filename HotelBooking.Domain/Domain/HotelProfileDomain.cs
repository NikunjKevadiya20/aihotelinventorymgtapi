using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelBooking.DataAccess.Interfaces;
using HotelBooking.Domain.Interfaces;
using HotelBooking.Entity.Common.Entities;
using HotelBooking.Entity.Entities;

namespace HotelBooking.Domain.Domain
{
    public class HotelProfileDomain : IHotelProfileDomain
    {
        IHotelProfileRepository repository;

        public HotelProfileDomain(IHotelProfileRepository _repository)
        {
            repository = _repository;
        }

        public async Task<PhilosophyIDViewEntity> InsertHotelProfile(HotelProfileEntity entity)
        {
            return await repository.InsertHotelProfile(entity);
        }

        public async Task<ResultModel> UpdateHotelProfile(HotelProfileEntity entity)
        {
            return await repository.UpdateHotelProfile(entity);
        }

        public async Task<ResultModel> DeleteHotelProfile(HotelProfileIDEntity entity)
        {
            return await repository.DeleteHotelProfile(entity);
        }

        public async Task<HotelProfileViewEntity> FindByIDHotelProfile(HotelProfileIDEntity entity)
        {
            return await repository.FindByIDHotelProfile(entity);
        }

        public async Task<List<HotelProfileViewEntity>> FindAllHotelProfile(HotelProfileIDEntity entity)
        {
            return await repository.FindAllHotelProfile(entity);
        }

        public async Task<List<HotelProfileViewEntity>> FindAllActiveHotelProfile()
        {
            return await repository.FindAllActiveHotelProfile();
        }

        public async Task<ResultModel> ActiveInActiveHotelProfile(HotelProfileIDEntity entity)
        {
            return await repository.ActiveInActiveHotelProfile(entity);
        }

        public async Task<ResultModel> UploadLogoHotelProfile(int? ID, string? LogoFile, int? UpdatedBy)
        {
            return await repository.UploadLogoHotelProfile(ID, LogoFile, UpdatedBy);
        }
    }
}
