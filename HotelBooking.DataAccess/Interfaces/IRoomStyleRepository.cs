using HotelBooking.Entity.Common.Entities;
using HotelBooking.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBooking.DataAccess.Interfaces
{
    public interface IRoomStyleRepository
    {
        Task<ResultModel> InsertRoomStyle(RoomStyleEntity entity);

        Task<ResultModel> UpdateRoomStyle(RoomStyleEntity entity);
        Task<ResultModel> DeleteRoomStyle(RoomStyleIDEntity entity);

        Task<RoomStyleViewEntity> FindByIDRoomStyle(RoomStyleIDEntity entity);
        Task<List<RoomStyleViewEntity>> FindAllRoomStyle(RoomStyleIDEntity entity);
        Task<List<RoomStyleViewEntity>> FindAllActiveRoomStyle();

        Task<ResultModel> ActiveInActiveRoomStyle(RoomStyleIDEntity entity);

    }
}
