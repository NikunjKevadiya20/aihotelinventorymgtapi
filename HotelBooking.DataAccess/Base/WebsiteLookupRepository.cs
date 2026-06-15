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
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace HotelBooking.DataAccess.Base
{
    public class WebsiteLookupRepository : IWebsiteLookupRepositoryInterface
    {
        #region Global Variables
        private readonly IDbConnection _dbConnection;
        #endregion

        private readonly ILogger<WebsiteLookupRepository> logger;


        public WebsiteLookupRepository(ILogger<WebsiteLookupRepository> _logger, IDbConnection dbConnection)
        {
            logger = _logger;
            _dbConnection = dbConnection;
        }

        public async Task<HomePageData> HomePageList(string storedProcedure)
        {
            HomePageData result = new HomePageData();

            try
            {
                Dapper.DefaultTypeMap.MatchNamesWithUnderscores = true;
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@OperationType", 1);
                var data = await _dbConnection.QueryMultipleAsync(storedProcedure, dynamicParameters, commandType: CommandType.StoredProcedure);


                var banner = (await data.ReadAsync<HomePageBannerData>()).ToList();
                result.Banner = banner;


                if (banner.Any())
                {
                    result.Message = banner.First().Message;
                    result.Details = banner.First().Details;
                }
                var Hotel = (await data.ReadAsync<HomePageHotel>()).ToList();


                var facilities = (await data.ReadAsync<HotelFacility>()).ToList();

                foreach (var hotel in Hotel)
                {
                    if (!string.IsNullOrEmpty(hotel.HotelFacilityID))
                    {
                        var ids = hotel.HotelFacilityID.Split(',').Select(int.Parse).ToList();

                        hotel.Facilities = facilities
                            .Where(f => ids.Contains(f.ID))
                            .ToList();
                    }
                }

                result.Hotel = Hotel;

                var HotelBookingTicket = (await data.ReadAsync<HomePageHotelBookingTicket>()).ToList();

                var HotelBookingTicketDetails = (await data.ReadAsync<HotelBookingTicketDetailsdataEntity>()).ToList();
                var HotelBookingTicketImage = (await data.ReadAsync<HotelBookingTicketImagedataEntity>()).ToList();

                foreach (var HotelBookingTickets in HotelBookingTicket)
                {
                    HotelBookingTickets.HotelBookingTicketDetails = HotelBookingTicketDetails
                        .Where(img => img.HotelBookingTicketID == HotelBookingTickets.ID)
                        .ToList();
                }
                foreach (var HotelBookingTickets in HotelBookingTicket)
                {
                    HotelBookingTickets.HotelBookingTicketImage = HotelBookingTicketImage
                        .Where(img => img.HotelBookingTicketID == HotelBookingTickets.ID)
                        .ToList();
                }

                result.HotelBookingTicket = HotelBookingTicket;

                var Atrraction = (await data.ReadAsync<HomePageAtrraction>()).ToList();
                result.Atrraction = Atrraction;


                var Tour = (await data.ReadAsync<HomePageTour>()).ToList();
                result.Tour = Tour;

                var Testimonials = (await data.ReadAsync<HomePageTestimonials>()).ToList();
                result.Testimonials = Testimonials;

                var CMSList = (await data.ReadAsync<HomePageCMSData>()).ToList();
                result.CMSList = CMSList;

                var Seotag = (await data.ReadAsync<HomePageSeotag>()).ToList();
                result.Seotag = Seotag;

                var Blog = (await data.ReadAsync<HomePageBlog>()).ToList();
                result.Blog = Blog;

                var HotelBookingPackage = (await data.ReadAsync<HomeHotelBookingPackage>()).ToList();
                var HotelBookingPackagePrice = (await data.ReadAsync<HomeHotelBookingPackagePrice>()).ToList();
                foreach (var HotelBookingPackages in HotelBookingPackage)
                {
                    HotelBookingPackages.HotelBookingPackagePrice = HotelBookingPackagePrice
                        .Where(img => img.HotelBookingPackageID == HotelBookingPackages.ID)
                        .ToList();
                }


                result.HotelBookingPackage = HotelBookingPackage;

              

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

        public async Task<List<HomePageHotelBookingTicket>> FindAllSAOUTicketList(string storedProcedure)
        {
            HomePageHotelBookingTicket result = new HomePageHotelBookingTicket();

            try
            {
                Dapper.DefaultTypeMap.MatchNamesWithUnderscores = true;
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@OperationType", 2);
                var data = await _dbConnection.QueryMultipleAsync(storedProcedure, dynamicParameters, commandType: CommandType.StoredProcedure);
                var HotelBookingTicket = (await data.ReadAsync<HomePageHotelBookingTicket>()).ToList();
                var HotelBookingTicketDetails = (await data.ReadAsync<HotelBookingTicketDetailsdataEntity>()).ToList();
                var HotelBookingTicketImage = (await data.ReadAsync<HotelBookingTicketImagedataEntity>()).ToList();
                var HotelBookingTicketSoldOutDate = (await data.ReadAsync<HotelBookingTicketSoldOutDatedataEntity>()).ToList();

                foreach (var ticket in HotelBookingTicket)
                {
                    ticket.HotelBookingTicketDetails = HotelBookingTicketDetails
                        .Where(img => img.HotelBookingTicketID == ticket.ID)
                        .ToList();
                }

                foreach (var HotelBookingTickets in HotelBookingTicket)
                {
                    HotelBookingTickets.HotelBookingTicketImage = HotelBookingTicketImage
                        .Where(img => img.HotelBookingTicketID == HotelBookingTickets.ID)
                        .ToList();
                }
                foreach (var HotelBookingTickets in HotelBookingTicket)
                {
                    HotelBookingTickets.HotelBookingTicketSoldOutDate = HotelBookingTicketSoldOutDate
                        .Where(img => img.HotelBookingTicketID == HotelBookingTickets.ID)
                        .ToList();
                }

                return HotelBookingTicket;



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

        public async Task<TourUrlEntity> TourDetailsByURL(TourByURLEntity entity, string storedProcedure)
        {
            TourUrlEntity result = new TourUrlEntity();

            try
            {
                Dapper.DefaultTypeMap.MatchNamesWithUnderscores = true;
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@TourURL", entity.TourURL);
                dynamicParameters.Add("@OperationType", 5);
                var data = await _dbConnection.QueryMultipleAsync(storedProcedure, dynamicParameters, commandType: CommandType.StoredProcedure);

                var tour = await data.ReadFirstOrDefaultAsync<TourUrlEntity>();
                if (tour == null) return null;


                tour.Innerimage = (await data.ReadAsync<WeddingInnserimageEntity>()).ToList();


                tour.TourItinerary = (await data.ReadAsync<TourItineraryEntity>()).ToList();
                tour.TourCost = (await data.ReadAsync<TourCostEntity>()).ToList();
                tour.VideoGallery = (await data.ReadAsync<VideoGalleryViewEntity>()).ToList();
                tour.FAQ = (await data.ReadAsync<FAQDataViewEntity>()).ToList();
 
                return tour;

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

        #region Analytics Count
        public async Task<AnalyticsCountViewEntity> FindAnalyticsCount(AnalyticsCountEntity entity, string storedProcedure)
        {
            AnalyticsCountViewEntity result = new AnalyticsCountViewEntity();

            try
            {
                Dapper.DefaultTypeMap.MatchNamesWithUnderscores = true;
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@URL", entity.URL);
                dynamicParameters.Add("@OperationType", 1);
                var data = await _dbConnection.QuerySingleOrDefaultAsync<AnalyticsCountViewEntity>(storedProcedure, dynamicParameters, commandType: CommandType.StoredProcedure);
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

        #region Insert Booking Reference
        public async Task<ResultModel> InsertBookingReference(BookingReferenceEntity entity, string storedProcedure)
        {
            ResultModel result = new ResultModel();

            try
            {
                Dapper.DefaultTypeMap.MatchNamesWithUnderscores = true;
                DynamicParameters dynamicParameters = new DynamicParameters();

                dynamicParameters.Add("@RoomID", entity.RoomID);
                dynamicParameters.Add("@URL", entity.URL);
                dynamicParameters.Add("@City", entity.City);
                dynamicParameters.Add("@State", entity.State);
                dynamicParameters.Add("@Country", entity.Country);
                dynamicParameters.Add("@IP", entity.IP);
                dynamicParameters.Add("@Pincode", entity.Pincode);
                dynamicParameters.Add("@Latitude", entity.Latitude);
                dynamicParameters.Add("@Longitude", entity.Longitude);
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

        #region Find All Booking Reference
        public async Task<List<BookingReferenceViewEntity>> FindAllBookingReference(BookingReferenceEntity entity, string storedProcedure)
        {
            BookingReferenceViewEntity result = new BookingReferenceViewEntity();

            try
            {
                Dapper.DefaultTypeMap.MatchNamesWithUnderscores = true;
                DynamicParameters dynamicParameters = new DynamicParameters();

                dynamicParameters.Add("@Skip", entity.Skip);
                dynamicParameters.Add("@Limit", entity.Limit);
                dynamicParameters.Add("@OperationType", 2);
                var data = await _dbConnection.QueryAsync<BookingReferenceViewEntity>(storedProcedure, dynamicParameters, commandType: CommandType.StoredProcedure);
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
