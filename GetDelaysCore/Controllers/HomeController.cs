using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using GetDelaysCore.Models;
using Microsoft.AspNetCore.Http;

namespace GetDelaysCore.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.user=HttpContext.Session.GetString("email");
            return View();
        }
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
