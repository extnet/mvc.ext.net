using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ext.Net.MVC.Examples.Areas.GridPanel_Plugins.Models;

namespace Ext.Net.MVC.Examples.Areas.GridPanel_Plugins.Controllers
{
    public class GridFilters_LocalController : Controller
    {
        public ActionResult Index()
        {
            return View(GridFiltersModel.Data);
        }

        public ActionResult SetFilter()
        {
            Column column = X.GetCmp<Column>("CompanyColumn");
            column.Call("filter.setValue", "3m Co");

            return this.Direct();
        }
    }
}
