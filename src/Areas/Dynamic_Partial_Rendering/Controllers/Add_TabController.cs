using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ext.Net.MVC.Examples.Areas.Dynamic_Partial_Rendering.Controllers
{
    public class Add_TabController : Controller
    {       
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AddTab(string containerId)
        {
            var result = new PartialViewResult
            {
                ViewName = "Tab",
                ContainerId = containerId,                                
                RenderMode = RenderMode.AddTo
            };
            
            this.GetCmp<TabPanel>(containerId).SetLastTabAsActive();
            
            return result;
        }
    }
}
