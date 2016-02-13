using System.Web.Mvc;

namespace Ext.Net.MVC.Examples.Areas.Getting_Started
{
    public class Getting_StartedAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Getting_Started";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "Getting_Started_default",
                "Getting_Started/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
