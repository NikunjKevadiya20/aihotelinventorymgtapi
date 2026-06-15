using HotelBooking.DataAccess.Interfaces;
using HotelBooking.Domain.Interfaces;
using HotelBooking.Entity.Common.Entities;
using HotelBooking.Entity.Entities;

namespace HotelBooking.Domain.Domain
{
    public class AttractionDomain : IAttractionDomain
    {
        IAttractionRepository repository;
        public AttractionDomain(IAttractionRepository _repository)
        {
            repository = _repository;
        }

        public async Task<AttractionIDEntity> InsertAttraction(AttractionEntity entity)
        {
            return await repository.InsertAttraction(entity);
        }
        public async Task<AttractionIDEntity> UpdateAttraction(AttractionEntity entity)
        {
            return await repository.UpdateAttraction(entity);
        }
        public async Task<ResultModel> DeleteAttraction(AttractionIDEntity entity)
        {
            return await repository.DeleteAttraction(entity);
        }
        public async Task<AttractionListEntity> FindByIDAttraction(AttractionIDEntity entity)
        {
            return await repository.FindByIDAttraction(entity);
        }
        public async Task<List<AttractionDataViewEntity>> FindAllAttraction(AttractionIDEntity entity)
        {
            return await repository.FindAllAttraction(entity);
        }
        public async Task<List<AttractionDataViewEntity>> FindAllActiveAttraction()
        {
            return await repository.FindAllActiveAttraction();
        }
        public async Task<ResultModel> ActiveInActiveAttraction(AttractionIDEntity entity)
        {
            return await repository.ActiveInActiveAttraction(entity);
        }
        public async Task<ResultModel> AttractionImageUpdate(string? MainImage, string? BannerImage, List<AttratcionsDocumentsImage> Documents , int? ID, string? UpdatedBy)
        {
            return await repository.AttractionImageUpdate(MainImage, BannerImage, Documents ,ID, UpdatedBy );
        }
        public async Task<AttractionListEntity> AttractionFindByURL(AttractionIDEntity entity)
        {
            return await repository.AttractionFindByURL(entity);
        }
        public async Task<ResultModel> DeleteAttractionImages(AttractionIDEntity entity)
        {
            return await repository.DeleteAttractionImages(entity);
        }
    }
}
