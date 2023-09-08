using Money_Wave_App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Money_Wave_App.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        MoneyWaveEntities2 db = new MoneyWaveEntities2();
        public ActionResult Login()
        {

            return View();
        }
        public ActionResult Login(string user_email, string password)
        {
            validateUser_Result userRole = db.validateUser(user_email, password).FirstOrDefault();
            string msg = string.Empty;
            if (userRole.user_id != -1)
            {
                FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(1, user_email, DateTime.Now, DateTime.Now.AddMinutes(30), true, userRole.role_name, FormsAuthentication.FormsCookiePath);
                string hash = FormsAuthentication.Encrypt(ticket);
                HttpCookie cookie = new HttpCookie(FormsAuthentication.FormsCookieName, hash);
                if (ticket.IsPersistent)
                {
                    cookie.Expires = ticket.Expiration;
                }
                Response.Cookies.Add(cookie);
                return RedirectToAction("Index", "Home");
            }
            else
            {
                msg = "User Name or Password is Invalid";
            }
            ViewBag.Msg = msg;
            return View();
        }
       
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login","Login");
        }

    }
}