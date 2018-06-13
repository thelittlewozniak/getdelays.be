using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace getdelays.be.Models
{
    public class DataApiPerStations
    {
        public Station stationinfo { get; set; }
        public ArrsDeps arrivals { get; set; }
        public ArrsDeps departures { get; set; }
    }
}