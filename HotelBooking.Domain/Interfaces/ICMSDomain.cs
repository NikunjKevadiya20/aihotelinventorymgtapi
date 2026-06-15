using HotelBooking.Entity.Common.Entities;
using HotelBooking.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBooking.Domain.Interfaces
{
    public interface ICMSDomain
    {
        Task<CMSIDViewEntity> InsertCMS(CMSDataEntity entity);
        Task<ResultModel> UpdateCMS(CMSDataEntity entity);
        Task<ResultModel> DeleteCMS(CMSIDEntity entity);
        Task<CMSViewDataEntity> FindByIDCMS(CMSIDEntity entity);
        Task<List<CMSViewDataEntity>> FindAllCMS(CMSIDEntity entity);
        Task<List<CMSViewDataEntity>> FindAllActiveCMS();
        Task<ResultModel> ActiveInActiveCMS(CMSIDEntity entity);
        Task<ResultModel> CMSImageUpdate(string? physicalFileName, string? CMSImageAlterTag, int? ID, int? UpdatedBy);
        Task<List<CMSViewDataEntity>> FindAllCMSURL(CMSIDEntity entity);

    }
}
