using HotelBooking.Domain.Interfaces;
using HotelBooking.Entity.Common.Helper;
using HotelBooking.Entity.Entities;
using HotelBooking.Entity.Common;
using HotelBooking.Entity.Common.Entities;
using HotelBooking.Entity.Common.Enums;
using HotelBooking.Helpers;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace HotelBooking.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GalleryController : ControllerBase
    {
        private readonly IGalleryDomain domain;
        private readonly ILogger<GalleryController> _logger;

        public GalleryController(ILogger<GalleryController> logger, IGalleryDomain GalleryDomain)
        {
            _logger = logger;
            domain = GalleryDomain;
        }




        #region Add / Update Gallery Image
        [HttpPost("CreateOrUpdateGallery")]
        [Authorize]
        public async Task<IActionResult> CreateOrUpdateGallery([FromForm] GalleryImageDataEntity docs)
        {
            try
            {
                int createdBy = 1;
                string physicalFileName = string.Empty;

                // Handle image upload
                if (docs.ImageFile != null && docs.ImageFile.Length > 0)
                {
                    string fileName = Path.GetFileName(docs.ImageFile.FileName);
                    string fileExtension = Path.GetExtension(fileName);
                    physicalFileName = $"{DateTime.Now.Ticks}{fileExtension}";

                    //  Build folder path
                    string folderPath = Path.Combine(
                        CommonRepositoryConstants.ImageFilePath,
                        CommonRepositoryConstants.documentsFolder
                    );

                    if (!Directory.Exists(folderPath))
                        Directory.CreateDirectory(folderPath);

                    string filePath = Path.Combine(folderPath, physicalFileName);

                    await ImageHelper.CompressWithSkia(docs.ImageFile, filePath);
                }

                // Prepare entity for DB
                var entity = new GalleryEntity()
                {
                    ID = docs.ID,
                    ImgAlt = docs.ImgAlt,
                    IsshowHome = docs.IsshowHome,
                    Image = physicalFileName,
                    CreatedBy = createdBy,
                    GroupName = docs.GroupName,
                    GalleryTypeID = docs.GalleryTypeID,
                    IsCuision = docs.IsCuision
                };

                // Call domain method
                var result = await domain.CreateOrUpdateGallery(entity);

                if (result.Message == "success")
                {
                    return Ok(new ResultModel()
                    {
                        Status = (int)ResponseStatusCode.Success,
                        Message = result.Message,
                        Details = result.Details,
                        Data = result
                    });
                }
                else
                {
                    return BadRequest(new ResultModel()
                    {
                        Status = (int)ResponseStatusCode.BadRequestError,
                        Message = result.Message,
                        Details = result.Details,
                        ErrorMessage = result.ErrorMessage
                    });
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error in CreateOrUpdateGallery");

                return StatusCode((int)HttpStatusCode.InternalServerError, new ResultModel()
                {
                    Status = (int)ResponseStatusCode.InternaServerError,
                    Message = CommonRepositoryMessages.NotFoundMessageEN,
                    Details = CommonRepositoryMessages.NotFoundMessageEN,
                    ErrorMessage = ex.Message
                });
            }
        }
        #endregion

        #region Delete Gallery Image
        [HttpPost("DeleteGallery")]
        [Authorize]
        public async Task<IActionResult> DeleteGallery(GalleryIDEntity entity)
        {
            try
            {
                var token = HttpContext.Request.Headers["Authorization"]
                .FirstOrDefault()?.Split(" ").Last();

                int userId = JwtMiddleware.GetUserIdFromToken(token);
                entity.UpdatedBy = userId;
                if (userId != 0)
                {

                    var result = await domain.DeleteGallery(entity);
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

        #region Find By ID Gallery
        [HttpPost("FindByIDGallery")]
        [Authorize]
        public async Task<IActionResult> FindByIDGallery(GalleryIDEntity entity)
        {
            try
            {
                var token = HttpContext.Request.Headers["Authorization"]
                .FirstOrDefault()?.Split(" ").Last();

                int userId = JwtMiddleware.GetUserIdFromToken(token);

                if (userId != 0)
                {

                    var result = await domain.FindByIDGallery(entity);
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

        #region Find All Gallery
        [HttpGet("FindAllGallery")]
        //[Authorize]
        public async Task<IActionResult> FindAllGallery()
        {
            try
            {
                //var token = HttpContext.Request.Headers["Authorization"]
                //.FirstOrDefault()?.Split(" ").Last();

                //int userId = JwtMiddleware.GetUserIdFromToken(token);
                int userId = 1;

                if (userId != 0)
                {

                    var result = await domain.FindAllGallery();
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

        #region Find All Active Gallery
        [HttpGet("FindAllActiveGallery")]
        public async Task<IActionResult> FindAllActiveGallery()
        {
            try
            {
                var result = await domain.FindAllActiveGallery();

                if (result.Count > 0)
                {
                    return Ok(new ResultModel()
                    {
                        Status = (int)ResponseStatusCode.Success,
                        Message = result[0].Message,
                        Details = result[0].Details,
                        Data = result
                    });
                }
                else
                {
                    return NotFound(new ResultModel()
                    {
                        Status = (int)ResponseStatusCode.NotFound,
                        Message = result.FirstOrDefault()?.Message ?? "No active data",
                        Details = result.FirstOrDefault()?.Details,
                        ErrorMessage = result.FirstOrDefault()?.ErrorMessage
                    });
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error in FindAllActiveGallery");
                return StatusCode((int)HttpStatusCode.InternalServerError, new ResultModel()
                {
                    Status = (int)ResponseStatusCode.InternaServerError,
                    Message = CommonRepositoryMessages.NotFoundMessageEN,
                    Details = CommonRepositoryMessages.NotFoundMessageEN,
                    ErrorMessage = ex.Message
                });
            }
        }
        #endregion

        #region Active/InActive Gallery
        [HttpPost("ActiveInActiveGallery")]
        [Authorize]
        public async Task<IActionResult> ActiveInActiveGallery(GalleryIDEntity entity)
        {
            try
            {
                var token = HttpContext.Request.Headers["Authorization"]
                .FirstOrDefault()?.Split(" ").Last();

                int userId = JwtMiddleware.GetUserIdFromToken(token);
                entity.UpdatedBy = userId;
                if (userId != 0)
                {

                    var result = await domain.ActiveInActiveGallery(entity);
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


        [HttpGet("FindAllGalleryWiseGroupName")]
        public async Task<IActionResult> FindAllGalleryWiseGroupName()
        {
            try
            {
                var result = await domain.FindAllGalleryWiseGroupName();

                if (result.Count > 0)
                {
                    return Ok(new ResultModel()
                    {
                        Status = (int)ResponseStatusCode.Success,
                        Message = result[0].Message,
                        Details = result[0].Details,
                        Data = result
                    });
                }
                else
                {
                    return NotFound(new ResultModel()
                    {
                        Status = (int)ResponseStatusCode.NotFound,
                        Message = result.FirstOrDefault()?.Message ?? "No active data",
                        Details = result.FirstOrDefault()?.Details,
                        ErrorMessage = result.FirstOrDefault()?.ErrorMessage
                    });
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error in FindAllActiveGallery");
                return StatusCode((int)HttpStatusCode.InternalServerError, new ResultModel()
                {
                    Status = (int)ResponseStatusCode.InternaServerError,
                    Message = CommonRepositoryMessages.NotFoundMessageEN,
                    Details = CommonRepositoryMessages.NotFoundMessageEN,
                    ErrorMessage = ex.Message
                });
            }
        }



        #region ListGalleryVideoGallery
        [HttpGet("ListGalleryVideoGallery")]
        public async Task<IActionResult> ListGalleryVideoGallery()
        {

            try
            {
                int userId = 1;

                if (userId != 0)
                {
                    var result = await domain.ListGalleryVideoGallery();
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
    }
}
