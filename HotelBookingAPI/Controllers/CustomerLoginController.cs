using HotelBooking.Domain.Interfaces;
using HotelBooking.Entity.Common;
using HotelBooking.Entity.Common.Entities;
using HotelBooking.Entity.Common.Enums;
using HotelBooking.Entity.Entities;
using HotelBooking.Helpers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace HotelBooking.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerLoginController : ControllerBase
    {
        private readonly ICustomerLoginDomain domain;

        private readonly IWebHostEnvironment _webHostEnvironment;

        public CustomerLoginController(ILogger<CustomerLoginController> _logger, ICustomerLoginDomain _UserLoginDomain)
        {
            domain = _UserLoginDomain;
        }

        #region User Login
        [HttpPost("CustomerLogin")]
        //[Authorize]
        public async Task<IActionResult> UserLogin(LoginRequestsEntity entity)
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

        #region User Signup
        [HttpPost("CustomerSignup")]
        //[Authorize]
        public async Task<IActionResult> UserSignup(LoginRequestsEntity entity)
        {

            try
            {
                //var token = HttpContext.Request.Headers["Authorization"]
                // .FirstOrDefault()?.Split(" ").Last();

                //int userId = JwtMiddleware.GetUserIdFromToken(token);
                //int isUser = JwtMiddleware.GetIsUserFromToken(token);


                var result = await domain.UserSignup(entity);
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
        #region Otp Genearte
        [HttpPost("CustomerOtpGenerate")]
        //[Authorize]
        public async Task<IActionResult> OtpGenerate(LoginRequestsEntity entity)
        {

            try
            {
                //var token = HttpContext.Request.Headers["Authorization"]
                // .FirstOrDefault()?.Split(" ").Last();

                //int userId = JwtMiddleware.GetUserIdFromToken(token);
                //int isUser = JwtMiddleware.GetIsUserFromToken(token);


                var result = await domain.OtpGenerate(entity);
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

        #region Verify Otp Generate
        [HttpPost("CustomerVerifyOtpGenerate")]
        //[Authorize]
        public async Task<IActionResult> VerifyOtpGenerate(LoginRequestsEntity entity)
        {

            try
            {

                var result = await domain.VerifyOtpGenerate(entity);
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

        #region EmailVerification 
        [HttpPost("CustomerEmailVerification")]
        //[Authorize]
        public async Task<IActionResult> EmailVerification(EmailVerificationEntity entity)
        {

            try
            {
                //var token = HttpContext.Request.Headers["Authorization"]
                // .FirstOrDefault()?.Split(" ").Last();

                //int userId = JwtMiddleware.GetUserIdFromToken(token);
                //int isUser = JwtMiddleware.GetIsUserFromToken(token);


                var result = await domain.EmailVerification(entity);
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

        #region Mobile Verification
        [HttpPost("CustomerMobileVerification")]
        //[Authorize]
        public async Task<IActionResult> MobileVerification(EmailVerificationEntity entity)
        {

            try
            {
                var result = await domain.MobileVerification(entity);
                if (result != null && result.Message == "success")
                {
                    return StatusCode((int)HttpStatusCode.OK, new ResultModel()
                    {
                        Status = (int)ResponseStatusCode.Success,
                        Message = Convert.ToString(result.Message),
                        Details = Convert.ToString(result.Details),
                        Data = string.Empty,
                    });
                }
                else
                {
                    return StatusCode((int)HttpStatusCode.BadRequest, new ResultModel()
                    {
                        Data = string.Empty,
                        Message = result?.Message ?? CommonRepositoryMessages.NotFoundMessageEN,
                        Details = result?.Details ?? CommonRepositoryMessages.NotFoundMessageEN,
                        Status = (int)ResponseStatusCode.BadRequestError,
                        ErrorMessage = result?.ErrorMessage ?? CommonRepositoryMessages.NotFoundMessageEN,
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
        #region   Emaile Otp Approve
        [HttpPost("CustomerEmailOtpApprove")]
        // [Authorize]
        public async Task<IActionResult> EmailOtpApprove(EmailVerificationEntity entity)
        {

            try
            {
                //var token = HttpContext.Request.Headers["Authorization"]
                //.FirstOrDefault()?.Split(" ").Last();

                //int userId = JwtMiddleware.GetUserIdFromToken(token);
                int userId = 1;

                if (userId != 0)
                {

                    var result = await domain.EmailOtpApprove(entity);
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

        #region UpdateCustomer
        [HttpPost("UpdateCustomer")]
        //[Authorize]
        public async Task<IActionResult> UpdateCustomer(CustomerEntity entity)
        {
            try
            {
                //var token = HttpContext.Request.Headers["Authorization"]
                //    .FirstOrDefault()?.Split(" ").Last();
                //int userId = JwtMiddleware.GetUserIdFromToken(token);
                //entity.UpdatedBy = userId;
                int userId = 1;

                if (userId != 0)
                {
                    var result = await domain.UpdateCustomer(entity);
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

        #region Find By ID Color
        [HttpPost("FindByIDCustomer")]
        //[Authorize]
        public async Task<IActionResult> FindByIDCustomer(ColorIDEntity entity)
        {
            try
            {
                //var token = HttpContext.Request.Headers["Authorization"]
                //    .FirstOrDefault()?.Split(" ").Last();
                //int userId = JwtMiddleware.GetUserIdFromToken(token);
                int userId = 1;

                if (userId != 0)
                {
                    var result = await domain.FindByIDCustomer(entity);
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


        #region Find All Customer
        [HttpPost("FindAllCustomer")]
        [Authorize]
        public async Task<IActionResult> FindAllCustomer(CustomerListRequestEntity entity)
        {
            try
            { var token = HttpContext.Request.Headers["Authorization"]
                    .FirstOrDefault()?.Split(" ").Last();
            int userId = JwtMiddleware.GetUserIdFromToken(token);

                if (userId != 0)
                {
                    var result = await domain.FindAllCustomer(entity);
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


        #region CustomerDetailsByID
        [HttpPost("CustomerDetailsByID")]
        [Authorize]
        public async Task<IActionResult> CustomerDetailsByID(ColorIDEntity entity)
        {
            try
            {
                var token = HttpContext.Request.Headers["Authorization"]
                    .FirstOrDefault()?.Split(" ").Last();
                int userId = JwtMiddleware.GetUserIdFromToken(token);
          

                if (userId != 0)
                {
                    var result = await domain.CustomerDetailsByID(entity);
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


        #region Find All Payment
        [HttpPost("FindAllPayment")]
        [Authorize]
        public async Task<IActionResult> FindAllPayment(OrderPaymentRequestEntity entity)
        {
            try
            {
                var token = HttpContext.Request.Headers["Authorization"]
                    .FirstOrDefault()?.Split(" ").Last();
                int userId = JwtMiddleware.GetUserIdFromToken(token);

                if (userId != 0)
                {
                    var result = await domain.FindAllPayment(entity);
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

        #region Payment Details By ID
        [HttpPost("PaymentDetailsByID")]
        [Authorize]
        public async Task<IActionResult> PaymentDetailsByID(OrderPaymentDetailsRequestEntity entity)
        {
            try
            {
                var token = HttpContext.Request.Headers["Authorization"]
                    .FirstOrDefault()?.Split(" ").Last();
                int userId = JwtMiddleware.GetUserIdFromToken(token);

                if (userId != 0)
                {
                    var result = await domain.PaymentDetailsByID(entity);
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
