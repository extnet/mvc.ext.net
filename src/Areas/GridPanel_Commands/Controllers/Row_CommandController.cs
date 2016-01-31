using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ext.Net.MVC.Examples.Areas.GridPanel_Commands.Row_Command.Controllers
{
    public class Row_CommandController : Controller
    {
        public ActionResult Index()
        {
            return View(Companies.GetAllCompanies());
        }
    }
}
