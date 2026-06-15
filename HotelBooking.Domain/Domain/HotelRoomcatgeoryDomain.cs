using HotelBooking.DataAccess.Interfaces;
using HotelBooking.Domain.Interfaces;
using HotelBooking.Entity.Common.Entities;
using HotelBooking.Entity.Entities;

namespace HotelBooking.Domain.Domain
{
    public class HotelRoomcatgeoryDomain : IHotelRoomcatgeoryDomain
    {

        IHotelRoomcatgeoryRepository repository;
        public HotelRoomcatgeoryDomain(IHotelRoomcatgeoryRepository _repository)
        {
            repository = _repository;
        }

        public async Task<ResultModel> InsertHotelRoomcatgeory(HotelRoomcatgeoryDataEntity entity, List<string>? otherImages)
        {
            return await repository.InsertHotelRoomcatgeory(entity, otherImages);
        }

        public async Task<ResultModel> UpdateHotelRoomcatgeory(HotelRoomcatgeoryDataEntity entity, List<string>? otherImages)
        {
            return await repository.UpdateHotelRoomcatgeory(entity, otherImages);
        }

        public async Task<ResultModel> DeleteHotelRoomcatgeory(HotelRoomcatgeoryIDEntity entity)
        {
            return await repository.DeleteHotelRoomcatgeory(entity);
        }

        public async Task<HotelRoomcatgeoryViewEntity> FindByIDHotelRoomcatgeory(HotelRoomcatgeoryIDEntity entity)
        {
            return await repository.FindByIDHotelRoomcatgeory(entity);
        }

        public async Task<List<HotelRoomcatgeoryViewEntity>> FindByHotelIDHotelRoomcatgeory(HotelRoomcatgeoryIDEntity entity)
        {
            return await repository.FindByHotelIDHotelRoomcatgeory(entity);
        }
        public async Task<List<HotelRoomcatgeoryViewEntity>> FindAllActiveHotelRoomcatgeory(HotelRoomcatgeoryIDEntity entity)
        {
            return await repository.FindAllActiveHotelRoomcatgeory(entity);
        }
        public async Task<ResultModel> ActiveInActiveHotelRoomcatgeory(HotelRoomcatgeoryIDEntity entity)
        {
            return await repository.ActiveInActiveHotelRoomcatgeory(entity);
        }

        public async Task<ResultModel> RoomCategoryImageUpload(List<string> otherImages, int? RoomCategoryID)
        {
            return await repository.RoomCategoryImageUpload(otherImages, RoomCategoryID);
        }

        public async Task<ResultModel> DeleteRoomCategoryImage(HotelRoomcatgeoryIDEntity entity)
        {
            return await repository.DeleteRoomCategoryImage(entity);
        }
    }
}
