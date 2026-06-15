using HotelBooking.DataAccess.Interfaces;
using HotelBooking.Domain.Interfaces;
using HotelBooking.Entity.Entities;
using HotelBooking.Entity.Common.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBooking.Domain.Domain
{
    public class VideoGalleryDomain : IVideoGalleryDomain
    {
        IVideoGalleryRepository repository;
        public VideoGalleryDomain(IVideoGalleryRepository _repository)
        {
            repository = _repository;
        }

        public async Task<ResultModel> InsertVideoGallery(VideoGalleryEntity entity)
        {
            return await repository.InsertVideoGallery(entity);
        }

        public async Task<ResultModel> UpdateVideoGallery(VideoGalleryEntity entity)
        {
            return await repository.UpdateVideoGallery(entity);
        }

        public async Task<ResultModel> DeleteVideoGallery(VideoGalleryIDEntity entity)
        {
            return await repository.DeleteVideoGallery(entity);
        }
        public async Task<VideoGalleryViewEntity> FindByIDVideoGallery(VideoGalleryIDEntity entity)
        {
            return await repository.FindByIDVideoGallery(entity);
        }
        public async Task<List<VideoGalleryViewEntity>> FindAllVideoGallery(VideoGalleryIDEntity entity)
        {
            return await repository.FindAllVideoGallery(entity);
        }
        public async Task<List<VideoGalleryViewEntity>> FindAllActiveVideoGallery()
        {
            return await repository.FindAllActiveVideoGallery();
        }

        public async Task<ResultModel> ActiveInActiveVideoGallery(VideoGalleryIDEntity entity)
        {
            return await repository.ActiveInActiveVideoGallery(entity);
        }
        public async Task<List<PropertyEntitys>> PropertyListWithVideo()
        {
            return await repository.PropertyListWithVideo();
        }

    }
}
