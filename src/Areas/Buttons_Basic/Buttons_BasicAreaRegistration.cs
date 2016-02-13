using System.Web.Mvc;

namespace Ext.Net.MVC.Examples.Areas.Buttons_Basic
{
    public class Buttons_BasicAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Buttons_Basic";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "Buttons_Basic_default",
                "Buttons_Basic/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
