using HotelBooking.Entity.Common.Entities;
using HotelBooking.Entity.Entities;

namespace HotelBooking.DataAccess.Base
{
    /// <summary>
    /// Added by NikunjK on 01-08-2023
    /// </summary>
    public interface IVehicleTypeLookupRepositoryInterface
    {
        Task<ResultModel> InsertVehicleType(VehicleTypeDataEntity entity, string storedProcedure);
        Task<ResultModel> UpdateVehicleType(VehicleTypeDataEntity entity, string storedProcedure);
        Task<ResultModel> DeleteVehicleType(VehicleTypeIDEntity entity, string storedProcedure);
        Task<VehicleTypeViewEntity> FindByIDVehicleType(VehicleTypeIDEntity entity, string storedProcedure);
        Task<List<VehicleTypeViewEntity>> FindAllVehicleType(VehicleTypeIDEntity entity, string storedProcedure);
        Task<List<VehicleTypeViewEntity>> FindAllActiveVehicleType(string storedProcedure);
        Task<ResultModel> ActiveInActiveVehicleType(VehicleTypeIDEntity entity, string storedProcedure);

        Task<List<RatesViewEntity>> FindRatesByNoOfPax(RatesEntity entity, string storedProcedure);
        //Tour WiseRate Entity
        Task<List<RatesViewEntity>> FindVehicleTypeByTour(TourwiseCity entity, string storedProcedure);
    }
}

