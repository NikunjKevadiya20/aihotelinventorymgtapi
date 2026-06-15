using HotelBooking.DataAccess.Interfaces;
using HotelBooking.Domain.Interfaces;
using HotelBooking.Entity.Common.Entities;
using HotelBooking.Entity.Entities;

namespace HotelBooking.Domain.Domains
{
    /// <summary>
    /// Added by NikunjK on 01-08-2023
    /// </summary>
    public class HotelContactDomain : IHotelContactDomain
    {
        IHotelContactRepository repository;
        public HotelContactDomain(IHotelContactRepository _repository)
        {
            repository = _repository;
        }

        public async Task<HotelContactsViewEntity> InsertHotelContact(HotelContactDataEntity entity)
        {
            return await repository.InsertHotelContact(entity);
        }
        public async Task<HotelContactsViewEntity> UpdateHotelContact(HotelContactDataEntity entity)
        {
            return await repository.UpdateHotelContact(entity);
        }
        public async Task<ResultModel> DeleteHotelContact(HotelContactIDEntity entity)
        {
            return await repository.DeleteHotelContact(entity);
        }
        public async Task<HotelContactViewEntity> FindByIDHotelContact(HotelContactIDEntity entity)
        {
            return await repository.FindByIDHotelContact(entity);
        }
        public async Task<HotelContactsViewEntity> FindByHotelIDContact(HotelContactIDEntity entity)
        {
            return await repository.FindByHotelIDContact(entity);
        }
        //public async Task<List<HotelContactViewEntity>> FindAllActiveHotelContact()
        //{
        //    return await repository.FindAllActiveHotelContact();
        //}
        public async Task<ResultModel> ActiveInActiveHotelContact(HotelContactIDEntity entity)
        {
            return await repository.ActiveInActiveHotelContact(entity);
        }
    }
}
