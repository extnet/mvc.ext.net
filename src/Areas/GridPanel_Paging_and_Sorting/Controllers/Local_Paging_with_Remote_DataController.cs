using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ext.Net.MVC.Examples.Areas.GridPanel_Paging_and_Sorting.Controllers
{
    public class Local_Paging_with_Remote_DataController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Read(int startRemote, int limitRemote)
        {
            List<object> data = new List<object>(limitRemote);

            for (int i = startRemote; i < startRemote + limitRemote; i++)
            {
                data.Add(new { field = "Value" + (i + 1) });
            }

            return this.Store(data, 8000);
        }
    }
}
