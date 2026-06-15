using Microsoft.AspNetCore.Mvc;
using HotelBooking.Domain.Interfaces;
using HotelBooking.Entity.Common;
using HotelBooking.Entity.Common.Entities;
using HotelBooking.Entity.Common.Enums;
using HotelBooking.Entity.Common.Helper;
using HotelBooking.Entity.Entities;
using HotelBooking.Helpers;
using System.Net;

namespace HotelBooking.Controllers
{
    /// <summary>
    /// Added by NikunjK on 01-08-2023
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class BannerController : ControllerBase
    {
        private readonly IBannerDomain domain;
        //private readonly IMapper _mapper;
        //private IMapper mapper;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public BannerController(ILogger<BannerController> _logger, IBannerDomain _BannerDomain)
        {
            domain = _BannerDomain;
            //_mapper = mapper;
        }


        #region Insert Banner

        [HttpPost("InsertBanner")]
        [Authorize]
        public async Task<IActionResult> InsertBanner(BannerEntity entity)
        {
            try
            {
                var token = HttpContext.Request.Headers["Authorization"]
                    .FirstOrDefault()?.Split(" ").Last();

                int userId = JwtMiddleware.GetUserIdFromToken(token);
                entity.CreatedBy = userId;
                if (userId != 0)
                {

                    var result = await domain.InsertBanner(entity);

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

        #region Update Banner
        [HttpPost("UpdateBanner")]
        [Authorize]
        public async Task<IActionResult> UpdateBanner(BannerEntity entity)
        {

            try
            {
                var token = HttpContext.Request.Headers["Authorization"]
                 .FirstOrDefault()?.Split(" ").Last();

                int userId = JwtMiddleware.GetUserIdFromToken(token);
                entity.UpdatedBy = userId;
                if (userId != 0)
                {
                    var result = await domain.UpdateBanner(entity);
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


        #region Delete Banner
        [HttpPost("DeleteBanner")]
        [Authorize]
        public async Task<IActionResult> DeleteBanner(BannerIDEntity entity)
        {

            try
            {
                var token = HttpContext.Request.Headers["Authorization"]
                .FirstOrDefault()?.Split(" ").Last();

                int userId = JwtMiddleware.GetUserIdFromToken(token);
                entity.UpdatedBy = userId;
                if (userId != 0)
                {

                    var result = await domain.DeleteBanner(entity);
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

        #region Find By ID Banner
        [HttpPost("FindByIDBanner")]
        [Authorize]
        public async Task<IActionResult> FindByIDBanner(BannerIDEntity entity)
        {

            try
            {
                var token = HttpContext.Request.Headers["Authorization"]
                .FirstOrDefault()?.Split(" ").Last();

                int userId = JwtMiddleware.GetUserIdFromToken(token);

                if (userId != 0)
                {

                    var result = await domain.FindByIDBanner(entity);
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

        #region Find All Active Banner
        [HttpPost("FindAllBanner")]
        [Authorize]
        public async Task<IActionResult> FindAllBanner(BannerIDEntity entity)
        {

            try
            {
                var token = HttpContext.Request.Headers["Authorization"]
                .FirstOrDefault()?.Split(" ").Last();

                int userId = JwtMiddleware.GetUserIdFromToken(token);

                if (userId != 0)
                {

                    var result = await domain.FindAllBanner(entity);
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

        #region Find All Banner
        [HttpGet("FindAllActiveBanner")]
        //[Authorize]
        public async Task<IActionResult> FindAllActiveBanner()
        {

            try
            {
                //var token = HttpContext.Request.Headers["Authorization"]
                //.FirstOrDefault()?.Split(" ").Last();

                //int userId = JwtMiddleware.GetUserIdFromToken(token);

                //if (userId != 0)
                //{
                var result = await domain.FindAllActiveBanner();
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
                //}
                //else
                //{
                //    return StatusCode((int)ResponseStatusCode.TokenExpired, new ResultModel()
                //    {
                //        Data = string.Empty,
                //        Message = CommonRepositoryMessages.NotFoundMessageEN,
                //        Details = CommonRepositoryMessages.NotFoundMessageEN,
                //        Status = (int)ResponseStatusCode.TokenExpired,

                //    });

                //}
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, new ResultModel()
                {
                    Message = CommonRepositoryMessages.NotFoundMessageEN,
                    Details = CommonRepositoryMessages.NotFoundMessageEN,
                    ErrorMessage = CommonRepositoryMessages.NotFoundMessageEN,
                    Status = (int)ResponseStatusCode.InternaServerError,
                });
            }

        }
        #endregion

        #region ActiveInActive Banner
        [HttpPost("ActiveInActiveBanner")]
        [Authorize]
        public async Task<IActionResult> ActiveInActiveBanner(BannerIDEntity entity)
        {

            try
            {
                var token = HttpContext.Request.Headers["Authorization"]
                .FirstOrDefault()?.Split(" ").Last();

                int userId = JwtMiddleware.GetUserIdFromToken(token);
                entity.UpdatedBy = userId;
                if (userId != 0)
                {

                    var result = await domain.ActiveInActiveBanner(entity);
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


        #region Banner Image Update
        [Authorize]
        [HttpPost("BannerImageUpdate")]
        public async Task<ResultModel> BannerImageUpdate([FromForm] BannerImageDataEntity docs)
        {
            try
            {

                var token = HttpContext.Request.Headers["Authorization"]
               .FirstOrDefault()?.Split(" ").Last();

                int userId = JwtMiddleware.GetUserIdFromToken(token);
                int isUser = JwtMiddleware.GetIsUserFromToken(token);

                int UpdatedBy = userId;

                string physicalFileName = string.Empty;


                if ((docs.BannerImage != null && docs.BannerImage.Length > 0))
                {

                    string originalFileName = Path.GetFileName(docs.BannerImage.FileName);


                    string fileName = Path.GetFileName(originalFileName);



                    physicalFileName = $"{DateTime.Now.Ticks}.webp";

                    string physicalFolderPath = CommonRepositoryConstants.ImageFilePath + CommonRepositoryConstants.BannerImage;


                    if (!Directory.Exists(physicalFolderPath))
                    {
                        Directory.CreateDirectory(physicalFolderPath);
                    }

                    string physicalFileFullPath = Path.Combine(physicalFolderPath, physicalFileName);

                    //using var stream = System.IO.File.Create(physicalFileFullPath);

                    //// Upload File
                    //await docs.BannerImage.CopyToAsync(stream);
                    await ImageHelper.CompressWithSkia(docs.BannerImage, physicalFileFullPath);


                }


                var result = await domain.BannerImageUpdate(physicalFileName, docs.AltTitle, docs.ID, UpdatedBy);

                return new ResultModel()
                {

                    Data = result,
                    Message = CommonRepositoryMessages.FindAllMessage,
                    Details = Convert.ToString(result.Details),
                    Status = (int)ResponseStatusCode.Success,
                    ErrorMessage = Convert.ToString(result.ErrorMessage),
                };
            }

            catch (Exception ex)
            {
                return new ResultModel()
                {
                    Message = CommonRepositoryMessages.NotFoundMessageEN,
                    Details = CommonRepositoryMessages.NotFoundMessageEN,
                    ErrorMessage = ex.Message,
                    Status = (int)ResponseStatusCode.InternaServerError,
                };
            }
        }
        #endregion

    }
}
