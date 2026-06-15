using Dapper;
using DapperParameters;
using Microsoft.Extensions.Logging;
using HotelBooking.Entity.Common;
using HotelBooking.Entity.Common.Entities;
using HotelBooking.Entity.Common.Enums;
using HotelBooking.Entity.Entities;
using System.Data;
using System.Data.SqlClient;

namespace HotelBooking.DataAccess.Base                                         
{
    public class AttractionLookupRepository : IAttractionLookupRepositoryInterface
    {
        private readonly IDbConnection _dbConnection;
        private readonly ILogger<AttractionLookupRepository> logger;
      

        public AttractionLookupRepository(ILogger<AttractionLookupRepository> _logger, IDbConnection dbConnection)
        {
            logger = _logger;
            _dbConnection = dbConnection;
        }

        public async Task<AttractionIDEntity> InsertAttraction(AttractionEntity entity, string storedProcedure)
        {
            AttractionIDEntity result = new AttractionIDEntity();
            try
            {
                Dapper.DefaultTypeMap.MatchNamesWithUnderscores = true;
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@PropertyID", entity.PropertyID);                
                dynamicParameters.Add("@Title", entity.Title);                
                dynamicParameters.Add("@AttractionCategory", entity.AttractionCategory);
                dynamicParameters.Add("@TagLine", entity.TagLine);
                dynamicParameters.Add("@Distance", entity.Distance);
                dynamicParameters.Add("@TravelTime", entity.TravelTime);
                dynamicParameters.Add("@BestTime", entity.BestTime);
                dynamicParameters.Add("@Duration", entity.Duration);
                dynamicParameters.Add("@Description", entity.Description);
                dynamicParameters.Add("@Dos", entity.Dos);
                dynamicParameters.Add("@Donts", entity.Donts);
                dynamicParameters.Add("@MainImage", entity.MainImage);
                dynamicParameters.Add("@BannerImage", entity.BannerImage);
                dynamicParameters.Add("@MetaTitle", entity.MetaTitle);
                dynamicParameters.Add("@MetaDescription", entity.MetaDescription);
                dynamicParameters.Add("@MetaKeywords", entity.MetaKeywords);
                dynamicParameters.Add("@IsActive", entity.IsActive);
                dynamicParameters.Add("@IsMustVisit", entity.IsMustVisit);
                dynamicParameters.Add("@AttractionURL", entity.AttractionURL);
                dynamicParameters.Add("@CreatedBy", entity.CreatedBy);                                             
                dynamicParameters.Add("@OperationType", CommonRepositoryConstants.Insert);

                if (entity.BestTimes != null)
                    dynamicParameters.AddTable<AttractionBestTimeEntity>("@UDTT_BestTime", "UDTT_AttractionBestTime", entity.BestTimes);
                if (entity.HowToReach != null)
                    dynamicParameters.AddTable<AttractionHowToReachEntity>("@UDTT_HowToReach", "UDTT_AttractionHowToReach", entity.HowToReach);
                if (entity.ThingsToDo != null)
                    dynamicParameters.AddTable<AttractionThingsToDoEntity>("@UDTT_ThingsToDo", "UDTT_AttractionThingsToDo", entity.ThingsToDo);
                if (entity.WhyVisit != null)
                    dynamicParameters.AddTable<AttractionWhyVisitEntity>("@UDTT_WhyVisit", "UDTT_AttractionWhyVisit", entity.WhyVisit);
                if (entity.Nearby != null)
                    dynamicParameters.AddTable<AttractionNearbyEntity>("@UDTT_Nearby", "UDTT_AttractionNearby", entity.Nearby);

                var data = await _dbConnection.QueryAsync(storedProcedure, dynamicParameters, commandType: CommandType.StoredProcedure);
                result.ID = data.FirstOrDefault().ID;
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
        }

        public async Task<AttractionIDEntity> UpdateAttraction(AttractionEntity entity, string storedProcedure)
        {
            AttractionIDEntity result = new AttractionIDEntity();
            try
            {
                Dapper.DefaultTypeMap.MatchNamesWithUnderscores = true;
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@ID", entity.ID);
                dynamicParameters.Add("@PropertyID", entity.PropertyID);
                dynamicParameters.Add("@Title", entity.Title);                
                dynamicParameters.Add("@AttractionCategory", entity.AttractionCategory);
                dynamicParameters.Add("@TagLine", entity.TagLine);
                dynamicParameters.Add("@Distance", entity.Distance);
                dynamicParameters.Add("@TravelTime", entity.TravelTime);
                dynamicParameters.Add("@BestTime", entity.BestTime);
                dynamicParameters.Add("@Duration", entity.Duration);
                dynamicParameters.Add("@Description", entity.Description);
                dynamicParameters.Add("@Dos", entity.Dos);
                dynamicParameters.Add("@Donts", entity.Donts);
                dynamicParameters.Add("@MainImage", entity.MainImage);
                dynamicParameters.Add("@BannerImage", entity.BannerImage);
                dynamicParameters.Add("@MetaTitle", entity.MetaTitle);
                dynamicParameters.Add("@MetaDescription", entity.MetaDescription);
                dynamicParameters.Add("@MetaKeywords", entity.MetaKeywords);
                dynamicParameters.Add("@IsActive", entity.IsActive);
                dynamicParameters.Add("@IsMustVisit", entity.IsMustVisit);
                dynamicParameters.Add("@AttractionURL", entity.AttractionURL);
                dynamicParameters.Add("@UpdatedBy", entity.UpdatedBy);                
                dynamicParameters.Add("@OperationType", CommonRepositoryConstants.Update);

                if (entity.BestTimes != null)
                    dynamicParameters.AddTable<AttractionBestTimeEntity>("@UDTT_BestTime", "UDTT_AttractionBestTime", entity.BestTimes);
                if (entity.HowToReach != null)
                    dynamicParameters.AddTable<AttractionHowToReachEntity>("@UDTT_HowToReach", "UDTT_AttractionHowToReach", entity.HowToReach);
                if (entity.ThingsToDo != null)
                    dynamicParameters.AddTable<AttractionThingsToDoEntity>("@UDTT_ThingsToDo", "UDTT_AttractionThingsToDo", entity.ThingsToDo);
                if (entity.WhyVisit != null)
                    dynamicParameters.AddTable<AttractionWhyVisitEntity>("@UDTT_WhyVisit", "UDTT_AttractionWhyVisit", entity.WhyVisit);
                if (entity.Nearby != null)
                    dynamicParameters.AddTable<AttractionNearbyEntity>("@UDTT_Nearby", "UDTT_AttractionNearby", entity.Nearby);

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
            return result;
        }

        public async Task<ResultModel> DeleteAttraction(AttractionIDEntity entity, string storedProcedure)
        {
            ResultModel result = new ResultModel();
            try
            {
                Dapper.DefaultTypeMap.MatchNamesWithUnderscores = true;
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@ID", entity.ID);
                dynamicParameters.Add("@OperationType", CommonRepositoryConstants.Delete);
                var data = await _dbConnection.QueryAsync(storedProcedure, dynamicParameters, commandType: CommandType.StoredProcedure);
                var first = data.FirstOrDefault();
                if (first != null)
                {
                    result.Message = first.Message;
                    result.Details = first.Details;
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

        public async Task<AttractionListEntity> FindByIDAttraction(AttractionIDEntity entity, string storedProcedure)
        {
            AttractionListEntity result = new AttractionListEntity();
            try
            {
                Dapper.DefaultTypeMap.MatchNamesWithUnderscores = true;
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@ID", entity.ID);
                dynamicParameters.Add("@OperationType", CommonRepositoryConstants.FindByID);
                var data = await _dbConnection.QueryMultipleAsync(storedProcedure, dynamicParameters, commandType: CommandType.StoredProcedure);

                AttractionListEntity attractionDataViewEntity = await data.ReadFirstOrDefaultAsync<AttractionListEntity>();

                if (attractionDataViewEntity != null)
                {
                    attractionDataViewEntity.BestTimes = (await data.ReadAsync<AttractionBestTimeEntity>()).ToList();
                    attractionDataViewEntity.HowToReach = (await data.ReadAsync<AttractionHowToReachEntity>()).ToList();
                    attractionDataViewEntity.ThingsToDo = (await data.ReadAsync<AttractionThingsToDoEntity>()).ToList();
                    attractionDataViewEntity.WhyVisit = (await data.ReadAsync<AttractionWhyVisitEntity>()).ToList();
                    attractionDataViewEntity.Nearby = (await data.ReadAsync<AttractionNearbyEntityFBI>()).ToList();
                    attractionDataViewEntity.Images = (await data.ReadAsync<AttractionPhotoGalleryEntityFBI>()).ToList();
                }

                return attractionDataViewEntity;
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
        }

        public async Task<List<AttractionDataViewEntity>> FindAllAttraction(AttractionIDEntity entity, string storedProcedure)
        {
            try
            {
                Dapper.DefaultTypeMap.MatchNamesWithUnderscores = true;
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@Title", entity.Title);
                dynamicParameters.Add("@OperationType", CommonRepositoryConstants.FindAllItems);
                var data = await _dbConnection.QueryAsync<AttractionDataViewEntity>(storedProcedure, dynamicParameters, commandType: CommandType.StoredProcedure);
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

        public async Task<List<AttractionDataViewEntity>> FindAllActiveAttraction(string storedProcedure)
        {
            try
            {
                Dapper.DefaultTypeMap.MatchNamesWithUnderscores = true;
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@OperationType", 5);
                var data = await _dbConnection.QueryAsync<AttractionDataViewEntity>(storedProcedure, dynamicParameters, commandType: CommandType.StoredProcedure);
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

        public async Task<ResultModel> ActiveInActiveAttraction(AttractionIDEntity entity, string storedProcedure)
        {
            ResultModel result = new ResultModel();
            try
            {
                Dapper.DefaultTypeMap.MatchNamesWithUnderscores = true;
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@ID", entity.ID);
                dynamicParameters.Add("@IsActive", entity.IsActive);
                dynamicParameters.Add("@OperationType", 4);
                var data = await _dbConnection.QueryAsync(storedProcedure, dynamicParameters, commandType: CommandType.StoredProcedure);
                var first = data.FirstOrDefault();
                if (first != null)
                {
                    result.Message = first.Message;
                    result.Details = first.Details;
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

        public async Task<ResultModel> AttractionImageUpdate(string? MainImage, string? BannerImage, List<AttratcionsDocumentsImage> Documents , int? ID, string? UpdatedBy, string storedProcedure)
        {
            ResultModel result = new ResultModel();
            try
            {
                Dapper.DefaultTypeMap.MatchNamesWithUnderscores = true;
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@ID", ID);
                dynamicParameters.Add("@MainImage", MainImage);
                dynamicParameters.Add("@BannerImage", BannerImage);
                dynamicParameters.AddTable("@UDTT_DocumentsImage", "UDTT_AttractionsDocumentsImage", Documents.ToList());
                dynamicParameters.Add("@UpdatedBy", UpdatedBy);
                dynamicParameters.Add("@OperationType", 3);


                var data = await _dbConnection.QueryAsync(storedProcedure, dynamicParameters, commandType: CommandType.StoredProcedure);
                
                var first = data.FirstOrDefault();
                
                if (first != null)
                {
                    result.Message = first.Message;
                    result.Details = first.Details;
                }
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
        }

        public async Task<AttractionListEntity> AttractionFindByURL(AttractionIDEntity entity, string storedProcedure)
        {
            AttractionListEntity result = new AttractionListEntity();
            try
            {
                Dapper.DefaultTypeMap.MatchNamesWithUnderscores = true;
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@AttractionURL", entity.AttractionURL);
                dynamicParameters.Add("@OperationType", 6);
                var data = await _dbConnection.QueryMultipleAsync(storedProcedure, dynamicParameters, commandType: CommandType.StoredProcedure);

                AttractionListEntity attractionDataViewEntity = await data.ReadFirstOrDefaultAsync<AttractionListEntity>();

                if (attractionDataViewEntity != null)
                {
                    attractionDataViewEntity.BestTimes = (await data.ReadAsync<AttractionBestTimeEntity>()).ToList();
                    attractionDataViewEntity.HowToReach = (await data.ReadAsync<AttractionHowToReachEntity>()).ToList();
                    attractionDataViewEntity.ThingsToDo = (await data.ReadAsync<AttractionThingsToDoEntity>()).ToList();
                    attractionDataViewEntity.WhyVisit = (await data.ReadAsync<AttractionWhyVisitEntity>()).ToList();
                    attractionDataViewEntity.Nearby = (await data.ReadAsync<AttractionNearbyEntityFBI>()).ToList();
                    attractionDataViewEntity.Images = (await data.ReadAsync<AttractionPhotoGalleryEntityFBI>()).ToList();

                }

                return attractionDataViewEntity;
            }
            catch (SqlException sqlException)
            {
                logger.LogError(sqlException, sqlException.Message);
                result.Message = CommonRepositoryMessages.CannotFindAllMessage;
                result.Details = CommonRepositoryMessages.CannotFindAllDetails;
                throw;
            }
            catch (Exception ex)
            {
                result.Message = CommonRepositoryMessages.ExceptionMessage;
                throw;
            }
            finally
            {
                
            }
        }
        public async Task<ResultModel> DeleteAttractionImages(AttractionIDEntity entity, string storedProcedure)
        {
            ResultModel result = new ResultModel();
            try
            {
                Dapper.DefaultTypeMap.MatchNamesWithUnderscores = true;
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@ID", entity.ID);
                dynamicParameters.Add("@OperationType", 4);
                var data = await _dbConnection.QueryAsync(storedProcedure, dynamicParameters, commandType: CommandType.StoredProcedure);
                var first = data.FirstOrDefault();
                if (first != null)
                {
                    result.Message = first.Message;
                    result.Details = first.Details;
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
    }
}
