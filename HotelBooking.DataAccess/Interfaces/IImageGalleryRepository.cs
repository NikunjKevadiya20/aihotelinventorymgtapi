using HotelBooking.Entity.Common.Entities;
using HotelBooking.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBooking.DataAccess.Interfaces
{
    public interface IImageGalleryRepository
    {
        Task<ResultModel> InsertImageGallery(ImageGalleryEntity entity);
        Task<ResultModel> UpdateImageGallery(ImageGalleryEntity entity);
        Task<ResultModel> DeleteImageGallery(ImageGalleryIDEntity entity);
        Task<List<ImageGalleryDataViewEntity>> FindAllImageGallery(ImageGalleryIDEntity entity);
    }
}
