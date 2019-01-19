using System;
using System.Web.Mvc;

namespace Ext.Net.MVC.Examples.Areas.Getting_Started.Component_Overview.Controllers
{
    public class Component_OverviewController : Controller
    {
        public ActionResult Index()
        {
            return View(Component_OverviewModel.TestData);
        }

        public ActionResult Button1_Click()
        {
            string msg = "This is a sample Alert MessageBox<br /><br />Server Timestamp : " +
                DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss");
            X.Msg.Alert("Message", msg).Show();

            return this.Direct();
        }

        public ActionResult GetGridData()
        {
            return this.Store(Component_OverviewModel.TestData);
        }
    }
}
