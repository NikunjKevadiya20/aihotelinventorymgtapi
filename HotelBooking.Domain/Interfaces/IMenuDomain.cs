using HotelBooking.Entity.Common.Entities;
using HotelBooking.Entity.Entities;

namespace HotelBooking.Domain.Interfaces
{
    public interface IMenuDomain
    {
        Task<ResultModel> InsertMenu(MenuEntity entity);

        Task<ResultModel> UpdateMenu(MenuEntity entity);
        Task <ResultModel> DeleteMenu(MenuIDEntity entity);

        Task <MenuViewEntity> FindByIDMenu (MenuIDEntity entity);

        Task<List<MenuViewEntity>> FindAllMenu(MenuIDEntity entity);
        Task<List<MenuViewEntity>> FindAllActiveMenu();

        Task <ResultModel> ActiveInActiveMenu (MenuIDEntity entity);
        Task<List<MenuFindByIDData>> FindAllActiveMenuListSub();

    }
}
