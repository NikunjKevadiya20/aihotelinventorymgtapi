using HotelBooking.Entity.Common.Entities;
using HotelBooking.Entity.Entities;

namespace HotelBooking.DataAccess.Base
{
    public interface IFestivalsViewRepositoryInterface
    {
        //Insert Added by AI009 on 25-03-23
        Task<ResultModel> InsertFestivals(FestivalEntity entity, string storedProcedure);
        //Update Added by AI009 on 25-03-23
        Task<ResultModel> UpdateFestivals(FestivalEntity entity, string storedProcedure);
        //FindAll Added by AI009 on 25-03-23
        Task<List<FestivalsEntity>> FindAllFestivals(string storedProcedure);
        //FindAllActive Added by AI009 on 25-03-23
        Task<List<FestivalsEntity>> FindAllActiveFestivals(string? Title, string storedProcedure);
        //FindByID Added by AI009 on 25-03-23
        Task<FestivalsEntity> FindByIDFestivals(FestivalsViewEntity entity, string storedProcedure);
        //Delete Added by AI009 on 25-03-23
        Task<ResultModel> DeleteFestivals(FestivalsViewEntity entity, string storedProcedure);
        //ActiveInActive Added by AI009 on 25-03-23
        Task<ResultModel> ActiveInActiveFestivals(FestivalsViewEntity entity, string storedProcedure);

    }
}