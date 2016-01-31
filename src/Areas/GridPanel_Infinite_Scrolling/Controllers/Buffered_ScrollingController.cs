using System.Web.Mvc;
using Ext.Net.MVC.Examples.Areas.GridPanel_Infinite_Scrolling.Models;

namespace Ext.Net.MVC.Examples.Areas.GridPanel_Infinite_Scrolling.Controllers
{
    public class Buffered_ScrollingController : Controller
    {
        public ActionResult Index()
        {
            return View(TestData.GetData(5000));
        }
    }
}
