using System.Web.Mvc;

namespace Ext.Net.MVC.Examples.Areas.Miscellaneous_Resizable
{
    public class Miscellaneous_ResizableAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Miscellaneous_Resizable";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "Miscellaneous_Resizable_default",
                "Miscellaneous_Resizable/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
