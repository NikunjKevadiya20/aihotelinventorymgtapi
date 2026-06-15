using HotelBooking.DataAccess.Base;
using HotelBooking.DataAccess.Interfaces;
using HotelBooking.Entity.Common.Entities;
using HotelBooking.Entity.Entities;

namespace HotelBooking.DataAccess.Repositories
{
    public class MenuRepository : IMenuRepository
    {
        IMenuLookupRepositoryInterface repository;

        public MenuRepository (IMenuLookupRepositoryInterface _repository)
        {
            repository = _repository;
        }

        public async Task<ResultModel> InsertMenu(MenuEntity entity)
        {
            return await repository.InsertMenu(entity, "sp_ManageMenuInsert");
        }
        public async Task<ResultModel> UpdateMenu (MenuEntity entity)
        {
            return await repository.UpdateMenu(entity, "sp_ManageMenuInsert");
        }
        public async Task<ResultModel> DeleteMenu(MenuIDEntity entity)
        {
            return await repository.DeleteMenu(entity, "sp_ManageMenuDetails");
        }
        public async Task<MenuViewEntity> FindByIDMenu(MenuIDEntity entity)
        {
            return await repository.FindByIDMenu(entity, "sp_ManageMenuDetails");
        }

        public async Task<List<MenuViewEntity>> FindAllMenu(MenuIDEntity entity)
        {
            return await repository.FindAllMenu(entity, "sp_ManageMenuDetails");
        }
        public async Task<List<MenuViewEntity>> FindAllActiveMenu()
        {
            return await repository.FindAllActiveMenu("sp_ManageMenuFindAllActive");
        }
        public async Task<ResultModel> ActiveInActiveMenu(MenuIDEntity entity)
        {
            return await repository.ActiveInActiveMenu(entity, "sp_ManageMenuDetails");
        }

        public async Task<List<MenuFindByIDData>> FindAllActiveMenuListSub()
        {
            return await repository.FindAllActiveMenuListSub("sp_ManageMenuFindAllActive");
        }
    }
}
