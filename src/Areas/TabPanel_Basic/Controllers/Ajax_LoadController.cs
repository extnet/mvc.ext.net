using System.Web.Mvc;

namespace Ext.Net.MVC.Examples.Areas.TabPanel_Basic.Controllers
{
    public class Ajax_LoadController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Ajax(string containerId)
        {
            System.Threading.Thread.Sleep(2000);

            return View("Ajax");
        }
    }
}
