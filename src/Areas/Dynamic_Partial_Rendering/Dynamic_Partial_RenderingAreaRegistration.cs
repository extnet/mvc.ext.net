using System.Web.Mvc;

namespace Ext.Net.MVC.Examples.Areas.Dynamic_Partial_Rendering
{
    public class Partial_RenderingAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Dynamic_Partial_Rendering";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "Dynamic_Partial_Rendering_default",
                "Dynamic_Partial_Rendering/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
