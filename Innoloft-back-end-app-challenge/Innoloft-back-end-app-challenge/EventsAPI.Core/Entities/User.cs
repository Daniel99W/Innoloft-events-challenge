using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace EventsAPI.Core.Entities
{
    public class User : BaseEntity
    {
        public string Name { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Website { get; set; }
        public int AddressId { get; set; }
        public int CompanyId { get; set; }
        public Address Address { get; set; }
        public Company Company { get; set; }
        public List<Event> Events { get; set; }
    }
}
