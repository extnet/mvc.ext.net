using System.Web.Mvc;

namespace Ext.Net.MVC.Examples.Areas.Window_Basic.Controllers
{
    public class Hello_WorldController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public DirectResult Button2_Click()
        {
            X.GetCmp<Window>("Window1").Show();
            return this.Direct();
        }
    }
}