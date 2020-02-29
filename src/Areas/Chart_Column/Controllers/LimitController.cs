using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Ext.Net.MVC.Examples.Areas.Chart_Column.Controllers
{
    public class LimitController : Controller
    {
        public class Temperature
        {
            public string Month
            {
                get;
                set;
            }

            public double High
            {
                get;
                set;
            }

            public double Low
            {
                get;
                set;
            }
        }

        public ActionResult Index()
        {
            return View(makeMockData());
        }

        static int counter = 0;
        public StoreResult GetData()
        {
            return new StoreResult(makeMockData(counter++));
        }

        private List<Temperature> makeMockData(int counter = -1)
        {
            var data = new List<Temperature>
            {
                new Temperature { Month = "Jan", High = 14.7, Low = 5.6  },
                new Temperature { Month = "Feb", High = 16.5, Low = 6.6  },
                new Temperature { Month = "Mar", High = 18.6, Low = 7.3  },
                new Temperature { Month = "Apr", High = 20.8, Low = 8.1  },
                new Temperature { Month = "May", High = 23.3, Low = 9.9  },
                new Temperature { Month = "Jun", High = 26.2, Low = 11.9 },
                new Temperature { Month = "Jul", High = 27.7, Low = 13.3 },
                new Temperature { Month = "Aug", High = 27.6, Low = 13.2 },
                new Temperature { Month = "Sep", High = 26.4, Low = 12.1 },
                new Temperature { Month = "Oct", High = 23.6, Low = 9.9  },
                new Temperature { Month = "Nov", High = 17  , Low = 6.8  },
                new Temperature { Month = "Dec", High = 14.7, Low = 5.8  }
            };

            if (counter >= 0)
            {
                int i;
                int temp = 15;
                int min = counter % 2 == 1 ? 0 : temp;
                var rand = new Random();

                for (i = 0; i < data.Count; i++)
                {
                    data[i].High = min + temp + rand.NextDouble() * temp;
                    data[i].Low = min + rand.NextDouble() * temp;
                }
                LimitController.counter++;
            }

            return data;
        }
    }
}
