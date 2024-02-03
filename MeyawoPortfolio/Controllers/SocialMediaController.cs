using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MeyawoPortfolio.Models;

namespace MeyawoPortfolio.Controllers
{
    public class SocialMediaController : Controller
    {
        DbMyPortfolioEntities db = new DbMyPortfolioEntities();
        public ActionResult Index()
        {
            var values = db.TblSocialMedia.ToList();
            return View(values);
        }
        [HttpGet]
        public ActionResult CreateSocialMedia()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateSocialMedia(TblSocialMedia p)
        {
            db.TblSocialMedia.Add(p);
            db.SaveChanges();
            return RedirectToAction("index");
        }
        public ActionResult DeleteSocialMedia(int id)
        {
            var values = db.TblSocialMedia.Find(id);
            db.TblSocialMedia.Remove(values); 
            db.SaveChanges();
            return RedirectToAction("index");

        }
        [HttpGet]
        public ActionResult EditSocialMedya(int id)
        {
            var values = db.TblSocialMedia.Find(id);
            return View(values);
        }
        [HttpPost]
        public ActionResult EditSocialMedya(TblSocialMedia p)
        {
            var values = db.TblSocialMedia.Find(p.SocialMediaID);
            values.Title = p.Title;
            values.SocialMediaUrl = p.SocialMediaUrl;
            values.Icon = p.Icon;
            db.SaveChanges();
            return RedirectToAction("index");
        }
    }
}