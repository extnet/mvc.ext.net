using System.Web.Mvc;

namespace Ext.Net.MVC.Examples.Areas.Chart_Gauge.Controllers
{
    public class BasicController : Controller
    {
        public ActionResult Index()
        {
            this.ViewData["Chart1"] = ChartModel.GenerateData();
            this.ViewData["Chart2"] = ChartModel.GenerateData();
            this.ViewData["Chart3"] = ChartModel.GenerateData();
            return View();
        }

        public StoreResult GetData()
        {
            return new StoreResult(new
                {
                    Chart1 = ChartModel.GenerateData(),
                    Chart2 = ChartModel.GenerateData(),
                    Chart3 = ChartModel.GenerateData()
                });
        }
    }
}
