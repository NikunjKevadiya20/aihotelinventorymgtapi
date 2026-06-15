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
    public class UserTypeLookupRepository : IUserTypeLookupRepositoryInterface
    {

        #region Global Variables
        private readonly IDbConnection _dbConnection;
        private readonly ILogger<UserTypeLookupRepository> logger;
        #endregion

        public UserTypeLookupRepository(ILogger<UserTypeLookupRepository> _logger, IDbConnection dbConnection)
        {
            logger = _logger;
            _dbConnection = dbConnection;
        }

        #region Insert UserType
        public async Task<UserIDView> InsertUserType(UserTypeDataEntity entity, string storedProcedure)
        {
            UserIDView result = new UserIDView();


            try
            {
                Dapper.DefaultTypeMap.MatchNamesWithUnderscores = true;
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@UserType", entity.UserType);
                dynamicParameters.Add("@IsActive", entity.IsActive);
                dynamicParameters.Add("@CreatedBy", entity.CreatedBy);
         
                dynamicParameters.Add("@OperationType", CommonRepositoryConstants.Insert);
                if (entity.UserTypeRightsAssign is not null)
                {
                    dynamicParameters.AddTable("@UDTTUSERRIGHTSASSIGN", "UserRightsAssign", entity.UserTypeRightsAssign.ToList());
                }

                var data = await _dbConnection.QueryFirstOrDefaultAsync<UserIDView>(storedProcedure, dynamicParameters, commandType: CommandType.StoredProcedure);

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

        #region Update UserType
        public async Task<ResultModel> UpdateUserType(UserTypeDataEntity entity, string storedProcedure)
        {
            ResultModel result = new ResultModel();

            try
            {
                Dapper.DefaultTypeMap.MatchNamesWithUnderscores = true;
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@ID", entity.ID);
                dynamicParameters.Add("@UserType", entity.UserType);
                dynamicParameters.Add("@IsActive", entity.IsActive);
                dynamicParameters.Add("@UpdatedBy", entity.UpdatedBy);
               
                if (entity.UserTypeRightsAssign is not null)
                {
                    dynamicParameters.AddTable("@UDTTUSERRIGHTSASSIGN", "UserRightsAssign", entity.UserTypeRightsAssign.ToList());
                }
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

        #region  Delete UserType
        public async Task<ResultModel> DeleteUserType(UserTypeIDEntity entity, string storedProcedure)
        {
            ResultModel result = new ResultModel();

            try
            {
                Dapper.DefaultTypeMap.MatchNamesWithUnderscores = true;
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@ID", entity.ID);
                dynamicParameters.Add("@OperationType", CommonRepositoryConstants.Delete);
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

        #region Find By ID UserType
        public async Task<UserTypeListEntity> FindByIDUserType(UserTypeIDEntity entity, string storedProcedure)
        {
            UserTypeListEntity result = new UserTypeListEntity();

            try
            {
                Dapper.DefaultTypeMap.MatchNamesWithUnderscores = true;
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@ID", entity.ID);
                dynamicParameters.Add("@OperationType", CommonRepositoryConstants.FindByID);
                var data = await _dbConnection.QueryMultipleAsync(storedProcedure, dynamicParameters, commandType: CommandType.StoredProcedure);
                UserTypeListEntity userRightsAssignByID = await data.ReadFirstOrDefaultAsync<UserTypeListEntity>();
                if (userRightsAssignByID != null)
                {
                    var User = await data.ReadAsync<UserRightsAssign>();
                    userRightsAssignByID.UserTypeRightsAssign = User.ToList();
                }

                return userRightsAssignByID;

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

        #region Find All  UserType
        public async Task<List<UserTypeListEntity>> FindAllUserType(UserTypeIDEntity entity, string storedProcedure)
        {
            UserTypeListEntity result = new UserTypeListEntity();

            try
            {
                Dapper.DefaultTypeMap.MatchNamesWithUnderscores = true;
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@UserType", entity.UserType);
                dynamicParameters.Add("@OperationType", CommonRepositoryConstants.FindAllItems);
                var data = await _dbConnection.QueryAsync<UserTypeListEntity>(storedProcedure, dynamicParameters, commandType: CommandType.StoredProcedure);
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

        #region Find All Active  UserType
        public async Task<List<UserTypeListEntity>> FindAllActiveUserType( string storedProcedure)
        {
            UserTypeListEntity result = new UserTypeListEntity();
     

            try
            {
                Dapper.DefaultTypeMap.MatchNamesWithUnderscores = true;
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@OperationType",CommonRepositoryConstants.FindAllActive);
                var data = await _dbConnection.QueryAsync<UserTypeListEntity>(storedProcedure, dynamicParameters, commandType: CommandType.StoredProcedure);
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

        #region  Active InActive UserType
        public async Task<ResultModel> ActiveInActiveUserType(UserTypeIDEntity entity, string storedProcedure)
        {
            ResultModel result = new ResultModel();

            try
            {
                Dapper.DefaultTypeMap.MatchNamesWithUnderscores = true;
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@ID", entity.ID);
                dynamicParameters.Add("@IsActive", entity.IsActive);
                dynamicParameters.Add("@OperationType",CommonRepositoryConstants.UpdateActive);
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
