using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using GetDelaysAPI;

namespace getdelays.be.Controllers
{
    public class ConnectionController : Controller
    {
        // GET: Connection
        public ActionResult Index()
        {
            return RedirectToAction("SearchConnection", "Connection");
        }
        public ActionResult SearchConnection()
        {
            IAPI api = new GetAll();
            ViewBag.s = api.SearchStation();
            return View();
        }
        [HttpGet]
        public ActionResult GetConnection(string dep, string arr)
        {
            if(dep!=null && arr!=null)
            {
                if(dep!="" && arr!="")
                {
                    IAPI api = new GetAll();
                    ViewBag.Connections = api.GetConnection(dep,arr);
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
        public ActionResult GetConnectionTime(string dep, string arr,string time)
        {
            if (dep != null && arr != null)
            {
                if (dep != "" && arr != "")
                {
                    IAPI api = new GetAll();
                    ViewBag.Connection = api.GetConnection(dep, arr,Convert.ToDateTime(time));
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

        public ActionResult FollowConnection(string arrival,string departure,string time)
        {
            User u = (User)Session["user"];
            IAPI api = new GetAll();
            if (u != null)
            {
                Session["user"] = api.FollowConnection(arrival,departure,time,"true",u);
                return RedirectToAction("GetConnection", "Connection", new { dep=departure, arr=arrival });
            }
            else
            {
                return RedirectToAction("ConnectionPage", "User");
            }
        }
        public ActionResult DeleteFollowConnectionProfile(string ConnectionId)
        {
            User u = (User)Session["user"];
            IAPI api = new GetAll();
            if (u != null)
            {
                Session["user"] = api.DeleteFollowConnection(ConnectionId,u);
                return RedirectToAction("Index", "User");
            }
            else
            {
                return RedirectToAction("ConnectionPage", "User");
            }
        }
        public ActionResult DeleteFollowConnectionConnection(string ConnectionId,string departure,string arrival)
        {
            User u = (User)Session["user"];
            IAPI api = new GetAll();
            if (u != null)
            {
                Session["user"] = api.DeleteFollowConnection(ConnectionId, u);
                return RedirectToAction("GetConnection", "Connection", new { dep = departure, arr = arrival });
            }
            else
            {
                return RedirectToAction("ConnectionPage", "User");
            }
        }

    }
}