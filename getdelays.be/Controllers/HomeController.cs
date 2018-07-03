using GetDelaysAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace getdelays.be.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            IAPI api = new GetAll();
            ViewBag.CountStation = api.SearchStation().Count();
            ViewBag.s = api.SearchStation();
            return View();
        }
        public ActionResult error()
        {
            return View();
        }
    }
}