using System.Web.Mvc;

namespace Ext.Net.MVC.Examples.Areas.XRender_Basic
{
    public class XRender_BasicAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "XRender_Basic";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "XRender_Basic_default",
                "XRender_Basic/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
