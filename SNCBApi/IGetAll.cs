using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SNCBAPI
{
    public interface IGetAll
    {
        List<Station> GetStations();
        DataApiPerStations GetDelaysForStation(string station);
        DataApiTrain GetTrain(string idTrain);
        DataApiTrain GetTrain(string idTrain, string StationName);
        DataApiConnection GetConnection(string dep, string arr);
    }
}
