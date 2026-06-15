using HotelBooking.Entity.Common.Entities;
using HotelBooking.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBooking.DataAccess.Base
{
    public interface ITicketAttractionsLookupRepositoryInterface
    {
        Task<ResultModel> InsertTicketAttractions(TicketAttractionsEntity entity, string storedProcedure);
        Task<ResultModel> UpdateTicketAttractions(TicketAttractionsEntity entity, string storedProcedure);
        Task<ResultModel> DeleteTicketAttractions(TicketAttractionsIDEntity entity, string storedProcedure);
        Task<TicketAttractionsViewEntity> FindByIDTicketAttractions(TicketAttractionsIDEntity entity, string storedProcedure);
        Task<List<TicketAttractionsViewEntity>> FindAllTicketAttractions(TicketAttractionsIDEntity entity, string storedProcedure);
        Task<List<TicketAttractionsViewEntity>> FindAllActiveTicketAttractions(string storedProcedure);

        Task<ResultModel> ActiveInActiveTicketAttractions(TicketAttractionsIDEntity entity, string storedProcedure);


    }
}
