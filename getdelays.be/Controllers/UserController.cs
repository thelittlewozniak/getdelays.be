using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GETDELAYSAPI;

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
            User testUserInformation = IAPI.Login(email, password);
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
            IUser userDAL = new DALUser();
            password = EncryptPassword(password);
            if (userDAL.GetUser(email)==null)
            {
                User user = new User { name = name, surname = surname, email = email, password = password, phoneNumber = Convert.ToInt32(phoneNumber) };
                userDAL.AddUser(user);
                Session["user"] = userDAL.GetUser(user.email);
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
            IUser userDAL = new DALUser();
            User user = (User)Session["user"];
            if (user == null)
            {
                return View("Login");
            }
            else
            {
                userDAL.DeleteUser(user);
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
            IUser userDAL = new DALUser();
            User user = (User)Session["user"];
            if (user == null)
            {
                return View("Login");
            }
            else
            {
                User newUser = new User { name = name, surname = surname, email = email, phoneNumber = Convert.ToInt32(phoneNumber) };
                userDAL.UpdateUser(user, newUser);
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