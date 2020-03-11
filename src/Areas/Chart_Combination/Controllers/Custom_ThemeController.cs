using System.Web.Mvc;

namespace Ext.Net.MVC.Examples.Areas.Chart_Combination.Controllers
{
    public class Custom_ThemeController : Controller
    {
        public ActionResult Index()
        {
            return View(new object[]
            {
                new { month = "Jan", data1 = 20, data2 = 37, data3 = 35, data4 = 4 },
                new { month = "Feb", data1 = 20, data2 = 37, data3 = 36, data4 = 5 },
                new { month = "Mar", data1 = 19, data2 = 36, data3 = 37, data4 = 4 },
                new { month = "Apr", data1 = 18, data2 = 36, data3 = 38, data4 = 5 },
                new { month = "May", data1 = 18, data2 = 35, data3 = 39, data4 = 4 },
                new { month = "Jun", data1 = 17, data2 = 34, data3 = 42, data4 = 4 },
                new { month = "Jul", data1 = 16, data2 = 34, data3 = 43, data4 = 4 },
                new { month = "Aug", data1 = 16, data2 = 33, data3 = 44, data4 = 4 },
                new { month = "Sep", data1 = 16, data2 = 32, data3 = 44, data4 = 4 },
                new { month = "Oct", data1 = 16, data2 = 32, data3 = 45, data4 = 4 },
                new { month = "Nov", data1 = 15, data2 = 31, data3 = 46, data4 = 4 },
                new { month = "Dec", data1 = 15, data2 = 31, data3 = 47, data4 = 4 }
            });
        }
    }
}
