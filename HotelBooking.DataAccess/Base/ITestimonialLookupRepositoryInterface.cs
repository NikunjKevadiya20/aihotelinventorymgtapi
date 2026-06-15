using HotelBooking.Entity.Common.Entities;
using HotelBooking.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBooking.DataAccess.Base
{
    public interface ITestimonialLookupRepositoryInterface
    {
        Task<TestimonialIDViewEntity> InsertTestimonial(TestimonialEntity entity, string storedProcedure);
        Task<ResultModel> UpdateTestimonial(TestimonialEntity entity, string storedProcedure);
        Task<ResultModel> DeleteTestimonial(TestimonialIDEntity entity, string storedProcedure);
        Task<TestimonialDataViewEntity> FindByIDTestimonial(TestimonialIDEntity entity, string storedProcedure);
        Task<List<TestimonialDataViewEntity>> FindAllTestimonial(TestimonialIDEntity entity, string storedProcedure);
        Task<List<TestimonialDataViewEntity>> FindAllActiveTestimonial(string storedProcedure);
        Task<ResultModel> ActiveInActiveTestimonial(TestimonialIDEntity entity, string storedProcedure);
        Task<ResultModel> TestimonialImageUpdate(string? physicalFileName, int? ID, int? UpdatedBy, string storedProcedure);
        Task<List<TestimonialDataViewEntity>> FindAllActiveTestimonialURL(TestimonialIDEntity entity, string storedProcedure);
    }
}
