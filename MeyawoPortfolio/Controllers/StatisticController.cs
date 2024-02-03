using MeyawoPortfolio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MeyawoPortfolio.Controllers
{
    public class StatisticController : Controller
    {
        DbMyPortfolioEntities db = new DbMyPortfolioEntities();
        // GET: Statistic
        public ActionResult Index()
        {
            ViewBag.categoryCount = db.TblCategory.Count();
            ViewBag.projectCount= db.TblProjects.Count();
            ViewBag.messageCount = db.TblContact.Count();
            ViewBag.flutterProjectCount =db.TblProjects.Where(x=>x.ProjectCategory==1).Count();
            ViewBag.isNotReadMessageCount= db.TblCategory.Count();
            ViewBag.lastProjectName = db.lastprojectname().FirstOrDefault();
            ViewBag.testimonialCount = db.TblTestimonial.Count();
            ViewBag.socialMediaCount = db.TblSocialMedia.Count();
            ViewBag.pythonProjectCount = db.TblProjects.Where(x => x.ProjectCategory == 2).Count();
            ViewBag.ReactProjectCount = db.TblProjects.Where(x => x.ProjectCategory == 6).Count();
            return View();
        }
    }
}