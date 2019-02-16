using System.Web.Mvc;

namespace Ext.Net.MVC.Examples.Areas.GridPanel_Miscellaneous.FilterQuery.Controllers
{
    public class FilterQueryController : Controller
    {
        public ActionResult Index()
        {
            return View(Companies.GetAllCompanies());
        }

        public ActionResult ApplyFilter()
        {
            var query = "company like \"The\" or price < 30";
            var store = X.GetCmp<Store>("Store1");

            store.AddFilter(new Ext.Net.FilterQuery(query));
            X.Toast("Server-filtered by query: " + query);

            return this.Direct();
        }
    }
}
