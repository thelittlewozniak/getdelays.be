using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GetDelaysAPI;
using Microsoft.AspNetCore.Mvc;

namespace GetDelaysCore.Controllers
{
    public class TrainController : Controller
    {
        public IActionResult Index()
        {
            return RedirectToAction("SearchStation", "Station");
        }
        public IActionResult GetTrain(string idTrain)
        {
            IAPI data = new GetAll();
            Train train = data.GetTrain(idTrain);
            ViewBag.train = train;
            return View("GetTrain");
        }
        public IActionResult GetTrainFromStation(string idTrain, string StationName)
        {
            IAPI api = new GetAll();
            ViewBag.train = api.GetTrainFromStation(idTrain, StationName);
            return View("GetTrain");
        }

    }
}