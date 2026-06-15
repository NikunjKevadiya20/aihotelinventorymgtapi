using HotelBooking.DataAccess.Base;
using HotelBooking.DataAccess.Interfaces;
using HotelBooking.Entity.Common.Entities;
using HotelBooking.Entity.Entities;

namespace HotelBooking.DataAccess.Repositories
{
    /// <summary>
    /// Added by NikunjK on 01-08-2023
    /// </summary>
    public class HotelContactRepository : IHotelContactRepository
    {
        IHotelContactLookupRepositoryInterface repository;
        public HotelContactRepository(IHotelContactLookupRepositoryInterface _repository)
        {
            repository = _repository;
        }

        public async Task<HotelContactsViewEntity> InsertHotelContact(HotelContactDataEntity entity)
        {
            return await repository.InsertHotelContact(entity, "sp_ManageHotelContactInsert");
        }
        public async Task<HotelContactsViewEntity> UpdateHotelContact(HotelContactDataEntity entity)
        {
            return await repository.UpdateHotelContact(entity, "sp_ManageHotelContactInsert");
        }
        public async Task<ResultModel> DeleteHotelContact(HotelContactIDEntity entity)
        {
            return await repository.DeleteHotelContact(entity, "sp_ManageHotelContactsFindByID");
        }
        public async Task<HotelContactViewEntity> FindByIDHotelContact(HotelContactIDEntity entity)
        {
            return await repository.FindByIDHotelContact(entity, "sp_ManageHotelContactsFindByID");
        }
        public async Task<HotelContactsViewEntity> FindByHotelIDContact(HotelContactIDEntity entity)
        {
            return await repository.FindByHotelIDContact(entity, "sp_ManageHotelContactsFindByID");
        }


        //public async Task<List<HotelContactViewEntity>> FindAllActiveHotelContact()
        //{
        //    return await repository.FindAllActiveHotelContact("sp_ManageHotelContactsFindByID");
        //}
        public async Task<ResultModel> ActiveInActiveHotelContact(HotelContactIDEntity entity)
        {
            return await repository.ActiveInActiveHotelContact(entity, "sp_ManageHotelContactsFindByID");
        }
    }

}
