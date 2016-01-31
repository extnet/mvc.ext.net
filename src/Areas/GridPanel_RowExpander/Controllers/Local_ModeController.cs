using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ext.Net.MVC.Examples.Areas.GridPanel_RowExpander.Models;

namespace Ext.Net.MVC.Examples.Areas.GridPanel_RowExpander.Controllers
{
    public class Local_ModeController : Controller
    {
        public ActionResult Index()
        {
            return View(Companies.GetCompanies());
        }
    }
}
