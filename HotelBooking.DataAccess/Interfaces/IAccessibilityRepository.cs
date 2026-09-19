using HotelBooking.Entity.Common.Entities;
using HotelBooking.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBooking.DataAccess.Interfaces
{
    public interface IAccessibilityRepository
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
