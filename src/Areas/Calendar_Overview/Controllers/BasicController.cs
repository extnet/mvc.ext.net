using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ext.Net.MVC.Examples.Areas.Calendar_Overview.Models;

namespace Ext.Net.MVC.Examples.Areas.Calendar_Overview.Controllers
{
    [DirectController(AreaName = "Calendar_Overview", IDMode = DirectMethodProxyIDMode.None)]
    public class BasicController : Controller
    {
        public ActionResult Index()
        {
            return View(BasicModel.Events);
        }

        public ActionResult SubmitData(string data)
        {
            List<EventModel> events = JSON.Deserialize<List<EventModel>>(data);

            return new PartialViewResult
            {
                ViewName = "EventsViewer",
                ViewBag =
                {
                    Events = events
                }
            };
        }

        [DirectMethod(Namespace = "CompanyX")]
        public ActionResult ShowMsg(string msg)
        {
            X.Msg.Notify("Message", msg).Show();

            return this.Direct();
        }
    }
}
