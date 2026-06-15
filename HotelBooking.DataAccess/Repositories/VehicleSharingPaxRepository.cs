using HotelBooking.DataAccess.Base;
using HotelBooking.DataAccess.Interfaces;
using HotelBooking.Entity.Common.Entities;
using HotelBooking.Entity.Entities;

namespace HotelBooking.DataAccess.Repositories
{
    /// <summary>
    /// Added by NikunjK on 01-08-2023
    /// </summary>
    public class VehicleSharingPaxRepository : IVehicleSharingPaxRepository
    {
        IVehicleSharingPaxLookupRepositoryInterface repository;
        public VehicleSharingPaxRepository(IVehicleSharingPaxLookupRepositoryInterface _repository)
        {
            repository = _repository;
        }

        public async Task<ResultModel> InsertVehicleSharingPax(VehicleSharingPaxDataEntity entity)
        {
            return await repository.InsertVehicleSharingPax(entity, "sp_ManageVehicleSharingPaxInsert");
        }
        public async Task<ResultModel> UpdateVehicleSharingPax(VehicleSharingPaxDataEntity entity)
        {
            return await repository.UpdateVehicleSharingPax(entity, "sp_ManageVehicleSharingPaxInsert");
        }
        public async Task<ResultModel> DeleteVehicleSharingPax(VehicleSharingPaxIDEntity entity)
        {
            return await repository.DeleteVehicleSharingPax(entity, "sp_ManageVehicleSharingPaxFindByID");
        }
        public async Task<VehicleSharingPaxViewEntity> FindByIDVehicleSharingPax(VehicleSharingPaxIDEntity entity)
        {
            return await repository.FindByIDVehicleSharingPax(entity, "sp_ManageVehicleSharingPaxFindByID");
        }
        public async Task<List<VehicleSharingPaxViewEntity>> FindAllVehicleSharingPax(VehicleSharingPaxIDEntity entity)
        {
            return await repository.FindAllVehicleSharingPax(entity, "sp_ManageVehicleSharingPaxFindByID");
        }
        public async Task<List<VehicleSharingPaxViewEntity>> FindAllActiveVehicleSharingPax()
        {
            return await repository.FindAllActiveVehicleSharingPax("sp_ManageVehicleSharingPaxFindAllActive");
        }
        public async Task<ResultModel> ActiveInActiveVehicleSharingPax(VehicleSharingPaxIDEntity entity)
        {
            return await repository.ActiveInActiveVehicleSharingPax(entity, "sp_ManageVehicleSharingPaxFindByID");
        }
    }

}
