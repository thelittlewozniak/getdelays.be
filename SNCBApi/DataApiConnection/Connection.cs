using System;
using System.Collections.Generic;
using System.Text;

namespace getdelays.be.Models
{
    public class Connection
    {
        public DepartureArrival departure { get; set; }
        public DepartureArrival arrival { get; set; }
        public double duration { get; set; }
        public Via vias { get; set; }
    }
}
