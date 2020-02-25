using System.Web.Mvc;

namespace Ext.Net.MVC.Examples.Areas.Chart_Bar.Controllers
{
    public class MixedController : Controller
    {
        public ActionResult Index()
        {
            return View(ChartModel.GenerateData(8));
        }

        public StoreResult GetData()
        {
            return new StoreResult(ChartModel.GenerateData(8));
        }
    }
}
