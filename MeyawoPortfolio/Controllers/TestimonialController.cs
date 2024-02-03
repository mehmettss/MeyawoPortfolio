using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MeyawoPortfolio.Models;

namespace MeyawoPortfolio.Controllers
{
    public class TestimonialController : Controller
    {
       DbMyPortfolioEntities db = new DbMyPortfolioEntities();
        public ActionResult Index()
        {
            var values = db.TblTestimonial.ToList();
            return View(values);
        }
        [HttpGet]
        public ActionResult CreateTestimonial()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateTestimonial(TblTestimonial p)
        {
            db.TblTestimonial.Add(p);
            db.SaveChanges();
            return RedirectToAction("index");
        }
        public ActionResult DeleteTestimonial(int id)
        {
            var values = db.TblTestimonial.Find(id);
            db.TblTestimonial.Remove(values); 
            db.SaveChanges();
            return RedirectToAction("index");
        }
        [HttpGet]
        public ActionResult EditTestimonial(int id)
        {
            var values = db.TblTestimonial.Find(id);
            return View(values);
        }
        [HttpPost]
        public ActionResult EditTestimonial(TblTestimonial p)
        {
            var values = db.TblTestimonial.Find(p.TestimonialID);
            values.NameSurname = p.NameSurname;
            values.Description = p.Description;
            values.Status = p.Status;
            db.SaveChanges();
            return RedirectToAction("index");
        }
    }
}