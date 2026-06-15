using HotelBooking.Entity.Common.Entities;
using HotelBooking.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBooking.DataAccess.Base
{
    public interface ISettingLookupRepositoryInterface
    {
        Task<ResultModel> InsertSetting(SettingDataEntity entity, string storedProcedure);
        Task<ResultModel> UpdateSetting(SettingDataEntity entity, string storedProcedure);
        Task<ResultModel> DeleteSetting(SettingIDEntity entity, string storedProcedure);
        Task<SettingViewEntity> FindByIDSetting(SettingIDEntity entity, string storedProcedure);
        Task<List<SettingViewEntity>> FindAllSetting(SettingIDEntity entity, string storedProcedure);
        Task<List<SettingViewEntity>> FindAllActiveSetting(string storedProcedure);
        Task<ResultModel> ActiveInActiveSetting(SettingIDEntity entity, string storedProcedure);
    }
}
