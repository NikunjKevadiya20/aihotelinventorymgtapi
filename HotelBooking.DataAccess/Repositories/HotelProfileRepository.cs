using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelBooking.DataAccess.Base;
using HotelBooking.DataAccess.Interfaces;
using HotelBooking.Entity.Common.Entities;
using HotelBooking.Entity.Entities;

namespace HotelBooking.DataAccess.Repositories
{
    public class HotelProfileRepository : IHotelProfileRepository
    {
        IHotelProfileLookupRepositoryInterface repository;

        public HotelProfileRepository(IHotelProfileLookupRepositoryInterface _repository)
        {
            repository = _repository;
        }

        public async Task<PhilosophyIDViewEntity> InsertHotelProfile(HotelProfileEntity entity)
        {
            return await repository.InsertHotelProfile(entity, "sp_ManageHotelProfile");
        }

        public async Task<ResultModel> UpdateHotelProfile(HotelProfileEntity entity)
        {
            return await repository.UpdateHotelProfile(entity, "sp_ManageHotelProfile");
        }

        public async Task<ResultModel> DeleteHotelProfile(HotelProfileIDEntity entity)
        {
            return await repository.DeleteHotelProfile(entity, "sp_ManageHotelProfileFindByID");
        }

        public async Task<HotelProfileViewEntity> FindByIDHotelProfile(HotelProfileIDEntity entity)
        {
            return await repository.FindByIDHotelProfile(entity, "sp_ManageHotelProfileFindByID");
        }

        public async Task<List<HotelProfileViewEntity>> FindAllHotelProfile(HotelProfileIDEntity entity)
        {
            return await repository.FindAllHotelProfile(entity, "sp_ManageHotelProfileFindAll");
        }

        public async Task<List<HotelProfileViewEntity>> FindAllActiveHotelProfile()
        {
            return await repository.FindAllActiveHotelProfile("sp_ManageHotelProfileFindAll");
        }

        public async Task<ResultModel> ActiveInActiveHotelProfile(HotelProfileIDEntity entity)
        {
            return await repository.ActiveInActiveHotelProfile(entity, "sp_ManageHotelProfileFindByID");
        }

        public async Task<ResultModel> UploadLogoHotelProfile(int? ID, string? LogoFile, int? UpdatedBy)
        {
            return await repository.UploadLogoHotelProfile(ID, LogoFile, UpdatedBy, "sp_ManageHotelProfile");
        }
    }
}
