﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventsAPI.Core.Utilities
{
    public class Pagination<T>
    {
        public int CurrentPage { get; set; }

        public int TotalPages { get; set; }

        public List<T> Results { get; set; }
    }
}
