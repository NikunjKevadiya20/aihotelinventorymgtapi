using HotelBooking.Entity.Common.Entities;
using HotelBooking.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBooking.DataAccess.Interfaces
{
    public interface ITourRepository
    {
        Task<TourIDViewEntity> InsertTour(TourEntity entity);
        Task<ResultModel> UpdateTour(TourEntity entity);
        Task<ResultModel> DeleteTour(TourIDEntity entity);
        Task<TourDataViewEntity> FindByIDTour(TourIDEntity entity);
        Task<List<TourDataViewEntity>> FindAllTour(TourIDEntity entity);
        Task<List<TourDataViewEntity>> FindAllActiveTour();
        Task<ResultModel> ActiveInActiveTour(TourIDEntity entity);
        Task<ResultModel> TourImageUpdate(string? MainImage, string? BannerImage, List<TourDocumentsImage> Documents, int? ID, int? UpdatedBy);
        Task<ResultModel> DeleteTourGalleryImage(TourIDEntity entity);
        Task<ResultModel> InsertTourItineraryDetails(TourItinerariesEntity entity);
        Task<ResultModel> UpdateTourItineraryDetails(TourItineraryDetailsEntity entity);
        Task<ResultModel> DeleteTourItineraryDetails(TourItineraryDetailsEntity entity);
        Task<List<TourItineraryDetailsViewEntity>> FindByIdTourItineraryDetails(TourRateViewEntity entity);
        Task<ResultModel> InsertTourCostDetails(TourCostDetailsEntity entity);
        Task<ResultModel> UpdateTourCostDetails(TourCostDetailsEntity entity);
        Task<ResultModel> DeleteTourCostDetails(TourCostDetailsEntity entity);
        Task<List<TourCostDetailsViewEntity>> FindByIdTourCostDetails(TourRateViewEntity entity);

        Task<ResultModel> InsertTourVideo(TourVideoEntity entity);
        Task<ResultModel> UpdateTourVideo(TourVideoEntity entity);
        Task<ResultModel> DeleteTourVideo(TourIDEntity entity);
        Task<ResultModel> InsertTourFAQ(TourFAQEntity entity);
        Task<ResultModel> UpdateTourFAQ(TourFAQEntity entity);
        Task<ResultModel> DeleteTourFAQ(TourIDEntity entity);
    }
}
