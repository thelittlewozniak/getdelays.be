using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetDelaysAPI
{
    public class Station
    {
        public StationData stationinfo { get; set; }
        public List<ArrivalDeparture> arrivals { get; set; }
        public List<ArrivalDeparture> departures { get; set; }
        public Station()
        {
            stationinfo = new StationData();
            arrivals = new List<ArrivalDeparture>();
            departures = new List<ArrivalDeparture>();
        }
    }
}
