using System;
using System.Collections.Generic;
using System.Text;

namespace getdelays.be.Models
{
    public class DepartureArrival
    {
        public double delay { get; set; }
        public string station { get; set; }
        public int time { get; set; }
        public string vehicle { get; set; }
        public int platform { get; set; }
        public string tForView { get; set; }
    }
}
