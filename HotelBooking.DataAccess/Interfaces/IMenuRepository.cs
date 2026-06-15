using HotelBooking.Entity.Common.Entities;
using HotelBooking.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBooking.DataAccess.Interfaces
{
    public interface IMenuRepository
    {
        Task<ResultModel> InsertMenu(MenuEntity entity);

        Task <ResultModel> UpdateMenu (MenuEntity entity);
        Task <ResultModel > DeleteMenu(MenuIDEntity entity);

        Task<MenuViewEntity> FindByIDMenu(MenuIDEntity entity);
        Task<List<MenuViewEntity>> FindAllMenu(MenuIDEntity entity);
        Task<List<MenuViewEntity>> FindAllActiveMenu();

        Task<ResultModel> ActiveInActiveMenu(MenuIDEntity entity);
        Task<List<MenuFindByIDData>> FindAllActiveMenuListSub();

    }
}
