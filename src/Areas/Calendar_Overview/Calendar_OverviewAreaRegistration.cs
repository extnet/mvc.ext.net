using System.Web.Mvc;

namespace Ext.Net.MVC.Examples.Areas.Calendar_Overview
{
    public class Calendar_OverviewAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Calendar_Overview";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "Calendar_Overview_default",
                "Calendar_Overview/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
