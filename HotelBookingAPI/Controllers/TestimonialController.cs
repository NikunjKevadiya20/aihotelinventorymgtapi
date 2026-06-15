using HotelBooking.Domain.Interfaces;
using HotelBooking.Entity.Common.Entities;
using HotelBooking.Entity.Common.Enums;
using HotelBooking.Entity.Common;
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
    public class TestimonialController : ControllerBase
    {
        private readonly ITestimonialDomain domain;
        //private readonly IMapper _mapper;
        //private IMapper mapper;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public TestimonialController(ILogger<TestimonialController> _logger, ITestimonialDomain _TestimonialDomain)
        {
            domain = _TestimonialDomain;
            //_mapper = mapper;
        }


        #region Insert Testimonial

        [HttpPost("InsertTestimonial")]
        [Authorize]
        public async Task<IActionResult> InsertTestimonial(TestimonialEntity entity)
        {
            try
            {
                var token = HttpContext.Request.Headers["Authorization"]
                    .FirstOrDefault()?.Split(" ").Last();

                int userId = JwtMiddleware.GetUserIdFromToken(token);
                entity.CreatedBy = userId;
                if (userId != 0)
                {

                    var result = await domain.InsertTestimonial(entity);

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

        #region Update Testimonial
        [HttpPost("UpdateTestimonial")]
        [Authorize]
        public async Task<IActionResult> UpdateTestimonial(TestimonialEntity entity)
        {

            try
            {
                var token = HttpContext.Request.Headers["Authorization"]
                 .FirstOrDefault()?.Split(" ").Last();

                int userId = JwtMiddleware.GetUserIdFromToken(token);
                entity.UpdatedBy = userId;
                if (userId != 0)
                {
                    var result = await domain.UpdateTestimonial(entity);
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


        #region Delete Testimonial
        [HttpPost("DeleteTestimonial")]
        [Authorize]
        public async Task<IActionResult> DeleteTestimonial(TestimonialIDEntity entity)
        {

            try
            {
                var token = HttpContext.Request.Headers["Authorization"]
                .FirstOrDefault()?.Split(" ").Last();

                int userId = JwtMiddleware.GetUserIdFromToken(token);
                entity.UpdatedBy = userId;
                if (userId != 0)
                {

                    var result = await domain.DeleteTestimonial(entity);
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

        #region Find By ID Testimonial
        [HttpPost("FindByIDTestimonial")]
        [Authorize]
        public async Task<IActionResult> FindByIDTestimonial(TestimonialIDEntity entity)
        {

            try
            {
                var token = HttpContext.Request.Headers["Authorization"]
                .FirstOrDefault()?.Split(" ").Last();

                int userId = JwtMiddleware.GetUserIdFromToken(token);

                if (userId != 0)
                {

                    var result = await domain.FindByIDTestimonial(entity);
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

        #region Find All Active Testimonial
        [HttpPost("FindAllTestimonial")]
        [Authorize]
        public async Task<IActionResult> FindAllTestimonial(TestimonialIDEntity entity)
        {

            try
            {
                var token = HttpContext.Request.Headers["Authorization"]
                .FirstOrDefault()?.Split(" ").Last();

                int userId = JwtMiddleware.GetUserIdFromToken(token);

                if (userId != 0)
                {

                    var result = await domain.FindAllTestimonial(entity);
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

        #region Find All Testimonial
        [HttpGet("FindAllActiveTestimonial")]

        public async Task<IActionResult> FindAllActiveTestimonial()
        {

            try
            {
                //var token = HttpContext.Request.Headers["Authorization"]
                //.FirstOrDefault()?.Split(" ").Last();

                //int userId = JwtMiddleware.GetUserIdFromToken(token);

                //if (userId != 0)
                //{
                var result = await domain.FindAllActiveTestimonial();
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

        #region ActiveInActive Testimonial
        [HttpPost("ActiveInActiveTestimonial")]
        [Authorize]
        public async Task<IActionResult> ActiveInActiveTestimonial(TestimonialIDEntity entity)
        {

            try
            {
                var token = HttpContext.Request.Headers["Authorization"]
                .FirstOrDefault()?.Split(" ").Last();

                int userId = JwtMiddleware.GetUserIdFromToken(token);
                entity.UpdatedBy = userId;
                if (userId != 0)
                {

                    var result = await domain.ActiveInActiveTestimonial(entity);
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


        #region Testimonial Image Update
        [Authorize]
        [HttpPost("TestimonialImageUpdate")]
        public async Task<ResultModel> TestimonialImageUpdate([FromForm] TestimonialImageDataEntity docs)
        {
            try
            {

                var token = HttpContext.Request.Headers["Authorization"]
               .FirstOrDefault()?.Split(" ").Last();

                int userId = JwtMiddleware.GetUserIdFromToken(token);
                int isUser = JwtMiddleware.GetIsUserFromToken(token);

                int UpdatedBy = userId;

                string physicalFileName = string.Empty;


                if ((docs.TestimonialImage != null && docs.TestimonialImage.Length > 0))
                {

                    string originalFileName = Path.GetFileName(docs.TestimonialImage.FileName);


                    string fileName = Path.GetFileName(originalFileName);



                    physicalFileName = $"{DateTime.Now.Ticks}" +
                                $"{Path.GetExtension(fileName)}";

                    string physicalFolderPath = CommonRepositoryConstants.ImageFilePath + CommonRepositoryConstants.TestimonialImage;


                    if (!Directory.Exists(physicalFolderPath))
                    {
                        Directory.CreateDirectory(physicalFolderPath);
                    }

                    string physicalFileFullPath = Path.Combine(physicalFolderPath, physicalFileName);

                    using var stream = System.IO.File.Create(physicalFileFullPath);

                    // Upload File
                    await docs.TestimonialImage.CopyToAsync(stream);


                }


                var result = await domain.TestimonialImageUpdate(physicalFileName, docs.ID, UpdatedBy);

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

        #region Find All Testimonial URL 
        [HttpPost("FindAllActiveTestimonialURL")]

        public async Task<IActionResult> FindAllActiveTestimonialURL(TestimonialIDEntity entity)
        {

            try
            {
                //var token = HttpContext.Request.Headers["Authorization"]
                //.FirstOrDefault()?.Split(" ").Last();

                //int userId = JwtMiddleware.GetUserIdFromToken(token);

                //if (userId != 0)
                //{
                var result = await domain.FindAllActiveTestimonialURL(entity);
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
