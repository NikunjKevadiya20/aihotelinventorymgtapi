using HotelBooking.Entity.Common.Entities;
using HotelBooking.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBooking.DataAccess.Interfaces
{
    public interface ITicketAttractionsRepository
    {
        Task<ResultModel> InsertTicketAttractions(TicketAttractionsEntity entity);

        Task<ResultModel> UpdateTicketAttractions(TicketAttractionsEntity entity);
        Task<ResultModel> DeleteTicketAttractions(TicketAttractionsIDEntity entity);

        Task<TicketAttractionsViewEntity> FindByIDTicketAttractions(TicketAttractionsIDEntity entity);
        Task<List<TicketAttractionsViewEntity>> FindAllTicketAttractions(TicketAttractionsIDEntity entity);
        Task<List<TicketAttractionsViewEntity>> FindAllActiveTicketAttractions();

        Task<ResultModel> ActiveInActiveTicketAttractions(TicketAttractionsIDEntity entity);



    }
}
