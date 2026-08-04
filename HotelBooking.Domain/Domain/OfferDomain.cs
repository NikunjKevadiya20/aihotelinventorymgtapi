using HotelBooking.DataAccess.Interfaces;
using HotelBooking.Entity.Common.Entities;
using HotelBooking.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static HotelBooking.Entity.Entities.OfferIDEntity;

namespace HotelBooking.Domain.Domain
{
    public class OfferDomain : IOfferDomain
    {
        private readonly IOfferRepository repository;

        public OfferDomain(IOfferRepository _repository)
        {
            repository = _repository;
        }

        public async Task<OfferIDViewEntity> InsertOffer(OfferEntity entity)
        {
            return await repository.InsertOffer(entity);
        }

        public async Task<ResultModel> UpdateOffer(OfferEntity entity)
        {
            return await repository.UpdateOffer(entity);
        }

        public async Task<ResultModel> DeleteOffer(OfferIDEntity entity)
        {
            return await repository.DeleteOffer(entity);
        }

        public async Task<OfferDataViewEntity> FindByIDOffer(OfferIDEntity entity)
        {
            return await repository.FindByIDOffer(entity);
        }

        public async Task<List<OfferDataViewEntity>> FindAllOffer(OfferIDEntity entity)
        {
            return await repository.FindAllOffer(entity);
        }

        public async Task<List<OfferDataViewEntity>> FindAllActiveOffer()
        {
            return await repository.FindAllActiveOffer();
        }

        public async Task<ResultModel> ActiveInActiveOffer(OfferIDEntity entity)
        {
            return await repository.ActiveInActiveOffer(entity);
        }
        public async Task<ResultModel> OfferImageUpdate(string? ImageUpload, int? ID, int? UpdatedBy)
        {
            return await repository.OfferImageUpdate(ImageUpload, ID, UpdatedBy);
        }
        public async Task<OfferViewEntity> FindByCouponCode(OfferIDEntity entity)
        {
            return await repository.FindByCouponCode(entity);
        }
        public async Task<List<OfferViewEntity>> GetAllAvailableOffers()
        {
            return await repository.GetAllAvailableOffers();
        }

    }
}
