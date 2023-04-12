using EventsAPI.Core.Entities;
using EventsAPI.Core.Interfaces;
using EventsAPI.Core.Utilities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventsAPI.DAL.Repositories
{
    public class EventRepository : Repository<Event>,IRepositoryEvent
    {
        public EventRepository(EventsDbContext eventsDbContext)
            :base(eventsDbContext)
        {

        }

        public async Task<Pagination<Event>> GetEventsByCreatorId(int page, int itemsPerPage,int CreatorId)
        {
            return _eventsDbContext
                .Events
                .Include(ev => ev.Creator)
                    .ThenInclude(user => user.Address)
                .Include(ev => ev.Creator)
                    .ThenInclude(user => user.Company)
                .Where(ev => ev.CreatorId == CreatorId)
               .Paginate(page, itemsPerPage);
        }
    }
}
