using HotelBooking.Entity.Common.Entities;
using HotelBooking.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBooking.DataAccess.Interfaces
{
    public interface IBadTypeRepository
    {
        Task<ResultModel> InsertBadType(BadTypeEntity entity);

        Task<ResultModel> UpdateBadType(BadTypeEntity entity);
        Task<ResultModel> DeleteBadType(BadTypeIDEntity entity);

        Task<BadTypeViewEntity> FindByIDBadType(BadTypeIDEntity entity);
        Task<List<BadTypeViewEntity>> FindAllBadType(BadTypeIDEntity entity);
        Task<List<BadTypeViewEntity>> FindAllActiveBadType();

        Task<ResultModel> ActiveInActiveBadType(BadTypeIDEntity entity);

    }
}
