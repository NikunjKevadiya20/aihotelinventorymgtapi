using Dapper;
using DapperParameters;
using Microsoft.Extensions.Logging;
using HotelBooking.Entity.Common;
using HotelBooking.Entity.Common.Entities;
using HotelBooking.Entity.Common.Enums;
using HotelBooking.Entity.Entities;
using System.Data;
using System.Data.SqlClient;
using static Dapper.SqlMapper;

namespace HotelBooking.DataAccess.Base
{
    public class HotelsLookupRepository : IHotelsLookupRepositoryInterface
    {
        #region Global Variables
        private readonly IDbConnection _dbConnection;
        #endregion

              
        private readonly ILogger<HotelsLookupRepository> logger;

        public HotelsLookupRepository(ILogger<HotelsLookupRepository> _logger, IDbConnection dbConnection)
        {
            logger = _logger;
            _dbConnection = dbConnection;
        }

        #region Insert Hotels
        public async Task<HotelResEntity> InsertHotels(HotelsDataEntity entity, string storedProcedure)
        {
            HotelResEntity result = new HotelResEntity();

            try
            {
                Dapper.DefaultTypeMap.MatchNamesWithUnderscores = true;
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@HotelName", entity.HotelName);
                dynamicParameters.Add("@PropertyTypeID", entity.PropertyTypeID);
                dynamicParameters.Add("@TillChildAge", entity.TillChildAge);
                dynamicParameters.Add("@PropertyRules", entity.PropertyRules);
                dynamicParameters.Add("@GoogleMapURL", entity.GoogleMapURL);
                dynamicParameters.Add("@ShortDescription", entity.ShortDescription);
                dynamicParameters.Add("@HotelFacilityID", entity.HotelFacilityID);
                dynamicParameters.Add("@Address", entity.Address);
                dynamicParameters.Add("@CityID", entity.CityID);
                dynamicParameters.Add("@StateID", entity.StateID);
                dynamicParameters.Add("@CountryID", entity.CountryID);
                dynamicParameters.Add("@HotelCategory", entity.HotelCategory);
                dynamicParameters.Add("@WeekDays", entity.WeekDays);
                dynamicParameters.Add("@WeekEnds", entity.WeekEnds);
                dynamicParameters.Add("@CreatedBy", entity.CreatedBy);
                dynamicParameters.Add("@UpdatedBy", entity.UpdatedBy);
                dynamicParameters.Add("@IsUser", entity.IsUser);
                dynamicParameters.Add("@IsUpdatedUser", entity.IsUpdatedUser);
                dynamicParameters.Add("@IsActive", entity.IsActive);
                dynamicParameters.Add("@CreatedBy", entity.CreatedBy);
                dynamicParameters.Add("@HotelDescription", entity.HotelDescription);
                dynamicParameters.Add("@BookingURL", entity.BookingURL);
                dynamicParameters.Add("@Notes", entity.Notes);
                dynamicParameters.Add("@CancellationPolicy", entity.CancellationPolicy);
                dynamicParameters.Add("@URL", entity.URL);
                dynamicParameters.Add("@BathroomFacilities", entity.BathroomFacilities);
                dynamicParameters.Add("@RoomAminities", entity.RoomAminities);
                dynamicParameters.Add("@LivingArea", entity.LivingArea);
                dynamicParameters.Add("@Bedroom", entity.Bedroom);
                dynamicParameters.Add("@SectorID", entity.SectorID);
                dynamicParameters.Add("@TotalRoom", entity.TotalRoom);
                dynamicParameters.Add("@IsDisplay", entity.IsDisplay);
                dynamicParameters.Add("@PurchaseRate", entity.PurchaseRate);
                dynamicParameters.Add("@SequenceNo", entity.SequenceNo);
                dynamicParameters.Add("@CheckInTime", entity.CheckInTime);
                dynamicParameters.Add("@CheckOutTime", entity.CheckOutTime);
                dynamicParameters.Add("@MetaTitle", entity.MetaTitle);
                dynamicParameters.Add("@MetaKeywords", entity.MetaKeywords);
                dynamicParameters.Add("@MetaDescription", entity.MetaDescription);
                dynamicParameters.Add("@FarFrom", entity.FarFrom);
                dynamicParameters.Add("@OperationType", CommonRepositoryConstants.Insert);

                var data = await _dbConnection.QueryAsync(storedProcedure, dynamicParameters, commandType: CommandType.StoredProcedure);
                result.HotelID = data.FirstOrDefault().HotelID;
                result.ID = data.FirstOrDefault().ID;
                result.Message = data.FirstOrDefault().Message;
                result.Details = data.FirstOrDefault().Details;

            }
            catch (SqlException sqlException)
            {
                logger.LogError(sqlException, sqlException.Message);
                result.ErrorMessage = sqlException.Message;
                result.Status = (int)ResponseStatusCode.InternaServerError;
                result.Message = CommonRepositoryMessages.CannotFindAllMessage;
                result.Details = CommonRepositoryMessages.CannotFindAllDetails;

            }
            catch (Exception ex)
            {
                result.Status = (int)ResponseStatusCode.InternaServerError;
                result.Message = CommonRepositoryMessages.ExceptionMessage;
                result.ErrorMessage = ex.Message;

            }
            finally
            {
            }

            return result;
        }
        #endregion

        #region Update Hotels
        public async Task<HotelResEntity> UpdateHotels(HotelsDataEntity entity, string storedProcedure)
        {
            HotelResEntity result = new HotelResEntity();

            try
            {
                Dapper.DefaultTypeMap.MatchNamesWithUnderscores = true;
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@ID", entity.ID);
                dynamicParameters.Add("@HotelName", entity.HotelName);
                dynamicParameters.Add("@PropertyTypeID", entity.PropertyTypeID);
                dynamicParameters.Add("@TillChildAge", entity.TillChildAge);
                dynamicParameters.Add("@PropertyRules", entity.PropertyRules);
                dynamicParameters.Add("@GoogleMapURL", entity.GoogleMapURL);
                dynamicParameters.Add("@ShortDescription", entity.ShortDescription);
                dynamicParameters.Add("@HotelFacilityID", entity.HotelFacilityID);
                dynamicParameters.Add("@Address", entity.Address);
                dynamicParameters.Add("@CityID", entity.CityID);
                dynamicParameters.Add("@StateID", entity.StateID);
                dynamicParameters.Add("@CountryID", entity.CountryID);
                dynamicParameters.Add("@HotelCategory", entity.HotelCategory);
                dynamicParameters.Add("@WeekDays", entity.WeekDays);
                dynamicParameters.Add("@WeekEnds", entity.WeekEnds);
                dynamicParameters.Add("@CreatedBy", entity.CreatedBy);
                dynamicParameters.Add("@UpdatedBy", entity.UpdatedBy);
                dynamicParameters.Add("@IsUser", entity.IsUser);
                dynamicParameters.Add("@IsUpdatedUser", entity.IsUpdatedUser);
                dynamicParameters.Add("@IsActive", entity.IsActive);
                dynamicParameters.Add("@OperationType", CommonRepositoryConstants.Update);
                dynamicParameters.Add("@HotelDescription", entity.HotelDescription);
                dynamicParameters.Add("@BookingURL", entity.BookingURL);
                dynamicParameters.Add("@Notes", entity.Notes);
                dynamicParameters.Add("@CancellationPolicy", entity.CancellationPolicy);
                dynamicParameters.Add("@URL", entity.URL);
                dynamicParameters.Add("@BathroomFacilities", entity.BathroomFacilities);
                dynamicParameters.Add("@RoomAminities", entity.RoomAminities);
                dynamicParameters.Add("@LivingArea", entity.LivingArea);
                dynamicParameters.Add("@Bedroom", entity.Bedroom);
                dynamicParameters.Add("@SectorID", entity.SectorID);
                dynamicParameters.Add("@TotalRoom", entity.TotalRoom);
                dynamicParameters.Add("@IsDisplay", entity.IsDisplay);
                dynamicParameters.Add("@PurchaseRate", entity.PurchaseRate);
                dynamicParameters.Add("@SequenceNo", entity.SequenceNo);
                dynamicParameters.Add("@CheckInTime", entity.CheckInTime);
                dynamicParameters.Add("@CheckOutTime", entity.CheckOutTime);
                dynamicParameters.Add("@MetaTitle", entity.MetaTitle);
                dynamicParameters.Add("@MetaKeywords", entity.MetaKeywords);
                dynamicParameters.Add("@MetaDescription", entity.MetaDescription);
                dynamicParameters.Add("@FarFrom", entity.FarFrom);
                var data = await _dbConnection.QueryAsync(storedProcedure, dynamicParameters, commandType: CommandType.StoredProcedure);
                result.HotelID = data.FirstOrDefault().HotelID;
                result.ID = data.FirstOrDefault().ID;
                result.Message = data.FirstOrDefault().Message;
                result.Details = data.FirstOrDefault().Details;

            }
            catch (SqlException sqlException)
            {
                logger.LogError(sqlException, sqlException.Message);
                result.ErrorMessage = sqlException.Message;
                result.Status = (int)ResponseStatusCode.InternaServerError;
                result.Message = CommonRepositoryMessages.CannotFindAllMessage;
                result.Details = CommonRepositoryMessages.CannotFindAllDetails;

            }
            catch (Exception ex)
            {
                result.Status = (int)ResponseStatusCode.InternaServerError;
                result.Message = CommonRepositoryMessages.ExceptionMessage;
                result.ErrorMessage = ex.Message;

            }
            finally
            {
            }

            return result;
        }
        #endregion

        #region Delete Hotels
        public async Task<ResultModel> DeleteHotels(HotelsIDEntity entity, string storedProcedure)
        {
            ResultModel result = new ResultModel();

            try
            {
                Dapper.DefaultTypeMap.MatchNamesWithUnderscores = true;
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@ID", entity.ID);
                dynamicParameters.Add("@DeletedBy", entity.DeletedBy);
                dynamicParameters.Add("@IsDeletedUser", entity.IsDeletedUser);
                dynamicParameters.Add("@OperationType", 7);
                var data = await _dbConnection.QueryAsync(storedProcedure, dynamicParameters, commandType: CommandType.StoredProcedure);
                result.Message = data.FirstOrDefault().Message;
                result.Details = data.FirstOrDefault().Details;

            }
            catch (SqlException sqlException)
            {
                logger.LogError(sqlException, sqlException.Message);
                result.ErrorMessage = sqlException.Message;
                result.Status = (int)ResponseStatusCode.InternaServerError;
                result.Message = CommonRepositoryMessages.CannotFindAllMessage;
                result.Details = CommonRepositoryMessages.CannotFindAllDetails;

            }
            catch (Exception ex)
            {
                result.Status = (int)ResponseStatusCode.InternaServerError;
                result.Message = CommonRepositoryMessages.ExceptionMessage;
                result.ErrorMessage = ex.Message;

            }
            finally
            {
            }

            return result;
        }
        #endregion

        #region Delete Hotel Image
        public async Task<ResultModel> DeleteHotelImage(HotelsIDEntity entity, string storedProcedure)
        {
            ResultModel result = new ResultModel();

            try
            {
                Dapper.DefaultTypeMap.MatchNamesWithUnderscores = true;
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@ID", entity.ID);
                dynamicParameters.Add("@OperationType", 8);
                var data = await _dbConnection.QueryAsync(storedProcedure, dynamicParameters, commandType: CommandType.StoredProcedure);
                result.Message = data.FirstOrDefault().Message;
                result.Details = data.FirstOrDefault().Details;

            }
            catch (SqlException sqlException)
            {
                logger.LogError(sqlException, sqlException.Message);
                result.ErrorMessage = sqlException.Message;
                result.Status = (int)ResponseStatusCode.InternaServerError;
                result.Message = CommonRepositoryMessages.CannotFindAllMessage;
                result.Details = CommonRepositoryMessages.CannotFindAllDetails;

            }
            catch (Exception ex)
            {
                result.Status = (int)ResponseStatusCode.InternaServerError;
                result.Message = CommonRepositoryMessages.ExceptionMessage;
                result.ErrorMessage = ex.Message;

            }
            finally
            {
            }

            return result;
        }
        #endregion

        #region FindBy ID Hotels
        public async Task<HotelsFindByViewEntity> FindByIDHotels(HotelsIDEntity entity, string storedProcedure)
        {
            HotelsFindByViewEntity result = new HotelsFindByViewEntity();
            
            try
            {

                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@ID", entity.ID);
                dynamicParameters.Add("@OperationType", 10);
                var data = await _dbConnection.QueryMultipleAsync(storedProcedure, dynamicParameters, commandType: System.Data.CommandType.StoredProcedure);
                var HotelData = await data.ReadFirstAsync<HotelsFindByViewEntity>();
                if (HotelData.Message == "success")
                {
                    var contactData = await data.ReadAsync<HotelContactEnityReq>();
                    var roomData = await data.ReadAsync<HotelCategoryResponse>();
                    var imageData = (await data.ReadAsync<HotelCategoryImage>()).ToList();
                    var weekdayData = await data.ReadAsync<HotelRatesViewEntity>();
                    var weekendData = await data.ReadAsync<HotelRatesViewEntity>();
                    var specialData = await data.ReadAsync<HotelSpecialRateResEntity>();
                    var regulardayData = await data.ReadAsync<HotelRatesViewEntity>();
                    var hotelimages = await data.ReadAsync<HotelImages>();

                    HotelsFindByViewEntity hotels = new HotelsFindByViewEntity();
                    hotels = (HotelsFindByViewEntity)HotelData;
                    hotels.HotelContactList = contactData;

                    foreach (var room in roomData)
                    {
                        room.Images = imageData
                            .Where(x => x.RoomCategoryID == room.ID)
                            .ToList();
                    }

                    hotels.RoomCategoryList = roomData;

                    hotels.WeekDaysRateList = weekdayData;
                    hotels.WeekEndRateList = weekendData;
                    hotels.SpecialDateRateList = specialData;
                    hotels.RegularDaysRateList = regulardayData;
                    hotels.HotelImages = hotelimages;
                    return hotels;
                }
                else
                {
                    result.Message = Convert.ToString(HotelData.Message);
                    result.Details = Convert.ToString(HotelData.Details);
                }
            }
            catch (SqlException sqlException)
            {
                logger.LogError(sqlException, sqlException.Message);
                result.ErrorMessage = sqlException.Message;
                result.Status = (int)ResponseStatusCode.InternaServerError;
                result.Message = CommonRepositoryMessages.CannotFindAllMessage;
                result.Details = CommonRepositoryMessages.CannotFindAllDetails;
                throw;
            }
            catch (Exception ex)
            {
                result.Status = (int)ResponseStatusCode.InternaServerError;
                result.Message = CommonRepositoryMessages.ExceptionMessage;
                result.ErrorMessage = ex.Message;
                throw;
            }
            finally
            {

            }

            return result;
        }
        #endregion

        #region Find All Hotels
        public async Task<List<HotelsViewEntity>> FindAllHotels(HotelsIDEntity entity, string storedProcedure)
        {
            HotelsViewEntity result = new HotelsViewEntity();

            try
            {
                Dapper.DefaultTypeMap.MatchNamesWithUnderscores = true;
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@HotelName", entity.HotelName);
                dynamicParameters.Add("@OperationType", 12);
                var data = await _dbConnection.QueryAsync<HotelsViewEntity>(storedProcedure, dynamicParameters, commandType: CommandType.StoredProcedure);
                return data.ToList();

            }
            catch (SqlException sqlException)
            {
                logger.LogError(sqlException, sqlException.Message);
                result.ErrorMessage = sqlException.Message;
                result.Status = (int)ResponseStatusCode.InternaServerError;
                result.Message = CommonRepositoryMessages.CannotFindAllMessage;
                result.Details = CommonRepositoryMessages.CannotFindAllDetails;
                throw;
            }
            catch (Exception ex)
            {
                result.Status = (int)ResponseStatusCode.InternaServerError;
                result.Message = CommonRepositoryMessages.ExceptionMessage;
                result.ErrorMessage = ex.Message;
                throw;
            }
            finally
            {

            }


        }
        #endregion

        #region Find All Active Hotels
        public async Task<List<HotelsViewEntity>> FindAllActiveHotels(HotelsAvailabilityEntity entity, string storedProcedure)
        {
            HotelsViewEntity result = new HotelsViewEntity();

            try
            {
                Dapper.DefaultTypeMap.MatchNamesWithUnderscores = true;
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@OperationType", 1);
                dynamicParameters.Add("@VisitDate", entity.VisitDate);
                var data = await _dbConnection.QueryMultipleAsync(storedProcedure, dynamicParameters, commandType: CommandType.StoredProcedure);
                // First result → Hotels
                var hotels = (await data.ReadAsync<HotelsViewEntity>()).ToList();

                // Second result → Facilities
                var facilities = (await data.ReadAsync<HotelFacility>()).ToList();

                var roomData = (await data.ReadAsync<HotelCategoryResponse>()).ToList();
                var imageData = (await data.ReadAsync<HotelCategoryImage>()).ToList();
                var hotelPrice = (await data.ReadAsync<HotelPriceRangeDataEntity>()).ToList();

                foreach (var hotel in hotels)
                {
                    if (!string.IsNullOrWhiteSpace(hotel.HotelFacilityID))
                    {
                        var ids = hotel.HotelFacilityID
                            .Split(',')
                            .Select(int.Parse)
                            .ToList();

                        hotel.Facilities = facilities
                            .Where(x => ids.Contains(x.ID))
                            .ToList();
                    }

                    var hotelRooms = roomData
                        .Where(x => x.HotelID == hotel.ID)
                        .ToList();

                    foreach (var room in hotelRooms)
                    {
                        room.Images = imageData
                            .Where(x => x.RoomCategoryID == room.ID)
                            .ToList();

                        room.HotelPrice = hotelPrice
                            .Where(x => x.RoomCategoryID == room.ID)
                            .ToList();
                    }

                    hotel.RoomCategoryList = hotelRooms;
                }

                return hotels;

            }
            catch (SqlException sqlException)
            {
                logger.LogError(sqlException, sqlException.Message);
                result.ErrorMessage = sqlException.Message;
                result.Status = (int)ResponseStatusCode.InternaServerError;
                result.Message = CommonRepositoryMessages.CannotFindAllMessage;
                result.Details = CommonRepositoryMessages.CannotFindAllDetails;
                throw;
            }
            catch (Exception ex)
            {
                result.Status = (int)ResponseStatusCode.InternaServerError;
                result.Message = CommonRepositoryMessages.ExceptionMessage;
                result.ErrorMessage = ex.Message;
                throw;
            }
            finally
            {

            }


        }
        #endregion

        #region Active InActive Hotels
        public async Task<ResultModel> ActiveInActiveHotels(HotelsIDEntity entity, string storedProcedure)
        {
            ResultModel result = new ResultModel();

            try
            {
                Dapper.DefaultTypeMap.MatchNamesWithUnderscores = true;
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@ID", entity.ID);
                dynamicParameters.Add("@IsActive", entity.IsActive);
                dynamicParameters.Add("@UpdatedBy", entity.UpdatedBy);
                dynamicParameters.Add("@IsUpdatedUser", entity.IsUpdatedUser);
                dynamicParameters.Add("@OperationType", 13);
                var data = await _dbConnection.QueryAsync(storedProcedure, dynamicParameters, commandType: CommandType.StoredProcedure);
                result.Message = data.FirstOrDefault().Message;
                result.Details = data.FirstOrDefault().Details;

            }

            catch (SqlException sqlException)
            {
                logger.LogError(sqlException, sqlException.Message);
                result.ErrorMessage = sqlException.Message;
                result.Status = (int)ResponseStatusCode.InternaServerError;
                result.Message = CommonRepositoryMessages.CannotFindAllMessage;
                result.Details = CommonRepositoryMessages.CannotFindAllDetails;

            }
            catch (Exception ex)
            {
                result.Status = (int)ResponseStatusCode.InternaServerError;
                result.Message = CommonRepositoryMessages.ExceptionMessage;
                result.ErrorMessage = ex.Message;

            }
            finally
            {

            }

            return result;
        }
        #endregion

        #region BulkUploadHotelData
        public async Task<ResultModel> BulkUploadHotelData(List<Hotel> Hotel, List<HotelRateSpecialDate> rate, string storedProcedure)
        {
            ResultModel result = new ResultModel();

            try
            {
                Dapper.DefaultTypeMap.MatchNamesWithUnderscores = true;
                DynamicParameters dynamicParameters = new DynamicParameters();

                if (Hotel != null)
                {
                    dynamicParameters.AddTable("@HotelDetails", "UDTTHotel", Hotel.ToList());
                }
                if (rate != null)
                {
                    dynamicParameters.AddTable("@HotelRateSpecialDates", "UDTTHotelRateSpecialDate", rate.ToList());
                }

                var data = await _dbConnection.QueryAsync(storedProcedure, dynamicParameters, commandType: CommandType.StoredProcedure);
                result.Message = data.FirstOrDefault().Message;
                result.Details = data.FirstOrDefault().Details;

            }
            catch (SqlException sqlException)
            {
                logger.LogError(sqlException, sqlException.Message);
                result.ErrorMessage = sqlException.Message;
                result.Status = (int)ResponseStatusCode.InternaServerError;
                result.Message = CommonRepositoryMessages.CannotFindAllMessage;
                result.Details = CommonRepositoryMessages.CannotFindAllDetails;
                throw;
            }
            catch (Exception ex)
            {
                result.Status = (int)ResponseStatusCode.InternaServerError;
                result.Message = CommonRepositoryMessages.ExceptionMessage;
                result.ErrorMessage = ex.Message;
                throw;
            }
            finally
            {

            }

            return result;
        }
        #endregion

        #region BulkUploadHotelData
        public async Task<ResultModel> BulkUploadHotelDataNew(List<HotelExcelExport> Hotel, List<HotelRateSpecialDateNew> rate, string storedProcedure)
        {
            ResultModel result = new ResultModel();

            try
            {
                Dapper.DefaultTypeMap.MatchNamesWithUnderscores = true;
                DynamicParameters dynamicParameters = new DynamicParameters();

                if (Hotel != null)
                {
                    dynamicParameters.AddTable("@HotelDetailsNew", "UDTTHotelNew", Hotel.ToList());
                }
                if (rate != null)
                {
                    dynamicParameters.AddTable("@HotelRateSpecialDatesNew", "UDTTHotelRateSpecialDateNew", rate.ToList());
                }

                var data = await _dbConnection.QueryAsync(storedProcedure, dynamicParameters, commandType: CommandType.StoredProcedure);
                result.Message = data.FirstOrDefault().Message;
                result.Details = data.FirstOrDefault().Details;

            }
            catch (SqlException sqlException)
            {
                logger.LogError(sqlException, sqlException.Message);
                result.ErrorMessage = sqlException.Message;
                result.Status = (int)ResponseStatusCode.InternaServerError;
                result.Message = CommonRepositoryMessages.CannotFindAllMessage;
                result.Details = CommonRepositoryMessages.CannotFindAllDetails;
                throw;
            }
            catch (Exception ex)
            {
                result.Status = (int)ResponseStatusCode.InternaServerError;
                result.Message = CommonRepositoryMessages.ExceptionMessage;
                result.ErrorMessage = ex.Message;
                throw;
            }
            finally
            {

            }

            return result;
        }
        #endregion

        public async Task<ResultModel> HotelImageUpdate(HotelImageEntity entity, string storedProcedure)
        {
            var result = new ResultModel();
            try
            {
                // Prepare InnerImages table-valued parameter
                var dt = new DataTable();
                dt.Columns.Add("ImagePath", typeof(string));
                dt.Columns.Add("SrNo", typeof(int));
                dt.Columns.Add("Remarks", typeof(string));
                
                if (entity.InnerImages != null && entity.InnerImages.Any())
                {
                    foreach (var img in entity.InnerImages)
                    {
                        object sr = img.SrNo.HasValue ? (object)img.SrNo.Value : DBNull.Value;
                        object rm = !string.IsNullOrEmpty(img.Remarks) ? (object)img.Remarks : DBNull.Value;
                        dt.Rows.Add(img.ImagePath, sr, rm);
                    }
                }

                var dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@ID", entity.ID);
                dynamicParameters.Add("@MainImage", entity.MainImage);
                dynamicParameters.Add("@BannerImage", entity.BannerImage);
                dynamicParameters.Add("@HotelLogo", entity.HotelLogo);
                dynamicParameters.Add("@UDTT_HotelImages", dt.AsTableValuedParameter("UDTT_HotelImages"));
                dynamicParameters.Add("@UpdatedBy", entity.UpdatedBy);
                dynamicParameters.Add("@OperationType", 8);

                var data = await _dbConnection.QueryAsync(storedProcedure, dynamicParameters, commandType: CommandType.StoredProcedure);
                var first = data.FirstOrDefault();

                if (first != null)
                {
                    result.Message = first.Message;
                    result.Details = first.Details;
                }

                return result;
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.Message);
                throw;
            }
        }

        #region FindBy URL Hotels
        public async Task<HotelsFindByViewEntity> FindByURLHotels(HotelsIDEntity entity, string storedProcedure)
        {
            HotelsFindByViewEntity result = new HotelsFindByViewEntity();
            try
            {

                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@URL", entity.URL);
                dynamicParameters.Add("@OperationType", 32);
                var data = await _dbConnection.QueryMultipleAsync(storedProcedure, dynamicParameters, commandType: System.Data.CommandType.StoredProcedure);
                var HotelData = await data.ReadFirstAsync<HotelsFindByViewEntity>();
                if (HotelData.Message == "success")
                {
                    var contactData = await data.ReadAsync<HotelContactEnityReq>();
                    var roomData = await data.ReadAsync<HotelCategoryResponse>();
                    var imageData = (await data.ReadAsync<HotelCategoryImage>()).ToList();
                    var HotelPrice = (await data.ReadAsync<HotelPriceRangeDataEntity>()).ToList();
                    var weekdayData = await data.ReadAsync<HotelRatesViewEntity>();
                    var weekendData = await data.ReadAsync<HotelRatesViewEntity>();
                    var specialData = await data.ReadAsync<HotelSpecialRateResEntity>();
                    var regularDaysRateList = await data.ReadAsync<HotelRatesViewEntity>();
                    var hotelimages = await data.ReadAsync<HotelImages>();
                    var FAQData = await data.ReadAsync<FAQDataViewByHotelEntity>();

                    HotelsFindByViewEntity hotels = new HotelsFindByViewEntity();
                    hotels = (HotelsFindByViewEntity)HotelData;
                    hotels.HotelContactList = contactData;
                    foreach (var room in roomData)
                    {
                        room.Images = imageData
                            .Where(x => x.RoomCategoryID == room.ID)
                            .ToList();
                    }
                    foreach (var room in roomData)
                    {
                        room.HotelPrice = HotelPrice
                            .Where(x => x.RoomCategoryID == room.ID)
                            .ToList();
                    }
                    hotels.RoomCategoryList = roomData;
                    hotels.WeekDaysRateList = weekdayData;
                    hotels.WeekEndRateList = weekendData;
                    hotels.SpecialDateRateList = specialData;
                    hotels.RegularDaysRateList = regularDaysRateList;
                    hotels.HotelImages = hotelimages;
                    hotels.FAQList = FAQData;
                    return hotels;
                }
                else
                {
                    result.Message = Convert.ToString(HotelData.Message);
                    result.Details = Convert.ToString(HotelData.Details);
                }
            }
            catch (SqlException sqlException)
            {
                logger.LogError(sqlException, sqlException.Message);
                result.ErrorMessage = sqlException.Message;
                result.Status = (int)ResponseStatusCode.InternaServerError;
                result.Message = CommonRepositoryMessages.CannotFindAllMessage;
                result.Details = CommonRepositoryMessages.CannotFindAllDetails;
                throw;
            }
            catch (Exception ex)
            {
                result.Status = (int)ResponseStatusCode.InternaServerError;
                result.Message = CommonRepositoryMessages.ExceptionMessage;
                result.ErrorMessage = ex.Message;
                throw;
            }
            finally
            {

            }

            return result;
        }
        #endregion

        #region Find All Hotels
        public async Task<List<HotelsViewEntity>> HotelsListForWebsite(HotelsIDEntity entity, string storedProcedure)
        {
            HotelsViewEntity result = new HotelsViewEntity();

            try
            {
                Dapper.DefaultTypeMap.MatchNamesWithUnderscores = true;
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@HotelName", entity.HotelName);
                dynamicParameters.Add("@HotelCategory", entity.HotelCategory);
                dynamicParameters.Add("@Limit", entity.Limit);
                dynamicParameters.Add("@Skip", entity.Skip);
                dynamicParameters.Add("@SectorType", entity.SectorType);
                dynamicParameters.Add("@OperationType", 31);
                var data = await _dbConnection.QueryMultipleAsync(storedProcedure, dynamicParameters, commandType: CommandType.StoredProcedure);
                // First result → Hotels
                var hotels = (await data.ReadAsync<HotelsViewEntity>()).ToList();

                // Second result → Facilities
                var facilities = (await data.ReadAsync<HotelFacility>()).ToList();

                // Map facilities with comma separated IDs
                foreach (var hotel in hotels)
                {
                    if (!string.IsNullOrEmpty(hotel.HotelFacilityID))
                    {
                        var ids = hotel.HotelFacilityID
                            .Split(',')
                            .Select(int.Parse)
                            .ToList();

                        hotel.Facilities = facilities
                            .Where(f => ids.Contains(f.ID))
                            .ToList();
                    }
                }

                return hotels;

            }
            catch (SqlException sqlException)
            {
                logger.LogError(sqlException, sqlException.Message);
                result.ErrorMessage = sqlException.Message;
                result.Status = (int)ResponseStatusCode.InternaServerError;
                result.Message = CommonRepositoryMessages.CannotFindAllMessage;
                result.Details = CommonRepositoryMessages.CannotFindAllDetails;
                throw;
            }
            catch (Exception ex)
            {
                result.Status = (int)ResponseStatusCode.InternaServerError;
                result.Message = CommonRepositoryMessages.ExceptionMessage;
                result.ErrorMessage = ex.Message;
                throw;
            }
            finally
            {

            }


        }
        #endregion

        #region Find All Hotels For Dropdown
        public async Task<List<HotelsViewEntity>> FindAllHotelsForDropdown(HotelsIDEntity entity, string storedProcedure)
        {
            HotelsViewEntity result = new HotelsViewEntity();

            try
            {
                Dapper.DefaultTypeMap.MatchNamesWithUnderscores = true;
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@HotelName", entity.HotelName);
                dynamicParameters.Add("@PlaceID", entity.PlaceID);
                dynamicParameters.Add("@HotelCategory", entity.HotelCategory);
                dynamicParameters.Add("@OperationType", 33);
                var data = await _dbConnection.QueryAsync<HotelsViewEntity>(storedProcedure, dynamicParameters, commandType: CommandType.StoredProcedure);
                return data.ToList();

            }
            catch (SqlException sqlException)
            {
                logger.LogError(sqlException, sqlException.Message);
                result.ErrorMessage = sqlException.Message;
                result.Status = (int)ResponseStatusCode.InternaServerError;
                result.Message = CommonRepositoryMessages.CannotFindAllMessage;
                result.Details = CommonRepositoryMessages.CannotFindAllDetails;
                throw;
            }
            catch (Exception ex)
            {
                result.Status = (int)ResponseStatusCode.InternaServerError;
                result.Message = CommonRepositoryMessages.ExceptionMessage;
                result.ErrorMessage = ex.Message;
                throw;
            }
            finally
            {

            }


        }
        #endregion

        #region Hotel Search For Website
        public async Task<List<HotelSearchForWebsite>> HotelSearchForWebsite(HotelsIDEntity entity, string storedProcedure)
        {
            HotelSearchForWebsite result = new HotelSearchForWebsite();

            try
            {
                Dapper.DefaultTypeMap.MatchNamesWithUnderscores = true;
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@HotelName", entity.HotelName);
                dynamicParameters.Add("@OperationType", 34);
                var data = await _dbConnection.QueryAsync<HotelSearchForWebsite>(storedProcedure, dynamicParameters, commandType: CommandType.StoredProcedure);
                return data.ToList();

            }
            catch (SqlException sqlException)
            {
                logger.LogError(sqlException, sqlException.Message);
                result.ErrorMessage = sqlException.Message;
                result.Status = (int)ResponseStatusCode.InternaServerError;
                result.Message = CommonRepositoryMessages.CannotFindAllMessage;
                result.Details = CommonRepositoryMessages.CannotFindAllDetails;
                throw;
            }
            catch (Exception ex)
            {
                result.Status = (int)ResponseStatusCode.InternaServerError;
                result.Message = CommonRepositoryMessages.ExceptionMessage;
                result.ErrorMessage = ex.Message;
                throw;
            }
            finally
            {

            }


        }
        #endregion

        #region City List For Website
        public async Task<List<HotelsCity>> CityListForWebsite(string storedProcedure)
        {
            HotelsCity result = new HotelsCity();

            try
            {
                Dapper.DefaultTypeMap.MatchNamesWithUnderscores = true;
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@OperationType", 35);
                var data = await _dbConnection.QueryAsync<HotelsCity>(storedProcedure, dynamicParameters, commandType: CommandType.StoredProcedure);
                return data.ToList();

            }
            catch (SqlException sqlException)
            {
                logger.LogError(sqlException, sqlException.Message);
                result.ErrorMessage = sqlException.Message;
                result.Status = (int)ResponseStatusCode.InternaServerError;
                result.Message = CommonRepositoryMessages.CannotFindAllMessage;
                result.Details = CommonRepositoryMessages.CannotFindAllDetails;
                throw;
            }
            catch (Exception ex)
            {
                result.Status = (int)ResponseStatusCode.InternaServerError;
                result.Message = CommonRepositoryMessages.ExceptionMessage;
                result.ErrorMessage = ex.Message;
                throw;
            }
            finally
            {

            }


        }
        #endregion

        #region Insert Hotel Room Avalability
        public async Task<ResultModel> InsertHotelRoomAvalability(HotelRoomEntity entity, string storedProcedure)
        {
            ResultModel result = new ResultModel();

            try
            {
                Dapper.DefaultTypeMap.MatchNamesWithUnderscores = true;
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@HotelID", entity.HotelID);
                dynamicParameters.Add("@CategoryID", entity.CategoryID);
                dynamicParameters.Add("@Total", entity.Total);
                dynamicParameters.Add("@FromDate", entity.FromDate);
                dynamicParameters.Add("@ToDate", entity.ToDate);
                dynamicParameters.Add("@OperationType", CommonRepositoryConstants.Insert);

                var data = await _dbConnection.QueryAsync(storedProcedure, dynamicParameters, commandType: CommandType.StoredProcedure);
         
                result.Message = data.FirstOrDefault().Message;
                result.Details = data.FirstOrDefault().Details;

            }
            catch (SqlException sqlException)
            {
                logger.LogError(sqlException, sqlException.Message);
                result.ErrorMessage = sqlException.Message;
                result.Status = (int)ResponseStatusCode.InternaServerError;
                result.Message = CommonRepositoryMessages.CannotFindAllMessage;
                result.Details = CommonRepositoryMessages.CannotFindAllDetails;

            }
            catch (Exception ex)
            {
                result.Status = (int)ResponseStatusCode.InternaServerError;
                result.Message = CommonRepositoryMessages.ExceptionMessage;
                result.ErrorMessage = ex.Message;

            }
            finally
            {
            }

            return result;
        }
        #endregion

        #region Find All Hotel Room Avalability
        public async Task<List<HotelRoomViewEntity>> FindAllHotelRoomAvalability(HotelsIDEntity entity, string storedProcedure)
        {
            HotelRoomViewEntity result = new HotelRoomViewEntity();

            try
            {
                Dapper.DefaultTypeMap.MatchNamesWithUnderscores = true;
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@HotelID", entity.HotelID);
                dynamicParameters.Add("@CategoryID", entity.CategoryID);
                dynamicParameters.Add("@OperationType", 2);
                var data = await _dbConnection.QueryAsync<HotelRoomViewEntity>(storedProcedure, dynamicParameters, commandType: CommandType.StoredProcedure);
                return data.ToList();

            }
            catch (SqlException sqlException)
            {
                logger.LogError(sqlException, sqlException.Message);
                result.ErrorMessage = sqlException.Message;
                result.Status = (int)ResponseStatusCode.InternaServerError;
                result.Message = CommonRepositoryMessages.CannotFindAllMessage;
                result.Details = CommonRepositoryMessages.CannotFindAllDetails;
                throw;
            }
            catch (Exception ex)
            {
                result.Status = (int)ResponseStatusCode.InternaServerError;
                result.Message = CommonRepositoryMessages.ExceptionMessage;
                result.ErrorMessage = ex.Message;
                throw;
            }
            finally
            {

            }


        }
        #endregion

        #region Insert Hotel PriceRange
        public async Task<ResultModel> InsertHotelPriceRange(HotelPriceRangeEntity entity, string storedProcedure)
        {
            ResultModel result = new ResultModel();

            try
            {
                Dapper.DefaultTypeMap.MatchNamesWithUnderscores = true;
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@HotelID", entity.HotelID);
                dynamicParameters.Add("@RoomCategoryID", entity.RoomCategoryID);
                dynamicParameters.Add("@MealPlanID", entity.MealPlanID);
                dynamicParameters.Add("@Days", entity.Days);
                dynamicParameters.Add("@CoupleCost", entity.CoupleCost);
                dynamicParameters.Add("@ExtraPersonCost", entity.ExtraPersonCost);
                dynamicParameters.Add("@ExtraChildCost", entity.ExtraChildCost);
                dynamicParameters.Add("@Discount", entity.Discount);
                dynamicParameters.Add("@FromDate", entity.FromDate);
                dynamicParameters.Add("@ToDate", entity.ToDate);
                dynamicParameters.Add("@OperationType", CommonRepositoryConstants.Insert);

                var data = await _dbConnection.QueryAsync(storedProcedure, dynamicParameters, commandType: CommandType.StoredProcedure);

                result.Message = data.FirstOrDefault().Message;
                result.Details = data.FirstOrDefault().Details;

            }
            catch (SqlException sqlException)
            {
                logger.LogError(sqlException, sqlException.Message);
                result.ErrorMessage = sqlException.Message;
                result.Status = (int)ResponseStatusCode.InternaServerError;
                result.Message = CommonRepositoryMessages.CannotFindAllMessage;
                result.Details = CommonRepositoryMessages.CannotFindAllDetails;

            }
            catch (Exception ex)
            {
                result.Status = (int)ResponseStatusCode.InternaServerError;
                result.Message = CommonRepositoryMessages.ExceptionMessage;
                result.ErrorMessage = ex.Message;

            }
            finally
            {
            }

            return result;
        }
        #endregion

        #region Find All Hotel PriceRange
        public async Task<List<HotelPriceRangeViewEntity>> FindAllHotelPriceRange(HotelPriceEntity entity, string storedProcedure)
        {
            HotelPriceRangeViewEntity result = new HotelPriceRangeViewEntity();

            try
            {
                Dapper.DefaultTypeMap.MatchNamesWithUnderscores = true;
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@HotelID", entity.HotelID);
                dynamicParameters.Add("@RoomCategoryID", entity.RoomCategoryID);
                dynamicParameters.Add("@MealPlanID", entity.MealPlanID);
                dynamicParameters.Add("@FromDate", entity.FromDate);
                dynamicParameters.Add("@ToDate", entity.ToDate);
                dynamicParameters.Add("@OperationType", 2);
                var data = await _dbConnection.QueryAsync<HotelPriceRangeViewEntity>(storedProcedure, dynamicParameters, commandType: CommandType.StoredProcedure);
                return data.ToList();

            }
            catch (SqlException sqlException)
            {
                logger.LogError(sqlException, sqlException.Message);
                result.ErrorMessage = sqlException.Message;
                result.Status = (int)ResponseStatusCode.InternaServerError;
                result.Message = CommonRepositoryMessages.CannotFindAllMessage;
                result.Details = CommonRepositoryMessages.CannotFindAllDetails;
                throw;
            }
            catch (Exception ex)
            {
                result.Status = (int)ResponseStatusCode.InternaServerError;
                result.Message = CommonRepositoryMessages.ExceptionMessage;
                result.ErrorMessage = ex.Message;
                throw;
            }
            finally
            {

            }

        }
        #endregion


        #region Find All Hotel Room Avalability
        public async Task<HotelRoomPriceViewEntity> FindAllAvailableHotelRoomPrice (HotelsIDEntity entity, string storedProcedure)
        {
            HotelRoomPriceViewEntity result = new HotelRoomPriceViewEntity();

            try
            {
                Dapper.DefaultTypeMap.MatchNamesWithUnderscores = true;
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@HotelID", entity.HotelID);
                dynamicParameters.Add("@CategoryID", entity.CategoryID);
                dynamicParameters.Add("@MealPlanID", entity.MealPlanID);
                dynamicParameters.Add("@Date", entity.Date);
                dynamicParameters.Add("@OperationType", 3);
                using (var multi = await _dbConnection.QueryMultipleAsync(
            storedProcedure,
            dynamicParameters,
            commandType: CommandType.StoredProcedure))
                {
                    // 1️⃣ Availability
                    var roomList = (await multi.ReadAsync<HotelRoomViewEntity>()).ToList();

                    // 2️⃣ Price
                    var priceList = (await multi.ReadAsync<HotelPriceRangeViewEntity>()).ToList();

                    result.HotelRoom = roomList;
                    result.HotelPrice = priceList;

                    // ✅ Pick message from SP (no hardcoding)
                    if (roomList.Any())
                    {
                        result.Message = roomList.First().Message;
                        result.Details = roomList.First().Details;
                    }
                    else if (priceList.Any())
                    {
                        result.Message = priceList.First().Message;
                        result.Details = priceList.First().Details;
                    }
                }

                return result;
            }
            catch (SqlException sqlException)
            {
                logger.LogError(sqlException, sqlException.Message);
                result.ErrorMessage = sqlException.Message;
                result.Status = (int)ResponseStatusCode.InternaServerError;
                result.Message = CommonRepositoryMessages.CannotFindAllMessage;
                result.Details = CommonRepositoryMessages.CannotFindAllDetails;
                throw;
            }
            catch (Exception ex)
            {
                result.Status = (int)ResponseStatusCode.InternaServerError;
                result.Message = CommonRepositoryMessages.ExceptionMessage;
                result.ErrorMessage = ex.Message;
                throw;
            }
            finally
            {

            }


        }
        #endregion


        #region FindAllHotelPriceTicketAvaibility
        public async Task<List<HotelPriceRangeViewEntity>> FindAllHotelPriceTicketAvaibility(HotelPriceEntity entity, string storedProcedure)
        {
            HotelPriceRangeViewEntity result = new HotelPriceRangeViewEntity();

            try
            {
                Dapper.DefaultTypeMap.MatchNamesWithUnderscores = true;
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@HotelID", entity.HotelID);
                dynamicParameters.Add("@RoomCategoryID", entity.RoomCategoryID);
                dynamicParameters.Add("@MealPlanID", entity.MealPlanID);
                dynamicParameters.Add("@FromDate", entity.FromDate);
                dynamicParameters.Add("@ToDate", entity.ToDate);
                dynamicParameters.Add("@OperationType", 3);
                var data = await _dbConnection.QueryAsync<HotelPriceRangeViewEntity>(storedProcedure, dynamicParameters, commandType: CommandType.StoredProcedure);
                return data.ToList();

            }
            catch (SqlException sqlException)
            {
                logger.LogError(sqlException, sqlException.Message);
                result.ErrorMessage = sqlException.Message;
                result.Status = (int)ResponseStatusCode.InternaServerError;
                result.Message = CommonRepositoryMessages.CannotFindAllMessage;
                result.Details = CommonRepositoryMessages.CannotFindAllDetails;
                throw;
            }
            catch (Exception ex)
            {
                result.Status = (int)ResponseStatusCode.InternaServerError;
                result.Message = CommonRepositoryMessages.ExceptionMessage;
                result.ErrorMessage = ex.Message;
                throw;
            }
            finally
            {

            }

        }
        #endregion

        #region Find All Hotel PriceRange
        public async Task<List<HotelPriceRangeViewEntity>> HotelPriceByHotelRoom(HotelPriceEntity entity, string storedProcedure)
        {
            HotelPriceRangeViewEntity result = new HotelPriceRangeViewEntity();

            try
            {
                Dapper.DefaultTypeMap.MatchNamesWithUnderscores = true;
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@HotelID", entity.HotelID);
                dynamicParameters.Add("@RoomCategoryID", entity.RoomCategoryID);
                dynamicParameters.Add("@Date", entity.Date); 
                dynamicParameters.Add("@OperationType", 1);
                var data = await _dbConnection.QueryAsync<HotelPriceRangeViewEntity>(storedProcedure, dynamicParameters, commandType: CommandType.StoredProcedure);
                return data.ToList();

            }
            catch (SqlException sqlException)
            {
                logger.LogError(sqlException, sqlException.Message);
                result.ErrorMessage = sqlException.Message;
                result.Status = (int)ResponseStatusCode.InternaServerError;
                result.Message = CommonRepositoryMessages.CannotFindAllMessage;
                result.Details = CommonRepositoryMessages.CannotFindAllDetails;
                throw;
            }
            catch (Exception ex)
            {
                result.Status = (int)ResponseStatusCode.InternaServerError;
                result.Message = CommonRepositoryMessages.ExceptionMessage;
                result.ErrorMessage = ex.Message;
                throw;
            }
            finally
            {

            }

        }
        #endregion

        #region Insert HotelBooking Package Price
        public async Task<ResultModel> InsertHotelBookingPackagePrice(HotelBookingPackagePriceEntity entity, string storedProcedure)
        {
            ResultModel result = new ResultModel();

            try
            {
                Dapper.DefaultTypeMap.MatchNamesWithUnderscores = true;

                DynamicParameters dynamicParameters = new DynamicParameters();

                dynamicParameters.Add("@HotelBookingPackageID", entity.HotelBookingPackageID);
                dynamicParameters.Add("@Days", entity.Days);

                dynamicParameters.Add("@CoupleCost", entity.CoupleCost);
                dynamicParameters.Add("@ExtraPersonCost", entity.ExtraPersonCost);
                dynamicParameters.Add("@ExtraChildCost", entity.ExtraChildCost);
                dynamicParameters.Add("@ChildThreeYrRate", entity.ChildThreeYrRate);
                dynamicParameters.Add("@ChildSevenYrRate", entity.ChildSevenYrRate);
                dynamicParameters.Add("@Discount", entity.Discount);

                dynamicParameters.Add("@FromDate", entity.FromDate);
                dynamicParameters.Add("@ToDate", entity.ToDate);

                dynamicParameters.Add("@OperationType", CommonRepositoryConstants.Insert);

                var data = await _dbConnection.QueryAsync(
                    storedProcedure,
                    dynamicParameters,
                    commandType: CommandType.StoredProcedure
                );

                result.Message = data.FirstOrDefault().Message;
                result.Details = data.FirstOrDefault().Details;
            }
            catch (SqlException sqlException)
            {
                logger.LogError(sqlException, sqlException.Message);

                result.ErrorMessage = sqlException.Message;
                result.Status = (int)ResponseStatusCode.InternaServerError;
                result.Message = CommonRepositoryMessages.CannotFindAllMessage;
                result.Details = CommonRepositoryMessages.CannotFindAllDetails;
            }
            catch (Exception ex)
            {
                result.Status = (int)ResponseStatusCode.InternaServerError;
                result.Message = CommonRepositoryMessages.ExceptionMessage;
                result.ErrorMessage = ex.Message;
            }
            finally
            {
            }

            return result;
        }
        #endregion


        #region Find All HotelBooking Package Price
        public async Task<List<HotelBookingPackagePriceViewEntity>> FindAllHotelBookingPackagePrice(HotelBookingPackagePriceEntity entity,string storedProcedure)
        {
            HotelBookingPackagePriceViewEntity result = new HotelBookingPackagePriceViewEntity();

            try
            {
                Dapper.DefaultTypeMap.MatchNamesWithUnderscores = true;

                DynamicParameters dynamicParameters = new DynamicParameters();

                dynamicParameters.Add("@HotelBookingPackageID", entity.HotelBookingPackageID);
                dynamicParameters.Add("@FromDate", entity.FromDate);
                dynamicParameters.Add("@ToDate", entity.ToDate);

                dynamicParameters.Add("@OperationType", 2);

                var data = await _dbConnection.QueryAsync<HotelBookingPackagePriceViewEntity>(
                    storedProcedure,
                    dynamicParameters,
                    commandType: CommandType.StoredProcedure
                );

                return data.ToList();
            }
            catch (SqlException sqlException)
            {
                logger.LogError(sqlException, sqlException.Message);

                result.ErrorMessage = sqlException.Message;
                result.Status = (int)ResponseStatusCode.InternaServerError;
                result.Message = CommonRepositoryMessages.CannotFindAllMessage;
                result.Details = CommonRepositoryMessages.CannotFindAllDetails;

                throw;
            }
            catch (Exception ex)
            {
                result.Status = (int)ResponseStatusCode.InternaServerError;
                result.Message = CommonRepositoryMessages.ExceptionMessage;
                result.ErrorMessage = ex.Message;

                throw;
            }
            finally
            {

            }
        }
        #endregion
    }

}
