using HotelBooking.Domain.Interfaces;
using HotelBooking.Entity.Common;
using HotelBooking.Entity.Common.Entities;
using HotelBooking.Entity.Common.Enums;
using HotelBooking.Entity.Entities;
using HotelBooking.Helpers;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using OfficeOpenXml;
using SkiaSharp;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Net;
using System.Text.RegularExpressions;
using HotelBooking.Entity.Common.Helper;

namespace HotelBooking.Controllers
{
    /// <summary>
    /// Added by NikunjK on 01-08-2023
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class HotelsController : ControllerBase
    {
        private readonly IHotelsDomain domain;
        private readonly ILogger<HotelsController> _logger;

        static HotelsController()
        {
            ExcelPackage.License.SetNonCommercialPersonal("Product");
        }

        public HotelsController(ILogger<HotelsController> logger, IHotelsDomain hotelsDomain)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger)); // Null check for logger
            domain = hotelsDomain ?? throw new ArgumentNullException(nameof(hotelsDomain)); // Null check
        }



        #region Insert Hotels

        [HttpPost("InsertHotels")]
        [Authorize]
        public async Task<IActionResult> InsertHotels(HotelsDataEntity entity)
        {
            try
            {
                var token = HttpContext.Request.Headers["Authorization"]
                    .FirstOrDefault()?.Split(" ").Last();

                int userId = JwtMiddleware.GetUserIdFromToken(token);
                entity.CreatedBy = userId;
                if (userId != 0)
                {

                    var result = await domain.InsertHotels(entity);

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

        #region Update Hotels
        [HttpPost("UpdateHotels")]
        [Authorize]
        public async Task<IActionResult> UpdateHotels(HotelsDataEntity entity)
        {

            try
            {
                var token = HttpContext.Request.Headers["Authorization"]
                 .FirstOrDefault()?.Split(" ").Last();

                int userId = JwtMiddleware.GetUserIdFromToken(token);
                entity.UpdatedBy = userId;
                if (userId != 0)
                {
                    var result = await domain.UpdateHotels(entity);
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

        #region Delete Hotels
        [HttpPost("DeleteHotels")]
        [Authorize]
        public async Task<IActionResult> DeleteHotels(HotelsIDEntity entity)
        {

            try
            {
                var token = HttpContext.Request.Headers["Authorization"]
                .FirstOrDefault()?.Split(" ").Last();

                int userId = JwtMiddleware.GetUserIdFromToken(token);
                int isUser = JwtMiddleware.GetIsUserFromToken(token);

                entity.DeletedBy = userId;
                entity.IsDeletedUser = isUser;



                if (userId != 0)
                {

                    var result = await domain.DeleteHotels(entity);
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

        #region Delete Hotel Image
        [HttpPost("DeleteHotelImage")]
        [Authorize]
        public async Task<IActionResult> DeleteHotelImage(HotelsIDEntity entity)
        {

            try
            {
                var token = HttpContext.Request.Headers["Authorization"]
                .FirstOrDefault()?.Split(" ").Last();

                int userId = JwtMiddleware.GetUserIdFromToken(token);
                int isUser = JwtMiddleware.GetIsUserFromToken(token);

                entity.DeletedBy = userId;
                entity.IsDeletedUser = isUser;



                if (userId != 0)
                {

                    var result = await domain.DeleteHotelImage(entity);
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

        #region Find By ID Hotels
        [HttpPost("FindByIDHotels")]
        [Authorize]
        public async Task<IActionResult> FindByIDHotels(HotelsIDEntity entity)
        {

            try
            {
                var token = HttpContext.Request.Headers["Authorization"]
                .FirstOrDefault()?.Split(" ").Last();

                int userId = JwtMiddleware.GetUserIdFromToken(token);

                if (userId != 0)
                {

                    var result = await domain.FindByIDHotels(entity);
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

        #region Find All Hotels
        [HttpPost("FindAllHotels")]
        [Authorize]
        public async Task<IActionResult> FindAllHotels(HotelsIDEntity entity)
        {

            try
            {
                var token = HttpContext.Request.Headers["Authorization"]
                .FirstOrDefault()?.Split(" ").Last();

                int userId = JwtMiddleware.GetUserIdFromToken(token);

                if (userId != 0)
                {

                    var result = await domain.FindAllHotels(entity);
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

        #region Find All Active Hotels
        [HttpGet("FindAllActiveHotels")]

        public async Task<IActionResult> FindAllActiveHotels([FromQuery] HotelsAvailabilityEntity entity)
        {

            try
            {


                int userId = 1;

                if (userId != 0)
                {
                    var result = await domain.FindAllActiveHotels(entity);
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

        #region ActiveInActive Hotels
        [HttpPost("ActiveInActiveHotels")]
        [Authorize]
        public async Task<IActionResult> ActiveInActiveHotels(HotelsIDEntity entity)
        {

            try
            {
                var token = HttpContext.Request.Headers["Authorization"]
                .FirstOrDefault()?.Split(" ").Last();

                int userId = JwtMiddleware.GetUserIdFromToken(token);
                entity.UpdatedBy = userId;
                if (userId != 0)
                {

                    var result = await domain.ActiveInActiveHotels(entity);
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


        #region Bulk Upload Hotels
        [HttpPost("BulkUploadHotelsOld")]//BulkUploadHotels
        public async Task<IActionResult> BulkUploadHotels(IFormFile file)
        {
            try
            {

                int userId = 1;
                if (userId != 0)
                {
                    if (file == null || file.Length == 0)
                    {
                        return StatusCode((int)HttpStatusCode.BadRequest, new ResultModel
                        {
                            Data = string.Empty,
                            Message = "No file uploaded.",
                            Details = "Please upload a valid Excel file.",
                            Status = (int)ResponseStatusCode.BadRequestError,
                            ErrorMessage = "File is required."
                        });
                    }


                    string uploadPath = CommonRepositoryConstants.ImageFilePath + CommonRepositoryConstants.Excel;

                    string fileName = $"{DateTime.Now:yyyyMMdd_HHmm}.xlsx";
                    string filePath = Path.Combine(uploadPath, fileName);

                    Directory.CreateDirectory(uploadPath);

                    // Save the file to the specified path
                    using (var fileStream = new FileStream(filePath, FileMode.Create, FileAccess.Write))
                    {
                        await file.CopyToAsync(fileStream);
                    }

                    using (var stream = new MemoryStream())
                    {
                        await file.CopyToAsync(stream);
                        using (var package = new ExcelPackage(stream))
                        {
                            var worksheet = package.Workbook.Worksheets["Sheet1"];
                            if (worksheet == null)
                            {
                                return StatusCode((int)HttpStatusCode.BadRequest, new ResultModel
                                {
                                    Data = string.Empty,
                                    Message = "Invalid Excel file structure.",
                                    Details = "File must contain 'Sheet1' sheet.",
                                    Status = (int)ResponseStatusCode.BadRequestError,
                                    ErrorMessage = "Missing required sheet."
                                });
                            }

                            var hotels = MapHotelData(worksheet, userId);
                            var hotelRateSpecialDates = MapHotelRateSpecialDates(worksheet);

                            var result = await domain.BulkUploadHotelData(hotels, hotelRateSpecialDates);

                            if (result.Message == "success")
                            {
                                return StatusCode((int)HttpStatusCode.OK, new ResultModel
                                {
                                    Status = (int)ResponseStatusCode.Success,
                                    Message = Convert.ToString(result.Message),
                                    Details = Convert.ToString(result.Details),
                                    Data = result,
                                });
                            }
                            else
                            {
                                return StatusCode((int)HttpStatusCode.BadRequest, new ResultModel
                                {
                                    Data = string.Empty,
                                    Message = Convert.ToString(result.Message),
                                    Details = Convert.ToString(result.Details),
                                    Status = (int)ResponseStatusCode.BadRequestError,
                                    ErrorMessage = Convert.ToString(result.ErrorMessage),
                                });
                            }
                        }
                    }
                }
                else
                {
                    return StatusCode((int)ResponseStatusCode.TokenExpired, new ResultModel
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
                return StatusCode((int)HttpStatusCode.InternalServerError, new ResultModel
                {
                    Message = CommonRepositoryMessages.NotFoundMessageEN,
                    Details = CommonRepositoryMessages.NotFoundMessageEN,
                    ErrorMessage = ex.Message,
                    Status = (int)ResponseStatusCode.InternaServerError,
                });
            }
        }

        private List<Hotel> MapHotelData(ExcelWorksheet worksheet, int? UserID)
        {
            var hotels = new List<Hotel>();
            for (int row = 2; row <= worksheet.Dimension.Rows; row++) // Start from row 2 dynamically
            {
                var hotelName = worksheet.Cells[row, 1].Text;
                if (string.IsNullOrEmpty(hotelName)) continue; // Process only when HotelName is not null/empty

                hotels.Add(new Hotel
                {
                    HotelName = hotelName,
                    Address = worksheet.Cells[row, 2].Text,
                    StateName = worksheet.Cells[row, 5].Text,
                    CountryName = worksheet.Cells[row, 6].Text,
                    CityName = worksheet.Cells[row, 4].Text,
                    HotelCategory = worksheet.Cells[row, 3].Text,
                    WeekDays = worksheet.Cells[row, 7].Text,
                    WeekEnds = worksheet.Cells[row, 8].Text,
                    ContactPersonName = worksheet.Cells[row, 9].Text,
                    ContactPersonMobileNo = worksheet.Cells[row, 10].Text,
                    ContactPersonEmailID = worksheet.Cells[row, 11].Text,
                    ContactPersonDesignation = worksheet.Cells[row, 12].Text,
                    UserID = UserID
                });
            }
            return hotels;
        }

        private List<HotelRateSpecialDate> MapHotelRateSpecialDates(ExcelWorksheet worksheet)
        {
            var rates = new List<HotelRateSpecialDate>();
            var dateRanges = new List<(int Row, string DateType, string DateRange)>();

            // Step 1: Collect all date range rows dynamically until HotelName or headers (EPAI) are found
            for (int row = 2; row <= worksheet.Dimension.Rows; row++)
            {
                var hotelName = worksheet.Cells[row, 1].Text;
                // Check if this row contains the rate header "EPAI" in column N (14)
                var potentialHeader = worksheet.Cells[row, 18].Text; // Check N column for EPAI
                if (!string.IsNullOrEmpty(hotelName) || (!string.IsNullOrEmpty(potentialHeader) && potentialHeader == "EPAI"))
                    break;

                // Check Off Season (N:Q) - Use the first non-empty cell as the range
                string offSeasonRange = worksheet.Cells[row, 18].Text.Trim();
                if (!string.IsNullOrEmpty(offSeasonRange) && offSeasonRange.Contains("-"))
                    dateRanges.Add((row, "OffSeason", offSeasonRange));

                // Check Mid Season (R:U) - Use the first non-empty cell as the range
                string midSeasonRange = worksheet.Cells[row, 28].Text.Trim();
                if (!string.IsNullOrEmpty(midSeasonRange) && midSeasonRange.Contains("-"))
                    dateRanges.Add((row, "MidSeason", midSeasonRange));

                // Check Peak Season (V:Y) - Use the first non-empty cell as the range
                string peakSeasonRange = worksheet.Cells[row, 38].Text.Trim();
                if (!string.IsNullOrEmpty(peakSeasonRange) && peakSeasonRange.Contains("-"))
                    dateRanges.Add((row, "PeakSeason", peakSeasonRange));
            }

            // Step 2: Process hotel rows and associate with date ranges hotel-wise
            for (int row = 2; row <= worksheet.Dimension.Rows; row++) // Start from 2 to catch the first hotel
            {
                var hotelName = worksheet.Cells[row, 1].Text;
                if (string.IsNullOrEmpty(hotelName)) continue;

                // Use rates from the current hotel row               
                decimal? sglOff, dblOff, exadOff, cwbOff, cnbOff, psglOff, pdblOff, pexadOff, pcwbOff, pcnbOff;     // Off season
                decimal? sglMid, dblMid, exadMid, cwbMid, cnbMid, psglMid, pdblMid, pexadMid, pcwbMid, pcnbMid;     // Mid season
                decimal? sglPeak, dblPeak, exadPeak, cwbPeak, cnbPeak, psglPeak, pdblPeak, pexadPeak, pcwbPeak, pcnbPeak;    // Peak season

                sglOff = ParseRate(worksheet.Cells[row, 18]);
                dblOff = ParseRate(worksheet.Cells[row, 19]);
                exadOff = ParseRate(worksheet.Cells[row, 20]);
                cwbOff = ParseRate(worksheet.Cells[row, 21]);
                cnbOff = ParseRate(worksheet.Cells[row, 22]);
                psglOff = ParseRate(worksheet.Cells[row, 23]);
                pdblOff = ParseRate(worksheet.Cells[row, 24]);
                pexadOff = ParseRate(worksheet.Cells[row, 25]);
                pcwbOff = ParseRate(worksheet.Cells[row, 26]);
                pcnbOff = ParseRate(worksheet.Cells[row, 27]);

                // Mid season
                sglMid = ParseRate(worksheet.Cells[row, 28]);
                dblMid = ParseRate(worksheet.Cells[row, 29]);
                exadMid = ParseRate(worksheet.Cells[row, 30]);
                cwbMid = ParseRate(worksheet.Cells[row, 31]);
                cnbMid = ParseRate(worksheet.Cells[row, 32]);
                psglMid = ParseRate(worksheet.Cells[row, 33]);
                pdblMid = ParseRate(worksheet.Cells[row, 34]);
                pexadMid = ParseRate(worksheet.Cells[row, 35]);
                pcwbMid = ParseRate(worksheet.Cells[row, 36]);
                pcnbMid = ParseRate(worksheet.Cells[row, 37]);

                // Peak season
                sglPeak = ParseRate(worksheet.Cells[row, 38]);
                dblPeak = ParseRate(worksheet.Cells[row, 39]);
                exadPeak = ParseRate(worksheet.Cells[row, 40]);
                cwbPeak = ParseRate(worksheet.Cells[row, 41]);
                cnbPeak = ParseRate(worksheet.Cells[row, 42]);
                psglPeak = ParseRate(worksheet.Cells[row, 43]);
                pdblPeak = ParseRate(worksheet.Cells[row, 44]);
                pexadPeak = ParseRate(worksheet.Cells[row, 45]);
                pcwbPeak = ParseRate(worksheet.Cells[row, 46]);
                pcnbPeak = ParseRate(worksheet.Cells[row, 47]);

                decimal? sgl = null, dbl = null, exad = null, cwb = null, cnb = null, psgl = null, pdbl = null, pexad = null, pcwb = null, pcnb = null;

                // Filter date ranges for the current hotel row or a reasonable range of preceding rows
                var currentHotelDateRanges = dateRanges.Where(dr => dr.Row == row || (dr.Row < row && dr.Row >= (row - 5000))).ToList();
                if (!currentHotelDateRanges.Any())
                {
                    // If no ranges for this row, try to use any remaining ranges (fallback for first hotel behavior)
                    currentHotelDateRanges = dateRanges.Where(dr => dr.Row < row).Take(3).ToList(); // Take up to 3 ranges as a fallback
                }

                foreach (var (dateRow, dateType, dateRange) in currentHotelDateRanges)
                {
                    var dateParts = dateRange.Split(new[] { '-' }, StringSplitOptions.RemoveEmptyEntries);
                    if (dateParts.Length != 2) continue;

                    string fromDateStr = dateParts[0].Trim();
                    string toDateStr = dateParts[1].Trim();

                    if (!DateTime.TryParse(fromDateStr, CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime fromDate) ||
                        !DateTime.TryParse(toDateStr, CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime toDate))
                    {
                        continue;
                    }

                    switch (dateType)
                    {
                        case "OffSeason":
                            sgl = sglOff; dbl = dblOff; exad = exadOff; cwb = cwbOff; cnb = cnbOff;
                            psgl = psglOff; pdbl = pdblOff; pexad = pexadOff; pcwb = pcwbOff; pcnb = pcnbOff;
                            break;
                        case "MidSeason":
                            sgl = sglMid; dbl = dblMid; exad = exadMid; cwb = cwbMid; cnb = cnbMid;
                            psgl = psglMid; pdbl = pdblMid; pexad = pexadMid; pcwb = pcwbMid; pcnb = pcnbMid;
                            break;
                        case "PeakSeason":
                            sgl = sglPeak; dbl = dblPeak; exad = exadPeak; cwb = cwbPeak; cnb = cnbPeak;
                            psgl = psglPeak; pdbl = pdblPeak; pexad = pexadPeak; pcwb = pcwbPeak; pcnb = pcnbPeak;
                            break;
                    }

                    decimal? kitchenCharges = null;
                    if (decimal.TryParse(worksheet.Cells[row, 16].Text.Trim(), out decimal tempKitchenCharges))
                    {
                        kitchenCharges = tempKitchenCharges != 0 ? (decimal?)tempKitchenCharges : null;
                    }

                    rates.Add(new HotelRateSpecialDate
                    {
                        HotelName = hotelName,
                        FestivalName = worksheet.Cells[row, 15].Text,
                        FromDate = fromDate.ToString("yyyy-MM-dd"),
                        ToDate = toDate.ToString("yyyy-MM-dd"),
                        RoomCategoryName = worksheet.Cells[row, 13].Text,
                        SingleOccupancyRate = sgl,
                        DoubleOccupancyRate = dbl,
                        ExtraPersonRate = exad,
                        ChildWithBedRate = cwb,
                        ChildWithoutBedRate = cnb,
                        SingleOccPurRate = psgl,
                        DoubleOccPurRate = pdbl,
                        ExtraPerPurRate = pexad,
                        CWBPurRate = pcwb,
                        CNBPurRate = pcnb,
                        KitchenCharges = kitchenCharges,
                        MealType = worksheet.Cells[row, 17].Text,
                        DateType = worksheet.Cells[row, 14].Text,
                    });
                }
            }

            return rates;
        }
        #endregion
        //---------------------------------------------------------------------------------------------------------------



        #region Bulk Upload Hotels New 
        [HttpPost("BulkUploadHotels")] //BulkUploadHotelsNew
        public async Task<IActionResult> BulkUploadHotelsNew(IFormFile file)
        {
            try
            {

                int userId = 1;
                if (userId != 0)
                {
                    if (file == null || file.Length == 0)
                    {
                        return StatusCode((int)HttpStatusCode.BadRequest, new ResultModel
                        {
                            Data = string.Empty,
                            Message = "No file uploaded.",
                            Details = "Please upload a valid Excel file.",
                            Status = (int)ResponseStatusCode.BadRequestError,
                            ErrorMessage = "File is required."
                        });
                    }


                    string uploadPath = CommonRepositoryConstants.ImageFilePath + CommonRepositoryConstants.Excel;

                    string fileName = $"{DateTime.Now:yyyyMMdd_HHmm}.xlsx";
                    string filePath = Path.Combine(uploadPath, fileName);

                    Directory.CreateDirectory(uploadPath);

                    // Save the file to the specified path
                    using (var fileStream = new FileStream(filePath, FileMode.Create, FileAccess.Write))
                    {
                        await file.CopyToAsync(fileStream);
                    }

                    using (var stream = new MemoryStream())
                    {
                        await file.CopyToAsync(stream);
                        using (var package = new ExcelPackage(stream))
                        {
                            var worksheets = package.Workbook.Worksheets;
                            if (worksheets == null)
                            {
                                return StatusCode((int)HttpStatusCode.BadRequest, new ResultModel
                                {
                                    Data = string.Empty,
                                    Message = "Invalid Excel file structure.",
                                    Details = "File must contain 'Sheet1' sheet.",
                                    Status = (int)ResponseStatusCode.BadRequestError,
                                    ErrorMessage = "Missing required sheet."
                                });
                            }

                            var allHotels = new List<HotelExcelExport>();
                            var allHotelRateSpecialDates = new List<HotelRateSpecialDateNew>();

                            foreach (var worksheet in worksheets)
                            {

                                if (worksheet.Dimension == null)
                                    continue;

                                try
                                {
                                    var hotels = MapHotelDataNew(worksheet, userId);
                                    var hotelRateSpecialDates = MapHotelRateSpecialDatesNew(worksheet);

                                    allHotels.AddRange(hotels);
                                    allHotelRateSpecialDates.AddRange(hotelRateSpecialDates);
                                }
                                catch (Exception ex)
                                {
                                    Console.WriteLine($"Error processing sheet '{worksheet.Name}': {ex.Message}");
                                }
                            }

                            var result = await domain.BulkUploadHotelDataNew(allHotels, allHotelRateSpecialDates);

                            if (result.Message == "success")
                            {
                                return StatusCode((int)HttpStatusCode.OK, new ResultModel
                                {
                                    Status = (int)ResponseStatusCode.Success,
                                    Message = Convert.ToString(result.Message),
                                    Details = Convert.ToString(result.Details),
                                    Data = result,
                                });
                            }
                            else
                            {
                                return StatusCode((int)HttpStatusCode.BadRequest, new ResultModel
                                {
                                    Data = string.Empty,
                                    Message = Convert.ToString(result.Message),
                                    Details = Convert.ToString(result.Details),
                                    Status = (int)ResponseStatusCode.BadRequestError,
                                    ErrorMessage = Convert.ToString(result.ErrorMessage),
                                });
                            }
                        }
                    }
                }
                else
                {
                    return StatusCode((int)ResponseStatusCode.TokenExpired, new ResultModel
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
                return StatusCode((int)HttpStatusCode.InternalServerError, new ResultModel
                {
                    Message = CommonRepositoryMessages.NotFoundMessageEN,
                    Details = CommonRepositoryMessages.NotFoundMessageEN,
                    ErrorMessage = ex.Message,
                    Status = (int)ResponseStatusCode.InternaServerError,
                });
            }
        }

        private List<HotelExcelExport> MapHotelDataNew(ExcelWorksheet worksheet, int? UserID)
        {
            var hotels = new List<HotelExcelExport>();
            bool inHotelBlock = false;
            string currentLocation = string.Empty;
            string currentHotelName = string.Empty;
            string currentStar = string.Empty;

            for (int row = 2; row <= worksheet.Dimension.Rows; row++) // Start from row 1 to catch headers and data 
            {
                var location = worksheet.Cells[row, 3].Text.Trim();
                var hotelName = worksheet.Cells[row, 1].Text.Trim();
                var star = worksheet.Cells[row, 3].Text.Trim();

                if (!string.IsNullOrEmpty(hotelName) && (hotelName).ToLower() != "extras")
                {
                    // New hotel block starts 
                    currentLocation = location;
                    currentHotelName = hotelName;
                    currentStar = star;
                    inHotelBlock = true;

                    // Add or update hotel if not already added 
                    var existingHotel = hotels.FirstOrDefault(h => h.HotelName == hotelName);
                    if (existingHotel == null)
                    {
                        hotels.Add(new HotelExcelExport
                        {
                            HotelName = hotelName,
                            CityName = location, // Location is city like Dwarka 
                            HotelCategory = star,
                            UserID = UserID
                        });
                    }
                    continue;
                }

                // Check for end of hotel block (next hotel or empty row after rooms/extras) 
                if (inHotelBlock && string.IsNullOrEmpty(location) && string.IsNullOrEmpty(hotelName) && string.IsNullOrEmpty(star))
                {
                    // Assume end if row after extras or blank 
                    inHotelBlock = false;
                }
            }
            return hotels;
        }


        private List<HotelRateSpecialDateNew> MapHotelRateSpecialDatesNew(ExcelWorksheet worksheet)
        {
            var rates = new List<HotelRateSpecialDateNew>();

            string currentHotelName = string.Empty;
            string currentLocation = string.Empty;
            // ============================
            // 1. READ SEASONS
            // ============================
            var seasonBlocks = new List<(int CpCol, int MapCol, List<(DateTime From, DateTime To)> Dates)>();
            var processedMerged = new HashSet<string>();

            for (int headerRow = 2; headerRow <= 5; headerRow++)
            {
                for (int col = 6; col <= worksheet.Dimension.Columns; col += 2)
                {
                    var cell = worksheet.Cells[headerRow, col];
                    string text = "";

                    if (cell.Merge)
                    {
                        var merge = worksheet.MergedCells.FirstOrDefault(a =>
                            worksheet.Cells[a].Start.Row <= headerRow &&
                            worksheet.Cells[a].End.Row >= headerRow &&
                            worksheet.Cells[a].Start.Column <= col &&
                            worksheet.Cells[a].End.Column >= col);

                        if (merge == null || !processedMerged.Add(merge))
                            continue;

                        text = worksheet.Cells[
                            worksheet.Cells[merge].Start.Row,
                            worksheet.Cells[merge].Start.Column
                        ].Text;
                    }
                    else
                    {
                        text = cell.Text;
                    }

                    if (string.IsNullOrWhiteSpace(text))
                        continue;

                    var matches = Regex.Matches(
                        text,
                        @"(\d{1,2}\s[A-Za-z]{3}\s\d{4})\s*-\s*(\d{1,2}\s[A-Za-z]{3}\s\d{4})"
                    );

                    var dates = new List<(DateTime, DateTime)>();
                    foreach (Match m in matches)
                    {
                        dates.Add((
                            DateTime.ParseExact(m.Groups[1].Value, "d MMM yyyy", CultureInfo.InvariantCulture),
                            DateTime.ParseExact(m.Groups[2].Value, "d MMM yyyy", CultureInfo.InvariantCulture)
                        ));
                    }

                    if (dates.Any())
                        seasonBlocks.Add((col, col + 1, dates));
                }
            }

            if (!seasonBlocks.Any())
                return rates;

            // ───────────────────────────────────────────────
            // 2. Process hotel rows + room categories (MODIFIED PART)
            // ───────────────────────────────────────────────
            for (int row = 5; row <= worksheet.Dimension.Rows; row++)
            {
                var location = worksheet.Cells[row, 2].Text.Trim();   // Column B
                var hotelName = worksheet.Cells[row, 3].Text.Trim();   // Column C
                var roomCategory = worksheet.Cells[row, 5].Text.Trim();   // Column E

                // Detect new hotel
                if (!string.IsNullOrEmpty(hotelName))
                {
                    currentHotelName = hotelName;
                    currentLocation = location;
                    // Do NOT continue here — allow processing rates on the same row if present
                }

                // Skip rows with no room category
                if (string.IsNullOrEmpty(roomCategory) || roomCategory.Contains("Extra") || roomCategory.Contains("Child"))
                    continue;

                // Process this room category for all season blocks
                foreach (var block in seasonBlocks)
                {
                    var cpRate = ParseRate(worksheet.Cells[row, block.CpCol].Text);
                    var mapRate = ParseRate(worksheet.Cells[row, block.MapCol].Text);

                    // For each date range in this block
                    foreach (var datePair in block.Dates)
                    {
                        string fromDate = datePair.From.ToString("yyyy-MM-dd");
                        string toDate = datePair.To.ToString("yyyy-MM-dd");

                        // Create CP entry
                        if (cpRate.HasValue)
                        {
                            rates.Add(new HotelRateSpecialDateNew
                            {
                                HotelName = currentHotelName,
                                FromDate = fromDate,
                                ToDate = toDate,
                                RoomCategoryName = roomCategory,
                                DoubleOccupancyRate = cpRate,
                                MealType = "CP",
                                DateType = "Weekdays"
                            });
                        }

                        // Create MAP entry
                        if (mapRate.HasValue)
                        {
                            rates.Add(new HotelRateSpecialDateNew
                            {
                                HotelName = currentHotelName,
                                FromDate = fromDate,
                                ToDate = toDate,
                                RoomCategoryName = roomCategory,
                                DoubleOccupancyRate = mapRate,
                                MealType = "MAP",
                                DateType = "Weekdays"
                            });
                        }
                    }
                }
            }

            return rates;
        }
        private decimal? ParseRate(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                return null;

            if (decimal.TryParse(value, NumberStyles.Any, CultureInfo.InvariantCulture, out decimal result))
                return result;

            return null;
        }


        #endregion
        //---------------------------------------------------------------------------------------------------------------

        public static decimal? ParseRate(ExcelRange cell)
        {
            if (!decimal.TryParse(cell.Text, out decimal value) || value == 0)
                return 0;
            return value;
        }
        [Authorize]
        [HttpPost("HotelImageUpdate")]
        public async Task<ResultModel> HotelImageUpdate([FromForm] HotelImageUploadEntity docs)
        {
            try
            {
                var token = HttpContext.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();
                int updatedBy = JwtMiddleware.GetUserIdFromToken(token);

                string mainImageFileName = string.Empty;
                string bannerImageFileName = string.Empty;
                string HotelLogoImageFileName = string.Empty;
                List<HotelImageListEntity> innerImages = new();

                // Save main image
                if (docs.MainImage != null && docs.MainImage.Length > 0)
                {
                    string mainFileName = $"{DateTime.Now.Ticks}{Path.GetExtension(docs.MainImage.FileName)}";
                    string folderPath = Path.Combine(CommonRepositoryConstants.ImageFilePath, CommonRepositoryConstants.documentsFolder);

                    if (!Directory.Exists(folderPath))
                        Directory.CreateDirectory(folderPath);

                    string fullPath = Path.Combine(folderPath, mainFileName);
                    await ImageHelper.CompressWithSkia(docs.MainImage, fullPath);

                    mainImageFileName = mainFileName;
                }

                // Save Banner image
                if (docs.BannerImage != null && docs.BannerImage.Length > 0)
                {
                    string bannerFileName = $"{DateTime.Now.Ticks}{Path.GetExtension(docs.BannerImage.FileName)}";
                    string folderPath = Path.Combine(CommonRepositoryConstants.ImageFilePath, CommonRepositoryConstants.documentsFolder);

                    if (!Directory.Exists(folderPath))
                        Directory.CreateDirectory(folderPath);

                    string fullPath = Path.Combine(folderPath, bannerFileName);
                    await ImageHelper.CompressWithSkia(docs.BannerImage, fullPath);

                    bannerImageFileName = bannerFileName;
                }

                // Save Banner image
                if (docs.HotelLogo != null && docs.HotelLogo.Length > 0)
                {
                    string HotelLogoFileName = $"{DateTime.Now.Ticks}{Path.GetExtension(docs.HotelLogo.FileName)}";
                    string folderPath = Path.Combine(CommonRepositoryConstants.ImageFilePath, CommonRepositoryConstants.documentsFolder);

                    if (!Directory.Exists(folderPath))
                        Directory.CreateDirectory(folderPath);

                    string fullPath = Path.Combine(folderPath, HotelLogoFileName);
                    await ImageHelper.CompressWithSkia(docs.HotelLogo, fullPath);

                    HotelLogoImageFileName = HotelLogoFileName;
                }

                //  Save inner images
                if (docs.InnerImages != null && docs.InnerImages.Count > 0)
                {
                    for (int i = 0; i < docs.InnerImages.Count; i++)
                    {
                        var item = docs.InnerImages[i];
                        if (item != null && item.Length > 0)
                        {
                            string innerFileName = $"{DateTime.Now.Ticks}{Path.GetExtension(item.FileName)}";
                            string folderPath = Path.Combine(CommonRepositoryConstants.ImageFilePath, CommonRepositoryConstants.documentsFolder);

                            if (!Directory.Exists(folderPath))
                                Directory.CreateDirectory(folderPath);

                            string fullPath = Path.Combine(folderPath, innerFileName);
                            await ImageHelper.CompressWithSkia(item, fullPath);

                            int? srNo = (docs.InnerImageSrNo != null && docs.InnerImageSrNo.Count > i) ? docs.InnerImageSrNo[i] : null;
                            string? remarks = (docs.InnerImageRemarks != null && docs.InnerImageRemarks.Count > i) ? docs.InnerImageRemarks[i] : null;

                            innerImages.Add(new HotelImageListEntity
                            {
                                ImagePath = innerFileName,
                                SrNo = srNo,
                                Remarks = remarks
                            });
                        }
                    }
                }

                // ✅ Create new clean entity for DB
                var entity = new HotelImageEntity
                {
                    ID = docs.ID,
                    MainImage = mainImageFileName,
                    BannerImage = bannerImageFileName,
                    HotelLogo = HotelLogoImageFileName,
                    InnerImages = innerImages,
                    UpdatedBy = updatedBy
                };

                var result = await domain.HotelImageUpdate(entity); // <-- call domain with ProjectsEntity

                return new ResultModel
                {
                    Status = (int)ResponseStatusCode.Success,
                    Message = result.Message,
                    Details = result.Details,
                    Data = result
                };
            }
            catch (Exception ex)
            {
                return new ResultModel
                {
                    Status = (int)ResponseStatusCode.InternaServerError,
                    Message = CommonRepositoryMessages.CannotInsertDetails,
                    ErrorMessage = ex.Message
                };
            }
        }

        #region Find By URL Hotels
        [HttpPost("FindByURLHotels")]
        public async Task<IActionResult> FindByURLHotels(HotelsIDEntity entity)
        {

            try
            {
                int userId = 1;

                if (userId != 0)
                {

                    var result = await domain.FindByURLHotels(entity);
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

        #region HotelsListForWebsite
        [HttpPost("HotelsListForWebsite")]

        public async Task<IActionResult> HotelsListForWebsite(HotelsIDEntity entity)
        {

            try
            {
                int userId = 1;

                if (userId != 0)
                {

                    var result = await domain.HotelsListForWebsite(entity);
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

        #region FindAllHotelsForDropdown
        [HttpPost("FindAllHotelsForDropdown")]
        [Authorize]
        public async Task<IActionResult> FindAllHotelsForDropdown(HotelsIDEntity entity)
        {

            try
            {
                var token = HttpContext.Request.Headers["Authorization"]
                .FirstOrDefault()?.Split(" ").Last();

                int userId = JwtMiddleware.GetUserIdFromToken(token);

                if (userId != 0)
                {

                    var result = await domain.FindAllHotelsForDropdown(entity);
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

        #region Hotel Search For Website
        [HttpPost("HotelSearchForWebsite")]

        public async Task<IActionResult> HotelSearchForWebsite(HotelsIDEntity entity)
        {

            try
            {
                int userId = 1;

                if (userId != 0)
                {

                    var result = await domain.HotelSearchForWebsite(entity);
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


        #region City List For Website
        [HttpGet("CityListForWebsite")]
        public async Task<IActionResult> CityListForWebsite()
        {

            try
            {

                int userId = 1;

                if (userId != 0)
                {
                    var result = await domain.CityListForWebsite();
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

        #region Insert Hotel Room Avalability

        [HttpPost("InsertHotelRoomAvalability")]
        [Authorize]
        public async Task<IActionResult> InsertHotelRoomAvalability(HotelRoomEntity entity)
        {
            try
            {
                var token = HttpContext.Request.Headers["Authorization"]
                    .FirstOrDefault()?.Split(" ").Last();

                int userId = JwtMiddleware.GetUserIdFromToken(token);
                if (userId != 0)
                {

                    var result = await domain.InsertHotelRoomAvalability(entity);

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

        #region Find All Hotel Room Avalability
        [HttpPost("FindAllHotelRoomAvalability")]
        [Authorize]
        public async Task<IActionResult> FindAllHotelRoomAvalability(HotelsIDEntity entity)
        {

            try
            {
                var token = HttpContext.Request.Headers["Authorization"]
                .FirstOrDefault()?.Split(" ").Last();

                int userId = JwtMiddleware.GetUserIdFromToken(token);

                if (userId != 0)
                {

                    var result = await domain.FindAllHotelRoomAvalability(entity);
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

        #region Insert Hotel PriceRange

        [HttpPost("InsertHotelPriceRange")]
        [Authorize]
        public async Task<IActionResult> InsertHotelPriceRange(HotelPriceRangeEntity entity)
        {
            try
            {
                var token = HttpContext.Request.Headers["Authorization"]
                    .FirstOrDefault()?.Split(" ").Last();

                int userId = JwtMiddleware.GetUserIdFromToken(token);
                if (userId != 0)
                {

                    var result = await domain.InsertHotelPriceRange(entity);

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

        #region Find All Hotel PriceRange
        [HttpPost("FindAllHotelPriceRange")]
        //[Authorize]
        public async Task<IActionResult> FindAllHotelPriceRange(HotelPriceEntity entity)
        {

            try
            {
                //var token = HttpContext.Request.Headers["Authorization"]
                //.FirstOrDefault()?.Split(" ").Last();

                //int userId = JwtMiddleware.GetUserIdFromToken(token);

                int userId = 1;

                if (userId != 0)
                {

                    var result = await domain.FindAllHotelPriceRange(entity);
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


        #region FindAllAvailableHotelRoomPrice
        [HttpPost("FindAllAvailableHotelRoomPrice")]
        [Authorize]
        public async Task<IActionResult> FindAllHotelPriceRange(HotelsIDEntity entity)
        {

            try
            {
                var token = HttpContext.Request.Headers["Authorization"]
                .FirstOrDefault()?.Split(" ").Last();

                int userId = JwtMiddleware.GetUserIdFromToken(token);

                if (userId != 0)
                {

                    var result = await domain.FindAllAvailableHotelRoomPrice(entity);
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

        #region Find All Hotel PriceRange
        [HttpPost("FindAllHotelPriceTicketAvaibility")]
        //[Authorize]
        public async Task<IActionResult> FindAllHotelPriceTicketAvaibility(HotelPriceEntity entity)
        {

            try
            {
                //var token = HttpContext.Request.Headers["Authorization"]
                //.FirstOrDefault()?.Split(" ").Last();

                //int userId = JwtMiddleware.GetUserIdFromToken(token);

                int userId = 1;

                if (userId != 0)
                {

                    var result = await domain.FindAllHotelPriceTicketAvaibility(entity);
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
 

     #region HotelPriceByHotelRoom
        [HttpPost("HotelPriceByHotelRoom")]
        [Authorize]
        public async Task<IActionResult> HotelPriceByHotelRoom(HotelPriceEntity entity)
        {

            try
            {
                var token = HttpContext.Request.Headers["Authorization"]
                .FirstOrDefault()?.Split(" ").Last();

                int userId = JwtMiddleware.GetUserIdFromToken(token);

                if (userId != 0)
                {

                    var result = await domain.HotelPriceByHotelRoom(entity);
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

        #region Insert Hotel PriceRange

        [HttpPost("InsertHotelBookingPackagePrice")]
        [Authorize]
        public async Task<IActionResult> InsertHotelBookingPackagePrice(HotelBookingPackagePriceEntity entity)
        {
            try
            {
                var token = HttpContext.Request.Headers["Authorization"]
                    .FirstOrDefault()?.Split(" ").Last();

                int userId = JwtMiddleware.GetUserIdFromToken(token);
                if (userId != 0)
                {

                    var result = await domain.InsertHotelBookingPackagePrice(entity);

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

        #region Find All Hotel PriceRange
        [HttpPost("FindAllHotelBookingPackagePrice")]
        //[Authorize]
        public async Task<IActionResult> FindAllHotelBookingPackagePrice(HotelBookingPackagePriceEntity entity)
        {

            try
            {
                //var token = HttpContext.Request.Headers["Authorization"]
                //.FirstOrDefault()?.Split(" ").Last();

                //int userId = JwtMiddleware.GetUserIdFromToken(token);

                int userId = 1;

                if (userId != 0)
                {

                    var result = await domain.FindAllHotelBookingPackagePrice(entity);
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
