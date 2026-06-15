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
    [Route("api/[controller]")]
    [ApiController]
    public class AttractionController : ControllerBase
    {
        private readonly IAttractionDomain domain;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public AttractionController(ILogger<AttractionController> _logger, IAttractionDomain _AttractionDomain)
        {
            domain = _AttractionDomain;
        }

        //Created By Shivam On 30-01-2024
        //For Inserting Attraction Details
        [HttpPost("InsertAttraction")]
        [Authorize]
        public async Task<IActionResult> InsertAttraction(AttractionEntity entity)
        {
            try
            {
                var token = HttpContext.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();
                string userId = JwtMiddleware.GetUserIdFromToken(token).ToString();
                entity.CreatedBy = userId;
                if (!string.IsNullOrEmpty(userId) && userId != "0")
                {
                    var result = await domain.InsertAttraction(entity);
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

        //Created By Shivam On 30-01-2024
        //For Update Attraction Details
        [HttpPost("UpdateAttraction")]
        [Authorize]
        public async Task<IActionResult> UpdateAttraction(AttractionEntity entity)
        {
            try
            {
                var token = HttpContext.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();
                string userId = JwtMiddleware.GetUserIdFromToken(token).ToString();
                entity.UpdatedBy = userId;
                if (!string.IsNullOrEmpty(userId) && userId != "0")
                {
                    var result = await domain.UpdateAttraction(entity);
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

        [HttpPost("DeleteAttraction")]
        [Authorize]
        public async Task<IActionResult> DeleteAttraction(AttractionIDEntity entity)
        {
            try
            {
                var token = HttpContext.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();
                string userId = JwtMiddleware.GetUserIdFromToken(token).ToString();
                entity.UpdatedBy = userId;
                if (!string.IsNullOrEmpty(userId) && userId != "0")
                {
                    var result = await domain.DeleteAttraction(entity);
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

        [HttpPost("FindByIDAttraction")]
        [Authorize]
        public async Task<IActionResult> FindByIDAttraction(AttractionIDEntity entity)
        {
            try
            {
                var token = HttpContext.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();
                string userId = JwtMiddleware.GetUserIdFromToken(token).ToString();
                if (!string.IsNullOrEmpty(userId) && userId != "0")
                {
                    var result = await domain.FindByIDAttraction(entity);
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

        [HttpPost("FindAllAttraction")]
        [Authorize]
        public async Task<IActionResult> FindAllAttraction(AttractionIDEntity entity)
        {
            try
            {
                var token = HttpContext.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();
                string userId = JwtMiddleware.GetUserIdFromToken(token).ToString();
                if (!string.IsNullOrEmpty(userId) && userId != "0")
                {
                    var result = await domain.FindAllAttraction(entity);
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
                    else
                    {
                        return StatusCode((int)HttpStatusCode.NotFound, new ResultModel()
                        {
                            Data = string.Empty,
                            Message = result.Count > 0 ? Convert.ToString(result[0].Message) : "Not found",
                            Details = result.Count > 0 ? Convert.ToString(result[0].Details) : "Not found",
                            Status = (int)ResponseStatusCode.NotFound,
                            ErrorMessage = result.Count > 0 ? Convert.ToString(result[0].ErrorMessage) : "Not found",
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

        [HttpGet("FindAllActiveAttraction")]
        public async Task<IActionResult> FindAllActiveAttraction()
        {
            try
            {
                var result = await domain.FindAllActiveAttraction();
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
                else
                {
                    return StatusCode((int)HttpStatusCode.NotFound, new ResultModel()
                    {
                        Data = string.Empty,
                        Message = result.Count > 0 ? Convert.ToString(result[0].Message) : "Not found",
                        Details = result.Count > 0 ? Convert.ToString(result[0].Details) : "Not found",
                        Status = (int)ResponseStatusCode.NotFound,
                        ErrorMessage = result.Count > 0 ? Convert.ToString(result[0].ErrorMessage) : "Not found",
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

        [HttpPost("ActiveInActiveAttraction")]
        [Authorize]
        public async Task<IActionResult> ActiveInActiveAttraction(AttractionIDEntity entity)
        {
            try
            {
                var token = HttpContext.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();
                string userId = JwtMiddleware.GetUserIdFromToken(token).ToString();
                entity.UpdatedBy = userId;
                if (!string.IsNullOrEmpty(userId) && userId != "0")
                {
                    var result = await domain.ActiveInActiveAttraction(entity);
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

        [Authorize]
        [HttpPost("AttractionImageUpdate")]
        public async Task<ResultModel> AttractionImageUpdate([FromForm] AttractionImage docs)
        {
            try
            {
                var token = HttpContext.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();
                string userId = JwtMiddleware.GetUserIdFromToken(token).ToString();
                string UpdatedBy = userId;
                string MainImage = string.Empty;
                string BannerImage = string.Empty;
                if ((docs.MainImage != null && docs.MainImage.Length > 0))
                {
                    string originalFileName = Path.GetFileName(docs.MainImage.FileName);
                    string fileName = Path.GetFileName(originalFileName);
                    MainImage = $"{DateTime.Now.Ticks}.webp";
                    string physicalFolderPath = Path.Combine(
                                      CommonRepositoryConstants.ImageFilePath,
                                      CommonRepositoryConstants.documentsFolder
                                      );
                    if (!Directory.Exists(physicalFolderPath))
                    {
                        Directory.CreateDirectory(physicalFolderPath);
                    }

                    string physicalFileFullPath = Path.Combine(physicalFolderPath, MainImage);
                    await ImageHelper.CompressWithSkia(docs.MainImage, physicalFileFullPath);
                }
                if ((docs.BannerImage != null && docs.BannerImage.Length > 0))
                {
                    string originalFileName = Path.GetFileName(docs.BannerImage.FileName);
                    string fileName = Path.GetFileName(originalFileName);
                    BannerImage = $"{DateTime.Now.Ticks}.webp";
                    string physicalFolderPath = Path.Combine(
                                      CommonRepositoryConstants.ImageFilePath,
                                      CommonRepositoryConstants.documentsFolder
                                      );
                    if (!Directory.Exists(physicalFolderPath))
                    {
                        Directory.CreateDirectory(physicalFolderPath);
                    }
                    string physicalFileFullPath = Path.Combine(physicalFolderPath, BannerImage);
                    await ImageHelper.CompressWithSkia(docs.BannerImage, physicalFileFullPath);
                }
                var Documents = new List<AttratcionsDocumentsImage>();
                if (docs.attachment != null)
                {
                    foreach (var item in docs.attachment)
                    {
                        if (docs != null && item.Length > 0)
                        {
                            string originalFileName = Path.GetFileName(item.FileName);
                            string fileName = Path.GetFileName(originalFileName);
                            string physicalFileName = $"{DateTime.Now.Ticks}.webp";
                            string physicalFolderPath = Path.Combine(
                                                     CommonRepositoryConstants.ImageFilePath,
                                                     CommonRepositoryConstants.documentsFolder
                                                     );
                            if (!Directory.Exists(physicalFolderPath))
                            {
                                Directory.CreateDirectory(physicalFolderPath);
                            }
                            string physicalFileFullPath = Path.Combine(physicalFolderPath, physicalFileName);
                            await ImageHelper.CompressWithSkia(item, physicalFileFullPath);
                            var InnerDocument = new AttratcionsDocumentsImage();
                            InnerDocument.FileName = physicalFileName;
                            Documents.Add(InnerDocument);
                        }
                    }
                }

                var result = await domain.AttractionImageUpdate(MainImage, BannerImage, Documents.ToList(), docs.AttractionID, UpdatedBy);
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

        [HttpPost("AttractionFindByURL")]
        public async Task<IActionResult> AttractionFindByURL(AttractionIDEntity entity)
        {
            try
            {
                var result = await domain.AttractionFindByURL(entity);
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

        [HttpPost("DeleteAttractionImages")]
        [Authorize]
        public async Task<IActionResult> DeleteAttractionImages(AttractionIDEntity entity)
        {
            try
            {
                var token = HttpContext.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();
                string userId = JwtMiddleware.GetUserIdFromToken(token).ToString();
                entity.UpdatedBy = userId;
                if (!string.IsNullOrEmpty(userId) && userId != "0")
                {
                    var result = await domain.DeleteAttractionImages(entity);
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
    }
}
