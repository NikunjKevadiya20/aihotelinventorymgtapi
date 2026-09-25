using Dapper;
using DapperParameters;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using HotelBooking.Entity.Common;
using HotelBooking.Entity.Common.Entities;
using HotelBooking.Entity.Common.Enums;
using HotelBooking.Entity.Common.Helpers;
using HotelBooking.Entity.Entities;
using System.Data;
using System.Data.SqlClient;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace HotelBooking.DataAccess.Base
{
    public class RoomStyleLookupRepository : IRoomStyleLookupRepositoryInterface
    {

        #region Global Variables
        private readonly IDbConnection _dbConnection;
        private readonly ILogger<RoomStyleLookupRepository> logger;
        #endregion

        public RoomStyleLookupRepository(ILogger<RoomStyleLookupRepository> _logger, IDbConnection dbConnection)
        {
            logger = _logger;
            _dbConnection = dbConnection;
        }


        #region Insert RoomStyle
        public async Task<ResultModel> InsertRoomStyle(RoomStyleEntity entity, string storedProcedure)
        {
            ResultModel result = new ResultModel();

            try
            {
                Dapper.DefaultTypeMap.MatchNamesWithUnderscores = true;
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@Title", entity.Title);
                dynamicParameters.Add("@IsActive", entity.IsActive);
                dynamicParameters.Add("@CreatedBy", entity.CreatedBy);
                dynamicParameters.Add("@operationtype", CommonRepositoryConstants.Insert);
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

        #region Update RoomStyle
        public async Task<ResultModel> UpdateRoomStyle(RoomStyleEntity entity, string storedProcedure)
        {
            ResultModel result = new ResultModel();

            try
            {
                Dapper.DefaultTypeMap.MatchNamesWithUnderscores = true;
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@ID", entity.ID);
                dynamicParameters.Add("@Title", entity.Title);
                dynamicParameters.Add("@IsActive", entity.IsActive);
                dynamicParameters.Add("@CreatedBy", entity.CreatedBy);
                dynamicParameters.Add("@operationtype", CommonRepositoryConstants.Update);
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

        #region Delete RoomStyle
        public async Task<ResultModel> DeleteRoomStyle(RoomStyleIDEntity entity, string storedProcedure)
        {
            ResultModel result = new ResultModel();

            try
            {
                Dapper.DefaultTypeMap.MatchNamesWithUnderscores = true;
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@ID", entity.ID);
                dynamicParameters.Add("@operationtype", CommonRepositoryConstants.Delete);
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

        #region FindBy ID RoomStyle
        public async Task<RoomStyleViewEntity> FindByIDRoomStyle(RoomStyleIDEntity entity, string storedProcedure)
        {
            RoomStyleViewEntity result = new RoomStyleViewEntity();

            try
            {
                Dapper.DefaultTypeMap.MatchNamesWithUnderscores = true;
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@ID", entity.ID);
                dynamicParameters.Add("@operationtype", CommonRepositoryConstants.FindByID);
                var data = await _dbConnection.QuerySingleOrDefaultAsync<RoomStyleViewEntity>(storedProcedure, dynamicParameters, commandType: CommandType.StoredProcedure);
                return data;
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

        #region Find All RoomStyle
        public async Task<List<RoomStyleViewEntity>> FindAllRoomStyle(RoomStyleIDEntity entity, string storedProcedure)
        {
            List<RoomStyleViewEntity> result = new List<RoomStyleViewEntity>();

            try
            {
                Dapper.DefaultTypeMap.MatchNamesWithUnderscores = true;
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@Title", entity.Title);
                dynamicParameters.Add("@operationtype", 3);
                var data = await _dbConnection.QueryAsync<RoomStyleViewEntity>(storedProcedure, dynamicParameters, commandType: CommandType.StoredProcedure);
                result = data.ToList();

            }
            catch (SqlException sqlException)
            {
                logger.LogError(sqlException, sqlException.Message);
                result = new List<RoomStyleViewEntity>();
                var objResult = new RoomStyleViewEntity();
                objResult.ErrorMessage = sqlException.Message;
                objResult.Status = (int)ResponseStatusCode.InternaServerError;
                objResult.Message = CommonRepositoryMessages.CannotFindAllMessage;
                objResult.Details = CommonRepositoryMessages.CannotFindAllDetails;
                result.Add(objResult);

            }
            catch (Exception ex)
            {
                result = new List<RoomStyleViewEntity>();
                var objResult = new RoomStyleViewEntity();
                objResult.Status = (int)ResponseStatusCode.InternaServerError;
                objResult.Message = CommonRepositoryMessages.ExceptionMessage;
                objResult.ErrorMessage = ex.Message;
                result.Add(objResult);

            }
            finally
            {
            }

            return result;
        }
        #endregion

        #region Find All Active RoomStyle
        public async Task<List<RoomStyleViewEntity>> FindAllActiveRoomStyle(string storedProcedure)
        {
            List<RoomStyleViewEntity> result = new List<RoomStyleViewEntity>();

            try
            {
                Dapper.DefaultTypeMap.MatchNamesWithUnderscores = true;
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@operationtype", 1);
                var data = await _dbConnection.QueryAsync<RoomStyleViewEntity>(storedProcedure, dynamicParameters, commandType: CommandType.StoredProcedure);
                result = data.ToList();

            }
            catch (SqlException sqlException)
            {
                logger.LogError(sqlException, sqlException.Message);
                result = new List<RoomStyleViewEntity>();
                var objResult = new RoomStyleViewEntity();
                objResult.ErrorMessage = sqlException.Message;
                objResult.Status = (int)ResponseStatusCode.InternaServerError;
                objResult.Message = CommonRepositoryMessages.CannotFindAllMessage;
                objResult.Details = CommonRepositoryMessages.CannotFindAllDetails;
                result.Add(objResult);

            }
            catch (Exception ex)
            {
                result = new List<RoomStyleViewEntity>();
                var objResult = new RoomStyleViewEntity();
                objResult.Status = (int)ResponseStatusCode.InternaServerError;
                objResult.Message = CommonRepositoryMessages.ExceptionMessage;
                objResult.ErrorMessage = ex.Message;
                result.Add(objResult);

            }
            finally
            {
            }

            return result;
        }
        #endregion

        #region Active InActive RoomStyle
        public async Task<ResultModel> ActiveInActiveRoomStyle(RoomStyleIDEntity entity, string storedProcedure)
        {
            ResultModel result = new ResultModel();

            try
            {
                Dapper.DefaultTypeMap.MatchNamesWithUnderscores = true;
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@ID", entity.ID);
                dynamicParameters.Add("@IsActive", entity.IsActive);
                dynamicParameters.Add("@UpdatedBy", entity.UpdatedBy);
                dynamicParameters.Add("@operationtype", CommonRepositoryConstants.UpdateActive);
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
