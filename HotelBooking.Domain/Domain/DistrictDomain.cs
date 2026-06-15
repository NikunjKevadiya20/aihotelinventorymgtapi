using HotelBooking.DataAccess.Interfaces;
using HotelBooking.Domain.Interfaces;
using HotelBooking.Entity.Common.Entities;
using HotelBooking.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBooking.Domain.Domain
{
    public class DistrictDomain : IDistrictDomain
    {
        private readonly IDistrictRepository repository;
        public DistrictDomain(IDistrictRepository _repository)
        {
            repository = _repository;
        }

        public async Task<ResultModel> InsertDistrict(DistrictEntity entity)
        {
            return await repository.InsertDistrict(entity);
        }

        public async Task<ResultModel> UpdateDistrict(DistrictEntity entity)
        {
            return await repository.UpdateDistrict(entity);
        }

        public async Task<ResultModel> DeleteDistrict(DistrictIDEntity entity)
        {
            return await repository.DeleteDistrict(entity);
        }

        public async Task<DistrictViewEntity> FindByIDDistrict(DistrictIDEntity entity)
        {
            return await repository.FindByIDDistrict(entity);
        }

        public async Task<List<DistrictViewEntity>> FindAllDistrict(DistrictIDEntity entity)
        {
            return await repository.FindAllDistrict(entity);
        }

        public async Task<List<DistrictViewEntity>> FindAllActiveDistrict()
        {
            return await repository.FindAllActiveDistrict();
        }

        public async Task<ResultModel> ActiveInActiveDistrict(DistrictIDEntity entity)
        {
            return await repository.ActiveInActiveDistrict(entity);
        }
        public async Task<List<DistrictViewEntity>> FindDisatrictByStateID(DistrictIDEntity entity)
        {
            return await repository.FindDisatrictByStateID(entity);
        }
    }
}
