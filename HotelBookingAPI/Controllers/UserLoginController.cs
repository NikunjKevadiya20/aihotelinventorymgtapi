using AutoMapper;
using HotelBooking.Domain.Interfaces;
using HotelBooking.Entity.Common;
using HotelBooking.Entity.Common.Entities;
using HotelBooking.Entity.Common.Enums;
using HotelBooking.Entity.Entities;
using HotelBooking.Helpers;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace HotelBooking.Controllers
{
    /// <summary>
    /// Added by NikunjK on 01-08-2023
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class UserLoginController : ControllerBase
    {
        private readonly IUserLoginDomain domain;

        private readonly IWebHostEnvironment _webHostEnvironment;

        public UserLoginController(ILogger<UserLoginController> _logger, IUserLoginDomain _UserLoginDomain)
        {
            domain = _UserLoginDomain;
        }

        #region User Login
        [HttpPost("UserLogin")]
        //[Authorize]
        public async Task<IActionResult> UserLogin(LoginRequestEntity entity)
        {
            try
            {
                //var token = HttpContext.Request.Headers["Authorization"]
                // .FirstOrDefault()?.Split(" ").Last();

                //int userId = JwtMiddleware.GetUserIdFromToken(token);
                //int isUser = JwtMiddleware.GetIsUserFromToken(token);
         

                var result = await domain.UserLogin(entity);
                if (result.Message == "success")
                {
                    return StatusCode((int)HttpStatusCode.OK, new ResultModel()
                    {
                        Status = (int)ResponseStatusCode.Success,
                        Message = Convert.ToString(result.Message),
                        Details = Convert.ToString(result.Details),
                        Data = result,
                    });
                }
                else
                {
                    return StatusCode((int)HttpStatusCode.BadRequest, new ResultModel()
                    {
                        Data = string.Empty,
                        Message = Convert.ToString(result.Message),
                        Details = Convert.ToString(result.Details),
                        Status = (int)ResponseStatusCode.BadRequestError,
                        ErrorMessage = Convert.ToString(result.ErrorMessage),
                    });
                }
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, new ResultModel()
                {
                    Message = CommonRepositoryMessages.NotFoundMessageEN,
                    Details = CommonRepositoryMessages.NotFoundMessageEN,
                    ErrorMessage = ex.Message,
                    Status = (int)ResponseStatusCode.InternaServerError,
                });
            }

        }
        #endregion

        #region Generate Login Token

        [HttpPost("CheckRefreshToken")]
        public async Task<IActionResult> CheckRefreshToken(UserToken entity)
        {

            try
            {
                //var token = HttpContext.Request.Headers["Authorization"]
                // .FirstOrDefault()?.Split(" ").Last();


                int userId = JwtMiddleware.GetUserIdFromRefreshToken(entity.RefreshToken);
                //int isUser = JwtMiddleware.GetIsUserFromToken(token);
                entity.UserID = userId;
                if (userId != 0)
                {
                    var result = await domain.CheckRefreshToken(entity);

                    object data;
                    if (result.Message == "success")
                    {

                        return StatusCode((int)HttpStatusCode.OK, new ResultModel()
                        {
                            Status = (int)ResponseStatusCode.Success,
                            Message = Convert.ToString(result.Message),
                            Details = Convert.ToString(result.Details),
                            Data = result,
                        });
                    }
                    else
                    {
                        return StatusCode((int)HttpStatusCode.BadRequest, new ResultModel()
                        {
                            Data = string.Empty,
                            Message = Convert.ToString(result.Message),
                            Details = Convert.ToString(result.Details),
                            Status = (int)ResponseStatusCode.BadRequestError,
                            ErrorMessage = Convert.ToString(result.ErrorMessage),
                        });
                    }
                }
                else
                {
                    return StatusCode((int)ResponseStatusCode.RefreshTokenExpired, new ResultModel()
                    {
                        Data = string.Empty,
                        Message = CommonRepositoryMessages.FAILUREMessage,
                        Details = CommonRepositoryMessages.TokenExprired,
                        Status = (int)ResponseStatusCode.RefreshTokenExpired,
                        
                    });

                }
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, new ResultModel()
                {
                    Message = CommonRepositoryMessages.NotFoundMessageEN,
                    Details = CommonRepositoryMessages.NotFoundMessageEN,
                    ErrorMessage = ex.Message,
                    Status = (int)ResponseStatusCode.InternaServerError,
                });
            }

        }
        #endregion

        #region ManageUserChangePassword   

        [HttpPost("ManageUserChangePassword")]
        public async Task<IActionResult> ManageUserChangePassword(ChangePasswordRequestEntity entity)
        {
            try
            {


                var token = HttpContext.Request.Headers["Authorization"]
                    .FirstOrDefault()?.Split(" ").Last();

                int userId = JwtMiddleware.GetUserIdFromToken(token);

                if (userId != 0)
                {
                    var result = await domain.ManageUserChangePassword(entity);

                    object data;
                    if (result.Message == "success")
                    {

                        return StatusCode((int)HttpStatusCode.OK, new ResultModel()
                        {
                            Status = (int)ResponseStatusCode.Success,
                            Message = Convert.ToString(result.Message),
                            Details = Convert.ToString(result.Details),
                            Data = result,
                        });
                    }
                    else
                    {
                        return StatusCode((int)HttpStatusCode.BadRequest, new ResultModel()
                        {
                            Data = string.Empty,
                            Message = Convert.ToString(result.Message),
                            Details = Convert.ToString(result.Details),
                            Status = (int)ResponseStatusCode.BadRequestError,
                            ErrorMessage = Convert.ToString(result.ErrorMessage),
                        });
                    }
                }
                else
                {
                    return StatusCode((int)ResponseStatusCode.RefreshTokenExpired, new ResultModel()
                    {
                        Data = string.Empty,
                        Message = CommonRepositoryMessages.FAILUREMessage,
                        Details = CommonRepositoryMessages.TokenExprired,
                        Status = (int)ResponseStatusCode.RefreshTokenExpired,

                    });

                }
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, new ResultModel()
                {
                    Message = CommonRepositoryMessages.NotFoundMessageEN,
                    Details = CommonRepositoryMessages.NotFoundMessageEN,
                    ErrorMessage = ex.Message,
                    Status = (int)ResponseStatusCode.InternaServerError,
                });
            }
        }
        #endregion

        #region ManageUserResetPassword
        [HttpPost("ManageUserResetPassword")]
        public async Task<IActionResult> ManageUserResetPassword(ChangePasswordRequestEntity entity)
        {
            try
            {

                var token = HttpContext.Request.Headers["Authorization"]
                                   .FirstOrDefault()?.Split(" ").Last();

                int userId = JwtMiddleware.GetUserIdFromToken(token);

                if (userId != 0)
                {
                    var result = await domain.ManageUserResetPassword(entity);

                    object data;
                    if (result.Message == "success")
                    {

                        return StatusCode((int)HttpStatusCode.OK, new ResultModel()
                        {
                            Status = (int)ResponseStatusCode.Success,
                            Message = Convert.ToString(result.Message),
                            Details = Convert.ToString(result.Details),
                            Data = result,
                        });
                    }
                    else
                    {
                        return StatusCode((int)HttpStatusCode.BadRequest, new ResultModel()
                        {
                            Data = string.Empty,
                            Message = Convert.ToString(result.Message),
                            Details = Convert.ToString(result.Details),
                            Status = (int)ResponseStatusCode.BadRequestError,
                            ErrorMessage = Convert.ToString(result.ErrorMessage),
                        });
                    }
                }
                else
                {
                    return StatusCode((int)ResponseStatusCode.RefreshTokenExpired, new ResultModel()
                    {
                        Data = string.Empty,
                        Message = CommonRepositoryMessages.FAILUREMessage,
                        Details = CommonRepositoryMessages.TokenExprired,
                        Status = (int)ResponseStatusCode.RefreshTokenExpired,

                    });

                }
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, new ResultModel()
                {
                    Message = CommonRepositoryMessages.NotFoundMessageEN,
                    Details = CommonRepositoryMessages.NotFoundMessageEN,
                    ErrorMessage = ex.Message,
                    Status = (int)ResponseStatusCode.InternaServerError,
                });
            }
        }
        #endregion

        #region Token check

        [HttpGet("TokenCheck")]
        public async Task<IActionResult> TokenCheck()
        {
            try
            {
                var token = HttpContext.Request.Headers["Authorization"]
               .FirstOrDefault()?.Split(" ").Last();
                int userId = JwtMiddleware.GetUserIdFromToken(token);

                if (userId != 0)
                {
                    return StatusCode((int)HttpStatusCode.OK, new ResultModel()
                    {
                        Status = (int)ResponseStatusCode.Success,
                        Message = "success",
                        Details = "User ID is valid."
                    });
                }
                else
                {
                    return StatusCode((int)ResponseStatusCode.TokenExpired, new ResultModel()
                    {
                        Status = (int)ResponseStatusCode.BadRequestError,
                        Message = "failed",
                        Details = "Invalid or expired refresh token."
                    });
                }
            }
            catch (Exception)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, new ResultModel()
                {
                    Status = (int)ResponseStatusCode.InternaServerError,
                    Message = "error",
                    Details = "An internal server error occurred."
                });
            }
        }
        #endregion


    }



}
