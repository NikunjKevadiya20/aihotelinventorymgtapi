using HotelBooking.DataAccess.Base;
using HotelBooking.DataAccess.Interfaces;
using HotelBooking.Entity.Common.Entities;
using HotelBooking.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static HotelBooking.Entity.Entities.OfferIDEntity;

namespace HotelBooking.DataAccess.Repositories
{
    public class OfferRepository : IOfferRepository
    {
        private readonly IOfferLookupRepositoryInterface repository;

        public OfferRepository(IOfferLookupRepositoryInterface _repository)
        {
            repository = _repository;
        }

        public async Task<OfferIDViewEntity> InsertOffer(OfferEntity entity)
        {
            return await repository.InsertOffer(entity, "sp_ManageOfferInsert");
        }

        public async Task<ResultModel> UpdateOffer(OfferEntity entity)
        {
            return await repository.UpdateOffer(entity, "sp_ManageOfferInsert");
        }

        public async Task<ResultModel> DeleteOffer(OfferIDEntity entity)
        {
            return await repository.DeleteOffer(entity, "sp_ManageOfferFindDelete");
        }

        public async Task<OfferDataViewEntity> FindByIDOffer(OfferIDEntity entity)
        {
            return await repository.FindByIDOffer(entity, "sp_ManageOfferFindDelete");
        }

        public async Task<List<OfferDataViewEntity>> FindAllOffer(OfferIDEntity entity)
        {
            return await repository.FindAllOffer(entity, "sp_ManageOfferFindAll");
        }

        public async Task<List<OfferDataViewEntity>> FindAllActiveOffer()
        {
            return await repository.FindAllActiveOffer("sp_ManageOfferFindAll");
        }

        public async Task<ResultModel> ActiveInActiveOffer(OfferIDEntity entity)
        {
            return await repository.ActiveInActiveOffer(entity, "sp_ManageOfferFindDelete");
        }

        public async Task<ResultModel> OfferImageUpdate(string? ImageUpload, int? ID, int? UpdatedBy)
        {
            return await repository.OfferImageUpdate(ImageUpload, ID, UpdatedBy, "sp_ManageOfferInsert");
        }
        public async Task<OfferViewEntity> FindByCouponCode(OfferIDEntity entity)
        {
            return await repository.FindByCouponCode(entity, "sp_ManageOrderFindByID");
        }
        public async Task<List<OfferViewEntity>> GetAllAvailableOffers()
        {
            return await repository.GetAllAvailableOffers("sp_ManageOfferFindDelete");
        }
    }
}
