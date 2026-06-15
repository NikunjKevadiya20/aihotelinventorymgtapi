using HotelBooking.DataAccess.Base;
using HotelBooking.DataAccess.Interfaces;
using HotelBooking.Entity.Common.Entities;
using HotelBooking.Entity.Entities;

namespace HotelBooking.DataAccess.Repositories
{
    public class AttractionRepository : IAttractionRepository
    {
        IAttractionLookupRepositoryInterface repository;
        public AttractionRepository(IAttractionLookupRepositoryInterface _repository)
        {
            repository = _repository;
        }

        public async Task<AttractionIDEntity> InsertAttraction(AttractionEntity entity)
        {
            return await repository.InsertAttraction(entity, "sp_ManageAttractionsInsert");
        }
        public async Task<AttractionIDEntity> UpdateAttraction(AttractionEntity entity)
        {
            return await repository.UpdateAttraction(entity, "sp_ManageAttractionsInsert");
        }
        public async Task<ResultModel> DeleteAttraction(AttractionIDEntity entity)
        {
            return await repository.DeleteAttraction(entity, "sp_ManageAttractionsFindDelete");
        }
        public async Task<AttractionListEntity> FindByIDAttraction(AttractionIDEntity entity)
        {
            return await repository.FindByIDAttraction(entity, "sp_ManageAttractionsFindDelete");
        }
        public async Task<List<AttractionDataViewEntity>> FindAllAttraction(AttractionIDEntity entity)
        {
            return await repository.FindAllAttraction(entity, "sp_ManageAttractionsFindDelete");
        }
        public async Task<List<AttractionDataViewEntity>> FindAllActiveAttraction()
        {
            return await repository.FindAllActiveAttraction("sp_ManageAttractionsFindDelete");
        }
        public async Task<ResultModel> ActiveInActiveAttraction(AttractionIDEntity entity)
        {
            return await repository.ActiveInActiveAttraction(entity, "sp_ManageAttractionsFindDelete");
        }
        public async Task<ResultModel> AttractionImageUpdate(string? MainImage, string? BannerImage, List<AttratcionsDocumentsImage> Documents, int? ID, string? UpdatedBy)
        {
            return await repository.AttractionImageUpdate(MainImage, BannerImage, Documents, ID, UpdatedBy, "sp_ManageAttractionsInsert");
        }
        public async Task<AttractionListEntity> AttractionFindByURL(AttractionIDEntity entity)
        {
            return await repository.AttractionFindByURL(entity, "sp_ManageAttractionsFindDelete");
        }
        public async Task<ResultModel> DeleteAttractionImages(AttractionIDEntity entity)
        {
            return await repository.DeleteAttractionImages(entity, "sp_ManageAttractionsInsert");
        }
    }
}
