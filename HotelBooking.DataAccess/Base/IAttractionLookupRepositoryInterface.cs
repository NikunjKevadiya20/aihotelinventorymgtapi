using HotelBooking.Entity.Common.Entities;
using HotelBooking.Entity.Entities;

namespace HotelBooking.DataAccess.Base
{
    public interface IAttractionLookupRepositoryInterface
    {
        Task<AttractionIDEntity> InsertAttraction(AttractionEntity entity, string storedProcedure);
        Task<AttractionIDEntity> UpdateAttraction(AttractionEntity entity, string storedProcedure);
        Task<ResultModel> DeleteAttraction(AttractionIDEntity entity, string storedProcedure);
        Task<AttractionListEntity> FindByIDAttraction(AttractionIDEntity entity, string storedProcedure);
        Task<List<AttractionDataViewEntity>> FindAllAttraction(AttractionIDEntity entity, string storedProcedure);
        Task<List<AttractionDataViewEntity>> FindAllActiveAttraction(string storedProcedure);
        Task<ResultModel> ActiveInActiveAttraction(AttractionIDEntity entity, string storedProcedure);
        Task<ResultModel> AttractionImageUpdate(string? MainImage, string? BannerImage, List<AttratcionsDocumentsImage> Documents, int? ID, string? UpdatedBy, string storedProcedure);
        Task<AttractionListEntity> AttractionFindByURL(AttractionIDEntity entity, string storedProcedure);
        Task<ResultModel> DeleteAttractionImages(AttractionIDEntity entity, string storedProcedure);
    }
}
