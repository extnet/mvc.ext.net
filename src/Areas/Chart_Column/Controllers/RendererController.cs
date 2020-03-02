using Ext.Net.MVC.Examples.Areas.Chart_Column.Models;
using System.Web.Mvc;

namespace Ext.Net.MVC.Examples.Areas.Chart_Column.Controllers
{
    public class RendererController : Controller
    {
        public ActionResult Index()
        {
            return View(RendererModel.GenerateData());
        }

        public StoreResult GetData()
        {
            return new StoreResult(RendererModel.GenerateData());
        }
    }
}
