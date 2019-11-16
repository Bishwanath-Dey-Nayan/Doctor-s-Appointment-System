using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using DAS.Models.ViewModel;

namespace DAS.Controllers
{
    public class AccountController : Controller
    {
        private DataBaseContext db = new DataBaseContext();
        // GET: Account
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(Login login)
        {
            var count = db.Logins.Where(x => x.Email == login.Email && x.Password == login.Password).Count();
            var loggedUser = db.Logins.Where(x => x.Email == login.Email && x.Password == login.Password).FirstOrDefault();
            Session["UserEmail"] = loggedUser.Email;

            if (count == 0)
            {
                ViewBag.Message = "Invalid User";
                return View();
            }
            else
            {
                FormsAuthentication.SetAuthCookie(login.Email, false);

                if (loggedUser.Role == "D")
                {
                    return RedirectToAction("ShowDoctor", "Home");
                }
               if(loggedUser.Role == "A")
                {
                    return RedirectToAction("ShowAdmin", "Home");
                }
            }
            return View();
            
        }


        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }
    }
}