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
    public class CMSDomain : ICMSDomain
    {
        ICMSRepository repository;
        public CMSDomain(ICMSRepository _repository)
        {
            repository = _repository;
        }

        public async Task<CMSIDViewEntity> InsertCMS(CMSDataEntity entity)
        {
            return await repository.InsertCMS(entity);
        }
        public async Task<ResultModel> UpdateCMS(CMSDataEntity entity)
        {
            return await repository.UpdateCMS(entity);
        }
        public async Task<ResultModel> DeleteCMS(CMSIDEntity entity)
        {
            return await repository.DeleteCMS(entity);
        }
        public async Task<CMSViewDataEntity> FindByIDCMS(CMSIDEntity entity)
        {
            return await repository.FindByIDCMS(entity);
        }
        public async Task<List<CMSViewDataEntity>> FindAllCMS(CMSIDEntity entity)
        {
            return await repository.FindAllCMS(entity);
        }
        public async Task<List<CMSViewDataEntity>> FindAllActiveCMS()
        {
            return await repository.FindAllActiveCMS();
        }
        public async Task<ResultModel> ActiveInActiveCMS(CMSIDEntity entity)
        {
            return await repository.ActiveInActiveCMS(entity);
        }

        public async Task<ResultModel> CMSImageUpdate(string? physicalFileName, string? CMSImageAlterTag, int? ID, int? UpdatedBy)
        {
            return await repository.CMSImageUpdate(physicalFileName, CMSImageAlterTag, ID, UpdatedBy);
        }

        public async Task<List<CMSViewDataEntity>> FindAllCMSURL(CMSIDEntity entity)
        {
            return await repository.FindAllCMSURL(entity);
        }


    }
}
