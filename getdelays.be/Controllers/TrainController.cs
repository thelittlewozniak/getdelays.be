using getdelays.be.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace getdelays.be.Controllers
{
    public class TrainController : Controller
    {
        // GET: Train
        public ActionResult Index()
        {
            return RedirectToAction("SearchStation", "Station");
        }
        public ActionResult GetTrain(string idTrain)
        {
            IGetAll newaccessapi = GetAll.Instance();
            DataApiTrain s = newaccessapi.GetTrain(idTrain);
            foreach (Stop a in s.stops.stop)
            {
                byte[] by = Encoding.Default.GetBytes(a.station);
                a.station = Encoding.UTF8.GetString(by);
                DateTime time = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
                time = time.AddSeconds(a.time).ToLocalTime();
                a.tForView = time.ToLongTimeString();
                a.delay = a.delay / 60;
            }
            ViewBag.stops = s;
            return View();
        }

    }
}