using HotelBooking.DataAccess.Base;
using HotelBooking.DataAccess.Interfaces;
using HotelBooking.Entity.Common.Entities;
using HotelBooking.Entity.Entities;

namespace HotelBooking.DataAccess.Repositories
{
    public class MealTypeRepository : IMealTypeRepository
    {
        IMealTypeLookupRepositoryInterface repository;
        public MealTypeRepository(IMealTypeLookupRepositoryInterface _repository)
        {
            repository = _repository;
        }

        public async Task<ResultModel> InsertMealType(MealTypeDataEntity entity)
        {
            return await repository.InsertMealType(entity, "sp_ManageMealType");
        }

        public async Task<ResultModel> UpdateMealType(MealTypeDataEntity entity)
        {
            return await repository.UpdateMealType(entity, "sp_ManageMealType");
        }

        public async Task<ResultModel> DeleteMealType(MealTypeIDEntity entity)
        {
            return await repository.DeleteMealType(entity, "sp_ManageMealType");
        }
        public async Task<MealTypeViewEntity> FindByIDMealType(MealTypeIDEntity entity)
        {
            return await repository.FindByIDMealType(entity, "sp_ManageMealType");
        }
        public async Task<List<MealTypeViewEntity>> FindAllMealType(MealTypeIDEntity entity)
        {
            return await repository.FindAllMealType(entity, "sp_ManageMealType");
        }
        public async Task<List<MealTypeViewEntity>> FindAllActiveMealType()
        {
            return await repository.FindAllActiveMealType("sp_ManageMealType");
        }
        public async Task<ResultModel> ActiveInActiveMealType(MealTypeIDEntity entity)
        {
            return await repository.ActiveInActiveMealType(entity, "sp_ManageMealType");
        }
    }
}
