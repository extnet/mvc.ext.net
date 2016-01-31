using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ext.Net.MVC.Examples.Areas.Portal.Controllers
{
    public class SimpleController : Controller
    {       
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult PortletHide(string id)
        {
            X.Msg.Alert("Status", id + " Hidden").Show();

            return this.Direct();
        }
    }
}
