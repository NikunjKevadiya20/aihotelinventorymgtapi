using HotelBooking.DataAccess.Interfaces;
using HotelBooking.Domain.Interfaces;
using HotelBooking.Entity.Common.Entities;
using HotelBooking.Entity.Entities;
using System.Threading.Tasks;

namespace HotelBooking.Domain.Domain
{
    public class CartDomain : ICartDomain
    {
        private readonly ICartRepository repository;

        public CartDomain(ICartRepository _repository)
        {
            repository = _repository;
        }

        public async Task<ResultModel> InsertCartPaxDetails(CartEntity entity)
        {
            return await repository.InsertCartPaxDetails(entity);
        }

        public async Task<ResultModel> UpdateCartPaxDetails(CartEntity entity)
        {
            return await repository.UpdateCartPaxDetails(entity);
        }

        public async Task<ResultModel> DeleteCartPaxDetails(CartIDEntity entity)
        {
            return await repository.DeleteCartPaxDetails(entity);
        }

        public async Task<CartEntity> FindByIDCartPaxDetails(CartIDEntity entity)
        {
            return await repository.FindByIDCartPaxDetails(entity);
        }

        public async Task<ResultModel> AddToCart(CartDataEntity entity)
        {
            return await repository.AddToCart(entity);
        }

        public async Task<ResultModel> DeleteCart(CartDataEntity entity)
        {
            return await repository.DeleteCart(entity);
        }

        public async Task<CartDetailsResponseEntity> GetCartDetails(CartDetailsRequestEntity entity)
        {
            return await repository.GetCartDetails(entity);
        }
        public async Task<ResultModel> UpdateTicketQuantity(CartDataEntity entity)
        {
            return await repository.UpdateTicketQuantity(entity);
        }
        public async Task<ResultModel> UpdateHotelQuantity(CartDataEntity entity)
        {
            return await repository.UpdateHotelQuantity(entity);
        }
    }
}
