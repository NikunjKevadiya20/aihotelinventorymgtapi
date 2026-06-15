using HotelBooking.Entity.Entities;
using HotelBooking.Entity.Common.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBooking.DataAccess.Interfaces
{
    public interface IVideoGalleryRepository
    {
        Task<ResultModel> InsertVideoGallery(VideoGalleryEntity entity);

        Task<ResultModel> UpdateVideoGallery(VideoGalleryEntity entity);
        Task<ResultModel> DeleteVideoGallery(VideoGalleryIDEntity entity);

        Task<VideoGalleryViewEntity> FindByIDVideoGallery(VideoGalleryIDEntity entity);
        Task<List<VideoGalleryViewEntity>> FindAllVideoGallery(VideoGalleryIDEntity entity);
        Task<List<VideoGalleryViewEntity>> FindAllActiveVideoGallery();

        Task<ResultModel> ActiveInActiveVideoGallery(VideoGalleryIDEntity entity);

        Task<List<PropertyEntitys>> PropertyListWithVideo();

    }
}
