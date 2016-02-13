using System.Web.Mvc;

namespace Ext.Net.MVC.Examples.Areas.Chart_Radar
{
    public class Chart_RadarAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Chart_Radar";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "Chart_Radar_default",
                "Chart_Radar/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
