using HotelBooking.Entity.Common.Entities;
using HotelBooking.Entity.Entities;

namespace HotelBooking.DataAccess.Base
{
    public interface IMealTypeLookupRepositoryInterface
    {
        Task<ResultModel> InsertMealType(MealTypeDataEntity entity, string storedProcedure);
        Task<ResultModel> UpdateMealType(MealTypeDataEntity entity, string storedProcedure);
        Task<ResultModel> DeleteMealType(MealTypeIDEntity entity, string storedProcedure);
        Task<MealTypeViewEntity> FindByIDMealType(MealTypeIDEntity entity, string storedProcedure);
        Task<List<MealTypeViewEntity>> FindAllMealType(MealTypeIDEntity entity, string storedProcedure);
        Task<List<MealTypeViewEntity>> FindAllActiveMealType(string storedProcedure);

        Task<ResultModel> ActiveInActiveMealType(MealTypeIDEntity entity, string storedProcedure);
    }
}
