using System.IdentityModel.Tokens.Jwt;
using System.Text;
using System.Text.Json;
using Microsoft.IdentityModel.Tokens;
using HotelBooking.DataAccess.Base;
using HotelBooking.Entity.Common;
using HotelBooking.Entity.Common.Entities;
using HotelBooking.Entity.Common.Enums;


namespace HotelBooking.Helpers
{
    public class JwtMiddleware
    {


        public static int GetUserIdFromToken(string token)
        {
            try
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes(CommonRepositoryConstants.SecretKey);
                tokenHandler.ValidateToken(token, new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    // set clockskew to zero so tokens expire exactly at token expiration time (instead of 5 minutes later)
                    ClockSkew = TimeSpan.Zero
                }, out SecurityToken validatedToken);

                var jwtToken = (JwtSecurityToken)validatedToken;

                //Guid.TryParse(jwtToken.Claims.First(x => x.Type == "userId").Value, out Guid userId);
                int userId = Convert.ToInt32(jwtToken.Claims.First(x => x.Type == "userId").Value);

                return userId;
            }
            catch (Exception ex)
            {
                return 0;
            }

        }

        public static int GetUserIdFromRefreshToken(string token)
        {
            try
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes(CommonRepositoryConstants.SecretKey);
                tokenHandler.ValidateToken(token, new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    // set clockskew to zero so tokens expire exactly at token expiration time (instead of 5 minutes later)
                    ClockSkew = TimeSpan.Zero
                }, out SecurityToken validatedToken);

                var jwtToken = (JwtSecurityToken)validatedToken;

                //Guid.TryParse(jwtToken.Claims.First(x => x.Type == "userId").Value, out Guid userId);
                int userId = Convert.ToInt32(jwtToken.Claims.First(x => x.Type == "userId").Value);

                return userId;
            }
            catch (Exception ex)
            {
                return 0;
            }

        }

        public static int GetIsUserFromToken(string token)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(CommonRepositoryConstants.SecretKey);
            tokenHandler.ValidateToken(token, new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(key),
                ValidateIssuer = false,
                ValidateAudience = false,
                // set clockskew to zero so tokens expire exactly at token expiration time (instead of 5 minutes later)
                ClockSkew = TimeSpan.Zero
            }, out SecurityToken validatedToken);

            var jwtToken = (JwtSecurityToken)validatedToken;

            //Guid.TryParse(jwtToken.Claims.First(x => x.Type == "userId").Value, out Guid userId);
            int isUser = Convert.ToInt32(jwtToken.Claims.First(x => x.Type == "isUser").Value);

            return isUser;
        }
        private readonly RequestDelegate _next;
        public JwtMiddleware(RequestDelegate next)
        {
            _next = next;

        }

        public async Task Invoke(HttpContext context, IUserLookupRepositoryInterface usersService)
        {
            if (context.Request.Path.StartsWithSegments("/api/UserLogin/UserLogin"))
            {
                Console.WriteLine($"Bypassing JwtMiddleware for: {context.Request.Path}");
                await _next(context);
                return;
            }

            var token = context.Request.Headers["Authorization"]
                .FirstOrDefault()?.Split(" ").Last();

            //if (string.IsNullOrWhiteSpace(token))
            //{
            //    context.Response.StatusCode = 419; 
            //    return;
            //}

            if (context.Request.Path.StartsWithSegments("/api/Booking/DashboardCount") &&
             string.IsNullOrWhiteSpace(token))
            {
                context.Response.StatusCode = 419;
                context.Response.ContentType = "application/json";

                var result = JsonSerializer.Serialize(new ResultModel
                {
                    Status = (int)ResponseStatusCode.TokenExpired, 
                    Message = "failed",
                    Details = "Token is missing.",
                    Data = string.Empty
                });

                await context.Response.WriteAsync(result);
                await context.Response.CompleteAsync();
                return;
            }


            await attachUserToContext(context, usersService, token);

            await _next(context);
        }

        private async Task attachUserToContext(HttpContext context,IUserLookupRepositoryInterface usersService, string token)
        {
            if (string.IsNullOrEmpty(token))
            {
                return;
            }
            try
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes(CommonRepositoryConstants.SecretKey);
                tokenHandler.ValidateToken(token, new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false,

                    // set clockskew to zero so tokens expire exactly at token expiration time (instead of 5 minutes later)
                    ClockSkew = TimeSpan.FromDays(30),
                }, out SecurityToken validatedToken);

                var jwtToken = (JwtSecurityToken)validatedToken;
                var userId = jwtToken.Claims.First(x => x.Type == "userId").Value;


                // attach user to context on successful jwt validation
                context.Items["userId"] = userId;

                //var userModel = await usersService.Get(userId);
                //context.Items["User"] = userModel;
                ////context.Items["CompanyId"] = companyId;
            }
            catch (Exception ex)
            {
                // do nothing if jwt validation fails
                // user is not attached to context so request won't have access to secure routes

                Console.WriteLine($"Token validation failed for: {context.Request.Path}, Error: {ex.Message}");
                context.Response.ContentType = "application/json";
                if (context.Request.Path.StartsWithSegments("/api/UserLogin/CheckRefreshToken"))
                {
                    context.Response.StatusCode = 420;
                    context.Response.Headers.Append("Access-Control-Allow-Status", "420");
                    await context.Response.WriteAsync(JsonSerializer.Serialize(new ResultModel
                    {
                        Status = (int)ResponseStatusCode.RefreshTokenExpired,
                        Message = "failed",
                        Details = ex is SecurityTokenExpiredException ? "Token has expired." : "Invalid token.",
                        Data = string.Empty
                    }));
                }
                else
                {
                    context.Response.StatusCode = 419;
                    context.Response.Headers.Append("Access-Control-Allow-Status", "419");
                    await context.Response.WriteAsync(JsonSerializer.Serialize(new ResultModel
                    {
                        Status = (int)ResponseStatusCode.TokenExpired,
                        Message = "failed",
                        Details = ex is SecurityTokenExpiredException ? "Token has expired." : "Invalid token.",
                        Data = string.Empty
                    }));
                }
                await context.Response.CompleteAsync();
            }
        }
    }
}