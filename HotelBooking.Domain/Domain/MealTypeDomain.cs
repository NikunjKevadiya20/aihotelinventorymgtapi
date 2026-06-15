using HotelBooking.DataAccess.Interfaces;
using HotelBooking.Domain.Interfaces;
using HotelBooking.Entity.Common.Entities;
using HotelBooking.Entity.Entities;

namespace HotelBooking.Domain.Domain
{
    public class MealTypeDomain : IMealTypeDomain
    {
        IMealTypeRepository repository;
        public MealTypeDomain(IMealTypeRepository _repository)
        {
            repository = _repository;
        }

        public async Task<ResultModel> InsertMealType(MealTypeDataEntity entity)
        {
            return await repository.InsertMealType(entity);
        }
        public async Task<ResultModel> UpdateMealType(MealTypeDataEntity entity)
        {
            return await repository.UpdateMealType(entity);
        }
        public async Task<ResultModel> DeleteMealType(MealTypeIDEntity entity)
        {
            return await repository.DeleteMealType(entity);
        }
        public async Task<MealTypeViewEntity> FindByIDMealType(MealTypeIDEntity entity)
        {
            return await repository.FindByIDMealType(entity);
        }
        public async Task<List<MealTypeViewEntity>> FindAllMealType(MealTypeIDEntity entity)
        {
            return await repository.FindAllMealType(entity);
        }
        public async Task<List<MealTypeViewEntity>> FindAllActiveMealType()
        {
            return await repository.FindAllActiveMealType();
        }
        public async Task<ResultModel> ActiveInActiveMealType(MealTypeIDEntity entity)
        {
            return await repository.ActiveInActiveMealType(entity);
        }
    }
}
