using HotelBooking.Entity.Common.Entities;
using HotelBooking.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBooking.DataAccess.Base
{
    public interface ICompanyProfileLookupRepositoryInterface
    {
        Task<ResultModel> InsertCompanyProfile(CompanyProfile entity, string storedProcedure);
        Task<CompanyProfile> GetCompanyProfile(string storedProcedure);
        Task<ResultModel> CompanyProfileImageUpdate(string? Image, int? UpdatedBy, string storedProcedure);
    }
}
