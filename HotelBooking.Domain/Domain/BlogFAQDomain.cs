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
    public class BlogFAQDomain : IBlogFAQDomain
    {
        IBlogFAQRepository repository;
        public BlogFAQDomain(IBlogFAQRepository _repository)
        {
            repository = _repository;
        }

        public async Task<ResultModel> InsertBlogFAQ(BlogFAQEntity entity)
        {
            return await repository.InsertBlogFAQ(entity);
        }
        public async Task<ResultModel> UpdateBlogFAQ(BlogFAQEntity entity)
        {
            return await repository.UpdateBlogFAQ(entity);
        }
        public async Task<ResultModel> DeleteBlogFAQ(BlogFAQIDEntity entity)
        {
            return await repository.DeleteBlogFAQ(entity);
        }
        public async Task<BlogFAQDataViewEntity> FindByIDBlogFAQ(BlogFAQIDEntity entity)
        {
            return await repository.FindByIDBlogFAQ(entity);
        }
        public async Task<List<BlogFAQDataViewEntity>> FindAllBlogFAQ(BlogFAQIDEntity entity)
        {
            return await repository.FindAllBlogFAQ(entity);
        }
        public async Task<List<BlogFAQDataViewEntity>> FindAllActiveBlogFAQ()
        {
            return await repository.FindAllActiveBlogFAQ();
        }
        public async Task<ResultModel> ActiveInActiveBlogFAQ(BlogFAQIDEntity entity)
        {
            return await repository.ActiveInActiveBlogFAQ(entity);
        }
    }
}
