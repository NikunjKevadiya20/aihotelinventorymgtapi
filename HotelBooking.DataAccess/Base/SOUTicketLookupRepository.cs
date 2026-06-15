using Dapper;
using DapperParameters;
using Microsoft.Extensions.Logging;
using HotelBooking.Entity.Common;
using HotelBooking.Entity.Common.Entities;
using HotelBooking.Entity.Common.Enums;
using HotelBooking.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Dapper.SqlMapper;
using static System.Net.Mime.MediaTypeNames;

namespace HotelBooking.DataAccess.Base
{
    public class HotelBookingTicketLookupRepository : IHotelBookingTicketLookupRepositoryInterface
    {

        #region Global Variables
        private readonly IDbConnection _dbConnection;
        private readonly ILogger<HotelBookingTicketLookupRepository> logger;
        #endregion

        public HotelBookingTicketLookupRepository(ILogger<HotelBookingTicketLookupRepository> _logger, IDbConnection dbConnection)
        {
            logger = _logger;
            _dbConnection = dbConnection;
        }


        #region Insert HotelBookingTicket
        public async Task<ResultModel> InsertHotelBookingTicket(HotelBookingTicketEntity entity, string storedProcedure)
        {
            ResultModel result = new ResultModel();

            try
            {
                Dapper.DefaultTypeMap.MatchNamesWithUnderscores = true;
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@Title", entity.Title);
                dynamicParameters.Add("@Timing", entity.Timing);
                dynamicParameters.Add("@ShortDescription", entity.ShortDescription);
                dynamicParameters.Add("@Description", entity.Description);
                dynamicParameters.Add("@SequenceNo", entity.SequenceNo);
                dynamicParameters.Add("@BookingURL", entity.BookingURL);
                dynamicParameters.Add("@IsPopular", entity.IsPopular);
                dynamicParameters.Add("@AttractionID", entity.AttractionID);
                dynamicParameters.Add("@IsProjectMapping", entity.IsProjectMapping);
                dynamicParameters.Add("@IsViewingGallery", entity.IsViewingGallery);
                dynamicParameters.Add("@CancellationPolicy", entity.CancellationPolicy);
                dynamicParameters.Add("@InstructionsForVisitors", entity.InstructionsForVisitors);
                dynamicParameters.Add("@MetaTitle", entity.MetaTitle);
                dynamicParameters.Add("@MetaKeywords", entity.MetaKeywords);
                dynamicParameters.Add("@MetaDescription", entity.MetaDescription);
                dynamicParameters.Add("@TicketURL", entity.TicketURL);
                dynamicParameters.Add("@ServiceCharge", entity.ServiceCharge);
                dynamicParameters.Add("@ServiceChargeType", entity.ServiceChargeType);
                dynamicParameters.Add("@ServiceChargeValue", entity.ServiceChargeValue);
                dynamicParameters.Add("@PerPersonRate", entity.PerPersonRate);
                dynamicParameters.Add("@ChildSevenYrRate", entity.ChildSevenYrRate);
                dynamicParameters.Add("@ChildThreeYrRate", entity.ChildThreeYrRate);
                dynamicParameters.Add("@LastEntry", entity.LastEntry);
                dynamicParameters.Add("@Notice", entity.Notice);
                dynamicParameters.Add("@MinPaxCount", entity.MinPaxCount);
                dynamicParameters.Add("@IsActive", entity.IsActive);
                dynamicParameters.Add("@CreatedBy", entity.CreatedBy);
                dynamicParameters.Add("@operationtype", CommonRepositoryConstants.Insert);


                if (entity.HotelBookingTicketDetails != null)
                    dynamicParameters.AddTable<HotelBookingTicketDetailsEntity>("@UDTT_HotelBookingTicketDetails", "UDTT_HotelBookingTicketDetails", entity.HotelBookingTicketDetails);

                var data = await _dbConnection.QueryAsync(storedProcedure, dynamicParameters, commandType: CommandType.StoredProcedure);
                result.ID = data.FirstOrDefault().ID;
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

        #region Update HotelBookingTicket
        public async Task<ResultModel> UpdateHotelBookingTicket(HotelBookingTicketEntity entity, string storedProcedure)
        {
            ResultModel result = new ResultModel();

            try
            {
                Dapper.DefaultTypeMap.MatchNamesWithUnderscores = true;
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@ID", entity.ID);
                dynamicParameters.Add("@Title", entity.Title);
                dynamicParameters.Add("@Timing", entity.Timing);
                dynamicParameters.Add("@ShortDescription", entity.ShortDescription);
                dynamicParameters.Add("@Description", entity.Description);
                dynamicParameters.Add("@SequenceNo", entity.SequenceNo);
                dynamicParameters.Add("@BookingURL", entity.BookingURL);
                dynamicParameters.Add("@IsPopular", entity.IsPopular);
                dynamicParameters.Add("@AttractionID", entity.AttractionID);
                dynamicParameters.Add("@IsProjectMapping", entity.IsProjectMapping);
                dynamicParameters.Add("@IsViewingGallery", entity.IsViewingGallery);
                dynamicParameters.Add("@CancellationPolicy", entity.CancellationPolicy);
                dynamicParameters.Add("@InstructionsForVisitors", entity.InstructionsForVisitors);
                dynamicParameters.Add("@MetaTitle", entity.MetaTitle);
                dynamicParameters.Add("@MetaKeywords", entity.MetaKeywords);
                dynamicParameters.Add("@MetaDescription", entity.MetaDescription);
                dynamicParameters.Add("@TicketURL", entity.TicketURL);
                dynamicParameters.Add("@ServiceCharge", entity.ServiceCharge);
                dynamicParameters.Add("@ServiceChargeType", entity.ServiceChargeType);
                dynamicParameters.Add("@ServiceChargeValue", entity.ServiceChargeValue);
                dynamicParameters.Add("@PerPersonRate", entity.PerPersonRate);
                dynamicParameters.Add("@ChildSevenYrRate", entity.ChildSevenYrRate);
                dynamicParameters.Add("@ChildThreeYrRate", entity.ChildThreeYrRate);
                dynamicParameters.Add("@LastEntry", entity.LastEntry);
                dynamicParameters.Add("@Notice", entity.Notice);
                dynamicParameters.Add("@MinPaxCount", entity.MinPaxCount);
                dynamicParameters.Add("@IsActive", entity.IsActive);
                dynamicParameters.Add("@CreatedBy", entity.CreatedBy);
                dynamicParameters.Add("@operationtype", CommonRepositoryConstants.Update);

                if (entity.HotelBookingTicketDetails != null)
                    dynamicParameters.AddTable<HotelBookingTicketDetailsEntity>("@UDTT_HotelBookingTicketDetails", "UDTT_HotelBookingTicketDetails", entity.HotelBookingTicketDetails);


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

        #region Delete HotelBookingTicket
        public async Task<ResultModel> DeleteHotelBookingTicket(HotelBookingTicketIDEntity entity, string storedProcedure)
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

        #region FindBy ID HotelBookingTicket
        public async Task<HotelBookingTicketViewEntity>  FindByIDHotelBookingTicket(HotelBookingTicketIDEntity entity, string storedProcedure)
        {
            HotelBookingTicketViewEntity result = new HotelBookingTicketViewEntity();

            try
            {
                Dapper.DefaultTypeMap.MatchNamesWithUnderscores = true;
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@ID", entity.ID);
                dynamicParameters.Add("@operationtype", CommonRepositoryConstants.FindByID);
                var data = await _dbConnection.QueryMultipleAsync(storedProcedure, dynamicParameters, commandType: CommandType.StoredProcedure);


                HotelBookingTicketViewEntity HotelBookingTicketViewEntity = await data.ReadFirstOrDefaultAsync<HotelBookingTicketViewEntity>();

                if (HotelBookingTicketViewEntity != null)
                {
                    HotelBookingTicketViewEntity.HotelBookingTicketDetails = (await data.ReadAsync<HotelBookingTicketDetailsdataEntity>()).ToList();
                    HotelBookingTicketViewEntity.HotelBookingTicketImage = (await data.ReadAsync<HotelBookingTicketImagesdataEntity>()).ToList();
                    HotelBookingTicketViewEntity.HotelBookingTicketVideo = (await data.ReadAsync<HotelBookingTicketVideodataEntity>()).ToList();
                    HotelBookingTicketViewEntity.HotelBookingTicketFAQ = (await data.ReadAsync<HotelBookingTicketFAQdataEntity>()).ToList();
                    HotelBookingTicketViewEntity.HotelBookingTicketSoldOutDate = (await data.ReadAsync<HotelBookingTicketSoldOutDateVeiwEntity>()).ToList();
                    HotelBookingTicketViewEntity.ViewingGallery = (await data.ReadAsync<ViewingGalleryEntity>()).ToList();
                    HotelBookingTicketViewEntity.ProjectionMapping = (await data.ReadAsync<ViewingGalleryEntity>()).ToList();
                
                }
                return HotelBookingTicketViewEntity;
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

        
        #region Find All Active HotelBookingTicket
        public async Task<List<HotelBookingTicketViewEntity>> FindAllHotelBookingTicket(HotelBookingTicketIDEntity entity, string storedProcedure)
        {
            HotelBookingTicketViewEntity result = new HotelBookingTicketViewEntity();

            try
            {
                Dapper.DefaultTypeMap.MatchNamesWithUnderscores = true;
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@Title", entity.Title);
                dynamicParameters.Add("@operationtype", CommonRepositoryConstants.FindAllItems);
                var data = await _dbConnection.QueryAsync<HotelBookingTicketViewEntity>(storedProcedure, dynamicParameters, commandType: CommandType.StoredProcedure);
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


        #region Find All HotelBookingTicket
        public async Task<List<HotelBookingTicketViewEntity>> FindAllActiveHotelBookingTicket(string storedProcedure)
        {
            HotelBookingTicketViewEntity result = new HotelBookingTicketViewEntity();

            try
            {
                Dapper.DefaultTypeMap.MatchNamesWithUnderscores = true;
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@operationtype", 5);
                var data = await _dbConnection.QueryAsync<HotelBookingTicketViewEntity>(storedProcedure, dynamicParameters, commandType: CommandType.StoredProcedure);
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

        #region Active InActive HotelBookingTicket
        public async Task<ResultModel> ActiveInActiveHotelBookingTicket(HotelBookingTicketIDEntity entity, string storedProcedure)
        {
            ResultModel result = new ResultModel();

            try
            {
                Dapper.DefaultTypeMap.MatchNamesWithUnderscores = true;
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@ID", entity.ID);
                dynamicParameters.Add("@IsActive", entity.IsActive);
                dynamicParameters.Add("@operationtype", 4);
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

        #region HotelBookingTicket Image Update
        public async Task<ResultModel> HotelBookingTicketImageUpdate(string? BannerImage,string? ImageUpload, List<HotelBookingTicketDocumentsImage> Image, int? ID, int? UpdatedBy, string storedProcedure)
        {
            ResultModel result = new ResultModel();

            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@ID", ID);
                parameters.Add("@ImageUpload", ImageUpload);
                parameters.Add("@BannerImage", BannerImage);
                parameters.AddTable("@UDTT_HotelBookingTicketDocumentsImage", "UDTT_HotelBookingTicketDocumentsImage", Image.ToList());
                parameters.Add("@UpdatedBy", UpdatedBy);
                parameters.Add("@OperationType", 3);

                var data = await _dbConnection.QueryAsync(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
                result.Message = data.FirstOrDefault().Message;
                result.Details = data.FirstOrDefault().Details;
                return result;
            }
            catch (SqlException ex)
            {
                logger.LogError(ex, ex.Message);
                result.Status = (int)ResponseStatusCode.InternaServerError;
                result.ErrorMessage = ex.Message;
                throw;
            }
            catch (Exception ex)
            {
                result.Status = (int)ResponseStatusCode.InternaServerError;
                result.ErrorMessage = ex.Message;
                throw;
            }
        }
        #endregion

        #region HotelBookingTicket Image Delete 

        public async Task<ResultModel> DeleteHotelBookingImages(AttractionIDEntity entity, string storedProcedure)
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
        #endregion

        #region FindByURLHotelBookingTicket
        public async Task<HotelBookingTicketViewEntity> FindByURLHotelBookingTicket(HotelBookingTicketIDEntity entity, string storedProcedure)
        {
            HotelBookingTicketViewEntity result = new HotelBookingTicketViewEntity();

            try
            {
                Dapper.DefaultTypeMap.MatchNamesWithUnderscores = true;
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@TicketURL", entity.TicketURL);
                dynamicParameters.Add("@operationtype", 5);
                var data = await _dbConnection.QueryMultipleAsync(storedProcedure, dynamicParameters, commandType: CommandType.StoredProcedure);


                HotelBookingTicketViewEntity HotelBookingTicketViewEntity = await data.ReadFirstOrDefaultAsync<HotelBookingTicketViewEntity>();

                if (HotelBookingTicketViewEntity != null)
                {
                    HotelBookingTicketViewEntity.HotelBookingTicketDetails = (await data.ReadAsync<HotelBookingTicketDetailsdataEntity>()).ToList();
                    HotelBookingTicketViewEntity.HotelBookingTicketImage = (await data.ReadAsync<HotelBookingTicketImagesdataEntity>()).ToList();
                    HotelBookingTicketViewEntity.HotelBookingTicketVideo = (await data.ReadAsync<HotelBookingTicketVideodataEntity>()).ToList();
                    HotelBookingTicketViewEntity.HotelBookingTicketFAQ = (await data.ReadAsync<HotelBookingTicketFAQdataEntity>()).ToList();
                    HotelBookingTicketViewEntity.AnotherTicket = (await data.ReadAsync<HotelBookingTicketAnotherTicketEntity>()).ToList();
                    var AnotherTikcetDetails = (await data.ReadAsync<HotelBookingTicketDetailsdataEntity>()).ToList();
                    foreach (var anotherTicket in HotelBookingTicketViewEntity.AnotherTicket)
                    {
                        anotherTicket.AnotherTicketDetails = AnotherTikcetDetails
                            .Where(x => x.HotelBookingTicketID == anotherTicket.ID)
                            .ToList();
                    }
                    HotelBookingTicketViewEntity.TimeSlot = (await data.ReadAsync<HotelBookingTicketTimeSlotEntity>()).ToList();

                }
                return HotelBookingTicketViewEntity;
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

        #region Insert HotelBookingTicketVideo
        public async Task<ResultModel> InsertHotelBookingTicketVideo(HotelBookingTicketVideoEntity entity, string storedProcedure)
        {
            ResultModel result = new ResultModel();

            try
            {
                Dapper.DefaultTypeMap.MatchNamesWithUnderscores = true;
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@TicketID", entity.TicketID);
                dynamicParameters.Add("@operationtype", 1);


                if (entity.HotelBookingTicketVideo != null)
                    dynamicParameters.AddTable<HotelBookingTicketVideo>("@UDTT_TicketVideo", "UDTT_TicketVideo", entity.HotelBookingTicketVideo);

                var data = await _dbConnection.QueryAsync(storedProcedure, dynamicParameters, commandType: CommandType.StoredProcedure);
                result.ID = data.FirstOrDefault().ID;
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

        #region Update HotelBookingTicketVideo
        public async Task<ResultModel> UpdateHotelBookingTicketVideo(HotelBookingTicketVideoEntity entity, string storedProcedure)
        {
            ResultModel result = new ResultModel();

            try
            {
                Dapper.DefaultTypeMap.MatchNamesWithUnderscores = true;
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@TicketID", entity.TicketID);
                dynamicParameters.Add("@operationtype", 3);

                if (entity.HotelBookingTicketVideo != null)
                    dynamicParameters.AddTable<HotelBookingTicketVideo>("@UDTT_TicketVideo", "UDTT_TicketVideo", entity.HotelBookingTicketVideo);


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

        #region Delete HotelBookingTicketVideo
        public async Task<ResultModel> DeleteHotelBookingTicketVideo(HotelBookingTicketIDEntity entity, string storedProcedure)
        {
            ResultModel result = new ResultModel();

            try
            {
                Dapper.DefaultTypeMap.MatchNamesWithUnderscores = true;
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@ID", entity.ID);
                dynamicParameters.Add("@operationtype", 6);
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

        #region Insert HotelBookingTicketFAQ
        public async Task<ResultModel> InsertHotelBookingTicketFAQ(HotelBookingTicketFAQEntity entity, string storedProcedure)
        {   
            ResultModel result = new ResultModel();

            try
            {
                Dapper.DefaultTypeMap.MatchNamesWithUnderscores = true;
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@TicketID", entity.TicketID);
                dynamicParameters.Add("@operationtype", 2);


                if (entity.HotelBookingTicketFAQ != null)
                    dynamicParameters.AddTable<HotelBookingTicketFAQ>("@UDTT_TicketFAQ", "UDTT_TicketFAQ", entity.HotelBookingTicketFAQ);

                var data = await _dbConnection.QueryAsync(storedProcedure, dynamicParameters, commandType: CommandType.StoredProcedure);
                result.ID = data.FirstOrDefault().ID;
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

        #region Update HotelBookingTicketFAQ
        public async Task<ResultModel> UpdateHotelBookingTicketFAQ(HotelBookingTicketFAQEntity entity, string storedProcedure)
        {
            ResultModel result = new ResultModel();

            try
            {
                Dapper.DefaultTypeMap.MatchNamesWithUnderscores = true;
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@TicketID", entity.TicketID);
                dynamicParameters.Add("@operationtype", 4);

                if (entity.HotelBookingTicketFAQ != null)
                    dynamicParameters.AddTable<HotelBookingTicketFAQ>("@UDTT_TicketFAQ", "UDTT_TicketFAQ", entity.HotelBookingTicketFAQ);


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

        #region Delete HotelBookingTicketFAQ
        public async Task<ResultModel> DeleteHotelBookingTicketFAQ(HotelBookingTicketIDEntity entity, string storedProcedure)
        {
            ResultModel result = new ResultModel();

            try
            {
                Dapper.DefaultTypeMap.MatchNamesWithUnderscores = true;
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@ID", entity.ID);
                dynamicParameters.Add("@operationtype", 7);
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


        #region Insert HotelBookingTicketSoldOutDate 
        public async Task<ResultModel> InsertHotelBookingTicketSoldOutDate(HotelBookingTicketSoldOutDateEntity entity, string storedProcedure)
        {
            ResultModel result = new ResultModel();

            try
            {
                Dapper.DefaultTypeMap.MatchNamesWithUnderscores = true;
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@HotelBookingTicketID", entity.HotelBookingTicketID);
                dynamicParameters.Add("@SoldOutDate", entity.SoldOutDate);
                
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

        #region Delete HotelBookingTicketSoldOutDate
        public async Task<ResultModel> DeleteHotelBookingTicketSoldOutDate(FAQIDEntity entity, string storedProcedure)
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

        #region Find By HotelBookingTicketID HotelBookingTicketSoldOutDate
        public async Task<List<HotelBookingTicketSoldOutDateViewEntity>> FindBYHotelBookingTicketSoldOutDate(HotelBookingTicketSoldOutDateEntity entity, string storedProcedure)
        {
            HotelBookingTicketSoldOutDateViewEntity result = new HotelBookingTicketSoldOutDateViewEntity();

            try
            {
                Dapper.DefaultTypeMap.MatchNamesWithUnderscores = true;
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@HotelBookingTicketID", entity.HotelBookingTicketID);
                dynamicParameters.Add("@OperationType", 2);
                var data = await _dbConnection.QueryAsync<HotelBookingTicketSoldOutDateViewEntity>(storedProcedure, dynamicParameters, commandType: CommandType.StoredProcedure);
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


        #region InsertTicketAvailability
        public async Task<ResultModel> InsertTicketAvailability(TicketAvailabilityEntity entity, string storedProcedure)
        {
            ResultModel result = new ResultModel();

            try
            {
                Dapper.DefaultTypeMap.MatchNamesWithUnderscores = true;
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@AttractionID", entity.AttractionID);
                dynamicParameters.Add("@TimeSlotID", entity.TimeSlotID);
                dynamicParameters.Add("@Total", entity.Total);
                dynamicParameters.Add("@FromDate", entity.FromDate);
                dynamicParameters.Add("@ToDate", entity.ToDate);
                
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

        #region FindTicketAvailability
        public async Task<List<TicketAvailabilityDataViewEntity>> FindTicketAvailability(TicketAvailabilityEntity entity, string storedProcedure)
        {
            TicketAvailabilityDataViewEntity result = new TicketAvailabilityDataViewEntity();

            try
            {
                Dapper.DefaultTypeMap.MatchNamesWithUnderscores = true;
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@AttractionID", entity.AttractionID);
                dynamicParameters.Add("@TimeSlotID", entity.TimeSlotID);
                dynamicParameters.Add("@OperationType", 2);
                var data = await _dbConnection.QueryAsync<TicketAvailabilityDataViewEntity>(storedProcedure, dynamicParameters, commandType: CommandType.StoredProcedure);
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

        #region FindAvailableTicket
        public async Task<TicketAvailabilityDataViewEntity> FindAvailableTicket(TicketAvailabilityEntity entity, string storedProcedure)
        {
            TicketAvailabilityDataViewEntity result = new TicketAvailabilityDataViewEntity();

            try
            {
                Dapper.DefaultTypeMap.MatchNamesWithUnderscores = true;
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@Date", entity.Date);
                dynamicParameters.Add("@TimeSlotID", entity.TimeSlotID);
                dynamicParameters.Add("@OperationType", 3);
                var data = await _dbConnection.QuerySingleOrDefaultAsync<TicketAvailabilityDataViewEntity>(storedProcedure, dynamicParameters, commandType: CommandType.StoredProcedure);
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
        #region SoldOutDate
        public async Task<ResultModel> InsertSoldOutDateDay(HotelPriceRangeEntity entity, string storedProcedure)
        {
            ResultModel result = new ResultModel();

            try
            {
                Dapper.DefaultTypeMap.MatchNamesWithUnderscores = true;
                DynamicParameters dynamicParameters = new DynamicParameters();
     
                dynamicParameters.Add("@Days", entity.Days);
                dynamicParameters.Add("@HotelBookingTicketID", entity.HotelBookingTicketID);
                
                dynamicParameters.Add("@FromDate", entity.FromDate);
                dynamicParameters.Add("@ToDate", entity.ToDate);
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

    }
}
