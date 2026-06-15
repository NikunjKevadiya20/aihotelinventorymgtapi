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
    public class TestimonialRepository : ITestimonialRepository
    {
        ITestimonialLookupRepositoryInterface repository;
        public TestimonialRepository(ITestimonialLookupRepositoryInterface _repository)
        {
            repository = _repository;
        }

        public async Task<TestimonialIDViewEntity> InsertTestimonial(TestimonialEntity entity)
        {
            return await repository.InsertTestimonial(entity, "sp_ManageTestimonialsInsert");
        }
        public async Task<ResultModel> UpdateTestimonial(TestimonialEntity entity)
        {
            return await repository.UpdateTestimonial(entity, "sp_ManageTestimonialsInsert");
        }
        public async Task<ResultModel> DeleteTestimonial(TestimonialIDEntity entity)
        {
            return await repository.DeleteTestimonial(entity, "sp_ManageTestimonialsFindDelete");
        }
        public async Task<TestimonialDataViewEntity> FindByIDTestimonial(TestimonialIDEntity entity)
        {
            return await repository.FindByIDTestimonial(entity, "sp_ManageTestimonialsFindDelete");
        }
        public async Task<List<TestimonialDataViewEntity>> FindAllTestimonial(TestimonialIDEntity entity)
        {
            return await repository.FindAllTestimonial(entity, "sp_ManageTestimonialsFindDelete");
        }
        public async Task<List<TestimonialDataViewEntity>> FindAllActiveTestimonial()
        {
            return await repository.FindAllActiveTestimonial("sp_ManageTestimonialsFindDelete");
        }
        public async Task<ResultModel> ActiveInActiveTestimonial(TestimonialIDEntity entity)
        {
            return await repository.ActiveInActiveTestimonial(entity, "sp_ManageTestimonialsFindDelete");
        }
        public async Task<ResultModel> TestimonialImageUpdate(string? physicalFileName, int? ID, int? UpdatedBy)
        {
            return await repository.TestimonialImageUpdate(physicalFileName, ID, UpdatedBy, "sp_ManageTestimonialsInsert");
        }
        public async Task<List<TestimonialDataViewEntity>> FindAllActiveTestimonialURL(TestimonialIDEntity entity)
        {
            return await repository.FindAllActiveTestimonialURL(entity, "sp_ManageTestimonialsFindDelete");
        }
    }
}
