using System.Web.Mvc;

namespace Ext.Net.MVC.Examples.Areas.Kitchen_Sink_GridPanels.Controllers
{
    public class GroupedController : Controller
    {
        public ActionResult Index()
        {
            return View(Examples.Models.KitchenSink.RestaurantsModel.GetAllRestaurants());
        }
    }
}
