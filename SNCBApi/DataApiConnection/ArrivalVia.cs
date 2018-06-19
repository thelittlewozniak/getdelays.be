using System;
using System.Collections.Generic;
using System.Text;

namespace SNCBAPI
{
    public class ArrivalVia
    {
        public double delay { get; set; }
        public string vehicule { get; set; }
        public int time { get; set; }
        public string TForView { get; set; }
        public string platform { get; set; }
        public Direction direction { get; set; }
    }
}
