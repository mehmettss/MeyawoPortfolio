using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Services.Description;
using MeyawoPortfolio.Models;

namespace MeyawoPortfolio.Controllers
{
    public class ContactController : Controller
    {
        DbMyPortfolioEntities db = new DbMyPortfolioEntities();
        public ActionResult Index()
        {
           
            var values = db.TblContact.ToList();
            return View(values);
        }

        public ActionResult DeleteContact(int id)
        {
            var values = db.TblContact.Find(id);
            db.TblContact.Remove(values);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpPost]
        public ActionResult SendMessage(TblContact p)
        {
            p.SendDate = Convert.ToDateTime(DateTime.Now.ToShortDateString());
            p.IsRead = true;
            p.MessageCategory = 2;
            db.TblContact.Add(p);
            db.SaveChanges();
            return Redirect("https://localhost:44371/Default/Index#contact");
        }

        //[HttpGet]
        //public IActionResult Index()
        //{
        //    return View();
        //}
        //[HttpPost]
        //public IActionResult Index(Message m)
        //{

        //    m.Date = Convert.ToDateTime(DateTime.Now.ToShortDateString());
        //    messageManager.TAdd(m);

        //    return View();
        //}
    }
}