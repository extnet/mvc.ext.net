using System.Web.Mvc;

namespace Ext.Net.MVC.Examples.Areas.MessageBus_Basic
{
    public class MessageBus_BasicAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "MessageBus_Basic";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "MessageBus_Basic_default",
                "MessageBus_Basic/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
