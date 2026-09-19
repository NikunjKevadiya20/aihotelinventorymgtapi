using HotelBooking.DataAccess.Base;
using HotelBooking.DataAccess.Interfaces;
using HotelBooking.Entity.Common.Entities;
using HotelBooking.Entity.Entities;

namespace HotelBooking.DataAccess.Repositories
{
    public class AccessibilityRepository : IAccessibilityRepository
    {
        IAccessibilityLookupRepositoryInterface repository;

        public AccessibilityRepository(IAccessibilityLookupRepositoryInterface _repository)
        {
            repository = _repository;
        }

        public async Task<ResultModel> InsertAccessibility(AccessibilityEntity entity)
        {
            return await repository.InsertAccessibility(entity, "sp_ManageAccessibilityInsert");
        }
        public async Task<ResultModel> UpdateAccessibility(AccessibilityEntity entity)
        {
            return await repository.UpdateAccessibility(entity, "sp_ManageAccessibilityInsert");
        }
        public async Task<ResultModel> DeleteAccessibility(AccessibilityIDEntity entity)
        {
            return await repository.DeleteAccessibility(entity, "sp_ManageAccessibilityFindByID");
        }
        public async Task<AccessibilityViewEntity> FindByIDAccessibility(AccessibilityIDEntity entity)
        {
            return await repository.FindByIDAccessibility(entity, "sp_ManageAccessibilityFindByID");
        }
        public async Task<List<AccessibilityViewEntity>> FindAllAccessibility(AccessibilityIDEntity entity)
        {
            return await repository.FindAllAccessibility(entity, "sp_ManageAccessibilityFindAllActive");
        }
        public async Task<List<AccessibilityViewEntity>> FindAllActiveAccessibility()
        {
            return await repository.FindAllActiveAccessibility("sp_ManageAccessibilityFindAllActive");
        }
        public async Task<ResultModel> ActiveInActiveAccessibility(AccessibilityIDEntity entity)
        {
            return await repository.ActiveInActiveAccessibility(entity, "sp_ManageAccessibilityFindByID");
        }


    }
}
