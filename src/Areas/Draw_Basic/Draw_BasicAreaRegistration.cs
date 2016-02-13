using System.Web.Mvc;

namespace Ext.Net.MVC.Examples.Areas.Draw_Basic
{
    public class Draw_BasicAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Draw_Basic";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "Draw_Basic_default",
                "Draw_Basic/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
