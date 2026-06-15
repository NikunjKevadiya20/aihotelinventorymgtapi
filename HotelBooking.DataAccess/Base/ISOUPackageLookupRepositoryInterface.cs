using HotelBooking.Entity.Common.Entities;
using HotelBooking.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBooking.DataAccess.Base
{
    public interface IHotelBookingPackageLookupRepositoryInterface
    {
        Task<ResultModel> InsertHotelBookingPackage(HotelBookingPackageEntity entity, string storedProcedure);
        Task<ResultModel> UpdateHotelBookingPackage(HotelBookingPackageEntity entity, string storedProcedure);
        Task<ResultModel> DeleteHotelBookingPackage(HotelBookingPackageIDEntity entity, string storedProcedure);
        Task<HotelBookingPackageViewEntity> FindByIDHotelBookingPackage(HotelBookingPackageIDEntity entity, string storedProcedure);
        Task<List<HotelBookingPackageViewEntity>> FindAllHotelBookingPackage(HotelBookingPackageIDEntity entity, string storedProcedure);
        Task<List<HotelBookingPackageViewEntity>> FindAllActiveHotelBookingPackage(string storedProcedure);

        Task<ResultModel> ActiveInActiveHotelBookingPackage(HotelBookingPackageIDEntity entity, string storedProcedure);
        Task<ResultModel> HotelBookingPackageImageUpdate(string? BannerImage, string? ImageUpload, List<HotelBookingPackageDocumentsImage> Image, int? ID, int? UpdatedBy, string storedProcedure);
        Task<ResultModel> DeleteHotelBookingImages(AttractionIDEntity entity, string storedProcedure);
        Task<HotelBookingPackageViewEntity> FindByURLHotelBookingPackage(HotelBookingPackageIDEntity entity, string storedProcedure);
        Task<ResultModel> InsertHotelBookingPackageItineraryDetails(HotelBookingPackageItinerariesEntity entity, string storedProcedure);
        Task<ResultModel> UpdateHotelBookingPackageItineraryDetails(HotelBookingPackageItineraryDetailsEntity entity, string storedProcedure);
        Task<ResultModel> DeleteHotelBookingPackageItineraryDetails(HotelBookingPackageItineraryDetailsEntity entity, string storedProcedure);
        Task<List<HotelBookingPackageItineraryDetailsViewEntity>> FindByIdHotelBookingPackageItineraryDetails(HotelBookingPackageRateViewEntity entity, string storedProcedure);



    }
}
