using HotelBooking.Entity.Common.Entities;
using HotelBooking.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBooking.DataAccess.Interfaces
{
    public interface IFAQRepository
    {
        Task<ResultModel> InsertFAQ(FAQEntity entity);
        Task<ResultModel> UpdateFAQ(FAQEntity entity);
        Task<ResultModel> DeleteFAQ(FAQIDEntity entity);
        Task<FAQDataViewEntity> FindByIDFAQ(FAQIDEntity entity);
        Task<List<FAQDataViewEntity>> FindAllFAQ(FAQIDEntity entity);
        Task<List<FAQDataViewEntity>> FindAllActiveFAQ();
        Task<ResultModel> ActiveInActiveFAQ(FAQIDEntity entity);
    }
}
