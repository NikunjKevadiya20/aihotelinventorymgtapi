using HotelBooking.Entity.Common.Entities;
using HotelBooking.Entity.Entities;

namespace HotelBooking.DataAccess.Base
{
    /// <summary>
    /// Added by NikunjK on 01-08-2023
    /// </summary>
    public interface IVehicleSharingPaxLookupRepositoryInterface
    {
        Task<ResultModel> InsertVehicleSharingPax(VehicleSharingPaxDataEntity entity, string storedProcedure);
        Task<ResultModel> UpdateVehicleSharingPax(VehicleSharingPaxDataEntity entity, string storedProcedure);
        Task<ResultModel> DeleteVehicleSharingPax(VehicleSharingPaxIDEntity entity, string storedProcedure);
        Task<VehicleSharingPaxViewEntity> FindByIDVehicleSharingPax(VehicleSharingPaxIDEntity entity, string storedProcedure);
        Task<List<VehicleSharingPaxViewEntity>> FindAllVehicleSharingPax(VehicleSharingPaxIDEntity entity, string storedProcedure);
        Task<List<VehicleSharingPaxViewEntity>> FindAllActiveVehicleSharingPax(string storedProcedure);
        Task<ResultModel> ActiveInActiveVehicleSharingPax(VehicleSharingPaxIDEntity entity, string storedProcedure);
    }
}

