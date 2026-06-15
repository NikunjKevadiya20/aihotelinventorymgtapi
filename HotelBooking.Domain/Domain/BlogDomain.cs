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
    public class BlogDomain : IBlogDomain
    {
        IBlogRepository repository;
        public BlogDomain(IBlogRepository _repository)
        {
            repository = _repository;
        }

        public async Task<BlogIDViewEntity> InsertBlog(BlogEntity entity)
        {
            return await repository.InsertBlog(entity);
        }
        public async Task<ResultModel> UpdateBlog(BlogEntity entity)
        {
            return await repository.UpdateBlog(entity);
        }
        public async Task<ResultModel> DeleteBlog(BlogIDEntity entity)
        {
            return await repository.DeleteBlog(entity);
        }
        public async Task<BlogDataViewEntity> FindByIDBlog(BlogIDEntity entity)
        {
            return await repository.FindByIDBlog(entity);
        }
        public async Task<List<BlogDataViewEntity>> FindAllBlog(BlogIDEntity entity)
        {
            return await repository.FindAllBlog(entity);
        }
        public async Task<List<BlogDataViewEntity>> FindAllActiveBlog()
        {
            return await repository.FindAllActiveBlog();
        }
        public async Task<ResultModel> ActiveInActiveBlog(BlogIDEntity entity)
        {
            return await repository.ActiveInActiveBlog(entity);
        }
        public async Task<ResultModel> BlogImageUpdate(string? Image, string? BlogBannerImage, int? ID, int? UpdatedBy)
        {
            return await repository.BlogImageUpdate(Image, BlogBannerImage, ID, UpdatedBy);
        }
        public async Task<BlogListEntity> BlogFindByURL(BlogUrlEntity entity)
        {
            return await repository.BlogFindByURL(entity);
        }
    }
}
