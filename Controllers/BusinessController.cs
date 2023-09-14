using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Money_Wave_App.Controllers
{
    public class BusinessController : Controller
    {
        // GET: Business
        public ActionResult BusinessIndex()
        {
            return View();
        }
    }
}