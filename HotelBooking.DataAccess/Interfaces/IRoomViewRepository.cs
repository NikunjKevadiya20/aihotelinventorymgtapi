using HotelBooking.Entity.Common.Entities;
using HotelBooking.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBooking.DataAccess.Interfaces
{
    public interface IRoomViewRepository
    {
        Task<ResultModel> InsertRoomView(RoomViewEntity entity);

        Task<ResultModel> UpdateRoomView(RoomViewEntity entity);
        Task<ResultModel> DeleteRoomView(RoomViewIDEntity entity);

        Task<RoomViewViewEntity> FindByIDRoomView(RoomViewIDEntity entity);
        Task<List<RoomViewViewEntity>> FindAllRoomView(RoomViewIDEntity entity);
        Task<List<RoomViewViewEntity>> FindAllActiveRoomView();

        Task<ResultModel> ActiveInActiveRoomView(RoomViewIDEntity entity);

    }
}
