using HotelBooking.DataAccess.Interfaces;
using HotelBooking.Domain.Interfaces;
using HotelBooking.Entity.Common.Entities;
using HotelBooking.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBooking.Domain.Domain
{
    public class ImageGalleryDomain : IImageGalleryDomain
    {
        IImageGalleryRepository repository;
        public ImageGalleryDomain(IImageGalleryRepository _repository)
        {
            repository = _repository;
        }

        public async Task<ResultModel> InsertImageGallery(ImageGalleryEntity entity)
        {
            return await repository.InsertImageGallery(entity);
        }
        public async Task<ResultModel> UpdateImageGallery(ImageGalleryEntity entity)
        {
            return await repository.UpdateImageGallery(entity);
        }
        public async Task<ResultModel> DeleteImageGallery(ImageGalleryIDEntity entity)
        {
            return await repository.DeleteImageGallery(entity);
        }
        
        public async Task<List<ImageGalleryDataViewEntity>> FindAllImageGallery(ImageGalleryIDEntity entity)
        {
            return await repository.FindAllImageGallery(entity);
        }
    }
}
