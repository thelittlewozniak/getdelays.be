using api.getdelays.POCO;
using api.getdelays.DAL;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using GoogleAPI;
using SNCBAPI;
using GetDelaysAPI;

namespace getdelays.be.Controllers
{
    public class StationController : ApiController
    {
        // GET: Station
        ///<summary>
        /// The API send you just the name, the location and the id of all stations inside the network
        ///</summary>
        /// <returns>
        /// It return an object StationData in wich you have a data from the SNCB. You will receive the name, the location,the id of the station
        /// <seealso cref="StationData"/>
        /// </returns>
        [HttpGet]
        public IEnumerable<StationData> SearchStation()
        {
            
            IGetAll newaccessapi = SNCBAPI.GetAll.Instance();
            List<SNCBAPI.Station> stations = newaccessapi.GetStations();
            List<StationData> stats = new List<StationData>();
            foreach (SNCBAPI.Station s in stations)
            {
                stats.Add(new StationData { name = s.name, locationX = s.locationX, locationY = s.locationY, id = s.id});
            }
            return stats;
        }
        ///<summary>
        /// The API send you the name, the location,the id, opening hours, the rating, the reviews, the arrivals and the departures of the station from the param
        ///</summary>
        /// <param name="station">it's the station for which we want information</param>
        /// <returns>
        /// It return an object Station in wich you have a full of data from the SNCB and Google. You will receive the name, the location,the id, opening hours, the rating, the reviews, the arrivals and the departures of the station
        /// <seealso cref="GetDelaysAPI.Station"/>
        /// </returns>
        [HttpGet]
        public GetDelaysAPI.Station GetStationsByName(string station) 
        {
            if (station !=null)
            {
                DateTime now = DateTime.UtcNow;
                now = now.AddHours(2);
                IGetAPIGoogle googleApi = new SearchPlaceAPI();
                IGetAll newaccessapi = SNCBAPI.GetAll.Instance();
                DataApiPerStations s = newaccessapi.GetDelaysForStation(station);
                DetailsPlace n = googleApi.GetInfo(string.Concat(s.stationinfo.locationY + "," + s.stationinfo.locationX));
                GetDelaysAPI.Station stat = new GetDelaysAPI.Station();
                stat.stationinfo.id = s.stationinfo.id;
                stat.stationinfo.locationX = s.stationinfo.locationX;
                stat.stationinfo.locationY = s.stationinfo.locationY;
                stat.stationinfo.name = s.stationinfo.name;
                if (n.result.opening_hours!=null)
                {
                    stat.stationinfo.opening_hours = n.result.opening_hours.weekday_text;
                }
                stat.stationinfo.rating = n.result.rating;
                foreach (GoogleAPI.Review r in n.result.reviews)
                {
                    stat.stationinfo.reviews.Add(new GetDelaysAPI.Review { author_name = r.author_name, rating = r.rating, text = r.text });
                }
                foreach (SNCBAPI.ArrDep arrdep in s.arrivals.arrival)
                {
                    DateTime hourTrain = new DateTime();
                    hourTrain=hourTrain.AddSeconds(arrdep.time);
                    hourTrain=hourTrain.AddMinutes(arrdep.delay);
                    if(now.TimeOfDay<hourTrain.TimeOfDay)
                    {
                        stat.arrivals.Add(new ArrivalDeparture { delay = arrdep.delay, id = arrdep.id, station = arrdep.station, time = arrdep.time.ToString(), vehicle = arrdep.vehicle });
                    }
                }
                foreach (SNCBAPI.ArrDep arrdep in s.departures.departure)
                {
                    DateTime hourTrain = new DateTime();
                    hourTrain = hourTrain.AddSeconds(arrdep.time);
                    hourTrain = hourTrain.AddMinutes(arrdep.delay);
                    if (now.TimeOfDay < hourTrain.TimeOfDay)
                    {
                        stat.departures.Add(new ArrivalDeparture { delay = arrdep.delay, id = arrdep.id, station = arrdep.station, time = arrdep.time.ToString(), vehicle = arrdep.vehicle });
                    }
                }
                return stat;
            }
            else
            {
                return null;
            }
        }
    }
}