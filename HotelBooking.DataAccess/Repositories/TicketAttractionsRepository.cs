using HotelBooking.DataAccess.Base;
using HotelBooking.DataAccess.Interfaces;
using HotelBooking.Entity.Common.Entities;
using HotelBooking.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBooking.DataAccess.Repositories
{
    public class TicketAttractionsRepository : ITicketAttractionsRepository
    {
        ITicketAttractionsLookupRepositoryInterface repository;

        public TicketAttractionsRepository(ITicketAttractionsLookupRepositoryInterface _repository)
        {
            repository = _repository;
        }

        public async Task<ResultModel> InsertTicketAttractions(TicketAttractionsEntity entity)
        {
            return await repository.InsertTicketAttractions(entity, "sp_ManageTicketAttractionsInsert");
        }
        public async Task<ResultModel> UpdateTicketAttractions(TicketAttractionsEntity entity)
        {
            return await repository.UpdateTicketAttractions(entity, "sp_ManageTicketAttractionsInsert");
        }
        public async Task<ResultModel> DeleteTicketAttractions(TicketAttractionsIDEntity entity)
        {
            return await repository.DeleteTicketAttractions(entity, "sp_ManageTicketAttractionsFindByID");
        }
        public async Task<TicketAttractionsViewEntity> FindByIDTicketAttractions(TicketAttractionsIDEntity entity)
        {
            return await repository.FindByIDTicketAttractions(entity, "sp_ManageTicketAttractionsFindByID");
        }

        public async Task<List<TicketAttractionsViewEntity>> FindAllTicketAttractions(TicketAttractionsIDEntity entity)
        {
            return await repository.FindAllTicketAttractions(entity, "sp_ManageTicketAttractionsFindAll");
        }
        public async Task<List<TicketAttractionsViewEntity>> FindAllActiveTicketAttractions()
        {
            return await repository.FindAllActiveTicketAttractions("sp_ManageTicketAttractionsFindAll");
        }
        public async Task<ResultModel> ActiveInActiveTicketAttractions(TicketAttractionsIDEntity entity)
        {
            return await repository.ActiveInActiveTicketAttractions(entity, "sp_ManageTicketAttractionsFindByID");
        }


    }
}
