using Dapper;
using HotelBooking.Entity.Common;
using HotelBooking.Entity.Common.Entities;
using HotelBooking.Entity.Common.Enums;
using HotelBooking.Entity.Entities;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Microsoft.Extensions.Logging;
using System.Data;
using System.Data.SqlClient;


namespace HotelBooking.DataAccess.Base
{
    public class CompanyProfileLookupRepository : ICompanyProfileLookupRepositoryInterface
    {
        private readonly IDbConnection _dbConnection;
        private readonly ILogger<CompanyProfileLookupRepository> _logger;
        public CompanyProfileLookupRepository(ILogger<CompanyProfileLookupRepository> logger, IDbConnection dbConnection)
        {
            _logger = logger;
            _dbConnection = dbConnection;
        }
        public async Task<ResultModel> InsertCompanyProfile(CompanyProfile entity, string storedProcedure)
        {
            ResultModel result = new ResultModel();
            try
            {
                Dapper.DefaultTypeMap.MatchNamesWithUnderscores = true;
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@Manager", entity.Manager);
                dynamicParameters.Add("@HotelEmail", entity.HotelEmail);
                dynamicParameters.Add("@ReservationsManager", entity.ReservationsManager);
                dynamicParameters.Add("@ReservationsEmail", entity.ReservationsEmail);
                dynamicParameters.Add("@ReservationsTelephone", entity.ReservationsTelephone);
                dynamicParameters.Add("@IsDisableBookingEmails", entity.IsDisableBookingEmails);
                dynamicParameters.Add("@SalesManager", entity.SalesManager);
                dynamicParameters.Add("@AccountsManager", entity.AccountsManager);
                dynamicParameters.Add("@CancellationPolicyName", entity.CancellationPolicyName);
                dynamicParameters.Add("@CancellationTerm", entity.CancellationTerm);
                dynamicParameters.Add("@CutOffType", entity.CutOffType);
                dynamicParameters.Add("@CutOffDays", entity.CutOffDays);
                dynamicParameters.Add("@CutOffTime", entity.CutOffTime);
                dynamicParameters.Add("@PenaltyType", entity.PenaltyType);
                dynamicParameters.Add("@PenaltyValue", entity.PenaltyValue);
                dynamicParameters.Add("@StayType", entity.StayType);
                dynamicParameters.Add("@CancellationDescription", entity.CancellationDescription);
                dynamicParameters.Add("@ChildPolicyFromAge", entity.ChildPolicyFromAge);
                dynamicParameters.Add("@ChildPolicyToAge", entity.ChildPolicyToAge);
                dynamicParameters.Add("@ChildPolicyDescription", entity.ChildPolicyDescription);
                dynamicParameters.Add("@MetaKeywords", entity.MetaKeywords);
                dynamicParameters.Add("@PrivacyStatement", entity.PrivacyStatement);
                dynamicParameters.Add("@ExtraBedPolicy", entity.ExtraBedPolicy);
                dynamicParameters.Add("@TermsAndConditionsType", entity.TermsAndConditionsType);
                dynamicParameters.Add("@TermsAndConditionsUrl", entity.TermsAndConditionsUrl);
                dynamicParameters.Add("@TermsAndConditionsText", entity.TermsAndConditionsText);
                dynamicParameters.Add("@CreditCardTerms", entity.CreditCardTerms);
                dynamicParameters.Add("@IsCloseOutTime", entity.IsCloseOutTime);
                dynamicParameters.Add("@CheckInTime", entity.CheckInTime);
                dynamicParameters.Add("@CheckOutTime", entity.CheckOutTime);
                dynamicParameters.Add("@EstimatedArrivalFrom", entity.EstimatedArrivalFrom);
                dynamicParameters.Add("@EstimatedArrivalTo", entity.EstimatedArrivalTo);
                dynamicParameters.Add("@CheckInDescription", entity.CheckInDescription);
                dynamicParameters.Add("@PaymentTermsType", entity.PaymentTermsType);
                dynamicParameters.Add("@PaymentTermsHeading", entity.PaymentTermsHeading);
                dynamicParameters.Add("@PaymentTermsDescription", entity.PaymentTermsDescription);
                dynamicParameters.Add("@PrivacyPolicyType", entity.PrivacyPolicyType);
                dynamicParameters.Add("@PrivacyPolicyUrl", entity.PrivacyPolicyUrl);
                dynamicParameters.Add("@PrivacyPolicyText", entity.PrivacyPolicyText);
                dynamicParameters.Add("@StreetAddress", entity.StreetAddress);
                dynamicParameters.Add("@MapLink", entity.MapLink);
                dynamicParameters.Add("@LocationSuburb", entity.LocationSuburb);
                dynamicParameters.Add("@Country", entity.Country);
                dynamicParameters.Add("@State", entity.State);
                dynamicParameters.Add("@City", entity.City);
                dynamicParameters.Add("@PostalCode", entity.PostalCode);
                dynamicParameters.Add("@Latitude", entity.Latitude);
                dynamicParameters.Add("@Longitude", entity.Longitude);
                dynamicParameters.Add("@Telephone", entity.Telephone);
                dynamicParameters.Add("@Fax", entity.Fax);
                dynamicParameters.Add("@PropertyName", entity.PropertyName);
                dynamicParameters.Add("@MaxId", entity.MaxId);
                dynamicParameters.Add("@PropertyDescription", entity.PropertyDescription);
                dynamicParameters.Add("@AdministratorEmail", entity.AdministratorEmail);
                dynamicParameters.Add("@WhatsAppCountryCode", entity.WhatsAppCountryCode);
                dynamicParameters.Add("@WhatsAppMobileNumber", entity.WhatsAppMobileNumber);
                dynamicParameters.Add("@PropertyType", entity.PropertyType);
                dynamicParameters.Add("@Website", entity.Website);
                dynamicParameters.Add("@SecondaryDomains", entity.SecondaryDomains);
                dynamicParameters.Add("@Currency", entity.Currency);
                dynamicParameters.Add("@StarRating", entity.StarRating);
                dynamicParameters.Add("@WeekEndNights", entity.WeekEndNights);
                dynamicParameters.Add("@IsActive", entity.IsActive);
                dynamicParameters.Add("@CreatedBy", entity.CreatedBy);
                dynamicParameters.Add("@UpdatedBy", entity.UpdatedBy);
                dynamicParameters.Add("@IsDeleted", entity.IsDeleted);
                dynamicParameters.Add("@OperationType", CommonRepositoryConstants.Insert);
                var data = await _dbConnection.QueryAsync(storedProcedure, dynamicParameters, commandType: CommandType.StoredProcedure);
                result.Message = data.FirstOrDefault().Message;
                result.Details = data.FirstOrDefault().Details;
            }
            catch (SqlException sqlException)
            {
                _logger.LogError(sqlException, sqlException.Message);
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
            return result;
        }
        public async Task<CompanyProfile> GetCompanyProfile(string storedProcedure)
        {
            CompanyProfile result = new CompanyProfile();
            try
            {
                Dapper.DefaultTypeMap.MatchNamesWithUnderscores = true;
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@OperationType", 3);
                var data = await _dbConnection.QuerySingleOrDefaultAsync<CompanyProfile>(storedProcedure, dynamicParameters, commandType: CommandType.StoredProcedure);
                return data;
            }
            catch (SqlException sqlException)
            {
                _logger.LogError(sqlException, sqlException.Message);
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


        #region Experience Image Update
        public async Task<ResultModel> CompanyProfileImageUpdate(string? Image,  int? UpdatedBy, string storedProcedure)
        {
            ResultModel result = new ResultModel();

            try
            {
                DynamicParameters parameters = new DynamicParameters();
                 
                parameters.Add("@Image", Image);
                parameters.Add("@UpdatedBy", UpdatedBy);
                parameters.Add("@OperationType", 4);

                var data = await _dbConnection.QueryAsync(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
                result.Message = data.FirstOrDefault().Message;
                result.Details = data.FirstOrDefault().Details;
                return result;
            }
            catch (SqlException ex)
            {
                 
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
    }
}
