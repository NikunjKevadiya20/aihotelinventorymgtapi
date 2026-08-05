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
    public class CompanyProfileDomain : ICompanyProfileDomain
    {
        private readonly ICompanyProfileRepository _repository;
        public CompanyProfileDomain(ICompanyProfileRepository repository)
        {
            _repository = repository;
        }
        public async Task<ResultModel> InsertCompanyProfile(CompanyProfile entity)
        {
            return await _repository.InsertCompanyProfile(entity);
        }
        public async Task<CompanyProfile> GetCompanyProfile()
        {
            return await _repository.GetCompanyProfile();
        }
        public async Task<ResultModel> CompanyProfileImageUpdate(string? Image, int? UpdatedBy )
        {
            return await _repository.CompanyProfileImageUpdate(Image,  UpdatedBy);
        }
    }
}
