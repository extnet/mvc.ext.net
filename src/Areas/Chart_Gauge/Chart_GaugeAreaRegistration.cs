using System.Web.Mvc;

namespace Ext.Net.MVC.Examples.Areas.Chart_Gauge
{
    public class Chart_GaugeAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Chart_Gauge";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "Chart_Gauge_default",
                "Chart_Gauge/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
