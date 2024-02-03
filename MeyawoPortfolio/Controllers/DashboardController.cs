using MeyawoPortfolio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Web;
using System.Web.Mvc;
using System.Xml.Linq;

namespace MeyawoPortfolio.Controllers
{
    public class DashboardController : Controller
    {
        // GET: Dashboard
        DbMyPortfolioEntities db = new DbMyPortfolioEntities();

        public ActionResult Index()
        {

            ViewBag.v2 = db.TblCategory.Count();
            ViewBag.v3 = db.TblContact.Count();
            ViewBag.v4 = db.TblProjects.Count();
            ViewBag.pythonProjectCount = db.TblProjects.Where(x => x.ProjectCategory == 2).Count();
            ViewBag.flutterProjectCount = db.TblProjects.Where(x => x.ProjectCategory == 1).Count();
            ViewBag.ReactProjectCount = db.TblProjects.Where(x => x.ProjectCategory == 6).Count();
            string api = "bbd07da7554c368f13fd790a928c246c";
            string connection = "https://api.openweathermap.org/data/2.5/weather?q=istanbul&mode=xml&lang=tr&units=metric&appid=" + api;
            //XDocument document = XDocument.Load(connection);
            XDocument document = XDocument.Load(connection);
            ViewBag.v5 = document.Descendants("temperature").ElementAt(0).Attribute("value").Value;
            return View();
        }

    }
}