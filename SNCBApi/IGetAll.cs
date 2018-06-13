using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace getdelays.be.Models
{
    public interface IGetAll
    {
        List<Station> GetStations();
        DataApiPerStations GetDelaysForStation(string station);
        DataApiPerStations GetArrival(string station);
        DataApiPerStations GetDeparture(string station);
        DataApiTrain GetTrain(string idTrain);
    }
}
