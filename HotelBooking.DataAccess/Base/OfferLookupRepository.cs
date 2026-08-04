using HotelBooking.Entity.Common;
using HotelBooking.Entity.Common.Entities;
using HotelBooking.Entity.Common.Enums;
using HotelBooking.Entity.Entities;
using Dapper;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static HotelBooking.Entity.Entities.OfferIDEntity;

namespace HotelBooking.DataAccess.Base
{
    public class OfferLookupRepository : IOfferLookupRepositoryInterface
    {
        #region Global Variables
        private readonly IDbConnection _dbConnection;
        private readonly ILogger<OfferLookupRepository> logger;
        #endregion

        public OfferLookupRepository(ILogger<OfferLookupRepository> _logger, IDbConnection dbConnection)
        {
            logger = _logger;
            _dbConnection = dbConnection;
        }

        #region Insert Offer
        public async Task<OfferIDViewEntity> InsertOffer(OfferEntity entity, string storedProcedure)
        {
            OfferIDViewEntity result = new OfferIDViewEntity();
            try
            {
                Dapper.DefaultTypeMap.MatchNamesWithUnderscores = true;
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@CouponCode", entity.CouponCode);
                parameters.Add("@ValidityFrom", entity.ValidityFrom);
                parameters.Add("@ValidityTo", entity.ValidityTo);
                parameters.Add("@ShortDescription", entity.ShortDescription);
                parameters.Add("@UsageCount", entity.UsageCount);
                parameters.Add("@AmountType", entity.AmountType);
                parameters.Add("@Percentage", entity.Percentage);
                parameters.Add("@Amount", entity.Amount);
                parameters.Add("@MaxAmount", entity.MaxAmount);

                parameters.Add("@IsActive", entity.IsActive);
                parameters.Add("@CreatedBy", entity.CreatedBy);
                parameters.Add("@OperationType", CommonRepositoryConstants.Insert);

                var data = await _dbConnection.QueryFirstOrDefaultAsync<OfferIDViewEntity>(
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

        #region Update Offer
        public async Task<ResultModel> UpdateOffer(OfferEntity entity, string storedProcedure)
        {
            ResultModel result = new ResultModel();
            try
            {
                Dapper.DefaultTypeMap.MatchNamesWithUnderscores = true;
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@ID", entity.ID);
                parameters.Add("@CouponCode", entity.CouponCode);
                parameters.Add("@ValidityFrom", entity.ValidityFrom);
                parameters.Add("@ValidityTo", entity.ValidityTo);
                parameters.Add("@ShortDescription", entity.ShortDescription);
                parameters.Add("@UsageCount", entity.UsageCount);
                parameters.Add("@AmountType", entity.AmountType);
                parameters.Add("@Percentage", entity.Percentage);
                parameters.Add("@Amount", entity.Amount);
                parameters.Add("@MaxAmount", entity.MaxAmount);
                parameters.Add("@IsActive", entity.IsActive);
                parameters.Add("@UpdatedBy", entity.UpdatedBy);
                parameters.Add("@OperationType", CommonRepositoryConstants.Update);

                var data = await _dbConnection.QueryAsync(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
                result.Message = data.FirstOrDefault()?.Message;
                result.Details = data.FirstOrDefault()?.Details;
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

        #region Delete Offer
        public async Task<ResultModel> DeleteOffer(OfferIDEntity entity, string storedProcedure)
        {
            ResultModel result = new ResultModel();
            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@ID", entity.ID);
                parameters.Add("@UpdatedBy", entity.UpdatedBy);
                parameters.Add("@OperationType", CommonRepositoryConstants.Delete);

                var data = await _dbConnection.QueryAsync(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
                result.Message = data.FirstOrDefault()?.Message;
                result.Details = data.FirstOrDefault()?.Details;
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

        #region Find By ID Offer
        public async Task<OfferDataViewEntity> FindByIDOffer(OfferIDEntity entity, string storedProcedure)
        {
            OfferDataViewEntity result = new OfferDataViewEntity();
            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@ID", entity.ID);
                parameters.Add("@OperationType", CommonRepositoryConstants.FindByID);

                var data = await _dbConnection.QuerySingleOrDefaultAsync<OfferDataViewEntity>(
                    storedProcedure, parameters, commandType: CommandType.StoredProcedure);
                return data;
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

        #region Find All Offer
        public async Task<List<OfferDataViewEntity>> FindAllOffer(OfferIDEntity entity, string storedProcedure)
        {
            OfferDataViewEntity result = new OfferDataViewEntity();
            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@CouponCode", entity.CouponCode);
                parameters.Add("@OperationType", CommonRepositoryConstants.FindAllItems);

                var data = await _dbConnection.QueryAsync<OfferDataViewEntity>(
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

        #region Find All Active Offer
        public async Task<List<OfferDataViewEntity>> FindAllActiveOffer(string storedProcedure)
        {
            OfferDataViewEntity result = new OfferDataViewEntity();
            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@OperationType", 5);

                var data = await _dbConnection.QueryAsync<OfferDataViewEntity>(
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

        #region Active/Inactive Offer
        public async Task<ResultModel> ActiveInActiveOffer(OfferIDEntity entity, string storedProcedure)
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
                result.Message = data.FirstOrDefault()?.Message;
                result.Details = data.FirstOrDefault()?.Details;
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

        #region Offer Image Update
        public async Task<ResultModel> OfferImageUpdate(string? ImageUpload, int? ID, int? UpdatedBy, string storedProcedure)
        {
            ResultModel result = new ResultModel();
            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@ID", ID);
                parameters.Add("@ImageUpload", ImageUpload);
                parameters.Add("@UpdatedBy", UpdatedBy);
                parameters.Add("@OperationType", 3);

                var data = await _dbConnection.QueryAsync(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
                result.Message = data.FirstOrDefault()?.Message;
                result.Details = data.FirstOrDefault()?.Details;
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

        #region Find By Coupon Code
        public async Task<OfferViewEntity> FindByCouponCode(OfferIDEntity entity, string storedProcedure)
        {
            OfferViewEntity result = new OfferViewEntity();

            try
            {
                Dapper.DefaultTypeMap.MatchNamesWithUnderscores = true;
                DynamicParameters dynamicParameters = new DynamicParameters();

                dynamicParameters.Add("@CouponCode", entity.CouponCode);
                dynamicParameters.Add("@OperationType", 8);
                var data = await _dbConnection.QuerySingleOrDefaultAsync<OfferViewEntity>(storedProcedure, dynamicParameters, commandType: CommandType.StoredProcedure);
                return data;

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

        #region Get All Available Offers

        public async Task<List<OfferViewEntity>> GetAllAvailableOffers(string storedProcedure)
        {
            List<OfferViewEntity> result = new List<OfferViewEntity>();
            try
            {
                Dapper.DefaultTypeMap.MatchNamesWithUnderscores = true;
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@OperationType", 5);
                var data = await _dbConnection.QueryAsync<OfferViewEntity>(storedProcedure, dynamicParameters, commandType: CommandType.StoredProcedure);
                return data.ToList();
            }
            catch (SqlException sqlException)
            {
                logger.LogError(sqlException, sqlException.Message);
                result[0].ErrorMessage = sqlException.Message;
                result[0].Status = (int)ResponseStatusCode.InternaServerError;
                result[0].Message = CommonRepositoryMessages.CannotFindAllMessage;
                result[0].Details = CommonRepositoryMessages.CannotFindAllDetails;
                throw;
            }
            catch (Exception ex)
            {
                result[0].Status = (int)ResponseStatusCode.InternaServerError;
                result[0].Message = CommonRepositoryMessages.ExceptionMessage;
                result[0].ErrorMessage = ex.Message;
                throw;
            }
            finally
            {
            }


        }
        #endregion
    }
}