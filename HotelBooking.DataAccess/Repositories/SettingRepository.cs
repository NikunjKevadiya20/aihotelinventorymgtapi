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
    public class SettingRepository : ISettingRepository
    {
        ISettingLookupRepositoryInterface repository;
        public SettingRepository(ISettingLookupRepositoryInterface _repository)
        {
            repository = _repository;
        }

        public async Task<ResultModel> InsertSetting(SettingDataEntity entity)
        {
            return await repository.InsertSetting(entity, "sp_ManageSettingsInsert");
        }
        public async Task<ResultModel> UpdateSetting(SettingDataEntity entity)
        {
            return await repository.UpdateSetting(entity, "sp_ManageSettingsInsert");
        }
        public async Task<ResultModel> DeleteSetting(SettingIDEntity entity)
        {
            return await repository.DeleteSetting(entity, "sp_ManageSettingsFindDelete");
        }
        public async Task<SettingViewEntity> FindByIDSetting(SettingIDEntity entity)
        {
            return await repository.FindByIDSetting(entity, "sp_ManageSettingsFindDelete");
        }
        public async Task<List<SettingViewEntity>> FindAllSetting(SettingIDEntity entity)
        {
            return await repository.FindAllSetting(entity, "sp_ManageSettingsFindDelete");
        }
        public async Task<List<SettingViewEntity>> FindAllActiveSetting()
        {
            return await repository.FindAllActiveSetting("sp_ManageSettingsFindDelete");
        }
        public async Task<ResultModel> ActiveInActiveSetting(SettingIDEntity entity)
        {
            return await repository.ActiveInActiveSetting(entity, "sp_ManageSettingsFindDelete");
        }

    }
}
