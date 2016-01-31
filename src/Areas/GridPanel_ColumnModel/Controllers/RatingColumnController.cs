using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ext.Net.MVC.Examples.Areas.GridPanel_ColumnModel.RatingColumn.Controllers
{
    public class RatingColumnController : Controller
    {
        public ActionResult Index()
        {
            return View(Companies.GetCompanies());
        }
    }
}
