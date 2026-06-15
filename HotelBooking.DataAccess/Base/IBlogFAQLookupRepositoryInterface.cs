using HotelBooking.Entity.Common.Entities;
using HotelBooking.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBooking.DataAccess.Base
{
    public interface IBlogFAQLookupRepositoryInterface
    {
        Task<ResultModel> InsertBlogFAQ(BlogFAQEntity entity, string storedProcedure);
        Task<ResultModel> UpdateBlogFAQ(BlogFAQEntity entity, string storedProcedure);
        Task<ResultModel> DeleteBlogFAQ(BlogFAQIDEntity entity, string storedProcedure);
        Task<BlogFAQDataViewEntity> FindByIDBlogFAQ(BlogFAQIDEntity entity, string storedProcedure);
        Task<List<BlogFAQDataViewEntity>> FindAllBlogFAQ(BlogFAQIDEntity entity, string storedProcedure);
        Task<List<BlogFAQDataViewEntity>> FindAllActiveBlogFAQ(string storedProcedure);
        Task<ResultModel> ActiveInActiveBlogFAQ(BlogFAQIDEntity entity, string storedProcedure);
    }
}
