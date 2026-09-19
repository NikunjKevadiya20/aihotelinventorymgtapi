using HotelBooking.Entity.Common.Entities;
using HotelBooking.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBooking.DataAccess.Interfaces
{
    public interface IBedTypeRepository
    {
        Task<ResultModel> InsertBedType(BedTypeEntity entity);

        Task<ResultModel> UpdateBedType(BedTypeEntity entity);
        Task<ResultModel> DeleteBedType(BedTypeIDEntity entity);

        Task<BedTypeViewEntity> FindByIDBedType(BedTypeIDEntity entity);
        Task<List<BedTypeViewEntity>> FindAllBedType(BedTypeIDEntity entity);
        Task<List<BedTypeViewEntity>> FindAllActiveBedType();

        Task<ResultModel> ActiveInActiveBedType(BedTypeIDEntity entity);

    }
}
