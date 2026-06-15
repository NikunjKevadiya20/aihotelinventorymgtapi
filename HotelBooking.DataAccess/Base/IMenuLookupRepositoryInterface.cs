using HotelBooking.Entity.Common.Entities;
using HotelBooking.Entity.Entities;


namespace HotelBooking.DataAccess.Base
{
    public interface IMenuLookupRepositoryInterface
    {
        Task<ResultModel> InsertMenu(MenuEntity entity, string storedProcedure);

        Task<ResultModel> UpdateMenu(MenuEntity entity, string storedProcedure);
        Task<ResultModel> DeleteMenu(MenuIDEntity entity,string storedProcedure);  
        Task<MenuViewEntity> FindByIDMenu(MenuIDEntity entity,string storedProcedure);

        Task<List<MenuViewEntity>> FindAllMenu(MenuIDEntity entity, string storedProcedure);
        Task<List<MenuViewEntity>> FindAllActiveMenu(string storedProcedure);

        Task<ResultModel> ActiveInActiveMenu(MenuIDEntity entity, string storedProcedure);

        Task<List<MenuFindByIDData>> FindAllActiveMenuListSub(string storedProcedure);

    }
}
