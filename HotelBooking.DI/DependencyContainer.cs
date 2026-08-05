using Microsoft.Extensions.DependencyInjection;
using HotelBooking.DataAccess.Base;
using HotelBooking.DataAccess.Interfaces;
using HotelBooking.DataAccess.Repositories;
using HotelBooking.Domain.Domain;
using HotelBooking.Domain.Domains;
using HotelBooking.Domain.Interfaces;

namespace HotelBooking.DI
{
    public class DependencyContainer
    {
        public static void RegisterServices(IServiceCollection services)
        {
            // Keep only services required by the user-specified features:
            // Room Availability Management, Ticket Availability Management,
            // Sold Out Dates, Room Price Management, Meal Type,
            // Amenities/Facility Master, Setting, Bookings, User Management,
            // AmountBaseGSTController

            // User Management
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserDomain, UserDomain>();
            services.AddScoped(typeof(IUserLookupRepositoryInterface), typeof(UserLookupRepository));

            services.AddScoped<IUserTypeRepository, UserTypeRepository>();
            services.AddScoped<IUserTypeDomain, UserTypeDomain>();
            services.AddScoped(typeof(IUserTypeLookupRepositoryInterface), typeof(UserTypeLookupRepository));

            services.AddScoped<IUserLoginRepository, UserLoginRepository>();
            services.AddScoped<IUserLoginDomain, UserLoginDomain>();
            services.AddScoped(typeof(IUserLoginLookupRepositoryInterface), typeof(UserLoginLookupRepository));

            // Bookings
            services.AddScoped<IBookingRepository, BookingRepository>();
            services.AddScoped<IBookingDomain, BookingDomain>();
            services.AddScoped(typeof(IBookingLookupRepositoryInterface), typeof(BookingLookupRepository));

        
            // Meal Type
            services.AddScoped<IMealTypeRepository, MealTypeRepository>();
            services.AddScoped<IMealTypeDomain, MealTypeDomain>();
            services.AddScoped(typeof(IMealTypeLookupRepositoryInterface), typeof(MealTypeLookupRepository));

            // Amenities/Facility Master
            services.AddScoped<IAmenitiesRepository, AmenitiesRepository>();
            services.AddScoped<IAmenitiesDomain, AmenitiesDomain>();
            services.AddScoped(typeof(IAmenitiesLookupRepositoryInterface), typeof(AmenitiesLookupRepository));

            // Setting
            services.AddScoped<ISettingRepository, SettingRepository>();
            services.AddScoped<ISettingDomain, SettingDomain>();
            services.AddScoped(typeof(ISettingLookupRepositoryInterface), typeof(SettingLookupRepository));

            // Room Availability Management
            services.AddScoped<IHotelRoomcatgeoryRepository, HotelRoomcatgeoryRepository>();
            services.AddScoped<IHotelRoomcatgeoryDomain, HotelRoomcatgeoryDomain>();
            services.AddScoped<IHotelRoomcatgeoryLookupRepositoryInterface, HotelRoomcatgeoryLookupRepository>();

            // Room Price Management
            services.AddScoped<IHotelSpecialRateRepository, HotelSpecialRateRepository>();
            services.AddScoped<IHotelSpecialRateDomain, HotelSpecialRateDomain>();
            services.AddScoped<IHotelSpecialRateLookupRepositoryInterface, HotelSpecialRateLookupRepository>();
       
 
            // Amount Base GST
            services.AddScoped<IAmountBaseGSTRepository, AmountBaseGSTRepository>();
            services.AddScoped<IAmountBaseGSTDomain, AmountBaseGSTDomain>();
            services.AddScoped(typeof(IAmountBaseGSTLookupRepositoryInterface), typeof(AmountBaseGSTLookupRepository));
      
            
            services.AddScoped<IHotelProfileRepository, HotelProfileRepository>();
            services.AddScoped<IHotelProfileDomain, HotelProfileDomain>();
            services.AddScoped(typeof(IHotelProfileLookupRepositoryInterface), typeof(HotelProfileLookupRepository));

            services.AddScoped<IRoomTypeRepository, RoomTypeRepository>();
            services.AddScoped<IRoomTypeDomain, RoomTypeDomain>();
            services.AddScoped(typeof(IRoomTypeLookupRepositoryInterface), typeof(RoomTypeLookupRepository));

            services.AddScoped<ITicketAttractionsRepository, TicketAttractionsRepository>();
            services.AddScoped<ITicketAttractionsDomain, TicketAttractionsDomain>();
            services.AddScoped(typeof(ITicketAttractionsLookupRepositoryInterface), typeof(TicketAttractionsLookupRepository));

            services.AddScoped<IMenuRepository, MenuRepository>();
            services.AddScoped<IMenuDomain, MenuDomain>();
            services.AddScoped(typeof(IMenuLookupRepositoryInterface), typeof(MenuLookupRepository));

            services.AddScoped<IRightsRepository, RightsRepository>();
            services.AddScoped<IRightsDomain, RightsDomain>();
            services.AddScoped(typeof(IRightsLookupRepositoryInterface), typeof(RightsLookupRepository));

            services.AddScoped<IHotelsRepository, HotelsRepository>();
            services.AddScoped<IHotelsDomain, HotelsDomain>();
            services.AddScoped(typeof(IHotelsLookupRepositoryInterface), typeof(HotelsLookupRepository));

            services.AddScoped<ISOUTicketRepository, SOUTicketRepository>();
            services.AddScoped<ISOUTicketDomain, SOUTicketDomain>();
            services.AddScoped(typeof(ISOUTicketLookupRepositoryInterface), typeof(SOUTicketLookupRepository));

            services.AddScoped<IOfferRepository, OfferRepository>();
            services.AddScoped<IOfferDomain, OfferDomain>();
            services.AddScoped(typeof(IOfferLookupRepositoryInterface), typeof(OfferLookupRepository));

            services.AddScoped<IAmenitiesTypeRepository, AmenitiesTypeRepository>();
            services.AddScoped<IAmenitiesTypeDomain, AmenitiesTypeDomain>();
            services.AddScoped(typeof(IAmenitiesTypeLookupRepositoryInterface), typeof(AmenitiesTypeLookupRepository));

            services.AddScoped <ICompanyProfileRepository, CompanyProfileRepository>();
            services.AddScoped<ICompanyProfileDomain, CompanyProfileDomain>();
            services.AddScoped(typeof(ICompanyProfileLookupRepositoryInterface), typeof(CompanyProfileLookupRepository));

        }

    }
    
}