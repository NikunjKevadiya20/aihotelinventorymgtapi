using HotelBooking.DataAccess.Base;
using HotelBooking.DataAccess.Interfaces;
using HotelBooking.Entity.Common.Entities;
using HotelBooking.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBooking.DataAccess.Repositories
{
    public class DistrictRepository : IDistrictRepository
    {
        private readonly IDistrictLookupRepositoryInterface repository;
        public DistrictRepository(IDistrictLookupRepositoryInterface _repository)
        {
            repository = _repository;
        }

        public async Task<ResultModel> InsertDistrict(DistrictEntity entity)
        {
            return await repository.InsertDistrict(entity, "sp_ManageDistrictInsert");
        }

        public async Task<ResultModel> UpdateDistrict(DistrictEntity entity)
        {
            return await repository.UpdateDistrict(entity, "sp_ManageDistrictInsert");
        }

        public async Task<ResultModel> DeleteDistrict(DistrictIDEntity entity)
        {
            return await repository.DeleteDistrict(entity, "sp_ManageDistrictFindByID");
        }

        public async Task<DistrictViewEntity> FindByIDDistrict(DistrictIDEntity entity)
        {
            return await repository.FindByIDDistrict(entity, "sp_ManageDistrictFindByID");
        }

        public async Task<List<DistrictViewEntity>> FindAllDistrict(DistrictIDEntity entity)
        {
            return await repository.FindAllDistrict(entity, "sp_ManageDistrictFindAll");
        }

        public async Task<List<DistrictViewEntity>> FindAllActiveDistrict()
        {
            return await repository.FindAllActiveDistrict("sp_ManageDistrictFindAll");
        }

        public async Task<ResultModel> ActiveInActiveDistrict(DistrictIDEntity entity)
        {
            return await repository.ActiveInActiveDistrict(entity, "sp_ManageDistrictFindByID");
        }
        public async Task<List<DistrictViewEntity>> FindDisatrictByStateID(DistrictIDEntity entity)
        {
            return await repository.FindDisatrictByStateID(entity, "sp_ManageDistrictFindByID");
        }
    }
}
