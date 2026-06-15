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
    public class VideoGalleryRepository : IVideoGalleryRepository
    {
        IVideoGalleryLookupRepositoryInterface repository;

        public VideoGalleryRepository(IVideoGalleryLookupRepositoryInterface _repository)
        {
            repository = _repository;
        }

        public async Task<ResultModel> InsertVideoGallery(VideoGalleryEntity entity)
        {
            return await repository.InsertVideoGallery(entity, "sp_ManageVideoGalleryInsert");
        }
        public async Task<ResultModel> UpdateVideoGallery(VideoGalleryEntity entity)
        {
            return await repository.UpdateVideoGallery(entity, "sp_ManageVideoGalleryInsert");
        }
        public async Task<ResultModel> DeleteVideoGallery(VideoGalleryIDEntity entity)
        {
            return await repository.DeleteVideoGallery(entity, "sp_ManageVideoGalleryFindByID");
        }
        public async Task<VideoGalleryViewEntity> FindByIDVideoGallery(VideoGalleryIDEntity entity)
        {
            return await repository.FindByIDVideoGallery(entity, "sp_ManageVideoGalleryFindByID");
        }

        public async Task<List<VideoGalleryViewEntity>> FindAllVideoGallery(VideoGalleryIDEntity entity)
        {
            return await repository.FindAllVideoGallery(entity, "sp_ManageVideoGalleryFindAll");
        }
        public async Task<List<VideoGalleryViewEntity>> FindAllActiveVideoGallery()
        {
            return await repository.FindAllActiveVideoGallery("sp_ManageVideoGalleryFindAll");
        }
        public async Task<ResultModel> ActiveInActiveVideoGallery(VideoGalleryIDEntity entity)
        {
            return await repository.ActiveInActiveVideoGallery(entity, "sp_ManageVideoGalleryFindByID");
        }
        public async Task<List<PropertyEntitys>> PropertyListWithVideo()
        {
            return await repository.PropertyListWithVideo("sp_ManageVideoGalleryInsert");

        }
    }
}
