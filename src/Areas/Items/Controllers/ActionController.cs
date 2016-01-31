using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ext.Net.MVC.Examples.Areas.Items.Controllers
{
    public class ActionController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult LoadView()
        {
            return this.PartialView("PartialView", new Tuple<string, string, string>("SubPanel 1", "SubPanel 2", "SubPanel 3"));
        }

        public ActionResult LoadViewWithTitles(Tuple<string, string, string> titles)
        {
            return this.PartialView("PartialView", titles);
        }
    }
}
