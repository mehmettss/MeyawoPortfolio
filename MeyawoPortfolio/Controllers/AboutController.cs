using MeyawoPortfolio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MeyawoPortfolio.Controllers
{
    public class AboutController : Controller
    {
        DbMyPortfolioEntities db = new DbMyPortfolioEntities();
        public ActionResult Index()
        {
            var values = db.TblAbout.ToList();
            return View(values);
        }
        [HttpGet]
        public ActionResult EditAbout(int id)
        {
            var values = db.TblAbout.Find(id);
            return View(values);
        }
        [HttpPost]
        public ActionResult EditAbout(TblAbout p)
        {
            var values = db.TblAbout.Find(p.AboutID);
            values.Header = p.Header;
            values.Title = p.Title;
            values.Description = p.Description;
            values.ImageUrl = p.ImageUrl;
            db.SaveChanges();
            return RedirectToAction("index");
        }
    }
}