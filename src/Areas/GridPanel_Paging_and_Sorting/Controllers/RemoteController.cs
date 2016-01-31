using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ext.Net.MVC.Examples.Areas.GridPanel_Paging_and_Sorting.Models;

namespace Ext.Net.MVC.Examples.Areas.GridPanel_Paging_and_Sorting.Controllers
{
    public class RemoteController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Read(StoreRequestParameters parameters)
        {
            return this.Store(Plant.PlantsPaging(parameters));
        }
    }
}
