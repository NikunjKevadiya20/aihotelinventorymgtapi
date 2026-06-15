using HotelBooking.DataAccess.Interfaces;
using HotelBooking.Domain.Interfaces;
using HotelBooking.Entity.Common.Entities;
using HotelBooking.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBooking.Domain.Domain
{
    public class AmountBaseGSTDomain : IAmountBaseGSTDomain
    {
        IAmountBaseGSTRepository repository;
        public AmountBaseGSTDomain(IAmountBaseGSTRepository _repository)
        {
            repository = _repository;
        }

        public async Task<ResultModel> InsertAmountBaseGST(AmountBaseGSTEntity entity)
        {
            return await repository.InsertAmountBaseGST(entity);
        }

        public async Task<ResultModel> UpdateAmountBaseGST(AmountBaseGSTEntity entity)
        {
            return await repository.UpdateAmountBaseGST(entity);
        }

        public async Task<ResultModel> DeleteAmountBaseGST(AmountBaseGSTIDEntity entity)
        {
            return await repository.DeleteAmountBaseGST(entity);
        }
        public async Task<AmountBaseGSTViewEntity> FindByIDAmountBaseGST(AmountBaseGSTIDEntity entity)
        {
            return await repository.FindByIDAmountBaseGST(entity);
        }
        public async Task<List<AmountBaseGSTViewEntity>> FindAllAmountBaseGST(AmountBaseGSTIDEntity entity)
        {
            return await repository.FindAllAmountBaseGST(entity);
        }
        public async Task<List<AmountBaseGSTViewEntity>> FindAllActiveAmountBaseGST()
        {
            return await repository.FindAllActiveAmountBaseGST();
        }

        public async Task<ResultModel> ActiveInActiveAmountBaseGST(AmountBaseGSTIDEntity entity)
        {
            return await repository.ActiveInActiveAmountBaseGST(entity);
        }
        



    }
}
