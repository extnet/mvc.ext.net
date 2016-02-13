using System.Web.Mvc;

namespace Ext.Net.MVC.Examples.Areas.ColorPicker_Basic
{
    public class ColorPicker_BasicAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "ColorPicker_Basic";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "ColorPicker_Basic_default",
                "ColorPicker_Basic/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
