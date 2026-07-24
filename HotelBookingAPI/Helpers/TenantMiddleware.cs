//using System.Data.SqlClient;
//using System.Text.Json;
//using Dapper;
//using HotelBooking.DataAccess.Base;
//using HotelBooking.Entity.Entities;

//namespace HotelBooking.Helpers
//{
//    public class TenantMiddleware
//    {
//        private readonly RequestDelegate _next;

//        public TenantMiddleware(RequestDelegate next)
//        {
//            _next = next;
//        }

//        public async Task Invoke(
//            HttpContext context,
//            IRedisService redis,
//            IConfiguration configuration)
//        {
//            var website = context.Request.Headers["URL"]
//     .FirstOrDefault()?.Trim().ToLower();

//            if (string.IsNullOrEmpty(website))
//            {
//                context.Response.StatusCode = 400;
//                await context.Response.WriteAsync("URL Header Missing");
//                return;
//            }

//            var cacheData =
//    await redis.GetAsync($"TENANT:{website}");

//            TenantInfo tenant = null;

//            // Redis Miss
//            if (string.IsNullOrEmpty(cacheData))
//            {
//                using var con = new SqlConnection(
//                    configuration.GetConnectionString("TemplateConnection"));

//                tenant = await con.QueryFirstOrDefaultAsync<TenantInfo>(
//                        @"SELECT
//                            ID,
//                            Website,
//                            DatabaseName,
//                            ServerName,
//                            UserName,
//                            Password,
//                            OrganizationCode,
//                            OrganizationName
//                        FROM tblOrganization
//                        WHERE Website = @Website
//                        AND IsActive = 1
//                        AND IsDeleted = 0",
//                        new { Website = website });

//                if (tenant == null)
//                {
//                    context.Response.StatusCode = 404;
//                    await context.Response.WriteAsync("Tenant Not Found");
//                    return;
//                }

//                // Save in Redis
//                await redis.SetAsync(
//                    $"TENANT:{website}",
//                    JsonSerializer.Serialize(tenant));
//            }
//            else
//            {
//                tenant =
//                    JsonSerializer.Deserialize<TenantInfo>(cacheData);
//            }

//            context.Items["Tenant"] = tenant;

//            await _next(context);
//        }
//    }
//}


using System.Data.SqlClient;
using Dapper;
using HotelBooking.Entity.Entities;

namespace HotelBooking.Helpers
{
    public class TenantMiddleware
    {
        private readonly RequestDelegate _next;

        public TenantMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(
            HttpContext context,
            IConfiguration configuration)
        {
            var website = context.Request.Headers["URL"]
                .FirstOrDefault()?
                .Trim()
                .ToLower();

            if (string.IsNullOrEmpty(website))
            {
                context.Response.StatusCode = 400;
                await context.Response.WriteAsync("URL Header Missing");
                return;
            }

            var templateConnectionString =
                configuration.GetConnectionString("TemplateConnection");

            if (string.IsNullOrEmpty(templateConnectionString))
            {
                context.Response.StatusCode = 500;
                await context.Response.WriteAsync(
                    "TemplateConnection is not configured.");
                return;
            }

            using var con = new SqlConnection(templateConnectionString);

            var tenant = await con.QueryFirstOrDefaultAsync<TenantInfo>(
                @"SELECT
                    ID,
                    Website,
                    DatabaseName,
                    ServerName,
                    UserName,
                    Password,
                    OrganizationCode,
                    OrganizationName
                  FROM tblOrganization
                  WHERE Website = @Website
                    AND IsActive = 1
                    AND IsDeleted = 0",
                new
                {
                    Website = website
                });

            if (tenant == null)
            {
                context.Response.StatusCode = 404;
                await context.Response.WriteAsync("Tenant Not Found");
                return;
            }

            context.Items["Tenant"] = tenant;

            await _next(context);
        }
    }
}
