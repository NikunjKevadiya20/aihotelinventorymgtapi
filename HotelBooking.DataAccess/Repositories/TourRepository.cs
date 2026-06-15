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
    public class TourRepository : ITourRepository
    {
        ITourLookupRepositoryInterface repository;

        public TourRepository(ITourLookupRepositoryInterface _repository)
        {
            repository = _repository;
        }

        public async Task<TourIDViewEntity> InsertTour(TourEntity entity)
        {
            return await repository.InsertTour(entity, "sp_ManageTourInsert");
        }

        public async Task<ResultModel> UpdateTour(TourEntity entity)
        {
            return await repository.UpdateTour(entity, "sp_ManageTourInsert");
        }

        public async Task<ResultModel> DeleteTour(TourIDEntity entity)
        {
            return await repository.DeleteTour(entity, "sp_ManageTourFindDelete");
        }

        public async Task<TourDataViewEntity> FindByIDTour(TourIDEntity entity)
        {
            return await repository.FindByIDTour(entity, "sp_ManageTourFindDelete");
        }

        public async Task<List<TourDataViewEntity>> FindAllTour(TourIDEntity entity)
        {
            return await repository.FindAllTour(entity, "sp_ManageTourFindAll");
        }

        public async Task<List<TourDataViewEntity>> FindAllActiveTour()
        {
            return await repository.FindAllActiveTour("sp_ManageTourFindAll");
        }

        public async Task<ResultModel> ActiveInActiveTour(TourIDEntity entity)
        {
            return await repository.ActiveInActiveTour(entity, "sp_ManageTourFindDelete");
        }

        public async Task<ResultModel> TourImageUpdate(string? MainImage, string? BannerImage,List<TourDocumentsImage> Documents, int? ID, int? UpdatedBy)
        {
            return await repository.TourImageUpdate(MainImage, BannerImage, Documents, ID, UpdatedBy, "sp_ManageTourInsert");
        }

        public async Task<ResultModel> DeleteTourGalleryImage(TourIDEntity entity)
        {
            return await repository.DeleteTourGalleryImage(entity, "sp_ManageTourInsert");
        }
        public async Task<ResultModel> InsertTourItineraryDetails(TourItinerariesEntity entity)
        {
            return await repository.InsertTourItineraryDetails(entity, "sp_ManageTourItineraryInsert");
        }
        public async Task<ResultModel> UpdateTourItineraryDetails(TourItineraryDetailsEntity entity)
        {
            return await repository.UpdateTourItineraryDetails(entity, "sp_ManageTourItineraryInsert");
        }
        public async Task<ResultModel> DeleteTourItineraryDetails(TourItineraryDetailsEntity entity)
        {
            return await repository.DeleteTourItineraryDetails(entity, "sp_ManageTourItineraryFindByID");
        }
        public async Task<List<TourItineraryDetailsViewEntity>> FindByIdTourItineraryDetails(TourRateViewEntity entity)
        {
            return await repository.FindByIdTourItineraryDetails(entity, "sp_ManageTourItineraryFindByID");
        }
      
        public async Task<ResultModel> InsertTourCostDetails(TourCostDetailsEntity entity)
        {
            return await repository.InsertTourCostDetails(entity, "sp_ManageTourCostInsert");
        }
      
        public async Task<ResultModel> UpdateTourCostDetails(TourCostDetailsEntity entity)
        {
            return await repository.UpdateTourCostDetails(entity, "sp_ManageTourCostInsert");
        }
      
        public async Task<ResultModel> DeleteTourCostDetails(TourCostDetailsEntity entity)
        {
            return await repository.DeleteTourCostDetails(entity, "sp_ManageTourCostFindByID");
        }
      
        public async Task<List<TourCostDetailsViewEntity>> FindByIdTourCostDetails(TourRateViewEntity entity)
        {
            return await repository.FindByIdTourCostDetails(entity, "sp_ManageTourCostFindByID");
        }

        public async Task<ResultModel> InsertTourVideo(TourVideoEntity entity)
        {
            return await repository.InsertTourVideo(entity, "sp_ManageTourInsertwithVideoandFAQ");
        }
        public async Task<ResultModel> UpdateTourVideo(TourVideoEntity entity)
        {
            return await repository.UpdateTourVideo(entity, "sp_ManageTourInsertwithVideoandFAQ");
        }           
        public async Task<ResultModel> DeleteTourVideo(TourIDEntity entity)
        {
            return await repository.DeleteTourVideo(entity, "sp_ManageTourFindDelete");
        }
        public async Task<ResultModel> InsertTourFAQ(TourFAQEntity entity)
        {
            return await repository.InsertTourFAQ(entity, "sp_ManageTourInsertwithVideoandFAQ");
        }
        public async Task<ResultModel> UpdateTourFAQ(TourFAQEntity entity)
        {
            return await repository.UpdateTourFAQ(entity, "sp_ManageTourInsertwithVideoandFAQ");
        }
        public async Task<ResultModel> DeleteTourFAQ(TourIDEntity entity)
        {
            return await repository.DeleteTourFAQ(entity, "sp_ManageTourFindDelete");
        }

    }
}
