using System.Web.Mvc;

namespace Ext.Net.MVC.Examples.Areas.Chart_Bar.Controllers
{
    public class Basic_3DController : Controller
    {
        public ActionResult Index()
        {
            return View(ChartModel.GenerateData());
        }

        public StoreResult GetData()
        {
            return new StoreResult(ChartModel.GenerateData());
        }
    }
}
