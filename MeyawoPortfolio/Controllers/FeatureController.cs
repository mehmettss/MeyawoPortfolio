using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MeyawoPortfolio.Models;

namespace MeyawoPortfolio.Controllers
{
    public class FeatureController : Controller
    {
        DbMyPortfolioEntities db = new DbMyPortfolioEntities();
        public ActionResult Index()
        {
            var values = db.TblFeature.ToList();
            return View(values);
        }
        [HttpGet]
        public ActionResult EditFeature(int id) 
        {
            var values = db.TblFeature.Find(id);
            return View(values);
        }
        [HttpPost]
        public ActionResult EditFeature(TblFeature p)
        {
            var values = db.TblFeature.Find(p.FeatureID);
            values.Header = p.Header;
            values.NameSurname = p.NameSurname;
            values.Title = p.Title;
            db.SaveChanges();
            return RedirectToAction("index");
        }
    }
}