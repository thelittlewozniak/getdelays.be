using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;

namespace SNCBAPI
{
    public class GetAll:IGetAll
    {
        private static string addressAPI = "https://api.irail.be/";
        private static GetAll instance;
        private GetAll(){}
        public static GetAll Instance()
        {
            if(instance==null)
            {
                instance = new GetAll();
            }
            return instance;
        }
        public List<Station> GetStations()
        {
            var json = new WebClient().DownloadString(addressAPI+"stations/?format=json&lang=en");
            var stations= JsonConvert.DeserializeObject<DataApi>(json);
            foreach (var s in stations.station)
            {
                byte[] bytes = Encoding.Default.GetBytes(s.name);
                var myString = Encoding.UTF8.GetString(bytes);
                s.name = myString;
            }
            return stations.station;
        }
        public DataApiPerStations GetDelaysForStation(string station)
        {
            DateTime timenow = DateTime.UtcNow;
            timenow = timenow.AddHours(1);
            string date = timenow.ToString("ddMMy");
            string time = timenow.ToString("HHmm");
            string url = addressAPI + "liveboard?format=json&lang=eng&date=" + date + "&time=" + time + "&arrdep=arrival&station=" + station;
            var json = new WebClient().DownloadString(url);
            string url2 = addressAPI + "liveboard?format=json&lang=eng&date=" + date + "&time=" + time + "&arrdep=departure&station=" + station;
            var json2 = new WebClient().DownloadString(url2);
            var dataAPI = JsonConvert.DeserializeObject<DataApiPerStations>(json);
            var dataAPI2 = JsonConvert.DeserializeObject<DataApiPerStations>(json2);
            dataAPI.departures = dataAPI2.departures;
            byte[] b = Encoding.Default.GetBytes(dataAPI.stationinfo.name);
            dataAPI.stationinfo.name = Encoding.UTF8.GetString(b);
            foreach (ArrDep a in dataAPI.arrivals.arrival)
            {
                byte[] by = Encoding.Default.GetBytes(a.station);
                a.station = Encoding.UTF8.GetString(by);
                DateTime date1 = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
                date1 = date1.AddSeconds(a.time).ToLocalTime();
                a.tForView = date1.ToLongTimeString();
                a.delay = a.delay / 60;
            }
            foreach (ArrDep a in dataAPI.departures.departure)
            {
                byte[] by = Encoding.Default.GetBytes(a.station);
                a.station = Encoding.UTF8.GetString(by);
                DateTime date2 = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
                date2 = date2.AddSeconds(a.time).ToLocalTime();
                a.tForView = date2.ToLongTimeString();
                a.delay = a.delay / 60;
            }
            return dataAPI;

        }
        public DataApiTrain GetTrain(string idTrain)
        {
            DateTime datenow = DateTime.UtcNow;
            datenow = datenow.AddHours(2);
            string date = datenow.ToString("ddMMy");
            string url = addressAPI + "vehicle/?format=json&lang=eng&date=" + date + "&id=" + idTrain;
            var json = new WebClient().DownloadString(url);
            var dataAPI = JsonConvert.DeserializeObject<DataApiTrain>(json);
            foreach (Stop a in dataAPI.stops.stop)
            {
                byte[] by = Encoding.Default.GetBytes(a.station);
                a.station = Encoding.UTF8.GetString(by);
                DateTime time = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
                time = time.AddSeconds(a.time).ToLocalTime();
                a.tForView = time.ToLongTimeString();
                a.delay = a.delay / 60;
            }
            return dataAPI;
        }
        public DataApiTrain GetTrain(string idTrain,string StationName)
        {
            DateTime datenow = DateTime.UtcNow;
            datenow = datenow.AddHours(2);
            string date = datenow.ToString("ddMMy");
            string url = addressAPI + "vehicle/?format=json&lang=eng&date=" + date + "&id=" + idTrain;
            var json = new WebClient().DownloadString(url);
            var dataAPI = JsonConvert.DeserializeObject<DataApiTrain>(json);
            bool ok = false;
            List<Stop> stps = new List<Stop>();
            foreach (Stop a in dataAPI.stops.stop)
            {
                byte[] by = Encoding.Default.GetBytes(a.station);
                a.station = Encoding.UTF8.GetString(by);
                DateTime time = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
                time = time.AddSeconds(a.time).ToLocalTime();
                a.tForView = time.ToLongTimeString();
                a.delay = a.delay / 60;
                if (a.station == StationName)
                {
                    ok = true;
                }
                if (ok)
                {
                    stps.Add(a);
                }
            }
            dataAPI.stops.stop = stps;
            return dataAPI;
        }
        public DataApiConnection GetConnection(string dep, string arr)
        {
            DateTime datenow = DateTime.UtcNow;
            datenow = datenow.AddHours(2);
            string time = datenow.ToString("HHmm");
            string date = datenow.ToString("ddMMy");
            string url = addressAPI + "connections/?format=json&lang=eng&date=" + date + "&from=" + dep + "&to=" + arr + "&time=" + time + "&timesel=departure" + "&typeOfTransport=trains&alerts=false&results=10";
            var json = new WebClient().DownloadString(url);
            var dataAPI = JsonConvert.DeserializeObject<DataApiConnection>(json);
            foreach (Connection c in dataAPI.connection)
            {
                byte[] b = Encoding.Default.GetBytes(c.arrival.station);
                c.arrival.station = Encoding.UTF8.GetString(b);
                DateTime dateArr = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
                dateArr = dateArr.AddSeconds(c.arrival.time).ToLocalTime();
                c.arrival.tForView = dateArr.ToLongTimeString();
                byte[] by = Encoding.Default.GetBytes(c.departure.station);
                c.departure.station = Encoding.UTF8.GetString(by);
                DateTime dateDep = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
                dateDep = dateDep.AddSeconds(c.departure.time).ToLocalTime();
                c.departure.tForView = dateDep.ToLongTimeString();
                c.arrival.delay = c.arrival.delay / 60;
                c.departure.delay = c.departure.delay / 60;
                if (c.vias != null)
                {
                    foreach (ViaInfo v in c.vias.via)
                    {
                        byte[] bv = Encoding.Default.GetBytes(v.station);
                        v.station = Encoding.UTF8.GetString(bv);
                        DateTime dateArrVia = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
                        dateArrVia = dateArr.AddSeconds(v.arrival.time).ToLocalTime();
                        v.arrival.TForView = dateArrVia.ToLongTimeString();
                        v.arrival.delay = v.arrival.delay / 60;
                        DateTime dateDepVia = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
                        dateDepVia = dateDepVia.AddSeconds(v.departure.time).ToLocalTime();
                        v.departure.TForView = dateDepVia.ToLongTimeString();
                        v.departure.delay = v.departure.delay / 60;
                        v.timeBetween = v.timeBetween / 60;
                    }
                }
            }
            return dataAPI;
        }
        public DataApiConnection GetConnection(string dep, string arr,DateTime datetime)
        {
            string time = datetime.ToString("HHmm");
            string date = datetime.ToString("ddMMy");
            string url = addressAPI + "connections/?format=json&lang=eng&date=" + date + "&from=" + dep + "&to=" + arr + "&time=" + time + "&timesel=departure" + "&typeOfTransport=trains&alerts=false&results=10";
            var json = new WebClient().DownloadString(url);
            var dataAPI = JsonConvert.DeserializeObject<DataApiConnection>(json);
            foreach (Connection c in dataAPI.connection)
            {
                byte[] b = Encoding.Default.GetBytes(c.arrival.station);
                c.arrival.station = Encoding.UTF8.GetString(b);
                DateTime dateArr = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
                dateArr = dateArr.AddSeconds(c.arrival.time).ToLocalTime();
                c.arrival.tForView = dateArr.ToLongTimeString();
                byte[] by = Encoding.Default.GetBytes(c.departure.station);
                c.departure.station = Encoding.UTF8.GetString(by);
                DateTime dateDep = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
                dateDep = dateDep.AddSeconds(c.departure.time).ToLocalTime();
                c.departure.tForView = dateDep.ToLongTimeString();
                c.arrival.delay = c.arrival.delay / 60;
                c.departure.delay = c.departure.delay / 60;
                if (c.vias != null)
                {
                    foreach (ViaInfo v in c.vias.via)
                    {
                        byte[] bv = Encoding.Default.GetBytes(v.station);
                        v.station = Encoding.UTF8.GetString(bv);
                        DateTime dateArrVia = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
                        dateArrVia = dateArr.AddSeconds(v.arrival.time).ToLocalTime();
                        v.arrival.TForView = dateArrVia.ToLongTimeString();
                        v.arrival.delay = v.arrival.delay / 60;
                        DateTime dateDepVia = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
                        dateDepVia = dateDepVia.AddSeconds(v.departure.time).ToLocalTime();
                        v.departure.TForView = dateDepVia.ToLongTimeString();
                        v.departure.delay = v.departure.delay / 60;
                        v.timeBetween = v.timeBetween / 60;
                    }
                }
            }
            return dataAPI;
        }
    }
}