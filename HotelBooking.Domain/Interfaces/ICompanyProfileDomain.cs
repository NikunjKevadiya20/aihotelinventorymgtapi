using HotelBooking.Entity.Common.Entities;
using HotelBooking.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBooking.Domain.Interfaces
{
    public interface ICompanyProfileDomain
    {
        Task<ResultModel> InsertCompanyProfile(CompanyProfile entity);
        Task<CompanyProfile> GetCompanyProfile();
        Task<ResultModel> CompanyProfileImageUpdate(string? Image, int? UpdatedBy);
    }
}
