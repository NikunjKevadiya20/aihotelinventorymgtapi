using HotelBooking.Entity.Common;
using HotelBooking.Entity.Common.Entities;
using HotelBooking.Entity.Common.Enums;
using HotelBooking.Entity.Entities;
using Dapper;
using Microsoft.Extensions.Logging;
using System.Data;
using System.Data.SqlClient;
using System.Text.RegularExpressions;

namespace HotelBooking.DataAccess.Base
{
    public class HotelSpecialRateLookupRepository : IHotelSpecialRateLookupRepositoryInterface
    {

        #region Global Variables
        private readonly IDbConnection _dbConnection;
        #endregion


        private readonly ILogger<HotelSpecialRateLookupRepository> logger;

        public HotelSpecialRateLookupRepository(ILogger<HotelSpecialRateLookupRepository> _logger, IDbConnection dbConnection)
        {
            logger = _logger;
            _dbConnection = dbConnection;
        }

        // Helper to parse IDs from various formats like "1,2,3" or "[1,2]" or "['1','2']" or JSON-ish strings
        private static HashSet<int> ParseAmenityIds(string? raw)
        {
            var set = new HashSet<int>();
            if (string.IsNullOrWhiteSpace(raw)) return set;

            // Find all integer sequences in the string. This handles CSV, brackets, quotes etc.
            var matches = Regex.Matches(raw, "\\d+");
            foreach (Match m in matches)
            {
                if (int.TryParse(m.Value, out var id)) set.Add(id);
            }

            return set;
        }

        #region Insert HotelSpecialRate
        public async Task<HotelRateResViewEntity> InsertHotelSpecialRate(HotelSpecialRateDataEntity entity, string storedProcedure)
        {
            HotelRateResViewEntity result = new HotelRateResViewEntity();
            

            try
            {
                Dapper.DefaultTypeMap.MatchNamesWithUnderscores = true;
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@DateType", entity.DateType);
                dynamicParameters.Add("@HotelID", entity.HotelID);
                dynamicParameters.Add("@FestivalID", entity.FestivalID);
                dynamicParameters.Add("@FromDate", entity.FromDate);
                dynamicParameters.Add("@ToDate", entity.ToDate);
                dynamicParameters.Add("@RoomCategoryID", entity.RoomCategoryID);
                dynamicParameters.Add("@SOEPAI", entity.SOEPAI);
                dynamicParameters.Add("@SOCPAI", entity.SOCPAI);
                dynamicParameters.Add("@SOMAPAI", entity.SOMAPAI);
                dynamicParameters.Add("@SOAPAI", entity.SOAPAI);
                dynamicParameters.Add("@KitchenCharges", entity.KitchenCharges);
                dynamicParameters.Add("@IsActive", entity.IsActive);
                dynamicParameters.Add("@CreatedBy", entity.CreatedBy);
                dynamicParameters.Add("@DeletedBy", entity.DeletedBy);
                dynamicParameters.Add("@IsUser", entity.IsUser);
                dynamicParameters.Add("@IsUpdatedUser", entity.IsUpdatedUser);
                dynamicParameters.Add("@MealID", entity.MealID);

                dynamicParameters.Add("@MarkupAmount", entity.MarkupAmount);
                dynamicParameters.Add("@MarkupType", entity.MarkupType);
                dynamicParameters.Add("@SingleOccupancyRate", entity.SingleOccupancyRate);
                dynamicParameters.Add("@DoubleOccupancyRate", entity.DoubleOccupancyRate);

                dynamicParameters.Add("@ExtraPersonRate", entity.ExtraPersonRate);
                dynamicParameters.Add("@ChildWithBedRate", entity.ChildWithBedRate);
                dynamicParameters.Add("@ChildWithoutBedRate", entity.ChildWithoutBedRate);
                dynamicParameters.Add("@SingleOccPurRate", entity.SingleOccPurRate);
                dynamicParameters.Add("@DoubleOccPurRate", entity.DoubleOccPurRate);
                dynamicParameters.Add("@ExtraPerPurRate", entity.ExtraPerPurRate);
                dynamicParameters.Add("@CWBPurRate", entity.CWBPurRate);
                dynamicParameters.Add("@CNBPurRate", entity.CNBPurRate);
                dynamicParameters.Add("@OperationType", CommonRepositoryConstants.Insert);
                var data = await _dbConnection.QueryMultipleAsync(storedProcedure, dynamicParameters, commandType: System.Data.CommandType.StoredProcedure);

                IEnumerable<HotelRateResViewEntity> hotelData = await data.ReadAsync<HotelRateResViewEntity>();

                if (hotelData.SingleOrDefault().Message == "success")
                {
                    IEnumerable<HotelRatesViewEntity> weekday = await data.ReadAsync<HotelRatesViewEntity>();
                    IEnumerable<HotelRatesViewEntity> Weekends = await data.ReadAsync<HotelRatesViewEntity>();
                    IEnumerable<HotelSpecialRateResEntity> Special = await data.ReadAsync<HotelSpecialRateResEntity>();
                    return GetHotelRate(hotelData, weekday, Weekends, Special);

                }
                else
                {
                    result.Message = Convert.ToString(hotelData.AsList()[0].Message);
                    result.Details = Convert.ToString(hotelData.AsList()[0].Details);

                    return result;
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
            finally
            {
            }

            return result;
        }
        #endregion

        public HotelRateResViewEntity GetHotelRate(IEnumerable<HotelRateResViewEntity> hotelData, IEnumerable<HotelRatesViewEntity> weekday, IEnumerable<HotelRatesViewEntity> Weekends,
         IEnumerable<HotelSpecialRateResEntity> Special)
        {
            HotelRateResViewEntity hotels = new HotelRateResViewEntity();
            foreach (var item in hotelData)
            {
                List<HotelRatesViewEntity> wdList = new List<HotelRatesViewEntity>();
                List<HotelRatesViewEntity> weList = new List<HotelRatesViewEntity>();
                List<HotelSpecialRateResEntity> spList = new List<HotelSpecialRateResEntity>();


                hotels.ID = item.ID;
                hotels.Message = item.Message;
                hotels.Details = item.Details;

                foreach (var wd in weekday)
                {
                    HotelRatesViewEntity weeks = new HotelRatesViewEntity();
                    weeks.ID = wd.ID;
                    weeks.DateType = wd.DateType;
                    weeks.HotelID = wd.HotelID;
                    weeks.HotelName = wd.HotelName;
                    weeks.RoomCategoryID = wd.RoomCategoryID;
                    weeks.RoomCategoryName = wd.RoomCategoryName;
                    weeks.SOEPAI = wd.SOEPAI;
                    weeks.SOCPAI = wd.SOCPAI;
                    weeks.SOMAPAI = wd.SOMAPAI;
                    weeks.SOAPAI = wd.SOAPAI;
                    weeks.KitchenCharges = wd.KitchenCharges;
                    weeks.IsActive = wd.IsActive;
                    wdList.Add(weeks);
                }
                foreach (var we in Weekends)
                {
                    HotelRatesViewEntity weeks = new HotelRatesViewEntity();
                    weeks.ID = we.ID;
                    weeks.DateType = we.DateType;
                    weeks.HotelID = we.HotelID;
                    weeks.HotelName = we.HotelName;
                    weeks.RoomCategoryID = we.RoomCategoryID;
                    weeks.RoomCategoryName = we.RoomCategoryName;
                    weeks.SOEPAI = we.SOEPAI;
                    weeks.SOCPAI = we.SOCPAI;
                    weeks.SOMAPAI = we.SOMAPAI;
                    weeks.SOAPAI = we.SOAPAI;
                    weeks.KitchenCharges = we.KitchenCharges;
                    weeks.IsActive = we.IsActive;
                    weList.Add(weeks);

                }
                foreach (var spl in Special)
                {
                    HotelSpecialRateResEntity sp = new HotelSpecialRateResEntity();
                    sp.ID = spl.ID;
                    sp.DateType = spl.DateType;
                    sp.HotelID = spl.HotelID;
                    sp.HotelName = spl.HotelName;
                    sp.RoomCategoryID = spl.RoomCategoryID;
                    sp.RoomCategoryName = spl.RoomCategoryName;
                    sp.FestivalID = spl.FestivalID;
                    sp.FestivalName = spl.FestivalName;
                    sp.FromDate = spl.FromDate;
                    sp.ToDate = spl.ToDate;
                    sp.SOEPAI = spl.SOEPAI;
                    sp.SOCPAI = spl.SOCPAI;
                    sp.SOMAPAI = spl.SOMAPAI;
                    sp.SOAPAI = spl.SOAPAI;
                    sp.IsActive = spl.IsActive;
                    sp.KitchenCharges = spl.KitchenCharges;
                    spList.Add(sp);

                }

                hotels.WeekDaysRateList = wdList;
                hotels.WeekEndRateList = weList;
                hotels.SpecialDateRateList = spList;

            }

            return hotels;
        }

        #region Update HotelSpecialRate
        public async Task<HotelRateResViewEntity> UpdateHotelSpecialRate(HotelSpecialRateDataEntity entity, string storedProcedure)
        {
            HotelRateResViewEntity result = new HotelRateResViewEntity();
            

            try
            {

                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@ID", entity.ID);
                dynamicParameters.Add("@DateType", entity.DateType);
                dynamicParameters.Add("@HotelID", entity.HotelID);
                dynamicParameters.Add("@FestivalID", entity.FestivalID);
                dynamicParameters.Add("@FromDate", entity.FromDate);
                dynamicParameters.Add("@ToDate", entity.ToDate);
                dynamicParameters.Add("@RoomCategoryID", entity.RoomCategoryID);
                dynamicParameters.Add("@SOEPAI", entity.SOEPAI);
                dynamicParameters.Add("@SOCPAI", entity.SOCPAI);
                dynamicParameters.Add("@SOMAPAI", entity.SOMAPAI);
                dynamicParameters.Add("@SOAPAI", entity.SOAPAI);
                dynamicParameters.Add("@KitchenCharges", entity.KitchenCharges);
                dynamicParameters.Add("@IsActive", entity.IsActive);
                dynamicParameters.Add("@CreatedBy", entity.CreatedBy);
                dynamicParameters.Add("@UpdatedBy", entity.UpdatedBy);
                dynamicParameters.Add("@DeletedBy", entity.DeletedBy);
                dynamicParameters.Add("@IsUser", entity.IsUser);
                dynamicParameters.Add("@IsUpdatedUser", entity.IsUpdatedUser);
                dynamicParameters.Add("@MealID", entity.MealID);
                dynamicParameters.Add("@MarkupAmount", entity.MarkupAmount);
                dynamicParameters.Add("@MarkupType", entity.MarkupType);
                dynamicParameters.Add("@SingleOccupancyRate", entity.SingleOccupancyRate);
                dynamicParameters.Add("@DoubleOccupancyRate", entity.DoubleOccupancyRate);
                dynamicParameters.Add("@ExtraPersonRate", entity.ExtraPersonRate);
                dynamicParameters.Add("@ChildWithBedRate", entity.ChildWithBedRate);
                dynamicParameters.Add("@ChildWithoutBedRate", entity.ChildWithoutBedRate);
                dynamicParameters.Add("@SingleOccPurRate", entity.SingleOccPurRate);
                dynamicParameters.Add("@DoubleOccPurRate", entity.DoubleOccPurRate);
                dynamicParameters.Add("@ExtraPerPurRate", entity.ExtraPerPurRate);
                dynamicParameters.Add("@CWBPurRate", entity.CWBPurRate);
                dynamicParameters.Add("@CNBPurRate", entity.CNBPurRate);
                dynamicParameters.Add("@OperationType", CommonRepositoryConstants.Update);
                var data = await _dbConnection.QueryMultipleAsync(storedProcedure, dynamicParameters, commandType: System.Data.CommandType.StoredProcedure);

                IEnumerable<HotelRateResViewEntity> hotelData = await data.ReadAsync<HotelRateResViewEntity>();

                if (hotelData.SingleOrDefault().Message == "success")
                {
                    IEnumerable<HotelRatesViewEntity> weekday = await data.ReadAsync<HotelRatesViewEntity>();
                    IEnumerable<HotelRatesViewEntity> Weekends = await data.ReadAsync<HotelRatesViewEntity>();
                    IEnumerable<HotelSpecialRateResEntity> Special = await data.ReadAsync<HotelSpecialRateResEntity>();
                    return GetHotelRate(hotelData, weekday, Weekends, Special);

                }
                else
                {
                    result.Message = Convert.ToString(hotelData.AsList()[0].Message);
                    result.Details = Convert.ToString(hotelData.AsList()[0].Details);

                    return result;
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
            finally
            {
            }

            return result;
        }
        #endregion

        #region Delete HotelSpecialRate
        public async Task<ResultModel> DeleteHotelSpecialRate(HotelSpecialRateIDEntity entity, string storedProcedure)
        {
            ResultModel result = new ResultModel();

            try
            {
                Dapper.DefaultTypeMap.MatchNamesWithUnderscores = true;
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@ID", entity.ID);
                dynamicParameters.Add("@OperationType", 9);
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

        #region Find By ID HotelSpecialRate
        public async Task<HotelSpecialRateViewEntity> FindByIDHotelSpecialRate(HotelSpecialRateIDEntity entity, string storedProcedure)
        {
            HotelSpecialRateViewEntity result = new HotelSpecialRateViewEntity();
            

            try
            {

                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@ID", entity.ID);
                dynamicParameters.Add("@OperationType", 28);
                var data = await _dbConnection.QueryMultipleAsync(storedProcedure, dynamicParameters, commandType: System.Data.CommandType.StoredProcedure);
                var HotelData = await data.ReadFirstAsync<HotelSpecialRateViewEntity>();

                if (HotelData.Message == "success")
                {
                    HotelSpecialRateViewEntity hotels = new HotelSpecialRateViewEntity();
                    hotels = (HotelSpecialRateViewEntity)HotelData;
                    return hotels;
                }
                else
                {
                    result.Message = Convert.ToString(HotelData.Message);
                    result.Details = Convert.ToString(HotelData.Details);
                }


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
        #endregion

        #region Find All Active HotelSpecialRate
        public async Task<List<HotelSpecialRateViewEntity>> FindHotelIDByHotelSpecialRate(HotelSpecialRateIDEntity entity, string storedProcedure)
        {
            HotelSpecialRateViewEntity result = new HotelSpecialRateViewEntity();

            try
            {
                Dapper.DefaultTypeMap.MatchNamesWithUnderscores = true;
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@HotelID", entity.HotelID);
                dynamicParameters.Add("@OperationType", 29);
                var data = await _dbConnection.QueryAsync<HotelSpecialRateViewEntity>(storedProcedure, dynamicParameters, commandType: CommandType.StoredProcedure);
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
        
        #region Active InActive HotelSpecialRate
        public async Task<ResultModel> ActiveInActiveHotelSpecialRate(HotelSpecialRateIDEntity entity, string storedProcedure)
        {
            ResultModel result = new ResultModel();

            try
            {
                Dapper.DefaultTypeMap.MatchNamesWithUnderscores = true;
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@ID", entity.ID);
                dynamicParameters.Add("@IsActive", entity.IsActive);
                dynamicParameters.Add("@OperationType", 15);
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

        #region Get Hotel Special Rate
        public async Task<HotelRateViewEntity> GetHotelSpecialRate(HotelRateDataEntity entity, string storedProcedure)
        {
            HotelRateViewEntity result = new HotelRateViewEntity();
            

            try
            {
                Dapper.DefaultTypeMap.MatchNamesWithUnderscores = true;
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@Place", entity.Place);
                dynamicParameters.Add("@HotelID", entity.HotelID);
                dynamicParameters.Add("@CheckInDate", entity.CheckInDate);
                dynamicParameters.Add("@MealTypeID", entity.MealTypeID);
                dynamicParameters.Add("@RoomCategoryID", entity.RoomCategoryID);
                dynamicParameters.Add("@OperationType", 30);
                var data = await _dbConnection.QuerySingleOrDefaultAsync<HotelRateViewEntity>(storedProcedure, dynamicParameters, commandType: CommandType.StoredProcedure);

                return data;
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

        #region Hotel Room Wise Rate List
        public async Task<HotelListViewEntity> HotelRoomWiseRateList(
            HotelListEntity entity,
            string storedProcedure)
        {
            HotelListViewEntity result = new HotelListViewEntity();

            try
            {
                Dapper.DefaultTypeMap.MatchNamesWithUnderscores = true;

                DynamicParameters dynamicParameters = new DynamicParameters();

                dynamicParameters.Add("@CheckInDate", entity.CheckInDate);
                dynamicParameters.Add("@CheckOutDate", entity.CheckOutDate);
                dynamicParameters.Add("@NoOfRooms", entity.NoOfRooms);
                dynamicParameters.Add("@OperationType", 1);

                using var multi = await _dbConnection.QueryMultipleAsync(
                    storedProcedure,
                    dynamicParameters,
                    commandType: CommandType.StoredProcedure);

                // Result Set 1
                var roomList = multi
                    .Read<RoomTypeEntity>()
                    .ToList();

                // Result Set 2
                var rateList = multi
                    .Read<HotelRateView>()
                    .ToList();

                // Result Set 3
                var imageList = multi
                    .Read<RoomTypeImageEntity1>()
                    .ToList();

                // Result Set 4 : Company Profile (Top 1)
                var companyProfile = multi.Read<CompanyProfile>().FirstOrDefault();
                
                // Result Set 5 : Amenities Type
                var amenitiesTypeList = multi.Read<AmenitiesTypeDataViewEntity>().ToList();
                
                // Result Set 6 : Amenities
                var amenitiesList = multi.Read<AmenitiesDataViewEntity>().ToList();

                if (roomList.Any())
                {
                    result.Status = (int)ResponseStatusCode.Success;

                    if (rateList.Any())
                    {
                        result.Message = rateList.First().Message;
                        result.Details = rateList.First().Details;
                    }

                    result.RoomType = roomList
                    .Select(room => new RoomTypeEntity
                    {
                        ID = room.ID,
                        RoomType = room.RoomType,
                        MaxGuest = room.MaxGuest,
                        RoomArea = room.RoomArea,
                        BedType = room.BedType,
                        Description = room.Description,
                        Amenities = room.Amenities,
                        AmenitiesIDs = room.AmenitiesIDs,
                        Image = room.Image,
                        TotalAvailableRoom = room.TotalAvailableRoom,

                        ImageList = imageList
                            .Where(image => image.RoomTypeID == room.ID)
                            .ToList(),

                        RateList = rateList
                            .Where(rate => rate.RoomCategoryID == room.ID)
                            .Select(rate => new RateEntity
                            {
                                MealPlanID = rate.MealPlanID,
                                MealPlanName = rate.MealPlanName,
                                MealDescription = rate.MealDescription,
                                CoupleCost = rate.CoupleCost,
                                ExtraPersonCost = rate.ExtraPersonCost,
                                ExtraChildCost = rate.ExtraChildCost,
                                Discount = rate.Discount
                            })
                            .ToList()
                    })
                    .ToList();

                    // Attach company profile and map amenities types and amenities
                    result.CompanyProfile = companyProfile;

                    // Keep all amenities types returned and map amenities by AmenitiesTypeID
                    result.AmenitiesType = amenitiesTypeList;

                    // Filter amenities to those that have a matching AmenitiesTypeID present in amenitiesTypeList
                    var amenityTypeIds = new HashSet<int>(amenitiesTypeList.Select(at => at.ID));

                    // Parse company amenity ids robustly
                    // Determine company amenity IDs. If company profile has no AmenitiesIDs set (null/empty),
                    // we must return no amenities per requirement.
                    var companyAmenityIds = new HashSet<int>();
                    var companyHasAmenities = false;
                    if (companyProfile != null && !string.IsNullOrWhiteSpace(companyProfile.AmenitiesIDs))
                    {
                        companyAmenityIds = ParseAmenityIds(companyProfile.AmenitiesIDs);
                        companyHasAmenities = companyAmenityIds.Count > 0;
                    }

                    // Build collection of all amenities belonging to returned amenity types (used for per-room mapping)
                    var allAmenitiesByType = amenitiesList
                        .Where(a => a.AmenitiesTypeID.HasValue && amenityTypeIds.Contains(a.AmenitiesTypeID.Value))
                        .ToList();

                    // If company explicitly provides amenity IDs, filter by them. If not provided, return no amenities.
                    var filteredAmenities = companyHasAmenities
                        ? allAmenitiesByType.Where(a => a.ID != 0 && companyAmenityIds.Contains(a.ID)).ToList()
                        : new List<AmenitiesDataViewEntity>();

                    // Optionally filter out amenities types that have no matching amenities after applying company filter
                    amenitiesTypeList = amenitiesTypeList
                        .Where(at => filteredAmenities.Any(a => a.AmenitiesTypeID.HasValue && a.AmenitiesTypeID.Value == at.ID))
                        .ToList();

                    // Update the result's AmenitiesType to the filtered list
                    result.AmenitiesType = amenitiesTypeList;

                    // Map amenities into each amenities type's Amenities collection
                    foreach (var at in amenitiesTypeList)
                    {
                        at.Amenities = filteredAmenities
                            .Where(a => a.AmenitiesTypeID.HasValue && a.AmenitiesTypeID.Value == at.ID)
                            .ToList();
                    }

                    // Map per-room amenities types using RoomType.AmenitiesIDs (comma-separated)
                    foreach (var room in result.RoomType)
                    {
                        // Parse room amenity ids robustly
                        var roomAmenityIds = ParseAmenityIds(room.AmenitiesIDs);

                        var roomAmenitiesTypes = new List<AmenitiesTypeDataViewEntity>();

                        foreach (var at in amenitiesTypeList)
                        {
                            // For per-room mapping: only include amenities that are listed in room.AmenitiesIDs.
                            // If room.AmenitiesIDs is null/empty we should not include any amenities for that room.
                            var amenitiesForType = allAmenitiesByType
                                 .Where(a => a.AmenitiesTypeID.HasValue && a.AmenitiesTypeID.Value == at.ID
                                             && roomAmenityIds.Count > 0 && a.ID != 0 && roomAmenityIds.Contains(a.ID))
                                 .ToList();

                            if (amenitiesForType.Any())
                            {
                                // create a shallow copy of the amenities type for this room
                                var atCopy = new AmenitiesTypeDataViewEntity
                                {
                                    ID = at.ID,
                                    AmenitiesID = at.AmenitiesID,
                                    AmenitiesName = at.AmenitiesName,
                                    AmenityType = at.AmenityType,
                                    IsActive = at.IsActive,
                                    Details = at.Details,
                                    Message = at.Message,
                                    Status = at.Status,
                                    ErrorMessage = at.ErrorMessage,
                                    Amenities = amenitiesForType
                                };

                                roomAmenitiesTypes.Add(atCopy);
                            }
                        }

                        room.AmenitiesType = roomAmenitiesTypes;
                    }

                    // Do not set a top-level flat Amenities list; amenities are available under AmenitiesType[].Amenities

                }
                else
                {
                    result.Status = (int)ResponseStatusCode.NotFound;
                    result.Message =
                        CommonRepositoryMessages.CannotFindAllMessage;

                    result.Details =
                        CommonRepositoryMessages.CannotFindAllDetails;
                }
            }
            catch (SqlException ex)
            {
                logger.LogError(ex, ex.Message);

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
                logger.LogError(ex, ex.Message);

                result.Status =
                    (int)ResponseStatusCode.InternaServerError;

                result.Message =
                    CommonRepositoryMessages.ExceptionMessage;

                result.ErrorMessage = ex.Message;
            }

            return result;
        }
        #endregion
    }
}
