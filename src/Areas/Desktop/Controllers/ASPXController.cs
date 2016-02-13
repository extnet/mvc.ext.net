using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ext.Net.MVC.Examples.Areas.Desktop.Models;

namespace Ext.Net.MVC.Examples.Areas.Desktop.Controllers
{
    [DirectController(AreaName = "Desktop", GenerateProxyForOtherControllers = false, IDMode = DirectMethodProxyIDMode.None)]
    public class ASPXController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Desktop()
        {
            return View();
        }

        public ActionResult Login(string txtUsername, string txtPassword)
        {
            // Do some Authentication...

            // Then user send to application
            return this.RedirectToAction("Desktop");
        }

        public ActionResult Logout()
        {
            return this.RedirectToAction("Index");
        }

        [DirectMethod(ShowMask = true)]
        public ActionResult AddNewModule()
        {
            this.GetDesktop().RemoveModule("add-module");
            return this.PartialExtView("TabWindow", singleControl:true);
        }

        [DirectMethod(ShowMask = true)]
        public ActionResult CreateWindow()
        {
            this.GetDesktop().CreateWindow(new Window
            {
                Title = "New window",
                Width = 300,
                Height = 300,
                CloseAction = CloseAction.Destroy,
                Html = "The window is created"
            });

            return this.Direct();
        }

        [DirectMethod(ShowMask = true)]
        public ActionResult AddAnotherModule()
        {
            var desktop = this.GetDesktop();
            desktop.RemoveModule("add1-module");
            DesktopModule m = new DesktopModule
            {
                ModuleID = "dyn-mod",
                Shortcut = new DesktopShortcut
                {
                    Name = "Dynamic Module"
                },

                Launcher = new Ext.Net.MenuItem
                {
                    Text = "Dynamic module"
                },

                Window =
                {
                    new Window
                    {
                        Title = "Dynamic Window",
                        Width = 300,
                        Height = 300,
                        DefaultRenderTo = Ext.Net.DefaultRenderTo.Form,
                        Icon = Icon.ApplicationAdd
                    }
                },

                AutoRun = true
            };

            desktop.AddModule(m);

            return this.Direct();
        }

        public ActionResult UpdateTask()
        {
            SystemStatusModel.UpdateCharts(new SystemStatusData(false,
                this.GetCmp<Store>("CPULoadStore"),
                this.GetCmp<Store>("MemoryStore"),
                this.GetCmp<Store>("ProcessStore")
            ));

            this.GetCmp<DrawContainer>("MemoryChart").RenderFrame();

            return this.Direct();
        }
    }
}
