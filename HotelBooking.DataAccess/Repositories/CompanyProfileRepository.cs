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
    public class CompanyProfileRepository : ICompanyProfileRepository
    {
        private readonly ICompanyProfileLookupRepositoryInterface _lookupRepository;
        public CompanyProfileRepository(ICompanyProfileLookupRepositoryInterface lookupRepository)
        {
            _lookupRepository = lookupRepository;
        }
        public async Task<ResultModel> InsertCompanyProfile(CompanyProfile entity)
        {
            return await _lookupRepository.InsertCompanyProfile(entity, "sp_ManageCompanyProfile");
        }
        public async Task<CompanyProfile> GetCompanyProfile()
        {
            return await _lookupRepository.GetCompanyProfile("sp_ManageCompanyProfile");
        }
        public async Task<ResultModel> CompanyProfileImageUpdate(string? Image, int? UpdatedBy)
        {
            return await _lookupRepository.CompanyProfileImageUpdate(Image, UpdatedBy,"sp_ManageCompanyProfile");
        }
    }
}
