using HotelBooking.Entity.Common.Entities;
using HotelBooking.Entity.Common.Enums;
using HotelBooking.Entity.Common;
using HotelBooking.Entity.Entities;
using Dapper;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBooking.DataAccess.Base
{
    public class CMSLookupRepository : ICMSLookupRepositoryInterface
    {
        #region Global Variables
        private readonly IDbConnection _dbConnection;
        #endregion

        private readonly ILogger<CMSLookupRepository> logger;

        public CMSLookupRepository(ILogger<CMSLookupRepository> _logger, IDbConnection dbConnection)
        {
            logger = _logger;
            _dbConnection = dbConnection;
        }

       

        #region Insert CMS
        public async Task<CMSIDViewEntity> InsertCMS(CMSDataEntity entity, string storedProcedure)
        {
            CMSIDViewEntity result = new CMSIDViewEntity();

            try
            {
                
                Dapper.DefaultTypeMap.MatchNamesWithUnderscores = true;
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@Name", entity.Name);
                dynamicParameters.Add("@CMSURL", entity.CMSURL);
                dynamicParameters.Add("@Template", entity.Template);
                dynamicParameters.Add("@MetaTitle", entity.MetaTitle);
                dynamicParameters.Add("@MetaKeyword", entity.MetaKeyword);
                dynamicParameters.Add("@MetaDescription", entity.MetaDescription);
                dynamicParameters.Add("@IsActive", entity.IsActive);
                dynamicParameters.Add("@CreatedBy", entity.CreatedBy);
                dynamicParameters.Add("@OperationType", CommonRepositoryConstants.Insert);

                var data = await _dbConnection.QueryFirstOrDefaultAsync<CMSIDViewEntity>(storedProcedure, dynamicParameters, commandType: CommandType.StoredProcedure);
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

        #region Update CMS
        public async Task<ResultModel> UpdateCMS(CMSDataEntity entity, string storedProcedure)
        {
            ResultModel result = new ResultModel();

            try
            {
                

                Dapper.DefaultTypeMap.MatchNamesWithUnderscores = true;
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@ID", entity.ID);
                dynamicParameters.Add("@Name", entity.Name);
                dynamicParameters.Add("@CMSURL", entity.CMSURL);
                dynamicParameters.Add("@Template", entity.Template);
                dynamicParameters.Add("@MetaTitle", entity.MetaTitle);
                dynamicParameters.Add("@MetaKeyword", entity.MetaKeyword);
                dynamicParameters.Add("@MetaDescription", entity.MetaDescription);
                dynamicParameters.Add("@IsActive", entity.IsActive);
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

        #region Delete CMS
        public async Task<ResultModel> DeleteCMS(CMSIDEntity entity, string storedProcedure)
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


        #region FindBy ID CMS
        //public async Task<CMSViewDataEntity> FindByIDCMS(CMSIDEntity entity, string storedProcedure)
        //{
        //    CMSViewDataEntity result = new CMSViewDataEntity();
        //    try
        //    {

        //        Dapper.DefaultTypeMap.MatchNamesWithUnderscores = true;
        //        DynamicParameters dynamicParameters = new DynamicParameters();
        //        dynamicParameters.Add("@ID", entity.ID);
        //        dynamicParameters.Add("@OperationType", CommonRepositoryConstants.FindByID);

        //        var data = await _dbConnection.QueryMultipleAsync(storedProcedure, dynamicParameters, commandType: CommandType.StoredProcedure);
        //        if (data != null)
        //        {
        //            var CMSData = await data.ReadFirstAsync<CMSViewDataEntity>();
        //            var CMSImage = await data.ReadAsync<CMSImageDataViewEntity>();
        //            result = (CMSViewDataEntity)CMSData;
        //            result.cms_image_details = CMSImage;
        //        }
        //        return result;

        //    }
        //    catch (SqlException sqlException)
        //    {
        //        logger.LogError(sqlException, sqlException.Message);
        //        result.ErrorMessage = sqlException.Message;
        //        result.Status = (int)ResponseStatusCode.InternaServerError;
        //        result.Message = CommonRepositoryMessages.CannotFindAllMessage;
        //        result.Details = CommonRepositoryMessages.CannotFindAllDetails;
        //        throw;
        //    }
        //    catch (Exception ex)
        //    {
        //        result.Status = (int)ResponseStatusCode.InternaServerError;
        //        result.Message = CommonRepositoryMessages.ExceptionMessage;
        //        result.ErrorMessage = ex.Message;
        //        throw;
        //    }
        //    finally
        //    {

        //    }
        //}
        public async Task<CMSViewDataEntity> FindByIDCMS(CMSIDEntity entity, string storedProcedure)
        {
            BannerDataViewEntity result = new BannerDataViewEntity();

            try
            {
                Dapper.DefaultTypeMap.MatchNamesWithUnderscores = true;
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@ID", entity.ID);
                dynamicParameters.Add("@OperationType", CommonRepositoryConstants.FindByID);
                var data = await _dbConnection.QuerySingleOrDefaultAsync<CMSViewDataEntity>(storedProcedure, dynamicParameters, commandType: CommandType.StoredProcedure);
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

        #region Find All CMS
        public async Task<List<CMSViewDataEntity>> FindAllCMS(CMSIDEntity entity, string storedProcedure)
        {
            CMSViewDataEntity result = new CMSViewDataEntity();
            try
            {
                
                Dapper.DefaultTypeMap.MatchNamesWithUnderscores = true;
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@Name", entity.Name);
                dynamicParameters.Add("@OperationType", CommonRepositoryConstants.FindAllItems);
                var data = await _dbConnection.QueryAsync<CMSViewDataEntity>(storedProcedure, dynamicParameters, commandType: CommandType.StoredProcedure);
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

        #region Find All Active CMS
        public async Task<List<CMSViewDataEntity>> FindAllActiveCMS(string storedProcedure)
        {
            CMSViewDataEntity result = new CMSViewDataEntity();
            try
            {
                
                Dapper.DefaultTypeMap.MatchNamesWithUnderscores = true;
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@OperationType", 5);
                var data = await _dbConnection.QueryAsync<CMSViewDataEntity>(storedProcedure, dynamicParameters, commandType: CommandType.StoredProcedure);
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

        #region Active InActive CMS
        public async Task<ResultModel> ActiveInActiveCMS(CMSIDEntity entity, string storedProcedure)
        {
            ResultModel result = new ResultModel();
            try
            {
               
                Dapper.DefaultTypeMap.MatchNamesWithUnderscores = true;
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@ID", entity.ID);
                dynamicParameters.Add("@IsActive", entity.IsActive);
                dynamicParameters.Add("@OperationType", CommonRepositoryConstants.UpdateActive);
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



        #region CMS Image Update
        public async Task<ResultModel> CMSImageUpdate(string? physicalFileName, string? CMSImageAlterTag, int? ID, int? UpdatedBy, string storedProcedure)
        {
            ResultModel result = new ResultModel();
            try
            {
                Dapper.DefaultTypeMap.MatchNamesWithUnderscores = true;
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@ID", ID);
                dynamicParameters.Add("@CMSImage", physicalFileName);
                dynamicParameters.Add("@CMSImageAlterTag", CMSImageAlterTag);
                dynamicParameters.Add("@UpdatedBy", UpdatedBy);
                dynamicParameters.Add("@OperationType", 3);

                var data = await _dbConnection.QueryAsync(storedProcedure, dynamicParameters, commandType: System.Data.CommandType.StoredProcedure);

                result.Message = data.FirstOrDefault()?.Message;
                result.Details = data.FirstOrDefault()?.Details;
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



        public async Task<List<CMSViewDataEntity>> FindAllCMSURL(CMSIDEntity entity, string storedProcedure)
        {
            CMSViewDataEntity result = new CMSViewDataEntity();
            try
            {
               
                Dapper.DefaultTypeMap.MatchNamesWithUnderscores = true;
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@CMSURL", entity.CMSURL);
                dynamicParameters.Add("@OperationType", 6);
                var data = await _dbConnection.QueryAsync<CMSViewDataEntity>(storedProcedure, dynamicParameters, commandType: CommandType.StoredProcedure);
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





    }
}
