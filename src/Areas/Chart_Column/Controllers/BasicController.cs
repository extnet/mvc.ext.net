using System.Web.Mvc;

namespace Ext.Net.MVC.Examples.Areas.Chart_Column.Controllers
{
    public class BasicController : Controller
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
