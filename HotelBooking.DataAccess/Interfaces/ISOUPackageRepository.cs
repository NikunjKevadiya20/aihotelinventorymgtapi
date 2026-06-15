using HotelBooking.Entity.Common.Entities;
using HotelBooking.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBooking.DataAccess.Interfaces
{
    public interface IHotelBookingPackageRepository
    {
        Task<ResultModel> InsertHotelBookingPackage(HotelBookingPackageEntity entity);
        Task<ResultModel> UpdateHotelBookingPackage(HotelBookingPackageEntity entity);
        Task<ResultModel> DeleteHotelBookingPackage(HotelBookingPackageIDEntity entity);

        Task<HotelBookingPackageViewEntity> FindByIDHotelBookingPackage(HotelBookingPackageIDEntity entity);
        Task<List<HotelBookingPackageViewEntity>> FindAllHotelBookingPackage(HotelBookingPackageIDEntity entity);
        Task<List<HotelBookingPackageViewEntity>> FindAllActiveHotelBookingPackage();

        Task<ResultModel> ActiveInActiveHotelBookingPackage(HotelBookingPackageIDEntity entity);
        Task<ResultModel> HotelBookingPackageImageUpdate(string? BannerImage, string? ImageUpload, List<HotelBookingPackageDocumentsImage> Image, int? ID, int? UpdatedBy);
        Task<ResultModel> DeleteHotelBookingImages(AttractionIDEntity entity);
        Task<HotelBookingPackageViewEntity> FindByURLHotelBookingPackage(HotelBookingPackageIDEntity entity);
        Task<ResultModel> InsertHotelBookingPackageItineraryDetails(HotelBookingPackageItinerariesEntity entity);
        Task<ResultModel> UpdateHotelBookingPackageItineraryDetails(HotelBookingPackageItineraryDetailsEntity entity);
        Task<ResultModel> DeleteHotelBookingPackageItineraryDetails(HotelBookingPackageItineraryDetailsEntity entity);
        Task<List<HotelBookingPackageItineraryDetailsViewEntity>> FindByIdHotelBookingPackageItineraryDetails(HotelBookingPackageRateViewEntity entity);



    }
}
