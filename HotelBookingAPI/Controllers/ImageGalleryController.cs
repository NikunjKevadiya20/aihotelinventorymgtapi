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
    public class ImageGalleryController : ControllerBase
    {
        private readonly IImageGalleryDomain domain;
        //private readonly IMapper _mapper;
        //private IMapper mapper;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public ImageGalleryController(ILogger<ImageGalleryController> _logger, IImageGalleryDomain _ImageGalleryDomain)
        {
            domain = _ImageGalleryDomain;
            // _mapper = mapper;
        }


        #region Inser Image Gallery
        [HttpPost("InsertImageGallery")]
        [Authorize]
        public async Task<ResultModel> InsertImageGallery([FromForm] ImageGalleryEntity entity)
        {
            try
            {
                var token = HttpContext.Request.Headers["Authorization"]
                    .FirstOrDefault()?.Split(" ").Last();

                int userId = JwtMiddleware.GetUserIdFromToken(token);
               
                if (userId == 0)
                {
                    return new ResultModel()
                    {
                        Data = string.Empty,
                        Message = CommonRepositoryMessages.NotFoundMessageEN,
                        Details = CommonRepositoryMessages.NotFoundMessageEN,
                        Status = (int)ResponseStatusCode.TokenExpired
                    };
                }

                entity.CreatedBy = userId;

                string physicalFolderPath = Path.Combine(
                                                CommonRepositoryConstants.ImageFilePath,
                                                CommonRepositoryConstants.documentsFolder
                                            );

                if (!Directory.Exists(physicalFolderPath))
                    Directory.CreateDirectory(physicalFolderPath);

                if (entity.OtherImageFiles != null && entity.OtherImageFiles.Count > 0)
                {
                    foreach (var file in entity.OtherImageFiles)
                    {
                        if (file.Length > 0)
                        {
                            string extension = Path.GetExtension(file.FileName);

                            string uniqueFileName = $"{DateTime.Now:yyyyMMddHHmmssfff}_{Guid.NewGuid():N}{extension}";

                            string fullPath = Path.Combine(physicalFolderPath, uniqueFileName);

                            using (var stream = System.IO.File.Create(fullPath))
                            {
                                await file.CopyToAsync(stream);
                            }

                            entity.Image = uniqueFileName;

                            await domain.InsertImageGallery(entity);
                        }
                    }
                }

                return new ResultModel()
                {
                    Message = "Images Uploaded Successfully",
                    Status = (int)ResponseStatusCode.Success
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

        #region Update Image Gallery
        [HttpPost("UpdateImageGallery")]
        [Authorize]
        public async Task<ResultModel> UpdateImageGallery([FromForm] ImageGalleryEntity entity)
        {
            try
            {
                var token = HttpContext.Request.Headers["Authorization"]
                    .FirstOrDefault()?.Split(" ").Last();

                int userId = JwtMiddleware.GetUserIdFromToken(token);

                if (userId == 0)
                {
                    return new ResultModel()
                    {
                        Data = string.Empty,
                        Message = CommonRepositoryMessages.NotFoundMessageEN,
                        Details = CommonRepositoryMessages.NotFoundMessageEN,
                        Status = (int)ResponseStatusCode.TokenExpired
                    };
                }

                entity.UpdatedBy = userId;

                string physicalFolderPath = Path.Combine(
                                                CommonRepositoryConstants.ImageFilePath,
                                                CommonRepositoryConstants.documentsFolder
                                            );

                if (!Directory.Exists(physicalFolderPath))
                    Directory.CreateDirectory(physicalFolderPath);

                if (entity.SingleImageFile != null && entity.SingleImageFile.Length > 0)
                {
                    string extension = Path.GetExtension(entity.SingleImageFile.FileName);

                    string uniqueFileName = $"{DateTime.Now:yyyyMMddHHmmssfff}_{Guid.NewGuid():N}{extension}";

                    string fullPath = Path.Combine(physicalFolderPath, uniqueFileName);

                    using (var stream = System.IO.File.Create(fullPath))
                    {
                        await entity.SingleImageFile.CopyToAsync(stream);
                    }

                    entity.Image = uniqueFileName;
                }

                var result = await domain.UpdateImageGallery(entity);

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

        #region Delete ImageGallery
        [HttpPost("DeleteImageGallery")]
        [Authorize]
        public async Task<IActionResult> DeleteImageGallery(ImageGalleryIDEntity entity)
        {

            try
            {
                var token = HttpContext.Request.Headers["Authorization"]
                .FirstOrDefault()?.Split(" ").Last();

                int userId = JwtMiddleware.GetUserIdFromToken(token);
                entity.UpdatedBy = userId;
                if (userId != 0)
                {

                    var result = await domain.DeleteImageGallery(entity);
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

        #region Find All ImageGallery
        [HttpPost("FindAllImageGallery")]
        
        public async Task<IActionResult> FindAllImageGallery(ImageGalleryIDEntity entity)
        {

            try
            {
                

                int userId = 1;

                if (userId != 0)
                {

                    var result = await domain.FindAllImageGallery(entity);
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


    }
}
