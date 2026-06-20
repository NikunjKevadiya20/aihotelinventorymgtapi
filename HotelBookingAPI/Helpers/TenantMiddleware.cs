using System.Data.SqlClient;
using System.Text.Json;
using Dapper;
using HotelBooking.DataAccess.Base;
using HotelBooking.Entity.Entities;

namespace HotelBooking.Helpers
{
    //public class TenantMiddleware
    //{
    //    private readonly RequestDelegate _next;

    //    public TenantMiddleware(RequestDelegate next)
    //    {
    //        _next = next;
    //    }

    //    public async Task Invoke(
    //        HttpContext context,
    //        IRedisService redis)
    //    {
    //        var host =
    //            context.Request.Host.Host.ToLower();
    //        //var host = "www.priyamhotels.com";

    //        var cacheData =
    //            await redis.GetAsync($"TENANT:{host}");

    //        if (string.IsNullOrEmpty(cacheData))
    //        {
    //            context.Response.StatusCode = 404;
    //            await context.Response.WriteAsync("Tenant Not Found");
    //            return;
    //        }

    //        var tenant =
    //            JsonSerializer.Deserialize<TenantInfo>(cacheData);

    //        context.Items["Tenant"] = tenant;

    //        await _next(context);
    //    }
    //}

    public class TenantMiddleware
    {
        private readonly RequestDelegate _next;

        public TenantMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(
            HttpContext context,
            IRedisService redis,
            IConfiguration configuration)
        {
            var website = context.Request.Headers["URL"]
     .FirstOrDefault()?.Trim().ToLower();

            if (string.IsNullOrEmpty(website))
            {
                context.Response.StatusCode = 400;
                await context.Response.WriteAsync("URL Header Missing");
                return;
            }

            var cacheData =
    await redis.GetAsync($"TENANT:{website}");

            TenantInfo tenant = null;

            // Redis Miss
            if (string.IsNullOrEmpty(cacheData))
            {
                using var con = new SqlConnection(
                    configuration.GetConnectionString("TemplateConnection"));

                tenant = await con.QueryFirstOrDefaultAsync<TenantInfo>(
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
                        new { Website = website });

                if (tenant == null)
                {
                    context.Response.StatusCode = 404;
                    await context.Response.WriteAsync("Tenant Not Found");
                    return;
                }

                // Save in Redis
                await redis.SetAsync(
                    $"TENANT:{website}",
                    JsonSerializer.Serialize(tenant));
            }
            else
            {
                tenant =
                    JsonSerializer.Deserialize<TenantInfo>(cacheData);
            }

            context.Items["Tenant"] = tenant;

            await _next(context);
        }
    }
}
