using HotelBooking.DataAccess.Interfaces;
using HotelBooking.Domain.Interfaces;
using HotelBooking.Entity.Common.Entities;
using HotelBooking.Entity.Entities;

namespace HotelBooking.Domain.Domains
{
    /// <summary>
    /// Added by NikunjK on 01-08-2023
    /// </summary>
    public class VehicleSharingPaxDomain : IVehicleSharingPaxDomain
    {
        IVehicleSharingPaxRepository repository;
        public VehicleSharingPaxDomain(IVehicleSharingPaxRepository _repository)
        {
            repository = _repository;
        }

        public async Task<ResultModel> InsertVehicleSharingPax(VehicleSharingPaxDataEntity entity)
        {
            return await repository.InsertVehicleSharingPax(entity);
        }
        public async Task<ResultModel> UpdateVehicleSharingPax(VehicleSharingPaxDataEntity entity)
        {
            return await repository.UpdateVehicleSharingPax(entity);
        }
        public async Task<ResultModel> DeleteVehicleSharingPax(VehicleSharingPaxIDEntity entity)
        {
            return await repository.DeleteVehicleSharingPax(entity);
        }
        public async Task<VehicleSharingPaxViewEntity> FindByIDVehicleSharingPax(VehicleSharingPaxIDEntity entity)
        {
            return await repository.FindByIDVehicleSharingPax(entity);
        }
        public async Task<List<VehicleSharingPaxViewEntity>> FindAllVehicleSharingPax(VehicleSharingPaxIDEntity entity)
        {
            return await repository.FindAllVehicleSharingPax(entity);
        }
        public async Task<List<VehicleSharingPaxViewEntity>> FindAllActiveVehicleSharingPax()
        {
            return await repository.FindAllActiveVehicleSharingPax();
        }
        public async Task<ResultModel> ActiveInActiveVehicleSharingPax(VehicleSharingPaxIDEntity entity)
        {
            return await repository.ActiveInActiveVehicleSharingPax(entity);
        }
    }
}
