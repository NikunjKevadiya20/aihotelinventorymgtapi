using HotelBooking.DataAccess.Interfaces;
using HotelBooking.Domain.Interfaces;
using HotelBooking.Entity.Common.Entities;
using HotelBooking.Entity.Entities;

namespace HotelBooking.Domain.Domain
{
    public class AccessibilityDomain : IAccessibilityDomain
    {
        IAccessibilityRepository repository;
        public AccessibilityDomain(IAccessibilityRepository _repository)
        {
            repository = _repository;
        }

        public async Task<ResultModel> InsertAccessibility(AccessibilityEntity entity)
        {
            return await repository.InsertAccessibility(entity);
        }

        public async Task<ResultModel> UpdateAccessibility(AccessibilityEntity entity)
        {
            return await repository.UpdateAccessibility(entity);
        }

        public async Task<ResultModel> DeleteAccessibility(AccessibilityIDEntity entity)
        {
            return await repository.DeleteAccessibility(entity);
        }
        public async Task<AccessibilityViewEntity> FindByIDAccessibility(AccessibilityIDEntity entity)
        {
            return await repository.FindByIDAccessibility(entity);
        }
        public async Task<List<AccessibilityViewEntity>> FindAllAccessibility(AccessibilityIDEntity entity)
        {
            return await repository.FindAllAccessibility(entity);
        }
        public async Task<List<AccessibilityViewEntity>> FindAllActiveAccessibility()
        {
            return await repository.FindAllActiveAccessibility();
        }

        public async Task<ResultModel> ActiveInActiveAccessibility(AccessibilityIDEntity entity)
        {
            return await repository.ActiveInActiveAccessibility(entity);
        }

    }
}
