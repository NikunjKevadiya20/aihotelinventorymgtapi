using HotelBooking.Entity.Common.Entities;
using HotelBooking.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBooking.DataAccess.Base
{
    public interface IBlogLookupRepositoryInterface
    {
        Task<BlogIDViewEntity> InsertBlog(BlogEntity entity, string storedProcedure);
        Task<ResultModel> UpdateBlog(BlogEntity entity, string storedProcedure);
        Task<ResultModel> DeleteBlog(BlogIDEntity entity, string storedProcedure);
        Task<BlogDataViewEntity> FindByIDBlog(BlogIDEntity entity, string storedProcedure);
        Task<List<BlogDataViewEntity>> FindAllBlog(BlogIDEntity entity, string storedProcedure);
        Task<List<BlogDataViewEntity>> FindAllActiveBlog(string storedProcedure);
        Task<ResultModel> ActiveInActiveBlog(BlogIDEntity entity, string storedProcedure);
        Task<ResultModel> BlogImageUpdate(string? Image, string? BlogBannerImage, int? ID, int? UpdatedBy, string storedProcedure);
        Task<BlogListEntity> BlogFindByURL(BlogUrlEntity entity, string storedProcedure);
    }
}
