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
    public class HotelRoomcatgeoryLookupRepository : IHotelRoomcatgeoryLookupRepositoryInterface
    {

        #region Global Variables
        private readonly IDbConnection _dbConnection;
        #endregion


        private readonly ILogger<HotelRoomcatgeoryLookupRepository> logger;

        public HotelRoomcatgeoryLookupRepository(ILogger<HotelRoomcatgeoryLookupRepository> _logger, IDbConnection dbConnection)
        {
            logger = _logger;
            _dbConnection = dbConnection;
        }

        #region Insert HotelRoomcatgeory
        public async Task<ResultModel> InsertHotelRoomcatgeory(HotelRoomcatgeoryDataEntity entity, List<string>? otherImages, string storedProcedure)
        {
            ResultModel result = new ResultModel();

            try
            {
                Dapper.DefaultTypeMap.MatchNamesWithUnderscores = true;
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@HotelID", entity.HotelID);
                dynamicParameters.Add("@RoomCategoryName", entity.RoomCategoryName);
                dynamicParameters.Add("@MaxAdultCount", entity.MaxAdultCount);
                dynamicParameters.Add("@MinAdultCount", entity.MinAdultCount);
                dynamicParameters.Add("@CNBCount", entity.CNBCount);
                dynamicParameters.Add("@CWBCount", entity.CWBCount);
                dynamicParameters.Add("@IsActive", entity.IsActive);
                dynamicParameters.Add("@CreatedBy", entity.CreatedBy);
                dynamicParameters.Add("@OperationType", 16);

                var data = await _dbConnection.QueryFirstOrDefaultAsync<dynamic>(
                storedProcedure,
                dynamicParameters,
                commandType: CommandType.StoredProcedure
                );

                int roomCategoryID = Convert.ToInt32(data.RoomCategoryID);


                if (otherImages?.Count > 0)
                {
                    foreach (var image in otherImages)
                    {
                        if (string.IsNullOrWhiteSpace(image)) continue;

                        DynamicParameters imgParams = new DynamicParameters();
                        imgParams.Add("@RoomCategoryID", roomCategoryID); 
                        imgParams.Add("@OtherImage", image);
                        imgParams.Add("@OperationType", 2);

                        await _dbConnection.ExecuteAsync(
                            storedProcedure,
                            imgParams,
                            commandType: CommandType.StoredProcedure
                        );
                    }
                }
                result.Message = data.Message;
                result.Details = data.Details;

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

        #region Update HotelRoomcatgeory
        public async Task<ResultModel> UpdateHotelRoomcatgeory(HotelRoomcatgeoryDataEntity entity, List<string>? otherImages, string storedProcedure)
        {
            ResultModel result = new ResultModel();

            try
            {
                Dapper.DefaultTypeMap.MatchNamesWithUnderscores = true;
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@ID", entity.ID);
                dynamicParameters.Add("@HotelID", entity.HotelID);
                dynamicParameters.Add("@RoomCategoryName", entity.RoomCategoryName);
                dynamicParameters.Add("@MaxAdultCount", entity.MaxAdultCount);
                dynamicParameters.Add("@MinAdultCount", entity.MinAdultCount);
                dynamicParameters.Add("@CNBCount", entity.CNBCount);
                dynamicParameters.Add("@CWBCount", entity.CWBCount);
                dynamicParameters.Add("@IsActive", entity.IsActive);
                dynamicParameters.Add("@UpdatedBy", entity.UpdatedBy);
                dynamicParameters.Add("@OperationType", 17);

                var data = await _dbConnection.QueryFirstOrDefaultAsync<dynamic>(
                storedProcedure,
                dynamicParameters,
                commandType: CommandType.StoredProcedure
                );
                    
                int? roomCategoryID = entity.ID;

                    if (otherImages?.Count > 0)
                {
                    foreach (var image in otherImages)
                    {
                        if (string.IsNullOrWhiteSpace(image)) continue;

                        DynamicParameters imgParams = new DynamicParameters();
                        imgParams.Add("@RoomCategoryID", roomCategoryID); 
                        imgParams.Add("@OtherImage", image);
                        imgParams.Add("@OperationType", 2);

                        await _dbConnection.ExecuteAsync(
                            storedProcedure,
                            imgParams,
                            commandType: CommandType.StoredProcedure
                        );
                    }
                }
                result.Message = data.Message;
                result.Details = data.Details;

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

        #region Delete HotelRoomcatgeory
        public async Task<ResultModel> DeleteHotelRoomcatgeory(HotelRoomcatgeoryIDEntity entity, string storedProcedure)
        {
            ResultModel result = new ResultModel();

            try
            {
                Dapper.DefaultTypeMap.MatchNamesWithUnderscores = true;
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@ID", entity.ID);
                dynamicParameters.Add("@OperationType", 18);
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

        #region Find By ID HotelRoomcatgeory
        public async Task<HotelRoomcatgeoryViewEntity> FindByIDHotelRoomcatgeory(HotelRoomcatgeoryIDEntity entity, string storedProcedure)
        {
            HotelRoomcatgeoryViewEntity result = new HotelRoomcatgeoryViewEntity();

            try
            {
                Dapper.DefaultTypeMap.MatchNamesWithUnderscores = true;
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@ID", entity.ID);
                dynamicParameters.Add("@OperationType", 19);
                var data = await _dbConnection.QueryFirstOrDefaultAsync<HotelRoomcatgeoryViewEntity>(storedProcedure, dynamicParameters, commandType: CommandType.StoredProcedure);

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

        #region Find By HotelID HotelRoomcatgeory
        public async Task<List<HotelRoomcatgeoryViewEntity>> FindByHotelIDHotelRoomcatgeory(
        HotelRoomcatgeoryIDEntity entity,
        string storedProcedure)
        {
            try
            {
                Dapper.DefaultTypeMap.MatchNamesWithUnderscores = true;

                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@HotelID", entity.HotelID);
                dynamicParameters.Add("@OperationType", 20);

                var multi = await _dbConnection.QueryMultipleAsync(
                    storedProcedure,
                    dynamicParameters,
                    commandType: CommandType.StoredProcedure
                );

                var hotelData = (await multi.ReadAsync<HotelRoomcatgeoryViewEntity>())?.ToList()
                                ?? new List<HotelRoomcatgeoryViewEntity>();

                var imageData = (await multi.ReadAsync<HotelCategoryImage>())?.ToList()
                                ?? new List<HotelCategoryImage>();

                foreach (var room in hotelData)
                {

                    room.Images = new List<HotelCategoryImage>();

                    if (imageData.Count > 0)
                    {
                        room.Images = imageData
                            .Where(x => x.RoomCategoryID == room.ID)
                            .ToList();
                    }
                }

                return hotelData;
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.Message);
                throw;
            }
        }
        #endregion

        #region Find All HotelRoomcatgeory
        public async Task<List<HotelRoomcatgeoryViewEntity>> FindAllActiveHotelRoomcatgeory(HotelRoomcatgeoryIDEntity entity, string storedProcedure)
        {
            HotelRoomcatgeoryViewEntity result = new HotelRoomcatgeoryViewEntity();

            try
            {
                Dapper.DefaultTypeMap.MatchNamesWithUnderscores = true;
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@HotelID", entity.HotelID);
                dynamicParameters.Add("@OperationType", 21);
                var data = await _dbConnection.QueryAsync<HotelRoomcatgeoryViewEntity>(storedProcedure, dynamicParameters, commandType: CommandType.StoredProcedure);
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

        #region Active InActive HotelRoomcatgeory
        public async Task<ResultModel> ActiveInActiveHotelRoomcatgeory(HotelRoomcatgeoryIDEntity entity, string storedProcedure)
        {
            ResultModel result = new ResultModel();

            try
            {
                Dapper.DefaultTypeMap.MatchNamesWithUnderscores = true;
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@ID", entity.ID);
                dynamicParameters.Add("@IsActive", entity.IsActive);
                dynamicParameters.Add("@OperationType", 25);
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

        #region Room Category ImageUpload

        public async Task<ResultModel> RoomCategoryImageUpload(List<string> otherImages, int? RoomCategoryID)
        {
            ResultModel result = new ResultModel();

            try
            {
                DynamicParameters dynamicParameters = new DynamicParameters();

                dynamicParameters.Add("@RoomCategoryID", RoomCategoryID);
                dynamicParameters.Add("@OtherImage", "");
                dynamicParameters.Add("@OperationType", 2);

                var data = await _dbConnection.QueryFirstOrDefaultAsync<ResultModel>(
                    "sp_ManageHotelRoomCategoriesInsert",
                    dynamicParameters,
                    commandType: CommandType.StoredProcedure
                );

                if (data != null)
                {
                    result.Message = data.Message;
                    result.Details = data.Details;
                    result.Status = (int)ResponseStatusCode.Success;
                }

                if (otherImages != null && otherImages.Count > 0)
                {
                    foreach (var image in otherImages)
                    {
                        DynamicParameters imgParams = new DynamicParameters();

                        imgParams.Add("@RoomCategoryID", RoomCategoryID);
                        imgParams.Add("@OtherImage", image);
                        imgParams.Add("@OperationType", 2);

                        await _dbConnection.ExecuteAsync(
                            "sp_ManageHotelRoomCategoriesInsert",
                            imgParams,
                            commandType: CommandType.StoredProcedure
                        );
                    }
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

        #region Delete RoomCategory Image
        public async Task<ResultModel> DeleteRoomCategoryImage(HotelRoomcatgeoryIDEntity entity, string storedProcedure)
        {
            ResultModel result = new ResultModel();

            try
            {
                Dapper.DefaultTypeMap.MatchNamesWithUnderscores = true;
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@ID", entity.ID);
                dynamicParameters.Add("@OperationType", 4);
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
