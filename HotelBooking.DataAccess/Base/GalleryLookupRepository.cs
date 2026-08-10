using HotelBooking.Entity.Entities;
using HotelBooking.DataAccess.Base;
using HotelBooking.Entity.Common;
using HotelBooking.Entity.Common.Entities;
using HotelBooking.Entity.Common.Enums;
using Dapper;
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
    public class GalleryLookupRepository : IGalleryLookupRepositoryInterface
    {
        #region Global Variables
        private readonly IDbConnection _dbConnection;
        private readonly ILogger<GalleryLookupRepository> logger;
        #endregion

        public GalleryLookupRepository(ILogger<GalleryLookupRepository> _logger, IDbConnection dbConnection)
        {
            logger = _logger;
            _dbConnection = dbConnection;
        }


        #region Create or Update Gallery (Insert/Update)
        public async Task<ResultModel> CreateOrUpdateGallery(GalleryEntity entity, string storedProcedure)
        {
            ResultModel result = new ResultModel();

            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@ID", entity.ID);
                parameters.Add("@Image", entity.Image);
                parameters.Add("@ImgAlt", entity.ImgAlt);
                parameters.Add("@IsshowHome", entity.IsshowHome);
                parameters.Add("@GroupName", entity.GroupName);
                parameters.Add("@GalleryTypeID", entity.GalleryTypeID);
                parameters.Add("@IsCuision", entity.IsCuision);
                parameters.Add("@CreatedBy", entity.CreatedBy);
                parameters.Add("@UpdatedBy", entity.UpdatedBy);
                parameters.Add("@OperationType", CommonRepositoryConstants.Update);

                var data = await _dbConnection.QueryAsync(storedProcedure, parameters, commandType: CommandType.StoredProcedure);

                if (data != null && data.Any())
                {
                    result.Message = data.FirstOrDefault().Message;
                    result.Details = data.FirstOrDefault().Details;
                }
                else
                {
                    result.Message = CommonRepositoryMessages.CannotInsertMessage;
                    result.Details = CommonRepositoryMessages.CannotInsertDetails;
                }

                return result;
            }
            catch (SqlException sqlException)
            {
                logger.LogError(sqlException, sqlException.Message);
                result.ErrorMessage = sqlException.Message;
                result.Status = (int)ResponseStatusCode.InternaServerError;
                result.Message = CommonRepositoryMessages.CannotInsertMessage;
                result.Details = CommonRepositoryMessages.CannotInsertDetails;
                throw;
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.Message);
                result.Status = (int)ResponseStatusCode.InternaServerError;
                result.Message = CommonRepositoryMessages.ExceptionMessage;
                result.ErrorMessage = ex.Message;
                throw;
            }
        }
        #endregion


        #region Delete Gallery
        public async Task<ResultModel> DeleteGallery(GalleryIDEntity entity, string storedProcedure)
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
                return result;
            }
            catch (SqlException sqlException)
            {
                logger.LogError(sqlException, sqlException.Message);
                result.ErrorMessage = sqlException.Message;
                result.Status = (int)ResponseStatusCode.InternaServerError;
                result.Message = CommonRepositoryMessages.CannotDeleteMessage;
                result.Details = CommonRepositoryMessages.CannotDeleteDetails;
                throw;
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.Message);
                result.Status = (int)ResponseStatusCode.InternaServerError;
                result.Message = CommonRepositoryMessages.ExceptionMessage;
                result.ErrorMessage = ex.Message;
                throw;
            }
        }
        #endregion

        #region FindByID Gallery
        public async Task<GalleryDataViewEntity> FindByIDGallery(GalleryIDEntity entity, string storedProcedure)
        {
            GalleryDataViewEntity result = new GalleryDataViewEntity();

            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@ID", entity.ID);
                parameters.Add("@OperationType", CommonRepositoryConstants.FindByID);

                var data = await _dbConnection.QuerySingleOrDefaultAsync<GalleryDataViewEntity>(
                    storedProcedure, parameters, commandType: CommandType.StoredProcedure);
                return data;
            }
            catch (SqlException sqlException)
            {
                logger.LogError(sqlException, sqlException.Message);
                result.ErrorMessage = sqlException.Message;
                result.Status = (int)ResponseStatusCode.InternaServerError;
                result.Message = "can not find Message";
                result.Details = "can not find Details";
                throw;
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.Message);
                result.Status = (int)ResponseStatusCode.InternaServerError;
                result.Message = CommonRepositoryMessages.ExceptionMessage;
                result.ErrorMessage = ex.Message;
                throw;
            }
        }
        #endregion

        #region FindAll Gallery
        public async Task<List<GalleryDataViewEntity>> FindAllGallery(string storedProcedure)
        {
            GalleryDataViewEntity result = new GalleryDataViewEntity();

            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@OperationType", CommonRepositoryConstants.FindAllItems);

                var data = await _dbConnection.QueryAsync<GalleryDataViewEntity>(
                    storedProcedure, parameters, commandType: CommandType.StoredProcedure);
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
                logger.LogError(ex, ex.Message);
                result.Status = (int)ResponseStatusCode.InternaServerError;
                result.Message = CommonRepositoryMessages.ExceptionMessage;
                result.ErrorMessage = ex.Message;
                throw;
            }
        }
        #endregion

        #region FindAllActive Gallery
        public async Task<List<GalleryGroupViewEntity>> FindAllActiveGallery(string storedProcedure)
        {
            GalleryDataViewEntity result = new GalleryDataViewEntity();

            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@OperationType", 5);

                var data = await _dbConnection.QueryAsync<GalleryDataViewEntity>(
                    storedProcedure, parameters, commandType: CommandType.StoredProcedure);
                var groupedData = data
       .GroupBy(x => x.GroupName)
       .Select(g => new GalleryGroupViewEntity
       {
           GroupName = g.Key,
           Images = g.ToList()
       })
       .ToList();

                return groupedData;
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
                logger.LogError(ex, ex.Message);
                result.Status = (int)ResponseStatusCode.InternaServerError;
                result.Message = CommonRepositoryMessages.ExceptionMessage;
                result.ErrorMessage = ex.Message;
                throw;
            }
        }
        #endregion

        #region Active / Inactive Gallery
        public async Task<ResultModel> ActiveInActiveGallery(GalleryIDEntity entity, string storedProcedure)
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

                return result;
            }
            catch (SqlException sqlException)
            {
                logger.LogError(sqlException, sqlException.Message);
                result.ErrorMessage = sqlException.Message;
                result.Status = (int)ResponseStatusCode.InternaServerError;
                result.Message = CommonRepositoryMessages.CannotUpdateMessage;
                result.Details = CommonRepositoryMessages.CannotUpdateDetails;
                throw;
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.Message);
                result.Status = (int)ResponseStatusCode.InternaServerError;
                result.Message = CommonRepositoryMessages.ExceptionMessage;
                result.ErrorMessage = ex.Message;
                throw;
            }
        }
        #endregion

        public async Task<List<GalleryGroupViewEntity>> FindAllGalleryWiseGroupName(string storedProcedure)
        {
            GalleryDataViewEntity result = new GalleryDataViewEntity();

            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@OperationType", 6);

                var data = await _dbConnection.QueryAsync<GalleryDataViewEntity>(
                    storedProcedure, parameters, commandType: CommandType.StoredProcedure);
                var groupedData = data
          .GroupBy(x => x.GroupName)
          .Select(g => new GalleryGroupViewEntity
          {
              GroupName = g.Key,
              Images = g.ToList()
          })
          .ToList();

                return groupedData;
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
                logger.LogError(ex, ex.Message);
                result.Status = (int)ResponseStatusCode.InternaServerError;
                result.Message = CommonRepositoryMessages.ExceptionMessage;
                result.ErrorMessage = ex.Message;
                throw;
            }
        }


        public async Task<GalleryVideoGalleryData> ListGalleryVideoGallery(string storedProcedure)
        {
            GalleryVideoGalleryData result = new GalleryVideoGalleryData();

            try
            {
                Dapper.DefaultTypeMap.MatchNamesWithUnderscores = true;
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@OperationType", 7);
                var data = await _dbConnection.QueryMultipleAsync(storedProcedure, dynamicParameters, commandType: CommandType.StoredProcedure);


                var Gallery = (await data.ReadAsync<GalleryData>()).ToList();
                result.Gallery = Gallery;


                if (Gallery.Any())
                {
                    result.Message = Gallery.First().Message;
                    result.Details = Gallery.First().Details;
                }
                var VideoGallery = (await data.ReadAsync<VideoGalleryData>()).ToList();
                result.VideoGallery = VideoGallery;
              


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
            return result;

        }
    }
}
