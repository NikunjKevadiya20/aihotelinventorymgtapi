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
    public class TourDomain : ITourDomain
    {
        private readonly ITourRepository repository;

        public TourDomain(ITourRepository _repository)
        {
            repository = _repository;
        }

        public async Task<TourIDViewEntity> InsertTour(TourEntity entity)
        {
            return await repository.InsertTour(entity);
        }

        public async Task<ResultModel> UpdateTour(TourEntity entity)
        {
            return await repository.UpdateTour(entity);
        }

        public async Task<ResultModel> DeleteTour(TourIDEntity entity)
        {
            return await repository.DeleteTour(entity);
        }

        public async Task<TourDataViewEntity> FindByIDTour(TourIDEntity entity)
        {
            return await repository.FindByIDTour(entity);
        }

        public async Task<List<TourDataViewEntity>> FindAllTour(TourIDEntity entity)
        {
            return await repository.FindAllTour(entity);
        }

        public async Task<List<TourDataViewEntity>> FindAllActiveTour()
        {
            return await repository.FindAllActiveTour();
        }

        public async Task<ResultModel> ActiveInActiveTour(TourIDEntity entity)
        {
            return await repository.ActiveInActiveTour(entity);
        }

        public async Task<ResultModel> TourImageUpdate(string? MainImage, string? BannerImage,List<TourDocumentsImage> Documents, int? ID, int? UpdatedBy)
        {
            return await repository.TourImageUpdate(MainImage, BannerImage, Documents, ID, UpdatedBy);
        }
        public async Task<ResultModel> DeleteTourGalleryImage(TourIDEntity entity)
        {
            return await repository.DeleteTourGalleryImage(entity);
        }
        public async Task<ResultModel> InsertTourItineraryDetails(TourItinerariesEntity entity)
        {
            return await repository.InsertTourItineraryDetails(entity);
        }
        public async Task<ResultModel> UpdateTourItineraryDetails(TourItineraryDetailsEntity entity)
        {
            return await repository.UpdateTourItineraryDetails(entity);
        }
        public async Task<ResultModel> DeleteTourItineraryDetails(TourItineraryDetailsEntity entity)
        {
            return await repository.DeleteTourItineraryDetails(entity);
        }
        public async Task<List<TourItineraryDetailsViewEntity>> FindByIdTourItineraryDetails(TourRateViewEntity entity)
        {
            return await repository.FindByIdTourItineraryDetails(entity);
        }


        public async Task<ResultModel> InsertTourCostDetails(TourCostDetailsEntity entity)
        {
            return await repository.InsertTourCostDetails(entity);
        }
        public async Task<ResultModel> UpdateTourCostDetails(TourCostDetailsEntity entity)
        {
            return await repository.UpdateTourCostDetails(entity);
        }
        public async Task<ResultModel> DeleteTourCostDetails(TourCostDetailsEntity entity)
        {
            return await repository.DeleteTourCostDetails(entity);
        }
        public async Task<List<TourCostDetailsViewEntity>> FindByIdTourCostDetails(TourRateViewEntity entity)
        {
            return await repository.FindByIdTourCostDetails(entity);
        }

        public async Task<ResultModel> InsertTourVideo(TourVideoEntity entity)
        {
            return await repository.InsertTourVideo(entity);
        }

        public async Task<ResultModel> UpdateTourVideo(TourVideoEntity entity)
        {
            return await repository.UpdateTourVideo(entity);
        }

        public async Task<ResultModel> DeleteTourVideo(TourIDEntity entity)
        {
            return await repository.DeleteTourVideo(entity);
        }
        public async Task<ResultModel> InsertTourFAQ(TourFAQEntity entity)
        {
            return await repository.InsertTourFAQ(entity);
        }

        public async Task<ResultModel> UpdateTourFAQ(TourFAQEntity entity)
        {
            return await repository.UpdateTourFAQ(entity);
        }

        public async Task<ResultModel> DeleteTourFAQ(TourIDEntity entity)
        {
            return await repository.DeleteTourFAQ(entity);
        }

    }
}
