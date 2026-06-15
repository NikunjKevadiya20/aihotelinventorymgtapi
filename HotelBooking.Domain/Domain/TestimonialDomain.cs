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
    public class TestimonialDomain : ITestimonialDomain
    {
        ITestimonialRepository repository;
        public TestimonialDomain(ITestimonialRepository _repository)
        {
            repository = _repository;
        }

        public async Task<TestimonialIDViewEntity> InsertTestimonial(TestimonialEntity entity)
        {
            return await repository.InsertTestimonial(entity);
        }
        public async Task<ResultModel> UpdateTestimonial(TestimonialEntity entity)
        {
            return await repository.UpdateTestimonial(entity);
        }
        public async Task<ResultModel> DeleteTestimonial(TestimonialIDEntity entity)
        {
            return await repository.DeleteTestimonial(entity);
        }
        public async Task<TestimonialDataViewEntity> FindByIDTestimonial(TestimonialIDEntity entity)
        {
            return await repository.FindByIDTestimonial(entity);
        }
        public async Task<List<TestimonialDataViewEntity>> FindAllTestimonial(TestimonialIDEntity entity)
        {
            return await repository.FindAllTestimonial(entity);
        }
        public async Task<List<TestimonialDataViewEntity>> FindAllActiveTestimonial()
        {
            return await repository.FindAllActiveTestimonial();
        }
        public async Task<ResultModel> ActiveInActiveTestimonial(TestimonialIDEntity entity)
        {
            return await repository.ActiveInActiveTestimonial(entity);
        }
        public async Task<ResultModel> TestimonialImageUpdate(string? physicalFileName, int? ID, int? UpdatedBy)
        {
            return await repository.TestimonialImageUpdate(physicalFileName, ID, UpdatedBy);
        }
        public async Task<List<TestimonialDataViewEntity>> FindAllActiveTestimonialURL(TestimonialIDEntity entity)
        {
            return await repository.FindAllActiveTestimonialURL(entity);
        }
    }
}
