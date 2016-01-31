using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ext.Net.MVC.Examples.Areas.Dynamic_Partial_Rendering.Controllers
{
    public class Partial_ContentController : System.Web.Mvc.Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public PartialViewResult PartialView(string containerId)
        {
            return new PartialViewResult(containerId);
        }

        public PartialViewResult AutoLoadPartialView(string containerId)
        {
            return new PartialViewResult 
            { 
                ContainerId = containerId,                
                ViewName = "PartialView",
                WrapByScriptTag = false
            };
        }
    }
}
