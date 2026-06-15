using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using HotelBooking.Domain.Interfaces;
using HotelBooking.Entity.Common;
using HotelBooking.Entity.Common.Entities;
using HotelBooking.Entity.Common.Enums;
using HotelBooking.Entity.Entities;
using HotelBooking.Helpers;
using System.Net;

namespace HotelBooking.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DistrictController : ControllerBase
    {
        private readonly IDistrictDomain domain;
        public DistrictController(IDistrictDomain _DistrictDomain)
        {
            domain = _DistrictDomain;
        }

        #region Insert District
        [HttpPost("InsertDistrict")]
        [Authorize]
        public async Task<IActionResult> InsertDistrict(DistrictEntity entity)
        {
            try
            {
                var token = HttpContext.Request.Headers["Authorization"]
                    .FirstOrDefault()?.Split(" ").Last();
                int userId = JwtMiddleware.GetUserIdFromToken(token);
                entity.CreatedBy = userId;
                if (userId != 0)
                {
                    var result = await domain.InsertDistrict(entity);
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
                    return StatusCode((int)HttpStatusCode.BadRequest, new ResultModel()
                    {
                        Data = string.Empty,
                        Message = Convert.ToString(result.Message),
                        Details = Convert.ToString(result.Details),
                        Status = (int)ResponseStatusCode.BadRequestError,
                        ErrorMessage = Convert.ToString(result.ErrorMessage),
                    });
                }
                return StatusCode((int)ResponseStatusCode.TokenExpired, new ResultModel()
                {
                    Data = string.Empty,
                    Message = CommonRepositoryMessages.NotFoundMessageEN,
                    Details = CommonRepositoryMessages.NotFoundMessageEN,
                    Status = (int)ResponseStatusCode.TokenExpired,
                });
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

        #region Update District
        [HttpPost("UpdateDistrict")]
        [Authorize]
        public async Task<IActionResult> UpdateDistrict(DistrictEntity entity)
        {
            try
            {
                var token = HttpContext.Request.Headers["Authorization"]
                    .FirstOrDefault()?.Split(" ").Last();
                int userId = JwtMiddleware.GetUserIdFromToken(token);
                entity.UpdatedBy = userId;
                if (userId != 0)
                {
                    var result = await domain.UpdateDistrict(entity);
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
                    return StatusCode((int)HttpStatusCode.BadRequest, new ResultModel()
                    {
                        Data = string.Empty,
                        Message = Convert.ToString(result.Message),
                        Details = Convert.ToString(result.Details),
                        Status = (int)ResponseStatusCode.BadRequestError,
                        ErrorMessage = Convert.ToString(result.ErrorMessage),
                    });
                }
                return StatusCode((int)ResponseStatusCode.TokenExpired, new ResultModel()
                {
                    Data = string.Empty,
                    Message = CommonRepositoryMessages.NotFoundMessageEN,
                    Details = CommonRepositoryMessages.NotFoundMessageEN,
                    Status = (int)ResponseStatusCode.TokenExpired,
                });
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

        #region Delete District
        [HttpPost("DeleteDistrict")]
        [Authorize]
        public async Task<IActionResult> DeleteDistrict(DistrictIDEntity entity)
        {
            try
            {
                var token = HttpContext.Request.Headers["Authorization"]
                    .FirstOrDefault()?.Split(" ").Last();
                int userId = JwtMiddleware.GetUserIdFromToken(token);
                entity.UpdatedBy = userId;
                if (userId != 0)
                {
                    var result = await domain.DeleteDistrict(entity);
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
                    return StatusCode((int)HttpStatusCode.BadRequest, new ResultModel()
                    {
                        Data = string.Empty,
                        Message = Convert.ToString(result.Message),
                        Details = Convert.ToString(result.Details),
                        Status = (int)ResponseStatusCode.BadRequestError,
                        ErrorMessage = Convert.ToString(result.ErrorMessage),
                    });
                }
                return StatusCode((int)ResponseStatusCode.TokenExpired, new ResultModel()
                {
                    Data = string.Empty,
                    Message = CommonRepositoryMessages.NotFoundMessageEN,
                    Details = CommonRepositoryMessages.NotFoundMessageEN,
                    Status = (int)ResponseStatusCode.TokenExpired,
                });
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

        #region Find By ID District
        [HttpPost("FindByIDDistrict")]
        [Authorize]
        public async Task<IActionResult> FindByIDDistrict(DistrictIDEntity entity)
        {
            try
            {
                var token = HttpContext.Request.Headers["Authorization"]
                    .FirstOrDefault()?.Split(" ").Last();
                int userId = JwtMiddleware.GetUserIdFromToken(token);
                if (userId != 0)
                {
                    var result = await domain.FindByIDDistrict(entity);
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
                    return StatusCode((int)HttpStatusCode.NotFound, new ResultModel()
                    {
                        Data = string.Empty,
                        Message = Convert.ToString(result.Message),
                        Details = Convert.ToString(result.Details),
                        Status = (int)ResponseStatusCode.NotFound,
                        ErrorMessage = Convert.ToString(result.ErrorMessage),
                    });
                }
                return StatusCode((int)ResponseStatusCode.TokenExpired, new ResultModel()
                {
                    Data = string.Empty,
                    Message = CommonRepositoryMessages.NotFoundMessageEN,
                    Details = CommonRepositoryMessages.NotFoundMessageEN,
                    Status = (int)ResponseStatusCode.TokenExpired,
                });
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

        #region Find All District
        [HttpPost("FindAllDistrict")]
        [Authorize]
        public async Task<IActionResult> FindAllDistrict(DistrictIDEntity entity)
        {
            try
            {
                var token = HttpContext.Request.Headers["Authorization"]
                    .FirstOrDefault()?.Split(" ").Last();
                int userId = JwtMiddleware.GetUserIdFromToken(token);
                if (userId != 0)
                {
                    var result = await domain.FindAllDistrict(entity);
                    if (result.Count > 0 && result[0].Message == "success")
                    {
                        return StatusCode((int)HttpStatusCode.OK, new ResultModel()
                        {
                            Status = (int)ResponseStatusCode.Success,
                            Message = Convert.ToString(result[0].Message),
                            Details = Convert.ToString(result[0].Details),
                            Data = result,
                        });
                    }
                    return StatusCode((int)HttpStatusCode.NotFound, new ResultModel()
                    {
                        Data = string.Empty,
                        Message = result.Count > 0 ? Convert.ToString(result[0].Message) : string.Empty,
                        Details = result.Count > 0 ? Convert.ToString(result[0].Details) : string.Empty,
                        Status = (int)ResponseStatusCode.NotFound,
                        ErrorMessage = result.Count > 0 ? Convert.ToString(result[0].ErrorMessage) : string.Empty,
                    });
                }
                return StatusCode((int)ResponseStatusCode.TokenExpired, new ResultModel()
                {
                    Data = string.Empty,
                    Message = CommonRepositoryMessages.NotFoundMessageEN,
                    Details = CommonRepositoryMessages.NotFoundMessageEN,
                    Status = (int)ResponseStatusCode.TokenExpired,
                });
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

        #region Find All Active District
        [HttpGet("FindAllActiveDistrict")]
        public async Task<IActionResult> FindAllActiveDistrict()
        {
            try
            {
                int userId = 1; // Public endpoint
                if (userId != 0)
                {
                    var result = await domain.FindAllActiveDistrict();
                    if (result.Count > 0 && result[0].Message == "success")
                    {
                        return StatusCode((int)HttpStatusCode.OK, new ResultModel()
                        {
                            Status = (int)ResponseStatusCode.Success,
                            Message = Convert.ToString(result[0].Message),
                            Details = Convert.ToString(result[0].Details),
                            Data = result,
                        });
                    }
                    return StatusCode((int)HttpStatusCode.NotFound, new ResultModel()
                    {
                        Data = string.Empty,
                        Message = result.Count > 0 ? Convert.ToString(result[0].Message) : string.Empty,
                        Details = result.Count > 0 ? Convert.ToString(result[0].Details) : string.Empty,
                        Status = (int)ResponseStatusCode.NotFound,
                        ErrorMessage = result.Count > 0 ? Convert.ToString(result[0].ErrorMessage) : string.Empty,
                    });
                }
                return StatusCode((int)ResponseStatusCode.TokenExpired, new ResultModel()
                {
                    Data = string.Empty,
                    Message = CommonRepositoryMessages.NotFoundMessageEN,
                    Details = CommonRepositoryMessages.NotFoundMessageEN,
                    Status = (int)ResponseStatusCode.TokenExpired,
                });
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

        #region Active InActive District
        [HttpPost("ActiveInActiveDistrict")]
        [Authorize]
        public async Task<IActionResult> ActiveInActiveDistrict(DistrictIDEntity entity)
        {
            try
            {
                var token = HttpContext.Request.Headers["Authorization"]
                    .FirstOrDefault()?.Split(" ").Last();
                int userId = JwtMiddleware.GetUserIdFromToken(token);
                entity.UpdatedBy = userId;
                if (userId != 0)
                {
                    var result = await domain.ActiveInActiveDistrict(entity);
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
                    return StatusCode((int)HttpStatusCode.BadRequest, new ResultModel()
                    {
                        Data = string.Empty,
                        Message = Convert.ToString(result.Message),
                        Details = Convert.ToString(result.Details),
                        Status = (int)ResponseStatusCode.BadRequestError,
                        ErrorMessage = Convert.ToString(result.ErrorMessage),
                    });
                }
                return StatusCode((int)ResponseStatusCode.TokenExpired, new ResultModel()
                {
                    Data = string.Empty,
                    Message = CommonRepositoryMessages.NotFoundMessageEN,
                    Details = CommonRepositoryMessages.NotFoundMessageEN,
                    Status = (int)ResponseStatusCode.TokenExpired,
                });
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

        #region FindDisatrictByStateID
        [HttpPost("FindDisatrictByStateID")]
        //[Authorize]
        public async Task<IActionResult> FindDisatrictByStateID(DistrictIDEntity entity)
        {
            try
            {
                //var token = HttpContext.Request.Headers["Authorization"]
                //    .FirstOrDefault()?.Split(" ").Last();
                //int userId = JwtMiddleware.GetUserIdFromToken(token);
                int userId = 1;
                if (userId != 0)
                {
                    var result = await domain.FindDisatrictByStateID(entity);
                    if (result.Count > 0 && result[0].Message == "success")
                    {
                        return StatusCode((int)HttpStatusCode.OK, new ResultModel()
                        {
                            Status = (int)ResponseStatusCode.Success,
                            Message = Convert.ToString(result[0].Message),
                            Details = Convert.ToString(result[0].Details),
                            Data = result,
                        });
                    }
                    return StatusCode((int)HttpStatusCode.NotFound, new ResultModel()
                    {
                        Data = string.Empty,
                        Message = result.Count > 0 ? Convert.ToString(result[0].Message) : string.Empty,
                        Details = result.Count > 0 ? Convert.ToString(result[0].Details) : string.Empty,
                        Status = (int)ResponseStatusCode.NotFound,
                        ErrorMessage = result.Count > 0 ? Convert.ToString(result[0].ErrorMessage) : string.Empty,
                    });
                }
                return StatusCode((int)ResponseStatusCode.TokenExpired, new ResultModel()
                {
                    Data = string.Empty,
                    Message = CommonRepositoryMessages.NotFoundMessageEN,
                    Details = CommonRepositoryMessages.NotFoundMessageEN,
                    Status = (int)ResponseStatusCode.TokenExpired,
                });
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
