using HotelBooking.Entity.Common.Entities;
using HotelBooking.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBooking.DataAccess.Base
{
    public interface ITourLookupRepositoryInterface
    {
        Task<TourIDViewEntity> InsertTour(TourEntity entity, string storedProcedure);
        Task<ResultModel> UpdateTour(TourEntity entity, string storedProcedure);
        Task<ResultModel> DeleteTour(TourIDEntity entity, string storedProcedure);
        Task<TourDataViewEntity> FindByIDTour(TourIDEntity entity, string storedProcedure);
        Task<List<TourDataViewEntity>> FindAllTour(TourIDEntity entity, string storedProcedure);
        Task<List<TourDataViewEntity>> FindAllActiveTour(string storedProcedure);
        Task<ResultModel> ActiveInActiveTour(TourIDEntity entity, string storedProcedure);
        Task<ResultModel> TourImageUpdate(string? MainImage, string? BannerImage, List<TourDocumentsImage> Documents, int? ID, int? UpdatedBy, string storedProcedure);
        Task<ResultModel> DeleteTourGalleryImage(TourIDEntity entity, string storedProcedure);
        Task<ResultModel> InsertTourItineraryDetails(TourItinerariesEntity entity, string storedProcedure);
        Task<ResultModel> UpdateTourItineraryDetails(TourItineraryDetailsEntity entity, string storedProcedure);
        Task<ResultModel> DeleteTourItineraryDetails(TourItineraryDetailsEntity entity, string storedProcedure);
        Task<List<TourItineraryDetailsViewEntity>> FindByIdTourItineraryDetails(TourRateViewEntity entity, string storedProcedure);

        Task<ResultModel> InsertTourCostDetails(TourCostDetailsEntity entity, string storedProcedure);
        Task<ResultModel> UpdateTourCostDetails(TourCostDetailsEntity entity, string storedProcedure);
        Task<ResultModel> DeleteTourCostDetails(TourCostDetailsEntity entity, string storedProcedure);
        Task<List<TourCostDetailsViewEntity>> FindByIdTourCostDetails(TourRateViewEntity entity, string storedProcedure);

        Task<ResultModel> InsertTourVideo(TourVideoEntity entity, string storedProcedure);
        Task<ResultModel> UpdateTourVideo(TourVideoEntity entity, string storedProcedure);
        Task<ResultModel> DeleteTourVideo(TourIDEntity entity, string storedProcedure);
        Task<ResultModel> InsertTourFAQ(TourFAQEntity entity, string storedProcedure);
        Task<ResultModel> UpdateTourFAQ(TourFAQEntity entity, string storedProcedure);
        Task<ResultModel> DeleteTourFAQ(TourIDEntity entity, string storedProcedure);


    }
}
