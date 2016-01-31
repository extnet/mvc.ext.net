using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ext.Net.MVC.Examples.Areas.Form_ComboBox.Custom_Search.Models;

namespace Ext.Net.MVC.Examples.Areas.Form_ComboBox.Custom_Search.Controllers
{
    public class Custom_SearchController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetPlants(int start, int limit, int page, string query)
        {
            Paging<Plant> plants = Plant.PlantsPaging(start, limit, "", "", query);

            return this.Store(plants.Data, plants.TotalRecords);
        }
    }
}
