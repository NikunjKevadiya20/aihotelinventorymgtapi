using HotelBooking.DataAccess.Interfaces;
using HotelBooking.Domain.Interfaces;
using HotelBooking.Entity.Common.Entities;
using HotelBooking.Entity.Entities;

namespace HotelBooking.Domain.Domains
{
    /// <summary>
    /// Added by NikunjK on 01-08-2023
    /// </summary>
    public class VehicleTypeDomain : IVehicleTypeDomain
    {
        IVehicleTypeRepository repository;
        public VehicleTypeDomain(IVehicleTypeRepository _repository)
        {
            repository = _repository;
        }

        public async Task<ResultModel> InsertVehicleType(VehicleTypeDataEntity entity)
        {
            return await repository.InsertVehicleType(entity);
        }
        public async Task<ResultModel> UpdateVehicleType(VehicleTypeDataEntity entity)
        {
            return await repository.UpdateVehicleType(entity);
        }
        public async Task<ResultModel> DeleteVehicleType(VehicleTypeIDEntity entity)
        {
            return await repository.DeleteVehicleType(entity);
        }
        public async Task<VehicleTypeViewEntity> FindByIDVehicleType(VehicleTypeIDEntity entity)
        {
            return await repository.FindByIDVehicleType(entity);
        }
        public async Task<List<VehicleTypeViewEntity>> FindAllVehicleType(VehicleTypeIDEntity entity)
        {
            return await repository.FindAllVehicleType(entity);
        }
        public async Task<List<VehicleTypeViewEntity>> FindAllActiveVehicleType()
        {
            return await repository.FindAllActiveVehicleType();
        }
        public async Task<ResultModel> ActiveInActiveVehicleType(VehicleTypeIDEntity entity)
        {
            return await repository.ActiveInActiveVehicleType(entity);
        }

        // 24-12-2024 add 
        public async Task<List<RatesViewEntity>> FindRatesByNoOfPax(RatesEntity entity)
        {
            return await repository.FindRatesByNoOfPax(entity);
        }


        public async Task<List<RatesViewEntity>> FindVehicleTypeByTour(TourwiseCity entity)
        {
            return await repository.FindVehicleTypeByTour(entity);
        }

    }
}
