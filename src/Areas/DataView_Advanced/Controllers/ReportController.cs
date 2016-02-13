using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ext.Net.MVC.Examples.Areas.DataView_Advanced.Controllers
{
    public class ReportController : Controller
    {
        public ActionResult Index()
        {
            List<object> data = new List<object>(26);

            for (char letter = 'A'; letter < 'Z'; letter++)
            {
                List<object> customers = new List<object>(10);

                for (int i = 1; i <= 10; i++)
                {
                    customers.Add(new
                    {
                        CustomerID = letter.ToString() + i,
                        CompanyName = "Company of " + (letter.ToString() + i),
                        ContactName = letter.ToString() + i,
                        Email = (letter.ToString() + i) + "@test.com",
                        Address = "Address of " + (letter.ToString() + i),
                        City = "City of " + (letter.ToString() + i),
                        PostalCode = "PostalCode of " + (letter.ToString() + i),
                        Country = "Country of " + (letter.ToString() + i)
                    });
                }

                data.Add(new { Letter = letter.ToString(), Customers = customers });
            }

            return View(data);
        }
    }
}
