using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Money_Wave_App.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult UserIndex(int? id)
        {
            return View();
        }
    }
}