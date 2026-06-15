using HotelBooking.Domain.Interfaces;
using HotelBooking.Entity.Common;
using HotelBooking.Entity.Common.Entities;
using HotelBooking.Entity.Common.Enums;
using HotelBooking.Entity.Entities;
using HotelBooking.Helpers;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace HotelBooking.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class StateController : Controller
    {
        private readonly IStateDomain domain;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public StateController(ILogger<StateController> _logger, IStateDomain _StateDomain)
        {
            domain = _StateDomain;
        }


        #region Insert State

        [HttpPost("InsertState")]
        [Authorize]
        public async Task<IActionResult> InsertState(StateEntity entity)
        {
            try
            {
                var token = HttpContext.Request.Headers["Authorization"]
                    .FirstOrDefault()?.Split(" ").Last();

                int userId = JwtMiddleware.GetUserIdFromToken(token);
                entity.CreatedBy = userId;
                if (userId != 0)
                {

                    var result = await domain.InsertState(entity);

                    if (result.Message == "success")
                    {
                        return StatusCode((int)HttpStatusCode.Created, new ResultModel()
                        {
                            Status = (int)ResponseStatusCode.Created,
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
                    return StatusCode((int)ResponseStatusCode.TokenExpired, new ResultModel()
                    {
                        Data = string.Empty,
                        Message = CommonRepositoryMessages.NotFoundMessageEN,
                        Details = CommonRepositoryMessages.NotFoundMessageEN,
                        Status = (int)ResponseStatusCode.TokenExpired,

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

        #region Update State
        [HttpPost("UpdateState")]
        [Authorize]
        public async Task<IActionResult> UpdateState(StateEntity entity)
        {

            try
            {
                var token = HttpContext.Request.Headers["Authorization"]
                 .FirstOrDefault()?.Split(" ").Last();

                int userId = JwtMiddleware.GetUserIdFromToken(token);
                entity.UpdatedBy = userId;
                if (userId != 0)
                {
                    var result = await domain.UpdateState(entity);
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
                    return StatusCode((int)ResponseStatusCode.TokenExpired, new ResultModel()
                    {
                        Data = string.Empty,
                        Message = CommonRepositoryMessages.NotFoundMessageEN,
                        Details = CommonRepositoryMessages.NotFoundMessageEN,
                        Status = (int)ResponseStatusCode.TokenExpired,

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


        #region Delete State
        [HttpPost("DeleteState")]
        [Authorize]
        public async Task<IActionResult> DeleteState(StateIDEntity entity)
        {

            try
            {
                var token = HttpContext.Request.Headers["Authorization"]
                .FirstOrDefault()?.Split(" ").Last();

                int userId = JwtMiddleware.GetUserIdFromToken(token);
                entity.UpdatedBy = userId;
                if (userId != 0)
                {

                    var result = await domain.DeleteState(entity);
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
                    return StatusCode((int)ResponseStatusCode.TokenExpired, new ResultModel()
                    {
                        Data = string.Empty,
                        Message = CommonRepositoryMessages.NotFoundMessageEN,
                        Details = CommonRepositoryMessages.NotFoundMessageEN,
                        Status = (int)ResponseStatusCode.TokenExpired,

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

        #region Find By ID State
        [HttpPost("FindByIDState")]
        [Authorize]
        public async Task<IActionResult> FindByIDState(StateIDEntity entity)
        {

            try
            {
                var token = HttpContext.Request.Headers["Authorization"]
                .FirstOrDefault()?.Split(" ").Last();

                int userId = JwtMiddleware.GetUserIdFromToken(token);

                if (userId != 0)
                {

                    var result = await domain.FindByIDState(entity);
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
                        return StatusCode((int)HttpStatusCode.NotFound, new ResultModel()
                        {
                            Data = string.Empty,
                            Message = Convert.ToString(result.Message),
                            Details = Convert.ToString(result.Details),
                            Status = (int)ResponseStatusCode.NotFound,
                            ErrorMessage = Convert.ToString(result.ErrorMessage),
                        });
                    }
                }
                else
                {
                    return StatusCode((int)ResponseStatusCode.TokenExpired, new ResultModel()
                    {
                        Data = string.Empty,
                        Message = CommonRepositoryMessages.NotFoundMessageEN,
                        Details = CommonRepositoryMessages.NotFoundMessageEN,
                        Status = (int)ResponseStatusCode.TokenExpired,

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

        #region Find All Active State
        [HttpPost("FindAllState")]
        [Authorize]
        public async Task<IActionResult> FindAllState(StateIDEntity entity)
        {

            try
            {
                var token = HttpContext.Request.Headers["Authorization"]
                .FirstOrDefault()?.Split(" ").Last();

                int userId = JwtMiddleware.GetUserIdFromToken(token);

                if (userId != 0)
                {

                    var result = await domain.FindAllState(entity);
                    if (result[0].Message == "success")
                    {
                        return StatusCode((int)HttpStatusCode.OK, new ResultModel()
                        {

                            Status = (int)ResponseStatusCode.Success,
                            Message = Convert.ToString(result[0].Message),
                            Details = Convert.ToString(result[0].Details),
                            Data = result,
                        });
                    }
                    else
                    {
                        return StatusCode((int)HttpStatusCode.NotFound, new ResultModel()
                        {
                            Data = string.Empty,
                            Message = Convert.ToString(result[0].Message),
                            Details = Convert.ToString(result[0].Details),
                            Status = (int)ResponseStatusCode.NotFound,
                            ErrorMessage = Convert.ToString(result[0].ErrorMessage),
                        });
                    }
                }
                else
                {
                    return StatusCode((int)ResponseStatusCode.TokenExpired, new ResultModel()
                    {
                        Data = string.Empty,
                        Message = CommonRepositoryMessages.NotFoundMessageEN,
                        Details = CommonRepositoryMessages.NotFoundMessageEN,
                        Status = (int)ResponseStatusCode.TokenExpired,

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

        #region Find All 
        [HttpGet("FindAllActiveState")]
        //[Authorize]
        public async Task<IActionResult> FindAllActiveState()
        {

            try
            {
                //var token = HttpContext.Request.Headers["Authorization"]
                //.FirstOrDefault()?.Split(" ").Last();

                //int userId = JwtMiddleware.GetUserIdFromToken(token);
                int userId = 1;
                if (userId != 0)
                {
                    var result = await domain.FindAllActiveState();
                    if (result[0].Message == "success")
                    {
                        return StatusCode((int)HttpStatusCode.OK, new ResultModel()
                        {
                            Status = (int)ResponseStatusCode.Success,
                            Message = Convert.ToString(result[0].Message),
                            Details = Convert.ToString(result[0].Details),
                            Data = result,
                        });
                    }
                    else
                    {
                        return StatusCode((int)HttpStatusCode.NotFound, new ResultModel()
                        {
                            Data = string.Empty,
                            Message = Convert.ToString(result[0].Message),
                            Details = Convert.ToString(result[0].Details),
                            Status = (int)ResponseStatusCode.NotFound,
                            ErrorMessage = Convert.ToString(result[0].ErrorMessage),
                        });
                    }
                }
                else
                {
                    return StatusCode((int)ResponseStatusCode.TokenExpired, new ResultModel()
                    {
                        Data = string.Empty,
                        Message = CommonRepositoryMessages.NotFoundMessageEN,
                        Details = CommonRepositoryMessages.NotFoundMessageEN,
                        Status = (int)ResponseStatusCode.TokenExpired,

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

        #region ActiveInActive State
        [HttpPost("ActiveInActiveState")]
        [Authorize]
        public async Task<IActionResult> ActiveInActiveState(StateIDEntity entity)
        {

            try
            {
                var token = HttpContext.Request.Headers["Authorization"]
                .FirstOrDefault()?.Split(" ").Last();

                int userId = JwtMiddleware.GetUserIdFromToken(token);
                entity.UpdatedBy = userId;
                if (userId != 0)
                {

                    var result = await domain.ActiveInActiveState(entity);
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
                    return StatusCode((int)ResponseStatusCode.TokenExpired, new ResultModel()
                    {
                        Data = string.Empty,
                        Message = CommonRepositoryMessages.NotFoundMessageEN,
                        Details = CommonRepositoryMessages.NotFoundMessageEN,
                        Status = (int)ResponseStatusCode.TokenExpired,

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
    }
}
