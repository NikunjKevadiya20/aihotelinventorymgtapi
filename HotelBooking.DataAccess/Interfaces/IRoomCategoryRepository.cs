using HotelBooking.Entity.Common.Entities;
using HotelBooking.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBooking.DataAccess.Interfaces
{
    public interface IRoomCategoryRepository
    {
        Task<ResultModel> InsertRoomCategory(RoomCategoryEntity entity);

        Task<ResultModel> UpdateRoomCategory(RoomCategoryEntity entity);
        Task<ResultModel> DeleteRoomCategory(RoomCategoryIDEntity entity);

        Task<RoomCategoryViewEntity> FindByIDRoomCategory(RoomCategoryIDEntity entity);
        Task<List<RoomCategoryViewEntity>> FindAllRoomCategory(RoomCategoryIDEntity entity);
        Task<List<RoomCategoryViewEntity>> FindAllActiveRoomCategory();

        Task<ResultModel> ActiveInActiveRoomCategory(RoomCategoryIDEntity entity);

    }
}
