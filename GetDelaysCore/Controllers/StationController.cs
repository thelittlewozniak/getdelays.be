using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GetDelaysAPI;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GetDelaysCore.Controllers
{
    public class StationController : Controller
    {
        public IActionResult Index()
        {
            return RedirectToAction("SearchStation", "Station");
        }
        public IActionResult SearchStation()
        {
            IAPI api = new GetAll();
            ViewBag.s = api.SearchStation();
            return View();
        }
        public IActionResult GetStationsByName(string station)
        {
            if (station != null)
            {
                IAPI api = new GetAll();
                ViewBag.station = api.GetStationsByName(station);
                ViewBag.user = api.GetUser(HttpContext.Session.GetString("email"));
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }
        public IActionResult FollowStation(string station)
        {
            IAPI api = new GetAll();
            User u = api.GetUser(HttpContext.Session.GetString("email"));
            if (u != null)
            {
                api.FollowStation(station, u);
                ViewBag.user = api.GetUser(HttpContext.Session.GetString("email"));
                return RedirectToAction("GetStationsByName", "Station", new { station });
            }
            else
            {
                return RedirectToAction("ConnectionPage", "User");
            }
        }
        public IActionResult DeleteFollowStationProfile(string station)
        {
            IAPI api = new GetAll();
            User u = api.GetUser(HttpContext.Session.GetString("email"));
            if (u != null)
            {
                api.DeleteFollowStation(station, u);
                ViewBag.user = api.GetUser(HttpContext.Session.GetString("email"));
                return RedirectToAction("Index", "User", new { station });
            }
            else
            {
                return RedirectToAction("ConnectionPage", "User");
            }
        }
        public IActionResult DeleteFollowStationStation(string station)
        {
            IAPI api = new GetAll();
            User u = api.GetUser(HttpContext.Session.GetString("email"));
            if (u != null)
            {
                api.DeleteFollowStation(station, u);
                ViewBag.user = api.GetUser(HttpContext.Session.GetString("email"));
                return RedirectToAction("GetStationsByName", "Station", new { station });
            }
            else
            {
                return RedirectToAction("ConnectionPage", "User");
            }
        }
    }
}