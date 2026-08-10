using HotelBooking.Entity.Entities;
using HotelBooking.Entity.Common.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBooking.DataAccess.Interfaces
{
    public interface IGalleryRepository
    {
        Task<ResultModel> CreateOrUpdateGallery(GalleryEntity entity);
        Task<ResultModel> DeleteGallery(GalleryIDEntity entity);
        Task<GalleryDataViewEntity> FindByIDGallery(GalleryIDEntity entity);
        Task<List<GalleryDataViewEntity>> FindAllGallery();
        Task<List<GalleryGroupViewEntity>> FindAllActiveGallery();
        Task<ResultModel> ActiveInActiveGallery(GalleryIDEntity entity);
        Task<List<GalleryGroupViewEntity>> FindAllGalleryWiseGroupName();
        Task<GalleryVideoGalleryData> ListGalleryVideoGallery();
    }
}
