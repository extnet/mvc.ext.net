using System.Web.Mvc;

namespace Ext.Net.MVC.Examples.Areas.ColorPicker_Advanced
{
    public class ColorPicker_AdvancedAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "ColorPicker_Advanced";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "ColorPicker_Advanced_default",
                "ColorPicker_Advanced/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
