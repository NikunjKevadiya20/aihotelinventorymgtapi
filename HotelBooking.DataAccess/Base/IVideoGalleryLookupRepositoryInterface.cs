using HotelBooking.Entity.Entities;
using HotelBooking.Entity.Common.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBooking.DataAccess.Base
{
    public interface IVideoGalleryLookupRepositoryInterface
    {
        Task<ResultModel> InsertVideoGallery(VideoGalleryEntity entity, string storedProcedure);
        Task<ResultModel> UpdateVideoGallery(VideoGalleryEntity entity, string storedProcedure);
        Task<ResultModel> DeleteVideoGallery(VideoGalleryIDEntity entity, string storedProcedure);
        Task<VideoGalleryViewEntity> FindByIDVideoGallery(VideoGalleryIDEntity entity, string storedProcedure);
        Task<List<VideoGalleryViewEntity>> FindAllVideoGallery(VideoGalleryIDEntity entity, string storedProcedure);
        Task<List<VideoGalleryViewEntity>> FindAllActiveVideoGallery(string storedProcedure);

        Task<ResultModel> ActiveInActiveVideoGallery(VideoGalleryIDEntity entity, string storedProcedure);

        Task<List<PropertyEntitys>> PropertyListWithVideo(string storedProcedure);


    }
}
