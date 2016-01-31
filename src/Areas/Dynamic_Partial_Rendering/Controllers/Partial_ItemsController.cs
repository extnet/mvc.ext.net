using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ext.Net.MVC.Examples.Areas.Dynamic_Partial_Rendering.Controllers
{
    public class Partial_ItemsController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public PartialViewResult WestItems(string containerId)
        {
            return new PartialViewResult
            {
                RenderMode = RenderMode.AddTo,
                ContainerId = containerId,
                WrapByScriptTag = false // we load the view via Loader with Script mode therefore script tags is not required
            };
        }

        public PartialViewResult LoadView(string containerId, string text)
        {
            // view is loaded via ajax request (DirectEvent) therefore script tags will be deactivated automatically
            return new PartialViewResult { 
                ViewName = "CenterView",
                ContainerId = containerId,
                Model = text,
                ClearContainer = true,
                RenderMode = RenderMode.AddTo
            };
        }
    }
}
