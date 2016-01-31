using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ext.Net.MVC.Examples.Areas.GridPanel_ArrayGrid.Remote_Load.Controllers
{
    public class Remote_LoadController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetData()
        {
            return this.Store(Companies.GetAllCompanies());
        }
    }
}
