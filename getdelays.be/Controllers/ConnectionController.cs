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
            foreach (var s in stations)
            {
                byte[] bytes = Encoding.Default.GetBytes(s.name);
                var myString = Encoding.UTF8.GetString(bytes);
                s.name = myString;
            }
            ViewBag.s = stations;
            return View();
        }
        [HttpPost]
        public ActionResult GetConnection(string dep, string arr)
        {
            IGetAPIGoogle googleApi = new SearchPlaceAPI();
            IGetAll newaccessapi = GetAll.Instance();
            DataApiConnection s = newaccessapi.GetConnection(dep,arr);
            foreach (Connection c in s.connection)
            {
                byte[] b = Encoding.Default.GetBytes(c.arrival.station);
                c.arrival.station = Encoding.UTF8.GetString(b);
                DateTime dateArr = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
                dateArr = dateArr.AddSeconds(c.arrival.time).ToLocalTime();
                c.arrival.tForView = dateArr.ToLongTimeString();
                byte[] by = Encoding.Default.GetBytes(c.departure.station);
                c.departure.station = Encoding.UTF8.GetString(by);
                DateTime dateDep = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
                dateDep = dateDep.AddSeconds(c.departure.time).ToLocalTime();
                c.departure.tForView = dateDep.ToLongTimeString();
                if (c.vias!=null)
                {
                    foreach (ViaInfo v in c.vias.via)
                    {
                        byte[] bv = Encoding.Default.GetBytes(v.station);
                        v.station = Encoding.UTF8.GetString(bv);
                        DateTime dateArrVia = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
                        dateArrVia = dateArr.AddSeconds(v.arrival.time).ToLocalTime();
                        v.arrival.TForView = dateArrVia.ToLongTimeString();
                        v.arrival.delay = v.arrival.delay / 60;
                        DateTime dateDepVia = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
                        dateDepVia = dateDepVia.AddSeconds(v.departure.time).ToLocalTime();
                        v.departure.TForView = dateDepVia.ToLongTimeString();
                        v.departure.delay = v.departure.delay / 60;
                        v.timeBetween = v.timeBetween / 60;
                    }
                }
            }
            ViewBag.Connection = s;
            return View();

        }
    }
}