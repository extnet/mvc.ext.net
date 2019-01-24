using System.Web.Mvc;

namespace Ext.Net.MVC.Examples.Areas.Kitchen_Sink_GridPanels.Controllers
{
    public class Grouped_HeaderController : Controller
    {
        public ActionResult Index()
        {
            return View(Models.Grouped_HeaderModel.GetData());
        }
    }
}
