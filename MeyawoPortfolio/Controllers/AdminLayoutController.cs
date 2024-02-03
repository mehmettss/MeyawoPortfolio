using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MeyawoPortfolio.Controllers
{
    public class AdminLayoutController : Controller
    {
        // GET: AdminLayout
        public ActionResult _Layout()
        {
            return View();
        }
        public PartialViewResult HeaderPartial()
        {
            return PartialView();
        }
		public PartialViewResult _SidebarPartial()
		{
            ViewBag.van = "merhaba";
            return PartialView();
		}
		public PartialViewResult _ScriptPartial()
		{
        
			return PartialView();
		}

    }
}