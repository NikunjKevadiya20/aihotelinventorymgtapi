using HotelBooking.Entity.Common.Entities;
using HotelBooking.Entity.Entities;


namespace HotelBooking.DataAccess.Base
{
    public interface IAccessibilityLookupRepositoryInterface
    {
        Task<ResultModel> InsertAccessibility(AccessibilityEntity entity, string storedProcedure);
        Task<ResultModel> UpdateAccessibility(AccessibilityEntity entity, string storedProcedure);
        Task<ResultModel> DeleteAccessibility(AccessibilityIDEntity entity, string storedProcedure);
        Task<AccessibilityViewEntity> FindByIDAccessibility(AccessibilityIDEntity entity, string storedProcedure);
        Task<List<AccessibilityViewEntity>> FindAllAccessibility(AccessibilityIDEntity entity, string storedProcedure);
        Task<List<AccessibilityViewEntity>> FindAllActiveAccessibility(string storedProcedure);

        Task<ResultModel> ActiveInActiveAccessibility(AccessibilityIDEntity entity, string storedProcedure);


    }
}
