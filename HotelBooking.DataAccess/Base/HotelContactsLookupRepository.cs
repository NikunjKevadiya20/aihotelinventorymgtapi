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
    public class HotelContactLookupRepository : IHotelContactLookupRepositoryInterface
    {
        #region Global Variables
        private readonly IDbConnection _dbConnection;
        #endregion


        private readonly ILogger<HotelContactLookupRepository> logger;

        public HotelContactLookupRepository(ILogger<HotelContactLookupRepository> _logger, IDbConnection dbConnection)
        {
            logger = _logger;
            _dbConnection = dbConnection;
        }
        #region Insert HotelContact
        public async Task<HotelContactsViewEntity> InsertHotelContact(HotelContactDataEntity entity, string storedProcedure)
        {
            HotelContactsViewEntity result = new HotelContactsViewEntity();
            
            try
            {
                Dapper.DefaultTypeMap.MatchNamesWithUnderscores = true;
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@HotelID", entity.HotelID);
                dynamicParameters.Add("@ContactPersonName", entity.ContactPersonName);
                dynamicParameters.Add("@ContactPersonMobileNo", entity.ContactPersonMobileNo);
                dynamicParameters.Add("@ContactPersonEmailID", entity.ContactPersonEmailID);
                dynamicParameters.Add("@ContactPersonDesignation", entity.ContactPersonDesignation);
                dynamicParameters.Add("@CreatedBy", entity.CreatedBy);
                dynamicParameters.Add("@UpdatedBy", entity.UpdatedBy);
                dynamicParameters.Add("@DeletedBy", entity.DeletedBy);
                dynamicParameters.Add("@IsUser", entity.IsUser);
                dynamicParameters.Add("@IsUpdatedUser", entity.IsUpdatedUser);
                dynamicParameters.Add("@IsActive", entity.IsActive);
                dynamicParameters.Add("@OperationType", CommonRepositoryConstants.Insert);
                var data = await _dbConnection.QueryMultipleAsync(storedProcedure, dynamicParameters, commandType: System.Data.CommandType.StoredProcedure);

                var contactData = await data.ReadFirstAsync<HotelContactsViewEntity>();

                if (contactData.Message == "success")
                {
                    var hocoData = await data.ReadAsync<HotelContactEnityReq>();

                    HotelContactsViewEntity hotels = new HotelContactsViewEntity();
                    hotels = (HotelContactsViewEntity)contactData;
                    hotels.HotelContactList = hocoData;
                    return hotels;
                }
                else
                {
                    result.Message = Convert.ToString(contactData.Message);
                    result.Details = Convert.ToString(contactData.Details);
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

        #region Update HotelContact
        public async Task<HotelContactsViewEntity> UpdateHotelContact(HotelContactDataEntity entity, string storedProcedure)
        {
            HotelContactsViewEntity result = new HotelContactsViewEntity();
            
            try
            {
                Dapper.DefaultTypeMap.MatchNamesWithUnderscores = true;
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@ID", entity.ID);
                dynamicParameters.Add("@HotelID", entity.HotelID);
                dynamicParameters.Add("@ContactPersonName", entity.ContactPersonName);
                dynamicParameters.Add("@ContactPersonMobileNo", entity.ContactPersonMobileNo);
                dynamicParameters.Add("@ContactPersonEmailID", entity.ContactPersonEmailID);
                dynamicParameters.Add("@ContactPersonDesignation", entity.ContactPersonDesignation);
                dynamicParameters.Add("@CreatedBy", entity.CreatedBy);
                dynamicParameters.Add("@UpdatedBy", entity.UpdatedBy);
                dynamicParameters.Add("@DeletedBy", entity.DeletedBy);
                dynamicParameters.Add("@IsUser", entity.IsUser);
                dynamicParameters.Add("@IsUpdatedUser", entity.IsUpdatedUser);
                dynamicParameters.Add("@IsActive", entity.IsActive);
                dynamicParameters.Add("@OperationType", CommonRepositoryConstants.Update);
                var data = await _dbConnection.QueryMultipleAsync(storedProcedure, dynamicParameters, commandType: System.Data.CommandType.StoredProcedure);

                var contactData = await data.ReadFirstAsync<HotelContactsViewEntity>();

                if (contactData.Message == "success")
                {
                    var hocoData = await data.ReadAsync<HotelContactEnityReq>();

                    HotelContactsViewEntity hotels = new HotelContactsViewEntity();
                    hotels = (HotelContactsViewEntity)contactData;
                    hotels.HotelContactList = hocoData;
                    return hotels;
                }
                else
                {
                    result.Message = Convert.ToString(contactData.Message);
                    result.Details = Convert.ToString(contactData.Details);
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

        #region Delete HotelContact
        public async Task<ResultModel> DeleteHotelContact(HotelContactIDEntity entity, string storedProcedure)
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

        #region FindBy ID HotelContact
        public async Task<HotelContactViewEntity> FindByIDHotelContact(HotelContactIDEntity entity, string storedProcedure)
        {
            HotelContactViewEntity result = new HotelContactViewEntity();
            
            try
            {
                Dapper.DefaultTypeMap.MatchNamesWithUnderscores = true;
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@ID", entity.ID);
                dynamicParameters.Add("@OperationType", 26);
                var data = await _dbConnection.QueryMultipleAsync(storedProcedure, dynamicParameters, commandType: System.Data.CommandType.StoredProcedure);
                var HotelData = await data.ReadFirstAsync<HotelContactViewEntity>();
                if (HotelData.Message == "success")
                {
                    HotelContactViewEntity hotels = new HotelContactViewEntity();
                    hotels = (HotelContactViewEntity)HotelData;
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

        #region HotelContacts Find By HotelID by AI003 on 25-05-2024
        public async Task<HotelContactsViewEntity> FindByHotelIDContact(HotelContactIDEntity entity, string storedProcedure)
        {
            HotelContactsViewEntity result = new HotelContactsViewEntity();
            
            try
            {
                Dapper.DefaultTypeMap.MatchNamesWithUnderscores = true;
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@HotelID", entity.HotelID);
                dynamicParameters.Add("@OperationType", 27);
                var data = await _dbConnection.QueryMultipleAsync(storedProcedure, dynamicParameters, commandType: System.Data.CommandType.StoredProcedure);
                var HotelData = await data.ReadFirstAsync<HotelContactsViewEntity>();

                if (HotelData.Message == "success")
                {
                    var contactData = await data.ReadAsync<HotelContactEnityReq>();

                    HotelContactsViewEntity hotels = new HotelContactsViewEntity();
                    hotels = (HotelContactsViewEntity)HotelData;

                    hotels.HotelContactList = contactData;

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

        //#region Find All HotelContact
        //public async Task<List<HotelContactViewEntity>> FindAllActiveHotelContact(string storedProcedure)
        //{
        //    HotelContactViewEntity result = new HotelContactViewEntity();

        //    try
        //    {
        //        Dapper.DefaultTypeMap.MatchNamesWithUnderscores = true;
        //        DynamicParameters dynamicParameters = new DynamicParameters();
        //        dynamicParameters.Add("@OperationType", CommonRepositoryConstants.FindAllItems);
        //        var data = await _dbConnection.QueryAsync<HotelContactViewEntity>(storedProcedure, dynamicParameters, commandType: CommandType.StoredProcedure);
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

        #region Active InActive HotelContact
        public async Task<ResultModel> ActiveInActiveHotelContact(HotelContactIDEntity entity, string storedProcedure)
        {
            ResultModel result = new ResultModel();

            try
            {
                Dapper.DefaultTypeMap.MatchNamesWithUnderscores = true;
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@ID", entity.ID);
                dynamicParameters.Add("@IsActive", entity.IsActive);
                dynamicParameters.Add("@OperationType", 14);
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
