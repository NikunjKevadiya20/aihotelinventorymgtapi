using HotelBooking.Entity.Common.Entities;
using HotelBooking.Entity.Entities;

namespace HotelBooking.Domain.Interfaces
{
    public interface IMealTypeDomain
    {
        Task<ResultModel> InsertMealType(MealTypeDataEntity entity);
        Task<ResultModel> UpdateMealType(MealTypeDataEntity entity);
        Task<ResultModel> DeleteMealType(MealTypeIDEntity entity);
        Task<MealTypeViewEntity> FindByIDMealType(MealTypeIDEntity entity);
        Task<List<MealTypeViewEntity>> FindAllMealType(MealTypeIDEntity entity);
        Task<List<MealTypeViewEntity>> FindAllActiveMealType();

        Task<ResultModel> ActiveInActiveMealType(MealTypeIDEntity entity);




    }
}
