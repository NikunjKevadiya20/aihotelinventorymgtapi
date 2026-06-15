using HotelBooking.Entity.Common.Entities;
using HotelBooking.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBooking.DataAccess.Base
{
    public interface IImageGalleryLookupRepositoryInterface
    {
        Task<ResultModel> InsertImageGallery(ImageGalleryEntity entity, string storedProcedure);
        Task<ResultModel> UpdateImageGallery(ImageGalleryEntity entity, string storedProcedure);
        Task<ResultModel> DeleteImageGallery(ImageGalleryIDEntity entity, string storedProcedure);
        Task<List<ImageGalleryDataViewEntity>> FindAllImageGallery(ImageGalleryIDEntity entity, string storedProcedure);
        
    }
}
