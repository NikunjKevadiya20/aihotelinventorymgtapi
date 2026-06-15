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
        //#region Find All HotelSpecialRate
        //public async Task<List<HotelSpecialRateViewEntity>> FindAllActiveHotelSpecialRate(string storedProcedure)
        //{
        //    HotelSpecialRateViewEntity result = new HotelSpecialRateViewEntity();

        //    try
        //    {
        //        Dapper.DefaultTypeMap.MatchNamesWithUnderscores = true;
        //        DynamicParameters dynamicParameters = new DynamicParameters();
        //        dynamicParameters.Add("@OperationType", CommonRepositoryConstants.FindAllItems);
        //        var data = await _dbConnection.QueryAsync<HotelSpecialRateViewEntity>(storedProcedure, dynamicParameters, commandType: CommandType.StoredProcedure);
        //        return data.ToList();

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
        //#endregion

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

    }
}
