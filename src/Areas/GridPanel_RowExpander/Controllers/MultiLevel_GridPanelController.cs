using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ext.Net.MVC.Examples.Areas.GridPanel_RowExpander.Models;

namespace Ext.Net.MVC.Examples.Areas.GridPanel_RowExpander.Controllers
{
    public class MultiLevel_GridPanelController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult BuildLevel(int level)
        {
            return this.ComponentConfig(MultiLevel_GridPanelModel.BuildLevel(level, Url.Action("BuildLevel")));
        }
    }
}
