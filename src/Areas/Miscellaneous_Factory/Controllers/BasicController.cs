using System;
using System.Web.Mvc;

namespace Ext.Net.MVC.Examples.Areas.Miscellaneous_Factory.Controllers
{
    [DirectController(AreaName = "Miscellaneous_Factory", GenerateProxyForOtherAreas=false, GenerateProxyForOtherControllers=false, IDMode=DirectMethodProxyIDMode.None)]
    public class BasicController : Controller
    {
        /*
         See such code in Global.asax
         if (!Ext.Net.ResourceManager.HasFactory("mybutton"))
            {
                Ext.Net.ResourceManager.AddFactory(delegate {
                    var b = new Ext.Net.Button
                    {
                        Text = "Factory button",
                        Handler = "Ext.Msg.alert('Factory button', 'The button is clicked');",
                        Plugins =
                    {
                        new Badge
                        {
                            Text = "20"
                        }
                    },

                        Factory = new FactoryConfig
                        {
                            Alias = "mybutton",
                            Instance = "My.Button"
                        }
                    };

                    return b;
                }, "mybutton", "My.Button");
            }

            if (!Ext.Net.ResourceManager.HasFactory("mywindow1"))
            {
                Ext.Net.ResourceManager.AddFactoryView("~/Areas/Miscellaneous_Factory/Views/Basic/MyWindow1.ascx", "mywindow1", "My.Window1");
            }

            if (!Ext.Net.ResourceManager.HasFactory("mywindow2"))
            {
                Ext.Net.ResourceManager.AddFactoryView("~/Areas/Miscellaneous_Factory/Views/Basic/MyWindow2.cshtml", "mywindow2", "My.Window2");
            }
         */

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult RenderWindow1()
        {
            return new Ext.Net.MVC.PartialViewResult { ViewName = "Window", SingleControl = true };
        }

        public ActionResult RenderWindow2()
        {
            Window win = new Window
            {
                FactoryAlias = "mywindow2"
            };

            win.Render(RenderMode.Auto);

            return this.Direct();
        }

        [DirectMethod]
        public ActionResult SendEmail()
        {
            string sendTo = this.Request["sendTo"];
            string subject = this.Request["subject"];
            string body = this.Request["body"];

            X.Msg.Alert("Email has been sent", string.Concat(
                "Send To: ", sendTo, "<br/>",
                "Subject: ", subject, "<br/>",
                "Body: ", body)).Show();

            return this.Direct();
        }
    }
}
