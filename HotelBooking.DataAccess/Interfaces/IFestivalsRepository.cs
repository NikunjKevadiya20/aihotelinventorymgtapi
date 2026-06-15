using HotelBooking.Entity.Common.Entities;
using HotelBooking.Entity.Entities;

namespace HotelBooking.DataAccess.Interfaces
{
    public interface IFestivalsRepository
    {
        //Insert Added by AI009 on 25-03-23
        Task<ResultModel> InsertFestivals(FestivalEntity entity);
        //Update Added by AI009 on 25-03-23
        Task<ResultModel> UpdateFestivals(FestivalEntity entity);
        //FindAll Added by AI009 on 25-03-23
        Task<List<FestivalsEntity>> FindAllFestivals();
        //FindAllActive Added by AI009 on 25-03-23
        Task<List<FestivalsEntity>> FindAllActiveFestivals(string? Title);
        //FindByID Added by AI009 on 25-03-23
        Task<FestivalsEntity> FindByIDFestivals(FestivalsViewEntity entity);
        //Delete Added by AI009 on 25-03-23
        Task<ResultModel> DeleteFestivals(FestivalsViewEntity entity);
        //Active-InActive Added by AI009 on 25-03-23
        Task<ResultModel> ActiveInActiveFestivals(FestivalsViewEntity entity);

    }
}
