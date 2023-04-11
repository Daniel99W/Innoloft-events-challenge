using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventsAPI.Core.Entities
{
    public class Geo : BaseEntity
    {
        public float Lat { get; set; }
        public float Lng { get; set; }
    }
}
