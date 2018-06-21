using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetDelaysAPI
{
    public class Via
    {
        public ArrivalDeparture arrival { get; set; }
        public ArrivalDeparture departure { get; set; }
        public double timeBetween { get; set; }
        public string station { get; set; }
        public Via()
        {
            arrival = new ArrivalDeparture();
            departure = new ArrivalDeparture();
        }
    }
}
