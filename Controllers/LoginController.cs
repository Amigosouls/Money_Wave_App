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
        MoneyWaveEntities db = new MoneyWaveEntities();
        public ActionResult Index()
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
                if(userRole.role_name == "Users")
                {
                    User logged_user = db.Users.FirstOrDefault(u => u.email == user_email);
                    Session["UserData"] = logged_user.username;
                    Session["UserImg"] = logged_user.img;
                }
                else if(userRole.role_name == "Admin")
                {
                    Admin logged_user = db.Admins.FirstOrDefault(u => u.email_id == user_email);
                    Session["UserData"] = logged_user.admin_name;

                }
                else if (userRole.role_name == "Business")
                {
                    Business logged_user = db.Businesses.FirstOrDefault(u => u.email == user_email);
                    Session["UserData"] = logged_user
                        .acronym;
                    Session["UserImg"] = logged_user.logo;
                }
                return RedirectToAction("Index", "Home");
            }
            else
            {
                msg = "User Name or Password is Invalid";
                ViewBag.Msg = msg;
                return RedirectToAction("Index", "Login");
            }
           
        }
       
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index","Home");
        }

        public ActionResult Register()
        {
            return RedirectToAction("UserRegister","Register");
        }

    }
}