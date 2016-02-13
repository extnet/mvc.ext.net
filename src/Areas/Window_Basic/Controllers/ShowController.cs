using System.Web.Mvc;

namespace Ext.Net.MVC.Examples.Areas.Window_Basic.Controllers
{
    [DirectController(AreaName = "Window_Basic")]
    public class ShowController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public DirectResult Button2_Click()
        {
            X.GetCmp<Window>("Window2").Show();
            return this.Direct();
        }

        [DirectMethod]
        public ActionResult Button3_Click()
        {
            X.GetCmp<Window>("Window3").Show();
            return this.Direct();
        }

    }
}