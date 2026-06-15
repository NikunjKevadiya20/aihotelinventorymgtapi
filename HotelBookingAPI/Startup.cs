using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Text.Json;
using CorePush.Apple;
using CorePush.Google;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using HotelBooking.DataAccess.Base;
using HotelBooking.DI;
using HotelBooking.Entity.Common;
using HotelBooking.Entity.Common.Entities;
using HotelBooking.Entity.Common.Enums;
using HotelBooking.Helpers;


namespace HotelBooking
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {

            // Read the connection string from appsettings.
            string dbConnectionString = Configuration.GetConnectionString("DefaultConnection");

            // Inject IDbConnection, with implementation from SqlConnection class.
            services.AddScoped<IDbConnection>((sp) => new SqlConnection(dbConnectionString));

            //services.AddTransient<INotificationViewLookupRepositoryInterface, NotificationViewLookupRepository>();
            services.AddHttpClient<FcmSender>();
            services.AddHttpClient<ApnSender>();
            //         services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            //.AddJwtBearer(options =>
            //{
            //    options.TokenValidationParameters = new TokenValidationParameters
            //    {
            //        ValidateIssuer = true,
            //        ValidateAudience = true,
            //        ValidateLifetime = true,
            //        ValidateIssuerSigningKey = true,
            //        ValidIssuer = Configuration["Jwt:Issuer"],
            //        ValidAudience = Configuration["Jwt:Issuer"],
            //        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Jwt:Key"]))
            //    };
            //});

            services.AddAuthentication(options =>
            {
                // Keep JWT as default for existing endpoints
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
           .AddJwtBearer(options =>
           {
               options.TokenValidationParameters = new TokenValidationParameters
               {
                   ValidateIssuerSigningKey = true,
                   IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(CommonRepositoryConstants.SecretKey)),
                   ValidateIssuer = false,
                   ValidateAudience = false,
                   ClockSkew = TimeSpan.Zero
               };
               options.Events = new JwtBearerEvents
               {
                   OnAuthenticationFailed = async context =>
                   {
                       if (context.Request.Path.StartsWithSegments("/api/UserLogin/CheckRefreshToken"))
                       {
                           Console.WriteLine($"Bypassing JWT OnAuthenticationFailed for: {context.Request.Path}");
                           context.NoResult();
                           return;
                       }
                       Console.WriteLine($"JWT authentication failed for: {context.Request.Path}, Error: {context.Exception.Message}");
                       context.Response.StatusCode = 419;
                       context.Response.ContentType = "application/json";
                       var result = JsonSerializer.Serialize(new ResultModel
                       {
                           Status = (int)ResponseStatusCode.TokenExpired,
                           Message = "failed",
                           Details = context.Exception is SecurityTokenExpiredException ? "Token has expired." : "Invalid token.",
                           Data = string.Empty
                       });
                       await context.Response.WriteAsync(result);
                       await context.Response.CompleteAsync();
                   }
               };
           });
            var appSettingsSection = Configuration.GetSection("FcmNotification");

            services.AddTransient<BookingLookupRepository>();
            services.AddControllersWithViews();
            RegisterServices(services);
            services.AddControllers().AddJsonOptions(options => options.JsonSerializerOptions.PropertyNamingPolicy = null);
            SetupConfigKeys();
            //services.AddAutoMapper(typeof(ResultModelAutoMap));
            services.AddSwaggerGen(c =>
            {   
                c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "HotelBookingAPI", Version = "v1" });

                // To Enable authorization using Swagger (JWT)  
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Description = "JWT Authorization header using the Bearer scheme. \r\n\r\n Enter 'Bearer' [space] and then your token in the text input below.\r\n\r\nExample: \"Bearer 12345abcdef\"",
                });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                          new OpenApiSecurityScheme
                            {
                                Reference = new OpenApiReference
                                {
                                    Type = ReferenceType.SecurityScheme,
                                    Id = "Bearer"
                                }
                            },
                            new string[] {}

                    }
                });
            });

        }
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory loggerFactory)
        {
            if (env != null && env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                ConfigurationConstants.HostingEnv_ContentRootPath = env.ContentRootPath;
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "HotelBookingAPI v1"));

            }
            app.UseAuthentication();

            app.UseCors(x => x
            .AllowAnyMethod()
            .AllowAnyHeader()
            .SetIsOriginAllowed(origin => true) // allow any origin
            .AllowCredentials()); // allow credentials

            app.UseRouting();

            app.UseAuthorization();

            // custom jwt auth middleware
            app.UseMiddleware<JwtMiddleware>();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            // Add Static Files Middleware  
            //app.UseDefaultFiles();
            app.UseStaticFiles();

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            // Add Static Files Middleware  
            //app.UseDefaultFiles();
            app.UseStaticFiles();

            ///Open and Modified by AI003 on 14-12-2022
            //app.UseEndpoints(endpoints =>
            //{
            //    endpoints.MapControllerRoute(
            //        //name: "default",
            //        //pattern: "{controller=TestPDF}/{action=index}/{id?}"
            //        //);
            //        name: "default",
            //         pattern: "{controller=Home}/{action=Index}/{id?}");
            //});

            // app.Run();

            //Rotativa.AspNetCore.RotativaConfiguration.Setup(env);
        }

        private static void RegisterServices(IServiceCollection services)
        {
            DependencyContainer.RegisterServices(services);
        }

        private void SetupConfigKeys()
        {
            CommonRepositoryConstants.DefaultConnectionString = Configuration.GetConnectionString("DefaultConnection");



        }
    }
}