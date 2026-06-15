using HotelBooking.DataAccess.Interfaces;
using HotelBooking.Domain.Interfaces;
using HotelBooking.Entity.Common.Entities;
using HotelBooking.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBooking.Domain.Domain
{
    public class TicketAttractionsDomain : ITicketAttractionsDomain
    {
        ITicketAttractionsRepository repository;
        public TicketAttractionsDomain(ITicketAttractionsRepository _repository)
        {
            repository = _repository;
        }

        public async Task<ResultModel> InsertTicketAttractions(TicketAttractionsEntity entity)
        {
            return await repository.InsertTicketAttractions(entity);
        }

        public async Task<ResultModel> UpdateTicketAttractions(TicketAttractionsEntity entity)
        {
            return await repository.UpdateTicketAttractions(entity);
        }

        public async Task<ResultModel> DeleteTicketAttractions(TicketAttractionsIDEntity entity)
        {
            return await repository.DeleteTicketAttractions(entity);
        }
        public async Task<TicketAttractionsViewEntity> FindByIDTicketAttractions(TicketAttractionsIDEntity entity)
        {
            return await repository.FindByIDTicketAttractions(entity);
        }
        public async Task<List<TicketAttractionsViewEntity>> FindAllTicketAttractions(TicketAttractionsIDEntity entity)
        {
            return await repository.FindAllTicketAttractions(entity);
        }
        public async Task<List<TicketAttractionsViewEntity>> FindAllActiveTicketAttractions()
        {
            return await repository.FindAllActiveTicketAttractions();
        }

        public async Task<ResultModel> ActiveInActiveTicketAttractions(TicketAttractionsIDEntity entity)
        {
            return await repository.ActiveInActiveTicketAttractions(entity);
        }
        



    }
}
