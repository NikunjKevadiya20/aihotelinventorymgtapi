using HotelBooking.Entity.Common.Entities;
using HotelBooking.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBooking.DataAccess.Interfaces
{
    public interface ITestimonialRepository
    {
        Task<TestimonialIDViewEntity> InsertTestimonial(TestimonialEntity entity);
        Task<ResultModel> UpdateTestimonial(TestimonialEntity entity);
        Task<ResultModel> DeleteTestimonial(TestimonialIDEntity entity);
        Task<TestimonialDataViewEntity> FindByIDTestimonial(TestimonialIDEntity entity);
        Task<List<TestimonialDataViewEntity>> FindAllTestimonial(TestimonialIDEntity entity);
        Task<List<TestimonialDataViewEntity>> FindAllActiveTestimonial();
        Task<ResultModel> ActiveInActiveTestimonial(TestimonialIDEntity entity);
        Task<ResultModel> TestimonialImageUpdate(string? physicalFileName, int? ID, int? UpdatedBy);
        Task<List<TestimonialDataViewEntity>> FindAllActiveTestimonialURL(TestimonialIDEntity entity);
    }
}
