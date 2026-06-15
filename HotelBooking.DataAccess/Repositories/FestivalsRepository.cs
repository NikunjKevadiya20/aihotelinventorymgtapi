using HotelBooking.DataAccess.Base;
using HotelBooking.DataAccess.Interfaces;
using HotelBooking.Entity.Common.Entities;
using HotelBooking.Entity.Entities;

namespace HotelBooking.DataAccess.Repositories
{
    public class FestivalsRepository : IFestivalsRepository


    // Added by AI009 on 25-03-23
    {
        IFestivalsViewRepositoryInterface viewrepository;
        public FestivalsRepository(IFestivalsViewRepositoryInterface _viewrepository)
        {
            viewrepository = _viewrepository;
        }

        public async Task<ResultModel> InsertFestivals(FestivalEntity entity)
        {
            return await viewrepository.InsertFestivals(entity, "sp_ManageFestivals");
        }

        public async Task<ResultModel> UpdateFestivals(FestivalEntity entity)
        {
            return await viewrepository.UpdateFestivals(entity, "sp_ManageFestivals");
        }

        public async Task<List<FestivalsEntity>> FindAllFestivals()
        {
            return await viewrepository.FindAllFestivals("sp_ManageFestivals");
        }

        public async Task<List<FestivalsEntity>> FindAllActiveFestivals(string? Title)
        {
            return await viewrepository.FindAllActiveFestivals(Title, "sp_ManageFestivals");
        }

        public async Task<FestivalsEntity> FindByIDFestivals(FestivalsViewEntity entity)
        {
            return await viewrepository.FindByIDFestivals(entity, "sp_ManageFestivals"); ;
        }

        public async Task<ResultModel> DeleteFestivals(FestivalsViewEntity entity)
        {
            return await viewrepository.DeleteFestivals(entity, "sp_ManageFestivals");
        }

        public async Task<ResultModel> ActiveInActiveFestivals(FestivalsViewEntity entity)
        {
            return await viewrepository.ActiveInActiveFestivals(entity, "sp_ManageFestivals");
        }

    }
}
