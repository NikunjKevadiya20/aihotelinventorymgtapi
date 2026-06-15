using Dapper;
using DapperParameters;
using Microsoft.Extensions.Logging;
using HotelBooking.Entity.Common;
using HotelBooking.Entity.Common.Entities;
using HotelBooking.Entity.Common.Enums;
using HotelBooking.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Dapper.SqlMapper;

namespace HotelBooking.DataAccess.Base
{
    public class TourLookupRepository : ITourLookupRepositoryInterface
    {
        #region Global Variables
        private readonly IDbConnection _dbConnection;
        #endregion

        private readonly ILogger<TourLookupRepository> logger;


        public TourLookupRepository(ILogger<TourLookupRepository> _logger, IDbConnection dbConnection)
        {
            logger = _logger;
            _dbConnection = dbConnection;
        }

        #region Insert Tour
        public async Task<TourIDViewEntity> InsertTour(TourEntity entity, string storedProcedure)
        {
            TourIDViewEntity result = new TourIDViewEntity();

            try
            {
                Dapper.DefaultTypeMap.MatchNamesWithUnderscores = true;
                DynamicParameters parameters = new DynamicParameters();

                parameters.Add("@PackageTypeID", entity.PackageTypeID);
                parameters.Add("@TourName", entity.TourName);
                parameters.Add("@TourURL", entity.TourURL);
                parameters.Add("@ShortDescription", entity.ShortDescription);
                parameters.Add("@LongDescription", entity.LongDescription);
                parameters.Add("@PackageType", entity.PackageType);

                parameters.Add("@NoOfNights", entity.NoOfNights);
                parameters.Add("@NoOfDays", entity.NoOfDays);

                parameters.Add("@MetaTitle", entity.MetaTitle);
                parameters.Add("@MetaKeywords", entity.MetaKeywords);
                parameters.Add("@MetaDescription", entity.MetaDescription);
                parameters.Add("@Inclusion", entity.Inclusion);
                parameters.Add("@Exclusion", entity.Exclusion);
                parameters.Add("@KeyPoints", entity.KeyPoints);
                parameters.Add("@Highlights", entity.Highlights);
                parameters.Add("@IsPopular", entity.IsPopular);
                parameters.Add("@BookingURL", entity.BookingURL);
                parameters.Add("@SequenceNo", entity.SequenceNo);
                parameters.Add("@IsActive", entity.IsActive);
                parameters.Add("@CreatedBy", entity.CreatedBy);
                parameters.Add("@OperationType", CommonRepositoryConstants.Insert);

                var data = await _dbConnection.QueryFirstOrDefaultAsync<TourIDViewEntity>(
                    storedProcedure, parameters, commandType: CommandType.StoredProcedure);
                return data;
            }
            catch (SqlException ex)
            {
                logger.LogError(ex, ex.Message);
                result.Status = (int)ResponseStatusCode.InternaServerError;
                result.ErrorMessage = ex.Message;
                result.Message = CommonRepositoryMessages.CannotFindAllMessage;
                result.Details = CommonRepositoryMessages.CannotFindAllDetails;
                throw;
            }
            catch (Exception ex)
            {
                result.Status = (int)ResponseStatusCode.InternaServerError;
                result.ErrorMessage = ex.Message;
                result.Message = CommonRepositoryMessages.ExceptionMessage;
                throw;
            }
        }
        #endregion

        #region Update Tour
        public async Task<ResultModel> UpdateTour(TourEntity entity, string storedProcedure)
        {
            ResultModel result = new ResultModel();

            try
            {
                Dapper.DefaultTypeMap.MatchNamesWithUnderscores = true;
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@ID", entity.ID);
                parameters.Add("@PackageTypeID", entity.PackageTypeID);
                parameters.Add("@TourName", entity.TourName);
                parameters.Add("@TourURL", entity.TourURL);
                parameters.Add("@ShortDescription", entity.ShortDescription);
                parameters.Add("@LongDescription", entity.LongDescription);
                parameters.Add("@PackageType", entity.PackageType);

                parameters.Add("@NoOfNights", entity.NoOfNights);
                parameters.Add("@NoOfDays", entity.NoOfDays);

                parameters.Add("@MetaTitle", entity.MetaTitle);
                parameters.Add("@MetaKeywords", entity.MetaKeywords);
                parameters.Add("@MetaDescription", entity.MetaDescription);
                parameters.Add("@Inclusion", entity.Inclusion);
                parameters.Add("@Exclusion", entity.Exclusion);
                parameters.Add("@KeyPoints", entity.KeyPoints);
                parameters.Add("@Highlights", entity.Highlights);
                parameters.Add("@IsPopular", entity.IsPopular);
                parameters.Add("@BookingURL", entity.BookingURL);
                parameters.Add("@SequenceNo", entity.SequenceNo);
                parameters.Add("@IsActive", entity.IsActive);
                parameters.Add("@UpdatedBy", entity.UpdatedBy);
                parameters.Add("@OperationType", CommonRepositoryConstants.Update);

                var data = await _dbConnection.QueryAsync(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
                result.Message = data.FirstOrDefault().Message;
                result.Details = data.FirstOrDefault().Details;
            }
            catch (SqlException ex)
            {
                logger.LogError(ex, ex.Message);
                result.Status = (int)ResponseStatusCode.InternaServerError;
                result.ErrorMessage = ex.Message;
                result.Message = CommonRepositoryMessages.CannotFindAllMessage;
                result.Details = CommonRepositoryMessages.CannotFindAllDetails;
            }
            catch (Exception ex)
            {
                result.Status = (int)ResponseStatusCode.InternaServerError;
                result.ErrorMessage = ex.Message;
                result.Message = CommonRepositoryMessages.ExceptionMessage;
            }

            return result;
        }
        #endregion

        #region Delete Tour
        public async Task<ResultModel> DeleteTour(TourIDEntity entity, string storedProcedure)
        {
            ResultModel result = new ResultModel();

            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@ID", entity.ID);
                parameters.Add("@UpdatedBy", entity.UpdatedBy);
                parameters.Add("@OperationType", CommonRepositoryConstants.Delete);

                var data = await _dbConnection.QueryAsync(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
                result.Message = data.FirstOrDefault().Message;
                result.Details = data.FirstOrDefault().Details;
            }
            catch (SqlException ex)
            {
                logger.LogError(ex, ex.Message);
                result.Status = (int)ResponseStatusCode.InternaServerError;
                result.ErrorMessage = ex.Message;
                result.Message = CommonRepositoryMessages.CannotFindAllMessage;
                result.Details = CommonRepositoryMessages.CannotFindAllDetails;
            }
            catch (Exception ex)
            {
                result.Status = (int)ResponseStatusCode.InternaServerError;
                result.ErrorMessage = ex.Message;
                result.Message = CommonRepositoryMessages.ExceptionMessage;
            }

            return result;
        }
        #endregion

        #region Find By ID Tour
        public async Task<TourDataViewEntity> FindByIDTour(TourIDEntity entity, string storedProcedure)
        {
            TourDataViewEntity result = new TourDataViewEntity();

            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@ID", entity.ID);
                parameters.Add("@OperationType", CommonRepositoryConstants.FindByID);

                var data = await _dbConnection.QueryMultipleAsync(
                    storedProcedure, parameters, commandType: CommandType.StoredProcedure);

                var venue = await data.ReadFirstOrDefaultAsync<TourDataViewEntity>();

                if (venue != null && !data.IsConsumed)
                {
                    venue.Innerimage = (await data.ReadAsync<WeddingInnserimageEntity>()).ToList();
                    venue.TourVideo = (await data.ReadAsync<TourVideodataEntity>()).ToList();
                    venue.TourFAQ = (await data.ReadAsync<TourFAQdataEntity>()).ToList();
                }
                
                return venue;
            }
            catch (SqlException ex)
            {
                logger.LogError(ex, ex.Message);
                result.Status = (int)ResponseStatusCode.InternaServerError;
                result.ErrorMessage = ex.Message;
                throw;
            }
            catch (Exception ex)
            {
                result.Status = (int)ResponseStatusCode.InternaServerError;
                result.ErrorMessage = ex.Message;
                throw;
            }
        }
        #endregion

        #region Find All Tour
        public async Task<List<TourDataViewEntity>> FindAllTour(TourIDEntity entity, string storedProcedure)
        {
            TourDataViewEntity result = new TourDataViewEntity();

            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@TourName", entity.TourName);
                parameters.Add("@PackageTypeID", entity.PackageTypeID);
                parameters.Add("@OperationType", CommonRepositoryConstants.FindAllItems);

                var data = await _dbConnection.QueryAsync<TourDataViewEntity>(
                    storedProcedure, parameters, commandType: CommandType.StoredProcedure);
                return data.ToList();
            }
            catch (SqlException ex)
            {
                logger.LogError(ex, ex.Message);
                result.Status = (int)ResponseStatusCode.InternaServerError;
                result.ErrorMessage = ex.Message;
                throw;
            }
            catch (Exception ex)
            {
                result.Status = (int)ResponseStatusCode.InternaServerError;
                result.ErrorMessage = ex.Message;
                throw;
            }
        }
        #endregion

        #region Find All Active Tour
        public async Task<List<TourDataViewEntity>> FindAllActiveTour(string storedProcedure)
        {
            TourDataViewEntity result = new TourDataViewEntity();

            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@OperationType", 5);
                var data = await _dbConnection.QueryAsync<TourDataViewEntity>(
                    storedProcedure, parameters, commandType: CommandType.StoredProcedure);
                return data.ToList();
            }
            catch (SqlException ex)
            {
                logger.LogError(ex, ex.Message);
                result.Status = (int)ResponseStatusCode.InternaServerError;
                result.ErrorMessage = ex.Message;
                throw;
            }
            catch (Exception ex)
            {
                result.Status = (int)ResponseStatusCode.InternaServerError;
                result.ErrorMessage = ex.Message;
                throw;
            }
        }
        #endregion

        #region Active/Inactive Tour
        public async Task<ResultModel> ActiveInActiveTour(TourIDEntity entity, string storedProcedure)
        {
            ResultModel result = new ResultModel();

            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@ID", entity.ID);
                parameters.Add("@IsActive", entity.IsActive);
                parameters.Add("@UpdatedBy", entity.UpdatedBy);
                parameters.Add("@OperationType", CommonRepositoryConstants.UpdateActive);

                var data = await _dbConnection.QueryAsync(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
                result.Message = data.FirstOrDefault().Message;
                result.Details = data.FirstOrDefault().Details;
            }
            catch (SqlException ex)
            {
                logger.LogError(ex, ex.Message);
                result.Status = (int)ResponseStatusCode.InternaServerError;
                result.ErrorMessage = ex.Message;
                result.Message = CommonRepositoryMessages.CannotFindAllMessage;
                result.Details = CommonRepositoryMessages.CannotFindAllDetails;
            }
            catch (Exception ex)
            {
                result.Status = (int)ResponseStatusCode.InternaServerError;
                result.ErrorMessage = ex.Message;
                result.Message = CommonRepositoryMessages.ExceptionMessage;
            }

            return result;
        }
        #endregion

        #region Tour Image Update
        public async Task<ResultModel> TourImageUpdate(string? MainImage,string? BannerImage, List<TourDocumentsImage> Documents, int? ID, int? UpdatedBy, string storedProcedure)
        {
            ResultModel result = new ResultModel();

            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@ID", ID);
                parameters.Add("@MainImage", MainImage);
                parameters.Add("@BannerImage", BannerImage);
                parameters.AddTable("@UDTT_TourImage", "UDTT_TourImage", Documents.ToList());
                parameters.Add("@UpdatedBy", UpdatedBy);
                parameters.Add("@OperationType", 3);

                var data = await _dbConnection.QueryAsync(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
                result.Message = data.FirstOrDefault().Message;
                result.Details = data.FirstOrDefault().Details;
                return result;
            }
            catch (SqlException ex)
            {
                logger.LogError(ex, ex.Message);
                result.Status = (int)ResponseStatusCode.InternaServerError;
                result.ErrorMessage = ex.Message;
                throw;
            }
            catch (Exception ex)
            {
                result.Status = (int)ResponseStatusCode.InternaServerError;
                result.ErrorMessage = ex.Message;
                throw;
            }
        }
        #endregion
            
        #region Delete Tour
        public async Task<ResultModel> DeleteTourGalleryImage(TourIDEntity entity, string storedProcedure)
        {
            ResultModel result = new ResultModel();

            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@ID", entity.ID);
                parameters.Add("@OperationType", 4);

                var data = await _dbConnection.QueryAsync(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
                result.Message = data.FirstOrDefault().Message;
                result.Details = data.FirstOrDefault().Details;
            }
            catch (SqlException ex)
            {
                logger.LogError(ex, ex.Message);
                result.Status = (int)ResponseStatusCode.InternaServerError;
                result.ErrorMessage = ex.Message;
                result.Message = CommonRepositoryMessages.CannotFindAllMessage;
                result.Details = CommonRepositoryMessages.CannotFindAllDetails;
            }
            catch (Exception ex)
            {
                result.Status = (int)ResponseStatusCode.InternaServerError;
                result.ErrorMessage = ex.Message;
                result.Message = CommonRepositoryMessages.ExceptionMessage;
            }

            return result;
        }
        #endregion

        #region TourItineraryDetails insert
        public async Task<ResultModel> InsertTourItineraryDetails(TourItinerariesEntity entity, string storedProcedure)
        {
            ResultModel result = new ResultModel();

            try
            {
                Dapper.DefaultTypeMap.MatchNamesWithUnderscores = true;
                DynamicParameters dynamicParameters = new DynamicParameters();
                if (entity.ItinerariesData != null)
                {
                    dynamicParameters.AddTable("@UDTTTourItineraries", "UDTTTourItineraries", entity.ItinerariesData.ToList());
                }

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

        #region TourItineraryDetails update
        public async Task<ResultModel> UpdateTourItineraryDetails(TourItineraryDetailsEntity entity, string storedProcedure)
        {
            ResultModel result = new ResultModel();

            try
            {
                Dapper.DefaultTypeMap.MatchNamesWithUnderscores = true;
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@ID", entity.ID);
                dynamicParameters.Add("@TourID", entity.TourID);
                dynamicParameters.Add("@DayNo", entity.DayNo);
                dynamicParameters.Add("@SequenceNo", entity.SequenceNo);
                dynamicParameters.Add("@Title", entity.Title);
                dynamicParameters.Add("@Description", entity.Description);
                dynamicParameters.Add("@OperationType", CommonRepositoryConstants.Update);
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

        #region TourItineraryDetails delete
        public async Task<ResultModel> DeleteTourItineraryDetails(TourItineraryDetailsEntity entity, string storedProcedure)
        {
            ResultModel result = new ResultModel();

            try
            {
                Dapper.DefaultTypeMap.MatchNamesWithUnderscores = true;
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@ID", entity.ID);
                dynamicParameters.Add("@OperationType", 3);
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

        #region TourItineraryDetails find by id 
        public async Task<List<TourItineraryDetailsViewEntity>> FindByIdTourItineraryDetails(TourRateViewEntity entity, string storedProcedure)
        {
            TourItineraryDetailsViewEntity result = new TourItineraryDetailsViewEntity();

            try
            {
                Dapper.DefaultTypeMap.MatchNamesWithUnderscores = true;
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@TourID", entity.TourID);
                dynamicParameters.Add("@OperationType", 2);
                var data = await _dbConnection.QueryAsync<TourItineraryDetailsViewEntity>(storedProcedure, dynamicParameters, commandType: CommandType.StoredProcedure);
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


        #region TourCostDetails insert
        public async Task<ResultModel> InsertTourCostDetails(TourCostDetailsEntity entity, string storedProcedure)
        {
            ResultModel result = new ResultModel();

            try
            {
                Dapper.DefaultTypeMap.MatchNamesWithUnderscores = true;
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@TourID", entity.TourID);
               
                dynamicParameters.Add("@StartDate", entity.StartDate);
                dynamicParameters.Add("@EndDate", entity.EndDate);

                dynamicParameters.Add("@TwoSharing", entity.TwoSharing);
                dynamicParameters.Add("@ExtraAdults", entity.ExtraAdults);
                dynamicParameters.Add("@CWB", entity.CWB);
                dynamicParameters.Add("@CNB", entity.CNB);

                dynamicParameters.Add("@RoomTypeID", entity.RoomTypeID);
                dynamicParameters.Add("@RateTitle", entity.RateTitle);

                dynamicParameters.Add("@TwoPax", entity.TwoPax);
                dynamicParameters.Add("@FourPax", entity.FourPax);
                dynamicParameters.Add("@SixPax", entity.SixPax);
                dynamicParameters.Add("@EightPax", entity.EightPax);
                dynamicParameters.Add("@TenPax", entity.TenPax);

                dynamicParameters.Add("@PickupLocation", entity.PickupLocation);
                dynamicParameters.Add("@TwoPaxVehicleType", entity.TwoPaxVehicleType);
                dynamicParameters.Add("@FourPaxVehicleType", entity.FourPaxVehicleType);
                dynamicParameters.Add("@EightPaxVehicleType", entity.EightPaxVehicleType);

                dynamicParameters.Add("@IsActive", entity.IsActive);
    

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

        #region TourCostDetails update
        public async Task<ResultModel> UpdateTourCostDetails(TourCostDetailsEntity entity, string storedProcedure)
        {
            ResultModel result = new ResultModel();

            try
            {
                Dapper.DefaultTypeMap.MatchNamesWithUnderscores = true;
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@ID", entity.ID);

                dynamicParameters.Add("@TourID", entity.TourID);

                dynamicParameters.Add("@StartDate", entity.StartDate);
                dynamicParameters.Add("@EndDate", entity.EndDate);

                dynamicParameters.Add("@TwoSharing", entity.TwoSharing);
                dynamicParameters.Add("@ExtraAdults", entity.ExtraAdults);
                dynamicParameters.Add("@CWB", entity.CWB);
                dynamicParameters.Add("@CNB", entity.CNB);

                dynamicParameters.Add("@RoomTypeID", entity.RoomTypeID);
                dynamicParameters.Add("@RateTitle", entity.RateTitle);

                dynamicParameters.Add("@TwoPax", entity.TwoPax);
                dynamicParameters.Add("@FourPax", entity.FourPax);
                dynamicParameters.Add("@SixPax", entity.SixPax);
                dynamicParameters.Add("@EightPax", entity.EightPax);
                dynamicParameters.Add("@TenPax", entity.TenPax);

                dynamicParameters.Add("@PickupLocation", entity.PickupLocation);
                dynamicParameters.Add("@TwoPaxVehicleType", entity.TwoPaxVehicleType);
                dynamicParameters.Add("@FourPaxVehicleType", entity.FourPaxVehicleType);
                dynamicParameters.Add("@EightPaxVehicleType", entity.EightPaxVehicleType);

                dynamicParameters.Add("@IsActive", entity.IsActive);
          
                dynamicParameters.Add("@OperationType", CommonRepositoryConstants.Update);
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

        #region TourCostDetails delete
        public async Task<ResultModel> DeleteTourCostDetails(TourCostDetailsEntity entity, string storedProcedure)
        {
            ResultModel result = new ResultModel();

            try
            {
                Dapper.DefaultTypeMap.MatchNamesWithUnderscores = true;
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@ID", entity.ID);
                dynamicParameters.Add("@OperationType", 3);
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

        public async Task<List<TourCostDetailsViewEntity>> FindByIdTourCostDetails(TourRateViewEntity entity, string storedProcedure)
        {
            TourCostDetailsViewEntity result = new TourCostDetailsViewEntity();

            try
            {
                Dapper.DefaultTypeMap.MatchNamesWithUnderscores = true;
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@TourID", entity.TourID);
                dynamicParameters.Add("@OperationType", 2);
                var data = await _dbConnection.QueryAsync<TourCostDetailsViewEntity>(storedProcedure, dynamicParameters, commandType: CommandType.StoredProcedure);
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

        #region Insert TourVideo
        public async Task<ResultModel> InsertTourVideo(TourVideoEntity entity, string storedProcedure)
        {
            ResultModel result = new ResultModel();

            try
            {
                Dapper.DefaultTypeMap.MatchNamesWithUnderscores = true;
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@TourID", entity.TourID);
                dynamicParameters.Add("@operationtype", 1);


                if (entity.TourVideo != null)
                    dynamicParameters.AddTable<TourVideo>("@UDTT_TourVideo", "UDTT_TourVideo", entity.TourVideo);

                var data = await _dbConnection.QueryAsync(storedProcedure, dynamicParameters, commandType: CommandType.StoredProcedure);
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

        #region Update TourVideo
        public async Task<ResultModel> UpdateTourVideo(TourVideoEntity entity, string storedProcedure)
        {
            ResultModel result = new ResultModel();

            try
            {
                Dapper.DefaultTypeMap.MatchNamesWithUnderscores = true;
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@TourID", entity.TourID);
                dynamicParameters.Add("@operationtype", 3);

                if (entity.TourVideo != null)
                    dynamicParameters.AddTable<TourVideo>("@UDTT_TourVideo", "UDTT_TourVideo", entity.TourVideo);


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

        #region Delete TourVideo
        public async Task<ResultModel> DeleteTourVideo(TourIDEntity entity, string storedProcedure)
        {
            ResultModel result = new ResultModel();

            try
            {
                Dapper.DefaultTypeMap.MatchNamesWithUnderscores = true;
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@ID", entity.ID);
                dynamicParameters.Add("@operationtype", 6);
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

        #region Insert TourFAQ
        public async Task<ResultModel> InsertTourFAQ(TourFAQEntity entity, string storedProcedure)
        {
            ResultModel result = new ResultModel();

            try
            {
                Dapper.DefaultTypeMap.MatchNamesWithUnderscores = true;
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@TourID", entity.TourID);
                dynamicParameters.Add("@operationtype",2);


                if (entity.TourFAQ != null)
                    dynamicParameters.AddTable<TourFAQ>("@UDTT_TourFAQ", "UDTT_TourFAQ", entity.TourFAQ);

                var data = await _dbConnection.QueryAsync(storedProcedure, dynamicParameters, commandType: CommandType.StoredProcedure);
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

        #region Update TourFAQ
        public async Task<ResultModel> UpdateTourFAQ(TourFAQEntity entity, string storedProcedure)
        {
            ResultModel result = new ResultModel();

            try
            {
                Dapper.DefaultTypeMap.MatchNamesWithUnderscores = true;
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@TourID", entity.TourID);
                dynamicParameters.Add("@operationtype", 4);

                if (entity.TourFAQ != null)
                    dynamicParameters.AddTable<TourFAQ>("@UDTT_TourFAQ", "UDTT_TourFAQ", entity.TourFAQ);


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

        #region Delete TourFAQ
        public async Task<ResultModel> DeleteTourFAQ(TourIDEntity entity, string storedProcedure)
        {
            ResultModel result = new ResultModel();

            try
            {
                Dapper.DefaultTypeMap.MatchNamesWithUnderscores = true;
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@ID", entity.ID);
                dynamicParameters.Add("@operationtype", 7);
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
    }
}
