using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ext.Net.MVC.Examples.Areas.Dynamic_Partial_Rendering.Controllers
{
    public class ASPX_EngineController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult View1(string containerId)
        {
            PartialViewResult pr = new PartialViewResult(containerId);
            pr.WrapByScriptTag = false;
            return pr;
        }

        public ActionResult View2(string containerId)
        {
            PartialViewResult pr = new PartialViewResult(containerId);
            pr.RenderMode = RenderMode.AddTo;
            pr.Items = true;
            return pr;
        }

        public ActionResult View3(string containerId)
        {
            PartialViewResult pr = new PartialViewResult(containerId);
            pr.RenderMode = RenderMode.AddTo;
            pr.SingleControl = true;
            pr.ViewData["title"] = DateTime.Now.ToLongTimeString();
            pr.ViewData["html"] = DateTime.Now.ToLongTimeString();
            return pr;
        }

        public ActionResult View4()
        {
            PartialViewResult pr = new PartialViewResult();
            pr.SingleControl = true;
            return pr;
        }
    }
}
