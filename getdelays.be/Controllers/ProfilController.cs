using getdelays.be.Models.DAL;
using getdelays.be.Models.POCO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace getdelays.be.Controllers
{
    public class ProfilController : Controller
    {
        // GET: Profil
        public ActionResult Index()
        {
            User user = (User)Session["user"];
            if (user == null)
            {
                return RedirectToAction("Index", "Login");
            }
            else
            {
                ViewBag.user = user;
                return View();
            }
        }
        public ActionResult DeleteUser()
        {
            IUser userDAL = new DALUser();
            User user = (User)Session["user"];
            if (user == null)
            {
                return RedirectToAction("Index", "Login");
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
                return RedirectToAction("Index", "Login");
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
                return RedirectToAction("Index", "Login");
            }
            else
            {
                User newUser = new User { name = name, surname = surname, email = email, phoneNumber = Convert.ToInt32(phoneNumber) };
                userDAL.UpdateUser(user, newUser);
                return RedirectToAction("Index", "Profil");
            }
        }
    }
}