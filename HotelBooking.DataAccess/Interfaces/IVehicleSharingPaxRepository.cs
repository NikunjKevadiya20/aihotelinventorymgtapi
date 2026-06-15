using HotelBooking.Entity.Common.Entities;
using HotelBooking.Entity.Entities;

namespace HotelBooking.DataAccess.Interfaces
{
    /// <summary>
    /// Added by NikunjK on 01-08-2023
    /// </summary>

    public interface IVehicleSharingPaxRepository
    {
        Task<ResultModel> InsertVehicleSharingPax(VehicleSharingPaxDataEntity entity);
        Task<ResultModel> UpdateVehicleSharingPax(VehicleSharingPaxDataEntity entity);
        Task<ResultModel> DeleteVehicleSharingPax(VehicleSharingPaxIDEntity entity);
        Task<VehicleSharingPaxViewEntity> FindByIDVehicleSharingPax(VehicleSharingPaxIDEntity entity);
        Task<List<VehicleSharingPaxViewEntity>> FindAllVehicleSharingPax(VehicleSharingPaxIDEntity entity);
        Task<List<VehicleSharingPaxViewEntity>> FindAllActiveVehicleSharingPax();
        Task<ResultModel> ActiveInActiveVehicleSharingPax(VehicleSharingPaxIDEntity entity);
    }
}
