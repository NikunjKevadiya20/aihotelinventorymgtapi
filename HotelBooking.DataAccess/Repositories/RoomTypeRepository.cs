using HotelBooking.DataAccess.Base;
using HotelBooking.DataAccess.Interfaces;
using HotelBooking.Entity.Common.Entities;
using HotelBooking.Entity.Entities;

namespace HotelBooking.DataAccess.Repositories
{
    public class RoomTypeRepository : IRoomTypeRepository
    {
        IRoomTypeLookupRepositoryInterface repository;
        public RoomTypeRepository(IRoomTypeLookupRepositoryInterface _repository)
        {
            repository = _repository;
        }
        public async Task<ResultModel> InsertRoomType(RoomTypeDataEntity entity)
        {
            return await repository.InsertRoomType(entity, "sp_ManageRoomType");
        }
        public async Task<ResultModel> UpdateRoomType(RoomTypeDataEntity entity)
        {
            return await repository.UpdateRoomType(entity, "sp_ManageRoomType");
        }
        public async Task<ResultModel> UpdateRoomTypeOccupancy(RoomTypeDataEntity entity)
        {
            return await repository.UpdateRoomTypeOccupancy(entity, "sp_ManageRoomType");
        }
        public async Task<ResultModel> UpdateRoomTypeAmenities(RoomTypeDataEntity entity)
        {
            return await repository.UpdateRoomTypeAmenities(entity, "sp_ManageRoomType");
        }
        public async Task<ResultModel> DeleteRoomType(RoomTypeIDEntity entity)
        {
            return await repository.DeleteRoomType(entity, "sp_ManageRoomTypeFindByID");
        }
        public async Task<RoomTypeViewEntity> FindByIDRoomType(RoomTypeIDEntity entity)
        {
            return await repository.FindByIDRoomType(entity, "sp_ManageRoomTypeFindByID");
        }
        public async Task<List<RoomTypeViewEntity>> FindAllRoomType(RoomTypeIDEntity entity)
        {
            return await repository.FindAllRoomType(entity, "sp_ManageRoomTypeFindAll");
        }
        public async Task<List<RoomTypeViewEntity>> FindAllActiveRoomType()
        {
            return await repository.FindAllActiveRoomType("sp_ManageRoomTypeFindAll");
        }
        public async Task<ResultModel> ActiveInActiveRoomType(RoomTypeIDEntity entity)
        {
            return await repository.ActiveInActiveRoomType(entity, "sp_ManageRoomTypeFindByID");
        }
        public async Task<ResultModel> RoomTypeImageUpload(string? image,List<string> imageList, int? roomTypeID, int? updatedBy)
        {
            return await repository.RoomTypeImageUpload(image, imageList, roomTypeID, updatedBy );
        }
        public async Task<ResultModel> CommonImageUpload(string? image, string? altTag, string? title, int? updatedBy)
        {
            return await repository.CommonImageUpload(image, altTag, title, updatedBy);
        }
        public async Task<ResultModel> DeleteImage(DeleteImageEntity entity)
        {
            return await repository.DeleteImage(entity, "sp_ManageRoomTypeImages");
        }
        public async Task<List<RoomTypeImageViewEntity>> FindAllRoomTypeImage(RoomTypeIDEntity entity)
        {
            return await repository.FindAllRoomTypeImage(entity, "sp_ManageRoomTypeFindAll");
        }

        public async Task<ResultModel> InsertRoomTypeBed(RoomTypeBed entity)
        {
            return await repository.InsertRoomTypeBed(entity, "sp_ManageRoomTypeBed");
        }

        public async Task<ResultModel> UpdateRoomTypeBed(RoomTypeBed entity)
        {
            return await repository.UpdateRoomTypeBed(entity, "sp_ManageRoomTypeBed");
        }

        public async Task<ResultModel> DeleteRoomTypeBed(RoomTypeBed entity)
        {
            return await repository.DeleteRoomTypeBed(entity, "sp_ManageRoomTypeBed");
        }

        public async Task<List<RoomTypeBedViewEntity>> FindAllRoomTypeBed()
        {
            return await repository.FindAllRoomTypeBed("sp_ManageRoomTypeBedFindAll");
        }

    }
}
