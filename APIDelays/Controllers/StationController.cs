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
        [HttpGet]
        public IEnumerable<StationData> SearchStation()
        {
            
            IGetAll newaccessapi = GetAll.Instance();
            List<SNCBAPI.Station> stations = newaccessapi.GetStations();
            List<StationData> stats = new List<StationData>();
            foreach (SNCBAPI.Station s in stations)
            {
                stats.Add(new StationData { name = s.name, locationX = s.locationX, locationY = s.locationY, id = s.id});
            }
            return stats;
        }
        [HttpGet]
        public GetDelaysAPI.Station GetStationsByName(string station)
        {
            if (station !=null)
            {
                IGetAPIGoogle googleApi = new SearchPlaceAPI();
                IGetAll newaccessapi = GetAll.Instance();
                DataApiPerStations s = newaccessapi.GetDelaysForStation(station);
                DetailsPlace n = googleApi.GetInfo(string.Concat(s.stationinfo.locationY + "," + s.stationinfo.locationX));
                GetDelaysAPI.Station stat = new GetDelaysAPI.Station();
                stat.stationinfo.id = s.stationinfo.id;
                stat.stationinfo.locationX = s.stationinfo.locationX;
                stat.stationinfo.locationY = s.stationinfo.locationY;
                stat.stationinfo.name = s.stationinfo.name;
                stat.stationinfo.opening_hours = n.result.opening_hours.weekday_text;
                stat.stationinfo.place_id = n.result.place_id;
                stat.stationinfo.rating = n.result.rating;
                foreach (GoogleAPI.Review r in n.result.reviews)
                {
                    stat.stationinfo.reviews.Add(new GetDelaysAPI.Review { author_name = r.author_name, rating = r.rating, text = r.text });
                }
                foreach (SNCBAPI.ArrDep arrdep in s.arrivals.arrival)
                {
                    stat.arrivals.Add(new ArrivalDeparture { delay = arrdep.delay, id = arrdep.id, station = arrdep.station, time = arrdep.tForView, vehicle = arrdep.vehicle });
                }
                foreach (SNCBAPI.ArrDep arrdep in s.departures.departure)
                {
                    stat.departures.Add(new ArrivalDeparture { delay = arrdep.delay, id = arrdep.id, station = arrdep.station, time = arrdep.tForView, vehicle = arrdep.vehicle });
                }
                // à finir, y mettre les data de google avec pour simplifier
                return stat;
            }
            else
            {
                return null;
            }
        }
    }
}