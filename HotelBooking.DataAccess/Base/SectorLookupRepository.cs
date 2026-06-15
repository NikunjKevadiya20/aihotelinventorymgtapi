using HotelBooking.Entity.Common;
using HotelBooking.Entity.Common.Entities;
using HotelBooking.Entity.Common.Enums;
using HotelBooking.Entity.Entities;
using Dapper;
using Microsoft.Extensions.Logging;
using System.Data;
using System.Data.SqlClient;

namespace HotelBooking.DataAccess.Base
{
    public class SectorLookupRepository : ISectorLookupRepositoryInterface
    {
        #region Global Variables
        private readonly IDbConnection _dbConnection;
        #endregion


        private readonly ILogger<SectorLookupRepository> logger;

        public SectorLookupRepository(ILogger<SectorLookupRepository> _logger, IDbConnection dbConnection)
        {
            logger = _logger;
            _dbConnection = dbConnection;
        }
        #region Insert Sectore
        public async Task<SectorResultModel> InsertSector(SectorDataEntity entity, string storedProcedure)
        {
            SectorResultModel result = new SectorResultModel();

            try
            {
                Dapper.DefaultTypeMap.MatchNamesWithUnderscores = true;
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@RegionID", entity.RegionID);
                dynamicParameters.Add("@CountryID", entity.CountryID);
                dynamicParameters.Add("@SectorName", entity.SectorName);
                dynamicParameters.Add("@SectorURL", entity.SectorURL);
                dynamicParameters.Add("@SectorType", entity.SectorType);
                dynamicParameters.Add("@CityID", entity.CityID);
                dynamicParameters.Add("@Prefix", entity.Prefix);
                dynamicParameters.Add("@IsShowOnHome", entity.IsShowOnHome);
                dynamicParameters.Add("@IsShowOnMenu", entity.IsShowOnMenu);
                dynamicParameters.Add("@Description", entity.Description);
                dynamicParameters.Add("@MetaTitle", entity.MetaTitle);
                dynamicParameters.Add("@MetaKeyWord", entity.MetaKeyWord);
                dynamicParameters.Add("@MetaDiscription", entity.MetaDiscription);
                dynamicParameters.Add("@Season", entity.Season);
                dynamicParameters.Add("@LongDescription", entity.LongDescription);
                dynamicParameters.Add("@SequenceNo", entity.SequenceNo);
                dynamicParameters.Add("@Inclusions", entity.Inclusions);
                dynamicParameters.Add("@Exclusions", entity.Exclusions);
                dynamicParameters.Add("@CancellationPolicy", entity.CancellationPolicy);

                dynamicParameters.Add("@TermsNCondition", entity.TermsNCondition);
                dynamicParameters.Add("@IsActive", entity.IsActive);
                dynamicParameters.Add("@CreatedBy", entity.CreatedBy);
                dynamicParameters.Add("@OperationType", CommonRepositoryConstants.Insert);
                var data = await _dbConnection.QueryFirstOrDefaultAsync<SectorResultModel>(storedProcedure, dynamicParameters, commandType: CommandType.StoredProcedure);

                result = data;
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

        #region Update Sector
        public async Task<ResultModel> UpdateSector(SectorDataEntity entity, string storedProcedure)
        {
            ResultModel result = new ResultModel();

            try
            {
                Dapper.DefaultTypeMap.MatchNamesWithUnderscores = true;
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@ID", entity.ID);
                dynamicParameters.Add("@RegionID", entity.RegionID);
                dynamicParameters.Add("@CountryID", entity.CountryID);
                dynamicParameters.Add("@SectorName", entity.SectorName);
                dynamicParameters.Add("@SectorURL", entity.SectorURL);
                dynamicParameters.Add("@SectorType", entity.SectorType);
                dynamicParameters.Add("@Prefix", entity.Prefix);
                dynamicParameters.Add("@CityID", entity.CityID);
                dynamicParameters.Add("@IsShowOnHome", entity.IsShowOnHome);
                dynamicParameters.Add("@IsShowOnMenu", entity.IsShowOnMenu);
                dynamicParameters.Add("@Description", entity.Description);
                dynamicParameters.Add("@MetaTitle", entity.MetaTitle);
                dynamicParameters.Add("@MetaKeyWord", entity.MetaKeyWord);
                dynamicParameters.Add("@MetaDiscription", entity.MetaDiscription);
                dynamicParameters.Add("@LongDescription", entity.LongDescription);
                dynamicParameters.Add("@SequenceNo", entity.SequenceNo);
                dynamicParameters.Add("@Season", entity.Season);
                dynamicParameters.Add("@IsActive", entity.IsActive);
                dynamicParameters.Add("@TermsNCondition", entity.TermsNCondition);
                dynamicParameters.Add("@Inclusions", entity.Inclusions);
                dynamicParameters.Add("@Exclusions", entity.Exclusions);
                dynamicParameters.Add("@CancellationPolicy", entity.CancellationPolicy);
                dynamicParameters.Add("@UpdatedBy", entity.UpdatedBy);
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

        #region Delete Sector
        public async Task<ResultModel> DeleteSector(SectorIDEntity entity, string storedProcedure)
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

        #region FindBy ID Sector
        public async Task<SectorViewEntity> FindByIDSector(SectorIDEntity entity, string storedProcedure)
        {
            SectorViewEntity result = new SectorViewEntity();

            try
            {
                Dapper.DefaultTypeMap.MatchNamesWithUnderscores = true;
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@ID", entity.ID);
                dynamicParameters.Add("@OperationType", 4);
                var data = await _dbConnection.QuerySingleOrDefaultAsync<SectorViewEntity>(storedProcedure, dynamicParameters, commandType: CommandType.StoredProcedure);
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

        #region Find All sector
        public async Task<List<SectorViewEntity>> FindAllSector(SectorIDEntity entity, string storedProcedure)
        {
            SectorViewEntity result = new SectorViewEntity();

            try
            {
                Dapper.DefaultTypeMap.MatchNamesWithUnderscores = true;
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@SectorName", entity.SectorName);
                dynamicParameters.Add("@OperationType", 5);
                var data = await _dbConnection.QueryAsync<SectorViewEntity>(storedProcedure, dynamicParameters, commandType: CommandType.StoredProcedure);
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

        #region Find All Active sector
        public async Task<List<SectorViewEntity>> FindAllActiveSector(string storedProcedure)
        {
            SectorViewEntity result = new SectorViewEntity();

            try
            {
                Dapper.DefaultTypeMap.MatchNamesWithUnderscores = true;
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@OperationType", 6);
                var data = await _dbConnection.QueryAsync<SectorViewEntity>(storedProcedure, dynamicParameters, commandType: CommandType.StoredProcedure);
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

        #region Active InActive sector
        public async Task<ResultModel> ActiveInActiveSector(SectorIDEntity entity, string storedProcedure)
        {
            ResultModel result = new ResultModel();

            try
            {
                Dapper.DefaultTypeMap.MatchNamesWithUnderscores = true;
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@ID", entity.ID);
                dynamicParameters.Add("@IsActive", entity.IsActive);
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

        #region Find All city by sector
        public async Task<List<CityListBySectorID>> FindCityBySectorID(SectorIDEntity entity, string storedProcedure)
        {
            CityListBySectorID result = new CityListBySectorID();

            try
            {
                Dapper.DefaultTypeMap.MatchNamesWithUnderscores = true;
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@ID", entity.ID);
                dynamicParameters.Add("@OperationType", 8);
                var data = await _dbConnection.QueryAsync<CityListBySectorID>(storedProcedure, dynamicParameters, commandType: CommandType.StoredProcedure);
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

        #region SectorShowOnMenu
        public async Task<List<SectorViewEntity>> SectorShowOnMenu(string storedProcedure)
        {
            SectorViewEntity result = new SectorViewEntity();

            try
            {
                Dapper.DefaultTypeMap.MatchNamesWithUnderscores = true;
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@OperationType", 9);
                var data = await _dbConnection.QueryAsync<SectorViewEntity>(storedProcedure, dynamicParameters, commandType: CommandType.StoredProcedure);
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

        #region SectorShowOnHome
        public async Task<List<SectorViewEntity>> SectorShowOnHome(string storedProcedure)
        {
            SectorViewEntity result = new SectorViewEntity();

            try
            {
                Dapper.DefaultTypeMap.MatchNamesWithUnderscores = true;
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@OperationType", 10);
                var data = await _dbConnection.QueryAsync<SectorViewEntity>(storedProcedure, dynamicParameters, commandType: CommandType.StoredProcedure);
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

        #region Sector Image Update
        public async Task<ResultModel> SectorImageUpdate(string? SectorImage, string? BannerImage, string? HomeImage, int? ID, int? UpdatedBy, string storedProcedure)
        {
            ResultModel result = new ResultModel();
            try
            {
                Dapper.DefaultTypeMap.MatchNamesWithUnderscores = true;
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@ID", ID);
                dynamicParameters.Add("@SectorImage", SectorImage);
                dynamicParameters.Add("@BannerImage", BannerImage);
                dynamicParameters.Add("@HomeImage", HomeImage);
                dynamicParameters.Add("@UpdatedBy", UpdatedBy);
                dynamicParameters.Add("@OperationType", 11);

                var data = await _dbConnection.QueryAsync(storedProcedure, dynamicParameters, commandType: System.Data.CommandType.StoredProcedure);


                result.Message = data.FirstOrDefault().Message;
                result.Details = data.FirstOrDefault().Details;
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

        #region Find All Active sector Incremental Search
        public async Task<List<SectorViewEntity>> FindAllSectorIncrementalSearch(SectorIDEntity entity, string storedProcedure)
        {
            SectorViewEntity result = new SectorViewEntity();

            try
            {
                Dapper.DefaultTypeMap.MatchNamesWithUnderscores = true;
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@SectorName", entity.SectorName);
                dynamicParameters.Add("@OperationType", 1);
                var data = await _dbConnection.QueryAsync<SectorViewEntity>(storedProcedure, dynamicParameters, commandType: CommandType.StoredProcedure);
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

        #region Find All sector Type Wise Sector
        public async Task<List<SectorViewEntity>> FindAllSectorTypeWiseSector(SectorIDEntity entity, string storedProcedure)
        {
            SectorViewEntity result = new SectorViewEntity();

            try
            {
                Dapper.DefaultTypeMap.MatchNamesWithUnderscores = true;
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@SectorType", entity.SectorType);
                dynamicParameters.Add("@OperationType", 1);
                var data = await _dbConnection.QueryAsync<SectorViewEntity>(storedProcedure, dynamicParameters, commandType: CommandType.StoredProcedure);
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
