using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GetDelaysAPI;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GetDelaysCore.Controllers
{
    public class ConnectionController : Controller
    {
        public IActionResult Index()
        {
            return RedirectToAction("SearchConnection", "Connection");
        }
        public IActionResult SearchConnection()
        {
            IAPI api = new GetAll();
            ViewBag.s = api.SearchStation();
            return View();
        }
        [HttpGet]
        public IActionResult GetConnection(string dep, string arr)
        {
            if (dep != null && arr != null)
            {
                if (dep != "" && arr != "")
                {
                    IAPI api = new GetAll();
                    ViewBag.Connections = api.GetConnection(dep, arr);
                    ViewBag.user = api.GetUser(HttpContext.Session.GetString("email"));
                    return View();
                }
                else
                {
                    return RedirectToAction("SearchConnection", "Connection");
                }
            }
            else
            {
                return RedirectToAction("SearchConnection", "Connection");
            }
        }
        [HttpGet]
        public IActionResult GetConnectionTime(string dep, string arr, string time)
        {
            if (dep != null && arr != null)
            {
                if (dep != "" && arr != "")
                {
                    IAPI api = new GetAll();
                    ViewBag.Connection = api.GetConnection(dep, arr, Convert.ToDateTime(time));
                    ViewBag.user = api.GetUser(HttpContext.Session.GetString("email"));
                    return View();
                }
                else
                {
                    return RedirectToAction("SearchConnection", "Connection");
                }
            }
            else
            {
                return RedirectToAction("SearchConnection", "Connection");
            }
        }

        public IActionResult FollowConnection(string arrival, string departure, string time)
        {
            IAPI api = new GetAll();
            User u = api.GetUser(HttpContext.Session.GetString("email"));
            if (u != null)
            {
                api.FollowConnection(arrival, departure, time, "true", u);
                ViewBag.user = api.GetUser(HttpContext.Session.GetString("email"));
                return RedirectToAction("GetConnection", "Connection", new { dep = departure, arr = arrival });
            }
            else
            {
                return RedirectToAction("ConnectionPage", "User");
            }
        }
        public IActionResult DeleteFollowConnectionProfile(string ConnectionId)
        {
            IAPI api = new GetAll();
            User u = api.GetUser(HttpContext.Session.GetString("email"));
            if (u != null)
            {
                api.DeleteFollowConnection(ConnectionId, u);
                ViewBag.user = api.GetUser(HttpContext.Session.GetString("email"));
                return RedirectToAction("Index", "User");
            }
            else
            {
                return RedirectToAction("ConnectionPage", "User");
            }
        }
        public IActionResult DeleteFollowConnectionConnection(string ConnectionId, string departure, string arrival)
        {
            IAPI api = new GetAll();
            User u = api.GetUser(HttpContext.Session.GetString("email"));
            if (u != null)
            {
                api.DeleteFollowConnection(ConnectionId, u);
                ViewBag.user = api.GetUser(HttpContext.Session.GetString("email"));
                return RedirectToAction("GetConnection", "Connection", new { dep = departure, arr = arrival });
            }
            else
            {
                return RedirectToAction("ConnectionPage", "User");
            }
        }


    }
}