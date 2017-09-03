using System.Web.Mvc;

namespace Ext.Net.MVC.Examples.Areas.Chart_Misc.Controllers
{
    public class CaptionsController : Controller
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
