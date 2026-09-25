using HotelBooking.DataAccess.Interfaces;
using HotelBooking.Domain.Interfaces;
using HotelBooking.Entity.Common.Entities;
using HotelBooking.Entity.Entities;

namespace HotelBooking.Domain.Domain
{
    public class RoomTypeDomain : IRoomTypeDomain
    {
        IRoomTypeRepository repository;
        public RoomTypeDomain(IRoomTypeRepository _repository)
        {
            repository = _repository;
        }
        public async Task<ResultModel> InsertRoomType(RoomTypeDataEntity entity)
        {
            return await repository.InsertRoomType(entity);
        }
        public async Task<ResultModel> UpdateRoomType(RoomTypeDataEntity entity)
        {
            return await repository.UpdateRoomType(entity);
        }
        public async Task<ResultModel> UpdateRoomTypeOccupancy(RoomTypeDataEntity entity)
        {
            return await repository.UpdateRoomTypeOccupancy(entity);
        }
        public async Task<ResultModel> UpdateRoomTypeAmenities(RoomTypeDataEntity entity)
        {
            return await repository.UpdateRoomTypeAmenities(entity);
        }
        public async Task<ResultModel> DeleteRoomType(RoomTypeIDEntity entity)
        {
            return await repository.DeleteRoomType(entity);
        }
        public async Task<RoomTypeViewEntity> FindByIDRoomType(RoomTypeIDEntity entity)
        {
            return await repository.FindByIDRoomType(entity);
        }
        public async Task<List<RoomTypeViewEntity>> FindAllRoomType(RoomTypeIDEntity entity)
        {
            return await repository.FindAllRoomType(entity);
        }
        public async Task<List<RoomTypeViewEntity>> FindAllActiveRoomType()
        {
            return await repository.FindAllActiveRoomType();
        }
        public async Task<ResultModel> ActiveInActiveRoomType(RoomTypeIDEntity entity)
        {
            return await repository.ActiveInActiveRoomType(entity);
        }
        public async Task<ResultModel> RoomTypeImageUpload( string? image, List<string> imageList, int? roomTypeID, int? updatedBy)
        {
            return await repository.RoomTypeImageUpload(image,imageList,roomTypeID,updatedBy);
        }
        public async Task<ResultModel> DeleteImage(DeleteImageEntity entity)
        {
            return await repository.DeleteImage(entity);
        }
        public async Task<List<RoomTypeImageViewEntity>> FindAllRoomTypeImage(RoomTypeIDEntity entity)
        {
            return await repository.FindAllRoomTypeImage(entity);
        }

        public async Task<ResultModel> CommonImageUpload(string? image, string? altTag, string? title, int? updatedBy)
        {
            return await repository.CommonImageUpload(image, altTag, title, updatedBy);
        }

        public async Task<ResultModel> InsertRoomTypeBed(RoomTypeBed entity)
        {
            return await repository.InsertRoomTypeBed(entity);
        }

        public async Task<ResultModel> UpdateRoomTypeBed(RoomTypeBed entity)
        {
            return await repository.UpdateRoomTypeBed(entity);
        }

        public async Task<ResultModel> DeleteRoomTypeBed(RoomTypeBed entity)
        {
            return await repository.DeleteRoomTypeBed(entity);
        }

        public async Task<List<RoomTypeBedViewEntity>> FindAllRoomTypeBed()
        {
            return await repository.FindAllRoomTypeBed();
        }
    }
}
