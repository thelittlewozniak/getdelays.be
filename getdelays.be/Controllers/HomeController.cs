using getdelays.be.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace getdelays.be.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            GetAll newaccessapi = GetAll.Instance();
            ViewBag.CountStation = newaccessapi.GetStations().Count();
            return View();
        }
        public ActionResult SearchStation()
        {
            GetAll newaccessapi = GetAll.Instance();
            List<Station> stations = newaccessapi.GetStations();
            List<SelectListItem> st = new List<SelectListItem>();
            foreach (var s in stations)
            {
                byte[] bytes = Encoding.Default.GetBytes(s.name);
                var myString = Encoding.UTF8.GetString(bytes);
                st.Add(new SelectListItem { Text = myString, Value = myString });
            }
            ViewBag.stations = st;
            return View();
        }
        [HttpPost]
        public ActionResult GetStationsByName(string station)
        {
            GetAll newaccessapi = GetAll.Instance();
            DataApiPerStations s = newaccessapi.GetDelaysForStation(station);
            byte[] b = Encoding.Default.GetBytes(s.stationinfo.name);
            s.stationinfo.name = Encoding.UTF8.GetString(b);
            foreach (ArrDep a in s.arrivals.arrival)
            {
                byte[] by = Encoding.Default.GetBytes(a.station);
                a.station = Encoding.UTF8.GetString(by);
                DateTime date = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
                date = date.AddSeconds(a.time).ToLocalTime();
                a.tForView = date.ToLongTimeString();
            }
            foreach (ArrDep a in s.departures.departure)
            {
                byte[] by = Encoding.Default.GetBytes(a.station);
                a.station = Encoding.UTF8.GetString(by);
                DateTime date = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
                date = date.AddSeconds(a.time).ToLocalTime();
                a.tForView = date.ToLongTimeString();
            }
            ViewBag.station=s;
            return View();
        }
        public ActionResult GetArrival(string station)
        {
            GetAll newaccessapi = GetAll.Instance();
            DataApiPerStations s = newaccessapi.GetArrival(station);
            byte[] b = Encoding.Default.GetBytes(s.stationinfo.name);
            s.stationinfo.name = Encoding.UTF8.GetString(b);
            foreach (ArrDep a in s.arrivals.arrival)
            {
                byte[] by = Encoding.Default.GetBytes(a.station);
                a.station = Encoding.UTF8.GetString(by);
                DateTime date = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
                date = date.AddSeconds(a.time).ToLocalTime();
                a.tForView = date.ToLongTimeString();
            }
            ViewBag.station = s;
            return View();
        }
        public ActionResult GetDeparture(string station)
        {
            GetAll newaccessapi = GetAll.Instance();
            DataApiPerStations s = newaccessapi.GetDeparture(station);
            byte[] b = Encoding.Default.GetBytes(s.stationinfo.name);
            s.stationinfo.name = Encoding.UTF8.GetString(b);
            foreach (ArrDep a in s.departures.departure)
            {
                byte[] by = Encoding.Default.GetBytes(a.station);
                a.station = Encoding.UTF8.GetString(by);
                DateTime date = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
                date = date.AddSeconds(a.time).ToLocalTime();
                a.tForView = date.ToLongTimeString();
            }
            ViewBag.station = s;
            return View();
        }
        public ActionResult GetTrain(string idTrain)
        {
            GetAll newaccessapi = GetAll.Instance();
            DataApiTrain s = newaccessapi.GetTrain(idTrain);
            foreach (Stop a in s.stops.stop)
            {
                byte[] by = Encoding.Default.GetBytes(a.station);
                a.station = Encoding.UTF8.GetString(by);
                DateTime time = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
                time = time.AddSeconds(a.time).ToLocalTime();
                a.tForView = time.ToLongTimeString();
            }
            ViewBag.stops = s;
            return View();
        }
    }
}