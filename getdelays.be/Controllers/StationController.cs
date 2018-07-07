using System;
using GetDelaysAPI;
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
            IAPI api = new GetAll();
            ViewBag.s = api.SearchStation(); 
            return View();
        }
        public ActionResult GetStationsByName(string station)
        {
            if (station !=null)
            {
                IAPI api = new GetAll();
                ViewBag.station = api.GetStationsByName(station);
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
            IAPI api = new GetAll();
            if (u != null)
            {
                Session["user"] = api.FollowStation(station, u);
                return RedirectToAction("GetStationsByName", "Station", new { station });
            }
            else
            {
                return RedirectToAction("ConnectionPage", "User");
            }
        }
        public ActionResult DeleteFollowStationProfile(string station)
        {
            User u = (User)Session["user"];
            IAPI api = new GetAll();
            if (u != null)
            {
                Session["user"] = api.DeleteFollowStation(station, u);
                return RedirectToAction("Index", "User", new { station });
            }
            else
            {
                return RedirectToAction("ConnectionPage", "User");
            }
        }
        public ActionResult DeleteFollowStationStation(string station)
        {
            User u = (User)Session["user"];
            IAPI api = new GetAll();
            if (u != null)
            {
                Session["user"] = api.DeleteFollowStation(station, u);
                return RedirectToAction("GetStationsByName", "Station", new { station });
            }
            else
            {
                return RedirectToAction("ConnectionPage", "User");
            }
        }
    }
}