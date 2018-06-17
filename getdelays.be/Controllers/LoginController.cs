using getdelays.be.Models.DAL;
using getdelays.be.Models.POCO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace getdelays.be.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            if(Session["user"]==null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }
        [HttpPost]
        public ActionResult Login(string email,string password)
        {
            IUser user = new DALUser();
            User testUserInformation = user.Login(email, password);
            if (testUserInformation==null)
            {
                ViewBag.error = "Email or password incorrect.";
                return View("Index");
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
            IUser userDAL = new DALUser();
            if(userDAL.GetUser(email)==null)
            {
                User user = new User { name = name, surname = surname, email = email, password = password, phoneNumber = Convert.ToInt32(phoneNumber) };
                userDAL.AddUser(user);
                Session["user"] = userDAL.GetUser(user.email);
                return RedirectToAction("Index", "Profil");
            }
            else
            {
                ViewBag.error = "An account is already link to this email.";
                return View("Index");
            }
        }
    }
}