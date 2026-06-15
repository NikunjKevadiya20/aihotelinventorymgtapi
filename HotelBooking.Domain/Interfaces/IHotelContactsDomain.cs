using HotelBooking.Entity.Common.Entities;
using HotelBooking.Entity.Entities;

namespace HotelBooking.Domain.Interfaces
{
    /// <summary>
    /// Added by NikunjK on 01-08-2023
    /// </summary>
    public interface IHotelContactDomain
    {
        Task<HotelContactsViewEntity> InsertHotelContact(HotelContactDataEntity entity);
        Task<HotelContactsViewEntity> UpdateHotelContact(HotelContactDataEntity entity);
        Task<ResultModel> DeleteHotelContact(HotelContactIDEntity entity);
        Task<HotelContactViewEntity> FindByIDHotelContact(HotelContactIDEntity entity);
        Task<HotelContactsViewEntity> FindByHotelIDContact(HotelContactIDEntity entity);
        //Task<List<HotelContactViewEntity>> FindAllActiveHotelContact();
        Task<ResultModel> ActiveInActiveHotelContact(HotelContactIDEntity entity);

    }
}
