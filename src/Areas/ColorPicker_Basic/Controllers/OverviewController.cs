using System.Web.Mvc;

namespace Ext.Net.MVC.Examples.Areas.ColorPicker_Basic.Controllers
{
    [DirectController(AreaName="ColorPicker_Basic")]
    public class OverviewController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [DirectMethod]
        public ActionResult ColorSelect(string value)
        {
            string tpl = "Choosen color: #<span style='color:#{0};font-weight:bold;'>{0}</span>";
            X.GetCmp<Label>("Label1").Html = string.Format(tpl, value);
            return this.Direct();
        }

        public ActionResult Color_Changed(string value)
        {
            string tpl = "Choosen color: #<span style='color:#{0};font-weight:bold;'>{0}</span>";
            X.GetCmp<Label>("Label2").Html = string.Format(tpl, value);
            return this.Direct();
        }
    }
}
