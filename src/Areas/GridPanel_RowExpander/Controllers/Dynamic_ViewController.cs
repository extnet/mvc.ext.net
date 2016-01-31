using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ext.Net.MVC.Examples.Areas.GridPanel_RowExpander.Controllers
{
    public class Dynamic_ViewController : Controller
    {
        public ActionResult Index()
        {
            List<object> data = new List<object>();

            for (int i = 1; i <= 10; i++)
            {
                data.Add(new { ID = "S" + i, Name = "Supplier " + i });
            }

            return View(data);
        }

        public ActionResult GetGrid(string id)
        {
            List<object> data = new List<object>();
            for (int i = 1; i <= 10; i++)
            {
                data.Add(new { ID = "P" + i, Name = "Product " + i });
            }

            return this.ComponentConfig("InnerGrid", data);
        }
    }
}
