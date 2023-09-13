using Money_Wave_App.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Money_Wave_App.Controllers
{
    public class RegisterController : Controller
    {
        // GET: Register
        MoneyWaveEntities db = new MoneyWaveEntities();
        public ActionResult RegisterUsers()
        {
            ViewData.Clear();
            List<Role> user_roles = db.Roles.ToList();
            foreach (Role user in user_roles)
            {
                ViewData.Add(user.role_name, user.role_id);

            }
            Dictionary<string, int> region = new Dictionary<string, int>();
            List<Region> user_regions = db.Regions.ToList();
            foreach (Region user in user_regions)
            {
                region.Add(user.region_name, user.region_id);

            }
            ViewBag.region = region;
            return View();
        }
        [HttpPost]
        public ActionResult RegisterUser(HttpPostedFileBase img, User user)
        {
            user.last_login =DateTime.Now;
            user.role_id = 2;
            user.account_bal = 5000;
            user.isDeleted = false;
            string filename = Path.GetFileName(img.FileName);
            string _filename = DateTime.Now.ToString("yymmssfff") + filename;
            string extension = Path.GetExtension(img.FileName);
            string path = Path.Combine(Server.MapPath("~/Photos/"), _filename);
            user.img = "~/Photos/" + _filename;
            if(extension.ToLower() == ".jpg" || extension.ToLower() == ".jpeg" || extension.ToLower() == ".png")
            {
                if (img.ContentLength <= 1000000)
                {
                    db.Users.Add(user);
                    if (db.SaveChanges() > 0)
                    {
                        img.SaveAs(path);
                        ViewBag.Upload = "Photo Uploaded";
                    }
                }
                else
                {
                    ViewBag.UploadError = "Image size error";
                }
            }
            return RedirectToAction("RegisterUsers");
        }
        [HttpPost]
        public ActionResult SaveCapture(string data)
        {
            TempData.Clear();    
            string fileName = DateTime.Now.ToString("dd-mm-yy hh-mm-ss");
            byte[] imageBytes = Convert.FromBase64String(data.Split(',')[1]);
            string filepath = Server.MapPath(string.Format("~/Photos/{0}.jpg", fileName));
            System.IO.File.WriteAllBytes(filepath, imageBytes);
            TempData["img"] = "~/Photos/" + fileName + ".jpg";
            return View("true");
        }

        public ActionResult RegisterBusiness()
        {
            Dictionary<string,int> bus_region = new Dictionary<string,int>();
            List<Region> regions = db.Regions.ToList();
            foreach(Region area in regions)
            {
                bus_region.Add(area.region_name, area.region_id);

            }
            ViewBag.bus_region = bus_region;
           return View();
        }
        [HttpPost]
        public ActionResult BusinessRegister(HttpPostedFileBase logo , Business business)
        {
            business.role_id = 3;
            business.isActive = true;
            string filename = Path.GetFileName(logo.FileName);
            string _filename = DateTime.Now.ToString("yymmssfff") + filename;
            string extension = Path.GetExtension(logo.FileName);
            string path = Path.Combine(Server.MapPath("~/Photos/"), _filename);
            business.logo = "~/Photos/" + _filename;
            if (extension.ToLower() == ".jpg" || extension.ToLower() == ".jpeg" || extension.ToLower() == ".png")
            {
                if (logo.ContentLength <= 1000000)
                {
                    db.Businesses.Add(business);
                    if (db.SaveChanges() > 0)
                    {
                        logo.SaveAs(path);
                        ViewBag.Upload = "Photo Uploaded";
                    }
                }
                else
                {
                    ViewBag.UploadError = "Image size error";
                }
            }
            return RedirectToAction("RegisterBusiness");
        }
    }
}