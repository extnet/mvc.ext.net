using System.Web.Mvc;

namespace Ext.Net.MVC.Examples.Areas.Editor_Basic
{
    public class Editor_BasicAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Editor_Basic";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "Editor_Basic_default",
                "Editor_Basic/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
