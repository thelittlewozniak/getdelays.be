using getdelays.be.Models;
using getdelays.be.Models.DAL;
using getdelays.be.Models.POCO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace getdelays.be.Controllers
{
    public class StationController : Controller
    {
        // GET: Station
        public ActionResult Index()
        {
            return RedirectToAction("SearchStation","Station");
        }
        public ActionResult SearchStation()
        {
            IGetAll newaccessapi = GetAll.Instance();
            List<Station> stations = newaccessapi.GetStations();
            List<SelectListItem> st = new List<SelectListItem>();
            foreach (var s in stations)
            {
                byte[] bytes = Encoding.Default.GetBytes(s.name);
                var myString = Encoding.UTF8.GetString(bytes);
                s.name = myString;
            }
            ViewBag.s = stations;
            return View();
        }
        public ActionResult GetStationsByName(string station)
        {
            IGetAPIGoogle googleApi = new SearchPlaceAPI();
            IGetAll newaccessapi = GetAll.Instance();
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
                a.delay = a.delay / 60;
            }
            foreach (ArrDep a in s.departures.departure)
            {
                byte[] by = Encoding.Default.GetBytes(a.station);
                a.station = Encoding.UTF8.GetString(by);
                DateTime date = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
                date = date.AddSeconds(a.time).ToLocalTime();
                a.tForView = date.ToLongTimeString();
                a.delay = a.delay / 60;
            }
            DetailsPlace n = googleApi.GetInfo(string.Concat(s.stationinfo.locationY + "," + s.stationinfo.locationX));
            ViewBag.InfoStation = googleApi.GetInfo(string.Concat(s.stationinfo.locationY + "," + s.stationinfo.locationX));
            ViewBag.station = s;
            return View();
        }
        public ActionResult GetArrival(string station)
        {
            IGetAll newaccessapi = GetAll.Instance();
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
                a.delay = a.delay / 60;
            }
            ViewBag.station = s;
            return View();
        }
        public ActionResult GetDeparture(string station)
        {
            IGetAll newaccessapi = GetAll.Instance();
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
                a.delay = a.delay / 60;
            }
            ViewBag.station = s;
            return View();
        }
        public ActionResult FollowStation(string station)
        {
            User u = (User)Session["user"];
            IFollowedStation followedStation = new DALFollowedStation();
            if (u != null)
            {
                followedStation.AddFollowedStation(new FollowedStation { stationName = station, user = u });
                return RedirectToAction("GetStationsByName", "Station", new { station });
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }
        public ActionResult DeleteFollowStationProfile(string station)
        {
            User u = (User)Session["user"];
            IFollowedStation followedStation = new DALFollowedStation();
            if (u != null)
            {
                FollowedStation f = followedStation.GetFollowedStation(station, u);
                followedStation.DeleteFollowedStation(f);
                u.followedStations.Remove(f);
                Session["user"] = u;
                return RedirectToAction("Index", "Profil", new { station });
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }
        public ActionResult DeleteFollowStationStation(string station)
        {
            User u = (User)Session["user"];
            IFollowedStation followedStation = new DALFollowedStation();
            if (u != null)
            {
                FollowedStation f = followedStation.GetFollowedStation(station, u);
                followedStation.DeleteFollowedStation(f);
                u.followedStations.Remove(f);
                Session["user"] = u;
                return RedirectToAction("GetStationsByName", "Station", new { station });
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }
    }
}