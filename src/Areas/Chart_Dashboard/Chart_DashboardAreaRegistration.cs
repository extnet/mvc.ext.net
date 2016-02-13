using System.Web.Mvc;

namespace Ext.Net.MVC.Examples.Areas.Chart_Dashboard
{
    public class Chart_DashboardAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Chart_Dashboard";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "Chart_Dashboard_default",
                "Chart_Dashboard/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
