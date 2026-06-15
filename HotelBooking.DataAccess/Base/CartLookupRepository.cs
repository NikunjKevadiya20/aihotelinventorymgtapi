using DapperParameters;
using Dapper;
using Dapper;
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
    public class CartLookupRepository : ICartLookupRepositoryInterface
    {
        #region Global Variables
        private readonly IDbConnection _dbConnection;
        private readonly ILogger<CartLookupRepository> logger;
        #endregion

        public CartLookupRepository(ILogger<CartLookupRepository> _logger, IDbConnection dbConnection)
        {
            logger = _logger;
            _dbConnection = dbConnection;
        }

        public async Task<ResultModel> InsertCartPaxDetails(CartEntity entity, string storedProcedure)
        {
            ResultModel result = new ResultModel();
            try
            {
                Dapper.DefaultTypeMap.MatchNamesWithUnderscores = true;
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@SessionID", entity.SessionID);
                if (entity.TicketPax != null && entity.TicketPax.Any())
                {
                    dynamicParameters.AddTable("@CartPaxDetails", "UDTTCartPaxDetails", entity.TicketPax.ToList());
                }
                    dynamicParameters.Add("@operationtype", 1);

                var data = await _dbConnection.QueryAsync(storedProcedure, dynamicParameters, commandType: CommandType.StoredProcedure);
                var first = data.FirstOrDefault();
                if (first != null)
                {
                    result.ID = first.ID;
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

        public async Task<ResultModel> UpdateCartPaxDetails(CartEntity entity, string storedProcedure)
        {
            ResultModel result = new ResultModel();
            try
            {
                Dapper.DefaultTypeMap.MatchNamesWithUnderscores = true;
                DynamicParameters dynamicParameters = new DynamicParameters();

                dynamicParameters.Add("@operationtype", 2);

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

        public async Task<ResultModel> DeleteCartPaxDetails(CartIDEntity entity, string storedProcedure)
        {
            ResultModel result = new ResultModel();
            try
            {
                Dapper.DefaultTypeMap.MatchNamesWithUnderscores = true;
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@ID", entity.ID);
                dynamicParameters.Add("@operationtype", 4);

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

        public async Task<CartEntity> FindByIDCartPaxDetails(CartIDEntity entity, string storedProcedure)
        {
            try
            {
                Dapper.DefaultTypeMap.MatchNamesWithUnderscores = true;

                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@SessionID", entity.SessionID);
                dynamicParameters.Add("@OperationType", 3);

                var data = await _dbConnection.QueryAsync<CartPaxDataEntity>(
                    storedProcedure,
                    dynamicParameters,
                    commandType: CommandType.StoredProcedure
                );
                bool hasData = data.Any();
                CartEntity result = new CartEntity
                {
                    SessionID = entity.SessionID,
                    TicketPax = data.ToList(),
                    Message = hasData ? "success" : "failure",
                    Details = hasData
                ? "Pax Details found successfully"
                : "No Pax Details found"
                };

                return result;
            }
            catch (SqlException sqlException)
            {
                logger.LogError(sqlException, sqlException.Message);
                throw;
            }
            catch (Exception)
            {
                throw;
            }
        }

        #region AddToCart/DeleteCart using sp_ManageCart
        public async Task<ResultModel> AddToCart(CartDataEntity entity, string storedProcedure)
        {
            ResultModel result = new ResultModel();
            try
            {
                Dapper.DefaultTypeMap.MatchNamesWithUnderscores = true;
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@SessionID", entity.SessionID);
                dynamicParameters.Add("@CartType", entity.CartType);

                // Hotel params
                dynamicParameters.Add("@HotelID", entity.HotelID);
                dynamicParameters.Add("@RoomCategoryID", entity.RoomCategoryID);
                dynamicParameters.Add("@CheckIn", entity.CheckIn);
                dynamicParameters.Add("@CheckOut", entity.CheckOut);
                dynamicParameters.Add("@Night", entity.Night);
                dynamicParameters.Add("@Rooms", entity.Rooms);
                dynamicParameters.Add("@Adults", entity.Adults);
                dynamicParameters.Add("@Child", entity.Child);
                dynamicParameters.Add("@ExtraAdult", entity.ExtraAdult);
                dynamicParameters.Add("@ExtraChild", entity.ExtraChild);
                dynamicParameters.Add("@MealPlanID", entity.MealPlanID);
                dynamicParameters.Add("@TotalChildSevenYr", entity.TotalChildSevenYr);
                dynamicParameters.Add("@TotalChildThreeYr", entity.TotalChildThreeYr);
                dynamicParameters.Add("@TotalAdults", entity.TotalAdults);

                // Ticket params
                dynamicParameters.Add("@TicketID", entity.TicketID);
                dynamicParameters.Add("@VisitDate", entity.VisitDate);
                dynamicParameters.Add("@ProjectionMappingID", entity.ProjectionMappingID);
                dynamicParameters.Add("@TimeSlotID", entity.TimeSlotID);

                dynamicParameters.Add("@operationtype", 1);

                if (entity.TicketPax != null && entity.TicketPax.Any())
                    dynamicParameters.AddTable<CartPaxEntity>("@TicketPax", "TicketPaxType", entity.TicketPax);

                var data = await _dbConnection.QueryAsync(storedProcedure, dynamicParameters, commandType: CommandType.StoredProcedure);
                var first = data.FirstOrDefault();
                if (first != null)
                {
                    result.ID = first.ID;
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

        public async Task<ResultModel> DeleteCart(CartDataEntity entity, string storedProcedure)
        {
            ResultModel result = new ResultModel();
            try
            {
                Dapper.DefaultTypeMap.MatchNamesWithUnderscores = true;
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@ID", entity.ID);
                dynamicParameters.Add("@CartType", entity.CartType);
                dynamicParameters.Add("@operationtype", 2);

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

        public async Task<CartDetailsResponseEntity> GetCartDetails(CartDetailsRequestEntity entity, string storedProcedure)
        {
            CartDetailsResponseEntity response = new CartDetailsResponseEntity();
            try
            {

                Dapper.DefaultTypeMap.MatchNamesWithUnderscores = true;
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@SessionID", entity.SessionID);
                dynamicParameters.Add("@operationtype", 1);

                var multi = await _dbConnection.QueryMultipleAsync(storedProcedure, dynamicParameters, commandType: CommandType.StoredProcedure);

                var hotelCart = (await multi.ReadAsync<CartHotelEntity>()).ToList();
                var RoomCategory = (await multi.ReadAsync<RoomCategoryImageViewEntity>()).ToList();
                var ticketCart = (await multi.ReadAsync<CartTicketEntity>()).ToList();
                var paxList = (await multi.ReadAsync<CartTicketPaxEntity>()).ToList();
                var ViewingGallery = (await multi.ReadAsync<ViewingGalleryEntity>()).ToList();
                var ProjectionMapping = (await multi.ReadAsync<ViewingGalleryEntity>()).ToList();
                var CartPaxDetails = (await multi.ReadAsync<CartPaxDetailsEntity>()).ToList();
                response.HotelBookingTicketSoldOutDateforpax = (await multi.ReadAsync<HotelBookingTicketPaxSoldOutDateViewEntity>()).ToList();
                var AttractionTicket = (await multi.ReadAsync<AttractionTicket>()).ToList();
                var AttractionTicketChild = (await multi.ReadAsync<AttractionTicketChild>()).ToList();
                var VisitDate = (await multi.ReadAsync<VisitDateEntity>()).ToList();



                // Map pax to ticket cart
                foreach (var ticket in ticketCart)
                {
                    ticket.TicketPaxDetails = paxList.Where(x => x.TicketCartID == ticket.CartID).ToList();
                }
                foreach (var ticket in ticketCart)
                {
                    ticket.ViewingGallery = ViewingGallery.Where(x => x.TicketID == ticket.TicketID).ToList();
                }
                foreach (var ticket in ticketCart)
                {
                    ticket.ProjectionMapping = ProjectionMapping
                       .Where(x => x.TicketID == ticket.TicketID)
                       .ToList();
                }
                foreach (var hotelcart in hotelCart)
                {
                    hotelcart.RoomCategory = RoomCategory
                       .Where(x => x.HotelID == hotelcart.HotelID)
                       .ToList();
                }
                foreach (var ticket in AttractionTicket)
                {
                    ticket.AttractionTicketChild = AttractionTicketChild.Where(x => x.AttractionID == ticket.ID).ToList();
                }

                foreach (var ticket in ticketCart)
                {
                    ticket.AttractionTicket = AttractionTicket
                        .Where(x => x.TicketID == ticket.TicketID)
                        .ToList();
                }

                response.HotelCart = hotelCart;
                response.TicketCart = ticketCart;
                response.CartPaxDetails = CartPaxDetails;
          
                 response.VisitDate = VisitDate;

            }
            catch (SqlException sqlException)
            {
                logger.LogError(sqlException, sqlException.Message);
                response.Message = CommonRepositoryMessages.CannotFindAllMessage;
                response.Details = CommonRepositoryMessages.CannotFindAllDetails;
                throw;
            }
            catch (Exception ex)
            {
                response.Message = CommonRepositoryMessages.ExceptionMessage;
                response.Details = ex.Message;
                throw;
            }

            return response;
        }

        public async Task<ResultModel> UpdateTicketQuantity(CartDataEntity entity, string storedProcedure)
        {
            ResultModel result = new ResultModel();
            try
            {
                Dapper.DefaultTypeMap.MatchNamesWithUnderscores = true;
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@SessionID", entity.SessionID);
                dynamicParameters.Add("@TicketID", entity.TicketID);
                dynamicParameters.Add("@TotalChildSevenYr", entity.TotalChildSevenYr);
                dynamicParameters.Add("@TotalChildThreeYr", entity.TotalChildThreeYr);
                dynamicParameters.Add("@TotalAdults", entity.TotalAdults);
                dynamicParameters.Add("@VisitDate", entity.VisitDate);
                dynamicParameters.Add("@ProjectionMappingID", entity.ProjectionMappingID);
                dynamicParameters.Add("@TimeSlotID", entity.TimeSlotID);
                dynamicParameters.Add("@operationtype", 3);

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

        public async Task<ResultModel> UpdateHotelQuantity(CartDataEntity entity, string storedProcedure)
        {
            ResultModel result = new ResultModel();
            try
            {
                Dapper.DefaultTypeMap.MatchNamesWithUnderscores = true;
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@SessionID", entity.SessionID);
                dynamicParameters.Add("@HotelID", entity.HotelID);
                dynamicParameters.Add("@RoomCategoryID", entity.RoomCategoryID);
                dynamicParameters.Add("@CheckIn", entity.CheckIn);
                dynamicParameters.Add("@CheckOut", entity.CheckOut);
                dynamicParameters.Add("@Night", entity.Night);
                dynamicParameters.Add("@Rooms", entity.Rooms);
                dynamicParameters.Add("@Adults", entity.Adults);
                dynamicParameters.Add("@Child", entity.Child);
                dynamicParameters.Add("@ExtraAdult", entity.ExtraAdult);
                dynamicParameters.Add("@MealPlanID", entity.MealPlanID);
               
                dynamicParameters.Add("@operationtype", 4);

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
