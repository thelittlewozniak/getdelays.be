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
            ViewBag.s = stations;
            return View();
        }
        public ActionResult GetStationsByName(string station)
        {
            if (station !=null)
            {
                IGetAPIGoogle googleApi = new SearchPlaceAPI();
                IGetAll newaccessapi = GetAll.Instance();
                DataApiPerStations s = newaccessapi.GetDelaysForStation(station);
                DetailsPlace n = googleApi.GetInfo(string.Concat(s.stationinfo.locationY + "," + s.stationinfo.locationX));
                ViewBag.InfoStation = googleApi.GetInfo(string.Concat(s.stationinfo.locationY + "," + s.stationinfo.locationX));
                ViewBag.station = s;
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
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
                return RedirectToAction("Login", "User");
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
                return RedirectToAction("Index", "User", new { station });
            }
            else
            {
                return RedirectToAction("Login", "User");
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
                return RedirectToAction("Login", "User");
            }
        }
    }
}