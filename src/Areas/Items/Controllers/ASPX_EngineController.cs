using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ext.Net.MVC.Examples.Areas.Items.Controllers
{
    public class ASPX_EngineController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public PartialViewResult LoadView(string containerId, string titlePrefix)
        {
            return new PartialViewResult { 
                ViewName = "View2",
                RenderMode = RenderMode.AddTo,
                ContainerId = containerId,
                Items = true,
                Model = new Tuple<string>(titlePrefix)
            };
        }
    }
}
