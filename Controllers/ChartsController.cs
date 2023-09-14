using Money_Wave_App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web;
using System.Web.Mvc;


namespace Money_Wave_App.Controllers
{
    public class ChartsController : Controller
    {
        // GET: Charts
        MoneyWaveEntities db = new MoneyWaveEntities();
        public ActionResult Index()
        {
            
            return View();
        }
        public ActionResult SharesBarchart()
        {
            db.Configuration.ProxyCreationEnabled = false;
            return Json(db.Shares.ToList(), JsonRequestBehavior.AllowGet);
        }
        public ActionResult RegionsChart()
        {
            db.Configuration.ProxyCreationEnabled = false;
            return Json(db.Regions.ToList(), JsonRequestBehavior.AllowGet);
        }
    }
}