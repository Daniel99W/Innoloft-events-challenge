using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventsAPI.Core.Entities
{
    public class Address : BaseEntity
    {
        public string Street { get; set; } 
        public string City { get; set; }
        public string Suite { get; set; }
        public string ZipCode { get; set; }
        public int GeoId { get; set; }
        public Geo Geo { get; set; }
    }
}
