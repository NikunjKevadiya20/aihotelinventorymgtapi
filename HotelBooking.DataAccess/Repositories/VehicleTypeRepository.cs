using HotelBooking.DataAccess.Base;
using HotelBooking.DataAccess.Interfaces;
using HotelBooking.Entity.Common.Entities;
using HotelBooking.Entity.Entities;

namespace HotelBooking.DataAccess.Repositories
{
    /// <summary>
    /// Added by NikunjK on 01-08-2023
    /// </summary>
    public class VehicleTypeRepository : IVehicleTypeRepository
    {
        IVehicleTypeLookupRepositoryInterface repository;
        public VehicleTypeRepository(IVehicleTypeLookupRepositoryInterface _repository)
        {
            repository = _repository;
        }

        public async Task<ResultModel> InsertVehicleType(VehicleTypeDataEntity entity)
        {
            return await repository.InsertVehicleType(entity, "sp_ManageVehicleType");
        }
        public async Task<ResultModel> UpdateVehicleType(VehicleTypeDataEntity entity)
        {
            return await repository.UpdateVehicleType(entity, "sp_ManageVehicleType");
        }
        public async Task<ResultModel> DeleteVehicleType(VehicleTypeIDEntity entity)
        {
            return await repository.DeleteVehicleType(entity, "sp_ManageVehicleType");
        }
        public async Task<VehicleTypeViewEntity> FindByIDVehicleType(VehicleTypeIDEntity entity)
        {
            return await repository.FindByIDVehicleType(entity, "sp_ManageVehicleType");
        }
        public async Task<List<VehicleTypeViewEntity>> FindAllVehicleType(VehicleTypeIDEntity entity)
        {
            return await repository.FindAllVehicleType(entity, "sp_ManageVehicleType");
        }
        public async Task<List<VehicleTypeViewEntity>> FindAllActiveVehicleType()
        {
            return await repository.FindAllActiveVehicleType("sp_ManageVehicleType");
        }
        public async Task<ResultModel> ActiveInActiveVehicleType(VehicleTypeIDEntity entity)
        {
            return await repository.ActiveInActiveVehicleType(entity, "sp_ManageVehicleType");
        }

        public async Task<List<RatesViewEntity>> FindRatesByNoOfPax(RatesEntity entity)
        {
            return await repository.FindRatesByNoOfPax(entity, "sp_ManageVehicleType");
        }

        public async Task<List<RatesViewEntity>> FindVehicleTypeByTour(TourwiseCity entity)
        {
            return await repository.FindVehicleTypeByTour(entity, "sp_ManageVehicleType");
        }
    }

}
