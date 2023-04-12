﻿using EventsAPI.Core.Entities;
using EventsAPI.Core.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventsAPI.Core.Interfaces
{
    public interface IRepositoryEvent : IRepository<Event>
    {
        public Task<Pagination<Event>> GetEventsByUserId(int page, int itemsPerPage, int UserId);
    }
}
