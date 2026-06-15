using HotelBooking.Entity.Common.Entities;
using HotelBooking.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBooking.Domain.Interfaces
{
    public interface ISettingDomain
    {
        Task<ResultModel> InsertSetting(SettingDataEntity entity);
        Task<ResultModel> UpdateSetting(SettingDataEntity entity);
        Task<ResultModel> DeleteSetting(SettingIDEntity entity);
        Task<SettingViewEntity> FindByIDSetting(SettingIDEntity entity);
        Task<List<SettingViewEntity>> FindAllSetting(SettingIDEntity entity);
        Task<List<SettingViewEntity>> FindAllActiveSetting();
        Task<ResultModel> ActiveInActiveSetting(SettingIDEntity entity);

    }
}
