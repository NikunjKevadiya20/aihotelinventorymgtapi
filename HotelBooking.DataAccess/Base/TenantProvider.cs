using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelBooking.Entity.Entities;
using Microsoft.AspNetCore.Http;

namespace HotelBooking.DataAccess.Base
{
    public class TenantProvider : ITenantProvider
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public TenantProvider(
            IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public string GetConnectionString()
        {
            var tenant =
                (TenantInfo)_httpContextAccessor
                .HttpContext
                .Items["Tenant"];

            return
                $"Server={tenant.ServerName};" +
                $"Database={tenant.DatabaseName};" +
                $"User Id={tenant.UserName};" +
                $"Password={tenant.Password};" +
                $"TrustServerCertificate=True;";
        }
    }
}
 