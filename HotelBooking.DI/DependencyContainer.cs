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

         
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserDomain, UserDomain>();
            services.AddScoped(typeof(IUserLookupRepositoryInterface), typeof(UserLookupRepository));

            services.AddScoped<IUserTypeRepository, UserTypeRepository>();
            services.AddScoped<IUserTypeDomain, UserTypeDomain>();
            services.AddScoped(typeof(IUserTypeLookupRepositoryInterface), typeof(UserTypeLookupRepository));

            services.AddScoped<IUserLoginRepository, UserLoginRepository>();
            services.AddScoped<IUserLoginDomain, UserLoginDomain>();
            services.AddScoped(typeof(IUserLoginLookupRepositoryInterface), typeof(UserLoginLookupRepository));

            services.AddScoped<IRightsRepository, RightsRepository>();
            services.AddScoped<IRightsDomain, RightsDomain>();
            services.AddScoped(typeof(IRightsLookupRepositoryInterface), typeof(RightsLookupRepository));

            services.AddScoped<IMenuRepository, MenuRepository>();
            services.AddScoped<IMenuDomain, MenuDomain>();
            services.AddScoped(typeof(IMenuLookupRepositoryInterface), typeof(MenuLookupRepository));

            services.AddScoped<IStateRepository, StateRepository>();
            services.AddScoped<IStateDomain, StateDomain>();
            services.AddScoped(typeof(IStateLookupRepositoryInterface), typeof(StateLookupRepository));

            services.AddScoped<ICityRepository, CityRepository>();
            services.AddScoped<ICityDomain, CityDomain>();
            services.AddScoped(typeof(ICityLookupRepositoryInterface), typeof(CityLookupRepository));

            services.AddScoped<ICountryRepository, CountryRepository>();
            services.AddScoped<ICountryDomain, CountryDomain>();
            services.AddScoped(typeof(ICountryLookupRepositoryInterface), typeof(CountryLookupRepository));

            services.AddScoped<IBlogRepository, BlogRepository>();
            services.AddScoped<IBlogDomain, BlogDomain>();
            services.AddScoped(typeof(IBlogLookupRepositoryInterface), typeof(BlogLookupRepository));

            services.AddScoped<ICMSRepository, CMSRepository>();
            services.AddScoped<ICMSDomain, CMSDomain>();
            services.AddScoped(typeof(ICMSLookupRepositoryInterface), typeof(CMSLookupRepository));

            services.AddScoped<ITestimonialRepository, TestimonialRepository>();
            services.AddScoped<ITestimonialDomain, TestimonialDomain>();
            services.AddScoped(typeof(ITestimonialLookupRepositoryInterface), typeof(TestimonialLookupRepository));

            services.AddScoped<ISeoTagsRepository, SeoTagsRepository>();
            services.AddScoped<ISeoTagsDomain, SeoTagsDomain>();
            services.AddScoped(typeof(ISeoTagsLookupRepositoryInterface), typeof(SeoTagsLookupRepository));


            services.AddScoped<IInquiryRepository, InquiryRepository>();
            services.AddScoped<IInquiryDomain, InquiryDomain>();
            services.AddScoped(typeof(IInquiryLookupRepositoryInterface), typeof(InquiryLookupRepository));

            services.AddScoped<IBannerRepository, BannerRepository>();
            services.AddScoped<IBannerDomain, BannerDomain>();
            services.AddScoped(typeof(IBannerLookupRepositoryInterface), typeof(BannerLookupRepository));

            services.AddScoped<ISettingRepository, SettingRepository>();
            services.AddScoped<ISettingDomain, SettingDomain>();
            services.AddScoped(typeof(ISettingLookupRepositoryInterface), typeof(SettingLookupRepository));

            services.AddScoped<IFAQRepository, FAQRepository>();
            services.AddScoped<IFAQDomain, FAQDomain>();
            services.AddScoped(typeof(IFAQLookupRepositoryInterface), typeof(FAQLookupRepository));

            services.AddScoped<IBlogFAQRepository, BlogFAQRepository>();
            services.AddScoped<IBlogFAQDomain, BlogFAQDomain>();
            services.AddScoped(typeof(IBlogFAQLookupRepositoryInterface), typeof(BlogFAQLookupRepository));

            services.AddScoped<IAttractionRepository, AttractionRepository>();
            services.AddScoped<IAttractionDomain, AttractionDomain>();
            services.AddScoped(typeof(IAttractionLookupRepositoryInterface), typeof(AttractionLookupRepository));

            services.AddScoped<IImageGalleryRepository, ImageGalleryRepository>();
            services.AddScoped<IImageGalleryDomain, ImageGalleryDomain>();
            services.AddScoped(typeof(IImageGalleryLookupRepositoryInterface), typeof(ImageGalleryLookupRepository));

            services.AddScoped<IAmenitiesRepository, AmenitiesRepository>();
            services.AddScoped<IAmenitiesDomain, AmenitiesDomain>();
            services.AddScoped(typeof(IAmenitiesLookupRepositoryInterface), typeof(AmenitiesLookupRepository));

            services.AddScoped<IHotelsRepository, HotelsRepository>();
            services.AddScoped<IHotelsDomain, HotelsDomain>();
            services.AddScoped(typeof(IHotelsLookupRepositoryInterface), typeof(HotelsLookupRepository));

            services.AddScoped<IItineraryRepository, ItineraryRepository>();
            services.AddScoped<IItineraryDomain, ItineraryDomain>();
            services.AddScoped(typeof(IItineraryLookupRepositoryInterface), typeof(ItineraryLookupRepository));
            
            services.AddScoped<IHotelBookingTicketRepository, HotelBookingTicketRepository>();
            services.AddScoped<IHotelBookingTicketDomain, HotelBookingTicketDomain>();
            services.AddScoped(typeof(IHotelBookingTicketLookupRepositoryInterface), typeof(HotelBookingTicketLookupRepository));
           
            // Cart Pax Details
            services.AddScoped<ICartRepository, CartRepository>();
            services.AddScoped<ICartDomain, CartDomain>();
            services.AddScoped(typeof(ICartLookupRepositoryInterface), typeof(CartLookupRepository));

            // Booking module (boilerplate)
            services.AddScoped<IBookingRepository, BookingRepository>();
            services.AddScoped<IBookingDomain, BookingDomain>();
            services.AddScoped(typeof(IBookingLookupRepositoryInterface), typeof(BookingLookupRepository));
            
            services.AddScoped<ITourRepository, TourRepository>();
            services.AddScoped<ITourDomain, TourDomain>();
            services.AddScoped(typeof(ITourLookupRepositoryInterface), typeof(TourLookupRepository));

            services.AddScoped<IHotelContactRepository, HotelContactRepository>();
            services.AddScoped<IHotelContactDomain, HotelContactDomain>();
            services.AddScoped(typeof(IHotelContactLookupRepositoryInterface), typeof(HotelContactLookupRepository));

            services.AddScoped<IHotelSpecialRateRepository, HotelSpecialRateRepository>();
            services.AddScoped<IHotelSpecialRateDomain, HotelSpecialRateDomain>();
            services.AddScoped(typeof(IHotelSpecialRateLookupRepositoryInterface), typeof(HotelSpecialRateLookupRepository));

            services.AddScoped<IHotelRoomcatgeoryRepository, HotelRoomcatgeoryRepository>();
            services.AddScoped<IHotelRoomcatgeoryDomain, HotelRoomcatgeoryDomain>();
            services.AddScoped(typeof(IHotelRoomcatgeoryLookupRepositoryInterface), typeof(HotelRoomcatgeoryLookupRepository));

            services.AddScoped<IFestivalsRepository, FestivalsRepository>();
            services.AddScoped<IFestivalsDomain, FestivalsDomain>();
            services.AddScoped(typeof(IFestivalsViewRepositoryInterface), typeof(FestivalsViewRepository));

            services.AddScoped<IMealTypeRepository, MealTypeRepository>();
            services.AddScoped<IMealTypeDomain, MealTypeDomain>();
            services.AddScoped(typeof(IMealTypeLookupRepositoryInterface), typeof(MealTypeLookupRepository));

            services.AddScoped<ISectorRepository, SectorRepository>();
            services.AddScoped<ISectorDomain, SectorDomain>();
            services.AddScoped(typeof(ISectorLookupRepositoryInterface), typeof(SectorLookupRepository));

            services.AddScoped<IRoomTypeRepository, RoomTypeRepository>();
            services.AddScoped<IRoomTypeDomain, RoomTypeDomain>();
            services.AddScoped(typeof(IRoomTypeLookupRepositoryInterface), typeof(RoomTypeLookupRepository));

            services.AddScoped<IVehicleSharingPaxRepository, VehicleSharingPaxRepository>();
            services.AddScoped<IVehicleSharingPaxDomain, VehicleSharingPaxDomain>();
            services.AddScoped(typeof(IVehicleSharingPaxLookupRepositoryInterface), typeof(VehicleSharingPaxLookupRepository));

            services.AddScoped<IItineraryFacilitiesRepository, ItineraryFacilitiesRepository>();
            services.AddScoped<IItineraryFacilitiesDomain, ItineraryFacilitiesDomain>();
            services.AddScoped(typeof(IItineraryFacilitiesViewRepositoryInterface), typeof(ItineraryFacilitiesViewRepository));

            services.AddScoped<IWebsiteRepository, WebsiteRepository>();
            services.AddScoped<IWebsiteDomain, WebsiteDomain>();
            services.AddScoped(typeof(IWebsiteLookupRepositoryInterface), typeof(WebsiteLookupRepository));

            services.AddScoped<IRegionRepository, RegionRepository>();
            services.AddScoped<IRegionDomain, RegionDomain>();
            services.AddScoped(typeof(IRegionLookupRepositoryInterface), typeof(RegionLookupRepository));
            
            services.AddScoped<IVehicleTypeRepository, VehicleTypeRepository>();
            services.AddScoped<IVehicleTypeDomain, VehicleTypeDomain>();
            services.AddScoped(typeof(IVehicleTypeLookupRepositoryInterface), typeof(VehicleTypeLookupRepository));

            services.AddScoped<ITicketAttractionsRepository, TicketAttractionsRepository>();
            services.AddScoped<ITicketAttractionsDomain, TicketAttractionsDomain>();
            services.AddScoped(typeof(ITicketAttractionsLookupRepositoryInterface), typeof(TicketAttractionsLookupRepository));

            services.AddScoped<IPropertyTypeRepository, PropertyTypeRepository>();
            services.AddScoped<IPropertyTypeDomain, PropertyTypeDomain>();
            services.AddScoped(typeof(IPropertyTypeLookupRepositoryInterface), typeof(PropertyTypeLookupRepository));

            services.AddScoped<IPackageTypeRepository, PackageTypeRepository>();
            services.AddScoped<IPackageTypeDomain, PackageTypeDomain>();
            services.AddScoped(typeof(IPackageTypeLookupRepositoryInterface), typeof(PackageTypeLookupRepository));
            
            services.AddScoped<IAmountBaseGSTRepository, AmountBaseGSTRepository>();
            services.AddScoped<IAmountBaseGSTDomain, AmountBaseGSTDomain>();
            services.AddScoped(typeof(IAmountBaseGSTLookupRepositoryInterface), typeof(AmountBaseGSTLookupRepository));

            services.AddScoped<IVideoGalleryRepository, VideoGalleryRepository>();
            services.AddScoped<IVideoGalleryDomain, VideoGalleryDomain>();
            services.AddScoped(typeof(IVideoGalleryLookupRepositoryInterface), typeof(VideoGalleryLookupRepository));

            services.AddScoped<IVideoGalleryRepository, VideoGalleryRepository>();
            services.AddScoped<IVideoGalleryDomain, VideoGalleryDomain>();
            services.AddScoped(typeof(IVideoGalleryLookupRepositoryInterface), typeof(VideoGalleryLookupRepository));
            
            services.AddScoped<IDistrictRepository, DistrictRepository>();
            services.AddScoped<IDistrictDomain, DistrictDomain>();
            services.AddScoped(typeof(IDistrictLookupRepositoryInterface), typeof(DistrictLookupRepository));
            
            
            services.AddScoped<IHotelBookingPackageRepository, HotelBookingPackageRepository>();
            services.AddScoped<IHotelBookingPackageDomain, HotelBookingPackageDomain>();
            services.AddScoped(typeof(IHotelBookingPackageLookupRepositoryInterface), typeof(HotelBookingPackageLookupRepository));
        }

    }
    
}