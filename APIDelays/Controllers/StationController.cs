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

namespace getdelays.be.Controllers
{
    public class StationController : ApiController
    {
        // GET: Station
        [HttpGet]
        public string SearchStation()
        {
            IGetAll newaccessapi = GetAll.Instance();
            List<Station> stations = newaccessapi.GetStations();
            return JsonConvert.SerializeObject(stations);
        }
        [HttpGet]
        public string GetStationsByName(string station)
        {
            if (station !=null)
            {
                IGetAPIGoogle googleApi = new SearchPlaceAPI();
                IGetAll newaccessapi = GetAll.Instance();
                DataApiPerStations s = newaccessapi.GetDelaysForStation(station);
                DetailsPlace n = googleApi.GetInfo(string.Concat(s.stationinfo.locationY + "," + s.stationinfo.locationX));
                // à finir, y mettre les data de google avec pour simplifier
                return JsonConvert.SerializeObject(s);
            }
            else
            {
                return null;
            }
        }
    }
}