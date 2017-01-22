using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ext.Net.MVC.Examples.Areas.Dynamic_Partial_Rendering.Controllers
{
    public class Render_as_ConfigController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult RenderWindow()
        {
            return new Ext.Net.MVC.PartialViewResult
            {
                ViewName = "Component",
                RenderMode = RenderMode.Config
            };
        }
    }
}
