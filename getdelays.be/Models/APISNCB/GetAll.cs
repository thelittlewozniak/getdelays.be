using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;

namespace getdelays.be.Models
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
            return stations.station;
        }
        public DataApiPerStations GetDelaysForStation(string station)
        {
            DateTime timenow = DateTime.Now;
            timenow=timenow.AddHours(-1);
            string date = timenow.ToString("ddMMy");
            string time = timenow.ToString("HHmm");
            string url = addressAPI + "liveboard?format=json&lang=eng&date=" + date + "&time=" + time + "&arrdep=arrival&station=" + station;
            var json = new WebClient().DownloadString(url);
            string url2 = addressAPI + "liveboard?format=json&lang=eng&date=" + date + "&time=" + time + "&arrdep=departure&station=" + station;
            var json2 = new WebClient().DownloadString(url2);
            var dataAPI = JsonConvert.DeserializeObject<DataApiPerStations>(json);
            var dataAPI2 = JsonConvert.DeserializeObject<DataApiPerStations>(json2);
            dataAPI.departures = dataAPI2.departures;
            return dataAPI;

        }
        public DataApiPerStations GetArrival(string station)
        {
            DateTime timenow = DateTime.Now;
            timenow = timenow.AddHours(-1);
            string date = timenow.ToString("ddMMy");
            string time = timenow.ToString("HHmm");
            string url = addressAPI + "liveboard?format=json&lang=eng&date=" + date + "&time=" + time + "&arrdep=arrival&station=" + station;
            var json = new WebClient().DownloadString(url);
            var dataAPI = JsonConvert.DeserializeObject<DataApiPerStations>(json);
            return dataAPI;
        }
        public DataApiPerStations GetDeparture(string station)
        {
            DateTime timenow = DateTime.Now;
            timenow = timenow.AddHours(-1);
            string date = timenow.ToString("ddMMy");
            string time = timenow.ToString("HHmm");
            string url = addressAPI + "liveboard?format=json&lang=eng&date=" + date + "&time=" + time + "&arrdep=departure&station=" + station;
            var json = new WebClient().DownloadString(url);
            var dataAPI = JsonConvert.DeserializeObject<DataApiPerStations>(json);
            return dataAPI;
        }
        public DataApiTrain GetTrain(string idTrain)
        {
            DateTime datenow = DateTime.Now;
            string date = datenow.ToString("ddMMy");
            string url = addressAPI + "vehicle/?format=json&lang=eng&date=" + date + "&id=" + idTrain;
            var json = new WebClient().DownloadString(url);
            var dataAPI = JsonConvert.DeserializeObject<DataApiTrain>(json);
            return dataAPI;
        }
    }
}