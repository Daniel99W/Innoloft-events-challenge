﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventsAPI.Core.Entities
{
    public class EventRegistration : BaseEntity
    {
        public int UserId { get; set; } 
        public int EventId { get; set; }
        public Boolean IsParticipating { get; set; }
        public User User { get; set; }
        public Event Event { get; set; }
    }
}
