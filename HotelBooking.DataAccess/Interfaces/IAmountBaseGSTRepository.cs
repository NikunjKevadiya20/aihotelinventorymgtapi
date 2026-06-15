using HotelBooking.Entity.Common.Entities;
using HotelBooking.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBooking.DataAccess.Interfaces
{
    public interface IAmountBaseGSTRepository
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
