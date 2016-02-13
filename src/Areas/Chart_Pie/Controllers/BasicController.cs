using System.Web.Mvc;

namespace Ext.Net.MVC.Examples.Areas.Chart_Pie.Controllers
{
    public class BasicController : Controller
    {
        public ActionResult Index()
        {
            return View(ChartModel.GenerateData(6));
        }

        public StoreResult GetData()
        {
            return new StoreResult(ChartModel.GenerateData(6));
        }
    }
}
