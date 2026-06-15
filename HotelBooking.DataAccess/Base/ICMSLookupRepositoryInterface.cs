using HotelBooking.Entity.Common.Entities;
using HotelBooking.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBooking.DataAccess.Base
{
    public interface ICMSLookupRepositoryInterface
    {
        Task<CMSIDViewEntity> InsertCMS(CMSDataEntity entity, string storedProcedure);
        Task<ResultModel> UpdateCMS(CMSDataEntity entity, string storedProcedure);
        Task<ResultModel> DeleteCMS(CMSIDEntity entity, string storedProcedure);
        Task<CMSViewDataEntity> FindByIDCMS(CMSIDEntity entity, string storedProcedure);
        Task<List<CMSViewDataEntity>> FindAllCMS(CMSIDEntity entity, string storedProcedure);
        Task<List<CMSViewDataEntity>> FindAllActiveCMS(string storedProcedure);
        Task<ResultModel> ActiveInActiveCMS(CMSIDEntity entity, string storedProcedure);


        Task<ResultModel> CMSImageUpdate(string? physicalFileName, string? CMSImageAlterTag, int? ID, int? UpdatedBy, string storedProcedure);
        Task<List<CMSViewDataEntity>> FindAllCMSURL(CMSIDEntity entity, string storedProcedure);



    }
}
