using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ext.Net.MVC.Examples.Areas.Form_ComboBox.Ajax_Linked_Combos.Models;

namespace Ext.Net.MVC.Examples.Areas.Form_ComboBox.Ajax_Linked_Combos.Controllers
{
    public class Ajax_Linked_CombosController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetCities(string country)
        {
            return this.Store(City.GetCities(country));
        }
    }
}
