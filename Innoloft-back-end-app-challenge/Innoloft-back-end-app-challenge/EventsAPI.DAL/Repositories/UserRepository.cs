using EventsAPI.Core.Entities;
using EventsAPI.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventsAPI.DAL.Repositories
{
    public class UserRepository : Repository<User>, IRepositoryUser
    {
        public UserRepository(EventsDbContext eventsDbContext)
            :base(eventsDbContext)
        {

        }
    }
}
