using System.Web.Mvc;

namespace Ext.Net.MVC.Examples.Areas.Editor_Basic.Controllers
{
    public class OverviewController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult CompleteEdit(string value)
        {
            this.GetCmp<Label>("AjaxLabel").Html = value;
            return this.Direct();
        }
    }
}
