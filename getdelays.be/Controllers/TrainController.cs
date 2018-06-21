using GetDelaysAPI;
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
            IAPI data = new GetAll();
            Train train = data.GetTrain(idTrain);
            ViewBag.train = train;
            return View("GetTrain");
        }
        public ActionResult GetTrainFromStation(string idTrain,string StationName)
        {
            IAPI api = new GetAll();
            ViewBag.train = api.GetTrainFromStation(idTrain,StationName);
            return View("GetTrain");
        }

    }
}