using System;
using System.Web.Mvc;

namespace Ext.Net.MVC.Examples.Areas.Buttons_Basic.Controllers
{
    public class LoadingStateController : Controller
    {
        public ActionResult Index() => View();

        public ActionResult Button1_Click()
        {
            System.Threading.Thread.Sleep(2000);

            X.Msg.Alert("Server Time", DateTime.Now.ToLongTimeString()).Show();
            return this.Direct();
        }
    }
}
