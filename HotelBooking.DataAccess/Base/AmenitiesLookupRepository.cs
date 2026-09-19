using Dapper;
using HotelBooking.Entity.Common;
using HotelBooking.Entity.Common.Entities;
using HotelBooking.Entity.Common.Enums;
using HotelBooking.Entity.Common.Helper;
using HotelBooking.Entity.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBooking.DataAccess.Base
{
    public class AmenitiesLookupRepository : IAmenitiesLookupRepositoryInterface
    {
        #region Global Variables
        private readonly IDbConnection _dbConnection;
        #endregion

        private readonly ILogger<AmenitiesLookupRepository> logger;
   

        public AmenitiesLookupRepository(ILogger<AmenitiesLookupRepository> _logger, IDbConnection dbConnection)
        {
            logger = _logger;
            _dbConnection = dbConnection;
        }

        #region Insert Amenities
        public async Task<AmenitiesIDViewEntity> InsertAmenities(AmenitiesEntity entity, string storedProcedure)
        {
            AmenitiesIDViewEntity result = new AmenitiesIDViewEntity();

            try
            {
                Dapper.DefaultTypeMap.MatchNamesWithUnderscores = true;
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@PropertyID", entity.PropertyID);
                parameters.Add("@OTAID", entity.OTAID);
                parameters.Add("@Description", entity.Description);
                parameters.Add("@AmenitiesName", entity.AmenitiesName);              
                parameters.Add("@AmenitiesTypeID", entity.AmenitiesTypeID);              
                parameters.Add("@IsActive", entity.IsActive);
                parameters.Add("@CreatedBy", entity.CreatedBy);
                parameters.Add("@OperationType", CommonRepositoryConstants.Insert);

                var data = await _dbConnection.QueryFirstOrDefaultAsync<AmenitiesIDViewEntity>(
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

        #region Update Amenities
        public async Task<ResultModel> UpdateAmenities(AmenitiesEntity entity, string storedProcedure)
        {
            ResultModel result = new ResultModel();

            try
            {
                Dapper.DefaultTypeMap.MatchNamesWithUnderscores = true;
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@ID", entity.ID);
                parameters.Add("@PropertyID", entity.PropertyID);
                parameters.Add("@OTAID", entity.OTAID);
                parameters.Add("@Description", entity.Description);
                parameters.Add("@AmenitiesName", entity.AmenitiesName);
                parameters.Add("@AmenitiesTypeID", entity.AmenitiesTypeID);
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

        #region Delete Amenities
        public async Task<ResultModel> DeleteAmenities(AmenitiesIDEntity entity, string storedProcedure)
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

        #region Find By ID Amenities
        public async Task<AmenitiesDataViewEntity> FindByIDAmenities(AmenitiesIDEntity entity, string storedProcedure)
        {
            AmenitiesDataViewEntity result = new AmenitiesDataViewEntity();

            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@ID", entity.ID);
                parameters.Add("@OperationType", CommonRepositoryConstants.FindByID);

                var data = await _dbConnection.QuerySingleOrDefaultAsync<AmenitiesDataViewEntity>(
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

        #region Find All Amenities
        public async Task<List<AmenitiesDataViewEntity>> FindAllAmenities(AmenitiesIDEntity entity, string storedProcedure)
        {
            AmenitiesDataViewEntity result = new AmenitiesDataViewEntity();

            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@AmenitiesName", entity.AmenitiesName);
                parameters.Add("@OperationType", CommonRepositoryConstants.FindAllItems);

                var data = await _dbConnection.QueryAsync<AmenitiesDataViewEntity>(
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

        #region Find All Active Amenities
        public async Task<List<AmenitiesDataViewEntity>> FindAllActiveAmenities(string storedProcedure)
        {
            AmenitiesDataViewEntity result = new AmenitiesDataViewEntity();

            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@OperationType", 5);
                var data = await _dbConnection.QueryAsync<AmenitiesDataViewEntity>(
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

        #region Active/Inactive Amenities
        public async Task<ResultModel> ActiveInActiveAmenities(AmenitiesIDEntity entity, string storedProcedure)
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

        #region Amenities Icon Upload
        public async Task<ResultModel> AmenitiesIconUpdate(string? Icon,int? ID,int? UpdatedBy,string storedProcedure)
        {
            ResultModel result = new ResultModel();

            try
            {
                Dapper.DefaultTypeMap.MatchNamesWithUnderscores = true;

                DynamicParameters dynamicParameters = new DynamicParameters();

                dynamicParameters.Add("@ID", ID);
                dynamicParameters.Add("@Icon", Icon);
                dynamicParameters.Add("@UpdatedBy", UpdatedBy);
                dynamicParameters.Add("@OperationType", 3);

                var data = await _dbConnection.QueryAsync(
                    storedProcedure,
                    dynamicParameters,
                    commandType: CommandType.StoredProcedure);

                var firstData = data.FirstOrDefault();

                if (firstData != null)
                {
                    result.Message = firstData.Message;
                    result.Details = firstData.Details;
                }
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

            return result;
        }
        #endregion

    }
}
