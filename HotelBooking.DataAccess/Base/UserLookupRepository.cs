using Dapper;
using DapperParameters;
using HotelBooking.Entity.Common;
using HotelBooking.Entity.Common.Entities;
using HotelBooking.Entity.Common.Enums;
using HotelBooking.Entity.Common.Helpers;
using HotelBooking.Entity.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System.Data;
using System.Data.SqlClient;

namespace HotelBooking.DataAccess.Base
{
    public class UserLookupRepository : IUserLookupRepositoryInterface
    {
        #region Global Variables
        private readonly IDbConnection _dbConnection;
        private readonly ILogger<UserLookupRepository> logger;
        #endregion

        public UserLookupRepository(ILogger<UserLookupRepository> _logger, IDbConnection dbConnection)
        {
            logger = _logger;
            _dbConnection = dbConnection;
        }

        #region Insert User
        public async Task<UserIDView> InsertUser(UsersDataEntity entity, string storedProcedure)
        {
            UserIDView result = new UserIDView();


            try
            {
                Dapper.DefaultTypeMap.MatchNamesWithUnderscores = true;
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@FirstName", entity.FirstName);
                dynamicParameters.Add("@LastName", entity.LastName);
                dynamicParameters.Add("@MobileNo", entity.MobileNo);
                dynamicParameters.Add("@AlternateMobileNo", entity.AlternateMobileNo);
                dynamicParameters.Add("@EmailID", entity.EmailID);
                dynamicParameters.Add("@AlternateEmailID", entity.AlternateEmailID);
                if (entity.Password == null)
                    dynamicParameters.Add("@Password", "");
                else
                    dynamicParameters.Add("@Password", HashPassword.EncryptPlainTextToCipherText(entity.Password));
                dynamicParameters.Add("@IsActive", entity.IsActive);
                dynamicParameters.Add("@UserTypeID", entity.UserTypeID);
                dynamicParameters.Add("@CreatedBy", entity.CreatedBy);

                if (entity.UserRightsAssign is not null)
                {
                    dynamicParameters.AddTable("@UDTTUSERRIGHTSASSIGN", "UserRightsAssign", entity.UserRightsAssign.ToList());
                }

                dynamicParameters.Add("@operationtype", CommonRepositoryConstants.Insert);

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

        #region Update User
        public async Task<ResultModel> UpdateUser(UsersDataEntity entity, string storedProcedure)
        {
            ResultModel result = new ResultModel();

            try
            {
                Dapper.DefaultTypeMap.MatchNamesWithUnderscores = true;
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@ID", entity.ID);
                dynamicParameters.Add("@FirstName", entity.FirstName);
                dynamicParameters.Add("@LastName", entity.LastName);
                dynamicParameters.Add("@MobileNo", entity.MobileNo);
                dynamicParameters.Add("@AlternateMobileNo", entity.AlternateMobileNo);
                dynamicParameters.Add("@EmailID", entity.EmailID);
                dynamicParameters.Add("@AlternateEmailID", entity.AlternateEmailID);
                dynamicParameters.Add("@IsActive", entity.IsActive);
                dynamicParameters.Add("@UserTypeID", entity.UserTypeID);
                dynamicParameters.Add("@UpdatedBy", entity.UpdatedBy);
                if (entity.UserRightsAssign is not null)
                {
                    dynamicParameters.AddTable("@UDTTUSERRIGHTSASSIGN", "UserRightsAssign", entity.UserRightsAssign.ToList());
                }

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

        #region  Delete User
        public async Task<ResultModel> DeleteUser(UserIDEntity entity, string storedProcedure)
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

        #region Find By ID User
        public async Task<UsersListEntity> FindByIDUser(UserIDEntity entity, string storedProcedure)
        {
            UsersListEntity result = new UsersListEntity();


            try
            {
                Dapper.DefaultTypeMap.MatchNamesWithUnderscores = true;
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@ID", entity.ID);
                dynamicParameters.Add("@operationtype", CommonRepositoryConstants.FindByID);

                var data = await _dbConnection.QueryMultipleAsync(storedProcedure, dynamicParameters, commandType: CommandType.StoredProcedure);
                UsersListEntity userRightsAssignByID = await data.ReadFirstOrDefaultAsync<UsersListEntity>();
                if (userRightsAssignByID != null)
                {
                    var User = await data.ReadAsync<UserRightsAssignList>();
                    userRightsAssignByID.UserRightsAssign = User.ToList();
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

        #region Find All  User
        public async Task<List<UsersListEntity>> FindAllUser(UserIDEntity entity, string storedProcedure)
        {
            UsersListEntity result = new UsersListEntity();

            try
            {
                Dapper.DefaultTypeMap.MatchNamesWithUnderscores = true;
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@FirstName", entity.FirstName);
                dynamicParameters.Add("@operationtype", CommonRepositoryConstants.FindAllItems);
                var data = await _dbConnection.QueryAsync<UsersListEntity>(storedProcedure, dynamicParameters, commandType: CommandType.StoredProcedure);
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

        #region Find All Active User
        public async Task<List<UsersListEntity>> FindAllActiveUser(string storedProcedure)
        {
            UsersListEntity result = new UsersListEntity();

            try
            {
                Dapper.DefaultTypeMap.MatchNamesWithUnderscores = true;
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@operationtype", CommonRepositoryConstants.FindAllActive);
                var data = await _dbConnection.QueryAsync<UsersListEntity>(storedProcedure, dynamicParameters, commandType: CommandType.StoredProcedure);
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

        #region  Active InActive User
        public async Task<ResultModel> ActiveInActiveUser(UserIDEntity entity, string storedProcedure)
        {
            ResultModel result = new ResultModel();

            try
            {
                Dapper.DefaultTypeMap.MatchNamesWithUnderscores = true;
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@ID", entity.ID);
                dynamicParameters.Add("@IsActive", entity.IsActive);
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

        #region User Image Update
        public async Task<UserImageListEntity> UserImageUpdate(string? physicalFileName, int? ID, int? UpdatedBy, string storedProcedure)
        {
            UserImageListEntity result = new UserImageListEntity();
            try
            {

                Dapper.DefaultTypeMap.MatchNamesWithUnderscores = true;
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@ID", ID);
                dynamicParameters.Add("@UserImage", physicalFileName);
                dynamicParameters.Add("@UpdatedBy", UpdatedBy);
                dynamicParameters.Add("@OperationType", 3);

                var data = await _dbConnection.QueryAsync<UserImageListEntity>(storedProcedure, dynamicParameters, commandType: System.Data.CommandType.StoredProcedure);


                result.Message = data.FirstOrDefault().Message;
                result.Details = data.FirstOrDefault().Details;
                result.Status = (int)ResponseStatusCode.Success;
                result.UserImage = data.FirstOrDefault().UserImage;
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

    }

}
