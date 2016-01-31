using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ext.Net.MVC.Examples.Areas.Models.Controllers
{
    public class GridPanelForController : Controller
    {
        public ActionResult Index()
        {
            return View(GridEmployee.GetAll());
        }
    }
}
