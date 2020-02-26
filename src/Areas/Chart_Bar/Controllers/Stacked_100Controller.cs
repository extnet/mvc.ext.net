using System.Web.Mvc;

namespace Ext.Net.MVC.Examples.Areas.Chart_Bar.Controllers
{
    public class Stacked_100Controller : Controller
    {
        public ActionResult Index()
        {
            return View(new object[]
            {
                new { Month = "Jan", Data1 = 20, Data2 = 37, Data3 = 35, Data4 = 4 },
                new { Month = "Feb", Data1 = 20, Data2 = 37, Data3 = 36, Data4 = 5 },
                new { Month = "Mar", Data1 = 19, Data2 = 36, Data3 = 37, Data4 = 4 },
                new { Month = "Apr", Data1 = 18, Data2 = 36, Data3 = 38, Data4 = 5 },
                new { Month = "May", Data1 = 18, Data2 = 35, Data3 = 39, Data4 = 4 },
                new { Month = "Jun", Data1 = 17, Data2 = 34, Data3 = 42, Data4 = 4 },
                new { Month = "Jul", Data1 = 16, Data2 = 34, Data3 = 43, Data4 = 4 },
                new { Month = "Aug", Data1 = 16, Data2 = 33, Data3 = 44, Data4 = 4 },
                new { Month = "Sep", Data1 = 16, Data2 = 32, Data3 = 44, Data4 = 4 },
                new { Month = "Oct", Data1 = 16, Data2 = 32, Data3 = 45, Data4 = 4 },
                new { Month = "Nov", Data1 = 15, Data2 = 31, Data3 = 46, Data4 = 4 },
                new { Month = "Dec", Data1 = 15, Data2 = 31, Data3 = 47, Data4 = 4 }
            });
        }
    }
}
