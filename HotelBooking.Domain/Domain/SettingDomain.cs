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

    public class SettingDomain : ISettingDomain
    {
        ISettingRepository repository;
        public SettingDomain(ISettingRepository _repository)
        {
            repository = _repository;
        }

        public async Task<ResultModel> InsertSetting(SettingDataEntity entity)
        {
            return await repository.InsertSetting(entity);
        }
        public async Task<ResultModel> UpdateSetting(SettingDataEntity entity)
        {
            return await repository.UpdateSetting(entity);
        }
        public async Task<ResultModel> DeleteSetting(SettingIDEntity entity)
        {
            return await repository.DeleteSetting(entity);
        }
        public async Task<SettingViewEntity> FindByIDSetting(SettingIDEntity entity)
        {
            return await repository.FindByIDSetting(entity);
        }
        public async Task<List<SettingViewEntity>> FindAllSetting(SettingIDEntity entity)
        {
            return await repository.FindAllSetting(entity);
        }
        public async Task<List<SettingViewEntity>> FindAllActiveSetting()
        {
            return await repository.FindAllActiveSetting();
        }
        public async Task<ResultModel> ActiveInActiveSetting(SettingIDEntity entity)
        {
            return await repository.ActiveInActiveSetting(entity);
        }

    }
}
