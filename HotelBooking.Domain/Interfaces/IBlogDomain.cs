using HotelBooking.Entity.Common.Entities;
using HotelBooking.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBooking.Domain.Interfaces
{
    public interface IBlogDomain
    {
        Task<BlogIDViewEntity> InsertBlog(BlogEntity entity);
        Task<ResultModel> UpdateBlog(BlogEntity entity);
        Task<ResultModel> DeleteBlog(BlogIDEntity entity);
        Task<BlogDataViewEntity> FindByIDBlog(BlogIDEntity entity);
        Task<List<BlogDataViewEntity>> FindAllBlog(BlogIDEntity entity);
        Task<List<BlogDataViewEntity>> FindAllActiveBlog();
        Task<ResultModel> ActiveInActiveBlog(BlogIDEntity entity);
        Task<ResultModel> BlogImageUpdate(string? Image, string? BlogBannerImage, int? ID, int? UpdatedBy);
        Task<BlogListEntity> BlogFindByURL(BlogUrlEntity entity);

    }
}
