using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MeyawoPortfolio.Models;

namespace MeyawoPortfolio.Controllers
{
    public class ServiceController : Controller
    {
        DbMyPortfolioEntities db = new DbMyPortfolioEntities();
        public ActionResult Index()
        {
            var values = db.TblService.ToList();
            return View(values);
        }
        [HttpGet]
        public ActionResult CreateService()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateService(TblService p)
        {
            db.TblService.Add(p);
            db.SaveChanges();
            return RedirectToAction("index");
        }
        public ActionResult DeleteService(int id)
        {
            var values = db.TblService.Find(id);
            db.TblService.Remove(values);
            db.SaveChanges();
            return RedirectToAction("index");
        }
        [HttpGet]
        public ActionResult UpdateService(int id) 
        { 
            var value = db.TblService.Find(id);
            return View(value);
        }
        [HttpPost]
        public ActionResult UpdateService(TblService p)
        {
            var value = db.TblService.Find(p.ServiceID);
            value.Title = p.Title;
            value.Description = p.Description;
            value.ImageUrl = p.ImageUrl;
            db.SaveChanges();
            return RedirectToAction("index");
        }
    }
}