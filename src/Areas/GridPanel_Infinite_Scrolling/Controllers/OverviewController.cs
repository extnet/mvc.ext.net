using System.Web.Mvc;
using Ext.Net.MVC.Examples.Areas.GridPanel_Infinite_Scrolling.Models;

namespace Ext.Net.MVC.Examples.Areas.GridPanel_Infinite_Scrolling.Controllers
{
    public class OverviewController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetStockQuotations(int start, int limit)
        {
            return this.Store(StockQuotation.GetStockQuotations(start, limit), 5000);
        }
    }
}
