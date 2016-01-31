using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ext.Net.MVC.Examples.Areas.GridPanel_ArrayGrid.ArrayWithPaging.Controllers
{
    public class ArrayWithPagingController : Controller
    {
        public ActionResult Index()
        {
            return View(Companies.GetAllCompanies());
        }

        public ActionResult GetData()
        {
            return this.Store(Companies.GetAllCompanies());
        }
    }
}
