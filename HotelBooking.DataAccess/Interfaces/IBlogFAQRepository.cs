using HotelBooking.Entity.Common.Entities;
using HotelBooking.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBooking.DataAccess.Interfaces
{
    public interface IBlogFAQRepository
    {
        Task<ResultModel> InsertBlogFAQ(BlogFAQEntity entity);
        Task<ResultModel> UpdateBlogFAQ(BlogFAQEntity entity);
        Task<ResultModel> DeleteBlogFAQ(BlogFAQIDEntity entity);
        Task<BlogFAQDataViewEntity> FindByIDBlogFAQ(BlogFAQIDEntity entity);
        Task<List<BlogFAQDataViewEntity>> FindAllBlogFAQ(BlogFAQIDEntity entity);
        Task<List<BlogFAQDataViewEntity>> FindAllActiveBlogFAQ();
        Task<ResultModel> ActiveInActiveBlogFAQ(BlogFAQIDEntity entity);
    }
}
