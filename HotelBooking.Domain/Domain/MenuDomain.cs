using HotelBooking.DataAccess.Interfaces;
using HotelBooking.Domain.Interfaces;
using HotelBooking.Entity.Common.Entities;
using HotelBooking.Entity.Entities;

namespace HotelBooking.Domain.Domain
{
    public class MenuDomain : IMenuDomain
    {
        IMenuRepository repository;
        public MenuDomain(IMenuRepository _repository)
        {
            repository = _repository;
        }

        public async Task<ResultModel> InsertMenu(MenuEntity entity)
        {
            return await repository.InsertMenu(entity);
        }

        public async Task<ResultModel> UpdateMenu(MenuEntity entity)
        {
            return await repository.UpdateMenu(entity);
        }
        
        public async Task<ResultModel> DeleteMenu(MenuIDEntity entity)
        {
            return await repository.DeleteMenu(entity);
        }
        public async Task<MenuViewEntity> FindByIDMenu(MenuIDEntity entity)
        {
            return await repository.FindByIDMenu(entity);
        }
        public async Task<List<MenuViewEntity>> FindAllMenu(MenuIDEntity entity)
        {
            return await repository.FindAllMenu(entity);
        }
        public async Task<List<MenuViewEntity>> FindAllActiveMenu()
        {
            return await repository.FindAllActiveMenu();
        }

        public async Task<ResultModel> ActiveInActiveMenu(MenuIDEntity entity)
        {
            return await repository.ActiveInActiveMenu(entity);
        }
        public async Task<List<MenuFindByIDData>> FindAllActiveMenuListSub()
        {
            return await repository.FindAllActiveMenuListSub();
        }
    }
}
