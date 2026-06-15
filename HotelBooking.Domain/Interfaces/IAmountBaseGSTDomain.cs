using HotelBooking.Entity.Common.Entities;
using HotelBooking.Entity.Entities;

namespace HotelBooking.Domain.Interfaces
{
    public interface IAmountBaseGSTDomain
    {
        Task<ResultModel> InsertAmountBaseGST(AmountBaseGSTEntity entity);

        Task<ResultModel> UpdateAmountBaseGST(AmountBaseGSTEntity entity);
        Task<ResultModel> DeleteAmountBaseGST(AmountBaseGSTIDEntity entity);

        Task<AmountBaseGSTViewEntity> FindByIDAmountBaseGST(AmountBaseGSTIDEntity entity);

        Task<List<AmountBaseGSTViewEntity>> FindAllAmountBaseGST(AmountBaseGSTIDEntity entity);
        Task<List<AmountBaseGSTViewEntity>> FindAllActiveAmountBaseGST();

        Task<ResultModel> ActiveInActiveAmountBaseGST(AmountBaseGSTIDEntity entity);


    }
}
