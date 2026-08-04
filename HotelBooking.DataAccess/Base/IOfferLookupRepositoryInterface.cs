using HotelBooking.Entity.Common.Entities;
using HotelBooking.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static HotelBooking.Entity.Entities.OfferIDEntity;

namespace HotelBooking.DataAccess.Base
{
    public interface IOfferLookupRepositoryInterface
    {
        Task<OfferIDViewEntity> InsertOffer(OfferEntity entity, string storedProcedure);
        Task<ResultModel> UpdateOffer(OfferEntity entity, string storedProcedure);
        Task<ResultModel> DeleteOffer(OfferIDEntity entity, string storedProcedure);
        Task<OfferDataViewEntity> FindByIDOffer(OfferIDEntity entity, string storedProcedure);
        Task<List<OfferDataViewEntity>> FindAllOffer(OfferIDEntity entity, string storedProcedure);
        Task<List<OfferDataViewEntity>> FindAllActiveOffer(string storedProcedure);
        Task<ResultModel> ActiveInActiveOffer(OfferIDEntity entity, string storedProcedure);
        Task<ResultModel> OfferImageUpdate(string? ImageUpload, int? ID, int? UpdatedBy, string storedProcedure);

        Task<OfferViewEntity> FindByCouponCode(OfferIDEntity entity, string storedProcedure);
        Task<List<OfferViewEntity>> GetAllAvailableOffers(string storedProcedure);
    }
}
