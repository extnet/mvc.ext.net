using System.Web.Mvc;

namespace Ext.Net.MVC.Examples.Areas.PropertyGrid_Basic
{
    public class PropertyGrid_BasicAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "PropertyGrid_Basic";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "PropertyGrid_Basic_default",
                "PropertyGrid_Basic/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
