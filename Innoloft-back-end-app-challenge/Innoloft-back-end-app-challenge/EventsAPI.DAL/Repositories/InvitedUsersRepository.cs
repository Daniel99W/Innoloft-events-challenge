using EventsAPI.Core.Entities;
using EventsAPI.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventsAPI.DAL.Repositories
{
    public class InvitedUsersRepository : Repository<InvitedUsers>,IRepositoryInvitedUsers
    {
        public InvitedUsersRepository(EventsDbContext eventsDbContext)
            :base(eventsDbContext)
        {

        }
    }
}
