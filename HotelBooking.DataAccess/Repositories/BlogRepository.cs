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
    public class BlogRepository : IBlogRepository
    {
        IBlogLookupRepositoryInterface repository;
        public BlogRepository(IBlogLookupRepositoryInterface _repository)
        {
            repository = _repository;
        }

        public async Task<BlogIDViewEntity> InsertBlog(BlogEntity entity)
        {
            return await repository.InsertBlog(entity, "sp_ManageBlogsInsert");
        }
        public async Task<ResultModel> UpdateBlog(BlogEntity entity)
        {
            return await repository.UpdateBlog(entity, "sp_ManageBlogsInsert");
        }
        public async Task<ResultModel> DeleteBlog(BlogIDEntity entity)
        {
            return await repository.DeleteBlog(entity, "sp_ManageBlogsFindDelete");
        }
        public async Task<BlogDataViewEntity> FindByIDBlog(BlogIDEntity entity)
        {
            return await repository.FindByIDBlog(entity, "sp_ManageBlogsFindDelete");
        }
        public async Task<List<BlogDataViewEntity>> FindAllBlog(BlogIDEntity entity)
        {
            return await repository.FindAllBlog(entity, "sp_ManageBlogsFindDelete");
        }
        public async Task<List<BlogDataViewEntity>> FindAllActiveBlog()
        {
            return await repository.FindAllActiveBlog("sp_ManageBlogFindALL");
        }
        public async Task<ResultModel> ActiveInActiveBlog(BlogIDEntity entity)
        {
            return await repository.ActiveInActiveBlog(entity, "sp_ManageBlogsFindDelete");
        }
        public async Task<ResultModel> BlogImageUpdate(string? Image, string? BlogBannerImage, int? ID, int? UpdatedBy)
        {
            return await repository.BlogImageUpdate(Image, BlogBannerImage, ID, UpdatedBy, "sp_ManageBlogsInsert");
        }
        public async Task<BlogListEntity> BlogFindByURL(BlogUrlEntity entity)
        {
            return await repository.BlogFindByURL(entity, "sp_ManageBlogFindALL");
        }
    }
}
