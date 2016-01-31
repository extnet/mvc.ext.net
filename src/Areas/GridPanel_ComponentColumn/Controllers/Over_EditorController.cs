using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ext.Net.MVC.Examples.Areas.GridPanel_ComponentColumn.Over_Editor.Controllers
{
    public class Over_EditorController : Controller
    {
        public ActionResult Index()
        {
            return View(TestData.GetData());
        }
    }
}
