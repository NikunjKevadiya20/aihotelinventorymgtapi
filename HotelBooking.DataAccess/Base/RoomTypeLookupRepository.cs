using Dapper;
using HotelBooking.Entity.Common;
using HotelBooking.Entity.Common.Entities;
using HotelBooking.Entity.Common.Enums;
using HotelBooking.Entity.Entities;
using Microsoft.Extensions.Logging;
using System.Data;
using System.Data.SqlClient;

namespace HotelBooking.DataAccess.Base
{
    public class RoomTypeLookupRepository : IRoomTypeLookupRepositoryInterface
    {
        #region Global Variables
        private readonly IDbConnection _dbConnection;
        #endregion


        private readonly ILogger<RoomTypeLookupRepository> logger;
        public RoomTypeLookupRepository(ILogger<RoomTypeLookupRepository> _logger, IDbConnection dbConnection)
        {
            logger = _logger;
            _dbConnection = dbConnection;
        }

        #region Insert RoomType
        public async Task<ResultModel> InsertRoomType(RoomTypeDataEntity entity, string storedProcedure)
        {
            ResultModel result = new ResultModel();

            try
            {
                Dapper.DefaultTypeMap.MatchNamesWithUnderscores = true;
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@AmenitiesIDs", entity.AmenitiesIDs);
                dynamicParameters.Add("@RoomType", entity.RoomType);
                dynamicParameters.Add("@Prefix", entity.Prefix);
                dynamicParameters.Add("@MaxGuest", entity.MaxGuest);
                dynamicParameters.Add("@RoomArea", entity.RoomArea);
                dynamicParameters.Add("@BedType", entity.BedType);
                dynamicParameters.Add("@Description", entity.Description);
                dynamicParameters.Add("@Amenities", entity.Amenities);
                dynamicParameters.Add("@IsActive", entity.IsActive);
                dynamicParameters.Add("@CreatedBy", entity.CreatedBy);
                dynamicParameters.Add("@OperationType", CommonRepositoryConstants.Insert);
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

        #region Update RoomType
        public async Task<ResultModel> UpdateRoomType(RoomTypeDataEntity entity, string storedProcedure)
        {
            ResultModel result = new ResultModel();

            try
            {
                Dapper.DefaultTypeMap.MatchNamesWithUnderscores = true;
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@ID", entity.ID);
                dynamicParameters.Add("@AmenitiesIDs", entity.AmenitiesIDs);
                dynamicParameters.Add("@RoomType", entity.RoomType);
                dynamicParameters.Add("@Prefix", entity.Prefix);
                dynamicParameters.Add("@MaxGuest", entity.MaxGuest);
                dynamicParameters.Add("@RoomArea", entity.RoomArea);
                dynamicParameters.Add("@BedType", entity.BedType);
                dynamicParameters.Add("@Description", entity.Description);
                dynamicParameters.Add("@Amenities", entity.Amenities);
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

        #region Delete RoomType
        public async Task<ResultModel> DeleteRoomType(RoomTypeIDEntity entity, string storedProcedure)
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

        #region FindBy ID RoomType

        public async Task<RoomTypeViewEntity> FindByIDRoomType(
            RoomTypeIDEntity entity,
            string storedProcedure)
        {
            RoomTypeViewEntity result = new RoomTypeViewEntity();

            try
            {
                Dapper.DefaultTypeMap.MatchNamesWithUnderscores = true;

                DynamicParameters dynamicParameters = new DynamicParameters();

                dynamicParameters.Add("@ID", entity.ID);
                dynamicParameters.Add("@OperationType", 4);

                using var multi = await _dbConnection.QueryMultipleAsync(
                    storedProcedure,
                    dynamicParameters,
                    commandType: CommandType.StoredProcedure);

                // Result Set 1 : Room Type
                var roomType = await multi.ReadSingleOrDefaultAsync<RoomTypeViewEntity>();

                if (roomType != null)
                {
                    // Result Set 2 : Multiple Images
                    var imageList = (await multi
                        .ReadAsync<RoomTypeImageViewEntity>())
                        .ToList();

                    roomType.ImageList = imageList;

                    return roomType;
                }

                result.Status = (int)ResponseStatusCode.NotFound;
                result.Message = CommonRepositoryMessages.CannotFindAllMessage;
                result.Details = CommonRepositoryMessages.CannotFindAllDetails;

                return result;
            }
            catch (SqlException ex)
            {
                logger.LogError(ex, ex.Message);

                result.ErrorMessage = ex.Message;
                result.Status = (int)ResponseStatusCode.InternaServerError;
                result.Message = CommonRepositoryMessages.CannotFindAllMessage;
                result.Details = CommonRepositoryMessages.CannotFindAllDetails;
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.Message);

                result.Status = (int)ResponseStatusCode.InternaServerError;
                result.Message = CommonRepositoryMessages.ExceptionMessage;
                result.ErrorMessage = ex.Message;
            }

            return result;
        }

        #endregion

        #region Find All   RoomType
        public async Task<List<RoomTypeViewEntity>> FindAllRoomType(RoomTypeIDEntity entity, string storedProcedure)
        {
            RoomTypeViewEntity result = new RoomTypeViewEntity();

            try
            {
                Dapper.DefaultTypeMap.MatchNamesWithUnderscores = true;
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@RoomType", entity.RoomType);
                dynamicParameters.Add("@OperationType", 5);
                var data = await _dbConnection.QueryAsync<RoomTypeViewEntity>(storedProcedure, dynamicParameters, commandType: CommandType.StoredProcedure);
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

        #region Find All Active RoomType
        public async Task<List<RoomTypeViewEntity>> FindAllActiveRoomType(string storedProcedure)
        {
            RoomTypeViewEntity result = new RoomTypeViewEntity();

            try
            {
                Dapper.DefaultTypeMap.MatchNamesWithUnderscores = true;
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@OperationType", 6);
                var data = await _dbConnection.QueryAsync<RoomTypeViewEntity>(storedProcedure, dynamicParameters, commandType: CommandType.StoredProcedure);
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

        #region Active InActive RoomType
        public async Task<ResultModel> ActiveInActiveRoomType(RoomTypeIDEntity entity, string storedProcedure)
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

        #region Room Type Image Upload

        public async Task<ResultModel> RoomTypeImageUpload(
            string? image,
            List<string> imageList,
            int? roomTypeID,
            int? updatedBy)
        {
            ResultModel result = new ResultModel();

            try
            {
                // -----------------------------------------
                // Validation
                // -----------------------------------------
                if (roomTypeID == null || roomTypeID <= 0)
                {
                    result.Status = (int)ResponseStatusCode.NotFound;
                    result.Message = "failure";
                    result.Details = "Invalid RoomTypeID.";
                    return result;
                }

                // -----------------------------------------
                // Main Image
                // -----------------------------------------
                if (!string.IsNullOrWhiteSpace(image))
                {
                    DynamicParameters parameters = new DynamicParameters();

                    parameters.Add(
                        "@RoomTypeID",
                        roomTypeID.Value,
                        DbType.Int32);

                    parameters.Add(
                        "@Image",
                        image,
                        DbType.String);

                    parameters.Add(
                        "@ImageList",
                        null,
                        DbType.String);

                    parameters.Add(
                        "@UpdatedBy",
                        updatedBy ?? 1,
                        DbType.Int32);

                    parameters.Add(
                        "@OperationType",
                        2,
                        DbType.Int32);

                    var mainImageResult =
                        await _dbConnection.QueryFirstOrDefaultAsync<ResultModel>(
                            "dbo.sp_ManageRoomTypeImages",
                            parameters,
                            commandType: CommandType.StoredProcedure);

                    if (mainImageResult != null)
                    {
                        result.Message = mainImageResult.Message;
                        result.Details = mainImageResult.Details;
                    }
                }

                // -----------------------------------------
                // Multiple Images
                // -----------------------------------------
                if (imageList != null && imageList.Count > 0)
                {
                    foreach (string img in imageList)
                    {
                        if (string.IsNullOrWhiteSpace(img))
                            continue;

                        DynamicParameters parameters = new DynamicParameters();

                        parameters.Add(
                            "@RoomTypeID",
                            roomTypeID.Value,
                            DbType.Int32);

                        parameters.Add(
                            "@Image",
                            null,
                            DbType.String);

                        parameters.Add(
                            "@ImageList",
                            img,
                            DbType.String);

                        parameters.Add(
                            "@UpdatedBy",
                            updatedBy ?? 1,
                            DbType.Int32);

                        parameters.Add(
                            "@OperationType",
                            2,
                            DbType.Int32);

                        var imageResult =
                            await _dbConnection.QueryFirstOrDefaultAsync<ResultModel>(
                                "dbo.sp_ManageRoomTypeImages",
                                parameters,
                                commandType: CommandType.StoredProcedure);

                        if (imageResult != null)
                        {
                            result.Message = imageResult.Message;
                            result.Details = imageResult.Details;
                        }
                    }
                }

                result.Status = (int)ResponseStatusCode.Success;

                if (string.IsNullOrEmpty(result.Message))
                {
                    result.Message = "success";
                    result.Details = "Room Type Images uploaded successfully.";
                }
            }
            catch (SqlException ex)
            {
                logger.LogError(
                    ex,
                    "RoomTypeImageUpload SQL Error. RoomTypeID: {RoomTypeID}",
                    roomTypeID);

                result.Status =
                    (int)ResponseStatusCode.InternaServerError;

                result.Message =
                    CommonRepositoryMessages.CannotFindAllMessage;

                result.Details =
                    CommonRepositoryMessages.CannotFindAllDetails;

                result.ErrorMessage = ex.Message;
            }
            catch (Exception ex)
            {
                logger.LogError(
                    ex,
                    "RoomTypeImageUpload Error. RoomTypeID: {RoomTypeID}",
                    roomTypeID);

                result.Status =
                    (int)ResponseStatusCode.InternaServerError;

                result.Message =
                    CommonRepositoryMessages.ExceptionMessage;

                result.ErrorMessage = ex.Message;
            }

            return result;
        }

        #endregion

        #region Delete Image
        public async Task<ResultModel> DeleteImage(DeleteImageEntity entity, string storedProcedure)
        {
            ResultModel result = new ResultModel();

            try
            {
                Dapper.DefaultTypeMap.MatchNamesWithUnderscores = true;
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@RoomTypeID", entity.RoomTypeID);
                dynamicParameters.Add("@operationtype", CommonRepositoryConstants.HardDelete);
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
