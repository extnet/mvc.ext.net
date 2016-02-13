using System;
using System.Web.Mvc;

namespace Ext.Net.MVC.Examples.Areas.Panel_Basic.Controllers
{
    public class LoaderController : Controller
    {
        public ActionResult Index(string containerId)
        {
            return View();
        }

        public ActionResult SetHtmlProperty(string containerId)
        {
            this.GetCmp<Panel>(containerId).Html = DateTime.Now.ToLongTimeString();
            return this.Direct();
        }

        public ActionResult RenderChild(string containerId)
        {
            return PartialView("Child");
        }

        public ActionResult SetLoaderProperty(string containerId)
        {
            Panel panel = this.GetCmp<Panel>(containerId);
            panel.Loader = new ComponentLoader
            {
                 Url = Url.Action("RenderChild"),
                 DisableCaching = true
            };
            panel.Loader.SuspendScripting();
            panel.LoadContent();
            return this.Direct();
        }

        public ActionResult LoadHtmlContent(string containerId)
        {
            this.GetCmp<Panel>(containerId).LoadContent("RenderChild", true);
            return this.Direct();
        }

        public ActionResult SetIFrameLoadProperty(string containerId)
        {
            Panel panel = this.GetCmp<Panel>(containerId);
            panel.Loader = new ComponentLoader
            {
                Url = Url.Action("RenderChild"),
                DisableCaching = true,
                Mode = LoadMode.Frame
            };
            panel.Loader.SuspendScripting();
            panel.LoadContent();
            return this.Direct();
        }

        public ActionResult LoadIFrameContent(string containerId)
        {
            this.GetCmp<Panel>(containerId).LoadContent(new ComponentLoader
            {
                Url = Url.Action("RenderChild"),
                DisableCaching = true,
                Mode = LoadMode.Frame
            });
            return this.Direct();
        }
    }
}