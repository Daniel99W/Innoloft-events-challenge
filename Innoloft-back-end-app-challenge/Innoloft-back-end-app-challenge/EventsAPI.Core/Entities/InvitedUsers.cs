using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventsAPI.Core.Entities
{
    public class InvitedUsers : BaseEntity
    {
        public int GuestId { get; set; } 
        public int EventId { get; set; }
        public bool IsParticipating { get; set; }
        public User Guest { get; set; }
        public Event Event { get; set; }
    }
}
