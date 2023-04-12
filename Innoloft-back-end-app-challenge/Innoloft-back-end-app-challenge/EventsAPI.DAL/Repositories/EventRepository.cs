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

        public async Task<Pagination<Event>> GetEventsByUserId(int page, int itemsPerPage,int UserId)
        {
            return _eventsDbContext
                .Events
                .Include(ev => ev.User)
                    .ThenInclude(user => user.Address)
                .Include(ev => ev.User)
                    .ThenInclude(user => user.Company)
                .Where(ev => ev.UserId == UserId)
               .Paginate(page, itemsPerPage);
        }
    }
}
