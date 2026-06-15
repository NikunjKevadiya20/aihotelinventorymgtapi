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

namespace HotelBooking.DataAccess.Base
{
    public class HotelBookingPackageLookupRepository : IHotelBookingPackageLookupRepositoryInterface
    {

        #region Global Variables
        private readonly IDbConnection _dbConnection;
        private readonly ILogger<HotelBookingPackageLookupRepository> logger;
        #endregion

        public HotelBookingPackageLookupRepository(ILogger<HotelBookingPackageLookupRepository> _logger, IDbConnection dbConnection)
        {
            logger = _logger;
            _dbConnection = dbConnection;
        }


        #region Insert HotelBookingPackage
        public async Task<ResultModel> InsertHotelBookingPackage(HotelBookingPackageEntity entity, string storedProcedure)
        {
            ResultModel result = new ResultModel();

            try
            {
                Dapper.DefaultTypeMap.MatchNamesWithUnderscores = true;
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@Title", entity.Title);
         
                dynamicParameters.Add("@ShortDescription", entity.ShortDescription);
                dynamicParameters.Add("@Description", entity.Description);
                dynamicParameters.Add("@SequenceNo", entity.SequenceNo);
                dynamicParameters.Add("@PackageURL", entity.PackageURL);
                dynamicParameters.Add("@IsPopular", entity.IsPopular);
                dynamicParameters.Add("@AttractionID", entity.AttractionID);
                dynamicParameters.Add("@IsProjectMapping", entity.IsProjectMapping);
                dynamicParameters.Add("@IsViewingGallery", entity.IsViewingGallery);
                dynamicParameters.Add("@CancellationPolicy", entity.CancellationPolicy);
                dynamicParameters.Add("@InstructionsForVisitors", entity.InstructionsForVisitors);
                dynamicParameters.Add("@MetaTitle", entity.MetaTitle);
                dynamicParameters.Add("@MetaKeywords", entity.MetaKeywords);
                dynamicParameters.Add("@MetaDescription", entity.MetaDescription);
              
                dynamicParameters.Add("@ServiceCharge", entity.ServiceCharge);
                dynamicParameters.Add("@ServiceChargeType", entity.ServiceChargeType);
                dynamicParameters.Add("@ServiceChargeValue", entity.ServiceChargeValue);
             
                dynamicParameters.Add("@ChildSevenYrRate", entity.ChildSevenYrRate);
                dynamicParameters.Add("@ChildThreeYrRate", entity.ChildThreeYrRate);
            
                dynamicParameters.Add("@Notice", entity.Notice);

                dynamicParameters.Add("@ERickshaw", entity.ERickshaw);
                dynamicParameters.Add("@ResortID", entity.ResortID);
                dynamicParameters.Add("@NoOfNights", entity.NoOfNights);
                dynamicParameters.Add("@PerCoupleRate", entity.PerCoupleRate);
                dynamicParameters.Add("@ExtraPersonRate", entity.ExtraPersonRate);
                dynamicParameters.Add("@Itinerary", entity.Itinerary);
                dynamicParameters.Add("@Highlights", entity.Highlights);
                dynamicParameters.Add("@RoomCategoryID", entity.RoomCategoryID);
                dynamicParameters.Add("@MealTypeID", entity.MealTypeID);

                dynamicParameters.Add("@IsActive", entity.IsActive);
                dynamicParameters.Add("@CreatedBy", entity.CreatedBy);
                dynamicParameters.Add("@operationtype", CommonRepositoryConstants.Insert);


                if (entity.HotelBookingPackageDetails != null)
                    dynamicParameters.AddTable<HotelBookingPackageDetailsEntity>("@UDTT_HotelBookingPackageDetails", "UDTT_HotelBookingPackageDetails", entity.HotelBookingPackageDetails);

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

        #region Update HotelBookingPackage
        public async Task<ResultModel> UpdateHotelBookingPackage(HotelBookingPackageEntity entity, string storedProcedure)
        {
            ResultModel result = new ResultModel();

            try
            {
                Dapper.DefaultTypeMap.MatchNamesWithUnderscores = true;
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@ID", entity.ID);
                dynamicParameters.Add("@Title", entity.Title);
           
                dynamicParameters.Add("@ShortDescription", entity.ShortDescription);
                dynamicParameters.Add("@Description", entity.Description);
                dynamicParameters.Add("@SequenceNo", entity.SequenceNo);
                dynamicParameters.Add("@PackageURL", entity.PackageURL);
                dynamicParameters.Add("@IsPopular", entity.IsPopular);
                dynamicParameters.Add("@AttractionID", entity.AttractionID);
                dynamicParameters.Add("@IsProjectMapping", entity.IsProjectMapping);
                dynamicParameters.Add("@IsViewingGallery", entity.IsViewingGallery);
                dynamicParameters.Add("@CancellationPolicy", entity.CancellationPolicy);
                dynamicParameters.Add("@InstructionsForVisitors", entity.InstructionsForVisitors);
                dynamicParameters.Add("@MetaTitle", entity.MetaTitle);
                dynamicParameters.Add("@MetaKeywords", entity.MetaKeywords);
                dynamicParameters.Add("@MetaDescription", entity.MetaDescription);
                
                dynamicParameters.Add("@ServiceCharge", entity.ServiceCharge);
                dynamicParameters.Add("@ServiceChargeType", entity.ServiceChargeType);
                dynamicParameters.Add("@ServiceChargeValue", entity.ServiceChargeValue);
              
                dynamicParameters.Add("@ChildSevenYrRate", entity.ChildSevenYrRate);
                dynamicParameters.Add("@ChildThreeYrRate", entity.ChildThreeYrRate);
                
                dynamicParameters.Add("@Notice", entity.Notice);

                dynamicParameters.Add("@ERickshaw", entity.ERickshaw);
                dynamicParameters.Add("@ResortID", entity.ResortID);
                dynamicParameters.Add("@NoOfNights", entity.NoOfNights);
                dynamicParameters.Add("@PerCoupleRate", entity.PerCoupleRate);
                dynamicParameters.Add("@ExtraPersonRate", entity.ExtraPersonRate);
                dynamicParameters.Add("@Itinerary", entity.Itinerary);
                dynamicParameters.Add("@Highlights", entity.Highlights);
                dynamicParameters.Add("@RoomCategoryID", entity.RoomCategoryID);
                dynamicParameters.Add("@MealTypeID", entity.MealTypeID);

                dynamicParameters.Add("@IsActive", entity.IsActive);
                dynamicParameters.Add("@CreatedBy", entity.CreatedBy);
                dynamicParameters.Add("@operationtype", CommonRepositoryConstants.Update);

                if (entity.HotelBookingPackageDetails != null)
                    dynamicParameters.AddTable<HotelBookingPackageDetailsEntity>("@UDTT_HotelBookingPackageDetails", "UDTT_HotelBookingPackageDetails", entity.HotelBookingPackageDetails);


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

        #region Delete HotelBookingPackage
        public async Task<ResultModel> DeleteHotelBookingPackage(HotelBookingPackageIDEntity entity, string storedProcedure)
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

        #region FindBy ID HotelBookingPackage
        public async Task<HotelBookingPackageViewEntity> FindByIDHotelBookingPackage(HotelBookingPackageIDEntity entity, string storedProcedure)
        {
            HotelBookingPackageViewEntity result = new HotelBookingPackageViewEntity();

            try
            {
                Dapper.DefaultTypeMap.MatchNamesWithUnderscores = true;
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@ID", entity.ID);
                dynamicParameters.Add("@operationtype", CommonRepositoryConstants.FindByID);
                var data = await _dbConnection.QueryMultipleAsync(storedProcedure, dynamicParameters, commandType: CommandType.StoredProcedure);


                HotelBookingPackageViewEntity HotelBookingPackageViewEntity = await data.ReadFirstOrDefaultAsync<HotelBookingPackageViewEntity>();

                if (HotelBookingPackageViewEntity != null)
                {
                    HotelBookingPackageViewEntity.HotelBookingPackageDetails = (await data.ReadAsync<HotelBookingPackageDetailsdataEntity>()).ToList();
                    HotelBookingPackageViewEntity.HotelBookingPackageImage = (await data.ReadAsync<HotelBookingPackageImagesdataEntity>()).ToList();
                    

                }
                return HotelBookingPackageViewEntity;
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


        #region Find All Active HotelBookingPackage
        public async Task<List<HotelBookingPackageViewEntity>> FindAllHotelBookingPackage(HotelBookingPackageIDEntity entity, string storedProcedure)
        {
            HotelBookingPackageViewEntity result = new HotelBookingPackageViewEntity();

            try
            {
                Dapper.DefaultTypeMap.MatchNamesWithUnderscores = true;
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@Title", entity.Title);
                dynamicParameters.Add("@operationtype", CommonRepositoryConstants.FindAllItems);
                var data = await _dbConnection.QueryAsync<HotelBookingPackageViewEntity>(storedProcedure, dynamicParameters, commandType: CommandType.StoredProcedure);
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


        #region Find All HotelBookingPackage
        public async Task<List<HotelBookingPackageViewEntity>> FindAllActiveHotelBookingPackage(string storedProcedure)
        {
            HotelBookingPackageViewEntity result = new HotelBookingPackageViewEntity();

            try
            {
                Dapper.DefaultTypeMap.MatchNamesWithUnderscores = true;

                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@operationtype", 5);

                using var multi = await _dbConnection.QueryMultipleAsync(
                    storedProcedure,
                    dynamicParameters,
                    commandType: CommandType.StoredProcedure);

                // First Result Set
                var packages = (await multi.ReadAsync<HotelBookingPackageViewEntity>()).ToList();

                // Second Result Set
                var prices = (await multi.ReadAsync<HotelBookingPackagePriceEntity>()).ToList();

                // Map prices to package
                foreach (var package in packages)
                {
                    package.PackagePrices = prices
                        .Where(x => x.HotelBookingPackageID == package.ID)
                        .ToList();
                }

                return packages;
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
        #endregion

        #region Active InActive HotelBookingPackage
        public async Task<ResultModel> ActiveInActiveHotelBookingPackage(HotelBookingPackageIDEntity entity, string storedProcedure)
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

        #region HotelBookingPackage Image Update
        public async Task<ResultModel> HotelBookingPackageImageUpdate(string? BannerImage, string? ImageUpload, List<HotelBookingPackageDocumentsImage> Image, int? ID, int? UpdatedBy, string storedProcedure)
        {
            ResultModel result = new ResultModel();

            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@ID", ID);
                parameters.Add("@ImageUpload", ImageUpload);
                parameters.Add("@BannerImage", BannerImage);
                parameters.AddTable("@UDTT_HotelBookingPackageDocumentsImage", "UDTT_HotelBookingPackageDocumentsImage", Image.ToList());
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

        #region HotelBookingPackage Image Delete 

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

        #region FindByURLHotelBookingPackage
        public async Task<HotelBookingPackageViewEntity> FindByURLHotelBookingPackage(HotelBookingPackageIDEntity entity, string storedProcedure)
        {
            HotelBookingPackageViewEntity result = new HotelBookingPackageViewEntity();

            try
            {
                Dapper.DefaultTypeMap.MatchNamesWithUnderscores = true;
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@PackageURL", entity.PackageURL);
                dynamicParameters.Add("@operationtype", 5);
                var data = await _dbConnection.QueryMultipleAsync(storedProcedure, dynamicParameters, commandType: CommandType.StoredProcedure);


                HotelBookingPackageViewEntity HotelBookingPackageViewEntity = await data.ReadFirstOrDefaultAsync<HotelBookingPackageViewEntity>();

                if (HotelBookingPackageViewEntity != null)
                {
                    HotelBookingPackageViewEntity.HotelBookingPackageDetails =
                        (await data.ReadAsync<HotelBookingPackageDetailsdataEntity>()).ToList();

                    HotelBookingPackageViewEntity.HotelBookingPackageImage =
                        (await data.ReadAsync<HotelBookingPackageImagesdataEntity>()).ToList();

                    HotelBookingPackageViewEntity.HotelBookingPackageItinerary =
                        (await data.ReadAsync<HotelBookingPackageItineraryEntity>()).ToList();

                    var allHotelImages =
                        (await data.ReadAsync<HotelBookingPackageHotelImages>()).ToList();

                    var allAttractions =
     (await data.ReadAsync<ViewingGalleryEntity>()).ToList();

                    HotelBookingPackageViewEntity.HotelBookingTicketSoldOutDateforpax =
                    (await data.ReadAsync<HotelBookingTicketPaxSoldOutDateViewEntity>()).ToList();

                     var allPrices =
                        (await data.ReadAsync<HotelBookingPackagePriceEntity>()).ToList();

                    HotelBookingPackageViewEntity.PackagePrices = allPrices
                        .Where(x => x.HotelBookingPackageID == HotelBookingPackageViewEntity.ID)
                        .ToList();

                    var attractionTicket =
    (await data.ReadAsync<AttractionTicket>()).ToList();

                    var attractionTicketChild =
                        (await data.ReadAsync<AttractionTicketChild>()).ToList();

                    foreach (var attraction in attractionTicket)
                    {
                        attraction.AttractionTicketChild = attractionTicketChild
                            .Where(x => x.AttractionID == attraction.AttractionID)
                            .ToList();
                    }

                    HotelBookingPackageViewEntity.AttractionTicket = attractionTicket
                        .Where(x => x.PackageID == HotelBookingPackageViewEntity.ID)
                        .ToList();

                    HotelBookingPackageViewEntity.HotelBookingPackageHotelImages = allHotelImages
                        .Where(x => x.HotelID == HotelBookingPackageViewEntity.ResortID)
                        .ToList();

                    var attractionIds = (HotelBookingPackageViewEntity.AttractionID ?? "")
                        .Split(',', StringSplitOptions.RemoveEmptyEntries)
                        .Select(x => x.Trim())
                        .ToList();

                    HotelBookingPackageViewEntity.ViewingGallery = allAttractions
                        .Where(x => x.AttractionID == 1)
                        .ToList();

                    HotelBookingPackageViewEntity.ProjectionMapping = allAttractions
                        .Where(x => x.AttractionID == 2)
                        .ToList();


                }
                return HotelBookingPackageViewEntity;
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


        #region HotelBookingPackageItineraryDetails insert
        public async Task<ResultModel> InsertHotelBookingPackageItineraryDetails(HotelBookingPackageItinerariesEntity entity, string storedProcedure)
        {
            ResultModel result = new ResultModel();

            try
            {
                Dapper.DefaultTypeMap.MatchNamesWithUnderscores = true;
                DynamicParameters dynamicParameters = new DynamicParameters();
                if (entity.ItinerariesData != null)
                {
                    dynamicParameters.AddTable("@UDTTHotelBookingPackageItineraries", "UDTTHotelBookingPackageItineraries", entity.ItinerariesData.ToList());
                }

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

        #region HotelBookingPackageItineraryDetails update
        public async Task<ResultModel> UpdateHotelBookingPackageItineraryDetails(HotelBookingPackageItineraryDetailsEntity entity, string storedProcedure)
        {
            ResultModel result = new ResultModel();

            try
            {
                Dapper.DefaultTypeMap.MatchNamesWithUnderscores = true;
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@ID", entity.ID);
                dynamicParameters.Add("@HotelBookingPackageID", entity.HotelBookingPackageID);
                dynamicParameters.Add("@DayNo", entity.DayNo);
                dynamicParameters.Add("@SequenceNo", entity.SequenceNo);
                dynamicParameters.Add("@Title", entity.Title);
                dynamicParameters.Add("@Description", entity.Description);
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

        #region HotelBookingPackageItineraryDetails delete
        public async Task<ResultModel> DeleteHotelBookingPackageItineraryDetails(HotelBookingPackageItineraryDetailsEntity entity, string storedProcedure)
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

        #region HotelBookingPackageItineraryDetails find by id 
        public async Task<List<HotelBookingPackageItineraryDetailsViewEntity>> FindByIdHotelBookingPackageItineraryDetails(HotelBookingPackageRateViewEntity entity, string storedProcedure)
        {
            HotelBookingPackageItineraryDetailsViewEntity result = new HotelBookingPackageItineraryDetailsViewEntity();

            try
            {
                Dapper.DefaultTypeMap.MatchNamesWithUnderscores = true;
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@HotelBookingPackageID", entity.HotelBookingPackageID);
                dynamicParameters.Add("@OperationType", 2);
                var data = await _dbConnection.QueryAsync<HotelBookingPackageItineraryDetailsViewEntity>(storedProcedure, dynamicParameters, commandType: CommandType.StoredProcedure);
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
