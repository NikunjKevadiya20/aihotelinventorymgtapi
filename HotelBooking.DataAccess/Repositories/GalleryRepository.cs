using HotelBooking.DataAccess.Base;
using HotelBooking.DataAccess.Interfaces;
using HotelBooking.Entity.Entities;
using HotelBooking.Entity.Common.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBooking.DataAccess.Repositories
{
    public class GalleryRepository : IGalleryRepository
    {
        private readonly IGalleryLookupRepositoryInterface repository;

        public GalleryRepository(IGalleryLookupRepositoryInterface _repository)
        {
            repository = _repository;
        }

        #region Create or Update Gallery (Insert/Update)
        public async Task<ResultModel> CreateOrUpdateGallery(GalleryEntity entity)
        {
            // Calls the same stored procedure that handles both insert and update logic
            return await repository.CreateOrUpdateGallery(entity, "sp_ManageGalleryInsert");
        }
        #endregion

        public async Task<ResultModel> DeleteGallery(GalleryIDEntity entity)
        {
            return await repository.DeleteGallery(entity, "sp_ManageGalleryFindDelete");
        }
        public async Task<GalleryDataViewEntity> FindByIDGallery(GalleryIDEntity entity)
        {
            return await repository.FindByIDGallery(entity, "sp_ManageGalleryFindDelete");
        }
        public async Task<List<GalleryDataViewEntity>> FindAllGallery()
        {
            return await repository.FindAllGallery("sp_ManageGalleryFindDelete");
        }
        public async Task<List<GalleryGroupViewEntity>> FindAllActiveGallery()
        {
            return await repository.FindAllActiveGallery("sp_ManageGalleryFindDelete");
        }
        public async Task<ResultModel> ActiveInActiveGallery(GalleryIDEntity entity)
        {
            return await repository.ActiveInActiveGallery(entity, "sp_ManageGalleryFindDelete");
        }
        public async Task<List<GalleryGroupViewEntity>> FindAllGalleryWiseGroupName()
        {
            return await repository.FindAllGalleryWiseGroupName("sp_ManageGalleryFindDelete");
        }
        public async Task<GalleryVideoGalleryData> ListGalleryVideoGallery()
        {
            return await repository.ListGalleryVideoGallery("sp_ManageGalleryFindDelete");
        }
    }
}
