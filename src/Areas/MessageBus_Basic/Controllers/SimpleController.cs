using System.Web.Mvc;
using System.Web.UI;

namespace Ext.Net.MVC.Examples.Areas.MessageBus_Basic.Controllers
{
    public class SimpleController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult PublishEvent()
        {
            MessageBus.Default.Publish("Msg.Server", "It is an event from server side");

            return this.Direct();
        }

        public ActionResult ServerBusEvent(string message)
        {
            this.GetCmp<Panel>("Panel2").Body.CreateChild(new DomObject
            {
                Html = message,
                Tag = HtmlTextWriterTag.P,
                CustomConfig =
                {
                    new ConfigItem("style", "color:green;", ParameterMode.Value)
                }
            });

            return this.Direct();
        }
    }
}
