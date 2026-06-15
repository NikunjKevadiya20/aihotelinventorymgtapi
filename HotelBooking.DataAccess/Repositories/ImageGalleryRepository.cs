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
    public class ImageGalleryRepository : IImageGalleryRepository
    {
        IImageGalleryLookupRepositoryInterface repository;
        public ImageGalleryRepository(IImageGalleryLookupRepositoryInterface _repository)
        {
            repository = _repository;
        }

        public async Task<ResultModel> InsertImageGallery(ImageGalleryEntity entity)
        {
            return await repository.InsertImageGallery(entity, "sp_ManageImages");
        }
        public async Task<ResultModel> UpdateImageGallery(ImageGalleryEntity entity)
        {
            return await repository.UpdateImageGallery(entity, "sp_ManageImages");
        }
        public async Task<ResultModel> DeleteImageGallery(ImageGalleryIDEntity entity)
        {
            return await repository.DeleteImageGallery(entity, "sp_ManageImages");
        }
        public async Task<List<ImageGalleryDataViewEntity>> FindAllImageGallery(ImageGalleryIDEntity entity)
        {
            return await repository.FindAllImageGallery(entity, "sp_ManageImages");
        }

    }
}
