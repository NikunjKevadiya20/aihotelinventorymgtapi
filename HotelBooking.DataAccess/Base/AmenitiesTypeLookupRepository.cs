using Dapper;
using HotelBooking.Entity.Entities;
using HotelBooking.Entity.Common;
using HotelBooking.Entity.Common.Entities;
using HotelBooking.Entity.Common.Enums;
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
    public class AmenitiesTypeLookupRepository : IAmenitiesTypeLookupRepositoryInterface
    {
        #region Global Variables
        private readonly IDbConnection _dbConnection;
        #endregion

        private readonly ILogger<AmenitiesTypeLookupRepository> logger;

        public AmenitiesTypeLookupRepository(ILogger<AmenitiesTypeLookupRepository> _logger, IDbConnection dbConnection)
        {
            logger = _logger;
            _dbConnection = dbConnection;
        }

        #region Insert AmenitiesType
        public async Task<AmenitiesTypeIDViewEntity> InsertAmenitiesType(AmenitiesTypeEntity entity, string storedProcedure)
        {
            AmenitiesTypeIDViewEntity result = new AmenitiesTypeIDViewEntity();
            try
            {
                Dapper.DefaultTypeMap.MatchNamesWithUnderscores = true;
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@AmenitiesID", entity.AmenitiesID);
                parameters.Add("@AmenityType", entity.AmenityType);
                parameters.Add("@IsActive", entity.IsActive);
                parameters.Add("@CreatedBy", entity.CreatedBy);
                parameters.Add("@OperationType", 1); // Insert

                var data = await _dbConnection.QueryFirstOrDefaultAsync<AmenitiesTypeIDViewEntity>(
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

        #region Update AmenitiesType
        public async Task<ResultModel> UpdateAmenitiesType(AmenitiesTypeEntity entity, string storedProcedure)
        {
            ResultModel result = new ResultModel();
            try
            {
                Dapper.DefaultTypeMap.MatchNamesWithUnderscores = true;
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@ID", entity.ID);
                parameters.Add("@AmenitiesID", entity.AmenitiesID);
                parameters.Add("@AmenityType", entity.AmenityType);
                parameters.Add("@IsActive", entity.IsActive);
                parameters.Add("@UpdatedBy", entity.UpdatedBy);
                parameters.Add("@OperationType", 2); // Update

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

        #region Delete AmenitiesType
        public async Task<ResultModel> DeleteAmenitiesType(AmenitiesTypeIDEntity entity, string storedProcedure)
        {
            ResultModel result = new ResultModel();
            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@ID", entity.ID);
                parameters.Add("@UpdatedBy", entity.UpdatedBy);
                parameters.Add("@OperationType", 1); // Delete

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

        #region Find By ID AmenitiesType
        public async Task<AmenitiesTypeDataViewEntity> FindByIDAmenitiesType(AmenitiesTypeIDEntity entity, string storedProcedure)
        {
            AmenitiesTypeDataViewEntity result = new AmenitiesTypeDataViewEntity();
            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@ID", entity.ID);
                parameters.Add("@OperationType", 2); // FindByID

                var data = await _dbConnection.QuerySingleOrDefaultAsync<AmenitiesTypeDataViewEntity>(
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

        #region Find All AmenitiesType
        public async Task<List<AmenitiesTypeDataViewEntity>> FindAllAmenitiesType(AmenitiesTypeIDEntity entity, string storedProcedure)
        {
            AmenitiesTypeDataViewEntity result = new AmenitiesTypeDataViewEntity();
            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@AmenityType", entity.AmenityType);
                parameters.Add("@AmenitiesID", entity.AmenitiesID);
                parameters.Add("@OperationType", 3); // FindAll

                var data = await _dbConnection.QueryAsync<AmenitiesTypeDataViewEntity>(
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

        #region Find All Active AmenitiesType
        public async Task<List<AmenitiesTypeDataViewEntity>> FindAllActiveAmenitiesType(string storedProcedure)
        {
            AmenitiesTypeDataViewEntity result = new AmenitiesTypeDataViewEntity();
            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@OperationType", 5); // FindAllActive

                var data = await _dbConnection.QueryAsync<AmenitiesTypeDataViewEntity>(
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

        #region Active/Inactive AmenitiesType
        public async Task<ResultModel> ActiveInActiveAmenitiesType(AmenitiesTypeIDEntity entity, string storedProcedure)
        {
            ResultModel result = new ResultModel();
            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@ID", entity.ID);
                parameters.Add("@IsActive", entity.IsActive);
                parameters.Add("@UpdatedBy", entity.UpdatedBy);
                parameters.Add("@OperationType", 4); // Active/Inactive

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
    }
}
