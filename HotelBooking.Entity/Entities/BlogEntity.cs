using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBooking.Entity.Entities
{
    public class BlogEntity
    {
        public int? ID { get; set; }
        public string? Title { get; set; }
        public string? ShortDescription { get; set; }
        public string? Keyword { get; set; }
        public string? Description { get; set; }
        public string? BlogURL { get; set; }
        public string? MetaTitle { get; set; }
        public string? MetaDescription { get; set; }
        public DateTime? BlogDate { get; set; }
        public Boolean? IsActive { get; set; }
        public Int32? CreatedBy { set; get; }
        public Int32? UpdatedBy { set; get; }
        public string? Details { get; set; }
        public string? Message { get; set; }

    }
    public class BlogListEntity
    {
        public int? ID { get; set; }
        public string? BlogImage { get; set; }
        public string? BlogTitle { get; set; }
        public string? BlogDate { get; set; }
        public string? ShortDescription { get; set; }
        public string? LongDescription { get; set; }
        public string? BlogBannerImage { get; set; }
        public string? BlogURL { get; set; }
        public string? MetaTitle { get; set; }
        public string? MetaDescription { get; set; }
        public string? Keyword {  get; set; }
        public Boolean? IsActive { get; set; }
        public string Details { get; set; }
        public string Message { get; set; }
        public int Status { get; set; }
        public string ErrorMessage { get; set; }
        public BlogResultModel? blogResultModel { get; set; }
        public List<BlogFAQList>? BlogFAQList { get; set; }    

    }
    public class BlogResultModel
    {
        public string? MetaTitle { get; set; }
        public string? MetaDescription { get; set; }
        public string? MetaKeyword { get; set; }

    }
    public class BlogFAQList
    {
        public Int32 ID { set; get; }
        public int? BlogID { get; set; }
        public string? Question { get; set; }
        public string? Answer { get; set; }
        public int? SequenceNo { get; set; }
        public Boolean? IsActive { get; set; }

    }

    public class BlogIDEntity : MessageBaseEntity
    {
        public int? ID { get; set; }
        public string? Title { get; set; }
        public Int32? UpdatedBy { set; get; }
        public Boolean? IsActive { get; set; }
    }

    public class BlogDataViewEntity
    {
        public Int32 ID { set; get; }
        public string? Title { get; set; }
        public string? ShortDescription { get; set; }
        public string? Keyword { get; set; }
        public string? Description { get; set; }
        public string? MetaTitle { get; set; }
        public string? MetaDescription { get; set; }
        public string? BlogDate { get; set; }
        public string? Image { get; set; }
        public string? BlogBannerImage { get; set; }
        public string? BlogURL { get; set; }
        public Boolean? IsActive { get; set; }
        public string? Details { get; set; }
        public string? Message { get; set; }
        public int? Status { get; set; }
        public string? ErrorMessage { get; set; }

    }
    public class BlogImageDataEntity
    {
        public int? ID { get; set; }
        public IFormFile? Image { get; set; }
        public IFormFile? BlogBannerImage { get; set; }

    }

    public class BlogIDViewEntity : MessageBaseEntity
    {
        public int? ID { get; set; }
    }

    public class BlogUrlEntity
    {
        public string? BlogURL { get; set; }
    }
    public class BlogDataListEntity
    {
        public int? ID { get; set; }
        public string? BlogTitle { get; set; }
        public string? BlogDate { get; set; }
        public string? ShortDescription { get; set; }
        public string? LongDescription { get; set; }
        public string? BlogURL { get; set; }
        public string? MetaTitle { get; set; }
        public string? MetaDescription { get; set; }
        public string? BlogImage { get; set; }
        public int? Status { get; set; }
        public Boolean? IsActive { get; set; }
        public string Details { get; set; }
        public string Message { get; set; }

    }
}
