using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ext.Net.MVC.Examples.Areas.GridPanel_Commands.Over_Commands.Controllers
{
    public class Over_CommandsController : Controller
    {
        public ActionResult Index()
        {
            return View(Companies.GetAllCompanies());
        }
    }
}
