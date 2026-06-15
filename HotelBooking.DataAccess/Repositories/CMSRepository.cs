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
    public class CMSRepository : ICMSRepository
    {
        ICMSLookupRepositoryInterface repository;
        public CMSRepository(ICMSLookupRepositoryInterface _repository)
        {
            repository = _repository;
        }

        public async Task<CMSIDViewEntity> InsertCMS(CMSDataEntity entity)
        {
            return await repository.InsertCMS(entity, "sp_ManageCMSInsert");
        }
        public async Task<ResultModel> UpdateCMS(CMSDataEntity entity)
        {
            return await repository.UpdateCMS(entity, "sp_ManageCMSInsert");
        }
        public async Task<ResultModel> DeleteCMS(CMSIDEntity entity)
        {
            return await repository.DeleteCMS(entity, "sp_ManageCMSFindDelete");
        }
        public async Task<CMSViewDataEntity> FindByIDCMS(CMSIDEntity entity)
        {
            return await repository.FindByIDCMS(entity, "sp_ManageCMSFindDelete");
        }
        public async Task<List<CMSViewDataEntity>> FindAllCMS(CMSIDEntity entity)
        {
            return await repository.FindAllCMS(entity, "sp_ManageCMSFindDelete");
        }
        public async Task<List<CMSViewDataEntity>> FindAllActiveCMS()
        {
            return await repository.FindAllActiveCMS("sp_ManageCMSFindDelete");
        }
        public async Task<ResultModel> ActiveInActiveCMS(CMSIDEntity entity)
        {
            return await repository.ActiveInActiveCMS(entity, "sp_ManageCMSFindDelete");
        }


        public async Task<ResultModel> CMSImageUpdate(string? physicalFileName, string? CMSImageAlterTag, int? ID, int? UpdatedBy)
        {
            return await repository.CMSImageUpdate(physicalFileName, CMSImageAlterTag, ID, UpdatedBy, "sp_ManageCMSInsert");
        }


        public async Task<List<CMSViewDataEntity>> FindAllCMSURL(CMSIDEntity entity)
        {
            return await repository.FindAllCMSURL(entity, "sp_ManageCMSFindDelete");
        }

    }
}
