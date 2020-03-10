using System.Web.Mvc;

namespace Ext.Net.MVC.Examples.Areas.Chart_Combination.Controllers
{
    public class Binding_TabsController : Controller
    {
        public ActionResult Index()
        {
            ViewData.Model =  new
            {
                stores = new
                {
                    priceData = new
                    {
                        fields = new string[] { "month", "price" },
                        data = new object[]
                        {
                            new { month = "Jan", price = 28 },
                            new { month = "Feb", price = 25 },
                            new { month = "Mar", price = 21 },
                            new { month = "Apr", price = 18 },
                            new { month = "May", price = 18 },
                            new { month = "Jun", price = 17 },
                            new { month = "Jul", price = 16 },
                            new { month = "Aug", price = 16 },
                            new { month = "Sep", price = 16 },
                            new { month = "Oct", price = 16 },
                            new { month = "Nov", price = 15 },
                            new { month = "Dec", price = 15 }
                        }
                    }
                }
            };

            return View();
        }
    }
}
