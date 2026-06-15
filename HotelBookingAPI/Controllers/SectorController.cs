using HotelBooking.Domain.Interfaces;
using HotelBooking.Entity.Common;
using HotelBooking.Entity.Common.Entities;
using HotelBooking.Entity.Common.Enums;
using HotelBooking.Entity.Common.Helper;
using HotelBooking.Entity.Entities;
using HotelBooking.Helpers;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SkiaSharp;
using System.Net;

namespace HotelBooking.Controllers
{
    /// <summary>
    /// Added by NikunjK on 01-08-2023
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class SectorController : ControllerBase
    {
        private readonly ISectorDomain domain;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public SectorController(ILogger<SectorController> _logger, ISectorDomain _SectorDomain)
        {
            domain = _SectorDomain;
        }


        #region Insert Sector

        [HttpPost("InsertSector")]
        [Authorize]
        public async Task<IActionResult> InsertSector(SectorDataEntity entity)
        {
            try
            {
                var token = HttpContext.Request.Headers["Authorization"]
                    .FirstOrDefault()?.Split(" ").Last();

                int userId = JwtMiddleware.GetUserIdFromToken(token);
                entity.CreatedBy = userId;
                if (userId != 0)
                {

                    var result = await domain.InsertSector(entity);

                    if (result.Message == "success")
                    {
                        return StatusCode((int)HttpStatusCode.Created, new SectorResultModel()
                        {
                            Status = (int)ResponseStatusCode.Created,
                            Message = Convert.ToString(result.Message
                            ),
                            Details = Convert.ToString(result.Details),
                            Data = result,
                        });
                    }
                    else
                    {
                        return StatusCode((int)HttpStatusCode.BadRequest, new SectorResultModel()
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
                    return StatusCode((int)ResponseStatusCode.TokenExpired, new SectorResultModel()
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
                return StatusCode((int)HttpStatusCode.InternalServerError, new SectorResultModel()
                {
                    Message = CommonRepositoryMessages.NotFoundMessageEN,
                    Details = CommonRepositoryMessages.NotFoundMessageEN,
                    ErrorMessage = ex.Message,
                    Status = (int)ResponseStatusCode.InternaServerError,
                });
            }
        }
        #endregion

        #region Update Sector
        [HttpPost("UpdateSector")]
        [Authorize]
        public async Task<IActionResult> UpdateSector(SectorDataEntity entity)
        {

            try
            {
                var token = HttpContext.Request.Headers["Authorization"]
                 .FirstOrDefault()?.Split(" ").Last();

                int userId = JwtMiddleware.GetUserIdFromToken(token);
                entity.UpdatedBy = userId;
                if (userId != 0)
                {
                    var result = await domain.UpdateSector(entity);
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


        #region Delete Sector
        [HttpPost("DeleteSector")]
        [Authorize]
        public async Task<IActionResult> DeleteSector(SectorIDEntity entity)
        {

            try
            {
                var token = HttpContext.Request.Headers["Authorization"]
                .FirstOrDefault()?.Split(" ").Last();

                int userId = JwtMiddleware.GetUserIdFromToken(token);
                entity.UpdatedBy = userId;
                if (userId != 0)
                {

                    var result = await domain.DeleteSector(entity);
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

        #region Find By ID Sector
        [HttpPost("FindByIDSector")]
        [Authorize]
        public async Task<IActionResult> FindByIDSector(SectorIDEntity entity)
        {

            try
            {
                var token = HttpContext.Request.Headers["Authorization"]
                .FirstOrDefault()?.Split(" ").Last();

                int userId = JwtMiddleware.GetUserIdFromToken(token);

                if (userId != 0)
                {

                    var result = await domain.FindByIDSector(entity);
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

        #region Find All Active Sector
        [HttpPost("FindAllSector")]
        [Authorize]
        public async Task<IActionResult> FindAllSector(SectorIDEntity entity)
        {

            try
            {
                var token = HttpContext.Request.Headers["Authorization"]
                .FirstOrDefault()?.Split(" ").Last();

                int userId = JwtMiddleware.GetUserIdFromToken(token);

                if (userId != 0)
                {

                    var result = await domain.FindAllSector(entity);
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

        #region Find All Sector
        [HttpGet("FindAllActiveSector")]
        //[Authorize]
        public async Task<IActionResult> FindAllActiveSector()
        {

            try
            {
                //var token = HttpContext.Request.Headers["Authorization"]
                //.FirstOrDefault()?.Split(" ").Last();

                //int userId = JwtMiddleware.GetUserIdFromToken(token);


                int userId = 1;
                if (userId != 0)
                {
                    var result = await domain.FindAllActiveSector();
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

        #region ActiveInActive sector
        [HttpPost("ActiveInActiveSector")]
        [Authorize]
        public async Task<IActionResult> ActiveInActiveSector(SectorIDEntity entity)
        {

            try
            {
                var token = HttpContext.Request.Headers["Authorization"]
                .FirstOrDefault()?.Split(" ").Last();

                int userId = JwtMiddleware.GetUserIdFromToken(token);
                entity.UpdatedBy = userId;
                if (userId != 0)
                {

                    var result = await domain.ActiveInActiveSector(entity);
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

        #region Find City by sector ID
        [HttpPost("FindCityBySectorID")]
        [Authorize]
        public async Task<IActionResult> FindCityBySectorID(SectorIDEntity entity)
        {

            try
            {
                var token = HttpContext.Request.Headers["Authorization"]
                .FirstOrDefault()?.Split(" ").Last();

                int userId = JwtMiddleware.GetUserIdFromToken(token);

                if (userId != 0)
                {

                    var result = await domain.FindCityBySectorID(entity);
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


        #region  SectorShowOnMenu
        [HttpGet("SectorShowOnMenu")]
        public async Task<IActionResult> SectorShowOnMenu()
        {

            try
            {


                int userId = 1;
                if (userId != 0)
                {
                    var result = await domain.SectorShowOnMenu();
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

        #region  SectorShowOnHome
        [HttpGet("SectorShowOnHome")]
        public async Task<IActionResult> SectorShowOnHome()
        {

            try
            {


                int userId = 1;
                if (userId != 0)
                {
                    var result = await domain.SectorShowOnHome();
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

        

        #region Sector Image Update
        [Authorize]
        [HttpPost("SectorImageUpdate")]
        public async Task<ResultModel> SectorImageUpdate([FromForm] SectorImageDataEntity docs)
        {
            try
            {

                var token = HttpContext.Request.Headers["Authorization"]
               .FirstOrDefault()?.Split(" ").Last();

                int userId = JwtMiddleware.GetUserIdFromToken(token);
                int isUser = JwtMiddleware.GetIsUserFromToken(token);

                int UpdatedBy = userId;

                string SectorImage = string.Empty;
                string BannerImage = string.Empty;
                string HomeImage = string.Empty;

                if ((docs.SectorImage != null && docs.SectorImage.Length > 0))
                {

                    string originalFileName = Path.GetFileName(docs.SectorImage.FileName);


                    string fileName = Path.GetFileName(originalFileName);



                    SectorImage = $"{DateTime.Now.Ticks}" +
                                $"{Path.GetExtension(fileName)}";

                    string physicalFolderPath = CommonRepositoryConstants.ImageFilePath + CommonRepositoryConstants.WebsiteImage;


                    if (!Directory.Exists(physicalFolderPath))
                    {
                        Directory.CreateDirectory(physicalFolderPath);
                    }

                    string physicalFileFullPath = Path.Combine(physicalFolderPath, SectorImage);

                    await ImageHelper.CompressWithSkia(docs.SectorImage, physicalFileFullPath);

                }

                if ((docs.BannerImage != null && docs.BannerImage.Length > 0))
                {

                    string originalFileName = Path.GetFileName(docs.BannerImage.FileName);


                    string fileName = Path.GetFileName(originalFileName);



                    BannerImage = $"{DateTime.Now.Ticks}" +
                                $"{Path.GetExtension(fileName)}";

                    string physicalFolderPath = CommonRepositoryConstants.ImageFilePath + CommonRepositoryConstants.WebsiteImage;


                    if (!Directory.Exists(physicalFolderPath))
                    {
                        Directory.CreateDirectory(physicalFolderPath);
                    }

                    string physicalFileFullPath = Path.Combine(physicalFolderPath, BannerImage);

                    await ImageHelper.CompressWithSkia(docs.SectorImage, physicalFileFullPath);

                }
                if ((docs.HomeImage != null && docs.HomeImage.Length > 0))
                {

                    string originalFileName = Path.GetFileName(docs.HomeImage.FileName);


                    string fileName = Path.GetFileName(originalFileName);



                    HomeImage = $"{DateTime.Now.Ticks}" +
                                $"{Path.GetExtension(fileName)}";

                    string physicalFolderPath = CommonRepositoryConstants.ImageFilePath + CommonRepositoryConstants.WebsiteImage;


                    if (!Directory.Exists(physicalFolderPath))
                    {
                        Directory.CreateDirectory(physicalFolderPath);
                    }

                    string physicalFileFullPath = Path.Combine(physicalFolderPath, HomeImage);

                    await ImageHelper.CompressWithSkia(docs.SectorImage, physicalFileFullPath);

                }
                var result = await domain.SectorImageUpdate(SectorImage, BannerImage, HomeImage, docs.ID, UpdatedBy);

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

        #region Find All Sector Incremental Search
        [HttpPost("FindAllSectorIncrementalSearch")]
        //[Authorize]
        public async Task<IActionResult> FindAllSectorIncrementalSearch(SectorIDEntity entity)
        {

            try
            {
                //var token = HttpContext.Request.Headers["Authorization"]
                //.FirstOrDefault()?.Split(" ").Last();

                //int userId = JwtMiddleware.GetUserIdFromToken(token);

                //if (userId != 0)
                //{
                var result = await domain.FindAllSectorIncrementalSearch(entity);
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
                    ErrorMessage = ex.Message,
                    Status = (int)ResponseStatusCode.InternaServerError,
                });
            }

        }
        #endregion

        #region Find All Sector Type Wise Sector Data
        [HttpPost("FindAllSectorTypeWiseSector")]
        //[Authorize]
        public async Task<IActionResult> FindAllSectorTypeWiseSector(SectorIDEntity entity)
        {

            try
            {
                //var token = HttpContext.Request.Headers["Authorization"]
                //.FirstOrDefault()?.Split(" ").Last();

                //int userId = JwtMiddleware.GetUserIdFromToken(token);

                //if (userId != 0)
                //{
                var result = await domain.FindAllSectorTypeWiseSector(entity);
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
                    ErrorMessage = ex.Message,
                    Status = (int)ResponseStatusCode.InternaServerError,
                });
            }

        }
        #endregion
    }



}
