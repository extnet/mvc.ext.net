using System.Web.Mvc;

namespace Ext.Net.MVC.Examples.Areas.Window_Basic
{
    public class Window_BasicAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get { return "Window_Basic"; }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "Window_Basic_default",
                "Window_Basic/{controller}/{action}/{id}",
                new {action = "Index", id = UrlParameter.Optional}
                );
        }
    }
}