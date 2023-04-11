using EventsAPI.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventsAPI.DAL.Repositories
{
    public class EventRepository : Repository<Event>
    {
        public EventRepository(EventsDbContext eventsDbContext)
            :base(eventsDbContext)
        {

        }
    }
}
