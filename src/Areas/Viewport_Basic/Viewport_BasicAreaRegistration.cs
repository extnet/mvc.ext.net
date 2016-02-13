using System.Web.Mvc;

namespace Ext.Net.MVC.Examples.Areas.Viewport_Basic
{
    public class Viewport_BasicAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Viewport_Basic";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "Viewport_Basic_default",
                "Viewport_Basic/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
