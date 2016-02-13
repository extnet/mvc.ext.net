using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Ext.Net.MVC.Examples.Areas.Chart_Dashboard.Controllers
{
    public class BasicController : Controller
    {

        public List<object> Data
        {
            get
            {
                string[] companies = new string[]
                {
                    "3m Co",
                    "Alcoa Inc",
                    "Altria Group Inc",
                    "American Express Company",
                    "American International Group, Inc.",
                    "AT&T Inc.",
                    "Boeing Co.",
                    "Caterpillar Inc.",
                    "Citigroup, Inc."
                };

                Random rand = new Random();
                List<object> data = new List<object>(companies.Length);

                for (int i = 0; i < companies.Length; i++)
                {
                    data.Add(new
                    {
                        Company = companies[i],
                        Price = rand.Next(10000) / 100d,
                        Revenue = rand.Next(10000) / 100d,
                        Growth = rand.Next(10000) / 100d,
                        Product = rand.Next(10000) / 100d,
                        Market = rand.Next(10000) / 100d,
                    });
                }

                return data;
            }
        }

        public List<object> RadarData
        {
            get
            {
                return new List<object>
            {
                new { Name = "Price", Data = 100 },
                new { Name = "Revenue %", Data = 100 },
                new { Name = "Growth %", Data = 100 },
                new { Name = "Product %", Data = 100 },
                new { Name = "Market %", Data = 100 }
            };
            }
        }

        public ActionResult Index()
        {
            this.ViewData["RadarData"] = RadarData;
            this.ViewData["Data"] = Data;
            return View();
        }
    }
}
