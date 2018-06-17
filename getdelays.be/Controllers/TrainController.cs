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
            ViewBag.stops = s;
            return View("GetTrain");
        }
        public ActionResult GetTrainFromStation(string idTrain,string StationName)
        {
            IGetAll newaccessapi = GetAll.Instance();
            DataApiTrain s = newaccessapi.GetTrain(idTrain,StationName);
            ViewBag.stops = s;
            return View("GetTrain");
        }

    }
}