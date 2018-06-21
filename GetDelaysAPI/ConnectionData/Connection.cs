using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetDelaysAPI
{
    public class Connection
    {
        public ArrivalDeparture departure { get; set; }
        public ArrivalDeparture arrival { get; set; }
        public double duration { get; set; }
        public List<Via> vias { get; set; }
        public Connection()
        {
            departure = new ArrivalDeparture();
            arrival = new ArrivalDeparture();
            vias = new List<Via>();
        }
    }
}
