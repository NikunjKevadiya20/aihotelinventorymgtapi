using HotelBooking.Entity.Common.Entities;
using HotelBooking.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBooking.DataAccess.Base
{
    public interface IFAQLookupRepositoryInterface
    {
        Task<ResultModel> InsertFAQ(FAQEntity entity, string storedProcedure);
        Task<ResultModel> UpdateFAQ(FAQEntity entity, string storedProcedure);
        Task<ResultModel> DeleteFAQ(FAQIDEntity entity, string storedProcedure);
        Task<FAQDataViewEntity> FindByIDFAQ(FAQIDEntity entity, string storedProcedure);
        Task<List<FAQDataViewEntity>> FindAllFAQ(FAQIDEntity entity, string storedProcedure);
        Task<List<FAQDataViewEntity>> FindAllActiveFAQ(string storedProcedure);
        Task<ResultModel> ActiveInActiveFAQ(FAQIDEntity entity, string storedProcedure);
    }
}
