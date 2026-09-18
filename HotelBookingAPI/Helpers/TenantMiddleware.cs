using System.Data.SqlClient;
using System.Text.Json;
using Dapper;
using HotelBooking.DataAccess.Base;
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
            IRedisService redis,
            IConfiguration configuration)
        {
            // Existing URL Header
            var website = context.Request.Headers["URL"]
                .FirstOrDefault()?.Trim().ToLower();

            //var website = "29397";

            // New PropertyId Header
            var propertyId = context.Request.Headers["PropertyId"]
                .FirstOrDefault()?.Trim();

            //var propertyId = "SoLfcrS22qs1fMR4VJWbRYSuAOIImpP6";

            // Either URL or PropertyId is required
            if (string.IsNullOrEmpty(website) &&
                string.IsNullOrEmpty(propertyId))
            {
                context.Response.StatusCode = 400;
                await context.Response.WriteAsync(
                    "URL or PropertyId Header Missing");
                return;
            }

            // Don't allow both
            if (!string.IsNullOrEmpty(website) &&
                !string.IsNullOrEmpty(propertyId))
            {
                context.Response.StatusCode = 400;
                await context.Response.WriteAsync(
                    "Please pass either URL or PropertyId, not both");
                return;
            }

            TenantInfo tenant = null;

            // =========================================================
            // URL FLOW - EXISTING
            // =========================================================
            if (!string.IsNullOrEmpty(website))
            {
                var cacheKey = $"TENANT:{website}";

                var cacheData = await redis.GetAsync(cacheKey);

                // Redis Miss
                if (string.IsNullOrEmpty(cacheData))
                {
                    using var con = new SqlConnection(
                        configuration.GetConnectionString("TemplateConnection"));

                    tenant = await con.QueryFirstOrDefaultAsync<TenantInfo>(
                        @"
                        SELECT
                            ID,
                            Website,
                            PropertyId,
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
                        await context.Response.WriteAsync(
                            "Tenant Not Found");
                        return;
                    }

                    // Save in Redis
                    await redis.SetAsync(
                        cacheKey,
                        JsonSerializer.Serialize(tenant));
                }
                else
                {
                    tenant =
                        JsonSerializer.Deserialize<TenantInfo>(cacheData);
                }
            }

            // =========================================================
            // PROPERTY ID FLOW - NEW
            // =========================================================
            else if (!string.IsNullOrEmpty(propertyId))
            {
                var cacheKey = $"TENANT:PROPERTY:{propertyId}";

                var cacheData = await redis.GetAsync(cacheKey);

                // Redis Miss
                if (string.IsNullOrEmpty(cacheData))
                {
                    using var con = new SqlConnection(
                        configuration.GetConnectionString("TemplateConnection"));

                    tenant = await con.QueryFirstOrDefaultAsync<TenantInfo>(
                        @"
                        SELECT
                            ID,
                            Website,
                            PropertyId,
                            DatabaseName,
                            ServerName,
                            UserName,
                            Password,
                            OrganizationCode,
                            OrganizationName
                        FROM tblOrganization
                        WHERE PropertyId = @PropertyId
                        AND IsActive = 1
                        AND IsDeleted = 0",
                        new
                        {
                            PropertyId = propertyId
                        });

                    if (tenant == null)
                    {
                        context.Response.StatusCode = 404;
                        await context.Response.WriteAsync(
                            "Tenant Not Found");
                        return;
                    }

                    // Save in Redis
                    await redis.SetAsync(
                        cacheKey,
                        JsonSerializer.Serialize(tenant));
                }
                else
                {
                    tenant =
                        JsonSerializer.Deserialize<TenantInfo>(cacheData);
                }
            }

            // Store Tenant
            context.Items["Tenant"] = tenant;

            await _next(context);
        }
    }
}