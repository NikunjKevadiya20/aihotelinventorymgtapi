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
    public class GalleryDomain : IGalleryDomain
    {
        private readonly IGalleryRepository repository;

        public GalleryDomain(IGalleryRepository _repository)
        {
            repository = _repository;
        }


        #region Create or Update Gallery (Insert/Update)
        public async Task<ResultModel> CreateOrUpdateGallery(GalleryEntity entity)
        {
            return await repository.CreateOrUpdateGallery(entity);
        }
        #endregion
        public async Task<ResultModel> DeleteGallery(GalleryIDEntity entity)
        {
            return await repository.DeleteGallery(entity);
        }

        public async Task<GalleryDataViewEntity> FindByIDGallery(GalleryIDEntity entity)
        {
            return await repository.FindByIDGallery(entity);
        }

        public async Task<List<GalleryDataViewEntity>> FindAllGallery()
        {
            return await repository.FindAllGallery();
        }

        public async Task<List<GalleryGroupViewEntity>> FindAllActiveGallery()
        {
            return await repository.FindAllActiveGallery();
        }

        public async Task<ResultModel> ActiveInActiveGallery(GalleryIDEntity entity)
        {
            return await repository.ActiveInActiveGallery(entity);
        }
        public async Task<List<GalleryGroupViewEntity>> FindAllGalleryWiseGroupName()
        {
            return await repository.FindAllGalleryWiseGroupName();
        }
        public async Task<GalleryVideoGalleryData> ListGalleryVideoGallery()
        {
            return await repository.ListGalleryVideoGallery();
        }
    }
}
