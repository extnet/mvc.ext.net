using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ext.Net.MVC.Examples.Areas.TreePanel_Basic.Models;

namespace Ext.Net.MVC.Examples.Areas.TreePanel_Basic.Controllers
{
    [DirectController(AreaName="TreePanel_Basic", GenerateProxyForOtherControllers=false)]
    public class Refresh_Static_TreeController : Controller
    {
        public ActionResult Index()
        {
            return View(Refresh_Static_TreeModel.BuildTree());
        }

        [DirectMethod(IDMode=DirectMethodProxyIDMode.None)]
        public ActionResult RefreshMenu()
        {
            return this.Direct(Refresh_Static_TreeModel.BuildTree());
        }
    }
}
