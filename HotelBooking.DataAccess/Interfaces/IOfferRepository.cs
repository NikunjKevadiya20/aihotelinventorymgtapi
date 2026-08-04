using HotelBooking.Entity.Common.Entities;
using HotelBooking.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static HotelBooking.Entity.Entities.OfferIDEntity;

namespace HotelBooking.DataAccess.Interfaces
{
    public interface IOfferRepository
    {
        Task<OfferIDViewEntity> InsertOffer(OfferEntity entity);
        Task<ResultModel> UpdateOffer(OfferEntity entity);
        Task<ResultModel> DeleteOffer(OfferIDEntity entity);
        Task<OfferDataViewEntity> FindByIDOffer(OfferIDEntity entity);
        Task<List<OfferDataViewEntity>> FindAllOffer(OfferIDEntity entity);
        Task<List<OfferDataViewEntity>> FindAllActiveOffer();
        Task<ResultModel> ActiveInActiveOffer(OfferIDEntity entity);
        Task<ResultModel> OfferImageUpdate(string? ImageUpload, int? ID, int? UpdatedBy);
        Task<OfferViewEntity> FindByCouponCode(OfferIDEntity entity);
        Task<List<OfferViewEntity>> GetAllAvailableOffers();
    }
}
