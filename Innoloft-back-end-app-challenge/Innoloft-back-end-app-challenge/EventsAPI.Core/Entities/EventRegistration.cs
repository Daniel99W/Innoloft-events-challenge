using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventsAPI.Core.Entities
{
    public class EventRegistration : BaseEntity
    {
        public int ParticipatorId { get; set; } 
        public int EventId { get; set; }
        public Boolean IsParticipating { get; set; }
        public User Participator { get; set; }
        public Event Event { get; set; }
    }
}
