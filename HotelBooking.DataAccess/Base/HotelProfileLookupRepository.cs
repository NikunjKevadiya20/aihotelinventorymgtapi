using Dapper;
using HotelBooking.Entity.Common;
using HotelBooking.Entity.Common.Entities;
using HotelBooking.Entity.Common.Enums;
using HotelBooking.Entity.Entities;
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
    public class HotelProfileLookupRepository : IHotelProfileLookupRepositoryInterface
    {
        #region Global Variables
        private readonly IDbConnection _dbConnection;
        #endregion
        private readonly ILogger<HotelProfileLookupRepository> logger;

        public HotelProfileLookupRepository(ILogger<HotelProfileLookupRepository> _logger, IDbConnection dbConnection)
        {
            logger = _logger;
            _dbConnection = dbConnection;
        }

        #region Insert HotelProfile
        public async Task<PhilosophyIDViewEntity> InsertHotelProfile(HotelProfileEntity entity, string storedProcedure)
        {
            ResultModel result = new ResultModel();
            try
            {
                Dapper.DefaultTypeMap.MatchNamesWithUnderscores = true;
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@HotelName", entity.HotelName);
                dynamicParameters.Add("@Address", entity.Address);
                dynamicParameters.Add("@MobileNo", entity.MobileNo);
                dynamicParameters.Add("@EmailID", entity.EmailID);
                dynamicParameters.Add("@MapURL", entity.MapURL);
                dynamicParameters.Add("@StarCategory", entity.StarCategory);
                dynamicParameters.Add("@CheckInTime", entity.CheckInTime);
                dynamicParameters.Add("@CheckOutTime", entity.CheckOutTime);
                dynamicParameters.Add("@ContactDetails", entity.ContactDetails);
                dynamicParameters.Add("@GSTDetails", entity.GSTDetails);
                dynamicParameters.Add("@BankDetails", entity.BankDetails);
                dynamicParameters.Add("@ChildPolicy", entity.ChildPolicy);
                dynamicParameters.Add("@CommonPolicy", entity.CommonPolicy);
                dynamicParameters.Add("@CancellationPolicy", entity.CancellationPolicy);
                dynamicParameters.Add("@TermsAndCondition", entity.TermsAndCondition);
                dynamicParameters.Add("@LogoFile", entity.LogoFile);
                dynamicParameters.Add("@IsActive", entity.IsActive);
                dynamicParameters.Add("@CreatedBy", entity.CreatedBy);
                dynamicParameters.Add("@operationtype", CommonRepositoryConstants.Insert);

                var data = await _dbConnection.QueryFirstOrDefaultAsync<PhilosophyIDViewEntity>(storedProcedure, dynamicParameters, commandType: CommandType.StoredProcedure);
                return data;
            }
            catch (SqlException sqlException)
            {
                logger.LogError(sqlException, sqlException.Message);
                throw;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        #endregion

        #region Update HotelProfile
        public async Task<ResultModel> UpdateHotelProfile(HotelProfileEntity entity, string storedProcedure)
        {
            ResultModel result = new ResultModel();
            try
            {
                Dapper.DefaultTypeMap.MatchNamesWithUnderscores = true;
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@ID", entity.ID);
                dynamicParameters.Add("@HotelName", entity.HotelName);
                dynamicParameters.Add("@Address", entity.Address);
                dynamicParameters.Add("@MobileNo", entity.MobileNo);
                dynamicParameters.Add("@EmailID", entity.EmailID);
                dynamicParameters.Add("@MapURL", entity.MapURL);
                dynamicParameters.Add("@StarCategory", entity.StarCategory);
                dynamicParameters.Add("@CheckInTime", entity.CheckInTime);
                dynamicParameters.Add("@CheckOutTime", entity.CheckOutTime);
                dynamicParameters.Add("@ContactDetails", entity.ContactDetails);
                dynamicParameters.Add("@GSTDetails", entity.GSTDetails);
                dynamicParameters.Add("@BankDetails", entity.BankDetails);
                dynamicParameters.Add("@ChildPolicy", entity.ChildPolicy);
                dynamicParameters.Add("@CommonPolicy", entity.CommonPolicy);
                dynamicParameters.Add("@CancellationPolicy", entity.CancellationPolicy);
                dynamicParameters.Add("@TermsAndCondition", entity.TermsAndCondition);
                dynamicParameters.Add("@IsActive", entity.IsActive);
                dynamicParameters.Add("@UpdatedBy", entity.UpdatedBy);
                dynamicParameters.Add("@operationtype", CommonRepositoryConstants.Update);

                var data = await _dbConnection.QueryAsync(storedProcedure, dynamicParameters, commandType: CommandType.StoredProcedure);
                result.Message = data.FirstOrDefault()?.Message;
                result.Details = data.FirstOrDefault()?.Details;
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

        #region Delete HotelProfile
        public async Task<ResultModel> DeleteHotelProfile(HotelProfileIDEntity entity, string storedProcedure)
        {
            ResultModel result = new ResultModel();
            try
            {
                Dapper.DefaultTypeMap.MatchNamesWithUnderscores = true;
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@ID", entity.ID);
                dynamicParameters.Add("@UpdatedBy", entity.UpdatedBy);
                dynamicParameters.Add("@operationtype", CommonRepositoryConstants.Delete);

                var data = await _dbConnection.QueryAsync(storedProcedure, dynamicParameters, commandType: CommandType.StoredProcedure);
                result.Message = data.FirstOrDefault()?.Message;
                result.Details = data.FirstOrDefault()?.Details;
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

        #region FindBy ID HotelProfile
        public async Task<HotelProfileViewEntity> FindByIDHotelProfile(HotelProfileIDEntity entity, string storedProcedure)
        {
            try
            {
                Dapper.DefaultTypeMap.MatchNamesWithUnderscores = true;
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@ID", entity.ID);
                dynamicParameters.Add("@operationtype", CommonRepositoryConstants.FindByID);

                var data = await _dbConnection.QuerySingleOrDefaultAsync<HotelProfileViewEntity>(storedProcedure, dynamicParameters, commandType: CommandType.StoredProcedure);
                return data;
            }
            catch (SqlException sqlException)
            {
                logger.LogError(sqlException, sqlException.Message);
                throw;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        #endregion

        #region Find All HotelProfile
        public async Task<List<HotelProfileViewEntity>> FindAllHotelProfile(HotelProfileIDEntity entity, string storedProcedure)
        {
            try
            {
                Dapper.DefaultTypeMap.MatchNamesWithUnderscores = true;
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@HotelName", entity.HotelName);
                dynamicParameters.Add("@operationtype", 3); // Search mode as per SP

                var data = await _dbConnection.QueryAsync<HotelProfileViewEntity>(storedProcedure, dynamicParameters, commandType: CommandType.StoredProcedure);
                return data.ToList();
            }
            catch (SqlException sqlException)
            {
                logger.LogError(sqlException, sqlException.Message);
                throw;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        #endregion

        #region Find All Active HotelProfile
        public async Task<List<HotelProfileViewEntity>> FindAllActiveHotelProfile(string storedProcedure)
        {
            try
            {
                Dapper.DefaultTypeMap.MatchNamesWithUnderscores = true;
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@operationtype", 1); // Active only

                var data = await _dbConnection.QueryAsync<HotelProfileViewEntity>(storedProcedure, dynamicParameters, commandType: CommandType.StoredProcedure);
                return data.ToList();
            }
            catch (SqlException sqlException)
            {
                logger.LogError(sqlException, sqlException.Message);
                throw;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        #endregion

        #region Active InActive HotelProfile
        public async Task<ResultModel> ActiveInActiveHotelProfile(HotelProfileIDEntity entity, string storedProcedure)
        {
            ResultModel result = new ResultModel();
            try
            {
                Dapper.DefaultTypeMap.MatchNamesWithUnderscores = true;
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@ID", entity.ID);
                dynamicParameters.Add("@IsActive", entity.IsActive);
                dynamicParameters.Add("@UpdatedBy", entity.UpdatedBy);
                dynamicParameters.Add("@operationtype", 4);

                var data = await _dbConnection.QueryAsync(storedProcedure, dynamicParameters, commandType: CommandType.StoredProcedure);
                result.Message = data.FirstOrDefault()?.Message;
                result.Details = data.FirstOrDefault()?.Details;
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

        #region Upload Logo HotelProfile
        public async Task<ResultModel> UploadLogoHotelProfile(int? ID, string? LogoFile, int? UpdatedBy, string storedProcedure)
        {
            ResultModel result = new ResultModel();
            try
            {
                Dapper.DefaultTypeMap.MatchNamesWithUnderscores = true;
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@ID", ID);
                dynamicParameters.Add("@LogoFile", LogoFile);
                dynamicParameters.Add("@UpdatedBy", UpdatedBy);
                dynamicParameters.Add("@operationtype", 3);

                var data = await _dbConnection.QueryAsync(storedProcedure, dynamicParameters, commandType: CommandType.StoredProcedure);
                result.Message = data.FirstOrDefault()?.Message;
                result.Details = data.FirstOrDefault()?.Details;
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
