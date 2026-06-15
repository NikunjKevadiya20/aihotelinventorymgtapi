using HotelBooking.Entity.Common.Entities;
using HotelBooking.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBooking.DataAccess.Base
{
    public interface IAmountBaseGSTLookupRepositoryInterface
    {
        Task<ResultModel> InsertAmountBaseGST(AmountBaseGSTEntity entity, string storedProcedure);
        Task<ResultModel> UpdateAmountBaseGST(AmountBaseGSTEntity entity, string storedProcedure);
        Task<ResultModel> DeleteAmountBaseGST(AmountBaseGSTIDEntity entity, string storedProcedure);
        Task<AmountBaseGSTViewEntity> FindByIDAmountBaseGST(AmountBaseGSTIDEntity entity, string storedProcedure);
        Task<List<AmountBaseGSTViewEntity>> FindAllAmountBaseGST(AmountBaseGSTIDEntity entity, string storedProcedure);
        Task<List<AmountBaseGSTViewEntity>> FindAllActiveAmountBaseGST(string storedProcedure);

        Task<ResultModel> ActiveInActiveAmountBaseGST(AmountBaseGSTIDEntity entity, string storedProcedure);


    }
}
