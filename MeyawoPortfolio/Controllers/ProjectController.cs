using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MeyawoPortfolio.Models;

namespace MeyawoPortfolio.Controllers
{
    public class ProjectController : Controller
    {
        DbMyPortfolioEntities db = new DbMyPortfolioEntities();
        public ActionResult Index()
        {
            var values = db.TblProjects.ToList();
            return View(values);
        }
        [HttpGet]
        public ActionResult CreateProject()
        {
            List<SelectListItem> values = (from x in db.TblCategory.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.CategoryName,
                                               Value = x.CategoryID.ToString(),
                                           }).ToList();
            ViewBag.v = values;
            return View();
        }
        [HttpPost]
        public ActionResult CreateProject(TblProjects p)
        {
            db.TblProjects.Add(p);
            db.SaveChanges();
            return RedirectToAction("index");
        }
        [HttpGet]
        public ActionResult UpdateProject(int id)
        {
            List<SelectListItem> values1 = (from x in db.TblCategory.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.CategoryName,
                                               Value = x.CategoryID.ToString(),
                                           }).ToList();
            ViewBag.v = values1;
            var values = db.TblProjects.Find(id);
            return View(values);
        }
        [HttpPost]
        public ActionResult UpdateProject(TblProjects p)
        {
            var values = db.TblProjects.Find(p.ProjectID);
            values.Description = p.Description;
            values.ImageUrl = p.ImageUrl;
            values.ProjectCategory = p.ProjectCategory;
            values.ProjectUrl = p.ProjectUrl;
            values.Title = p.Title;
            db.SaveChanges();
            return RedirectToAction("index");

        }
        public ActionResult DeleteProject(int id)
        {
            var values = db.TblProjects.Find(id);
            db.TblProjects.Remove(values);
            db.SaveChanges();
            return RedirectToAction("index");
        }


    }
}