using HotelBooking.Entity.Common.Entities;
using HotelBooking.Entity.Entities;

namespace HotelBooking.DataAccess.Interfaces
{
    public interface IAttractionRepository
    {
        Task<AttractionIDEntity> InsertAttraction(AttractionEntity entity);
        Task<AttractionIDEntity> UpdateAttraction(AttractionEntity entity);
        Task<ResultModel> DeleteAttraction(AttractionIDEntity entity);
        Task<AttractionListEntity> FindByIDAttraction(AttractionIDEntity entity);
        Task<List<AttractionDataViewEntity>> FindAllAttraction(AttractionIDEntity entity);
        Task<List<AttractionDataViewEntity>> FindAllActiveAttraction();
        Task<ResultModel> ActiveInActiveAttraction(AttractionIDEntity entity);
        Task<ResultModel> AttractionImageUpdate(string? MainImage, string? BannerImage, List<AttratcionsDocumentsImage> Documents, int? ID, string? UpdatedBy);
        Task<AttractionListEntity> AttractionFindByURL(AttractionIDEntity entity);
        Task<ResultModel> DeleteAttractionImages(AttractionIDEntity entity);

    }
}
