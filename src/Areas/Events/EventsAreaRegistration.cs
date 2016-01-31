using System.Web.Mvc;

namespace Ext.Net.MVC.Examples.Areas.Events
{
    public class EventsAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Events";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "Events_default",
                "Events/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
