using System.Web.Mvc;

namespace Ext.Net.MVC.Examples.Areas.Chart_Scatter.Controllers
{
    public class BasicController : Controller
    {
        public ActionResult Index()
        {
            return View(new object[]
            {
                new { x = 5,   y = 20 },
                new { x = 480, y = 90 },
                new { x = 250, y = 50 },
                new { x = 100, y = 33 },
                new { x = 330, y = 95 },
                new { x = 410, y = 12 },
                new { x = 475, y = 44 },
                new { x = 25,  y = 67 },
                new { x = 85,  y = 21 },
                new { x = 220, y = 88 },
                new { x = 320, y = 79 },
                new { x = 270, y = 32 }
            });
        }
    }
}
