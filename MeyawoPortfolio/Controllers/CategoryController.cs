using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MeyawoPortfolio.Models;

namespace MeyawoPortfolio.Controllers
{
    public class CategoryController : Controller
    {
        DbMyPortfolioEntities db = new DbMyPortfolioEntities();
        public ActionResult Index()
        {
            var values = db.TblCategory.ToList();
            return View(values);
        }
        [HttpGet]
        public ActionResult CreateCategory() 
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateCategory(TblCategory p)
        {
            db.TblCategory.Add(p);
            db.SaveChanges();
            return RedirectToAction("index");
        }
        public ActionResult DeleteCategory(int id)
        {
            var values = db.TblCategory.Find(id);
            db.TblCategory.Remove(values); 
            db.SaveChanges();
            return RedirectToAction("index");
        }
        [HttpGet]
        public ActionResult EditCategory(int id) 
        {
            var values = db.TblCategory.Find(id);
            return View(values);
        }
        [HttpPost]
        public ActionResult EditCategory(TblCategory p)
        {
            var values = db.TblCategory.Find(p.CategoryID);
            values.CategoryName = p.CategoryName;
            db.SaveChanges();
            return RedirectToAction("index");
        }
    }
}