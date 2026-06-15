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
    public class HotelBookingPackageDomain : IHotelBookingPackageDomain
    {
        IHotelBookingPackageRepository repository;
        public HotelBookingPackageDomain(IHotelBookingPackageRepository _repository)
        {
            repository = _repository;
        }

        public async Task<ResultModel> InsertHotelBookingPackage(HotelBookingPackageEntity entity)
        {
            return await repository.InsertHotelBookingPackage(entity);
        }

        public async Task<ResultModel> UpdateHotelBookingPackage(HotelBookingPackageEntity entity)
        {
            return await repository.UpdateHotelBookingPackage(entity);
        }

        public async Task<ResultModel> DeleteHotelBookingPackage(HotelBookingPackageIDEntity entity)
        {
            return await repository.DeleteHotelBookingPackage(entity);
        }
        public async Task<HotelBookingPackageViewEntity> FindByIDHotelBookingPackage(HotelBookingPackageIDEntity entity)
        {
            return await repository.FindByIDHotelBookingPackage(entity);
        }
        public async Task<List<HotelBookingPackageViewEntity>> FindAllHotelBookingPackage(HotelBookingPackageIDEntity entity)
        {
            return await repository.FindAllHotelBookingPackage(entity);
        }
        public async Task<List<HotelBookingPackageViewEntity>> FindAllActiveHotelBookingPackage()
        {
            return await repository.FindAllActiveHotelBookingPackage();
        }

        public async Task<ResultModel> ActiveInActiveHotelBookingPackage(HotelBookingPackageIDEntity entity)
        {
            return await repository.ActiveInActiveHotelBookingPackage(entity);
        }
        public async Task<ResultModel> HotelBookingPackageImageUpdate(string? BannerImage, string? ImageUpload, List<HotelBookingPackageDocumentsImage> Image, int? ID, int? UpdatedBy)
        {
            return await repository.HotelBookingPackageImageUpdate(BannerImage, ImageUpload, Image, ID, UpdatedBy);
        }
        public async Task<ResultModel> DeleteHotelBookingImages(AttractionIDEntity entity)
        {
            return await repository.DeleteHotelBookingImages(entity);
        }
        public async Task<HotelBookingPackageViewEntity> FindByURLHotelBookingPackage(HotelBookingPackageIDEntity entity)
        {
            return await repository.FindByURLHotelBookingPackage(entity);
        }

        public async Task<ResultModel> InsertHotelBookingPackageItineraryDetails(HotelBookingPackageItinerariesEntity entity)
        {
            return await repository.InsertHotelBookingPackageItineraryDetails(entity);
        }
        public async Task<ResultModel> UpdateHotelBookingPackageItineraryDetails(HotelBookingPackageItineraryDetailsEntity entity)
        {
            return await repository.UpdateHotelBookingPackageItineraryDetails(entity);
        }
        public async Task<ResultModel> DeleteHotelBookingPackageItineraryDetails(HotelBookingPackageItineraryDetailsEntity entity)
        {
            return await repository.DeleteHotelBookingPackageItineraryDetails(entity);
        }
        public async Task<List<HotelBookingPackageItineraryDetailsViewEntity>> FindByIdHotelBookingPackageItineraryDetails(HotelBookingPackageRateViewEntity entity)
        {
            return await repository.FindByIdHotelBookingPackageItineraryDetails(entity);
        }
    }
}
