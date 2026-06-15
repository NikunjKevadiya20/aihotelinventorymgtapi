using HotelBooking.DataAccess.Base;
using HotelBooking.DataAccess.Interfaces;
using HotelBooking.Entity.Common.Entities;
using HotelBooking.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBooking.DataAccess.Repositories
{
    public class AmountBaseGSTRepository : IAmountBaseGSTRepository
    {
        IAmountBaseGSTLookupRepositoryInterface repository;

        public AmountBaseGSTRepository(IAmountBaseGSTLookupRepositoryInterface _repository)
        {
            repository = _repository;
        }

        public async Task<ResultModel> InsertAmountBaseGST(AmountBaseGSTEntity entity)
        {
            return await repository.InsertAmountBaseGST(entity, "sp_ManageAmountBaseGSTInsert");
        }
        public async Task<ResultModel> UpdateAmountBaseGST(AmountBaseGSTEntity entity)
        {
            return await repository.UpdateAmountBaseGST(entity, "sp_ManageAmountBaseGSTInsert");
        }
        public async Task<ResultModel> DeleteAmountBaseGST(AmountBaseGSTIDEntity entity)
        {
            return await repository.DeleteAmountBaseGST(entity, "sp_ManageAmountBaseGSTFindByID");
        }
        public async Task<AmountBaseGSTViewEntity> FindByIDAmountBaseGST(AmountBaseGSTIDEntity entity)
        {
            return await repository.FindByIDAmountBaseGST(entity, "sp_ManageAmountBaseGSTFindByID");
        }

        public async Task<List<AmountBaseGSTViewEntity>> FindAllAmountBaseGST(AmountBaseGSTIDEntity entity)
        {
            return await repository.FindAllAmountBaseGST(entity, "sp_ManageAmountBaseGSTFindAll");
        }
        public async Task<List<AmountBaseGSTViewEntity>> FindAllActiveAmountBaseGST()
        {
            return await repository.FindAllActiveAmountBaseGST("sp_ManageAmountBaseGSTFindAll");
        }
        public async Task<ResultModel> ActiveInActiveAmountBaseGST(AmountBaseGSTIDEntity entity)
        {
            return await repository.ActiveInActiveAmountBaseGST(entity, "sp_ManageAmountBaseGSTFindByID");
        }


    }
}
