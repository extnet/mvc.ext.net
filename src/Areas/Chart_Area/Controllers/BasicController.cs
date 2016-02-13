using System.Web.Mvc;

namespace Ext.Net.MVC.Examples.Areas.Chart_Area.Controllers
{
    public class BasicController : Controller
    {
        public ActionResult Index()
        {
            return View(new object[]
            {
                new { month = "Jan", data1 = 20 },
                new { month = "Feb", data1 = 20 },
                new { month = "Mar", data1 = 19 },
                new { month = "Apr", data1 = 18 },
                new { month = "May", data1 = 18 },
                new { month = "Jun", data1 = 17 },
                new { month = "Jul", data1 = 16 },
                new { month = "Aug", data1 = 16 },
                new { month = "Sep", data1 = 16 },
                new { month = "Oct", data1 = 16 },
                new { month = "Nov", data1 = 15 },
                new { month = "Dec", data1 = 15 }
            });
        }
    }
}
