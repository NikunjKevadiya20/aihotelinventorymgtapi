using HotelBooking.DataAccess.Base;
using HotelBooking.DataAccess.Interfaces;
using HotelBooking.Entity.Common.Entities;
using HotelBooking.Entity.Entities;
using System.Threading.Tasks;

namespace HotelBooking.DataAccess.Repositories
{
    public class CartRepository : ICartRepository
    {
        ICartLookupRepositoryInterface repository;

        public CartRepository(ICartLookupRepositoryInterface _repository)
        {
            repository = _repository;
        }

        public async Task<ResultModel> InsertCartPaxDetails(CartEntity entity)
        {
            return await repository.InsertCartPaxDetails(entity, "sp_ManageCartPaxDetails");
        }

        public async Task<ResultModel> UpdateCartPaxDetails(CartEntity entity)
        {
            return await repository.UpdateCartPaxDetails(entity, "sp_ManageCartPaxDetails");
        }

        public async Task<ResultModel> DeleteCartPaxDetails(CartIDEntity entity)
        {
            return await repository.DeleteCartPaxDetails(entity, "sp_ManageCartPaxDetails");
        }

        public async Task<CartEntity> FindByIDCartPaxDetails(CartIDEntity entity)
        {
            return await repository.FindByIDCartPaxDetails(entity, "sp_ManageCartPaxDetails");
        }

        public async Task<CartDetailsResponseEntity> GetCartDetails(CartDetailsRequestEntity entity)
        {
            return await repository.GetCartDetails(entity, "sp_ManageCartDetails");
        }

        public async Task<ResultModel> AddToCart(CartDataEntity entity)
        {
            return await repository.AddToCart(entity, "sp_ManageCart");
        }

        public async Task<ResultModel> DeleteCart(CartDataEntity entity)
        {
            return await repository.DeleteCart(entity, "sp_ManageCart");
        }
        public async Task<ResultModel> UpdateTicketQuantity(CartDataEntity entity )
        {
            return await repository.UpdateTicketQuantity(entity, "sp_ManageCart");
        }
        public async Task<ResultModel> UpdateHotelQuantity(CartDataEntity entity )
        {
            return await repository.UpdateHotelQuantity(entity, "sp_ManageCart");
        }
    }
}
