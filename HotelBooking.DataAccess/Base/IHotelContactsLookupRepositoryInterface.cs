using HotelBooking.Entity.Common.Entities;
using HotelBooking.Entity.Entities;

namespace HotelBooking.DataAccess.Base
{
    /// <summary>
    /// Added by NikunjK on 01-08-2023
    /// </summary>
    public interface IHotelContactLookupRepositoryInterface
    {
        Task<HotelContactsViewEntity> InsertHotelContact(HotelContactDataEntity entity, string storedProcedure);
        Task<HotelContactsViewEntity> UpdateHotelContact(HotelContactDataEntity entity, string storedProcedure);
        Task<ResultModel> DeleteHotelContact(HotelContactIDEntity entity, string storedProcedure);
        Task<HotelContactViewEntity> FindByIDHotelContact(HotelContactIDEntity entity, string storedProcedure);
        Task<HotelContactsViewEntity> FindByHotelIDContact(HotelContactIDEntity entity, string storedProcedure);
        // Task<List<HotelContactViewEntity>> FindAllActiveHotelContact( string storedProcedure);
        Task<ResultModel> ActiveInActiveHotelContact(HotelContactIDEntity entity, string storedProcedure);
    }
}

