using HotelBooking.Entity.Common.Entities;
using HotelBooking.Entity.Entities;

namespace HotelBooking.Domain.Interfaces
{
    public interface IAccessibilityDomain
    {
        Task<ResultModel> InsertAccessibility(AccessibilityEntity entity);

        Task<ResultModel> UpdateAccessibility(AccessibilityEntity entity);
        Task<ResultModel> DeleteAccessibility(AccessibilityIDEntity entity);

        Task<AccessibilityViewEntity> FindByIDAccessibility(AccessibilityIDEntity entity);

        Task<List<AccessibilityViewEntity>> FindAllAccessibility(AccessibilityIDEntity entity);
        Task<List<AccessibilityViewEntity>> FindAllActiveAccessibility();

        Task<ResultModel> ActiveInActiveAccessibility(AccessibilityIDEntity entity);

    }
}
