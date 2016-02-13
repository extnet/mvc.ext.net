using System.Web.Mvc;

namespace Ext.Net.MVC.Examples.Areas.Panel_Basic.Controllers
{
    public class Deferred_LoadingController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult RenderChild(string containerId)
        {
            return PartialView("Child");
        }
    }
}
