using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ext.Net.MVC.Examples.Areas.GridPanel_Commands.Group_Command.Controllers
{
    public class Group_CommandController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetPlants()
        {
            return this.Store(Plant.TestData);
        }
    }
}
