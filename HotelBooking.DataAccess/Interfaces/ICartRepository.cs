using HotelBooking.Entity.Common.Entities;
using HotelBooking.Entity.Common.Entities;
using HotelBooking.Entity.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HotelBooking.DataAccess.Interfaces
{
    public interface ICartRepository
    {
        Task<ResultModel> InsertCartPaxDetails(CartEntity entity);
        Task<ResultModel> UpdateCartPaxDetails(CartEntity entity);
        Task<ResultModel> DeleteCartPaxDetails(CartIDEntity entity);
        Task<CartEntity> FindByIDCartPaxDetails(CartIDEntity entity);

        // Cart operations
        Task<ResultModel> AddToCart(CartDataEntity entity);
        Task<ResultModel> DeleteCart(CartDataEntity entity);

        Task<CartDetailsResponseEntity> GetCartDetails(CartDetailsRequestEntity entity);
        Task<ResultModel> UpdateTicketQuantity(CartDataEntity entity);
        Task<ResultModel> UpdateHotelQuantity(CartDataEntity entity);
    }
}
