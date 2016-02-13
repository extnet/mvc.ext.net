using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ext.Net.MVC.Examples.Areas.GridPanel_Miscellaneous.Models;

namespace Ext.Net.MVC.Examples.Areas.GridPanel_Miscellaneous.Controllers
{
    public class Marking_RecordsController : Controller
    {
        public ActionResult Index()
        {
            return View(new Marking_RecordsModel());
        }

    }
}
