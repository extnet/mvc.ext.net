using System;
using System.Web.Mvc;
using Ext.Net.Utilities;

namespace Ext.Net.MVC.Examples.Areas.XRender_Basic.Controllers
{
    public class Add_ItemsController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Button1_Click(int index)
        {
            index++;
            this.GetCmp<Hidden>("Hidden1").Text = index.ToString();

            /* TabPanel */

            Panel tab = new Panel
            {
                ID = "Tab" + index,
                Title = "Tab " + index,
                Html = "Tab {0} : ({1})".FormatWith(index, DateTime.Now.ToLongTimeString()),
                BodyPadding = 5,
                Border = false
            };

            tab.AddTo(this.GetCmp<TabPanel>("TabPanel1"));

            this.GetCmp<TabPanel>("TabPanel1").SetActiveTab("Tab" + index);


            /* Accordion */

            Panel panel = new Panel
            {
                ID = "Panel" + index,
                Title = "Panel " + index,
                Html = "Panel {0} : ({1})".FormatWith(index, DateTime.Now.ToLongTimeString()),
                BodyPadding = 5,
                Border = false
            };

            // You can also call .Render and pass RenderMode.AddTo as the second param
            // p.Render(this.Panel1, RenderMode.AddTo);

            // or, call .AddTo Method which performs the same action as above line.
            panel.AddTo(this.GetCmp<Panel>("Panel1"));

            panel.Expand();

            return this.Direct();
        }
    }
}
