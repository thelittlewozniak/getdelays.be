using getdelays.be.Models;
using getdelays.be.Models.DAL;
using getdelays.be.Models.POCO;
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
            IGetAll newaccessapi = GetAll.Instance();
            ViewBag.CountStation = newaccessapi.GetStations().Count();
            return View();
        }
        public ActionResult error()
        {
            return View();
        }
    }
}