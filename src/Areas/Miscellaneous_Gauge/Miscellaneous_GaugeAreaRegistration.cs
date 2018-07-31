using System.Web.Mvc;

namespace Ext.Net.MVC.Examples.Areas.Miscellaneous_Gauge
{
    public class Miscellaneous_GaugeAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Miscellaneous_Gauge";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "Miscellaneous_Gauge_default",
                "Miscellaneous_Gauge/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
