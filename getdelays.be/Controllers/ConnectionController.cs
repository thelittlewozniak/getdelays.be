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
        [HttpPost]
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
    }
}