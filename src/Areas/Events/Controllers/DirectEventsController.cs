using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ext.Net.MVC.Examples.Areas.Events.Controllers
{
    public class DirectEventsController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult UpdateTimeStamp()
        {
            X.Msg.Notify("The Server Time is: ", DateTime.Now.ToLongTimeString()).Show();
            return this.Direct();
        }
    }
}
