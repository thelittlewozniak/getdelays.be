using getdelays.be.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

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
            IGetAll newaccessapi = GetAll.Instance();
            List<Station> stations = newaccessapi.GetStations();
            ViewBag.s = stations;
            return View();
        }
        [HttpPost]
        public ActionResult GetConnection(string dep, string arr)
        {
            IGetAPIGoogle googleApi = new SearchPlaceAPI();
            IGetAll newaccessapi = GetAll.Instance();
            DataApiConnection s = newaccessapi.GetConnection(dep,arr);
            ViewBag.Connection = s;
            return View();

        }
    }
}