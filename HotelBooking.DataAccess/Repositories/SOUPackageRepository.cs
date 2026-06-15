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
    public class HotelBookingPackageRepository : IHotelBookingPackageRepository
    {
        IHotelBookingPackageLookupRepositoryInterface repository;

        public HotelBookingPackageRepository(IHotelBookingPackageLookupRepositoryInterface _repository)
        {
            repository = _repository;
        }

        public async Task<ResultModel> InsertHotelBookingPackage(HotelBookingPackageEntity entity)
        {
            return await repository.InsertHotelBookingPackage(entity, "sp_ManageHotelBookingPackageInsert");
        }
        public async Task<ResultModel> UpdateHotelBookingPackage(HotelBookingPackageEntity entity)
        {
            return await repository.UpdateHotelBookingPackage(entity, "sp_ManageHotelBookingPackageInsert");
        }
        public async Task<ResultModel> DeleteHotelBookingPackage(HotelBookingPackageIDEntity entity)
        {
            return await repository.DeleteHotelBookingPackage(entity, "sp_ManageHotelBookingPackageFindDelete");
        }
        public async Task<HotelBookingPackageViewEntity> FindByIDHotelBookingPackage(HotelBookingPackageIDEntity entity)
        {
            return await repository.FindByIDHotelBookingPackage(entity, "sp_ManageHotelBookingPackageFindDelete");
        }

        public async Task<List<HotelBookingPackageViewEntity>> FindAllHotelBookingPackage(HotelBookingPackageIDEntity entity)
        {
            return await repository.FindAllHotelBookingPackage(entity, "sp_ManageHotelBookingPackageFindAll");
        }
        public async Task<List<HotelBookingPackageViewEntity>> FindAllActiveHotelBookingPackage()
        {
            return await repository.FindAllActiveHotelBookingPackage("sp_ManageHotelBookingPackageFindAllActive");
        }
        public async Task<ResultModel> ActiveInActiveHotelBookingPackage(HotelBookingPackageIDEntity entity)
        {
            return await repository.ActiveInActiveHotelBookingPackage(entity, "sp_ManageHotelBookingPackageFindDelete");
        }
        public async Task<ResultModel> HotelBookingPackageImageUpdate(string? BannerImage, string? ImageUpload, List<HotelBookingPackageDocumentsImage> Image, int? ID, int? UpdatedBy)
        {
            return await repository.HotelBookingPackageImageUpdate(BannerImage, ImageUpload, Image, ID, UpdatedBy, "sp_ManageHotelBookingPackageInsert");
        }
        public async Task<ResultModel> DeleteHotelBookingImages(AttractionIDEntity entity)
        {
            return await repository.DeleteHotelBookingImages(entity, "sp_ManageHotelBookingPackageInsert");
        }
        public async Task<HotelBookingPackageViewEntity> FindByURLHotelBookingPackage(HotelBookingPackageIDEntity entity)
        {
            return await repository.FindByURLHotelBookingPackage(entity, "sp_ManageHotelBookingPackageFindDelete");
        }

        public async Task<ResultModel> InsertHotelBookingPackageItineraryDetails(HotelBookingPackageItinerariesEntity entity)
        {
            return await repository.InsertHotelBookingPackageItineraryDetails(entity, "sp_ManageHotelBookingPackageItineraryInsert");
        }
        public async Task<ResultModel> UpdateHotelBookingPackageItineraryDetails(HotelBookingPackageItineraryDetailsEntity entity)
        {
            return await repository.UpdateHotelBookingPackageItineraryDetails(entity, "sp_ManageHotelBookingPackageItineraryInsert");
        }
        public async Task<ResultModel> DeleteHotelBookingPackageItineraryDetails(HotelBookingPackageItineraryDetailsEntity entity)
        {
            return await repository.DeleteHotelBookingPackageItineraryDetails(entity, "sp_ManageHotelBookingPackageItineraryFindByID");
        }
        public async Task<List<HotelBookingPackageItineraryDetailsViewEntity>> FindByIdHotelBookingPackageItineraryDetails(HotelBookingPackageRateViewEntity entity)
        {
            return await repository.FindByIdHotelBookingPackageItineraryDetails(entity, "sp_ManageHotelBookingPackageItineraryFindByID");
        }

    }
}
