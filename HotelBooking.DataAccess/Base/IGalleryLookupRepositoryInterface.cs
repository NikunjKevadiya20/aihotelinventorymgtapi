using HotelBooking.Entity.Entities;
using HotelBooking.Entity.Common.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBooking.DataAccess.Base
{
    public interface IGalleryLookupRepositoryInterface
    {

        Task<ResultModel> CreateOrUpdateGallery(GalleryEntity entity, string storedProcedure);
        Task<ResultModel> DeleteGallery(GalleryIDEntity entity, string storedProcedure);
        Task<GalleryDataViewEntity> FindByIDGallery(GalleryIDEntity entity, string storedProcedure);
        Task<List<GalleryDataViewEntity>> FindAllGallery(string storedProcedure);
        Task<List<GalleryGroupViewEntity>> FindAllActiveGallery(string storedProcedure);
        Task<ResultModel> ActiveInActiveGallery(GalleryIDEntity entity, string storedProcedure);
        Task<List<GalleryGroupViewEntity>> FindAllGalleryWiseGroupName(string storedProcedure);
        Task<GalleryVideoGalleryData> ListGalleryVideoGallery(string storedProcedure);
    }
}
