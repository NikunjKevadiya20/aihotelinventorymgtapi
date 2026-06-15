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
    public class BlogFAQRepository : IBlogFAQRepository
    {
        IBlogFAQLookupRepositoryInterface repository;
        public BlogFAQRepository(IBlogFAQLookupRepositoryInterface _repository)
        {
            repository = _repository;
        }

        public async Task<ResultModel> InsertBlogFAQ(BlogFAQEntity entity)
        {
            return await repository.InsertBlogFAQ(entity, "sp_ManageBlogFAQInsert");
        }
        public async Task<ResultModel> UpdateBlogFAQ(BlogFAQEntity entity)
        {
            return await repository.UpdateBlogFAQ(entity, "sp_ManageBlogFAQInsert");
        }
        public async Task<ResultModel> DeleteBlogFAQ(BlogFAQIDEntity entity)
        {
            return await repository.DeleteBlogFAQ(entity, "sp_ManageBlogFAQFindDelete");
        }
        public async Task<BlogFAQDataViewEntity> FindByIDBlogFAQ(BlogFAQIDEntity entity)
        {
            return await repository.FindByIDBlogFAQ(entity, "sp_ManageBlogFAQFindDelete");
        }
        public async Task<List<BlogFAQDataViewEntity>> FindAllBlogFAQ(BlogFAQIDEntity entity)
        {
            return await repository.FindAllBlogFAQ(entity, "sp_ManageBlogFAQFindAll");
        }
        public async Task<List<BlogFAQDataViewEntity>> FindAllActiveBlogFAQ()
        {
            return await repository.FindAllActiveBlogFAQ("sp_ManageBlogFAQFindAll");
        }
        public async Task<ResultModel> ActiveInActiveBlogFAQ(BlogFAQIDEntity entity)
        {
            return await repository.ActiveInActiveBlogFAQ(entity, "sp_ManageBlogFAQFindDelete");
        }

    }
}
