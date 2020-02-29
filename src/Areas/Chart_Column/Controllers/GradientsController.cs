using System.Web.Mvc;

namespace Ext.Net.MVC.Examples.Areas.Chart_Column.Controllers
{
    public class GradientsController : Controller
    {
        public ActionResult Index()
        {
            return View(ChartModel.GenerateData(5, 0));
        }

        public StoreResult GetData()
        {
            return new StoreResult(ChartModel.GenerateData(5, 0));
        }
    }
}
