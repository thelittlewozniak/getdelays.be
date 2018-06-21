using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GetDelaysAPI;

namespace getdelays.be.Controllers
{
    public class UserController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            if(Session["user"]!=null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }
        public ActionResult ConnectionPage()
        {
            return View("Login");
        }
        [HttpPost]
        public ActionResult Login(string email,string password)
        {
            password = EncryptPassword(password);
            IAPI api = new GetAll();
            User testUserInformation = api.Login(email, password);
            if (testUserInformation==null)
            {
                ViewBag.error = "Email or password incorrect.";
                return View("Login");
            }
            else
            {
                Session["user"] = testUserInformation;
                return RedirectToAction("Index", "Home");
            }
        }
        public ActionResult Disconnect()
        {
            Session["user"] = null;
            return RedirectToAction("Index", "Home");
        }
        public ActionResult CreateAccount()
        {
            return View();
        }
        [HttpPost]
        public ActionResult MakeAccount(string email,string name,string surname,string password,string phoneNumber)
        {
            IAPI api = new GetAll();
            password = EncryptPassword(password);
            User u = api.GetUser(email);
            if (u==null)
            {
                api.MakeAccount(email,name,surname,password,phoneNumber);
                Session["user"] = api.GetUser(email);
                return View("Login");
            }
            else
            {
                ViewBag.error = "An account is already link to this email.";
                return View("CreateAccount");
            }
        }
        public ActionResult DeleteUser()
        {
            IAPI api = new GetAll();
            User user = (User)Session["user"];
            if (user == null)
            {
                return View("Login");
            }
            else
            {
                api.DeleteUser(user);
                Session["user"] = null;
                return RedirectToAction("Index", "Home");
            }
        }
        public ActionResult MakeChangeInformation()
        {
            User user = (User)Session["user"];
            if (user == null)
            {
                return View("Login");
            }
            else
            {
                ViewBag.user = user;
                return View();
            }
        }
        [HttpPost]
        public ActionResult MakeChange(string email, string name, string surname, string phoneNumber)
        {
            IAPI api = new GetAll();
            User user = (User)Session["user"];
            if (user == null)
            {
                return View("Login");
            }
            else
            {
                api.UpdateUser(email,name,surname,phoneNumber, user);
                return View("Index");
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