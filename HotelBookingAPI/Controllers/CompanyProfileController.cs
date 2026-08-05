using DocumentFormat.OpenXml.Spreadsheet;
using HotelBooking.Domain.Interfaces;
using HotelBooking.Entity.Common;
using HotelBooking.Entity.Common.Entities;
using HotelBooking.Entity.Common.Enums;
using HotelBooking.Entity.Common.Helper;
using HotelBooking.Entity.Entities;
using HotelBooking.Helpers;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace HotelBooking.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyProfileController : ControllerBase
    {
        private readonly ICompanyProfileDomain _domain;
        private readonly ILogger<CompanyProfileController> _logger;
        public CompanyProfileController(ILogger<CompanyProfileController> logger, ICompanyProfileDomain domain)
        {
            _logger = logger;
            _domain = domain;
        }
        [HttpPost("InsertCompanyProfile")]
        [Authorize]
        public async Task<IActionResult> InsertCompanyProfile(CompanyProfile entity)
        {
            try
            {
                var token = HttpContext.Request.Headers["Authorization"]
                    .FirstOrDefault()?.Split(" ").Last();
                int userId = JwtMiddleware.GetUserIdFromToken(token);
                entity.CreatedBy = userId;
                if (userId != 0)
                {
                    entity.CreatedBy = userId;
                    entity.UpdatedBy = userId; // Added for Update block in OperationType 1
                    var result = await _domain.InsertCompanyProfile(entity);
                    if (result.Message == "success")
                    {
                        return StatusCode((int)HttpStatusCode.Created, new ResultModel()
                        {
                            Status = (int)ResponseStatusCode.Created,
                            Message = Convert.ToString(result.Message),
                            Details = Convert.ToString(result.Details),
                            Data = result.Data
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
                            ErrorMessage = Convert.ToString(result.ErrorMessage)
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
                        Status = (int)ResponseStatusCode.TokenExpired
                    });
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return StatusCode((int)HttpStatusCode.InternalServerError, new ResultModel()
                {
                    Message = CommonRepositoryMessages.NotFoundMessageEN,
                    Details = CommonRepositoryMessages.NotFoundMessageEN,
                    ErrorMessage = ex.Message,
                    Status = (int)ResponseStatusCode.InternaServerError
                });
            }
        }
        [HttpGet("GetCompanyProfile")]
        [Authorize]
        public async Task<IActionResult> GetCompanyProfile()
        {
            try
            {
                var token = HttpContext.Request.Headers["Authorization"]
                    .FirstOrDefault()?.Split(" ").Last();
                int userId = JwtMiddleware.GetUserIdFromToken(token);
                if (userId != 0)
                {
                    var result = await _domain.GetCompanyProfile();
                    if (result.Message == "success")
                    {
                        return StatusCode((int)HttpStatusCode.OK, new ResultModel()
                        {
                            Status = (int)ResponseStatusCode.Success,
                            Message = Convert.ToString(result.Message),
                            Details = Convert.ToString(result.Details),
                            Data = result
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
                            ErrorMessage = Convert.ToString(result.ErrorMessage)
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
                        Status = (int)ResponseStatusCode.TokenExpired
                    });
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return StatusCode((int)HttpStatusCode.InternalServerError, new ResultModel()
                {
                    Message = CommonRepositoryMessages.NotFoundMessageEN,
                    Details = CommonRepositoryMessages.NotFoundMessageEN,
                    ErrorMessage = ex.Message,
                    Status = (int)ResponseStatusCode.InternaServerError
                });
            }
        }


        #region Experience Image Update
        [HttpPost("CompanyProfileImageUpdate")]
        public async Task<IActionResult> CompanyProfileImageUpdate([FromForm] ExperienceImageDataEntity docs)
        {
            try
            {
                int updatedBy = 1;
                string Image = string.Empty;


                string folderPath = Path.Combine(CommonRepositoryConstants.ImageFilePath, CommonRepositoryConstants.documentsFolder);

                if (!Directory.Exists(folderPath))
                    Directory.CreateDirectory(folderPath);

                if (docs.Image != null && docs.Image.Length > 0)
                {
                    string fileName = Path.GetFileName(docs.Image.FileName);
                    string fileExtension = Path.GetExtension(fileName);
                    Image = $"{DateTime.Now.Ticks}.webp";
                    string filePath = Path.Combine(folderPath, Image);
                    await ImageHelper.CompressWithSkia(docs.Image, filePath);

                }



                var result = await _domain.CompanyProfileImageUpdate(Image, updatedBy);

                return Ok(new ResultModel()
                {
                    Status = (int)ResponseStatusCode.Success,
                    Message = result.Message,
                    Details = result.Details,
                    Data = result,
                    ErrorMessage = result.ErrorMessage
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error in ExperienceImageUpdate");
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
    }
}
