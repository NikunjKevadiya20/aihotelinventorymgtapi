using HotelBooking.Entity.Common.Entities;
using HotelBooking.Entity.Entities;

namespace HotelBooking.DataAccess.Interfaces
{
    /// <summary>
    /// Added by NikunjK on 01-08-2023
    /// </summary>

    public interface IVehicleTypeRepository
    {
        Task<ResultModel> InsertVehicleType(VehicleTypeDataEntity entity);
        Task<ResultModel> UpdateVehicleType(VehicleTypeDataEntity entity);
        Task<ResultModel> DeleteVehicleType(VehicleTypeIDEntity entity);
        Task<VehicleTypeViewEntity> FindByIDVehicleType(VehicleTypeIDEntity entity);
        Task<List<VehicleTypeViewEntity>> FindAllVehicleType(VehicleTypeIDEntity entity);
        Task<List<VehicleTypeViewEntity>> FindAllActiveVehicleType();
        Task<ResultModel> ActiveInActiveVehicleType(VehicleTypeIDEntity entity);
        Task<List<RatesViewEntity>> FindRatesByNoOfPax(RatesEntity entity);
        //Tour WiseRate Entity
        Task<List<RatesViewEntity>> FindVehicleTypeByTour(TourwiseCity entity);
    }
}
