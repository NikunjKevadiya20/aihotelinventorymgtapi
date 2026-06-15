using HotelBooking.Entity.Common.Entities;
using HotelBooking.Entity.Entities;

namespace HotelBooking.DataAccess.Base
{
    public interface ICartLookupRepositoryInterface
    {
        Task<ResultModel> InsertCartPaxDetails(CartEntity entity, string storedProcedure);
        Task<ResultModel> UpdateCartPaxDetails(CartEntity entity, string storedProcedure);
        Task<ResultModel> DeleteCartPaxDetails(CartIDEntity entity, string storedProcedure);
        Task<CartEntity> FindByIDCartPaxDetails(CartIDEntity entity, string storedProcedure);

        // Cart operations using sp_ManageCart
        Task<ResultModel> AddToCart(CartDataEntity entity, string storedProcedure);
        Task<ResultModel> DeleteCart(CartDataEntity entity, string storedProcedure);
        Task<CartDetailsResponseEntity> GetCartDetails(CartDetailsRequestEntity entity, string storedProcedure);
        Task<ResultModel> UpdateTicketQuantity(CartDataEntity entity, string storedProcedure);
        Task<ResultModel> UpdateHotelQuantity(CartDataEntity entity, string storedProcedure);
    }
}
