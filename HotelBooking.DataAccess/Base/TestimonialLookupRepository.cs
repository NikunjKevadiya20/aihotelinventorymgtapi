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
    public class TestimonialLookupRepository : ITestimonialLookupRepositoryInterface
    {
        #region Global Variables
        private readonly IDbConnection _dbConnection;
        private readonly ILogger<TestimonialLookupRepository> logger;
        #endregion

        public TestimonialLookupRepository(ILogger<TestimonialLookupRepository> _logger, IDbConnection dbConnection)
        {
            logger = _logger;
            _dbConnection = dbConnection;
        }

        #region Insert Testimonial
        public async Task<TestimonialIDViewEntity> InsertTestimonial(TestimonialEntity entity, string storedProcedure)
        {
            TestimonialIDViewEntity result = new TestimonialIDViewEntity();
            try
            {
                Dapper.DefaultTypeMap.MatchNamesWithUnderscores = true;
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@CustomerName", entity.CustomerName);
                dynamicParameters.Add("@Description", entity.Description);
                dynamicParameters.Add("@UniversityName", entity.UniversityName);
                dynamicParameters.Add("@TestimonialURL", entity.TestimonialURL);
                dynamicParameters.Add("@IsActive", entity.IsActive);
                dynamicParameters.Add("@CreatedBy", entity.CreatedBy);
                dynamicParameters.Add("@OperationType", CommonRepositoryConstants.Insert);
                var data = await _dbConnection.QueryFirstOrDefaultAsync<TestimonialIDViewEntity>(storedProcedure, dynamicParameters, commandType: CommandType.StoredProcedure);
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

        #region Update Testimonial
        public async Task<ResultModel> UpdateTestimonial(TestimonialEntity entity, string storedProcedure)
        {
            ResultModel result = new ResultModel();
            try
            {
                Dapper.DefaultTypeMap.MatchNamesWithUnderscores = true;
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@ID", entity.ID);
                dynamicParameters.Add("@CustomerName", entity.CustomerName);
                dynamicParameters.Add("@Description", entity.Description);
                dynamicParameters.Add("@UniversityName", entity.UniversityName);
                dynamicParameters.Add("@TestimonialURL", entity.TestimonialURL);
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

        #region Delete Testimonial
        public async Task<ResultModel> DeleteTestimonial(TestimonialIDEntity entity, string storedProcedure)
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

        #region FindBy ID Testimonial
        public async Task<TestimonialDataViewEntity> FindByIDTestimonial(TestimonialIDEntity entity, string storedProcedure)
        {
            TestimonialDataViewEntity result = new TestimonialDataViewEntity();

            try
            {
                Dapper.DefaultTypeMap.MatchNamesWithUnderscores = true;
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@ID", entity.ID);
                dynamicParameters.Add("@OperationType", CommonRepositoryConstants.FindByID);
                var data = await _dbConnection.QuerySingleOrDefaultAsync<TestimonialDataViewEntity>(storedProcedure, dynamicParameters, commandType: CommandType.StoredProcedure);
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
        #region Find All Active Testimonial
        public async Task<List<TestimonialDataViewEntity>> FindAllTestimonial(TestimonialIDEntity entity, string storedProcedure)
        {
            TestimonialDataViewEntity result = new TestimonialDataViewEntity();

            try
            {
                Dapper.DefaultTypeMap.MatchNamesWithUnderscores = true;
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@CustomerName", entity.CustomerName);
                dynamicParameters.Add("@OperationType", CommonRepositoryConstants.FindAllItems);
                var data = await _dbConnection.QueryAsync<TestimonialDataViewEntity>(storedProcedure, dynamicParameters, commandType: CommandType.StoredProcedure);
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
        #region Find All Testimonial
        public async Task<List<TestimonialDataViewEntity>> FindAllActiveTestimonial(string storedProcedure)
        {
            TestimonialDataViewEntity result = new TestimonialDataViewEntity();

            try
            {
                Dapper.DefaultTypeMap.MatchNamesWithUnderscores = true;
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@OperationType", 5);
                var data = await _dbConnection.QueryAsync<TestimonialDataViewEntity>(storedProcedure, dynamicParameters, commandType: CommandType.StoredProcedure);
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
        #region Active InActive Testimonial
        public async Task<ResultModel> ActiveInActiveTestimonial(TestimonialIDEntity entity, string storedProcedure)
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

        #region banner Image Update
        public async Task<ResultModel> TestimonialImageUpdate(string? physicalFileName, int? ID, int? UpdatedBy, string storedProcedure)
        {
            ResultModel result = new ResultModel();
            try
            {
                Dapper.DefaultTypeMap.MatchNamesWithUnderscores = true;
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@ID", ID);
                dynamicParameters.Add("@Image", physicalFileName);
                dynamicParameters.Add("@UpdatedBy", UpdatedBy);
                dynamicParameters.Add("@OperationType", 3);

                var data = await _dbConnection.QueryAsync(storedProcedure, dynamicParameters, commandType: System.Data.CommandType.StoredProcedure);


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
            finally
            {
            }

        }
        #endregion

        #region Find All Active Testimonial URl Data
        public async Task<List<TestimonialDataViewEntity>> FindAllActiveTestimonialURL(TestimonialIDEntity entity, string storedProcedure)
        {
            TestimonialDataViewEntity result = new TestimonialDataViewEntity();

            try
            {
                Dapper.DefaultTypeMap.MatchNamesWithUnderscores = true;
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@TestimonialURL", entity.TestimonialURL);
                dynamicParameters.Add("@OperationType", 6);
                var data = await _dbConnection.QueryAsync<TestimonialDataViewEntity>(storedProcedure, dynamicParameters, commandType: CommandType.StoredProcedure);
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
