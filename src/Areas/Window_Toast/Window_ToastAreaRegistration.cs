using System.Web.Mvc;

namespace Ext.Net.MVC.Examples.Areas.Window_Toast
{
    public class Window_ToastAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get { return "Window_Toast"; }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "Window_Toast_default",
                "Window_Toast/{controller}/{action}/{id}",
                new {action = "Index", id = UrlParameter.Optional}
                );
        }
    }
}