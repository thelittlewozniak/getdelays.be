using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using getdelays.be.Controllers;
using GetDelaysAPI;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace GetDelaysCore.Controllers
{
    public class UserController : Controller
    {
        private static readonly HttpClient client = new HttpClient();
        public IActionResult Index()
        {
            if(HttpContext.Session.GetString("email")!=null)
            {
                IAPI api = new GetAll();
                ViewBag.user = api.GetUser(HttpContext.Session.GetString("email"));
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }
        public IActionResult ConnectionPage()
        {
            IAPI api = new GetAll();
            if (HttpContext.Session.GetString("email") == null)
            {
                return View("Login");
            }
            else
            {
                ViewBag.user = api.GetUser(HttpContext.Session.GetString("email"));
                return View("Index");
            }
        }
        [HttpPost]
        public IActionResult Login(string email, string password)
        {
            password = EncryptPassword(password);
            IAPI api = new GetAll();
            User testUserInformation = api.Login(email, password);
            if (testUserInformation == null)
            {
                ViewBag.error = "Email or password incorrect.";
                return View("Login");
            }
            else
            {
                HttpContext.Session.SetString("email",testUserInformation.email);
                ViewBag.user = api.GetUser(email);
                return RedirectToAction("Index", "Home");
            }
        }
        public IActionResult Disconnect()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Home");
        }
        public IActionResult CreateAccount()
        {
            return View();
        }
        [HttpPost]
        public IActionResult MakeAccount(string email, string name, string surname, string password, string phoneNumber)
        {
            string response = Request.Form["g-recaptcha-response"];
            var json = new WebClient().DownloadString("https://www.google.com/recaptcha/api/siteverify?secret=6Le9eGEUAAAAAJt22PAEWs18klrzAqzEeRnYTlJp&response=" + response);
            var success = JsonConvert.DeserializeObject<GoogleResponseCaptcha>(json);
            if (success.success)
            {
                IAPI api = new GetAll();
                password = EncryptPassword(password);
                User u = api.GetUser(email);
                if (u == null)
                {
                    api.MakeAccount(email, name, surname, password, phoneNumber);
                    HttpContext.Session.SetString("email", email);
                    ViewBag.user = api.GetUser(email);
                    return View("Index");
                }
                else
                {
                    ViewBag.error = "An account is already link to this email.";
                    return View("CreateAccount");
                }
            }
            else
            {
                ViewBag.error = "Captcha error";
                return View("CreateAccount");
            }
        }
        //public ActionResult DeleteUser()
        //{
        //    IAPI api = new GetAll();
        //    User user = (User)Session["user"];
        //    if (user == null)
        //    {
        //        return View("Login");
        //    }
        //    else
        //    {
        //        if (api.DeleteUser(user))
        //        {
        //            Session["user"] = null;
        //            return RedirectToAction("Index", "Home");
        //        }
        //    }
        //}
        public ActionResult MakeChangeInformation()
        {
            IAPI api = new GetAll();
            string email = HttpContext.Session.GetString("email");
            if (email == null)
            {
                return View("Login");
            }
            else
            {
                User user = api.GetUser(email);
                ViewBag.user = user;
                return View();
            }
        }
        [HttpPost]
        public ActionResult MakeChange(string name, string surname, string phoneNumber)
        {
            IAPI api = new GetAll();
            string email = HttpContext.Session.GetString("email");
            if (email == null)
            {
                return View("Login");
            }
            else
            {
                User user = api.GetUser(email);
                api.UpdateUser(name, surname, phoneNumber, user);
                ViewBag.user = api.GetUser(email);
                return View("Index");
            }
        }
        public ActionResult Notification()
        {
            IAPI api = new GetAll();
            string email = HttpContext.Session.GetString("email");
            if (email == null)
            {
                return View("Login");
            }
            else
            {
                User user = api.GetUser(email);
                ViewBag.NotificationStations = api.GetNotificationStations(user);
                ViewBag.NotificationConnections = api.GetNotificationConnections(user);
                return View();
            }
        }
        private string EncryptPassword(string password)
        {
            byte[] bytePassword = System.Text.Encoding.ASCII.GetBytes(password);
            bytePassword = new System.Security.Cryptography.SHA256Managed().ComputeHash(bytePassword);
            return System.Text.Encoding.ASCII.GetString(bytePassword);
        }

    }
}